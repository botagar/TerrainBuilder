using LibNoise;
using LibNoise.Primitive;
using System;

namespace TerrainBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var noiseSource = new SimplexPerlin
            {
                Seed = 0,
                Quality = NoiseQuality.Fast
            };

            var min = 0f;
            var max = 0f;
            for (int x = 0; x < 100; x++)
            {
                for (int z = 0; z < 100; z++)
                {
                    var val = noiseSource.GetValue(x, z);
                    if (val < min) min = val;
                    if (val > max) max = val;
                }
            }
            Console.Write(min + " " + max);

            Console.ReadKey();
        }
    }
}
