using System;

namespace NoiseGenerators
{
    public class NoiseMap : INoiseMap<float>
    {
        private int mapWidth;
        private int mapHeight;
        private float[,] data;

        public NoiseMap(int MapWidth, int MapHeight, float[,] Data)
        {
            mapWidth = MapWidth;
            mapHeight = MapHeight;
            data = Data;
        }

        public float[,] Data()
        {
            return data;
        }

        public int Height()
        {
            return mapHeight;
        }

        public int Width()
        {
            return mapWidth;
        }
    }
}
