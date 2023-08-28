Imports DevExpress.DashboardCommon
Imports System

Namespace DashboardExport
    Partial Public Class Form1
        Inherits DevExpress.XtraEditors.XtraForm

        Private dashboardExporter_Renamed As CustomDashboardExporter
        Private ReadOnly Property CustomDashboardExporter() As CustomDashboardExporter
            Get
                If dashboardExporter_Renamed Is Nothing Then
                    dashboardExporter_Renamed = New CustomDashboardExporter(dashboardViewer1)
                End If
                Return dashboardExporter_Renamed
            End Get
        End Property
        Public Sub New()
            InitializeComponent()

        End Sub
        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Dim dashboard As Dashboard = New DevExpress.DashboardCommon.Dashboard()
            dashboard.LoadFromXml("Data\CustomerSupport.xml")
            dashboard.DataSources(0).Data = (New CustomerSupportData(DataLoader.LoadCustomerSupport(), DataLoader.LoadEmployees())).CustomerSupport
            dashboardViewer1.Dashboard = dashboard
        End Sub
        Private Sub button1_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
            CustomDashboardExporter.ShowPrintPreview(True)
        End Sub
        Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
            CustomDashboardExporter.ShowPrintPreview(False)
        End Sub
    End Class
End Namespace