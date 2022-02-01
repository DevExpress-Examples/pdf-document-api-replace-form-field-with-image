<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/146724242/21.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T830535)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# PDF Document API - Replace a Form Field with an Image

This example shows how to substitute a text form field with an image.

To accomplish this task it is necessary to remove a certain field with an annotation and substitute it with an image since widget annotations are drawn over the page content.

-	Obtain a required form field using the <a href="https://docs.devexpress.com/OfficeFileAPI/DevExpress.Pdf.PdfAcroFormFacade.GetFormField(System.String)">PdfAcroFormFacade.GetFormField</a> method. The PdfAcroFormFacade object can be accessed using the <a href="https://docs.devexpress.com/OfficeFileAPI/DevExpress.Pdf.PdfDocumentFacade.AcroForm"> PdfDocumentFacade.AcroForm</a> property.

-	Obtain the widget annotations using the <a href="https://docs.devexpress.com/OfficeFileAPI/DevExpress.Pdf.PdfFormFieldFacade-2.Widgets"> PdfFormFieldFacade<T, V>.Widgets </a> property and get the annotation rectangle (defines the annotation location on the page) via the <a href="https://docs.devexpress.com/OfficeFileAPI/DevExpress.Pdf.PdfWidgetFacade.Rectangle">PdfWidgetFacade.Rectangle</a> property. Note that this property is measured in default user space units. 

-	Use the <a href="https://docs.devexpress.com/OfficeFileAPI/DevExpress.Pdf.PdfWidgetFacade.PageNumber">PdfWidgetFacade.PageNumber</a> property to get the page where the annotation is located. After that obtain the page boundaries defined by the crop box in the <a href="https://documentation.devexpress.com/OfficeFileAPI/120032/PDF-Document-API/Coordinate-Systems#User">user coordinate system</a> using the <a href="https://documentation.devexpress.com/CoreLibraries/DevExpress.Pdf.PdfPageTreeObject.CropBox.property">PdfPageTreeObject.CropBox</a> property. 
-	To draw an image at the form field position on the page, use the <a href="https://documentation.devexpress.com/CoreLibraries/DevExpress.Pdf.PdfGraphics.DrawImage.method(RvMF4Q)">PdfGraphics.DrawImage</a>  overload method of the **PdfGraphics** class.

-	Add graphics to a page foreground by calling the <a href="https://documentation.devexpress.com/CoreLibraries/DevExpress.Pdf.PdfGraphics.AddToPageForeground.overloads">PdfGraphics.AddToPageForeground</a> overload method and pass 72 as a DPI value. This method automatically converts <a href="https://documentation.devexpress.com/OfficeFileAPI/120032/PDF-Document-API/Coordinate-Systems#World">world coordinates</a> to <a href="https://documentation.devexpress.com/OfficeFileAPI/120032/PDF-Document-API/Coordinate-Systems#Page">page coordinates</a>. Passing 72 as a DPI value to this method allows transforming coordinates without any scaling. See <a href="https://documentation.devexpress.com/OfficeFileAPI/120032/PDF-Document-API/Coordinate-Systems">Coordinate Systems</a> for more details. 
-	Remove the form field calling the <a href="https://documentation.devexpress.com/OfficeFileAPI/DevExpress.Pdf.PdfDocumentProcessor.RemoveFormField.method">PdfDocumentProcessor.RemoveFormField</a> method. 
-	Save the resulting document calling the <a href="https://documentation.devexpress.com/OfficeFileAPI/DevExpress.Pdf.PdfDocumentProcessor.SaveDocument.overloads">PdfDocumentProcessor.SaveDocument</a> overload method. 

<br/>


