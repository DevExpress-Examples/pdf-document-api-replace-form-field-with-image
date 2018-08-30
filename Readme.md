# How to export AcroForm data to XML


This example shows how to export AcroForm data (interactive form data) from a PDF document to XML format.<br><br>You can also export the AcroForm data to FDF, XFDF, and TXT formats using the approach described below.


<h3>Description</h3>

To export&nbsp;interactive form&nbsp;data&nbsp;to XML format:<br><br>- load a document containing interactive forms (e.g., from a file path)&nbsp;using the&nbsp;<a href="https://documentation.devexpress.com/#DocumentServer/DevExpressPdfPdfDocumentProcessor_LoadDocumenttopic">PdfDocumentProcessor.LoadDocument</a> method; <br>- call one of the <a href="https://documentation.devexpress.com/#DocumentServer/DevExpressPdfPdfDocumentProcessor_Exporttopic">PdfDocumentProcessor.Export </a>overloaded methods, for example, with a specified XML file name including a file path, where the exported document will be located, and&nbsp;XML data format.

<br/>


