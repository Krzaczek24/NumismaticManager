using System;
using System.Collections.Generic;
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
        const int HEADER_FONT_SIZE = 16;
        const int FONT_SIZE = 12;
        const double TABLE_LINE_WIDTH = 1.5;
        const int DOC_MARGIN = 10;
        const int ROW_HEIGHT = 16;
        const int TOP_MARGIN = LEFT_MARGIN + HEADER_FONT_SIZE + 4;
        const double FIRST_TAB_PERCENT = 0.61;
        const double SECOND_TAB_PERCENT = 0.73;
        const double THIRD_TAB_PERCENT = 0.85;
        const double FOURTH_TAB_PERCENT = 0.93;
        const int TEXT_PADDING = 3;

        //Do not touch this section
        const int LEFT_MARGIN = DOC_MARGIN * 2;
        const int RIGHT_MARGIN = DOC_WIDTH - LEFT_MARGIN;
        const int REAL_WIDTH = RIGHT_MARGIN - LEFT_MARGIN;
        const int REAL_HEIGHT = DOC_HEIGHT - LEFT_MARGIN * 2;
        const int FIRST_TAB = (int)(REAL_WIDTH * FIRST_TAB_PERCENT) + LEFT_MARGIN;
        const int SECOND_TAB = (int)(REAL_WIDTH * SECOND_TAB_PERCENT) + LEFT_MARGIN;
        const int THIRD_TAB = (int)(REAL_WIDTH * THIRD_TAB_PERCENT) + LEFT_MARGIN;
        const int FOURTH_TAB = (int)(REAL_WIDTH * FOURTH_TAB_PERCENT) + LEFT_MARGIN;

        public static void GenerateDoc(string filePath, List<string> headers, List<Dictionary<string, object>> coins)
        {
            PdfDocument document = new PdfDocument();

            document.Info.Title = "Spis monet";

            PdfPage page = document.AddPage();

            XFont headerFont = new XFont("Calibri", HEADER_FONT_SIZE, XFontStyle.Regular, new XPdfFontOptions(PdfFontEncoding.Unicode));
            XFont font = new XFont("Calibri", FONT_SIZE, XFontStyle.Regular, new XPdfFontOptions(PdfFontEncoding.Unicode));

            XSolidBrush brush = XBrushes.Black;
            XPen pen = new XPen(XColor.FromKnownColor(KnownColor.DarkGray), TABLE_LINE_WIDTH);

            XGraphics gfx = XGraphics.FromPdfPage(page);

            //Horizontal lines
            gfx.DrawLine(pen, LEFT_MARGIN, LEFT_MARGIN, RIGHT_MARGIN, LEFT_MARGIN);
            gfx.DrawLine(pen, LEFT_MARGIN, TOP_MARGIN, RIGHT_MARGIN, TOP_MARGIN);

            //Vertical lines
            gfx.DrawLine(pen, LEFT_MARGIN, LEFT_MARGIN, LEFT_MARGIN, TOP_MARGIN);
            gfx.DrawLine(pen, FIRST_TAB, LEFT_MARGIN, FIRST_TAB, TOP_MARGIN);
            gfx.DrawLine(pen, SECOND_TAB, LEFT_MARGIN, SECOND_TAB, TOP_MARGIN);
            gfx.DrawLine(pen, THIRD_TAB, LEFT_MARGIN, THIRD_TAB, TOP_MARGIN);
            gfx.DrawLine(pen, FOURTH_TAB, LEFT_MARGIN, FOURTH_TAB, TOP_MARGIN);
            gfx.DrawLine(pen, RIGHT_MARGIN, LEFT_MARGIN, RIGHT_MARGIN, TOP_MARGIN);

            //Text
            XTextFormatter tx = new XTextFormatter(gfx) { Alignment = XParagraphAlignment.Center };
            tx.DrawString("Okoliczność wybicia monety", headerFont, brush, new XRect(new XPoint(LEFT_MARGIN + TEXT_PADDING, LEFT_MARGIN), new XPoint(FIRST_TAB - TEXT_PADDING, TOP_MARGIN)));
            tx.DrawString("Nominał", headerFont, brush, new XRect(new XPoint(FIRST_TAB + TEXT_PADDING, LEFT_MARGIN), new XPoint(SECOND_TAB - TEXT_PADDING, TOP_MARGIN)));
            tx.DrawString("Nakład", headerFont, brush, new XRect(new XPoint(SECOND_TAB + TEXT_PADDING, LEFT_MARGIN), new XPoint(THIRD_TAB - TEXT_PADDING, TOP_MARGIN)));
            tx.DrawString("Rok", headerFont, brush, new XRect(new XPoint(THIRD_TAB + TEXT_PADDING, LEFT_MARGIN), new XPoint(FOURTH_TAB - TEXT_PADDING, TOP_MARGIN)));
            tx.DrawString("Ilość", headerFont, brush, new XRect(new XPoint(FOURTH_TAB + TEXT_PADDING, LEFT_MARGIN), new XPoint(RIGHT_MARGIN - TEXT_PADDING, TOP_MARGIN)));

            int previousPosition = TOP_MARGIN;
            int currentPosition = TOP_MARGIN + ROW_HEIGHT;

            foreach (Dictionary<string, object> entry in coins)
            {
                //Horizontal line
                gfx.DrawLine(pen, LEFT_MARGIN, currentPosition, RIGHT_MARGIN, currentPosition);

                //Vertical lines
                gfx.DrawLine(pen, LEFT_MARGIN, previousPosition, LEFT_MARGIN, currentPosition);
                gfx.DrawLine(pen, FIRST_TAB, previousPosition, FIRST_TAB, currentPosition);
                gfx.DrawLine(pen, SECOND_TAB, previousPosition, SECOND_TAB, currentPosition);
                gfx.DrawLine(pen, THIRD_TAB, previousPosition, THIRD_TAB, currentPosition);
                gfx.DrawLine(pen, FOURTH_TAB, previousPosition, FOURTH_TAB, currentPosition);
                gfx.DrawLine(pen, RIGHT_MARGIN, previousPosition, RIGHT_MARGIN, currentPosition);

                //Text
                tx.Alignment = XParagraphAlignment.Left;
                tx.DrawString($"{entry["Name"]}", font, brush, new XRect(new XPoint(LEFT_MARGIN + TEXT_PADDING, previousPosition), new XPoint(FIRST_TAB - TEXT_PADDING, currentPosition)));

                tx.Alignment = XParagraphAlignment.Center;
                tx.DrawString($"{entry["Value"]:c0}", font, brush, new XRect(new XPoint(FIRST_TAB + TEXT_PADDING, previousPosition), new XPoint(SECOND_TAB - TEXT_PADDING, currentPosition)));

                tx.Alignment = XParagraphAlignment.Right;
                tx.DrawString($"{entry["Edition"]:n0}", font, brush, new XRect(new XPoint(SECOND_TAB + TEXT_PADDING, previousPosition), new XPoint(THIRD_TAB - TEXT_PADDING, currentPosition)));

                tx.Alignment = XParagraphAlignment.Center;
                tx.DrawString(DateTime.Parse($"{entry["Emission"]}").ToString("yyyy"), font, brush, new XRect(new XPoint(THIRD_TAB + TEXT_PADDING, previousPosition), new XPoint(FOURTH_TAB - TEXT_PADDING, currentPosition)));

                tx.Alignment = XParagraphAlignment.Right;
                tx.DrawString($"{entry["Amount"]}", font, brush, new XRect(new XPoint(FOURTH_TAB + TEXT_PADDING, previousPosition), new XPoint(RIGHT_MARGIN - TEXT_PADDING, currentPosition)));

                if (currentPosition >= REAL_HEIGHT)
                {
                    page = document.AddPage();
                    gfx = XGraphics.FromPdfPage(page);
                    tx = new XTextFormatter(gfx);
                    previousPosition = LEFT_MARGIN;
                    currentPosition = LEFT_MARGIN + ROW_HEIGHT;
                    gfx.DrawLine(pen, LEFT_MARGIN, previousPosition, RIGHT_MARGIN, previousPosition);
                }
                else
                {
                    previousPosition += ROW_HEIGHT;
                    currentPosition += ROW_HEIGHT;
                }
            }

            document.Save(filePath);
        }
    }
}
