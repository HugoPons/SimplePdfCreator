using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PdfMerge
{
    class Program
    {
        static void Main(string[] args)
        {
            string file1 = @"C:\Users\administrateur\Documents\hugo\tests pdf\testsmerge\pdf-A2.pdf";
            string file2 = @"C:\Users\administrateur\Documents\hugo\tests pdf\testsmerge\doc_simple.pdf";
            string file3 = @"C:\Users\administrateur\Documents\hugo\tests pdf\testsmerge\pdf-A5.pdf";
            string[] files = new string[] { file1, file2, file3 };
            PdfMerger.MergePdf(files, @"C:\Users\administrateur\Documents\hugo\tests pdf\testsmerge\merged_pdf.pdf");
        }
    }
}
