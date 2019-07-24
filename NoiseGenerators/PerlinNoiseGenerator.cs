using LibNoise;
using LibNoise.Primitive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiseGenerators
{
    public class PerlinNoiseGenerator : INoiseGenerator
    {
        public INoiseMap<float> GenerateMap(int mapWidth = 512, int mapHeight = 512, float scale = 1, int seed = 0)
        {
            if (mapWidth <= 0) throw new ArgumentException("mapWidth should be greater than 0");
            if (mapHeight <= 0) throw new ArgumentException("mapHeight should be greater than 0");
            if (scale <= 0) throw new ArgumentException("scale should be greater than 0");

            var perlineNoiseSource = new SimplexPerlin
            {
                Seed = seed,
                Quality = NoiseQuality.Fast
            };

            var noiseMap = new float[mapWidth, mapHeight];
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    var sampleX = x / scale;
                    var sampleY = y / scale;

                    var perlinValue = perlineNoiseSource.GetValue(sampleX, sampleY);
                    noiseMap[x, y] = perlinValue;
                }
            }
            return new NoiseMap(MapWidth: mapWidth, MapHeight: mapHeight, Data: noiseMap);
        }
    }
}
