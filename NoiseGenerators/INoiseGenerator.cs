using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiseGenerators
{
    public interface INoiseGenerator
    {
        INoiseMap<float> GenerateMap(int width, int height, float scale = 1f, int seed = 0);
    }
}
