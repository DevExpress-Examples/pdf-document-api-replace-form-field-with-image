<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/146724242/18.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T830535)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# How to replace a form field with an image

This example shows how to substitute a text form field with an image.

To accomplish this task, remove a field with an annotation and substitute it with an image since widget annotations are drawn over the page content.

*   Obtain a required form field by iterating through the [`PdfInteractiveFormField`](https://documentation.devexpress.com/CoreLibraries/DevExpress.Pdf.PdfInteractiveFormField.class) collection.  
    Use the [`PdfInteractiveForm.Fields`](https://documentation.devexpress.com/CoreLibraries/DevExpress.Pdf.PdfInteractiveForm.Fields.property) property to access this collection.  
    To obtain the interactive form, use the [`PdfDocument.AcroForm`](https://documentation.devexpress.com/CoreLibraries/DevExpress.Pdf.PdfDocument.AcroForm.property) property.  
    The document can be accessed using the [`PdfDocumentProcessor.Document`](https://documentation.devexpress.com/OfficeFileAPI/DevExpress.Pdf.PdfDocumentProcessor.Document.property) property.

*   Obtain the widget annotation using the [`PdfInteractiveFormField.Widget`](https://documentation.devexpress.com/CoreLibraries/DevExpress.Pdf.PdfInteractiveFormField.Widget.property) property and get the annotation rectangle (defines the annotation location on the page) via the [`PdfAnnotation.Rect`](https://documentation.devexpress.com/CoreLibraries/DevExpress.Pdf.PdfAnnotation.Rect.property) property.  
    Note that this property is measured in default user space units.

*   Use the [`PdfAnnotation.Page`](https://documentation.devexpress.com/CoreLibraries/DevExpress.Pdf.PdfAnnotation.Page.property) property to get the page with which the annotation is associated.  
    After that, obtain the page boundaries defined by the crop box in the user coordinate system using the [`PdfPageTreeObject.CropBox`](https://documentation.devexpress.com/CoreLibraries/DevExpress.Pdf.PdfPageTreeObject.CropBox.property) property.

*   To draw an image at the form field position on the page, use the [`PdfGraphics.DrawImage`](https://documentation.devexpress.com/CoreLibraries/DevExpress.Pdf.PdfGraphics.DrawImage.method\(RvMF4Q\)) overload method of the **PdfGraphics** class.

*   Add graphics to the page foreground by calling the [`PdfGraphics.AddToPageForeground`](https://documentation.devexpress.com/CoreLibraries/DevExpress.Pdf.PdfGraphics.AddToPageForeground.overloads) overload method and pass `72` as the DPI value.  
    This method automatically converts world coordinates to page coordinates.  
    Passing `72` ensures no scaling occurs during transformation.  
    See [Coordinate Systems](https://documentation.devexpress.com/OfficeFileAPI/120032/PDF-Document-API/Coordinate-Systems) for more details.

*   Remove the form field by calling the [`PdfDocumentProcessor.RemoveFormField`](https://documentation.devexpress.com/OfficeFileAPI/DevExpress.Pdf.PdfDocumentProcessor.RemoveFormField.method) method.
*   Save the resulting document by calling the [`PdfDocumentProcessor.SaveDocument`](https://documentation.devexpress.com/OfficeFileAPI/DevExpress.Pdf.PdfDocumentProcessor.SaveDocument.overloads) method.


<!-- feedback -->
## Does This Example Address Your Development Requirements/Objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=pdf-document-api-replace-form-field-with-image&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=pdf-document-api-replace-form-field-with-image&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
