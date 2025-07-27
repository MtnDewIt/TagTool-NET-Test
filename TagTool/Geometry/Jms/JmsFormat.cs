﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Assimp;
using TagTool.Commands.Common;
using TagTool.Common;
using TagTool.Common.Logging;

namespace TagTool.Geometry.Jms
{
    // REFERENCE:  Halo-Asset-Blender-Development-Toolset
    // https://github.com/General-101/Halo-Asset-Blender-Development-Toolset/blob/master/io_scene_halo/file_jms/build_asset.py

    public class JmsFormat
    {
        private int Version = 8213; // 8213 is the maximum documented version of the JMS format
        private int SignificantFigures = 10;

        private uint NodeCount;
        public List<JmsNode> Nodes = new List<JmsNode>();
        private uint MaterialCount;
        public List<JmsMaterial> Materials = new List<JmsMaterial>();
        private uint MarkerCount;
        public List<JmsMarker> Markers = new List<JmsMarker>();
        private uint VertexCount;
        public List<JmsVertex> Vertices = new List<JmsVertex>();
        private uint TriangleCount;
        public List<JmsTriangle> Triangles = new List<JmsTriangle>();
        private uint SphereCount;
        public List<JmsSphere> Spheres = new List<JmsSphere>();
        private uint BoxCount;
        public List<JmsBox> Boxes = new List<JmsBox>();
        private uint CapsuleCount;
        public List<JmsCapsule> Capsules = new List<JmsCapsule>();
        private uint ConvexShapeCount;
        public List<JmsConvexShape> ConvexShapes = new List<JmsConvexShape>();
        private uint RagdollCount;
        public List<JmsRagdoll> Ragdolls = new List<JmsRagdoll>();
        private uint HingeCount;
        public List<JmsHinge> Hinges = new List<JmsHinge>();
        private uint SkylightCount;
        public List<JmsSkylight> Skylights = new List<JmsSkylight>();

        public bool TryRead(FileInfo file)
        {
            try
            {
                Read(file);
            }
            catch (Exception)
            {
                Log.Error("Invalid JMS.");
                return false;
            }
            return true;
        }

        public void Write(FileInfo file)
        {
            using(var stream = file.CreateText())
            {
                stream.WriteLine(";### VERSION ###");
                stream.WriteLine(Version);
                stream.WriteLine();

                stream.WriteLine(";### NODES ###");
                stream.WriteLine(Nodes.Count);
                stream.WriteLine(";\t<name>");
                stream.WriteLine(";\t<parent node index>");
                stream.WriteLine(";\t<default rotation <i,j,k,w>>");
                stream.WriteLine(";\t<default translation <x,y,z>>");
                stream.WriteLine();
                for (var nodeindex = 0; nodeindex < Nodes.Count; nodeindex++)
                {
                    stream.WriteLine($";NODE {nodeindex}");
                    Nodes[nodeindex].Write(stream);
                    stream.WriteLine();
                }

                stream.WriteLine(";### MATERIALS ###");
                stream.WriteLine(Materials.Count);
                stream.WriteLine(";\t<name>");
                stream.WriteLine(";\t<material name>");
                stream.WriteLine();
                for (var materialindex = 0; materialindex < Materials.Count; materialindex++)
                {
                    stream.WriteLine($";MATERIAL {materialindex}");
                    Materials[materialindex].Write(stream);
                    stream.WriteLine();
                }

                stream.WriteLine(";### MARKERS ###");
                stream.WriteLine(Markers.Count);
                stream.WriteLine(";\t<name>");
                stream.WriteLine(";\t<node index>");
                stream.WriteLine(";\t<rotation <i,j,k,w>>");
                stream.WriteLine(";\t<translation <x,y,z>>");
                stream.WriteLine(";\t<radius>");
                stream.WriteLine();
                for (var markerindex = 0; markerindex < Markers.Count; markerindex++)
                {
                    stream.WriteLine($";MARKER {markerindex}");
                    Markers[markerindex].Write(stream);
                    stream.WriteLine();
                }

                //leave unpopulated for now
                stream.WriteLine(";### INSTANCE XREF PATHS ###");
                stream.WriteLine(0);
                stream.WriteLine(";\t<path>");
                stream.WriteLine(";\t<name>");
                stream.WriteLine();

                //leave unpopulated for now
                stream.WriteLine(";### INSTANCE MARKERS ###");
                stream.WriteLine(0);
                stream.WriteLine(";\t<name>");
                stream.WriteLine(";\t<unique identifier>");
                stream.WriteLine(";\t<path index>");
                stream.WriteLine(";\t<rotation <i,j,k,w>>");
                stream.WriteLine(";\t<translation <x,y,z>>");
                stream.WriteLine();

                stream.WriteLine(";### VERTICES ###");
                stream.WriteLine(Vertices.Count);
                stream.WriteLine(";\t<position>");
                stream.WriteLine(";\t<normal>");
                stream.WriteLine(";\t<node influences count>");
                stream.WriteLine(";\t\t<node influences <index, weight>>");
                stream.WriteLine(";\t\t<...>");
                stream.WriteLine(";\t<texture coordinate count>");
                stream.WriteLine(";\t\t<texture coordinates <u,v>>");
                stream.WriteLine(";\t\t<...>");
                stream.WriteLine(";\t\t<vertex color <r,g,b>>");
                stream.WriteLine(";\t\t<...>");
                stream.WriteLine();
                for (var vertexindex = 0; vertexindex < Vertices.Count; vertexindex++)
                {
                    stream.WriteLine($";VERTEX {vertexindex}");
                    Vertices[vertexindex].Write(stream);
                    stream.WriteLine();
                }

                stream.WriteLine(";### TRIANGLES ###");
                stream.WriteLine(Triangles.Count);
                stream.WriteLine(";\t<material index>");
                stream.WriteLine(";\t<vertex indices <v0,v1,v2>>");
                stream.WriteLine();
                for (var triangleindex = 0; triangleindex < Triangles.Count; triangleindex++)
                {
                    stream.WriteLine($";TRIANGLE {triangleindex}");
                    Triangles[triangleindex].Write(stream);
                    stream.WriteLine();
                }

                stream.WriteLine(";### SPHERES ###");
                stream.WriteLine(Spheres.Count);
                stream.WriteLine(";\t<name>");
                stream.WriteLine(";\t<parent>");
                stream.WriteLine(";\t<material>");
                stream.WriteLine(";\t<rotation <i,j,k,w>>");
                stream.WriteLine(";\t<translation <x,y,z>>");
                stream.WriteLine(";\t<radius>");
                stream.WriteLine();
                for (var sphereindex = 0; sphereindex < Spheres.Count; sphereindex++)
                {
                    stream.WriteLine($";SPHERE {sphereindex}");
                    Spheres[sphereindex].Write(stream);
                    stream.WriteLine();
                }

                stream.WriteLine(";### BOXES ###");
                stream.WriteLine(Boxes.Count);
                stream.WriteLine(";\t<name>");
                stream.WriteLine(";\t<parent>");
                stream.WriteLine(";\t<material>");
                stream.WriteLine(";\t<rotation <i,j,k,w>>");
                stream.WriteLine(";\t<translation <x,y,z>>");
                stream.WriteLine(";\t<width (x)>");
                stream.WriteLine(";\t<length (y)>");
                stream.WriteLine(";\t<height (z)>");
                stream.WriteLine();
                for (var boxindex = 0; boxindex < Boxes.Count; boxindex++)
                {
                    stream.WriteLine($";BOX {boxindex}");
                    Boxes[boxindex].Write(stream);
                    stream.WriteLine();
                }

                stream.WriteLine(";### CAPSULES ###");
                stream.WriteLine(Capsules.Count);
                stream.WriteLine(";\t<name>");
                stream.WriteLine(";\t<parent>");
                stream.WriteLine(";\t<material>");
                stream.WriteLine(";\t<rotation <i,j,k,w>>");
                stream.WriteLine(";\t<translation <x,y,z>>");
                stream.WriteLine(";\t<height>");
                stream.WriteLine(";\t<radius>");
                stream.WriteLine();
                for (var capsuleindex = 0; capsuleindex < Capsules.Count; capsuleindex++)
                {
                    stream.WriteLine($";CAPSULE {capsuleindex}");
                    Capsules[capsuleindex].Write(stream);
                    stream.WriteLine();
                }

                stream.WriteLine(";### CONVEX SHAPES ###");
                stream.WriteLine(ConvexShapes.Count);
                stream.WriteLine(";\t<name>");
                stream.WriteLine(";\t<parent>");
                stream.WriteLine(";\t<material>");
                stream.WriteLine(";\t<rotation <i,j,k,w>>");
                stream.WriteLine(";\t<translation <x,y,z>>");
                stream.WriteLine(";\t<vertex count>");
                stream.WriteLine(";\t<...vertices>");
                stream.WriteLine();
                for (var convexshapeindex = 0; convexshapeindex < ConvexShapes.Count; convexshapeindex++)
                {
                    stream.WriteLine($";CONVEX {convexshapeindex}");
                    ConvexShapes[convexshapeindex].Write(stream);
                    stream.WriteLine();
                }

                stream.WriteLine(";### RAGDOLLS ###");
                stream.WriteLine(Ragdolls.Count);
                stream.WriteLine(";\t<name>");
                stream.WriteLine(";\t<attached index>");
                stream.WriteLine(";\t<referenced index>");
                stream.WriteLine(";\t<attached transform>");
                stream.WriteLine(";\t<reference transform>");
                stream.WriteLine(";\t<min twist>");
                stream.WriteLine(";\t<max twist>");
                stream.WriteLine(";\t<min cone>");
                stream.WriteLine(";\t<max cone>");
                stream.WriteLine(";\t<min plane>");
                stream.WriteLine(";\t<max plane>");
                stream.WriteLine(";\t<friction limit>");
                stream.WriteLine();
                for (var ragdollindex = 0; ragdollindex < Ragdolls.Count; ragdollindex++)
                {
                    stream.WriteLine($";RAGDOLL {ragdollindex}");
                    Ragdolls[ragdollindex].Write(stream);
                    stream.WriteLine();
                }

                stream.WriteLine(";### HINGES ###");
                stream.WriteLine(Hinges.Count);
                stream.WriteLine(";\t<name>");
                stream.WriteLine(";\t<body A index>");
                stream.WriteLine(";\t<body B index>");
                stream.WriteLine(";\t<body A transform>");
                stream.WriteLine(";\t<body B transform>");
                stream.WriteLine(";\t<is limited>");
                stream.WriteLine(";\t<friction limit>");
                stream.WriteLine(";\t<min angle>");
                stream.WriteLine(";\t<max angle");
                stream.WriteLine();
                for (var hingeindex = 0; hingeindex < Hinges.Count; hingeindex++)
                {
                    stream.WriteLine($";HINGE {hingeindex}");
                    Hinges[hingeindex].Write(stream);
                    stream.WriteLine();
                }

                //leave unpopulated for now
                stream.WriteLine(";### CAR_WHEEL ###");
                stream.WriteLine("0");
                stream.WriteLine(";\t<name>");
                stream.WriteLine(";\t<chassis index>");
                stream.WriteLine(";\t<wheel index>");
                stream.WriteLine(";\t<chassis transform>");
                stream.WriteLine(";\t<wheel transform>");
                stream.WriteLine(";\t<suspension transform>");
                stream.WriteLine(";\t<suspension min limit>");
                stream.WriteLine(";\t<suspension max limit>");
                stream.WriteLine(";\t<friction limit>");
                stream.WriteLine(";\t<velocity>");
                stream.WriteLine(";\t<gain>");
                stream.WriteLine();

                //leave unpopulated for now
                stream.WriteLine(";### POINT_TO_POINT ###");
                stream.WriteLine("0");
                stream.WriteLine(";\t<name>");
                stream.WriteLine(";\t<body A index>");
                stream.WriteLine(";\t<body B index>");
                stream.WriteLine(";\t<body A transform>");
                stream.WriteLine(";\t<body B transform>");
                stream.WriteLine(";\t<constraint type>");
                stream.WriteLine(";\t<x min limit>");
                stream.WriteLine(";\t<x max limit>");
                stream.WriteLine(";\t<y min limit>");
                stream.WriteLine(";\t<y max limit>");
                stream.WriteLine(";\t<z min limit>");
                stream.WriteLine(";\t<z max limit>");
                stream.WriteLine(";\t<spring length>");
                stream.WriteLine();

                //leave unpopulated for now
                stream.WriteLine(";### PRISMATIC ###");
                stream.WriteLine("0");
                stream.WriteLine(";\t<name>");
                stream.WriteLine(";\t<body A index>");
                stream.WriteLine(";\t<body B index>");
                stream.WriteLine(";\t<body A transform>");
                stream.WriteLine(";\t<body B transform>");
                stream.WriteLine(";\t<is limited>");
                stream.WriteLine(";\t<friction limit>");
                stream.WriteLine(";\t<min limit>");
                stream.WriteLine(";\t<max limit>");
                stream.WriteLine();

                //leave unpopulated for now
                stream.WriteLine(";### BOUNDING SPHERE ###");
                stream.WriteLine("0");
                stream.WriteLine(";\t<translation <x,y,z>>");
                stream.WriteLine(";\t<radius>");
                stream.WriteLine();

                //leave unpopulated for now
                stream.WriteLine(";### SKYLIGHT ###");
                stream.WriteLine(Skylights.Count);
                stream.WriteLine(";\t<direction <x,y,z>>");
                stream.WriteLine(";\t<radiant intensity <x,y,z>>");
                stream.WriteLine(";\t<solid angle>");
                stream.WriteLine();
                for (var skylightindex = 0; skylightindex < Skylights.Count; skylightindex++)
                {
                    stream.WriteLine($";SKYLIGHT {skylightindex}");
                    Skylights[skylightindex].Write(stream);
                    stream.WriteLine();
                }
            }
        }

        public void Read(FileInfo file)
        {
            using (var stream = file.OpenText())
            {
                if (stream.BaseStream.Length > 0)
                {
                    stream.ReadLine();
                    Version = int.Parse(stream.ReadLine());
                    if (Version != 8213)
                    {
                        Log.Error("JMS reading only supported for version 8213");
                        return;
                    }

                    // parse Nodes
                    while (true)
                    {
                        if (stream.ReadLine() != ";### NODES ###")
                        {
                            continue;
                        }
                        break;
                    }

                    NodeCount = uint.Parse(stream.ReadLine());
                    for (int i = 0; i < NodeCount; i++)
                    {
                        // parse each Node Instance
                        while (true)
                        {
                            if (stream.ReadLine() != ";NODE " + i.ToString())
                            {
                                continue;
                            }
                            break;
                        }

                        JmsNode node = new JmsNode();
                        node.Read(stream);                  
                        Nodes.Add(node);
                    }

                    // parse Materials
                    while (true)
                    {
                        if (stream.ReadLine() != ";### MATERIALS ###")
                        {
                            continue;
                        }
                        break;
                    }

                    MaterialCount = uint.Parse(stream.ReadLine());
                    for (int i = 0; i < MaterialCount; i++)
                    {
                        // parse each Material Instance
                        while (true)
                        {
                            if (stream.ReadLine() != ";MATERIAL " + i.ToString())
                            {
                                continue;
                            }
                            break;
                        }

                        JmsMaterial material = new JmsMaterial();
                        material.Read(stream);
                        Materials.Add(material);
                    }

                    // parse Markers
                    while (true)
                    {
                        if (stream.ReadLine() != ";### MARKERS ###")
                        {
                            continue;
                        }
                        break;
                    }

                    MarkerCount = uint.Parse(stream.ReadLine());
                    for (int i = 0; i < MarkerCount; i++)
                    {
                        JmsMarker marker = new JmsMarker();
                        marker.Read(stream);
                        Markers.Add(marker);
                    }

                    // parse Vertices
                    while (true)
                    {
                        if (stream.ReadLine() != ";### VERTICES ###")
                        {
                            continue;
                        }
                        break;
                    }

                    VertexCount = uint.Parse(stream.ReadLine());
                    for (int i = 0; i < VertexCount; i++)
                    {
                        // parse each Vertex Instance
                        while (true)
                        {
                            if (stream.ReadLine() != ";VERTEX " + i.ToString())
                            {
                                continue;
                            }
                            break;
                        }

                        JmsVertex vertex = new JmsVertex();
                        vertex.Read(stream);
                        Vertices.Add(vertex);
                    }

                    // parse Triangles
                    while (true)
                    {
                        if (stream.ReadLine() != ";### TRIANGLES ###")
                        {
                            continue;
                        }
                        break;
                    }

                    TriangleCount = uint.Parse(stream.ReadLine());
                    for (int i = 0; i < TriangleCount; i++)
                    {
                        // parse each Triangle Instance
                        while (true)
                        {
                            if (stream.ReadLine() != ";TRIANGLE " + i.ToString())
                            {
                                continue;
                            }
                            break;
                        }

                        JmsTriangle triangle = new JmsTriangle();
                        triangle.Read(stream);
                        Triangles.Add(triangle);
                    }

                    // parse Convex Shapes
                    while (true)
                    {
                        if (stream.ReadLine() != ";### CONVEX SHAPES ###")
                        {
                            continue;
                        }
                        break;
                    }

                    ConvexShapeCount = uint.Parse(stream.ReadLine());
                    for (int i = 0; i < ConvexShapeCount; i++)
                    {
                        // parse each ConvexShape Instance
                        while (true)
                        {
                            if (stream.ReadLine() != ";CONVEX " + i.ToString())
                            {
                                continue;
                            }
                            break;
                        }

                        JmsConvexShape convexShape = new JmsConvexShape();
                        convexShape.Read(stream);
                        ConvexShapes.Add(convexShape);
                    }
                }
            }
            return;
        }

        public class JmsNode : JmsElement
        {
            public string Name = "default";
            public int ParentNodeIndex = -1;
            public RealQuaternion Rotation = new RealQuaternion(0, 0, 0, 0);
            public RealVector3d Position = new RealVector3d(0, 0, 0);

            public void Read(StreamReader stream)
            {
                Name = stream.ReadLine();
                ParentNodeIndex = int.Parse(stream.ReadLine());
                Rotation = ReadQuaternion(stream);
                Position = ReadVector3d(stream);
            }

            public void Write(StreamWriter stream)
            {
                stream.WriteLine(Name);
                stream.WriteLine(ParentNodeIndex);
                WriteQuaternion(Rotation, stream);
                WriteVector3d(Position, stream);            
            }
        }

        public class JmsMaterial : JmsElement
        {
            public string Name = "default";
            public string MaterialName = "default";

            public void Read(StreamReader stream)
            {
                Name = stream.ReadLine();
                MaterialName = stream.ReadLine();
            }

            public void Write(StreamWriter stream)
            {
                stream.WriteLine(Name);
                stream.WriteLine(MaterialName);
            }
        }

        public class JmsMarker : JmsElement
        {
            public string Name = "default";
            public int NodeIndex = -1;
            public RealQuaternion Rotation = new RealQuaternion(0, 0, 0, 0);
            public RealVector3d Translation = new RealVector3d(0, 0, 0);
            public float Radius = 0.0f;

            public void Read(StreamReader stream)
            {
            }

            public void Write(StreamWriter stream)
            {
                stream.WriteLine(Name);
                stream.WriteLine(NodeIndex);
                WriteQuaternion(Rotation, stream);
                WriteVector3d(Translation, stream);
                WriteFloat(Radius, stream);
            }
        }

        public class JmsVertex : JmsElement
        {
            public RealPoint3d Position = new RealPoint3d(0, 0, 0);
            public RealVector3d Normal = new RealVector3d(0, 0, 0);
            public List<NodeSet> NodeSets = new List<NodeSet>();
            public List<UvSet> UvSets = new List<UvSet>();
            public RealRgbColor VertexColor = new RealRgbColor(0, 0, 0);

            public class NodeSet
            {
                public int NodeIndex = -1;
                public float NodeWeight = 0.0f;
            }
            public class UvSet
            {
                public RealPoint2d TextureCoordinates = new RealPoint2d();
            }
            public void Read(StreamReader stream)
            {
                Position = ReadPoint3d(stream);
                Normal = ReadVector3d(stream);
                int nodeSetCount = int.Parse(stream.ReadLine());
                for (int i = 0; i < nodeSetCount; i++)
                {
                    NodeSets.Add(new NodeSet());
                    NodeSets[i].NodeIndex = int.Parse(stream.ReadLine());
                    NodeSets[i].NodeWeight = float.Parse(stream.ReadLine());
                }
                int uvSetCount = int.Parse(stream.ReadLine());
                for (int i = 0; i < uvSetCount; i++)
                {
                    UvSets.Add(new UvSet());
                    UvSets[i].TextureCoordinates = ReadPoint2d(stream);
                }
                VertexColor = ReadRGBColor(stream);
            }
            public void Write(StreamWriter stream)
            {
                WritePoint3d(Position, stream);
                WriteVector3d(Normal, stream);
                stream.WriteLine(NodeSets.Count);
                if (NodeSets.Count > 0)
                {
                    foreach (var nodeset in NodeSets)
                    {
                        stream.WriteLine(nodeset.NodeIndex);
                        WriteFloat(nodeset.NodeWeight, stream);
                    }
                }
                stream.WriteLine(UvSets.Count);
                if (UvSets.Count > 0)
                {
                    foreach (var uvset in UvSets)
                    {
                        WritePoint2d(uvset.TextureCoordinates, stream);
                    }
                }
                //color is null
                WritePoint3d(new RealPoint3d(), stream);
            }
        }

        public class JmsTriangle : JmsElement
        {
            public int MaterialIndex = -1;
            public List<int> VertexIndices = new List<int>();

            public void Read(StreamReader stream)
            {
                MaterialIndex = int.Parse(stream.ReadLine());

                // parse triangle indices
                string[] indexArray = stream.ReadLine().Split('\t');
                for (byte index = 0; index < indexArray.Length; index++)
                    VertexIndices.Add(int.Parse(indexArray[index]));
            }

            public void Write(StreamWriter stream)
            {
                stream.WriteLine(MaterialIndex);
                stream.WriteLine($"{VertexIndices[0]}\t{VertexIndices[1]}\t{VertexIndices[2]}");
            }
        }

        public class JmsSphere : JmsElement
        {
            public string Name = "default";
            public int Parent = -1;
            public int Material = -1;
            public RealQuaternion Rotation = new RealQuaternion(0, 0, 0, 0);
            public RealVector3d Translation = new RealVector3d(0, 0, 0);
            public float Radius = 0.0f;

            public void Read(StreamReader stream)
            {
            }

            public void Write(StreamWriter stream)
            {
                stream.WriteLine(Name);
                stream.WriteLine(Parent);
                stream.WriteLine(Material);
                WriteQuaternion(Rotation, stream);
                WriteVector3d(Translation, stream);
                WriteFloat(Radius, stream);
            }
        }

        public class JmsBox : JmsElement
        {
            public string Name = "default";
            public int Parent = -1;
            public int Material = -1;
            public RealQuaternion Rotation = new RealQuaternion(0, 0, 0, 0);
            public RealVector3d Translation = new RealVector3d(0, 0, 0);
            public float Width = 0.0f;
            public float Length = 0.0f;
            public float Height = 0.0f;

            public void Read(StreamReader stream)
            {
            }

            public void Write(StreamWriter stream)
            {
                stream.WriteLine(Name);
                stream.WriteLine(Parent);
                stream.WriteLine(Material);
                WriteQuaternion(Rotation, stream);
                WriteVector3d(Translation, stream);
                WriteFloat(Width, stream);
                WriteFloat(Length, stream);
                WriteFloat(Height, stream);
            }
        }

        public class JmsCapsule : JmsElement
        {
            public string Name = "default";
            public int Parent = -1;
            public int Material = -1;
            public RealQuaternion Rotation = new RealQuaternion(0, 0, 0, 0);
            public RealVector3d Translation = new RealVector3d(0, 0, 0);
            public float Height = 0.0f;
            public float Radius = 0.0f;

            public void Read(StreamReader stream)
            {
            }

            public void Write(StreamWriter stream)
            {
                stream.WriteLine(Name);
                stream.WriteLine(Parent);
                stream.WriteLine(Material);
                WriteQuaternion(Rotation, stream);
                WriteVector3d(Translation, stream);
                WriteFloat(Height, stream);
                WriteFloat(Radius, stream);
            }
        }

        public class JmsConvexShape : JmsElement
        {
            public string Name = "default";
            public int Parent = -1;
            public int Material = -1;
            public RealQuaternion Rotation = new RealQuaternion(0, 0, 0, 0);
            public RealVector3d Translation = new RealVector3d(0, 0, 0);
            public int ShapeVertexCount = 0;
            public List<RealPoint3d> ShapeVertices = new List<RealPoint3d>();

            public void Read(StreamReader stream)
            {
                Name = stream.ReadLine();
                Parent = int.Parse(stream.ReadLine());
                Material = int.Parse(stream.ReadLine());
                Rotation = ReadQuaternion(stream);
                Translation = ReadVector3d(stream);
                ShapeVertexCount = int.Parse(stream.ReadLine());
                for (int i = 0; i < ShapeVertexCount; i++)
                    ShapeVertices.Add(ReadPoint3d(stream));
            }

            public void Write(StreamWriter stream)
            {
                stream.WriteLine(Name);
                stream.WriteLine(Parent);
                stream.WriteLine(Material);
                WriteQuaternion(Rotation, stream);
                WriteVector3d(Translation, stream);
                stream.WriteLine(ShapeVertexCount);
                foreach(var shapevert in ShapeVertices)
                    WritePoint3d(shapevert, stream);
            }
        }

        public class JmsRagdoll : JmsElement
        {
            public string Name = "default";
            public int AttachedIndex = -1;
            public int ReferencedIndex = -1;
            public RealQuaternion AttachedTransformOrientation = new RealQuaternion(0, 0, 0, 0);
            public RealVector3d AttachedTransformPosition = new RealVector3d(0, 0, 0);
            public RealQuaternion ReferenceTransformOrientation = new RealQuaternion(0, 0, 0, 0);
            public RealVector3d ReferenceTransformPosition = new RealVector3d(0, 0, 0);
            public float MinTwist;
            public float MaxTwist;
            public float MinCone;
            public float MaxCone;
            public float MinPlane;
            public float MaxPlane;
            public float FrictionLimit;
            public void Read(StreamReader stream)
            {
            }

            public void Write(StreamWriter stream)
            {
                stream.WriteLine(Name);
                stream.WriteLine(AttachedIndex);
                stream.WriteLine(ReferencedIndex);
                WriteQuaternion(AttachedTransformOrientation, stream);
                WriteVector3d(AttachedTransformPosition, stream);
                WriteQuaternion(ReferenceTransformOrientation, stream);
                WriteVector3d(ReferenceTransformPosition, stream);
                WriteFloat(MinTwist, stream);
                WriteFloat(MaxTwist, stream);
                WriteFloat(MinCone, stream);
                WriteFloat(MaxCone, stream); 
                WriteFloat(MinPlane, stream);
                WriteFloat(MaxPlane, stream);
                WriteFloat(FrictionLimit, stream);
            }
        }

        public class JmsHinge : JmsElement
        {
            public string Name = "default";
            public int BodyAIndex = -1;
            public int BodyBIndex = -1;
            public RealQuaternion BodyATransformOrientation = new RealQuaternion(0, 0, 0, 0);
            public RealVector3d BodyATransformPosition = new RealVector3d(0, 0, 0);
            public RealQuaternion BodyBTransformOrientation = new RealQuaternion(0, 0, 0, 0);
            public RealVector3d BodyBTransformPosition = new RealVector3d(0, 0, 0);
            public int IsLimited;
            public float FrictionLimit;
            public float MinAngle;
            public float MaxAngle;
            public void Read(StreamReader stream)
            {
            }

            public void Write(StreamWriter stream)
            {
                stream.WriteLine(Name);
                stream.WriteLine(BodyAIndex);
                stream.WriteLine(BodyBIndex);
                WriteQuaternion(BodyATransformOrientation, stream);
                WriteVector3d(BodyATransformPosition, stream);
                WriteQuaternion(BodyBTransformOrientation, stream);
                WriteVector3d(BodyBTransformPosition, stream);
                stream.WriteLine(IsLimited);
                WriteFloat(FrictionLimit, stream);
                WriteFloat(MinAngle, stream);
                WriteFloat(MaxAngle, stream);
            }
        }

        public class JmsSkylight : JmsElement
        {
            public RealVector3d Direction = new RealVector3d(0, 0, 0);
            public RealVector3d RadiantIntensity = new RealVector3d(0, 0, 0);
            public float SolidAngle = 0.0f;

            public void Read(StreamReader stream)
            {
            }

            public void Write(StreamWriter stream)
            {
                WriteVector3d(Direction, stream);
                WriteVector3d(RadiantIntensity, stream);
                WriteFloat(SolidAngle, stream);
            }
        }

        //inherited class that contains all of the writing methods
        public class JmsElement
        {
            public void WriteQuaternion(RealQuaternion quaternion, StreamWriter stream)
            {
                stream.Write(quaternion.I.ToString("0.0000000000"));
                stream.Write('\t');
                stream.Write(quaternion.J.ToString("0.0000000000"));
                stream.Write('\t');
                stream.Write(quaternion.K.ToString("0.0000000000"));
                stream.Write('\t');
                stream.Write(quaternion.W.ToString("0.0000000000"));
                stream.WriteLine();
            }

            public void WriteVector3d(RealVector3d point, StreamWriter stream)
            {
                stream.Write(point.I.ToString("0.0000000000"));
                stream.Write('\t');
                stream.Write(point.J.ToString("0.0000000000"));
                stream.Write('\t');
                stream.Write(point.K.ToString("0.0000000000"));
                stream.WriteLine();
            }
            public void WritePoint3d(RealPoint3d point, StreamWriter stream)
            {
                stream.Write(point.X.ToString("0.0000000000"));
                stream.Write('\t');
                stream.Write(point.Y.ToString("0.0000000000"));
                stream.Write('\t');
                stream.Write(point.Z.ToString("0.0000000000"));
                stream.WriteLine();
            }
            public void WriteRealRGB(RealRgbColor color, StreamWriter stream)
            {
                stream.Write(color.Red.ToString("0.0000000000"));
                stream.Write('\t');
                stream.Write(color.Green.ToString("0.0000000000"));
                stream.Write('\t');
                stream.Write(color.Blue.ToString("0.0000000000"));
                stream.WriteLine();
            }

            public void WritePoint2d(RealPoint2d point, StreamWriter stream)
            {
                stream.Write(point.X.ToString("0.0000000000"));
                stream.Write('\t');
                stream.Write(point.Y.ToString("0.0000000000"));
                stream.WriteLine();
            }

            public void WriteFloat(float number, StreamWriter stream)
            {
                stream.WriteLine(number.ToString("0.0000000000"));
            }

            public RealPoint2d ReadPoint2d(StreamReader stream)
            {
                string[] point2dArray = stream.ReadLine().Split('\t');
                return new RealPoint2d(float.Parse(point2dArray[0]), float.Parse(point2dArray[1]));
            }

            public RealVector3d ReadVector3d(StreamReader stream)
            {
                string[] vector3dArray = stream.ReadLine().Split('\t');
                return new RealVector3d(float.Parse(vector3dArray[0]), float.Parse(vector3dArray[1]), float.Parse(vector3dArray[2]));
            }

            public RealPoint3d ReadPoint3d(StreamReader stream)
            {
                string[] point3dArray = stream.ReadLine().Split('\t');
                return new RealPoint3d(float.Parse(point3dArray[0]), float.Parse(point3dArray[1]), float.Parse(point3dArray[2]));
            }

            public RealRgbColor ReadRGBColor(StreamReader stream)
            {
                string[] rgbColorArray = stream.ReadLine().Split('\t');
                return new RealRgbColor(float.Parse(rgbColorArray[0]), float.Parse(rgbColorArray[1]), float.Parse(rgbColorArray[2]));
            }

            public RealQuaternion ReadQuaternion(StreamReader stream)
            {
                string[] quaternion4dArray = stream.ReadLine().Split('\t');
                return new RealQuaternion(float.Parse(quaternion4dArray[0]), float.Parse(quaternion4dArray[1]), float.Parse(quaternion4dArray[2]), float.Parse(quaternion4dArray[3]));
            }
        }       
    }
}
