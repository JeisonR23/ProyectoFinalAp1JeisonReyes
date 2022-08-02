using iTextSharp.text;
using iTextSharp.text.pdf;

public class RptResult : PdfFooterPart
{

    PdfWriter _PdfWriter;
    int maxColumn = 4;
    Document _document;
    PdfPTable _pdfPTable = new PdfPTable(8);
    PdfPCell _pdfPCell;
    Font _fontStyle;
    MemoryStream _memotyStream = new MemoryStream();



    public byte[] Report(List<Jugadas> jugadas)
    {
        // _jugadas = jugadas;
        _document = new Document(PageSize.NOTE, 10f, 10f, 20f, 30f);
        _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);

        _PdfWriter = PdfWriter.GetInstance(_document, _memotyStream);
        _PdfWriter.PageEvent = new PdfFooterPart();

        _document.Open();

        Paragraph titlePricipal = new Paragraph();
        titlePricipal.Font = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 14f);
        titlePricipal.Alignment = Element.ALIGN_CENTER;
        titlePricipal.Add("Lista De jugadas");
        titlePricipal.SpacingAfter = 5;
        _document.Add(titlePricipal);

        Font fonttabla = new Font(Font.TIMES_ROMAN, 12, Font.BOLD);
        Font font = new Font(Font.TIMES_ROMAN, 12, Font.NORMAL);

        //tabla detalle monto mensual
        PdfPTable tblLocal = new PdfPTable(3);
        tblLocal.WidthPercentage = 100;
        float[] widths = new float[] { 3f, 5f, 3f };
        tblLocal.SetWidths(widths);

        PdfPCell clId = new PdfPCell(new Phrase("Id", fonttabla));
        PdfPCell clFecha = new PdfPCell(new Phrase("Fecha", fonttabla));
        PdfPCell clMonto = new PdfPCell(new Phrase("Monto", fonttabla));
       

        tblLocal.AddCell(clId);
        tblLocal.AddCell(clFecha);
        tblLocal.AddCell(clMonto);
       

        PdfPCell cell = new PdfPCell();
        foreach (var _jugadas in jugadas)
        {
            cell = new PdfPCell(new Phrase(_jugadas.JugadaId.ToString(), font));
            tblLocal.AddCell(cell);
            cell = new PdfPCell(new Phrase(_jugadas.Fecha.ToString(), font));
            tblLocal.AddCell(cell);
            cell = new PdfPCell(new Phrase(_jugadas.Monto.ToString(), font));
            tblLocal.AddCell(cell);
        }

        _document.Add(tblLocal);

        this.OnEndPage(_PdfWriter, _document);
        _document.Close();

        return _memotyStream.ToArray();
    }


}