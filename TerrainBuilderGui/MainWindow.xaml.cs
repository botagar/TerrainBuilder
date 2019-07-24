using NoiseGenerators;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TerrainBuilderGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        INoiseGenerator perlineNoiseGenerator;

        public MainWindow()
        {
            InitializeComponent();
            perlineNoiseGenerator = new PerlinNoiseGenerator();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Title = Seed.Text;
            int seed = Convert.ToInt32(Seed.Text);
            float scale = (float)Convert.ToDouble(Scale.Text);
            var noiseMap = perlineNoiseGenerator.GenerateMap(256, 256, scale, seed);

            NoiseMapDisplay.Width = noiseMap.Width();
            NoiseMapDisplay.Height = noiseMap.Height();

            var rawImageData = ScaleArray(noiseMap.Data(),0,255);
            var imageBuffer = MapToByteArray(rawImageData);
            
            var bitmapSource = BitmapSource.Create(256, 256, 72, 72, PixelFormats.Indexed8, BitmapPalettes.Gray256, imageBuffer, 256);
            NoiseMapDisplay.Source = bitmapSource;

        }

        private float[,] ScaleArray(float[,] array, float desiredMin, float desiredMax)
        {
            var outArray = new float[256, 256];
            float m = (desiredMax - desiredMin) / (1 - -1);
            float c = (desiredMin - -1) * m;
            for (int x=0; x<256; x++)
            {
                for (int y=0; y<256; y++)
                {
                    outArray[x,y] = m * array[x,y] + c;
                }
            }
            return outArray;
        }

        private byte[] MapToByteArray(float[,] array)
        {
            var arrayWidth = array.GetLength(0);
            var arrayHeight = array.GetLength(1);
            var outArray = new byte[arrayWidth* arrayHeight];

            for (int x = 0; x < arrayWidth; x++)
            {
                for (int y = 0; y < arrayHeight; y++)
                {
                    outArray[x * arrayWidth + y] = (byte)array[x, y];
                }
            }

            return outArray;
        }
    }
}
