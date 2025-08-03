using System;
using System.Runtime.CompilerServices;

namespace TagTool.Bitmaps.Utils
{
    // Based on the implementation in NVTT. Optimization for single color blocks
    public class SingleColorLookup
    {
        public static byte[,] OMatch5 = new byte[256, 2];
        public static byte[,] OMatch6 = new byte[256, 2];
        public static byte[,] OMatchAlpha5 = new byte[256, 2];
        public static byte[,] OMatchAlpha6 = new byte[256, 2];

        static SingleColorLookup()
        {
            InitSingleColorLookup();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static int Lerp13(int a, int b)
        {
            return (a * 2 + b + 1) / 3;
        }

        private static void PrepareOptTable(byte[,] table, byte[] expand, int size, bool alphaMode)
        {
            for (int i = 0; i < 256; i++)
            {
                int bestErr = 256 * 100;

                for (int min = 0; min < size; min++)
                {
                    for (int max = 0; max < size; max++)
                    {
                        int mine = expand[min];
                        int maxe = expand[max];

                        int err = alphaMode ? Math.Abs((maxe + mine) / 2 - i) : Math.Abs(Lerp13(maxe, mine) - i);
                        err *= 100;

                        // DX10 spec error term
                        err += Math.Abs(max - min) * 3;

                        if (err < bestErr)
                        {
                            table[i, 0] = (byte)max;
                            table[i, 1] = (byte)min;
                            bestErr = err;
                        }
                    }
                }
            }
        }

        public static void InitSingleColorLookup()
        {
            byte[] expand5 = new byte[32];
            byte[] expand6 = new byte[64];

            for (int i = 0; i < 32; i++)
            {
                expand5[i] = (byte)((i << 3) | (i >> 2));
            }

            for (int i = 0; i < 64; i++)
            {
                expand6[i] = (byte)((i << 2) | (i >> 4));
            }

            PrepareOptTable(OMatch5, expand5, 32, false);
            PrepareOptTable(OMatch6, expand6, 64, false);
            PrepareOptTable(OMatchAlpha5, expand5, 32, true);
            PrepareOptTable(OMatchAlpha6, expand6, 64, true);
        }
    }
}
