<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128581274/18.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4399)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [DashboardExporter.cs](./CS/DashboardExport/DashboardExporter.cs) (VB: [DashboardExporter.vb](./VB/DashboardExport/DashboardExporter.vb))
* [Form1.cs](./CS/DashboardExport/Form1.cs) (VB: [Form1.vb](./VB/DashboardExport/Form1.vb))
<!-- default file list end -->
# Dashboard for WinForms - How to Use the PrintableComponentLink to Print a Dashboard


This example demonstrates the use of the [PrintableComponentLink](https://docs.devexpress.com/WindowsForms/DevExpress.XtraPrinting.PrintableComponentLink) to print a dashboard.

A custom **DashboardExporter** class implements the [IPrintable](https://docs.devexpress.com/WindowsForms/DevExpress.XtraPrinting.IPrintable) interface and encapsulates all logic required to specify page settings, create a PrintableComponentLink and show the **Print Preview** window. Use the **Show Preview** and **Show Paged Preview** buttons to view the result.

![](dashboard-viewer-custom-export.png)

## Documentation

- [Printing and Exporting](https://docs.devexpress.com/Dashboard/15181/common-features/printing-and-exporting?p=netframework)
