using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyImageCompressor
{    
    internal class Program
    {
        
        #region Constants
        private const double ImageDimensionWidth = 1920.0;
        private const double ImageDimensionHeight = 1080.0;
        #endregion

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("This utility compresses JPEG image files supplied as parameters.");
                Console.WriteLine("New compressed files will be placed in the original directory having '_' sign as a prefix.");
            }            

            foreach (string inputFilename in args)
            {
                Image inputImage = (Image)null;
                try
                {
                    inputImage = Image.FromFile(inputFilename);
                    string outputFilename = inputFilename.Insert(inputFilename.LastIndexOf('\\') + 1, "_");
                    double imageHeight = (double)inputImage.Height;
                    double imageWidth = (double)inputImage.Width;
                    if (imageWidth > ImageDimensionWidth)
                    {
                        double ratio = ImageDimensionWidth / imageWidth;
                        imageWidth = ImageDimensionWidth;
                        imageHeight *= ratio;
                    }
                    if (imageHeight > ImageDimensionHeight)
                    {
                        double ratio = ImageDimensionHeight / imageHeight;
                        imageHeight = ImageDimensionHeight;
                        imageWidth *= ratio;
                    }

                    using (Image outputImage = (Image)new Bitmap((int)imageWidth, (int)imageHeight))
                    {
                        using (Graphics graphics = Graphics.FromImage(outputImage))
                        {
                            graphics.DrawImage(inputImage, 0, 0, (int)imageWidth, (int)imageHeight);
                        }
                        using (EncoderParameters encoderParams = new EncoderParameters(1))
                        {
                            encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 90L);
                            ImageCodecInfo encoder = ImageCodecInfo.GetImageEncoders()[1];
                            outputImage.Save(outputFilename, encoder, encoderParams);
                        }
                    }

                    Console.WriteLine("Picture resized: " + outputFilename);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Picture resize FAILED!!! " + inputFilename);
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    if (inputImage != null)
                        inputImage.Dispose();
                }
            }

            Console.WriteLine();
            Console.WriteLine("********************************************************");
            Console.WriteLine("Press any key to close.");
            Console.ReadKey();
        }
    }
}
