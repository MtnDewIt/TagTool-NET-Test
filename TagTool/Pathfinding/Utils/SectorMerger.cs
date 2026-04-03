using System;
using System.Collections.Generic;
using System.Linq;
using TagTool.Common;

#nullable enable

namespace TagTool.Pathfinding.Utils
{
    /// <summary>
    /// Merges adjacent, coplanar, convex collision surfaces into larger sectors.
    ///
    /// Rules (matching Bungie's observed generator behaviour):
    ///   1. Surfaces must be coplanar (same plane normal and D value within epsilon).
    ///   2. Merged polygon must remain convex — no concave vertices allowed on the same plane.
    ///   3. Merged polygon must not exceed 8 sides.
    ///   4. Non-coplanar vertices are allowed in a sector provided the above rules are met
    ///      for any sub-set of vertices that lie on a single plane (i.e. ramp + flat seams).
    ///
    /// This is called once per set of walkable surfaces before sector/link generation.
    /// The return value is a new list of ProcessedSurface where merged groups are replaced
    /// by a single representative surface; the original surfaces that were consumed are
    /// removed from the list. Each returned surface may have more than the original vertex
    /// count (up to 8) if merging occurred.
    /// </summary>
    public static class SectorMerger
    {
        public static List<ProcessedSurface> MergeCoplanarSurfaces(
            List<ProcessedSurface> surfaces,
            float coplanarEpsilon = 0.01f,
            float adjacencyEpsilon = 0.01f)
        {
            // Work on a copy so we can mark surfaces consumed
            var remaining = surfaces.ToList();
            var merged = new List<ProcessedSurface>();

            while (remaining.Count > 0)
            {
                // Take the first surface as the seed for a new merge group
                var seed = remaining[0];
                remaining.RemoveAt(0);

                var group = new List<ProcessedSurface> { seed };
                bool anyMerge = true;

                // Repeatedly try to grow the group until no more candidates fit
                while (anyMerge)
                {
                    anyMerge = false;

                    for (int i = remaining.Count - 1; i >= 0; i--)
                    {
                        var candidate = remaining[i];

                        // Must be coplanar with the seed plane (all surfaces in the group share it)
                        if (!PathfindingMath.AreSurfacesCoplanar(seed, candidate, coplanarEpsilon))
                            continue;

                        // Must be adjacent to at least one surface already in the group
                        bool adjacent = group.Any(g =>
                            PathfindingMath.SurfacesAdjacent(g, candidate, adjacencyEpsilon));

                        if (!adjacent)
                            continue;

                        // Speculatively merge and check convexity + side count
                        var merged2D = TryMergeInto2DPolygon(group, candidate, seed.Plane, adjacencyEpsilon);

                        if (merged2D == null)
                            continue;

                        if (merged2D.Count > 8)
                            continue;

                        if (!PathfindingMath.IsConvex2D(merged2D))
                            continue;

                        // Accept: remove from remaining, add to group
                        group.Add(candidate);
                        remaining.RemoveAt(i);
                        anyMerge = true;
                    }
                }

                // Build the merged surface from the group
                merged.Add(BuildMergedSurface(group, seed.Plane, adjacencyEpsilon));
            }

            return merged;
        }

        // -------------------------------------------------------------------------
        // Private helpers
        // -------------------------------------------------------------------------

        /// <summary>
        /// Attempts to compute the 2D convex hull polygon that would result from merging
        /// the existing group with the candidate surface. Returns null if the merge is
        /// geometrically invalid.
        /// </summary>
        private static List<(float u, float v)>? TryMergeInto2DPolygon(
            List<ProcessedSurface> group,
            ProcessedSurface candidate,
            RealPlane3d referencePlane,
            float epsilon)
        {
            // Collect all unique 3D points from group + candidate
            var allPts = new List<RealPoint3d>();

            foreach (var s in group)
                foreach (var v in s.Vertices)
                    AddUniquePoint(allPts, v, epsilon);

            foreach (var v in candidate.Vertices)
                AddUniquePoint(allPts, v, epsilon);

            // Project onto the dominant plane axes
            var projected = allPts
                .Select(p => PathfindingMath.ProjectOntoPlane(p, referencePlane))
                .ToList();

            // Return the convex hull of all projected points
            return ConvexHull2D(projected);
        }

        /// <summary>
        /// Builds the final merged ProcessedSurface from a group, taking metadata from the
        /// first (seed) surface and computing the merged vertex list via convex hull.
        /// </summary>
        private static ProcessedSurface BuildMergedSurface(
            List<ProcessedSurface> group,
            RealPlane3d plane,
            float epsilon)
        {
            if (group.Count == 1)
                return group[0];

            var seed = group[0];

            // Collect unique 3D points
            var allPts = new List<RealPoint3d>();
            foreach (var s in group)
                foreach (var v in s.Vertices)
                    AddUniquePoint(allPts, v, epsilon);

            // Project, hull, then unproject back to 3D (keeping original Z)
            var projected = allPts.Select(p => (
                pt3d: p,
                uv: PathfindingMath.ProjectOntoPlane(p, plane)
            )).ToList();

            var hullUVs = ConvexHull2D(projected.Select(x => x.uv).ToList());
            if (hullUVs == null || hullUVs.Count == 0)
                return seed; // degenerate fallback

            // Re-map hull UVs back to 3D points
            var hullVertices = new List<RealPoint3d>();
            foreach (var uv in hullUVs)
            {
                // Find the closest original 3D point matching this projected coordinate
                var match = projected
                    .OrderBy(x => (x.uv.u - uv.u) * (x.uv.u - uv.u) + (x.uv.v - uv.v) * (x.uv.v - uv.v))
                    .First();
                hullVertices.Add(match.pt3d);
            }

            return new ProcessedSurface
            {
                Vertices = hullVertices,
                Plane = seed.Plane,
                Source = seed.Source,
                OriginalSurfaceIndex = seed.OriginalSurfaceIndex,
                OwnerIndex = seed.OwnerIndex,
            };
        }

        private static void AddUniquePoint(List<RealPoint3d> list, RealPoint3d p, float epsilon)
        {
            foreach (var existing in list)
            {
                if (PathfindingMath.PointsEqual(existing, p, epsilon))
                    return;
            }
            list.Add(p);
        }

        /// <summary>
        /// Andrew's monotone chain convex hull. O(n log n).
        /// Returns hull vertices in counter-clockwise order, or null if degenerate.
        /// </summary>
        private static List<(float u, float v)>? ConvexHull2D(List<(float u, float v)> pts)
        {
            int n = pts.Count;
            if (n < 3)
                return pts.Count > 0 ? pts : null;

            var sorted = pts.OrderBy(p => p.u).ThenBy(p => p.v).ToList();

            var lower = new List<(float u, float v)>();
            foreach (var p in sorted)
            {
                while (lower.Count >= 2 && Cross(lower[^2], lower[^1], p) <= 0)
                    lower.RemoveAt(lower.Count - 1);
                lower.Add(p);
            }

            var upper = new List<(float u, float v)>();
            for (int i = sorted.Count - 1; i >= 0; i--)
            {
                var p = sorted[i];
                while (upper.Count >= 2 && Cross(upper[^2], upper[^1], p) <= 0)
                    upper.RemoveAt(upper.Count - 1);
                upper.Add(p);
            }

            // Remove last point of each half because it is repeated
            lower.RemoveAt(lower.Count - 1);
            upper.RemoveAt(upper.Count - 1);

            lower.AddRange(upper);
            return lower.Count >= 3 ? lower : null;
        }

        private static float Cross((float u, float v) O, (float u, float v) A, (float u, float v) B)
        {
            return (A.u - O.u) * (B.v - O.v) - (A.v - O.v) * (B.u - O.u);
        }
    }
}
