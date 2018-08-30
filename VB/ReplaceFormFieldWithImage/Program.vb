Imports System.Drawing
Imports DevExpress.Pdf

Namespace ReplaceFormFieldWithImage
    Friend Class Program
        Shared Sub Main(ByVal args() As String)

            Using processor As New PdfDocumentProcessor()

                ' Load a PDF document with AcroForm data. 
                processor.LoadDocument("..\..\InteractiveForm.pdf")

                For Each field As PdfInteractiveFormField In processor.Document.AcroForm.Fields

                    If field.Name = "Address" Then

                        Dim cropBox As PdfRectangle = field.Widget.Page.CropBox
                        Dim rect As PdfRectangle = field.Widget.Rect

                        Dim x As Double = rect.Left - cropBox.Left
                        Dim y As Double = cropBox.Top - rect.Bottom

                        ' Create graphics and draw an image.
                        Using graphics As PdfGraphics = processor.CreateGraphics()
                            DrawImage(graphics, rect, x, y)

                            graphics.AddToPageForeground(processor.Document.Pages(0), 72, 72)
                        End Using
                    End If
                Next field
                processor.RemoveFormField("Address")
                processor.SaveDocument("..\..\Result.pdf")
            End Using
        End Sub

        Private Shared Sub DrawImage(ByVal graphics As PdfGraphics, ByVal rect As PdfRectangle, ByVal x As Double, ByVal y As Double)

            Dim image As New Bitmap("..\..\AddressFormField.png")

            Dim aspectRatio As Double = image.Width \ image.Height

            Dim scaleX As Double = image.Width \ rect.Width
            Dim scaleY As Double = image.Height \ rect.Height

            Dim width As Double
            Dim height As Double

            If scaleX < scaleY Then

                width = rect.Width
                height = width / aspectRatio

            Else
                height = rect.Height
                width = height * aspectRatio
            End If

            Dim imageRect As New RectangleF(CSng(x), CSng(y - height), CSng(width), CSng(height))
            graphics.DrawImage(image, imageRect)
        End Sub
    End Class
End Namespace