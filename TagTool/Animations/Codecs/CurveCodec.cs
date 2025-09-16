﻿using TagTool.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using TagTool.Common;
using TagTool.Cache;

namespace TagTool.Animations.Codecs
{
    public class CurveCodec : CodecBase
    {
        public uint PayloadDataOffset { get; set; }

        public uint TotalCompressedSize { get; set; }

        public CurveCodec(int framecount)
          : base(framecount)
        {
        }

        public override void Read(EndianReader reader)
        {
            uint position = (uint)reader.BaseStream.Position;
            base.Read(reader);
            TranslationDataOffset = reader.ReadUInt32();
            ScaleDataOffset = reader.ReadUInt32();
            PayloadDataOffset = reader.ReadUInt32();
            TotalCompressedSize = reader.ReadUInt32();
            int num1 = (int)reader.ReadUInt32();

            Rotations = new Quaternion[(int)RotatedNodeCount][];
            Translations = new RealPoint3d[(int)TranslatedNodeCount][];
            Scales = new float[(int)ScaledNodeCount][];
            RotationKeyFrames = new List<List<int>>((int)RotatedNodeCount);
            TranslationKeyFrames = new List<List<int>>((int)TranslatedNodeCount);
            ScaleKeyFrames = new List<List<int>>((int)ScaledNodeCount);
            uint[] rotationkeyframes = new uint[(int)RotatedNodeCount];
            for (int index = 0; index < (int)RotatedNodeCount; ++index)
                rotationkeyframes[index] = reader.ReadUInt32();
            for (int rotatednodeindex = 0; rotatednodeindex < (int)RotatedNodeCount; ++rotatednodeindex)
            {
                List<int> intList = new List<int>();
                reader.BaseStream.Position = (long)(position + PayloadDataOffset + rotationkeyframes[rotatednodeindex]);
                int num2 = (int)reader.ReadUInt16();
                int keyCount = (int)reader.ReadUInt16();
                int num3 = (int)reader.ReadByte();
                int num4 = (int)reader.ReadByte();
                int num5 = (int)reader.ReadInt16();
                if ((num3 & 1) == 0)
                    intList = ReadKeyFrameData(keyCount, reader);
                RotationKeyFrames.Add(Enumerable.Range(0, FrameCount).ToList<int>());
                Rotations[rotatednodeindex] = new Quaternion[FrameCount];
                Quaternion p1 = new Quaternion();
                Quaternion p2 = new Quaternion();
                byte num6 = 0;
                byte num7 = 0;
                byte num8 = 0;
                byte num9 = 0;
                int num10 = 0;
                int index2 = 0;
                int num11 = 0;
                for (int frameindex = 0; frameindex < FrameCount; ++frameindex)
                {
                    Quaternion q;
                    if ((num3 & 1) == 1)
                    {
                        q = DecompressQuat((float)reader.ReadInt16() / (float)short.MaxValue, (float)reader.ReadInt16() / (float)short.MaxValue, (float)reader.ReadInt16() / (float)short.MaxValue);
                    }
                    else
                    {
                        if (intList[index2] == frameindex && frameindex < FrameCount - 1)
                        {
                            float i1 = (float)reader.ReadInt16() / (float)short.MaxValue;
                            float j1 = (float)reader.ReadInt16() / (float)short.MaxValue;
                            float w1 = (float)reader.ReadInt16() / (float)short.MaxValue;
                            num6 = reader.ReadByte();
                            num7 = reader.ReadByte();
                            num8 = reader.ReadByte();
                            num9 = reader.ReadByte();
                            float i2 = (float)reader.ReadInt16() / (float)short.MaxValue;
                            float j2 = (float)reader.ReadInt16() / (float)short.MaxValue;
                            float w2 = (float)reader.ReadInt16() / (float)short.MaxValue;
                            p1 = DecompressQuat(i1, j1, w1);
                            p2 = DecompressQuat(i2, j2, w2);
                            num10 = intList[index2];
                            num11 = intList[index2 + 1];
                            ++index2;
                            //go back 6 bytes so you can read the values again
                            reader.BaseStream.Position -= 6L;
                        }
                        Quaternion tangent1 = CalculateTangent(((int)num6 >> 4) - 7, ((int)num7 >> 4) - 7, ((int)num8 >> 4) - 7, ((int)num9 >> 4) - 7, p1, p2);
                        Quaternion tangent2 = CalculateTangent(((int)num6 & 15) - 7, ((int)num7 & 15) - 7, ((int)num8 & 15) - 7, ((int)num9 & 15) - 7, p1, p2);
                        q = CalculateCurvePosition((float)((double)(frameindex - num10) / (double)(num11 - num10)), tangent1, tangent2, p1, p2);
                    }
                    Rotations[rotatednodeindex][frameindex] = Quaternion.Normalize(q);
                }
            }
            reader.BaseStream.Position = (long)(position + PayloadDataOffset + TranslationDataOffset);
            uint[] numArray2 = new uint[(int)TranslatedNodeCount];
            for (int index = 0; index < (int)TranslatedNodeCount; ++index)
                numArray2[index] = reader.ReadUInt32();
            for (int index1 = 0; index1 < (int)TranslatedNodeCount; ++index1)
            {
                List<int> intList = new List<int>();
                reader.BaseStream.Position = (long)(position + PayloadDataOffset + numArray2[index1]);
                int num2 = (int)reader.ReadUInt16();
                int keyCount = (int)reader.ReadUInt16();
                int num3 = (int)reader.ReadByte();
                int num4 = (int)reader.ReadByte();
                int num5 = (int)reader.ReadUInt16();
                float num6 = reader.ReadSingle();
                float num7 = reader.ReadSingle();
                float num8 = reader.ReadSingle();
                float num9 = reader.ReadSingle();
                if ((num3 & 1) == 0)
                    intList = ReadKeyFrameData(keyCount, reader);
                TranslationKeyFrames.Add(Enumerable.Range(0, FrameCount).ToList<int>());
                Translations[index1] = new RealPoint3d[FrameCount];
                RealPoint3d p1 = new RealPoint3d();
                RealPoint3d p2 = new RealPoint3d();
                byte num10 = 0;
                byte num11 = 0;
                byte num12 = 0;
                int num13 = 0;
                int index2 = 0;
                int num14 = 0;
                for (int index3 = 0; index3 < FrameCount; ++index3)
                {
                    RealPoint3d RealPoint3d2;
                    if ((num3 & 1) == 1)
                    {
                        double num15 = (double)reader.ReadInt16() / (double)short.MaxValue;
                        float num16 = (float)reader.ReadInt16() / (float)short.MaxValue;
                        float num17 = (float)reader.ReadInt16() / (float)short.MaxValue;
                        double num18 = (double)num16;
                        double num19 = (double)num17;
                        RealPoint3d2 = new RealPoint3d((float)num15, (float)num18, (float)num19);
                    }
                    else
                    {
                        if (intList[index2] == index3 && index3 < FrameCount - 1)
                        {
                            float x = (float)reader.ReadInt16() / (float)short.MaxValue;
                            float y = (float)reader.ReadInt16() / (float)short.MaxValue;
                            float z = (float)reader.ReadInt16() / (float)short.MaxValue;
                            num10 = reader.ReadByte();
                            num11 = reader.ReadByte();
                            num12 = reader.ReadByte();
                            double num15 = (double)reader.ReadInt16() / (double)short.MaxValue;
                            float num16 = (float)reader.ReadInt16() / (float)short.MaxValue;
                            float num17 = (float)reader.ReadInt16() / (float)short.MaxValue;
                            p1 = new RealPoint3d(x, y, z);
                            double num18 = (double)num16;
                            double num19 = (double)num17;
                            p2 = new RealPoint3d((float)num15, (float)num18, (float)num19);
                            num13 = intList[index2];
                            num14 = intList[index2 + 1];
                            ++index2;
                            reader.BaseStream.Position -= 6L;
                        }
                        RealPoint3d tangent1 = CalculateTangent(((int)num10 >> 4) - 7, ((int)num11 >> 4) - 7, ((int)num12 >> 4) - 7, p1, p2);
                        RealPoint3d tangent2 = CalculateTangent(((int)num10 & 15) - 7, ((int)num11 & 15) - 7, ((int)num12 & 15) - 7, p1, p2);
                        RealPoint3d2 = CalculateCurvePosition((float)((double)(index3 - num13) / (double)(num14 - num13)), tangent1, tangent2, p1, p2);
                    }
                    RealPoint3d2.X = (float)(((double)num9 * (double)RealPoint3d2.X + (double)num6) * 100.0);
                    RealPoint3d2.Y = (float)(((double)num9 * (double)RealPoint3d2.Y + (double)num7) * 100.0);
                    RealPoint3d2.Z = (float)(((double)num9 * (double)RealPoint3d2.Z + (double)num8) * 100.0);
                    Translations[index1][index3] = RealPoint3d2;
                }
            }
            reader.BaseStream.Position = (long)(position + PayloadDataOffset + ScaleDataOffset);
            uint[] numArray3 = new uint[(int)ScaledNodeCount];
            for (int index = 0; index < (int)ScaledNodeCount; ++index)
                numArray3[index] = reader.ReadUInt32();
            for (int index1 = 0; index1 < (int)ScaledNodeCount; ++index1)
            {
                List<int> intList = new List<int>();
                reader.BaseStream.Position = (long)(position + PayloadDataOffset + numArray3[index1]);
                int num2 = (int)reader.ReadUInt16();
                int keyCount = (int)reader.ReadUInt16();
                int num3 = (int)reader.ReadByte();
                int num4 = (int)reader.ReadByte();
                int num5 = (int)reader.ReadUInt16();
                float num6 = reader.ReadSingle();
                float num7 = reader.ReadSingle();
                if ((num3 & 1) == 0)
                    intList = ReadKeyFrameData(keyCount, reader);
                ScaleKeyFrames.Add(Enumerable.Range(0, FrameCount).ToList<int>());
                Scales[index1] = new float[FrameCount];
                float real1 = 0.0f;
                float real2 = 0.0f;
                byte num8 = 0;
                int num9 = 0;
                int index2 = 0;
                int num10 = 0;
                for (int index3 = 0; index3 < FrameCount; ++index3)
                {
                    float real3;
                    if ((num3 & 1) == 1)
                    {
                        real3 = (float)reader.ReadInt16() / (float)short.MaxValue;
                    }
                    else
                    {
                        if (intList[index2] == index3 && index3 < FrameCount - 1)
                        {
                            float num11 = (float)reader.ReadInt16() / (float)short.MaxValue;
                            num8 = reader.ReadByte();
                            float num12 = (float)reader.ReadInt16() / (float)short.MaxValue;
                            real1 = num11;
                            real2 = num12;
                            num9 = intList[index2];
                            num10 = intList[index2 + 1];
                            ++index2;
                            reader.BaseStream.Position -= 2L;
                        }
                        float tangent1 = CalculateTangent(((int)num8 >> 4) - 7, real1, real2);
                        float tangent2 = CalculateTangent(((int)num8 & 15) - 7, real1, real2);
                        float time = (float)((double)(index3 - num9) / (double)(num10 - num9));
                        real3 = CalculateCurvePosition(time, tangent1, tangent2, real1, real2);
                    }
                    real3 = real3 * num7 + num6;
                    Scales[index1][index3] = real3;
                }
            }
            reader.BaseStream.Position = (long)(position + TotalCompressedSize);
        }

        public override byte[] Write(GameCacheEldoradoBase CacheContext) => throw new NotImplementedException();

        protected List<int> ReadKeyFrameData(int keyCount, EndianReader reader)
        {
            List<int> keyframelist = new List<int>(keyCount);
            keyframelist.Add(0);
            int num = 0;
            for (int index = 0; index < keyCount; ++index)
            {
                num += (int)reader.ReadByte();
                keyframelist.Add(num);
            }
            return keyframelist;
        }

        protected Quaternion DecompressQuat(float i, float j, float w)
        {
            float num = (float)Math.Sqrt((double)Math.Max((float)(1.0 - (double)i * (double)i - (double)j * (double)j), 0.0f));
            if ((double)w < 0.0)
                num *= -1f;
            w = (float)((double)Math.Abs(w) + (double)Math.Abs(w) - 1.0);
            i *= (float)Math.Sqrt(1.0 - (double)w * (double)w);
            j *= (float)Math.Sqrt(1.0 - (double)w * (double)w);
            float k = num * (float)Math.Sqrt(1.0 - (double)w * (double)w);
            return new Quaternion(i, j, k, w);
        }

        protected float CalculateTangent(int tanComponent, float p1, float p2) => (float)((double)Math.Abs((float)tanComponent / 7f) * ((double)tanComponent / 7.0 * 0.300000011920929) + ((double)p2 - (double)p1));

        protected Quaternion CalculateTangent(
          int iTanComponent,
          int jTanComponent,
          int kTanComponent,
          int wTanComponent,
          Quaternion p1,
          Quaternion p2)
        {
            double tangent1 = (double)CalculateTangent(iTanComponent, p1.X, p2.X);
            float tangent2 = CalculateTangent(jTanComponent, p1.Y, p2.Y);
            float tangent3 = CalculateTangent(kTanComponent, p1.Z, p2.Z);
            float tangent4 = CalculateTangent(wTanComponent, p1.W, p2.W);
            double num1 = (double)tangent2;
            double num2 = (double)tangent3;
            double num3 = (double)tangent4;
            return new Quaternion((float)tangent1, (float)num1, (float)num2, (float)num3);
        }

        protected RealPoint3d CalculateTangent(
          int xTanComponent,
          int yTanComponent,
          int zTanComponent,
          RealPoint3d p1,
          RealPoint3d p2)
        {
            float tangent1 = CalculateTangent(xTanComponent, p1.X, p2.X);
            float tangent2 = CalculateTangent(yTanComponent, p1.Y, p2.Y);
            float tangent3 = CalculateTangent(zTanComponent, p1.Z, p2.Z);
            return new RealPoint3d(tangent1, tangent2, tangent3);
        }

        protected float CalculateCurvePosition(
          float time,
          float tan1,
          float tan2,
          float p1,
          float p2)
        {
            double num1 = 2.0 * Math.Pow((double)time, 3.0) - 3.0 * Math.Pow((double)time, 2.0) + 1.0;
            float num2 = (float)Math.Pow((double)time, 3.0) - (float)(2.0 * Math.Pow((double)time, 2.0)) + time;
            float num3 = (float)(3.0 * Math.Pow((double)time, 2.0) - 2.0 * Math.Pow((double)time, 3.0));
            float num4 = (float)Math.Pow((double)time, 3.0) - (float)Math.Pow((double)time, 2.0);
            double num5 = (double)p1;
            return (float)(num1 * num5 + (double)num2 * (double)tan1 + (double)num3 * (double)p2 + (double)num4 * (double)tan2);
        }

        protected Quaternion CalculateCurvePosition(
          float time,
          Quaternion tan1,
          Quaternion tan2,
          Quaternion p1,
          Quaternion p2)
        {
            float curvePosition1 = CalculateCurvePosition(time, tan1.X, tan2.X, p1.X, p2.X);
            float curvePosition2 = CalculateCurvePosition(time, tan1.Y, tan2.Y, p1.Y, p2.Y);
            float curvePosition3 = CalculateCurvePosition(time, tan1.Z, tan2.Z, p1.Z, p2.Z);
            float curvePosition4 = CalculateCurvePosition(time, tan1.W, tan2.W, p1.W, p2.W);
            return new Quaternion(curvePosition1, curvePosition2, curvePosition3, curvePosition4);
        }

        protected RealPoint3d CalculateCurvePosition(
          float time,
          RealPoint3d tan1,
          RealPoint3d tan2,
          RealPoint3d p1,
          RealPoint3d p2)
        {
            float curvePosition1 = CalculateCurvePosition(time, tan1.X, tan2.X, p1.X, p2.X);
            float curvePosition2 = CalculateCurvePosition(time, tan1.Y, tan2.Y, p1.Y, p2.Y);
            float curvePosition3 = CalculateCurvePosition(time, tan1.Z, tan2.Z, p1.Z, p2.Z);
            return new RealPoint3d(curvePosition1, curvePosition2, curvePosition3);
        }
    }
}
