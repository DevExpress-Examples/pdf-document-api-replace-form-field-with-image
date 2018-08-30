using System.Drawing;
using DevExpress.Pdf;

namespace ReplaceFormFieldWithImage {
    class Program {
        static void Main(string[] args) {

            using (PdfDocumentProcessor processor = new PdfDocumentProcessor()) {

                // Load a PDF document with AcroForm data. 
                processor.LoadDocument("..\\..\\InteractiveForm.pdf");

                foreach (PdfInteractiveFormField field in processor.Document.AcroForm.Fields) {

                    if (field.Name == "Address") {

                        PdfRectangle cropBox = field.Widget.Page.CropBox;
                        PdfRectangle rect = field.Widget.Rect;

                        double x = rect.Left - cropBox.Left;
                        double y = cropBox.Top - rect.Bottom;

                        // Create graphics and draw an image.
                        using (PdfGraphics graphics = processor.CreateGraphics()) {
                            DrawImage(graphics, rect, x, y);

                            graphics.AddToPageForeground(processor.Document.Pages[0], 72, 72);
                        }
                    }
                }
                processor.RemoveFormField("Address");
                processor.SaveDocument("..\\..\\Result.pdf");
            }
        }

        static void DrawImage(PdfGraphics graphics, PdfRectangle rect, double x, double y) {

            Bitmap image = new Bitmap("..\\..\\AddressFormField.png");

            double aspectRatio = image.Width / image.Height;

            double scaleX = image.Width / rect.Width;
            double scaleY = image.Height / rect.Height;

            double width;
            double height;

            if (scaleX < scaleY) {

                width = rect.Width;
                height = width / aspectRatio;
            }

            else {
                height = rect.Height;
                width = height * aspectRatio;
            }

            RectangleF imageRect = new RectangleF((float)x, (float)(y - height), (float)width, (float)height);
            graphics.DrawImage(image, imageRect);
        }
    }
}