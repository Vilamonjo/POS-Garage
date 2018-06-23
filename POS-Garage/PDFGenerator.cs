using System;
using System.Collections.Generic;
using System.Linq;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf;

class PDFGenerator
{
    private PdfDocument pdf;
    private List<PdfPage> pages;
    private List<XGraphics> gfxs;

    public PDFGenerator()
    {
        pdf = new PdfDocument();
        pages = new List<PdfPage>();
        gfxs = new List<XGraphics>();
        pages.Add(pdf.AddPage());
        XGraphics gfx = XGraphics.FromPdfPage(pages.Last());
        gfxs.Add(gfx);
    }

    public void AddPage()
    {
        pages.Add(pdf.AddPage());
    }
    
    public void WriteAt(string text, int x, int y, int size)
    {
        XGraphics gfx = gfxs.Last();
        XFont font = new XFont("Verdana", size,XFontStyle.Italic);

        gfx.DrawString(text, font, XBrushes.Black, x, y);
    }

    public void DrawHoLine(int thickness, int y)
    {
        XGraphics gfx = gfxs.Last();
        PdfPage page = pages.Last();
        XPen pen = new XPen(XColors.DarkGray, thickness);
        gfx.DrawLine(pen, 0, y, page.Width, y);
    }

    public void DrawVeLine(int thickness, int x)
    {
        XGraphics gfx = gfxs.Last();
        PdfPage page = pages.Last();
        XPen pen = new XPen(XColors.DarkGray, thickness);
        gfx.DrawLine(pen, x, 0, x, page.Height );
    }

    public void SaveDocument(string fileName)
    {
        pdf.Save(fileName + ".pdf");
    }


}

