﻿using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.IO;
using TagTool.IO;
using TagTool.Cache;
using TagTool.Commands.Common;
using TagTool.Common;
using TagTool.Geometry.BspCollisionGeometry;
using TagTool.Tags.Definitions;
using TagTool.Tags;
using System.Diagnostics;
using TagTool.Havok;
using TagTool.Common.Logging;

namespace TagTool.Commands.CollisionModels
{
    public class GenerateBspPhysicsCommand : Command
    {
        public CollisionGeometry Bsp { get; set; }
        public CollisionModel Definition { get; set; }

        public GenerateBspPhysicsCommand(ref CollisionModel definition) :
            base(true,

                "GenerateBspPhysics",
                "Generates BspPhysics for the current collision tag, removing the previous BspPhysics",

                "GenerateBspPhysics",

                "")
        {
            Definition = definition;
            Bsp = new CollisionGeometry();
        }
        public override object Execute(List<string> args)
        {
            CollisionModel.Region.Permutation Permutation = Definition.Regions[0].Permutations[0];
            Bsp = Definition.Regions[0].Permutations[0].Bsps[0].Geometry;
            Console.WriteLine("NOOOO you can't just generate mopps with that shitty code! (begin mopp generation)");
            if (!generate_mopp_codes(ref Permutation))
            {
                Log.Error("Failed to build mopps!");
                return false;
            }
            else
            {
                Console.WriteLine("HAHA mopps go BRRRRRRR (Mopps built successfully!)");
                Definition.Regions[0].Permutations[0] = Permutation;
            }           
            return true;
        }

        unsafe public bool generate_mopp_codes(ref CollisionModel.Region.Permutation Permutation)
        {
            var moppCodes = HavokMoppGenerator.GenerateCollisionMopp(Bsp);
            if(moppCodes == null)
            {
                Console.WriteLine("No moppcodes produced!");
                return false;
            }

            //populate fields with the appropriate values
            Permutation.BspMoppCodes = new List<Havok.TagHkpMoppCode> { new Havok.TagHkpMoppCode { Data = new TagBlock<byte>() } };
            Permutation.BspPhysics = new List<CollisionBspPhysicsDefinition> { new CollisionBspPhysicsDefinition() };

            foreach(byte moppcode in moppCodes.Data)
            {
                Permutation.BspMoppCodes[0].Data.Add(moppcode);
            }

            Permutation.BspMoppCodes[0].Info = moppCodes.Info;
            Permutation.BspMoppCodes[0].ArrayBase = new Havok.HkArrayBase { Size = (uint)moppCodes.Data.Count, CapacityAndFlags = (uint)(moppCodes.Data.Count | 0x80000000)};
            Permutation.BspMoppCodes[0].ReferencedObject = new Havok.HkpReferencedObject { ReferenceCount = 128 };

            Permutation.BspPhysics[0].MoppBvTreeShape = new Havok.CMoppBvTreeShape
            {
                ReferencedObject = new Havok.HkpReferencedObject { ReferenceCount = 128 },
                Type = 27
            };

            List<RealQuaternion> AABB_parameters = get_model_half_extents();

            Permutation.BspPhysics[0].GeometryShape = new CollisionGeometryShape
            {
                Type = 2,
                BspIndex = -1,
                CollisionGeometryShapeKey = 65535,
                AABB_Center = AABB_parameters[0],
                AABB_Half_Extents = AABB_parameters[1]
            };
                
            return true;
        }

        List<RealQuaternion> get_model_half_extents()
        {

            RealPoint3d mincoords = new RealPoint3d(float.MaxValue, float.MaxValue, float.MaxValue);
            RealPoint3d maxcoords = new RealPoint3d(float.MinValue, float.MinValue, float.MinValue);

            foreach(Vertex vertex in Bsp.Vertices)
            {
                RealPoint3d point = vertex.Point;
                if (point.X < mincoords.X)
                    mincoords.X = point.X;
                if (point.X > maxcoords.X)
                    maxcoords.X = point.X;
                if (point.Y < mincoords.Y)
                    mincoords.Y = point.Y;
                if (point.Y > maxcoords.Y)
                    maxcoords.Y = point.Y;
                if (point.Z < mincoords.Z)
                    mincoords.Z = point.Z;
                if (point.Z > maxcoords.Z)
                    maxcoords.Z = point.Z;
            }

            RealPoint3d scale = new RealPoint3d(maxcoords.X - mincoords.X, maxcoords.Y - mincoords.Y, maxcoords.Z - mincoords.Z);

            List<RealQuaternion> AABB_parameters = new List<RealQuaternion>();
            RealQuaternion half_extents = new RealQuaternion(scale.X / 2, scale.Y / 2, scale.Z / 2);
            RealQuaternion center = new RealQuaternion(maxcoords.X - half_extents.I, maxcoords.Y - half_extents.J, maxcoords.Z - half_extents.K);

            AABB_parameters.Add(center);
            AABB_parameters.Add(half_extents);
            return AABB_parameters;
        }

        List<int> surface_collect_vertices(int surface_index)
        {
            List<int> vertex_index_list = new List<int>();
            Surface surface_block = Bsp.Surfaces[surface_index];
            int first_Edge_index = surface_block.FirstEdge;
            int current_edge_index = surface_block.FirstEdge;
            do
            {
                Edge edge_block = Bsp.Edges[current_edge_index];
                if (edge_block.RightSurface == surface_index)
                {
                    current_edge_index = edge_block.ReverseEdge;
                    vertex_index_list.Add(edge_block.EndVertex);
                }
                else
                {
                    current_edge_index = edge_block.ForwardEdge;
                    vertex_index_list.Add(edge_block.StartVertex);
                }
            }
            while (current_edge_index != first_Edge_index);
            return vertex_index_list;
        }
    }
}