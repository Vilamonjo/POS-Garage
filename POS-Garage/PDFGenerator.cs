using System.Collections.Generic;
using System.Linq;
using PdfSharp.Drawing;
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
        XFont font = new XFont("Times New Roman", size,XFontStyle.Regular);

        gfx.DrawString(text, font, XBrushes.Black, x, y);
    }

    public void DrawHoLine(int thickness, int y, int y2)
    {
        XGraphics gfx = gfxs.Last();
        PdfPage page = pages.Last();
        XPen pen = new XPen(XColors.DarkBlue, thickness);
        gfx.DrawLine(pen, 0, y, page.Width, y);
    }

    public void DrawLine(int thickness, int x, int y, int x2, int y2)
    {
        XGraphics gfx = gfxs.Last();
        PdfPage page = pages.Last();
        XPen pen = new XPen(XColors.DarkBlue, thickness);
        gfx.DrawLine(pen, x, y, x2, y2);
    }

    public void SaveDocument(string fileName)
    {
        pdf.Save(fileName + ".pdf");
    }


}

