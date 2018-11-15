<!-- default file list -->
*Files to look at*:

* [DashboardExporter.cs](./CS/DashboardExport/DashboardExporter.cs) (VB: [DashboardExporter.vb](./VB/DashboardExport/DashboardExporter.vb))
* [Form1.cs](./CS/DashboardExport/Form1.cs) (VB: [Form1.vb](./VB/DashboardExport/Form1.vb))
<!-- default file list end -->
# How to print and export a WinForms Dashboard visual representation as is


<p>The following example demonstrates a workaround that allows you to print and export a Dashboard visual representation as is via the Print Preview dialog.</p><p>In this example, the Customer Support dashboard is displayed. You can invoke the Print Preview for the dashboard in one of the two modes, using the Show Preview or Show Paged Preview button. In the first mode, the paper size is adjusted to fit the dashboard. In the second mode, the dashboard gets split across the appropriate number of standard A4 pages.</p><p>To accomplish this, we have created a DashboardExporter class that implements the DevExpress.XtraPrinting.IPrintable interface. DashboardExporter instances are mapped to a DashboardViewer when they are created and then passed to the Print Preview thus bringing the dashboard to paper.</p>

<br/>


