using System;
using NUnit.Framework;
using NoiseGenerators;
using System.Collections.Generic;
using Emgu.CV.UI;

namespace NoiseGeneratorsTests
{
    [TestFixture]
    public class PerlinNoiseGeneratorTest
    {
        INoiseGenerator perlinNoiseGenerator;
        INoiseMap<float> noiseMap;

        [SetUp]
        public void Setup()
        {
            perlinNoiseGenerator = new PerlinNoiseGenerator();
            noiseMap = perlinNoiseGenerator.GenerateMap(width: 512, height: 256, scale: 50f);
        }

        [Test]
        public void NoiseMapShouldHaveSetDimentions()
        {
            Assert.AreEqual(512, noiseMap.Width());
            Assert.AreEqual(256, noiseMap.Height());
        }

        [Test]
        public void NoiseMapShouldNotHaveExtremeGradientsInTheXAxis()
        {
            const float gradientThreshhold = 0.25f;

            for (int y=0; y<noiseMap.Height(); y++)
            {
                for (int x=0; x<noiseMap.Width() -1; x++)
                {
                    var val1 = noiseMap.Data()[x, y];
                    var val2 = noiseMap.Data()[x+1, y];
                    var gradient = Math.Abs(val1 - val2);
                    Assert.Less(gradient, gradientThreshhold);
                }
            }
        }
    }
}
