Imports DevExpress.DashboardCommon
Imports System

Namespace DashboardExport
	Partial Public Class Form1
		Inherits DevExpress.XtraEditors.XtraForm

'INSTANT VB NOTE: The variable dashboardExporter was renamed since Visual Basic does not allow variables and other class members to have the same name:
		Private dashboardExporter_Renamed As DashboardExporter
		Private ReadOnly Property DashboardExporter() As DashboardExporter
			Get
				If dashboardExporter_Renamed Is Nothing Then
					dashboardExporter_Renamed = New DashboardExporter(dashboardViewer1)
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
			DashboardExport.DashboardExporter.ShowPrintPreview(True)
		End Sub
		Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button2.Click
			DashboardExport.DashboardExporter.ShowPrintPreview(False)
		End Sub
	End Class
End Namespace
