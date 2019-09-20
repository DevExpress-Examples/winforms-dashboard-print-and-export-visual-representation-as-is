Imports System.Collections.Generic
Imports System.Data
Imports System
Imports DevExpress.Utils

Namespace DashboardExport
	Public NotInheritable Class DataLoader

		Private Sub New()
		End Sub

		Private Shared Function LoadData(ByVal fileName As String) As DataSet
			Dim path As String = $"Data\{fileName}.xml"
			Dim ds As New DataSet()
			ds.ReadXml(path, XmlReadMode.ReadSchema)
			Return ds
		End Function
		Public Shared Function LoadEmployees() As DataSet
			Return LoadData("EmployeesAndDepartments")
		End Function
		Public Shared Function LoadCustomerSupport() As DataSet
			Return LoadData("CustomerSupportData")
		End Function
	End Class
End Namespace
