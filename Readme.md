<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/146724242/21.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T830535)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# PDF Document API - Replace a Form Field with an Image

This example shows how to substitute a text form field with an image.

To accomplish this task it is necessary to remove a certain field with an annotation and substitute it with an image since widget annotations are drawn over the page content.

- Use the [PdfAcroFormFacade.GetFormField](https://docs.devexpress.com/OfficeFileAPI/DevExpress.Pdf.PdfAcroFormFacade.GetFormField(System.String)) method to obtain a required form field. The [PdfDocumentFacade.AcroForm](https://docs.devexpress.com/OfficeFileAPI/DevExpress.Pdf.PdfDocumentFacade.AcroForm) property allows you to access the`PdfAcroFormFacade` object.

- Obtain the widget annotations using the [PdfFormFieldFacade<T, V>.Widgets](https://docs.devexpress.com/OfficeFileAPI/DevExpress.Pdf.PdfFormFieldFacade-2.Widgets) property and get the annotation rectangle (defines the annotation location on the page) via the [PdfWidgetFacade.Rectangle](https://docs.devexpress.com/OfficeFileAPI/DevExpress.Pdf.PdfWidgetFacade.Rectangle) property. Note that this property is measured in default user space units.

- Use the [PdfWidgetFacade.PageNumber](https://docs.devexpress.com/OfficeFileAPI/DevExpress.Pdf.PdfWidgetFacade.PageNumber) property to get the page where the annotation is located. After that obtain the page boundaries defined by the crop box in the [user coordinate system](https://docs.devexpress.com/OfficeFileAPI/120032/pdf-document-api/coordinate-systems#user-coordinate-system)) using the [PdfPageTreeObject.CropBox](https://docs.devexpress.com/CoreLibraries/DevExpress.Pdf.PdfPageTreeObject.CropBox) property.
- To draw an image at the form field position on the page, use the [PdfGraphics.DrawImage](https://docs.devexpress.com/OfficeFileAPI/DevExpress.Pdf.PdfGraphics.DrawImage.overloads)  overload method of the `PdfGraphics` class.

- Call the [PdfGraphics.AddToPageForeground](https://docs.devexpress.com/OfficeFileAPI/devexpress.pdf.pdfgraphics.addtopageforeground.overloads) overload to add graphics to a page foreground. This method automatically converts [world coordinates]([https://docs.devexpress.com/OfficeFileAPI/120032/pdf-document-api/coordinate-systems#world-coordinate-system](https://docs.devexpress.com/OfficeFileAPI/120032/pdf-document-api/coordinate-systems#page-coordinate-system) to [page coordinates](https://docs.devexpress.com/OfficeFileAPI/120032/pdf-document-api/coordinate-systems#page-coordinate-system). Pass `72` as a `dpi` parameter to this method to transform coordinates without any scaling.
- Call the [PdfDocumentProcessor.RemoveFormField](https://docs.devexpress.com/OfficeFileAPI/DevExpress.Pdf.PdfDocumentProcessor.RemoveFormField.method) method to remove the form field.
- Use the [PdfDocumentProcessor.SaveDocument](https://docs.devexpress.com/OfficeFileAPI/DevExpress.Pdf.PdfDocumentProcessor.SaveDocument.overloads)  method to save the resulting document.

## Files To Review

- [Program.cs](./CS/ReplaceFormFieldWithImage/Program.cs) (VB: [Program.vb](./VB/ReplaceFormFieldWithImage/Program.vb))

## Documentation

- [Coordinate Systems](https://docs.devexpress.com/OfficeFileAPI/120032/PDF-Document-API/Coordinate-Systems)
- [Interactive Forms in PDF Documents](https://docs.devexpress.com/OfficeFileAPI/118284/pdf-document-api/interactive-forms)
