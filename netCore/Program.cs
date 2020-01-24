using System;
using McMaster.Extensions.CommandLineUtils;

namespace cli1
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new CommandLineApplication<Program>(throwOnUnexpectedArg: false);

            var imageCompressor = new ImageCompressor();

            imageCompressor.Compress(args);


            Console.WriteLine();
            Console.WriteLine("********************************************************");
            Console.WriteLine("Press any key to close.");
            Console.ReadKey();
        }
    }
}
