using System;
using System.Drawing;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;

namespace PDF
{
    public class PDFCreator
    {
        //Do not touch this section
        const int DOC_WIDTH = 595;
        const int DOC_HEIGHT = 842;

        //Edit this section
        const int DOC_MARGIN = 20;

        //Do not touch this section
        const int LEFT_MARGIN = DOC_MARGIN * 2;
        const int RIGHT_MARGIN = DOC_WIDTH - LEFT_MARGIN;
        const int REAL_WIDTH = RIGHT_MARGIN - LEFT_MARGIN;
        const int REAL_HEIGHT = DOC_HEIGHT - LEFT_MARGIN * 2;

        public static void GenerateDoc(string filePath)
        {
            try
            {
                using (PdfDocument document = new PdfDocument())
                {
                    document.Info.Title = "Spis monet okolicznościowych";

                    PdfPage page = document.AddPage();

                    XFont headerFont = new XFont("Calibri", 20, XFontStyle.Regular, new XPdfFontOptions(PdfFontEncoding.Unicode));
                    XFont font = new XFont("Calibri", 16, XFontStyle.Regular, new XPdfFontOptions(PdfFontEncoding.Unicode));

                    XSolidBrush brush = XBrushes.Black;

                    using (XGraphics gfx = XGraphics.FromPdfPage(page))
                    {
                        #region "ruler"
                        XPen rulerGridPen = new XPen(XColor.FromKnownColor(KnownColor.Gray), 0.5);

                        for (int i = 0; i < page.Width.Point; i += 10)
                        {
                            if (i % 100 == 0)
                            {
                                gfx.DrawLine(rulerGridPen, new XPoint(i, 0), new XPoint(i, page.Height.Point));
                            }
                            else
                            {
                                gfx.DrawLine(rulerGridPen, new XPoint(i, 0), new XPoint(i, 5));
                            }
                        }

                        for (int i = 0; i < page.Height.Point; i += 10)
                        {
                            if (i % 100 == 0)
                            {
                                gfx.DrawLine(rulerGridPen, new XPoint(0, i), new XPoint(page.Width.Point, i));
                            }
                            else
                            {
                                gfx.DrawLine(rulerGridPen, new XPoint(0, i), new XPoint(5, i));
                            }
                        }

                        rulerGridPen.Color = XColor.FromKnownColor(KnownColor.Red);
                        gfx.DrawRectangle(rulerGridPen, LEFT_MARGIN, LEFT_MARGIN, REAL_WIDTH, REAL_HEIGHT);
                        #endregion
                    }

                    document.Save(filePath);
                    System.Diagnostics.Process.Start(filePath);
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
