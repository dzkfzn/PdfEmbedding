using iTextSharp.text;
using iTextSharp.text.pdf;

// create a new PDF reader object
PdfReader reader = new PdfReader("existing.pdf");

// create a new PDF stamper object
PdfStamper stamper = new PdfStamper(reader, new FileStream("output.pdf", FileMode.Create));

// get the content byte stream for the first page
PdfContentByte cb = stamper.GetOverContent(1);

// add an image to the document at specific coordinates
Image image = Image.GetInstance("signature.png");
image.SetAbsolutePosition(100, 100); // set the X and Y coordinates
cb.AddImage(image);

// add text to the document at specific coordinates
ColumnText ct = new ColumnText(cb);
ct.SetSimpleColumn(new Rectangle(200, 200, 400, 400)); // set the rectangle for the text
Paragraph paragraph = new Paragraph("Hello, world!");
ct.AddElement(paragraph);
ct.Go();

// close the stamper
stamper.Close();
