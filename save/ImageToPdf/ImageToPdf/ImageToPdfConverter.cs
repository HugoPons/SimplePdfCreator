using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;

namespace ImageToPdf
{
    public static class ImageToPdfConverter
    {
        private static readonly string[] fileExtensions = new string[] { ".jpeg", ".tiff", ".bmp", ".gif", ".png", ".jpg", ".tif" };

        private static bool Match(string fileExtension, string ext)
        {
            return string.Equals(fileExtension, ext, StringComparison.InvariantCultureIgnoreCase);
        }

        private static bool ExtensionIsSupported(ConvertOptions convertOptions)
        {
            bool isSupported = false;
            foreach (var suppExtension in fileExtensions)
            {
                if (Match(convertOptions.FileExtension, suppExtension))
                {
                    isSupported = true;
                }
            }
            return isSupported;
        }

        public static void ConvertToPdf(ConvertOptions convertOptions)
        {
            if (!ExtensionIsSupported(convertOptions))
            {
                throw new ArgumentException("L'extension du fichier n'est pas prise en compte par le convertisseur");
            }

            //Create a new PDF document
            using (PdfDocument doc = new PdfDocument())
            {
                //Add a page to the document
                PdfPage page = doc.Pages.Add();
                //Create PDF graphics for the page
                PdfGraphics graphics = page.Graphics;
                //Load the image from the disk
                PdfBitmap image = new PdfBitmap(convertOptions.InputFilePath);

                float PageWidth = page.Graphics.ClientSize.Width;
                float PageHeight = page.Graphics.ClientSize.Height;
                float myWidth = image.Width;
                float myHeight = image.Height;

                float shrinkFactor;

                if (myWidth > PageWidth)
                {
                    shrinkFactor = myWidth / PageWidth;
                    myWidth = PageWidth;
                    myHeight = myHeight / shrinkFactor;
                }

                if (myHeight > PageHeight)
                {
                    shrinkFactor = myHeight / PageHeight;
                    myHeight = PageHeight;
                    myWidth = myWidth / shrinkFactor;
                }

                //Draw the image
                graphics.DrawImage(image, 0, 0, myWidth, myHeight);
                //Save the document
                doc.Save(convertOptions.OutputFilePath);
                //Close the document
                doc.Close(true);
            }           
        }
    }
}
