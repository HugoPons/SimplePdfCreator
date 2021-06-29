using System;
using System.IO;

namespace ImageToPdf
{
    public class ConvertOptions
    {
        public string InputFilePath { get; private set; }

        public string OutputFilePath { get; private set; }

        public string FileExtension { get; private set; }

        public ConvertOptions(string inputFilePath, string outputFilePath)
        {
            if (string.IsNullOrEmpty(inputFilePath) || string.IsNullOrEmpty(outputFilePath))
            {
                throw new ArgumentException("Impossible d'obtenir les <option> sont incomplets");
            }

            if (!File.Exists(inputFilePath))
            {
                throw new ArgumentException("Fichier d'entrée inexistant");
            }

            InputFilePath = inputFilePath;
            OutputFilePath = outputFilePath;
            FileExtension = Path.GetExtension(InputFilePath);

            if (string.IsNullOrEmpty(FileExtension))
            {
                throw new ArgumentException("Format du fichier d'entree non conforme");
            }
        }
    }
}
