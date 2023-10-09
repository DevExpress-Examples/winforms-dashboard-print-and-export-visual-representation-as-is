Imports System.Data
Imports System
Imports DevExpress.Utils

Namespace DashboardExport

    Public Module DataLoader

        Private Function LoadData(ByVal fileName As String) As DataSet
            Dim path As String = FilesHelper.FindingFileName(AppDomain.CurrentDomain.BaseDirectory, String.Format("Data\{0}.xml", fileName), False)
            Dim ds As DataSet = New DataSet()
            ds.ReadXml(path, XmlReadMode.ReadSchema)
            Return ds
        End Function

        Public Function LoadEmployees() As DataSet
            Return LoadData("EmployeesAndDepartments")
        End Function

        Public Function LoadCustomerSupport() As DataSet
            Return LoadData("CustomerSupport")
        End Function
    End Module
End Namespace
