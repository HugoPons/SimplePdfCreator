using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplePdfCreation
{
    class Program
    {
        static void Main(string[] args)
        {
            var pdfCreator = new SimplePdfCreator(@"C:\Users\administrateur\Documents\hugo\testcreationpdf\test.pdf");
            pdfCreator.SetBackgroundColor(SimplePdfCreator.Color.Blue);
            pdfCreator.SetSize(1000, 700);
            pdfCreator.AddImage(@"C:\Users\administrateur\Documents\hugo\testcreationpdf\test_images\img_jpg.jpg");
            pdfCreator.DrawPdf();

        }
    }
}
