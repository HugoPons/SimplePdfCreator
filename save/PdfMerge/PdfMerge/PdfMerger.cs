using Syncfusion.Pdf;
using System.IO;

namespace PdfMerge
{
    public static class PdfMerger
    {
        public static void MergePdf(string[] filePaths, string outputNamePath)
        {
            using (PdfDocument finalDoc = new PdfDocument())
            {
                // Merges PDFDocument.

                PdfDocument.Merge(finalDoc, filePaths);

                //Saves the final document

                finalDoc.Save(outputNamePath);

                //Closes the document

                finalDoc.Close(true);
            }
        }

        public static void MergePdf(Stream[] fileStreams, string outputNamePath)
        {
            using (PdfDocument finalDoc = new PdfDocument())
            {
                // Merges PDFDocument.
                PdfDocumentBase.Merge(finalDoc, fileStreams);

                //Saves the document
                finalDoc.Save(outputNamePath);

                //Closes the document
                finalDoc.Close(true);

                //Disposes the streams
                foreach(var stream in fileStreams)
                {
                    stream.Dispose();
                }
            }
        }
    }
}
