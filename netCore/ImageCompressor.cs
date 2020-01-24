using System;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.Primitives;
using System.IO;
using SixLabors.ImageSharp.Formats.Jpeg;

namespace cli1
{
    class ImageCompressor
    {

        #region Constants
        private const double ImageDimensionWidth = 1920.0;
        private const double ImageDimensionHeight = 1080.0;
        #endregion
        
        public void Compress(string[] inputFilenames)
        {

            foreach (string inputFilename in inputFilenames)
            {                
                using (Image image = Image.Load(inputFilename))
                {
                    string outputFilename = inputFilename.Insert(inputFilename.LastIndexOf('\\') + 1, "_");

                    var outputImageDimensions = GetOutputImageDimensions(image);
                    
                    image.Mutate(x => x
                       .Resize(outputImageDimensions.Width, outputImageDimensions.Height)                       
                    );

                    if (Path.GetExtension(inputFilename).ToLower() == ".jpg")
                    {
                        var jpgEncoderOptions = new JpegEncoder();
                        jpgEncoderOptions.Quality = 90;
                        image.Save(outputFilename, jpgEncoderOptions);
                    }
                    else
                    {
                        image.Save(outputFilename);
                    }
                    
                    Console.WriteLine("Picture resized: " + outputFilename);
                }              
            }
        }

        private Size GetOutputImageDimensions(Image inputImage)
        {
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

            return new Size(Convert.ToInt32(imageWidth), Convert.ToInt32(imageHeight));
        }
        

    }
}
