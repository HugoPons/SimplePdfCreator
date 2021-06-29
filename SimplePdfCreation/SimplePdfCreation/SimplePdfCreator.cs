using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Drawing;
using System.Reflection;

namespace SimplePdfCreation
{
    class SimplePdfCreator
    {
        public enum Color
        {
            AliceBlue,
            PaleGoldenrod,
            Orchid,
            OrangeRed,
            Orange,
            OliveDrab,
            Olive,
            OldLace,
            Navy,
            NavajoWhite,
            Moccasin,
            MistyRose,
            MintCream,
            MidnightBlue,
            MediumVioletRed,
            MediumTurquoise,
            MediumSpringGreen,
            MediumSlateBlue,
            LightSkyBlue,
            LightSlateGray,
            LightSteelBlue,
            LightYellow,
            Lime,
            LimeGreen,
            PaleGreen,
            Linen,
            Maroon,
            MediumAquamarine,
            MediumBlue,
            MediumOrchid,
            MediumPurple,
            MediumSeaGreen,
            Magenta,
            PaleTurquoise,
            PaleVioletRed,
            PapayaWhip,
            SlateGray,
            Snow,
            SpringGreen,
            SteelBlue,
            Tan,
            Teal,
            SlateBlue,
            Thistle,
            Transparent,
            Turquoise,
            Violet,
            Wheat,
            White,
            WhiteSmoke,
            Tomato,
            LightSeaGreen,
            SkyBlue,
            Sienna,
            PeachPuff,
            Peru,
            Pink,
            Plum,
            PowderBlue,
            Purple,
            Silver,
            Red,
            RoyalBlue,
            SaddleBrown,
            Salmon,
            SandyBrown,
            SeaGreen,
            SeaShell,
            RosyBrown,
            Yellow,
            LightSalmon,
            LightGreen,
            DarkRed,
            DarkOrchid,
            DarkOrange,
            DarkOliveGreen,
            DarkMagenta,
            DarkKhaki,
            DarkGreen,
            DarkGray,
            DarkGoldenrod,
            DarkCyan,
            DarkBlue,
            Cyan,
            Crimson,
            Cornsilk,
            CornflowerBlue,
            Coral,
            Chocolate,
            AntiqueWhite,
            Aqua,
            Aquamarine,
            Azure,
            Beige,
            Bisque,
            DarkSalmon,
            Black,
            Blue,
            BlueViolet,
            Brown,
            BurlyWood,
            CadetBlue,
            Chartreuse,
            BlanchedAlmond,
            DarkSeaGreen,
            DarkSlateBlue,
            DarkSlateGray,
            HotPink,
            IndianRed,
            Indigo,
            Ivory,
            Khaki,
            Lavender,
            Honeydew,
            LavenderBlush,
            LemonChiffon,
            LightBlue,
            LightCoral,
            LightCyan,
            LightGoldenrodYellow,
            LightGray,
            LawnGreen,
            LightPink,
            GreenYellow,
            Gray,
            DarkTurquoise,
            DarkViolet,
            DeepPink,
            DeepSkyBlue,
            DimGray,
            DodgerBlue,
            Green,
            Firebrick,
            ForestGreen,
            Fuchsia,
            Gainsboro,
            GhostWhite,
            Gold,
            Goldenrod,
            FloralWhite,
            YellowGreen
        }
        private Color BackgroundColor { get; set; }

        private bool ColorIsSet { get; set; } = false;

        private int PageWidth { get; set; } = 595;

        private int PageHeight { get; set; } = 842;

        private string OutputPath { get; set; }

        private string PicturePath { get; set; } = "";

        private int[] PicturePos { get; set; } = { 0, 0 };

        private void DrawBackgroundColor(PdfPage page)
        {
            //set the page marign            
            RectangleF bounds = new RectangleF(0, 0, PageWidth, PageHeight);
            //Draw page background color using rectangle
            page.Graphics.DrawRectangle((PdfBrush)typeof(PdfBrushes).GetProperty(BackgroundColor.ToString()).GetValue(null), bounds);
        }
        public void DrawText(PdfGraphics graphics)
        {
            //Set the standard font.
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

            //Draw the text.
            graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new PointF(0, 0));
        }

        public void DrawImage(PdfGraphics graphics)
        {
            PdfBitmap image = new PdfBitmap(@PicturePath);

            float myWidth = image.Width;
            float myHeight = image.Height;

            float shrinkFactor;

            if (myWidth > PageWidth)
            {
                shrinkFactor = myWidth / PageWidth;
                myWidth = PageWidth;
                myHeight /= shrinkFactor;
            }

            if (myHeight > PageHeight)
            {
                shrinkFactor = myHeight / PageHeight;
                myHeight = PageHeight;
                myWidth /= shrinkFactor;
            }

            graphics.DrawImage(image, PicturePos[0], PicturePos[1], myWidth, myHeight);
        }

        public void DrawPdf()
        {
            PdfDocument doc = new PdfDocument();
            doc.PageSettings.Margins.All = 0;
            doc.PageSettings.Width = PageWidth;
            doc.PageSettings.Height = PageHeight;
            //Add a page to the document.
            PdfPage page = doc.Pages.Add();
            //Create PDF graphics for the page
            PdfGraphics graphics = page.Graphics;
            if (ColorIsSet)
            {
                DrawBackgroundColor(page);
            }
            if (!String.IsNullOrEmpty(PicturePath))
            {
                DrawImage(graphics);
            }
            DrawText(graphics);

            //Save the document.
            doc.Save(OutputPath);
            //Close the document.
            doc.Close(true);
        }

        public void AddImage(string filePath, int xPos, int yPos)
        {
            if (xPos <= 0 || yPos <= 0)
            {
                throw new ArgumentException("Une image ne peut pas avoir des coordonnées négatives");
            }
            PicturePath = filePath;
            PicturePos[0] = xPos;
            PicturePos[1] = yPos;
        }

        public void AddImage(string filePath)
        {
            PicturePath = filePath;
        }

        public void SetBackgroundColor(Color backgroundColor)
        {
            BackgroundColor = backgroundColor;
            ColorIsSet = true;
        }

        public void SetSize(int width, int height)
        {
            if(width <= 0 || height <= 0)
            {
                throw new ArgumentException("Impossible de créer un pdf avec une largeur ou une hauteur négative");
            }
            PageWidth = width;
            PageHeight = height;
        }

        public void SetToLandscape()
        {
            int widthTmp = PageWidth;
            PageWidth = PageHeight;
            PageHeight = widthTmp;
        }

        public SimplePdfCreator(string outputPath)
        {
            OutputPath = @outputPath;
        }
    }
}
