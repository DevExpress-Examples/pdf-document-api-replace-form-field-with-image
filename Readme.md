# How to replace a form field with an image

This example shows how to substitute a text form field with an image.

To accomplish this task it is necessary to remove a certain field with an annotation and substitute it with an image since widget annotations are drawn over the page content.

-	Obtain a required form field iterating through the <a href="https://documentation.devexpress.com/CoreLibraries/DevExpress.Pdf.PdfInteractiveFormField.class">PdfInteractiveFormField</a> collection. Use the <a href="https://documentation.devexpress.com/CoreLibraries/DevExpress.Pdf.PdfInteractiveForm.Fields.property">PdfInteractiveForm.Fields</a>  property to access this collection. To obtain the interactive form, use the <a href="https://documentation.devexpress.com/CoreLibraries/DevExpress.Pdf.PdfDocument.AcroForm.property">PdfDocument.AcroForm</a> property. The document can be accessed using the <a href="https://documentation.devexpress.com/OfficeFileAPI/DevExpress.Pdf.PdfDocumentProcessor.Document.property">PdfDocumentProcessor.Document</a> property.

-	Obtain the widget annotation using the <a href="https://documentation.devexpress.com/CoreLibraries/DevExpress.Pdf.PdfInteractiveFormField.Widget.property">PdfInteractiveFormField.Widget</a> property and get the annotation rectangle (defines the annotation location on the page) via the <a href="https://documentation.devexpress.com/CoreLibraries/DevExpress.Pdf.PdfAnnotation.Rect.property">PdfAnnotation.Rect</a> property. Note that this property is measured in default user space units. 

-	Use the <a href="https://documentation.devexpress.com/CoreLibraries/DevExpress.Pdf.PdfAnnotation.Page.property">PdfAnnotation.Page</a>  property to get the page with which the annotation is associated. After that obtain the page boundaries defined by the crop box in the <a href="https://documentation.devexpress.com/OfficeFileAPI/120032/PDF-Document-API/Coordinate-Systems">user coordinate system</a> using the <a href="https://documentation.devexpress.com/CoreLibraries/DevExpress.Pdf.PdfPageTreeObject.CropBox.property">PdfPageTreeObject.CropBox</a> property. 
-	To draw an image at the form field position on the page, use the <a href="https://documentation.devexpress.com/CoreLibraries/DevExpress.Pdf.PdfGraphics.DrawImage.method(RvMF4Q)">PdfGraphics.DrawImage</a>  overload method of the **PdfGraphics** class.

-	Add graphics to a page foreground by calling the <a href="https://documentation.devexpress.com/CoreLibraries/DevExpress.Pdf.PdfGraphics.AddToPageForeground.overloads">PdfGraphics.AddToPageForeground</a> overload method and pass 72 as a DPI value. This method automatically converts <a href="https://documentation.devexpress.com/OfficeFileAPI/120032/PDF-Document-API/Coordinate-Systems">world coordinates</a> to <a href="https://documentation.devexpress.com/OfficeFileAPI/120032/PDF-Document-API/Coordinate-Systems">page coordinates</a>. Passing 72 as a DPI value to this method allows transforming coordinates without any scaling. See <a href="https://documentation.devexpress.com/OfficeFileAPI/120032/PDF-Document-API/Coordinate-Systems">Coordinate Systems</a> for more details. 
-	Remove the form field calling the <a href="https://documentation.devexpress.com/OfficeFileAPI/DevExpress.Pdf.PdfDocumentProcessor.RemoveFormField.method">PdfDocumentProcessor.RemoveFormField</a> method. 
-	Save the resulting document calling the <a href="https://documentation.devexpress.com/OfficeFileAPI/DevExpress.Pdf.PdfDocumentProcessor.SaveDocument.overloadss">PdfDocumentProcessor.SaveDocument</a> overload method. 

<br/>


