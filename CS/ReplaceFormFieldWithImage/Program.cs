using System.Drawing;
using DevExpress.Pdf;

namespace ReplaceFormFieldWithImage {
    class Program {
        static void Main(string[] args)
        {
            const float dpix = 72f;
            const float dpiY = 72f;
            using (PdfDocumentProcessor processor = new PdfDocumentProcessor())
            {

                // Load a PDF document with AcroForm data. 
                processor.LoadDocument("..\\..\\InteractiveForm.pdf");
                PdfDocumentFacade documentFacade = processor.DocumentFacade;
                PdfAcroFormFacade acroForm = documentFacade.AcroForm;
                string fieldName = "Address";
                PdfTextFormFieldFacade formField = acroForm.GetFormField(fieldName) as PdfTextFormFieldFacade;
                if (formField == null) return;

                foreach (PdfWidgetFacade widget in formField)
                {
                    PdfRectangle rect = widget.Rectangle;
                    PdfPage page = processor.Document.Pages[widget.PageNumber - 1];
                    double x = rect.Left - page.CropBox.Left;
                    double y = page.CropBox.Top - rect.Bottom;

                    // Create graphics and draw an image.
                    using (PdfGraphics graphics = processor.CreateGraphics())
                    {
                        DrawImage(graphics, rect, x, y);

                        graphics.AddToPageForeground(page, dpix, dpiY);
                    }


                }
                processor.RemoveFormField(fieldName);
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