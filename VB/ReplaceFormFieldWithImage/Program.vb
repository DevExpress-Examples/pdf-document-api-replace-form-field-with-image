Imports System.Drawing
Imports DevExpress.Pdf

Namespace ReplaceFormFieldWithImage

    Friend Class Program

        Shared Sub Main(ByVal args As String())
            Const dpix As Single = 72F
            Const dpiY As Single = 72F
            Using processor As PdfDocumentProcessor = New PdfDocumentProcessor()
                ' Load a PDF document with AcroForm data. 
                processor.LoadDocument("..\..\InteractiveForm.pdf")
                Dim documentFacade As PdfDocumentFacade = processor.DocumentFacade
                Dim acroForm As PdfAcroFormFacade = documentFacade.AcroForm
                Dim fieldName As String = "Address"
                Dim formField As PdfTextFormFieldFacade = TryCast(acroForm.GetFormField(fieldName), PdfTextFormFieldFacade)
                If formField Is Nothing Then Return
                For Each widget As PdfWidgetFacade In formField
                    Dim rect As PdfRectangle = widget.Rectangle
                    Dim page As PdfPage = processor.Document.Pages(widget.PageNumber - 1)
                    Dim x As Double = rect.Left - page.CropBox.Left
                    Dim y As Double = page.CropBox.Top - rect.Bottom
                    ' Create graphics and draw an image.
                    Using graphics As PdfGraphics = processor.CreateGraphics()
                        DrawImage(graphics, rect, x, y)
                        graphics.AddToPageForeground(page, dpix, dpiY)
                    End Using
                Next

                processor.RemoveFormField(fieldName)
                processor.SaveDocument("..\..\Result.pdf")
            End Using
        End Sub

        Private Shared Sub DrawImage(ByVal graphics As PdfGraphics, ByVal rect As PdfRectangle, ByVal x As Double, ByVal y As Double)
            Dim image As Bitmap = New Bitmap("..\..\AddressFormField.png")
            Dim aspectRatio As Double = image.Width \ image.Height
            Dim scaleX As Double = image.Width / rect.Width
            Dim scaleY As Double = image.Height / rect.Height
            Dim width As Double
            Dim height As Double
            If scaleX < scaleY Then
                width = rect.Width
                height = width / aspectRatio
            Else
                height = rect.Height
                width = height * aspectRatio
            End If

            Dim imageRect As RectangleF = New RectangleF(CSng(x), CSng(y - height), CSng(width), CSng(height))
            graphics.DrawImage(image, imageRect)
        End Sub
    End Class
End Namespace
