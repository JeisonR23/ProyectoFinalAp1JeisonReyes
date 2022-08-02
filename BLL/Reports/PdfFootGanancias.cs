using iTextSharp.text.pdf;
using iTextSharp.text;

public class PdfFootGanacias  : PdfPageEventHelper
 {

    private readonly Font _pageNumberFont = new Font (Font.NORMAL, 8f, Font.NORMAL);

    public override void OnEndPage(PdfWriter writer, Document document)
    {
        this.AddPageNumber (writer, document);
    }


    public void AddPageNumber(PdfWriter writer, Document document)
    {

        var numberTable = new PdfPTable(1);
        string text = "Page no : " + writer.PageNumber.ToString("00");
        string text1 = "Generated time: " + DateTime.Now.ToString("dddd/MMMM/YYYY");


        var pdfCell = new  PdfPCell (new Phrase(text, _pageNumberFont));
        pdfCell.HorizontalAlignment = Element.ALIGN_RIGHT;
        pdfCell.Border = 0;
       // pdfCell.BackgroundColor = BaseColor.White;
        numberTable.AddCell(pdfCell);
        numberTable.TotalWidth= 450;
        numberTable.WriteSelectedRows(0,-1,document.Left + 80 , document.Bottom + 10 , writer.DirectContent);

    }
}