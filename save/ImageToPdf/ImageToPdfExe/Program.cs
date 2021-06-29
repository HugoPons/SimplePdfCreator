using ImageToPdf;
using System;

namespace ImageToPdfExe
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var convertOptions = CommandLineOptions.ParseArgs(args);
                if (null == convertOptions) return;

                Console.WriteLine("Fichier d'entrée : {0}", convertOptions.InputFilePath);
                Console.WriteLine("Conversion vers --> {0}\n", convertOptions.OutputFilePath);

                Console.WriteLine("================= Début de la conversion =================\n");

                ImageToPdfConverter.ConvertToPdf(convertOptions);
                Console.WriteLine("=================  Conversion terminée   =================\n");
            }
            catch (Exception exc)
            {
                Console.WriteLine("Conversion interrompue par exception : " + exc.Message);
                Console.WriteLine("=================  Conversion terminée: Echec ==============\n");
            }
        }
    }
}
