﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TagTool.Common;
using TagTool.Commands.Common;
using TagTool.IO;
using System.IO;
using TagTool.Tags;
using TagTool.Common.Logging;

namespace TagTool.Geometry.BspCollisionGeometry.Utils
{
    public class LargeCollisionBSPBuilder
    {
        public LargeCollisionBspBlock Bsp { get; set; }
        private bool debug = false;
        private int original_surface_count = 0;
        public List<int> surface_addendums = new List<int>();
        //error geometry 
        private ErrorGeometryBuilder Errors = new ErrorGeometryBuilder();
        private bool hasErrors = false;
        public bool useleafmap = false;

        public bool generate_bsp(ref LargeCollisionBspBlock bsp, bool debug_arg = false)
        {
            Bsp = bsp.DeepClone();

            Errors = new ErrorGeometryBuilder();
            hasErrors = false;

            if (debug_arg == true)
                debug = true;

            //make sure there is nothing in the bsp blocks before starting
            Bsp.Leaves.Clear();
            Bsp.Bsp2dNodes.Clear();
            Bsp.Bsp2dReferences.Clear();
            Bsp.Bsp3dNodes.Clear();

            //allocate surface array before starting the bsp build
            surface_array_definition surface_array = new surface_array_definition { free_count = 0, used_count = 0, surface_array = new List<int>() };
            for (int i = 0; i < Bsp.Surfaces.Count; i++)
            {
                //starting in reach, some surfaces use the plane negated flag instead of negating the plane index
                if (Bsp.Surfaces[i].Flags.HasFlag(SurfaceFlags.PlaneNegated))
                {
                    //negate the plane index and remove the surface flag to match H3 standard
                    Bsp.Surfaces[i].Plane = (int)(Bsp.Surfaces[i].Plane | 0x80000000);
                    Bsp.Surfaces[i].Flags &= ~SurfaceFlags.PlaneNegated;
                }

                //if the surface is invalid (first seen in reach), ignore it 
                if (Bsp.Surfaces[i].Flags.HasFlag(SurfaceFlags.Invalid))
                    continue;

                surface_array.surface_array.Add((int)(i | 0x80000000));
                surface_array.free_count++;
            }

            //populate surface_addendums list for usage later on
            original_surface_count = Bsp.Surfaces.Count;
            surface_addendums = new List<int>();
            for (int surface_index = 0; surface_index < Bsp.Surfaces.Count; surface_index++)
            {
                surface_addendums.Add(surface_index);
            }

            int bsp3dnode_index = -1;
            if (build_bsp_tree_main(surface_array, ref bsp3dnode_index))
            {
                //Console.WriteLine($"###Collision bsp R{region_index}P{permutation_index}B{bsp_index} built successfully!");
            }
            else
            {
                Console.WriteLine($"###Failed to build collision bsp!");
                if (hasErrors && debug)
                    Errors.WriteOBJ();
                return false;
            }

            if (!verify_collision_bsp())
            {
                Console.WriteLine($"###Failed to verify collision bsp!");
                return false;
            }

            if (useleafmap)
            {
                LeafMap leafmapbuilder = new LeafMap();
                LargeCollisionBspBlock bsp_copy = Bsp.DeepClone();
                if (!leafmapbuilder.munge_collision_bsp(this))
                {
                    Log.Warning("Failed to build leaf map!");
                    Bsp = bsp_copy;
                }
            }

            if (!prune_node_tree())
            {
                Console.WriteLine($"###Failed to prune node tree!");
                return false;
            }

            if (hasErrors && debug)
                Errors.WriteOBJ();

            bsp = Bsp.DeepClone();
            return true;
        }

        public int bsp_tree_decision_switch(ref surface_array_definition surface_array)
        {
            //IMPORTANT NOTE: a negative surface index indicates a front face (in front of splitting plane), 
            //whereas a positive surface index indicates a back face (behind splitting plane)

            //Also, a used surface is one that has been on one of the node planes used thus far, 
            //whereas a free surface has not been on any node planes

            int surface_array_total_count = surface_array.used_count + surface_array.free_count;
            if (surface_array_total_count <= 0)
                return 2;
            int free_surfaces_backface = 0;
            int used_surfaces_backface = 0;
            int used_surfaces_frontface = 0;

            //tabulate the free/used and front/back face counts
            for (int surface_index_index = 0; surface_index_index < surface_array_total_count; surface_index_index++)
            {
                int surface_index = surface_array.surface_array[surface_index_index];
                if (surface_index_index >= surface_array.free_count) //surface is used
                {
                    if (surface_index >= 0)
                        used_surfaces_backface++;
                    else
                        used_surfaces_frontface++;
                }
                else //surface is free
                {
                    if (surface_index < 0)
                        return 1; //if there is a free surface that is a front face, create bsp3dnodes
                    free_surfaces_backface++;
                }
            }

            //from here, all surfaces must be used or be backfaces, no free front faces must exist

            //make 3dnodes if there are only FREE BACKFACES
            if (free_surfaces_backface > 0 && used_surfaces_backface == 0)
                return 1;
            //make 2dnodes if there are only USED FRONTFACES
            if (free_surfaces_backface == 0 && used_surfaces_backface == 0)
                return 2;
            //OTHERWISE RECALCULATE IF THERE IS A MIXTURE
            if (used_surfaces_frontface > 0 || used_surfaces_backface <= 0)
                return surface_array_recalculate_counts(ref surface_array);
            //BUT FAIL if there are only USED BACKFACES
            return 3;
        }

        public int surface_array_recalculate_counts(ref surface_array_definition surface_array)
        {
            surface_array_definition surface_counts = new surface_array_definition();
            surface_array_definition new_surface_array = new surface_array_definition { surface_array = new List<int>(), free_count = 0, used_count = 0 };
            double surface_areas_frontface = 0;
            double surface_areas_backface = 0;

            //Iterate through used surfaces -- those than have been on node planes
            //COMPARE combined surface area of front faces to combined surface area of backfaces
            if (surface_array.used_count > 0)
            {
                for (int surface_index_index = 0; surface_index_index < surface_array.used_count; surface_index_index++)
                {
                    int surface_index = surface_array.surface_array[surface_index_index + surface_array.free_count];
                    double current_surface_area = surface_calculate_area(surface_index & 0x7FFFFFFF);
                    new_surface_array.surface_array.Add(surface_index);
                    if (surface_index < 0)
                    {
                        surface_counts.used_count++;
                        surface_areas_frontface += current_surface_area;
                    }
                    else
                    {
                        surface_counts.free_count++;
                        surface_areas_backface += current_surface_area;
                    }
                }
            }
            int new_surfaces_count = surface_counts.free_count + surface_counts.used_count;
            new_surface_array.used_count = new_surfaces_count;

            surfaces_check_if_intersecting(new_surface_array);

            if (surface_areas_frontface * 4.0f <= surface_areas_backface)
            {
                surface_array = new_surface_array.DeepClone();
                return 3;
            }

            surface_array_definition new_surface_array_B = new surface_array_definition { surface_array = new List<int>(), free_count = 0, used_count = 0 };
            for (int surface_index_index = 0; surface_index_index < new_surface_array.used_count; surface_index_index++)
            {
                int surface_index = new_surface_array.surface_array[surface_index_index];
                if (surface_index < 0)
                {
                    new_surface_array_B.surface_array.Add(surface_index);
                }
            }
            new_surface_array_B.used_count = new_surface_array_B.surface_array.Count;
            surface_array = new_surface_array_B.DeepClone();
            return 2;
        }

        public bool planes_get_intersection(RealPlane3d planeA, RealPlane3d planeB, ref RealVector3d intersection_point, ref RealVector3d intersection_vector)
        {
            RealVector3d vectorplaneA = new RealVector3d(planeA.I, planeA.J, planeA.K);
            RealVector3d vectorplaneB = new RealVector3d(planeB.I, planeB.J, planeB.K);

            //cross product of plane normal vectors
            intersection_vector = RealVector3d.CrossProduct(vectorplaneA, vectorplaneB);

            //If the plane normal vectors are nearly identical, the planes won't overlap, so return false
            float vector_magnitude = RealVector3d.Magnitude(intersection_vector);
            if (Math.Abs(vector_magnitude) < 0.00009999999747378752)
                return false;

            RealVector3d componentA = RealVector3d.CrossProduct(intersection_vector, vectorplaneA);
            RealVector3d componentB = RealVector3d.CrossProduct(vectorplaneB, intersection_vector);
            componentA = componentA * planeB.D;
            componentB = componentB * planeA.D;

            intersection_point = componentA + componentB;

            //divide intersection_point by the magnitude of the cross product of the two plane normals
            intersection_point = intersection_point / vector_magnitude;

            return true;
        }

        public bool intersecting_surface_get_intersection_line(int surface_index, RealVector3d intersection_point, RealVector3d intersection_vector, ref Bounds<float> Bounds)
        {
            LargeSurface surface_block = Bsp.Surfaces[surface_index & 0x7FFFFFFF];
            int plane_index = surface_block.Plane;
            Plane plane_block = Bsp.Planes[surface_block.Plane & 0x7FFFFFFF];
            int plane_projection_axis = plane_get_projection_coefficient(plane_block.Value);
            bool plane_projection_positive = plane_get_projection_sign(plane_block.Value, plane_projection_axis);
            int plane_mirror_check = plane_projection_positive != (plane_index < 0) ? 1 : 0;

            RealPoint3d intersection_point_vertex = new RealPoint3d(intersection_point.I, intersection_point.J, intersection_point.K);
            RealPoint3d intersection_vector_vertex = new RealPoint3d(intersection_vector.I, intersection_vector.J, intersection_vector.K);
            RealPoint2d CoordsP = vertex_get_projection_relevant_coords(intersection_point_vertex, plane_projection_axis, plane_mirror_check);
            RealPoint2d CoordsV = vertex_get_projection_relevant_coords(intersection_vector_vertex, plane_projection_axis, plane_mirror_check);

            Bounds.Upper = float.MinValue;
            Bounds.Lower = float.MaxValue;

            int first_Edge_index = surface_block.FirstEdge;
            int current_edge_index = surface_block.FirstEdge;
            do
            {
                LargeEdge edge_block = Bsp.Edges[current_edge_index];
                bool surface_is_right_of_edge = edge_block.RightSurface == surface_index;

                LargeVertex VertexA = Bsp.Vertices[surface_is_right_of_edge ? edge_block.EndVertex : edge_block.StartVertex];
                LargeVertex VertexB = Bsp.Vertices[surface_is_right_of_edge ? edge_block.StartVertex : edge_block.EndVertex];
                RealPoint2d CoordsA = vertex_get_projection_relevant_coords(VertexA.Point, plane_projection_axis, plane_mirror_check);
                RealPoint2d CoordsB = vertex_get_projection_relevant_coords(VertexB.Point, plane_projection_axis, plane_mirror_check);

                RealPoint2d diffBA = CoordsB - CoordsA;
                RealPoint2d diffPA = CoordsP - CoordsA;

                //VBA cross should be the cross product between:
                //      the plane projected vector between this edge's two vertices
                //      the plane projected intersection vector
                float VBA_cross = diffBA.Y * CoordsV.X - CoordsV.Y * diffBA.X;
                //BAPA cross should be the cross product between:
                //      the plane projected vector between this edge's two vertices
                //      the plane projected vector between the intersection point and the first vertex on the edge
                float BAPA_cross = diffBA.X * diffPA.Y - diffBA.Y * diffPA.X;

                if (VBA_cross == 0.0)
                {
                    if (BAPA_cross < 0.0)
                        return false;
                }
                else
                {
                    float cross_ratio = BAPA_cross / VBA_cross;
                    if (VBA_cross >= 0.0)
                    {
                        if (cross_ratio < Bounds.Lower)
                            Bounds.Lower = cross_ratio;
                    }
                    else if (cross_ratio > Bounds.Upper)
                        Bounds.Upper = cross_ratio;
                    if (Bounds.Upper > Bounds.Lower)
                        return false;
                }
                current_edge_index = surface_is_right_of_edge ? edge_block.ReverseEdge : edge_block.ForwardEdge;
            }
            while (current_edge_index != first_Edge_index);
            return true;
        }

        public bool surfaces_check_if_intersecting_internal(int surface_index_A, int surface_index_B, ref RealPoint3d Point0, ref RealPoint3d Point1)
        {
            LargeSurface surfaceA = Bsp.Surfaces[surface_index_A & 0x7FFFFFFF];
            LargeSurface surfaceB = Bsp.Surfaces[surface_index_B & 0x7FFFFFFF];
            int plane_index_A = surfaceA.Plane & 0x7FFFFFFF;
            int plane_index_B = surfaceB.Plane & 0x7FFFFFFF;
            RealPlane3d plane_A = Bsp.Planes[plane_index_A].Value;
            RealPlane3d plane_B = Bsp.Planes[plane_index_B].Value;

            Plane_Relationship relationshipA = determine_surface_plane_relationship(surface_index_A, plane_index_B, new RealPlane3d());
            Plane_Relationship relationshipB = determine_surface_plane_relationship(surface_index_B, plane_index_A, new RealPlane3d());

            //the two surfaces should each be on both sides of the plane belonging to the other surface if they are z-buffered
            if (relationshipA != Plane_Relationship.BothSidesofPlane || relationshipB != Plane_Relationship.BothSidesofPlane)
                return false;

            RealVector3d intersection_point = new RealVector3d();
            RealVector3d intersection_vector = new RealVector3d();
            if (!planes_get_intersection(plane_A, plane_B, ref intersection_point, ref intersection_vector))
                return false;

            Bounds<float> BoundsA = new Bounds<float>();
            Bounds<float> BoundsB = new Bounds<float>();
            if (!intersecting_surface_get_intersection_line(surface_index_A, intersection_point, intersection_vector, ref BoundsA) ||
                !intersecting_surface_get_intersection_line(surface_index_B, intersection_point, intersection_vector, ref BoundsB))
                return false;

            if (BoundsA.Upper <= BoundsB.Upper)
                BoundsA.Upper = BoundsB.Upper;

            BoundsB.Upper = BoundsA.Lower <= BoundsB.Lower ? BoundsA.Lower : BoundsB.Lower;

            if (BoundsB.Upper - BoundsA.Upper <= 0.000099999997)
                return false;

            //these two points will be used to identify the region of overlap
            Point0 = point_from_point_and_vector(intersection_point, intersection_vector, BoundsA.Upper);
            Point1 = point_from_point_and_vector(intersection_point, intersection_vector, BoundsB.Upper);

            return true;
        }

        public RealPoint3d point_from_point_and_vector(RealVector3d vertex_A, RealVector3d vector_B, float vector_fraction)
        {
            return new RealPoint3d
            {
                X = vector_fraction * vector_B.I + vertex_A.I,
                Y = vector_fraction * vector_B.J + vertex_A.J,
                Z = vector_fraction * vector_B.K + vertex_A.K,
            };
        }

        public bool surfaces_check_if_intersecting(surface_array_definition surface_array)
        {
            bool warning_posted = false;
            if (surface_array.used_count > 0)
            {
                for (int used_surface_index = 0; used_surface_index < surface_array.used_count; used_surface_index++)
                {
                    int surface_index = surface_array.surface_array[surface_array.free_count + used_surface_index] & 0x7FFFFFFF;
                    while (surface_index >= original_surface_count)
                    {
                        surface_index = surface_addendums[surface_index];
                    }
                    //compare this surface with every other used surface currently in the array
                    for (int second_used_surface_index = 0; second_used_surface_index < surface_array.used_count; second_used_surface_index++)
                    {
                        int second_surface_index = surface_array.surface_array[surface_array.free_count + second_used_surface_index] & 0x7FFFFFFF;
                        while (second_surface_index >= original_surface_count)
                        {
                            second_surface_index = surface_addendums[second_surface_index];
                        }

                        RealPoint3d Point0 = new RealPoint3d();
                        RealPoint3d Point1 = new RealPoint3d();
                        if (surfaces_check_if_intersecting_internal(surface_index, second_surface_index, ref Point0, ref Point1))
                        {
                            if (!warning_posted && debug)
                            {
                                Console.WriteLine("### ERROR found intersecting surfaces");
                                warning_posted = true;
                            }
                            //Error geometry output
                            hasErrors = true;
                            List<int> ErrorIndices = new List<int>();
                            Errors.Vertices.Add(Point0);
                            ErrorIndices.Add(Errors.Vertices.Count);
                            Errors.Vertices.Add(Point1);
                            ErrorIndices.Add(Errors.Vertices.Count);
                            Errors.Geometry.Add(new ErrorGeometryBuilder.error_geometry
                            {
                                Type = ErrorGeometryBuilder.error_geometry_type.intersectingsurface,
                                Indices = ErrorIndices
                            });
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public RealPlane3d plane_get_equation_parameters(int plane_index)
        {
            RealPlane3d plane_equation = new RealPlane3d();
            Plane plane_block = Bsp.Planes[plane_index & 0x7FFFFFFF];
            if (plane_index >= 0)
            {
                plane_equation = plane_block.Value;
            }
            else
            {
                plane_equation.I = -plane_block.Value.I;
                plane_equation.J = -plane_block.Value.J;
                plane_equation.K = -plane_block.Value.K;
                plane_equation.D = -plane_block.Value.D;
            }
            return plane_equation;
        }

        public bool build_bsp_tree_main(surface_array_definition surface_array, ref int bsp3dnode_index)
        {
            int switch_arg = 3;
            switch_arg = bsp_tree_decision_switch(ref surface_array);

            switch (switch_arg)
            {
                case 1: //construct bsp3d nodes
                    plane_splitting_parameters splitting_parameters = find_surface_splitting_plane(surface_array);
                    //these arrays need to be initialized with empty elements so that specific indices can be directly assigned
                    surface_array_definition back_surface_array = new surface_array_definition { free_count = splitting_parameters.BackSurfaceCount, used_count = splitting_parameters.BackSurfaceUsedCount, surface_array = new List<int>(new int[splitting_parameters.BackSurfaceCount + splitting_parameters.BackSurfaceUsedCount]) };
                    surface_array_definition front_surface_array = new surface_array_definition { free_count = splitting_parameters.FrontSurfaceCount, used_count = splitting_parameters.FrontSurfaceUsedCount, surface_array = new List<int>(new int[splitting_parameters.FrontSurfaceCount + splitting_parameters.FrontSurfaceUsedCount]) };

                    //here we are going to preserve the current counts of the various geometry primitives, so that they can be reset later
                    int vertex_block_count = Bsp.Vertices.Count;
                    int surface_block_count = Bsp.Surfaces.Count;
                    int edges_block_count = Bsp.Edges.Count;

                    if (!split_object_surfaces_with_plane(surface_array, splitting_parameters.plane_index, ref back_surface_array, ref front_surface_array))
                    {
                        Console.WriteLine("###ERROR Failed to split surface!");
                        return false;
                    }
                    Bsp.Bsp3dNodes.Add(new LargeBsp3dNode { FrontChild = -1, BackChild = -1 });
                    int current_bsp3dnode_index = Bsp.Bsp3dNodes.Count - 1;
                    int back_child_node_index = -1;
                    int front_child_node_index = -1;

                    //this function is recursive, and continues branching until no more 3d nodes can be made
                    if (build_bsp_tree_main(back_surface_array, ref back_child_node_index) && build_bsp_tree_main(front_surface_array, ref front_child_node_index))
                    {
                        LargeBsp3dNode node = new LargeBsp3dNode {Plane = -1, BackChild = -1, FrontChild = -1 };

                        node.Plane = splitting_parameters.plane_index < 0 ? (int)(splitting_parameters.plane_index | 0x80000000) : splitting_parameters.plane_index;
                        node.FrontChild = front_child_node_index;
                        node.BackChild = back_child_node_index;

                        Bsp.Bsp3dNodes[current_bsp3dnode_index] = node;

                        bsp3dnode_index = current_bsp3dnode_index;
                    }
                    else
                    {
                        if (debug)
                            Console.WriteLine("###ERROR couldn't build surface lists.");
                        return false;
                    }

                    //here we are going to reset the counts of the various geometry primitives to their prior state
                    while (Bsp.Vertices.Count > vertex_block_count)
                        Bsp.Vertices.RemoveAt(Bsp.Vertices.Count - 1);
                    while (Bsp.Surfaces.Count > surface_block_count)
                        Bsp.Surfaces.RemoveAt(Bsp.Surfaces.Count - 1);
                    while (Bsp.Edges.Count > edges_block_count)
                        Bsp.Edges.RemoveAt(Bsp.Edges.Count - 1);
                    while (surface_addendums.Count > surface_block_count)
                        surface_addendums.RemoveAt(surface_addendums.Count - 1);

                    return true;
                case 2: //build leaves
                    if (surfaces_reset_for_leaf_building(ref surface_array) == -1)
                    {
                        Console.WriteLine("###ERROR tried to build leaves while there are free surfaces.");
                        return false;
                    }
                    int leaf_index = -1;
                    if (build_leaves(ref surface_array, ref leaf_index))
                    {
                        bsp3dnode_index = (int)(leaf_index | 0x80000000);
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("###ERROR couldn't build leaf.");
                        return false;
                    }
                case 3: //all done!
                    bsp3dnode_index = -1;
                    return true;
                default:
                    Console.WriteLine("###ERROR couldn't decide what to build.");
                    return false;
            }
        }

        public int surfaces_reset_for_leaf_building(ref surface_array_definition surface_array)
        {
            if (surface_array.free_count > 0)
                return -1;
            for (int surface_index_index = 0; surface_index_index < surface_array.used_count; surface_index_index++)
            {
                int surface_index = surface_array.surface_array[surface_index_index] & 0x7FFFFFFF;
                while (surface_index >= original_surface_count)
                {
                    surface_index = surface_addendums[surface_index];
                }
                surface_array.surface_array[surface_index_index] = (int)(surface_index | 0x80000000);
            }
            return surface_array.used_count;
        }

        public surface_array_definition collect_plane_matching_surfaces(ref surface_array_definition surface_array, int plane_index)
        {
            surface_array_definition plane_matched_surface_array = new surface_array_definition { surface_array = new List<int>() };
            for (int surface_array_index = 0; surface_array_index < surface_array.used_count; surface_array_index++)
            {
                int surface_index = surface_array.surface_array[surface_array_index];
                int absolute_surface_index = surface_index & 0x7FFFFFFF;

                int test_plane = Bsp.Surfaces[absolute_surface_index].Plane;
                if (surface_index < 0 && test_plane == plane_index)
                {
                    plane_matched_surface_array.surface_array.Add(absolute_surface_index);
                    //reset plane matching surfaces in the primary array to an unflagged state
                    surface_array.surface_array[surface_array_index] = absolute_surface_index;
                }
            }
            return plane_matched_surface_array;
        }

        public int plane_get_projection_coefficient(RealPlane3d plane)
        {
            int minimum_coefficient;
            float plane_I = Math.Abs(plane.I);
            float plane_J = Math.Abs(plane.J);
            float plane_K = Math.Abs(plane.K);
            if (plane_K < plane_J || plane_K < plane_I)
            {
                if (plane_J >= plane_I)
                    minimum_coefficient = 1;
                else
                    minimum_coefficient = 0;
            }
            else
                minimum_coefficient = 2;
            return minimum_coefficient;
        }

        public bool plane_get_projection_sign(RealPlane3d plane, int projection_axis)
        {
            switch (projection_axis)
            {
                case 0: //x axis
                    return plane.I > 0.0f;
                case 1: //y axis
                    return plane.J > 0.0f;
                case 2: //z axis
                    return plane.K > 0.0f;
            }
            return false;
        }

        public void sort_surfaces_by_plane_2D(plane_splitting_parameters splitting_parameters, int plane_projection_axis, int plane_mirror_check, LargeBsp2dNode bsp2dnode_block, surface_array_definition plane_matched_surface_array, surface_array_definition back_surface_array, surface_array_definition front_surface_array)
        {
            int back_surface_count = 0;
            int front_surface_count = 0;
            foreach (int surface_index in plane_matched_surface_array.surface_array)
            {
                Plane_Relationship surface_location = determine_surface_plane_relationship_2D(surface_index, bsp2dnode_block, plane_projection_axis, plane_mirror_check);
                if (surface_location.HasFlag(Plane_Relationship.BackofPlane))
                {
                    back_surface_array.surface_array[back_surface_count] = surface_index;
                    back_surface_count++;
                }
                if (surface_location.HasFlag(Plane_Relationship.FrontofPlane))
                {
                    front_surface_array.surface_array[front_surface_count] = surface_index;
                    front_surface_count++;
                }
            }
            if (front_surface_count != splitting_parameters.FrontSurfaceCount)
            {
                Console.WriteLine("###ERROR BSP2D front_surface_index_index!=front_surface_index_count");
            }
            if (back_surface_count != splitting_parameters.BackSurfaceCount)
            {
                Console.WriteLine("###ERROR BSP2D back_surface_index_index!=back_surface_index_count");
            }
        }

        public int create_bsp2dnodes(int plane_projection_axis, int plane_mirror_check, surface_array_definition plane_matched_surface_array)
        {
            int bsp2dnode_index = -1;
            int back_bsp2dnode_index = -1;
            int front_bsp2dnode_index = -1;
            if (plane_matched_surface_array.surface_array.Count <= 1)
                return (int)(plane_matched_surface_array.surface_array[0] | 0x80000000);
            LargeBsp2dNode bsp2dnode_block = new LargeBsp2dNode() { LeftChild = -1, RightChild = -1 };
            plane_splitting_parameters splitting_parameters = new plane_splitting_parameters();
            bool warning_posted = false;

            while (plane_matched_surface_array.surface_array.Count > 1)
            {
                splitting_parameters = generate_best_splitting_plane_2D(plane_projection_axis, plane_mirror_check, ref bsp2dnode_block, plane_matched_surface_array);
                //check to see that a valid split was found
                if (splitting_parameters.plane_splitting_effectiveness < double.MaxValue)
                {
                    break;
                }
                else
                {
                    if (!warning_posted && debug)
                    {
                        Console.WriteLine("###ERROR Overlapping surfaces found!");
                        foreach (int surface_index in plane_matched_surface_array.surface_array)
                        {
                            int abs_surface_index = surface_index & 0x7FFFFFFF;
                            //Error geometry output
                            hasErrors = true;
                            List<int> ErrorIndices = new List<int>();
                            foreach (var vert in surface_get_vertices(abs_surface_index))
                            {
                                Errors.Vertices.Add(vert);
                                ErrorIndices.Add(Errors.Vertices.Count);
                            }
                            Errors.Geometry.Add(new ErrorGeometryBuilder.error_geometry
                            {
                                Type = ErrorGeometryBuilder.error_geometry_type.overlappingsurface,
                                Indices = ErrorIndices
                            });
                        }
                        warning_posted = true;
                    }

                    //this addendum to the function is a bit of black magic from H2Tool.exe. 
                    //the surface with the smallest surface area is just removed from the leaf, as this is most likely to be the issue
                    //This ultimately allows bsp compilation to complete even when there are 'overlapping' surfaces
                    int remove_surface_index = -1;
                    double smallest_surface_area = double.MaxValue;
                    for (var i = 0; i < plane_matched_surface_array.surface_array.Count; i++)
                    {
                        double current_surface_area = surface_calculate_area(plane_matched_surface_array.surface_array[i] & 0x7FFFFFFF);
                        if (current_surface_area < smallest_surface_area)
                        {
                            smallest_surface_area = current_surface_area;
                            remove_surface_index = i;
                        }
                    }
                    plane_matched_surface_array.surface_array.RemoveAt(remove_surface_index);
                }
            }

            if (plane_matched_surface_array.surface_array.Count <= 1)
                return (int)(plane_matched_surface_array.surface_array[0] | 0x80000000);

            surface_array_definition back_surface_array = new surface_array_definition { surface_array = new List<int>(new int[splitting_parameters.BackSurfaceCount]) };
            surface_array_definition front_surface_array = new surface_array_definition { surface_array = new List<int>(new int[splitting_parameters.FrontSurfaceCount]) };

            Bsp.Bsp2dNodes.Add(bsp2dnode_block);
            bsp2dnode_index = Bsp.Bsp2dNodes.Count - 1;

            sort_surfaces_by_plane_2D(splitting_parameters, plane_projection_axis, plane_mirror_check, bsp2dnode_block, plane_matched_surface_array, back_surface_array, front_surface_array);

            //create a child node with the back surface array first
            back_bsp2dnode_index = create_bsp2dnodes(plane_projection_axis, plane_mirror_check, back_surface_array);
            if (back_bsp2dnode_index == -1)
            {
                bsp2dnode_index = -1;
            }
            else
            {
                front_bsp2dnode_index = create_bsp2dnodes(plane_projection_axis, plane_mirror_check, front_surface_array);
                if (front_bsp2dnode_index == -1)
                {
                    bsp2dnode_index = -1;
                }
                else
                {
                    //move the flag so that it won't get chopped off in the int cast
                    Bsp.Bsp2dNodes[bsp2dnode_index].LeftChild = back_bsp2dnode_index < 0 ? (int)(back_bsp2dnode_index | 0x80000000) : back_bsp2dnode_index;
                    Bsp.Bsp2dNodes[bsp2dnode_index].RightChild = front_bsp2dnode_index < 0 ? (int)(front_bsp2dnode_index | 0x80000000) : front_bsp2dnode_index;
                }
            }
            return bsp2dnode_index;
        }

        public double surface_calculate_area(int surface_index)
        {
            double surface_area = 0;
            LargeSurface surface_block = Bsp.Surfaces[surface_index];
            RealPlane3d plane = Bsp.Planes[surface_block.Plane & 0x7FFFFFFF].Value;
            int first_Edge_index = surface_block.FirstEdge;

            int current_edge_index = surface_block.FirstEdge;
            LargeEdge edge_block = Bsp.Edges[current_edge_index];
            bool surface_is_right_of_edge = edge_block.RightSurface == surface_index;

            LargeVertex BaseVertex = Bsp.Vertices[surface_is_right_of_edge ? edge_block.EndVertex : edge_block.StartVertex];

            //after collecting the base vertex, move to the next edge so two more can be collected
            current_edge_index = surface_is_right_of_edge ? edge_block.ReverseEdge : edge_block.ForwardEdge;
            edge_block = Bsp.Edges[current_edge_index];
            surface_is_right_of_edge = edge_block.RightSurface == surface_index;

            if ((surface_is_right_of_edge ? edge_block.ReverseEdge : edge_block.ForwardEdge) != surface_block.FirstEdge)
            {
                do
                {
                    LargeVertex VertexA = Bsp.Vertices[surface_is_right_of_edge ? edge_block.EndVertex : edge_block.StartVertex];
                    LargeVertex VertexB = Bsp.Vertices[surface_is_right_of_edge ? edge_block.StartVertex : edge_block.EndVertex];

                    RealPoint3d d10 = VertexA.Point - BaseVertex.Point;
                    RealPoint3d d20 = VertexB.Point - BaseVertex.Point;

                    double v19 = d20.Z * d10.Y - d20.Y * d10.Z;
                    double v20 = d20.X * d10.Z - d20.Z * d10.X;
                    double v21 = d20.Y * d10.X - d20.X * d10.Y;
                    double current_surface_area = plane.I * v19 + plane.J * v20 + plane.K * v21;
                    surface_area += current_surface_area;

                    current_edge_index = surface_is_right_of_edge ? edge_block.ReverseEdge : edge_block.ForwardEdge;
                    edge_block = Bsp.Edges[current_edge_index];
                    surface_is_right_of_edge = edge_block.RightSurface == surface_index;
                }
                while (current_edge_index != first_Edge_index);
            }
            //account for surfaces on the plane with an inverted normal
            if ((surface_block.Plane & 0x80000000) != 0)
                surface_area = -surface_area;
            if (surface_area <= 0.0)
                return 0.0;

            return surface_area;
        }

        List<RealPoint3d> surface_get_vertices(int surface_index)
        {
            LargeSurface surface_block = Bsp.Surfaces[surface_index];
            int first_Edge_index = surface_block.FirstEdge;
            int current_edge_index = surface_block.FirstEdge;
            List<RealPoint3d> vertexlist = new List<RealPoint3d>();
            do
            {
                LargeEdge edge_block = Bsp.Edges[current_edge_index];
                if (edge_block.RightSurface == surface_index)
                {
                    current_edge_index = edge_block.ReverseEdge;
                    vertexlist.Add(Bsp.Vertices[edge_block.EndVertex].Point);
                }
                else
                {
                    current_edge_index = edge_block.ForwardEdge;
                    vertexlist.Add(Bsp.Vertices[edge_block.StartVertex].Point);
                }
            }
            while (current_edge_index != first_Edge_index);
            return vertexlist;
        }

        public void debug_print_vertices(List<RealPoint3d> vertexlist)
        {
            foreach (RealPoint3d vertex in vertexlist)
            {
                RealPoint3d vertex_fix = vertex * 100.0f;
                Console.WriteLine($"{vertex_fix.X} , {vertex_fix.Y} , {vertex_fix.Z}");
                Console.WriteLine($"{vertex_fix.X} , {-vertex_fix.Z} , {vertex_fix.Y} (Blender Convention)");
            }
        }

        public bool build_leaves(ref surface_array_definition surface_array, ref int leaf_index)
        {
            bool result = true;

            Bsp.Leaves.Add(new Leaf());
            leaf_index = Bsp.Leaves.Count - 1;

            //allocate initial leaf values
            Bsp.Leaves[leaf_index].Flags = 0;
            Bsp.Leaves[leaf_index].Bsp2dReferenceCount = 0;
            Bsp.Leaves[leaf_index].FirstBsp2dReference = 0xFFFFFFFF;

            for (int surface_array_index = 0; surface_array_index < surface_array.free_count + surface_array.used_count; surface_array_index++)
            {
                int surface_index = surface_array.surface_array[surface_array_index];
                LargeSurface surface_block = Bsp.Surfaces[surface_index & 0x7FFFFFFF];

                //carry over surface flags
                if (surface_block.Flags.HasFlag(SurfaceFlags.TwoSided))
                    Bsp.Leaves[leaf_index].Flags |= LeafFlags.ContainsDoubleSidedSurfaces;

                if (surface_index < 0)
                {
                    int plane_index = surface_block.Plane;
                    surface_array_definition plane_matched_surface_array = collect_plane_matching_surfaces(ref surface_array, plane_index);
                    if (plane_matched_surface_array.surface_array.Count > 0)
                    {
                        Bsp.Bsp2dReferences.Add(new LargeBsp2dReference());
                        int bsp2drefindex = Bsp.Bsp2dReferences.Count - 1;
                        Plane plane_block = Bsp.Planes[plane_index & 0x7FFFFFFF];
                        Bsp.Bsp2dReferences[bsp2drefindex].PlaneIndex = plane_index;
                        Bsp.Bsp2dReferences[bsp2drefindex].Bsp2dNodeIndex = -1;

                        //update leaf block parameters given new bsp2dreference
                        Bsp.Leaves[leaf_index].Bsp2dReferenceCount++;
                        if (Bsp.Leaves[leaf_index].FirstBsp2dReference == 0xFFFFFFFF)
                            Bsp.Leaves[leaf_index].FirstBsp2dReference = (uint)bsp2drefindex;

                        int plane_projection_axis = plane_get_projection_coefficient(plane_block.Value);
                        bool plane_projection_positive = plane_get_projection_sign(plane_block.Value, plane_projection_axis);
                        int plane_mirror_check = plane_projection_positive != (plane_index < 0) ? 1 : 0;

                        int bsp2dnodeindex = create_bsp2dnodes(plane_projection_axis, plane_mirror_check, plane_matched_surface_array);
                        Bsp.Bsp2dReferences[bsp2drefindex].Bsp2dNodeIndex = bsp2dnodeindex < 0 ? (int)(bsp2dnodeindex | 0x80000000) : bsp2dnodeindex;
                        if (bsp2dnodeindex == -1)
                        {
                            Console.WriteLine("###ERROR couldn't build bsp2d.");
                            result = false;
                        }
                    }
                }
            }
            return result;
        }

        public bool divide_surface_into_two_surfaces(int original_surface_index, int plane_index, int new_surface_index_A, int new_surface_index_B)
        {
            RealPlane3d plane_block = Bsp.Planes[plane_index].Value;
            LargeSurface original_surface = Bsp.Surfaces[original_surface_index];

            //copy over values that won't change
            Bsp.Surfaces[new_surface_index_A].Flags = original_surface.Flags;
            Bsp.Surfaces[new_surface_index_A].BreakableSurface = original_surface.BreakableSurface;
            Bsp.Surfaces[new_surface_index_A].Plane = original_surface.Plane;
            Bsp.Surfaces[new_surface_index_A].FirstEdge = int.MaxValue;
            Bsp.Surfaces[new_surface_index_B].Flags = original_surface.Flags;
            Bsp.Surfaces[new_surface_index_B].BreakableSurface = original_surface.BreakableSurface;
            Bsp.Surfaces[new_surface_index_B].Plane = original_surface.Plane;
            Bsp.Surfaces[new_surface_index_B].FirstEdge = int.MaxValue;

            int surface_edge_index = original_surface.FirstEdge;

            //some debugging tools
            int total_edge_count = surface_count_edges(original_surface_index);
            List<Plane_Relationship> edge_plane_relationships = new List<Plane_Relationship>();

            int dividing_edge_index = -1;
            int previous_new_edge_index = -1;
            int first_new_edge_index = -1;
            int edge_vertex_A_index = -1;
            int edge_vertex_B_index = -1;

            //find edges of the original surface that are split by the plane and divide them
            while (true)
            {
                //grab edge vertices
                LargeEdge surface_edge_block = Bsp.Edges[surface_edge_index];

                if (surface_edge_block.RightSurface == original_surface_index)
                {
                    edge_vertex_A_index = surface_edge_block.EndVertex;
                    edge_vertex_B_index = surface_edge_block.StartVertex;
                }
                else
                {
                    edge_vertex_A_index = surface_edge_block.StartVertex;
                    edge_vertex_B_index = surface_edge_block.EndVertex;
                }

                RealPoint3d edge_vertex_A = Bsp.Vertices[edge_vertex_A_index].Point;
                RealPoint3d edge_vertex_B = Bsp.Vertices[edge_vertex_B_index].Point;

                //calculate vertex plane relationships
                Plane_Relationship vertex_plane_relationship_A = determine_vertex_plane_relationship(edge_vertex_A, plane_block);
                Plane_Relationship vertex_plane_relationship_B = determine_vertex_plane_relationship(edge_vertex_B, plane_block);

                //check if there is a vertex on both sides of the plane
                Plane_Relationship edge_plane_relationship = vertex_plane_relationship_A | vertex_plane_relationship_B;
                edge_plane_relationships.Add(edge_plane_relationship);

                //if this edge spans the plane, then create a new dividing edge
                if (edge_plane_relationship.HasFlag(Plane_Relationship.BothSidesofPlane))
                {
                    //allocate new edges and vertex
                    Bsp.Vertices.Add(new LargeVertex());
                    int new_vertex_index_A = Bsp.Vertices.Count - 1;
                    Bsp.Edges.Add(new LargeEdge());
                    Bsp.Edges.Add(new LargeEdge());
                    int new_edge_index_A = Bsp.Edges.Count - 2;
                    int new_edge_index_B = Bsp.Edges.Count - 1;

                    if (dividing_edge_index == -1)
                    {
                        //allocate new dividing edge
                        Bsp.Edges.Add(new LargeEdge());
                        dividing_edge_index = Bsp.Edges.Count - 1;

                        //new edge C will be the edge that separates the two new surfaces
                        Bsp.Edges[dividing_edge_index].StartVertex = new_vertex_index_A;
                        Bsp.Edges[dividing_edge_index].ReverseEdge = new_edge_index_B;
                        Bsp.Edges[dividing_edge_index].EndVertex = int.MaxValue; //0xFFFF
                        Bsp.Edges[dividing_edge_index].ForwardEdge = int.MaxValue; //0xFFFF
                        if (vertex_plane_relationship_A == Plane_Relationship.FrontofPlane || vertex_plane_relationship_A == Plane_Relationship.OnPlane)
                            Bsp.Edges[dividing_edge_index].LeftSurface = new_surface_index_B;
                        else
                            Bsp.Edges[dividing_edge_index].LeftSurface = new_surface_index_A;
                        if (vertex_plane_relationship_B == Plane_Relationship.FrontofPlane || vertex_plane_relationship_B == Plane_Relationship.OnPlane)
                            Bsp.Edges[dividing_edge_index].RightSurface = new_surface_index_B;
                        else
                            Bsp.Edges[dividing_edge_index].RightSurface = new_surface_index_A;
                    }
                    else
                    {
                        if (Bsp.Edges[dividing_edge_index].EndVertex != int.MaxValue)
                        {
                            Console.WriteLine("###ERROR Dividing Edge EndVertex should be -1");
                            return false;
                        }

                        Bsp.Edges[dividing_edge_index].EndVertex = new_vertex_index_A;

                        if (Bsp.Edges[dividing_edge_index].ForwardEdge != int.MaxValue)
                        {
                            Console.WriteLine("###ERROR Dividing Edge ForwardEdge should be -1");
                            return false;
                        }

                        Bsp.Edges[dividing_edge_index].ForwardEdge = new_edge_index_B;
                    }

                    float plane_vertex_input_A = edge_vertex_A.X * plane_block.I + edge_vertex_A.Y * plane_block.J + edge_vertex_A.Z * plane_block.K - plane_block.D;
                    float plane_vertex_input_B = edge_vertex_B.X * plane_block.I + edge_vertex_B.Y * plane_block.J + edge_vertex_B.Z * plane_block.K - plane_block.D;
                    float plane_vertex_input_AB_ratio = plane_vertex_input_A / (plane_vertex_input_A - plane_vertex_input_B);

                    //allocate values for new_vertex_A
                    Bsp.Vertices[new_vertex_index_A].Point.X = (edge_vertex_B.X - edge_vertex_A.X) * plane_vertex_input_AB_ratio + edge_vertex_A.X;
                    Bsp.Vertices[new_vertex_index_A].Point.Y = (edge_vertex_B.Y - edge_vertex_A.Y) * plane_vertex_input_AB_ratio + edge_vertex_A.Y;
                    Bsp.Vertices[new_vertex_index_A].Point.Z = (edge_vertex_B.Z - edge_vertex_A.Z) * plane_vertex_input_AB_ratio + edge_vertex_A.Z;
                    Bsp.Vertices[new_vertex_index_A].FirstEdge = new_edge_index_A;

                    //allocate values for new_edge_A
                    Bsp.Edges[new_edge_index_A].ForwardEdge = dividing_edge_index;
                    Bsp.Edges[new_edge_index_A].ReverseEdge = int.MaxValue;
                    Bsp.Edges[new_edge_index_A].StartVertex = edge_vertex_A_index;
                    Bsp.Edges[new_edge_index_A].EndVertex = new_vertex_index_A;
                    if (vertex_plane_relationship_A == Plane_Relationship.FrontofPlane || vertex_plane_relationship_A == Plane_Relationship.OnPlane)
                        Bsp.Edges[new_edge_index_A].LeftSurface = new_surface_index_B;
                    else
                        Bsp.Edges[new_edge_index_A].LeftSurface = new_surface_index_A;
                    Bsp.Edges[new_edge_index_A].RightSurface = int.MaxValue;

                    //allocate values for new_edge_B
                    Bsp.Edges[new_edge_index_B].ForwardEdge = int.MaxValue;
                    Bsp.Edges[new_edge_index_B].ReverseEdge = int.MaxValue;
                    Bsp.Edges[new_edge_index_B].StartVertex = new_vertex_index_A;
                    Bsp.Edges[new_edge_index_B].EndVertex = edge_vertex_B_index;
                    if (vertex_plane_relationship_B == Plane_Relationship.FrontofPlane || vertex_plane_relationship_B == Plane_Relationship.OnPlane)
                        Bsp.Edges[new_edge_index_B].LeftSurface = new_surface_index_B;
                    else
                        Bsp.Edges[new_edge_index_B].LeftSurface = new_surface_index_A;
                    Bsp.Edges[new_edge_index_B].RightSurface = int.MaxValue;

                    if (first_new_edge_index == -1)
                        first_new_edge_index = new_edge_index_A;

                    //connect previous edge to generated edges
                    if (previous_new_edge_index != -1)
                        Bsp.Edges[previous_new_edge_index].ForwardEdge = new_edge_index_A;
                    previous_new_edge_index = new_edge_index_B;
                }

                //not sure about what this is for, if vertex A isn't on the plane or vertex B IS on the plane...
                else if (vertex_plane_relationship_A != Plane_Relationship.OnPlane || vertex_plane_relationship_B == Plane_Relationship.OnPlane)
                {
                    //allocate new edge
                    Bsp.Edges.Add(new LargeEdge());
                    int new_edge_index_D = Bsp.Edges.Count - 1;

                    Bsp.Edges[new_edge_index_D].StartVertex = edge_vertex_A_index;
                    Bsp.Edges[new_edge_index_D].EndVertex = edge_vertex_B_index;
                    Bsp.Edges[new_edge_index_D].ForwardEdge = int.MaxValue;
                    Bsp.Edges[new_edge_index_D].ReverseEdge = int.MaxValue;
                    if (edge_plane_relationship.HasFlag(Plane_Relationship.BackofPlane))
                        Bsp.Edges[new_edge_index_D].LeftSurface = new_surface_index_A;
                    else
                        Bsp.Edges[new_edge_index_D].LeftSurface = new_surface_index_B;
                    Bsp.Edges[new_edge_index_D].RightSurface = int.MaxValue;

                    if (first_new_edge_index == -1)
                        first_new_edge_index = new_edge_index_D;

                    //connect previous edge to generated edges
                    if (previous_new_edge_index != -1)
                        Bsp.Edges[previous_new_edge_index].ForwardEdge = new_edge_index_D;
                    previous_new_edge_index = new_edge_index_D;
                }

                else
                {
                    //allocate new edge
                    Bsp.Edges.Add(new LargeEdge());
                    int new_edge_index_E = Bsp.Edges.Count - 1;

                    if (dividing_edge_index == -1)
                    {
                        //allocate new dividing edge
                        Bsp.Edges.Add(new LargeEdge());
                        dividing_edge_index = Bsp.Edges.Count - 1;

                        Bsp.Edges[dividing_edge_index].StartVertex = edge_vertex_A_index;
                        Bsp.Edges[dividing_edge_index].EndVertex = int.MaxValue;
                        Bsp.Edges[dividing_edge_index].ForwardEdge = int.MaxValue;
                        Bsp.Edges[dividing_edge_index].ReverseEdge = new_edge_index_E;

                        if (vertex_plane_relationship_B == Plane_Relationship.BackofPlane)
                            Bsp.Edges[dividing_edge_index].LeftSurface = new_surface_index_B;
                        else
                            Bsp.Edges[dividing_edge_index].LeftSurface = new_surface_index_A;

                        if (vertex_plane_relationship_B == Plane_Relationship.FrontofPlane || vertex_plane_relationship_B == Plane_Relationship.OnPlane)
                            Bsp.Edges[dividing_edge_index].RightSurface = new_surface_index_B;
                        else
                            Bsp.Edges[dividing_edge_index].RightSurface = new_surface_index_A;
                    }
                    else
                    {
                        if (Bsp.Edges[dividing_edge_index].EndVertex != int.MaxValue)
                        {
                            Console.WriteLine("###ERROR Dividing Edge EndVertex should be -1");
                            return false;
                        }
                        Bsp.Edges[dividing_edge_index].EndVertex = edge_vertex_A_index;
                        if (Bsp.Edges[dividing_edge_index].ForwardEdge != int.MaxValue)
                        {
                            Console.WriteLine("###ERROR Dividing Edge ForwardEdge should be -1");
                            return false;
                        }
                        Bsp.Edges[dividing_edge_index].ForwardEdge = new_edge_index_E;
                    }

                    Bsp.Edges[new_edge_index_E].EndVertex = edge_vertex_B_index;
                    Bsp.Edges[new_edge_index_E].StartVertex = edge_vertex_A_index;
                    Bsp.Edges[new_edge_index_E].ForwardEdge = int.MaxValue;
                    Bsp.Edges[new_edge_index_E].ReverseEdge = int.MaxValue;
                    Bsp.Edges[new_edge_index_E].RightSurface = int.MaxValue;

                    if (vertex_plane_relationship_B == Plane_Relationship.FrontofPlane || vertex_plane_relationship_B == Plane_Relationship.OnPlane)
                        Bsp.Edges[new_edge_index_E].LeftSurface = new_surface_index_B;
                    else
                        Bsp.Edges[new_edge_index_E].LeftSurface = new_surface_index_A;

                    if (first_new_edge_index == -1)
                        first_new_edge_index = dividing_edge_index;

                    //connect previous edge to new generated edges
                    if (previous_new_edge_index != -1)
                        Bsp.Edges[previous_new_edge_index].ForwardEdge = dividing_edge_index;
                    previous_new_edge_index = new_edge_index_E;
                }

                if (surface_edge_block.RightSurface == original_surface_index)
                    surface_edge_index = surface_edge_block.ReverseEdge;
                else
                    surface_edge_index = surface_edge_block.ForwardEdge;
                //break the loop if we have finished circulating the surface
                if (surface_edge_index == original_surface.FirstEdge)
                {
                    //check for errors before exiting loop
                    if (first_new_edge_index == -1 || previous_new_edge_index == -1)
                    {
                        Console.WriteLine("###ERROR First New Edge index or Previous New Edge Index value not set!");
                        return false;
                    }
                    if (dividing_edge_index == -1)
                    {
                        Console.WriteLine("###ERROR Dividing Edge index value not set!");
                        return false;
                    }
                    break;
                }
            }
            //connect loose ends and set first edge of new surfaces
            Bsp.Edges[previous_new_edge_index].ForwardEdge = first_new_edge_index;

            Bsp.Surfaces[new_surface_index_A].FirstEdge = dividing_edge_index;
            Bsp.Surfaces[new_surface_index_B].FirstEdge = dividing_edge_index;
            return true;
        }

        public bool split_object_surfaces_with_plane(surface_array_definition surface_array, int plane_index, ref surface_array_definition back_surfaces_array, ref surface_array_definition front_surfaces_array)
        {
            int surface_array_index = 0;

            int back_free_count = 0;
            int back_used_count = 0;
            int front_free_count = 0;
            int front_used_count = 0;

            int unknown_count = 0;
            int back_of_plane_count = 0;
            int front_of_plane_count = 0;
            int split_plane_count = 0;
            int on_plane_count = 0;

            if (surface_array.free_count + surface_array.used_count > 0)
            {
                while (true)
                {
                    int surface_index = surface_array.surface_array[surface_array_index];
                    bool surface_index_less_than_0 = false;
                    if (surface_index < 0)
                        surface_index_less_than_0 = true;
                    int absolute_surface_index = surface_index & 0x7FFFFFFF;
                    bool surface_is_free = surface_array_index < surface_array.free_count;
                    int current_surface_plane_index = Bsp.Surfaces[absolute_surface_index].Plane;
                    bool surface_is_double_sided = Bsp.Surfaces[absolute_surface_index].Flags.HasFlag(SurfaceFlags.TwoSided);
                    int back_surface_index = -1;
                    int front_surface_index = -1;
                    switch (determine_surface_plane_relationship(absolute_surface_index, plane_index, new RealPlane3d()))
                    {
                        case Plane_Relationship.Unknown: //surface does not appear to be on either side of the plane and is not on the plane either
                            unknown_count++;
                            if (surface_index != -1)
                            {
                                if (surface_is_free)
                                {
                                    back_surfaces_array.surface_array[back_free_count] = surface_index;
                                    back_free_count++;
                                    front_surfaces_array.surface_array[front_free_count] = surface_index;
                                    front_free_count++;
                                }
                                else
                                {
                                    back_surfaces_array.surface_array[back_used_count + back_surfaces_array.free_count] = surface_index;
                                    back_used_count++;
                                    front_surfaces_array.surface_array[front_used_count + front_surfaces_array.free_count] = surface_index;
                                    front_used_count++;
                                }
                            }
                            break;

                        case Plane_Relationship.BackofPlane: //surface is in back of plane
                            back_of_plane_count++;
                            if (surface_index != -1)
                            {
                                if (surface_is_free)
                                {
                                    back_surfaces_array.surface_array[back_free_count] = surface_index;
                                    back_free_count++;
                                }
                                else
                                {
                                    back_surfaces_array.surface_array[back_used_count + back_surfaces_array.free_count] = surface_index;
                                    back_used_count++;
                                }
                            }
                            break;

                        case Plane_Relationship.FrontofPlane: //surface is in front of plane
                            front_of_plane_count++;
                            if (surface_index != -1)
                            {
                                if (surface_is_free)
                                {
                                    front_surfaces_array.surface_array[front_free_count] = surface_index;
                                    front_free_count++;
                                }
                                else
                                {
                                    front_surfaces_array.surface_array[front_used_count + front_surfaces_array.free_count] = surface_index;
                                    front_used_count++;
                                }
                            }
                            break;

                        case Plane_Relationship.BothSidesofPlane: //surface is both in front of and behind plane
                            split_plane_count++;

                            Bsp.Surfaces.Add(new LargeSurface());
                            Bsp.Surfaces.Add(new LargeSurface());
                            int new_surface_A_index = Bsp.Surfaces.Count - 2;
                            int new_surface_B_index = Bsp.Surfaces.Count - 1;

                            //split surface into two new surfaces, one on each side of the plane
                            if (!divide_surface_into_two_surfaces(absolute_surface_index, plane_index, new_surface_A_index, new_surface_B_index))
                            {
                                return false;
                            }

                            //here we will record the parent surface index for these child surfaces for use later on
                            surface_addendums.Add(absolute_surface_index);
                            surface_addendums.Add(absolute_surface_index);

                            //propagate surface index flags to child surfaces
                            if (surface_index_less_than_0)
                            {
                                back_surface_index = (int)(new_surface_A_index | 0x80000000);
                                front_surface_index = (int)(new_surface_B_index | 0x80000000);
                            }
                            else
                            {
                                back_surface_index = new_surface_A_index & 0x7FFFFFFF;
                                front_surface_index = new_surface_B_index & 0x7FFFFFFF;
                            }

                            //add child surfaces to appropriate arrays
                            if (surface_is_free)
                            {
                                if (back_surface_index != -1)
                                {
                                    back_surfaces_array.surface_array[back_free_count] = back_surface_index;
                                    back_free_count++;
                                }
                                if (front_surface_index != -1)
                                {
                                    front_surfaces_array.surface_array[front_free_count] = front_surface_index;
                                    front_free_count++;
                                }
                            }
                            else
                            {
                                if (back_surface_index != -1)
                                {
                                    back_surfaces_array.surface_array[back_used_count + back_surfaces_array.free_count] = back_surface_index;
                                    back_used_count++;
                                }
                                if (front_surface_index != -1)
                                {
                                    front_surfaces_array.surface_array[front_used_count + front_surfaces_array.free_count] = front_surface_index;
                                    front_used_count++;
                                }
                            }
                            break;

                        case Plane_Relationship.OnPlane: //surface is ON the plane
                            on_plane_count++;
                            if (!surface_index_less_than_0)
                            {
                                break;
                            }
                            if (!surface_is_free || (current_surface_plane_index & 0x7FFFFFFF) != plane_index)
                            {
                                Console.WriteLine("###ERROR Surface on plane does not have matching plane index!");
                            }
                            if (!surface_is_double_sided) //surface is NOT double sided
                            {
                                if (current_surface_plane_index >= 0)
                                {
                                    back_surface_index = absolute_surface_index & 0x7FFFFFFF;
                                    front_surface_index = (int)(absolute_surface_index | 0x80000000);
                                }
                                else
                                {
                                    back_surface_index = (int)(absolute_surface_index | 0x80000000);
                                    front_surface_index = absolute_surface_index & 0x7FFFFFFF;
                                }
                            }
                            else
                            {
                                if (current_surface_plane_index >= 0)
                                {
                                    front_surface_index = (int)(absolute_surface_index | 0x80000000);
                                    back_surface_index = -1;
                                }
                                else
                                {
                                    back_surface_index = (int)(absolute_surface_index | 0x80000000);
                                    front_surface_index = -1;
                                }
                            }
                            //add child surfaces to appropriate arrays
                            //none of these surfaces are considered free, as surface_is_free is set to false for all conditions
                            if (back_surface_index != -1)
                            {
                                back_surfaces_array.surface_array[back_used_count + back_surfaces_array.free_count] = back_surface_index;
                                back_used_count++;
                            }
                            if (front_surface_index != -1)
                            {
                                front_surfaces_array.surface_array[front_used_count + front_surfaces_array.free_count] = front_surface_index;
                                front_used_count++;
                            }
                            break;
                    }

                    if (++surface_array_index >= surface_array.free_count + surface_array.used_count)
                        break;
                }
            }

            if (back_free_count != back_surfaces_array.free_count)
            {
                Console.WriteLine("###ERROR back_free_count != back_surfaces->free_count");
                return false;
            }
            if (back_used_count != back_surfaces_array.used_count)
            {
                Console.WriteLine("###ERROR back_used_count != back_surfaces->used_count");
                return false;
            }
            if (front_free_count != front_surfaces_array.free_count)
            {
                Console.WriteLine("###ERROR front_free_count != front_surfaces->free_count");
                return false;
            }
            if (front_used_count != front_surfaces_array.used_count)
            {
                Console.WriteLine("###ERROR front_used_count != front_surfaces->used_count");
                return false;
            }
            return true;
        }

        public plane_splitting_parameters find_surface_splitting_plane(surface_array_definition surface_array)
        {
            plane_splitting_parameters splitting_parameters = new plane_splitting_parameters();

            //this code should only be used with <1024 surfaces as it loops and checks every surface. large meshes first need to be split with generate_object_splitting_plane
            if (surface_array.free_count < 1024)
            {
                splitting_parameters = surface_plane_splitting_effectiveness_check_loop(surface_array);
                return splitting_parameters;
            }

            splitting_parameters = generate_object_splitting_plane(surface_array);
            return splitting_parameters;
        }

        [Flags]
        public enum Plane_Relationship : int
        {
            Unknown = 0,
            BackofPlane = 1,
            FrontofPlane = 2,
            BothSidesofPlane = 3, //both 1 & 2 
            OnPlane = 4
        }

        public Plane_Relationship determine_vertex_plane_relationship(RealPoint3d vertex, RealPlane3d plane)
        {
            double plane_equation_vertex_input = vertex.X * plane.I + vertex.Y * plane.J + vertex.Z * plane.K - plane.D;

            if (plane_equation_vertex_input >= -0.00024414062)
            {
                //if the plane distance is within both of these bounds, it is considered ON the plane
                if (plane_equation_vertex_input <= 0.00024414062)
                    return Plane_Relationship.OnPlane;
                else
                    return Plane_Relationship.FrontofPlane;
            }
            else
            {
                return Plane_Relationship.BackofPlane;
            }
        }

        public RealPoint2d vertex_get_projection_relevant_coords(RealPoint3d vertex_block, int plane_projection_axis, int plane_mirror_check)
        {
            //plane mirror check = "projection_sign"
            RealPoint2d relevant_coords = new RealPoint2d();
            int v4 = 2 * (plane_mirror_check + 2 * plane_projection_axis);
            List<int> coordinate_list = new List<int> { 2, 1, 1, 2, 0, 2, 2, 0, 1, 0, 0, 1 };
            int vertex_coord_X_index = coordinate_list[v4];
            int vertex_coord_Y_index = coordinate_list[v4 + 1];

            float[] vertex_values = new float[3] { vertex_block.X, vertex_block.Y, vertex_block.Z };
            relevant_coords.X = vertex_values[vertex_coord_X_index];
            relevant_coords.Y = vertex_values[vertex_coord_Y_index];
            return relevant_coords;
        }

        public Plane_Relationship determine_surface_plane_relationship_2D(int surface_index, LargeBsp2dNode bsp2dnodeblock, int plane_projection_axis, int plane_mirror_check)
        {
            Plane_Relationship surface_plane_relationship = 0;
            LargeSurface surface_block = Bsp.Surfaces[surface_index];
            List<RealPoint2d> pointlist = new List<RealPoint2d>();
            List<double> inputlist = new List<double>();

            int surface_edge_index = surface_block.FirstEdge;
            while (true)
            {
                LargeEdge surface_edge_block = Bsp.Edges[surface_edge_index];
                LargeVertex edge_vertex;
                if (surface_edge_block.RightSurface == surface_index)
                    edge_vertex = Bsp.Vertices[surface_edge_block.EndVertex];
                else
                    edge_vertex = Bsp.Vertices[surface_edge_block.StartVertex];

                RealPoint2d relevant_coords = vertex_get_projection_relevant_coords(edge_vertex.Point, plane_projection_axis, plane_mirror_check);
                pointlist.Add(relevant_coords);

                double plane_equation_vertex_input = bsp2dnodeblock.Plane.I * relevant_coords.X + bsp2dnodeblock.Plane.J * relevant_coords.Y - bsp2dnodeblock.Plane.D;
                inputlist.Add(plane_equation_vertex_input);

                if (plane_equation_vertex_input < -0.00009999999747378752)
                {
                    surface_plane_relationship |= Plane_Relationship.BackofPlane;
                }
                if (plane_equation_vertex_input > 0.00009999999747378752)
                {
                    surface_plane_relationship |= Plane_Relationship.FrontofPlane;
                }

                if (surface_plane_relationship.HasFlag(Plane_Relationship.BothSidesofPlane))
                    break;

                if (surface_edge_block.RightSurface == surface_index)
                    surface_edge_index = surface_edge_block.ReverseEdge;
                else
                    surface_edge_index = surface_edge_block.ForwardEdge;
                //break the loop if we have finished circulating the surface
                if (surface_edge_index == surface_block.FirstEdge)
                    break;
            }

            return surface_plane_relationship;
        }

        public Plane_Relationship determine_surface_plane_relationship(int surface_index, int plane_index, RealPlane3d plane_block)
        {
            Plane_Relationship surface_plane_relationship = 0;
            LargeSurface surface_block = Bsp.Surfaces[surface_index];

            //check if surface is on the plane
            if ((surface_block.Plane & 0x7FFFFFFF) == plane_index)
                return Plane_Relationship.OnPlane;

            //if plane block is empty, use the plane index to get one instead
            if (plane_block == new RealPlane3d())
                plane_block = Bsp.Planes[plane_index].Value;

            int surface_edge_index = surface_block.FirstEdge;
            while (true)
            {
                LargeEdge surface_edge_block = Bsp.Edges[surface_edge_index];
                RealPoint3d edge_vertex;
                if (surface_edge_block.RightSurface == surface_index)
                    edge_vertex = Bsp.Vertices[surface_edge_block.EndVertex].Point;
                else
                    edge_vertex = Bsp.Vertices[surface_edge_block.StartVertex].Point;

                Plane_Relationship vertex_plane_relationship = determine_vertex_plane_relationship(edge_vertex, plane_block);
                //if a vertex is on the plane, just ignore it and continue testing the remainder
                if (!vertex_plane_relationship.HasFlag(Plane_Relationship.OnPlane))
                    surface_plane_relationship |= vertex_plane_relationship;

                if (surface_plane_relationship.HasFlag(Plane_Relationship.BothSidesofPlane))
                    break;

                if (surface_edge_block.RightSurface == surface_index)
                    surface_edge_index = surface_edge_block.ReverseEdge;
                else
                    surface_edge_index = surface_edge_block.ForwardEdge;
                //break the loop if we have finished circulating the surface
                if (surface_edge_index == surface_block.FirstEdge)
                    break;
            }

            //split surfaces may become very small and be hard to work with. To get clarity, we can use the parent surface of the split surface
            if (surface_plane_relationship == Plane_Relationship.Unknown && surface_index >= original_surface_count)
            {
                while (true)
                {
                    surface_index = surface_addendums[surface_index];
                    surface_plane_relationship = determine_surface_plane_relationship(surface_index, plane_index, plane_block);
                    if (surface_plane_relationship == Plane_Relationship.BackofPlane || surface_plane_relationship == Plane_Relationship.FrontofPlane)
                        break;
                    if (surface_index < original_surface_count)
                    {
                        surface_plane_relationship = Plane_Relationship.Unknown;
                        break;
                    }
                }
            }

            return surface_plane_relationship;
        }

        public class plane_splitting_parameters
        {
            public double plane_splitting_effectiveness;
            public int plane_index;
            public int BackSurfaceCount;
            public int BackSurfaceUsedCount;
            public int FrontSurfaceCount;
            public int FrontSurfaceUsedCount;
        }

        public class surface_array_definition
        {
            public int free_count;
            public int used_count;
            public List<int> surface_array;
        }

        public plane_splitting_parameters determine_plane_splitting_effectiveness_2D(LargeBsp2dNode bsp2dnode_block, int plane_projection_axis, int a3, surface_array_definition plane_matched_surface_array)
        {
            plane_splitting_parameters splitting_Parameters = new plane_splitting_parameters();
            foreach (int surface_index in plane_matched_surface_array.surface_array)
            {
                Plane_Relationship surface_plane_orientation = determine_surface_plane_relationship_2D(surface_index, bsp2dnode_block, plane_projection_axis, a3);
                if (surface_plane_orientation.HasFlag(Plane_Relationship.BackofPlane))
                    splitting_Parameters.BackSurfaceCount++;
                if (surface_plane_orientation.HasFlag(Plane_Relationship.FrontofPlane))
                    splitting_Parameters.FrontSurfaceCount++;
            }
            //if all of the surfaces are on one side or the other, this is not a good split
            if (splitting_Parameters.BackSurfaceCount > 0 &&
                splitting_Parameters.BackSurfaceCount < plane_matched_surface_array.surface_array.Count &&
                splitting_Parameters.FrontSurfaceCount > 0 &&
                splitting_Parameters.FrontSurfaceCount < plane_matched_surface_array.surface_array.Count)
            {
                splitting_Parameters.plane_splitting_effectiveness = Math.Abs(splitting_Parameters.BackSurfaceCount - splitting_Parameters.FrontSurfaceCount) + 2 * (splitting_Parameters.FrontSurfaceCount + splitting_Parameters.BackSurfaceCount);
            }
            else
                splitting_Parameters.plane_splitting_effectiveness = double.MaxValue;
            return splitting_Parameters;
        }

        public plane_splitting_parameters determine_plane_splitting_effectiveness(surface_array_definition surface_array, int plane_index, RealPlane3d plane_block)
        {
            plane_splitting_parameters splitting_Parameters = new plane_splitting_parameters();
            if (surface_array.free_count + surface_array.used_count > 0)
            {
                int current_surface_array_index = 0;
                while (true)
                {
                    int surface_index = surface_array.surface_array[current_surface_array_index];
                    bool surface_is_free = current_surface_array_index < surface_array.free_count;
                    Plane_Relationship relationship = determine_surface_plane_relationship((surface_index & 0x7FFFFFFF), plane_index, plane_block);
                    if (relationship.HasFlag(Plane_Relationship.OnPlane))
                    {
                        if (!surface_is_free)
                        {
                            Console.WriteLine("###ERROR Plane matching surface should be free!");
                        }
                        if (surface_index < 0)
                        {
                            LargeSurface surface_block = Bsp.Surfaces[surface_index & 0x7FFFFFFF];
                            if (surface_block.Flags.HasFlag(SurfaceFlags.TwoSided))
                            {
                                if ((surface_block.Plane & 0x80000000) != 0)
                                {
                                    splitting_Parameters.BackSurfaceUsedCount++;
                                    if (++current_surface_array_index >= surface_array.free_count + surface_array.used_count)
                                        break;
                                    continue;
                                }
                            }
                            else
                            {
                                splitting_Parameters.BackSurfaceUsedCount++;
                            }
                            splitting_Parameters.FrontSurfaceUsedCount++;
                            if (++current_surface_array_index >= surface_array.free_count + surface_array.used_count)
                                break;
                            continue;
                        }
                    }
                    else
                    {
                        //if surface seems to be on neither side of the plane, consider it to be on both
                        if (!relationship.HasFlag(Plane_Relationship.BackofPlane) && !relationship.HasFlag(Plane_Relationship.FrontofPlane))
                        {
                            relationship |= Plane_Relationship.FrontofPlane;
                            relationship |= Plane_Relationship.BackofPlane;
                        }
                        if (surface_is_free)
                        {
                            if (relationship.HasFlag(Plane_Relationship.BackofPlane))
                                splitting_Parameters.BackSurfaceCount++;
                            if (relationship.HasFlag(Plane_Relationship.FrontofPlane))
                                splitting_Parameters.FrontSurfaceCount++;
                        }
                        else
                        {
                            if (relationship.HasFlag(Plane_Relationship.BackofPlane))
                                splitting_Parameters.BackSurfaceUsedCount++;
                            if (relationship.HasFlag(Plane_Relationship.FrontofPlane))
                                splitting_Parameters.FrontSurfaceUsedCount++;
                        }
                    }

                    if (++current_surface_array_index >= surface_array.free_count + surface_array.used_count)
                        break;
                }
            }

            splitting_Parameters.plane_splitting_effectiveness =
                Math.Abs(splitting_Parameters.BackSurfaceCount - splitting_Parameters.FrontSurfaceCount) + 2 * (splitting_Parameters.FrontSurfaceCount + splitting_Parameters.BackSurfaceCount);

            return splitting_Parameters;
        }

        public LargeBsp2dNode generate_bsp2d_plane_parameters(RealPoint2d Coords1, RealPoint2d Coords2)
        {
            LargeBsp2dNode bsp2dnode_block = new LargeBsp2dNode();
            double plane_I = Coords2.Y - Coords1.Y;
            double plane_J = Coords1.X - Coords2.X;

            double dist = Math.Sqrt(plane_I * plane_I + plane_J * plane_J);

            if (Math.Abs(dist) < 0.00009999999747378752)
            {
                bsp2dnode_block.Plane.I = (float)plane_I;
                bsp2dnode_block.Plane.J = (float)plane_J;
                bsp2dnode_block.Plane.D = 0;
            }
            else
            {
                bsp2dnode_block.Plane.I = (float)(plane_I / dist);
                bsp2dnode_block.Plane.J = (float)(plane_J / dist);
                bsp2dnode_block.Plane.D = bsp2dnode_block.Plane.J * Coords1.Y + bsp2dnode_block.Plane.I * Coords1.X;
            }
            return bsp2dnode_block;
        }

        public plane_splitting_parameters generate_best_splitting_plane_2D(int plane_projection_axis, int plane_mirror_check, ref LargeBsp2dNode bsp2dnode_block, surface_array_definition plane_matched_surface_array)
        {
            plane_splitting_parameters lowest_plane_splitting_parameters = new plane_splitting_parameters();
            lowest_plane_splitting_parameters.plane_splitting_effectiveness = double.MaxValue;

            for (int surface_index_index = 0; surface_index_index < plane_matched_surface_array.surface_array.Count; surface_index_index++)
            {
                int surface_index = plane_matched_surface_array.surface_array[surface_index_index] & 0x7FFFFFFF;
                LargeSurface surface_block = Bsp.Surfaces[surface_index];
                int surface_edge_index = surface_block.FirstEdge;
                while (true)
                {
                    LargeEdge surface_edge_block = Bsp.Edges[surface_edge_index];
                    LargeVertex start_vertex = Bsp.Vertices[surface_edge_block.StartVertex];
                    LargeVertex end_vertex = Bsp.Vertices[surface_edge_block.EndVertex];
                    RealPoint2d Coords1;
                    RealPoint2d Coords2;
                    if (surface_edge_block.RightSurface == surface_index)
                    {
                        Coords1 = vertex_get_projection_relevant_coords(end_vertex.Point, plane_projection_axis, plane_mirror_check);
                        Coords2 = vertex_get_projection_relevant_coords(start_vertex.Point, plane_projection_axis, plane_mirror_check);
                    }
                    else
                    {
                        Coords2 = vertex_get_projection_relevant_coords(end_vertex.Point, plane_projection_axis, plane_mirror_check);
                        Coords1 = vertex_get_projection_relevant_coords(start_vertex.Point, plane_projection_axis, plane_mirror_check);
                    }

                    LargeBsp2dNode current_bsp2dnode_block = generate_bsp2d_plane_parameters(Coords1, Coords2);

                    plane_splitting_parameters current_plane_splitting_parameters = determine_plane_splitting_effectiveness_2D(current_bsp2dnode_block, plane_projection_axis, plane_mirror_check, plane_matched_surface_array);

                    if (current_plane_splitting_parameters.plane_splitting_effectiveness < lowest_plane_splitting_parameters.plane_splitting_effectiveness)
                    {
                        lowest_plane_splitting_parameters = current_plane_splitting_parameters.DeepClone();
                        bsp2dnode_block = current_bsp2dnode_block.DeepClone();
                    }

                    if (surface_edge_block.RightSurface == surface_index)
                        surface_edge_index = surface_edge_block.ReverseEdge;
                    else
                        surface_edge_index = surface_edge_block.ForwardEdge;
                    //break the loop if we have finished circulating the surface
                    if (surface_edge_index == surface_block.FirstEdge)
                        break;
                }
            }
            return lowest_plane_splitting_parameters;
        }

        public plane_splitting_parameters surface_plane_splitting_effectiveness_check_loop(surface_array_definition surface_array)
        {
            plane_splitting_parameters lowest_plane_splitting_parameters = new plane_splitting_parameters();
            lowest_plane_splitting_parameters.plane_splitting_effectiveness = double.MaxValue;

            //loop through free surfaces to see how effectively their associated planes split the remaining surfaces. Find the one that most effectively splits the remaining surfaces.
            for (int i = 0; i < surface_array.free_count; i++)
            {
                int current_plane_index = (Bsp.Surfaces[(surface_array.surface_array[i] & 0x7FFFFFFF)].Plane & 0x7FFFFFFF);
                plane_splitting_parameters current_plane_splitting_parameters = determine_plane_splitting_effectiveness(surface_array, current_plane_index, new RealPlane3d());
                if (current_plane_splitting_parameters.plane_splitting_effectiveness < lowest_plane_splitting_parameters.plane_splitting_effectiveness)
                {
                    lowest_plane_splitting_parameters = current_plane_splitting_parameters.DeepClone();
                    lowest_plane_splitting_parameters.plane_index = current_plane_index;
                }
            }

            return lowest_plane_splitting_parameters;
        }

        public class surface_array_qsort_compar : IComparer<extent_entry>
        {
            public int Compare(extent_entry element1, extent_entry element2)
            {
                if (element1.coordinate < element2.coordinate)
                    return -1;
                if (element1.coordinate > element2.coordinate)
                    return 1;
                if (element2.is_max_coord && !element1.is_max_coord)
                    return -1;
                if (element1.is_max_coord && !element2.is_max_coord)
                    return 1;
                return 0;
            }
        }

        public class extent_entry
        {
            public float coordinate;
            public bool is_max_coord;
        };

        public plane_splitting_parameters generate_object_splitting_plane(surface_array_definition surface_array)
        {
            plane_splitting_parameters lowest_plane_splitting_parameters = new plane_splitting_parameters();
            lowest_plane_splitting_parameters.plane_splitting_effectiveness = double.MaxValue;

            int best_axis_index = -1;
            double desired_plane_distance = 0;

            //check X, Y, and Z axes
            for (int current_test_axis = 0; current_test_axis < 3; current_test_axis++)
            {
                //generate a list of maximum and minimum coordinates on the specified plane for each surface
                List<extent_entry> extents_table = new List<extent_entry>();
                for (int i = 0; i < surface_array.free_count; i++)
                {
                    extent_entry min_coordinate = new extent_entry { coordinate = float.MaxValue, is_max_coord = false };
                    extent_entry max_coordinate = new extent_entry { coordinate = float.MinValue, is_max_coord = true };
                    int surface_index = surface_array.surface_array[i] & 0x7FFFFFFF;
                    LargeSurface surface_block = Bsp.Surfaces[surface_index];
                    int surface_edge_index = surface_block.FirstEdge;
                    while (true)
                    {
                        LargeEdge surface_edge_block = Bsp.Edges[surface_edge_index];
                        RealPoint3d edge_vertex;
                        if (surface_edge_block.RightSurface == surface_index)
                            edge_vertex = Bsp.Vertices[surface_edge_block.EndVertex].Point;
                        else
                            edge_vertex = Bsp.Vertices[surface_edge_block.StartVertex].Point;
                        switch (current_test_axis)
                        {
                            case 0: //X axis
                                if (min_coordinate.coordinate > edge_vertex.X)
                                    min_coordinate.coordinate = edge_vertex.X;
                                if (max_coordinate.coordinate < edge_vertex.X)
                                    max_coordinate.coordinate = edge_vertex.X;
                                break;
                            case 1: //Y axis
                                if (min_coordinate.coordinate > edge_vertex.Y)
                                    min_coordinate.coordinate = edge_vertex.Y;
                                if (max_coordinate.coordinate < edge_vertex.Y)
                                    max_coordinate.coordinate = edge_vertex.Y;
                                break;
                            case 2: //Z axis
                                if (min_coordinate.coordinate > edge_vertex.Z)
                                    min_coordinate.coordinate = edge_vertex.Z;
                                if (max_coordinate.coordinate < edge_vertex.Z)
                                    max_coordinate.coordinate = edge_vertex.Z;
                                break;
                        }

                        if (surface_edge_block.RightSurface == surface_index)
                            surface_edge_index = surface_edge_block.ReverseEdge;
                        else
                            surface_edge_index = surface_edge_block.ForwardEdge;
                        //break the loop if we have finished circulating the surface
                        if (surface_edge_index == surface_block.FirstEdge)
                            break;
                    }
                    extents_table.Add(min_coordinate);
                    extents_table.Add(max_coordinate);
                }
                //use the above defined comparer to sort the extent entries first by coordinate and then by whether they are a surface max coordinate or not
                surface_array_qsort_compar sorter = new surface_array_qsort_compar();
                extents_table.Sort(sorter);

                int front_count = surface_array.free_count;
                int back_count = 0;
                for (int extent_index = 1; extent_index < extents_table.Count; extent_index++)
                {
                    if (extents_table[extent_index - 1].is_max_coord)
                    {
                        if (--front_count < 0)
                        {
                            Console.WriteLine("###ERROR negative plane front count!");
                        }
                    }
                    else
                    {
                        if (++back_count > surface_array.free_count)
                        {
                            Console.WriteLine("###ERROR back count greater than surface free count!");
                        }
                    }
                    double current_splitting_effectiveness = Math.Abs(back_count - front_count) + 2 * (front_count + back_count);
                    if (current_splitting_effectiveness < lowest_plane_splitting_parameters.plane_splitting_effectiveness)
                    {
                        lowest_plane_splitting_parameters.plane_splitting_effectiveness = current_splitting_effectiveness;
                        best_axis_index = current_test_axis;
                        desired_plane_distance = (extents_table[extent_index].coordinate + extents_table[extent_index - 1].coordinate) * 0.5;
                    }
                }
            }
            if (best_axis_index == -1)
            {
                Console.WriteLine("###ERROR: Failed to find best axis index!");
            }
            //generate a plane based on the ideal plane characteristics calculated above
            RealPlane3d best_plane = new RealPlane3d();
            best_plane.D = (float)desired_plane_distance;
            switch (best_axis_index)
            {
                case 0:
                    best_plane.I = 1.0f;
                    break;
                case 1:
                    best_plane.J = 1.0f;
                    break;
                case 2:
                    best_plane.K = 1.0f;
                    break;
            }
            //an identical but opposite facing plane can also be used
            RealPlane3d inverse_best_plane = new RealPlane3d
            {
                I = best_plane.I * -1,
                J = best_plane.J * -1,
                K = best_plane.K * -1,
                D = best_plane.D * -1,
            };
            //we can use an existing plane if it is within this tolerance threshold 
            double plane_tolerance = 0.001000000047497451;
            int ideal_plane_index;
            for (ideal_plane_index = 0; ideal_plane_index < Bsp.Planes.Count; ideal_plane_index++)
            {
                var plane = Bsp.Planes[ideal_plane_index].Value;
                if (Math.Abs(plane.I - best_plane.I) < plane_tolerance &&
                    Math.Abs(plane.J - best_plane.J) < plane_tolerance &&
                    Math.Abs(plane.K - best_plane.K) < plane_tolerance &&
                    Math.Abs(plane.D - best_plane.D) < plane_tolerance)
                {
                    break;
                }
                else if (Math.Abs(plane.I - inverse_best_plane.I) < plane_tolerance &&
                    Math.Abs(plane.J - inverse_best_plane.J) < plane_tolerance &&
                    Math.Abs(plane.K - inverse_best_plane.K) < plane_tolerance &&
                    Math.Abs(plane.D - inverse_best_plane.D) < plane_tolerance)
                {
                    break;
                }
            }
            //if we have found a usable existing plane, use it
            if (ideal_plane_index < Bsp.Planes.Count)
            {
                lowest_plane_splitting_parameters = determine_plane_splitting_effectiveness(surface_array, ideal_plane_index, new RealPlane3d());
                lowest_plane_splitting_parameters.plane_index = ideal_plane_index;
            }
            //otherwise just add a new plane with ideal characteristics
            else
            {
                Bsp.Planes.Add(new Plane { Value = best_plane });
                ideal_plane_index = Bsp.Planes.Count - 1;
                lowest_plane_splitting_parameters = determine_plane_splitting_effectiveness(surface_array, ideal_plane_index, new RealPlane3d());
                lowest_plane_splitting_parameters.plane_index = ideal_plane_index;
            }
            return lowest_plane_splitting_parameters;
        }

        ///////////////////////////////////////////
        //bsp/geo reduction stuff stored down here
        ///////////////////////////////////////////     

        int surface_count_edges(int surface_index)
        {
            int edge_count = 0;
            LargeSurface surface_block = Bsp.Surfaces[surface_index];
            int first_Edge_index = surface_block.FirstEdge;
            int current_edge_index = surface_block.FirstEdge;
            do
            {
                LargeEdge edge_block = Bsp.Edges[current_edge_index];
                ++edge_count;
                if (edge_block.RightSurface == surface_index)
                    current_edge_index = edge_block.ReverseEdge;
                else
                    current_edge_index = edge_block.ForwardEdge;
            }
            while (current_edge_index != first_Edge_index);
            return edge_count;
        }

        public bool verify_collision_bsp()
        {
            for (var i = 0; i < Bsp.Bsp3dNodes.Count; i++)
            {
                LargeBsp3dNode node = Bsp.Bsp3dNodes[i];
                if (node.Plane < 0 || node.Plane >= Bsp.Planes.Count)
                {
                    Console.WriteLine($"###ERROR: Bsp3dnode {i} has a bad plane index!");
                    return false;
                }
                if (node.BackChild != -1)
                {
                    bool back_child_is_leaf = (node.BackChild & 0x80000000) != 0;
                    int backmaxcount = back_child_is_leaf ? Bsp.Leaves.Count : Bsp.Bsp3dNodes.Count;
                    int backchildindex = node.BackChild & 0x7FFFFFFF;
                    if (backchildindex < 0 || backchildindex >= backmaxcount)
                    {
                        Console.WriteLine($"###ERROR: Bsp3dnode {i} has a bad back child index!");
                        return false;
                    }
                }
                if (node.FrontChild != -1)
                {
                    bool front_child_is_leaf = (node.FrontChild & 0x80000000) != 0;
                    int frontmaxcount = front_child_is_leaf ? Bsp.Leaves.Count : Bsp.Bsp3dNodes.Count;
                    int frontchildindex = node.FrontChild & 0x7FFFFFFF;
                    if (frontchildindex < 0 || frontchildindex >= frontmaxcount)
                    {
                        Console.WriteLine($"###ERROR: Bsp3dnode {i} has a bad front child index!");
                        return false;
                    }
                }
            }

            for (var j = 0; j < Bsp.Leaves.Count; j++)
            {
                var leaf = Bsp.Leaves[j];
                if (leaf.FirstBsp2dReference < 0 || leaf.FirstBsp2dReference >= Bsp.Bsp2dReferences.Count)
                {
                    Console.WriteLine($"###ERROR leaf {j} has a bad bsp2d reference index {leaf.FirstBsp2dReference}");
                    return false;
                }
                if (leaf.Bsp2dReferenceCount == 0 && leaf.FirstBsp2dReference != uint.MaxValue)
                {
                    Console.WriteLine($"###ERROR leaf {j} has a bad bsp2d reference index {leaf.FirstBsp2dReference}");
                    return false;
                }
                if (leaf.Bsp2dReferenceCount < 0 || leaf.FirstBsp2dReference + leaf.Bsp2dReferenceCount > Bsp.Bsp2dReferences.Count)
                {
                    Console.WriteLine($"###ERROR leaf {j} has a bad bsp2d reference count {leaf.Bsp2dReferenceCount}");
                    return false;
                }
            }

            for (var k = 0; k < Bsp.Bsp2dReferences.Count; k++)
            {
                var ref2d = Bsp.Bsp2dReferences[k];
                if ((ref2d.PlaneIndex & 0x7FFFFFFF) < 0 || (ref2d.PlaneIndex & 0x7FFFFFFF) >= Bsp.Planes.Count)
                {
                    Console.WriteLine($"###ERROR Bsp2dref {k} has a bad plane index {ref2d.PlaneIndex}");
                    return false;
                }
                int root_node_index = ref2d.Bsp2dNodeIndex & 0x7FFFFFFF;
                int count = (ref2d.Bsp2dNodeIndex & 0x80000000) != 0 ? Bsp.Surfaces.Count : Bsp.Bsp2dNodes.Count;
                if (root_node_index < 0 || root_node_index >= count)
                {
                    Console.WriteLine($"###ERROR Bsp2dref {k} has a bad root index {ref2d.Bsp2dNodeIndex}");
                    return false;
                }
            }

            //check depth of bsp3dtree
            /*
            int back_count = count_bsp3d_nodes(Bsp.Bsp3dNodes[0].BackChild);
            int front_count = count_bsp3d_nodes(Bsp.Bsp3dNodes[0].FrontChild);
            if (front_count > back_count)
                back_count = front_count;
            if(debug && back_count > 128)
                Console.WriteLine($"###WARNING:Depth of Bsp3dTree is {back_count} (max 128 ideally)");
            */
            return true;
        }

        public int count_bsp3d_nodes(int node_index)
        {
            if ((node_index & 0x80000000) != 0)
                return 0;
            int front_count = count_bsp3d_nodes(Bsp.Bsp3dNodes[node_index].FrontChild);
            int back_count = count_bsp3d_nodes(Bsp.Bsp3dNodes[node_index].BackChild);
            if (front_count > back_count)
                back_count = front_count;
            return back_count + 1;
        }

        //function unfinished, is of dubious usefulness
        public bool remove_floating_leaves()
        {
            List<int> leaf_array = new List<int>();
            int leaf_count = 0;
            foreach (var leaf_block in Bsp.Leaves)
            {
                if (leaf_block.Bsp2dReferenceCount > 0)
                    leaf_array.Add(leaf_count++);
                else
                    leaf_array.Add(-1);
            }
            return true;
        }

        //this function removes unnecessary nodes in the tree,
        //i.e. if there are one or more nodes that just lead to -1, they can be removed and the parent can just reference -1
        public bool prune_node_tree()
        {
            //first collapse the node children, shifting -1 up through any unnecessary nodes
            List<int> valid_node_array = new List<int>();
            TagBlock<LargeBsp3dNode> Nodelist = Bsp.Bsp3dNodes.DeepClone();
            Nodelist[0].FrontChild = collapse_node_children(Nodelist, Nodelist[0].FrontChild);
            Nodelist[0].BackChild = collapse_node_children(Nodelist, Nodelist[0].BackChild);

            //this function now does an inline replacement of the nodes block, removing nodes that only have -1 as children
            int node_count = 0;
            int pruned_nodes_count = 0;
            foreach (var node in Nodelist)
            {
                if (node.FrontChild != -1 || node.BackChild != -1)
                {
                    valid_node_array.Add(node_count++);
                }
                else
                {
                    valid_node_array.Add(-1);
                    pruned_nodes_count++;
                }
            }

            //adjust node children to match new node list
            for (var i = 0; i < Nodelist.Count; i++)
            {
                if ((Nodelist[i].FrontChild & 0x80000000) == 0) //child is another node, not a leaf or -1
                {
                    Nodelist[i].FrontChild = valid_node_array[Nodelist[i].FrontChild];
                }
                if ((Nodelist[i].BackChild & 0x80000000) == 0) //child is another node, not a leaf or -1
                {
                    Nodelist[i].BackChild = valid_node_array[Nodelist[i].BackChild];
                }
            }

            //now complete the inline replacement of the node list
            for (var n = 0; n < Nodelist.Count; n++)
            {
                if (valid_node_array[n] > n)
                {
                    Console.WriteLine("###ERROR: node_table[node_index]>node_index");
                    return false;
                }

                if (valid_node_array[n] != -1)
                {
                    Nodelist[valid_node_array[n]] = Nodelist[n].DeepClone();
                }
            }

            //remove extra nodes from the end of the tree
            while (Nodelist.Count > node_count)
                Nodelist.RemoveAt(Nodelist.Count - 1);

            if (pruned_nodes_count > 0 && debug)
                Console.WriteLine($"Pruned {pruned_nodes_count} nodes from tree!");

            //write nodes out to main BSP
            Bsp.Bsp3dNodes = Nodelist.DeepClone();
            return true;
        }

        public int collapse_node_children(TagBlock<LargeBsp3dNode> Nodelist, int node_index)
        {
            int absolute_node_index = node_index & 0x7FFFFFFF;

            if ((node_index & 0x80000000) != 0) //if this child is a leaf or -1, just return it
                return node_index;

            //call this function again for both children of this node
            int front_child_node_index = collapse_node_children(Nodelist, Nodelist[absolute_node_index].FrontChild);
            int back_child_node_index = collapse_node_children(Nodelist, Nodelist[absolute_node_index].BackChild);
            Nodelist[absolute_node_index].FrontChild = front_child_node_index;
            Nodelist[absolute_node_index].BackChild = back_child_node_index;

            //if either of this node's children are not -1, return this node index, otherwise return -1
            if (front_child_node_index != -1 || back_child_node_index != -1)
                return node_index;
            return back_child_node_index;
        }
    }
}
