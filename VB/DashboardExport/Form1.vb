Imports System
Imports System.Windows.Forms
Imports DevExpress.DashboardCommon

Namespace DashboardExport

    Public Partial Class Form1
        Inherits Form

        Private dashboardExporterField As DashboardExporter

        Private ReadOnly Property DashboardExporter As DashboardExporter
            Get
                If dashboardExporterField Is Nothing Then dashboardExporterField = New DashboardExporter(dashboardViewer1)
                Return dashboardExporterField
            End Get
        End Property

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim dashboard As Dashboard = New Dashboard()
            dashboard.LoadFromXml(GetType(Form1).Assembly.GetManifestResourceStream("DashboardExport.CustomerSupport.xml"))
            dashboard.DataSources(0).Data = New CustomerSupportData(LoadCustomerSupport(), LoadEmployees()).CustomerSupport
            dashboardViewer1.Dashboard = dashboard
        End Sub

        Private Sub button1_Click_1(ByVal sender As Object, ByVal e As EventArgs)
            DashboardExporter.ShowPrintPreview(True)
        End Sub

        Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs)
            DashboardExporter.ShowPrintPreview(False)
        End Sub
    End Class
End Namespace
