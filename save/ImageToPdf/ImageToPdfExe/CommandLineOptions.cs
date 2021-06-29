using CommandLine;
using ImageToPdf;
using System;
using System.IO;

namespace ImageToPdfExe
{
    public class Options
    {
        [Option('o', "outputpath", Required = false, HelpText = "Définit le fichier de sortie.")]
        public string OutputFile { get; set; }

        [Option('i', "inputpath", Required = true, HelpText = "Définit le fichier d'entrée avec chemin d'accès total ou relatif.")]
        public string InputFile { get; set; }
    }

    public class CommandLineOptions
    {
        public static ConvertOptions ParseArgs(string[] args)
        {
            return Parser.Default.ParseArguments<Options>(args)
                .MapResult(o =>
                {
                    string inputFilePath = o.InputFile;
                    string outputFilePath = null;

                    if (string.IsNullOrEmpty(inputFilePath))
                        throw new ArgumentException("Veuillez ajouter un document en entrée, avec l'option -i");

                    if (!string.IsNullOrEmpty(o.OutputFile))
                    {
                        if (Directory.Exists(o.OutputFile))
                            outputFilePath = o.OutputFile + @"\" + Path.GetFileNameWithoutExtension(inputFilePath) + ".pdf";
                        else if (string.Equals(Path.GetExtension(o.OutputFile), ".pdf", StringComparison.InvariantCultureIgnoreCase))
                            outputFilePath = o.OutputFile;
                        else
                            throw new ArgumentException("Argument de fichier de sortie non conforme");
                    }
                    else
                    {
                        outputFilePath = Path.ChangeExtension(inputFilePath, ".pdf");
                    }

                    return new ConvertOptions(inputFilePath, outputFilePath);
                },
                (_) => null);
        }
    }
}
