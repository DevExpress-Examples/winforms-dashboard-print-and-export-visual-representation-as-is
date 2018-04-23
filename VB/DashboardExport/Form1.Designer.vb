Imports Microsoft.VisualBasic
Imports System
Namespace DashboardExport
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.dashboardViewer1 = New DevExpress.XtraDashboard.DashboardViewer(Me.components)
			Me.panel1 = New System.Windows.Forms.Panel()
			Me.button1 = New System.Windows.Forms.Button()
			Me.button2 = New System.Windows.Forms.Button()
			Me.panel1.SuspendLayout()
			Me.SuspendLayout()
			' 
			' dashboardViewer1
			' 
			Me.dashboardViewer1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.dashboardViewer1.Location = New System.Drawing.Point(0, 0)
			Me.dashboardViewer1.Name = "dashboardViewer1"
			Me.dashboardViewer1.Size = New System.Drawing.Size(1659, 949)
			Me.dashboardViewer1.TabIndex = 0
			' 
			' panel1
			' 
			Me.panel1.Controls.Add(Me.button2)
			Me.panel1.Controls.Add(Me.button1)
			Me.panel1.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.panel1.Location = New System.Drawing.Point(0, 904)
			Me.panel1.Name = "panel1"
			Me.panel1.Size = New System.Drawing.Size(1659, 45)
			Me.panel1.TabIndex = 1
			' 
			' button1
			' 
			Me.button1.Location = New System.Drawing.Point(23, 11)
			Me.button1.Name = "button1"
			Me.button1.Size = New System.Drawing.Size(164, 23)
			Me.button1.TabIndex = 0
			Me.button1.Text = "Show Preview"
			Me.button1.UseVisualStyleBackColor = True
'			Me.button1.Click += New System.EventHandler(Me.button1_Click_1);
			' 
			' button2
			' 
			Me.button2.Location = New System.Drawing.Point(202, 11)
			Me.button2.Name = "button2"
			Me.button2.Size = New System.Drawing.Size(197, 23)
			Me.button2.TabIndex = 1
			Me.button2.Text = "Show Paged Preview"
			Me.button2.UseVisualStyleBackColor = True
'			Me.button2.Click += New System.EventHandler(Me.button2_Click);
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(1659, 949)
			Me.Controls.Add(Me.panel1)
			Me.Controls.Add(Me.dashboardViewer1)
			Me.Name = "Form1"
			Me.ShowIcon = False
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Dashboard Viewer"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			Me.panel1.ResumeLayout(False)
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private dashboardViewer1 As DevExpress.XtraDashboard.DashboardViewer
		Private panel1 As System.Windows.Forms.Panel
		Private WithEvents button2 As System.Windows.Forms.Button
		Private WithEvents button1 As System.Windows.Forms.Button
	End Class
End Namespace

