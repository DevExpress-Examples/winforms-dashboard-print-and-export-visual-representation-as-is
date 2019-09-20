Imports System
Imports System.Drawing
Imports System.Windows.Forms
Imports DevExpress.DashboardWin
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.Native
Imports DevExpress.XtraReports.UI

Namespace DashboardExport
	Friend Class DashboardExporter
		Implements IPrintable

		Private ps As New PrintingSystem()
		Private componentLink As New PrintableComponentLink()
		Private viewer As DashboardViewer
		Private paged As Boolean
		Public Sub New(ByVal viewer As DashboardViewer)
			Me.viewer = viewer
			ps.Links.AddRange(New Object() { componentLink })
			AddHandler ps.AfterChange, AddressOf ps_AfterChange
			componentLink.Component = Me
		End Sub
		Friend Sub ShowPrintPreview(ByVal fitPage As Boolean)
			If fitPage Then
				componentLink.PaperKind = System.Drawing.Printing.PaperKind.Custom
				componentLink.CustomPaperSize = New Size(Convert.ToInt32(Math.Ceiling(viewer.Width / 0.96F)) + 45, Convert.ToInt32(Math.Ceiling(viewer.Height / 0.96F)) + 45)
				ps.PreviewFormEx.Size = New Size(viewer.Width + 100, viewer.Height + 100)
			Else
				componentLink.PaperKind = System.Drawing.Printing.PaperKind.A4
				ps.PreviewFormEx.Size = New Size(&H2f0, &H274)
			End If
			componentLink.Margins = New System.Drawing.Printing.Margins(20, 20, 20, 20)
			componentLink.MinMargins = New System.Drawing.Printing.Margins(0, 0, 0, 0)
			ps.PreviewFormEx.StartPosition = FormStartPosition.CenterScreen
			Me.paged = Not fitPage
			componentLink.CreateDocument()
			componentLink.ShowPreview()
		End Sub
		Private Sub ps_AfterChange(ByVal sender As Object, ByVal e As ChangeEventArgs)
			Select Case e.EventName
				Case SR.PageSettingsChanged, SR.AfterMarginsChange
					componentLink.CreateDocument()
			End Select
		End Sub
		Private Function ToDocument(ByVal value As Integer) As Integer
			Return Convert.ToInt32(GraphicsUnitConverter.PixelToDoc(value))
		End Function
#Region "IPrintable"
		Private Sub IPrintable_AcceptChanges() Implements IPrintable.AcceptChanges
		End Sub
		Private ReadOnly Property IPrintable_CreatesIntersectedBricks() As Boolean Implements IPrintable.CreatesIntersectedBricks
			Get
				Return False
			End Get
		End Property
		Private Function IPrintable_HasPropertyEditor() As Boolean Implements IPrintable.HasPropertyEditor
			Return False
		End Function
		Private ReadOnly Property IPrintable_PropertyEditorControl() As UserControl Implements IPrintable.PropertyEditorControl
			Get
				Return Nothing
			End Get
		End Property
		Private Sub IPrintable_RejectChanges() Implements IPrintable.RejectChanges
		End Sub
		Private Sub IPrintable_ShowHelp() Implements IPrintable.ShowHelp
		End Sub
		Private Function IPrintable_SupportsHelp() As Boolean Implements IPrintable.SupportsHelp
			Return False
		End Function
		Private Sub IBasePrintable_CreateArea(ByVal areaName As String, ByVal graph As IBrickGraphics) Implements IBasePrintable.CreateArea
			If areaName <> "Detail" Then
				Return
			End If
			Dim width As Integer
			Dim height As Integer
			If paged Then
				width = viewer.Width
				height = viewer.Height
			Else
				width = Convert.ToInt32(ps.PageSettings.UsablePageSizeInPixels.Width)
				height = Convert.ToInt32(ps.PageSettings.UsablePageSizeInPixels.Height)
			End If
			Dim bitmap As Image = XRControlPaint.GetControlImage(viewer, WinControlDrawMethod_Utils.UseWMPrintRecursive, WinControlImageType_Utils.Bitmap)
			graph.DrawBrick(New ImageBrick() With {.Image = bitmap, .SizeMode = ImageSizeMode.CenterImage}, New Rectangle(0, 0, width, height))
		End Sub
		Private Sub IBasePrintable_Finalize(ByVal ps As IPrintingSystem, ByVal link As ILink) Implements IBasePrintable.Finalize
		End Sub
		Private Sub IBasePrintable_Initialize(ByVal ps As IPrintingSystem, ByVal link As ILink) Implements IBasePrintable.Initialize
		End Sub
#End Region
	End Class
End Namespace
