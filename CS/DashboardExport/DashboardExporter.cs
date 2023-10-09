using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.DashboardWin;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.Native;
using DevExpress.XtraReports.UI;

namespace DashboardExport {
    class DashboardExporter : IPrintable {
        PrintingSystem ps = new PrintingSystem();
        PrintableComponentLink componentLink = new PrintableComponentLink();
        DashboardViewer viewer;
        bool paged;
        public DashboardExporter(DashboardViewer viewer) {
            this.viewer = viewer;
            ps.Links.AddRange(new object[] { componentLink });
            ps.AfterChange += ps_AfterChange;
            componentLink.Component = this;
        }
        internal void ShowPrintPreview(bool fitPage) {
            if(fitPage) {
                componentLink.PaperKind = System.Drawing.Printing.PaperKind.Custom;
                componentLink.CustomPaperSize = 
                    new Size(Convert.ToInt32(Math.Ceiling(viewer.Width / 0.96f)) + 45, 
                        Convert.ToInt32(Math.Ceiling(viewer.Height / 0.96f)) + 45);
                ps.PreviewFormEx.Size = new Size(viewer.Width + 100, viewer.Height + 100);
            } else {
                componentLink.PaperKind = System.Drawing.Printing.PaperKind.A4;
                ps.PreviewFormEx.Size = new Size(0x2f0, 0x274);
            }
            componentLink.Margins = new System.Drawing.Printing.Margins(20, 20, 20, 20);
            componentLink.MinMargins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            ps.PreviewFormEx.StartPosition = FormStartPosition.CenterScreen;
            this.paged = !fitPage;
            componentLink.CreateDocument();
            componentLink.ShowPreview();
        }
        void ps_AfterChange(object sender, ChangeEventArgs e) {
            switch(e.EventName) {
                case SR.PageSettingsChanged:
                case SR.AfterMarginsChange:
                    componentLink.CreateDocument();
                    break;
            }
        }
        int ToDocument(int value) {
            return Convert.ToInt32(GraphicsUnitConverter.PixelToDoc(value));
        }
#region IPrintable
        void IPrintable.AcceptChanges() {
        }
        bool IPrintable.CreatesIntersectedBricks {
            get { return false; }
        }
        bool IPrintable.HasPropertyEditor() {
            return false;
        }
        UserControl IPrintable.PropertyEditorControl {
            get { return null; }
        }
        void IPrintable.RejectChanges() {            
        }
        void IPrintable.ShowHelp() {
        }
        bool IPrintable.SupportsHelp() {
            return false;
        }
        void IBasePrintable.CreateArea(string areaName, IBrickGraphics graph) {
            if(areaName != "Detail")
                return;
            int width;
            int height;
            if(paged) {
                width = viewer.Width;
                height = viewer.Height;
            } else {
                width = Convert.ToInt32(ps.PageSettings.UsablePageSizeInPixels.Width);
                height = Convert.ToInt32(ps.PageSettings.UsablePageSizeInPixels.Height);
            }
            Image bitmap = 
                XRControlPaint.GetControlImage(
                    viewer, 
                    WinControlDrawMethod_Utils.UseWMPrintRecursive, 
                    WinControlImageType_Utils.Bitmap);
            graph.DrawBrick(new ImageBrick() {
                    Image = bitmap, 
                    SizeMode = ImageSizeMode.CenterImage
                }, new Rectangle(0, 0, width, height));
        }
        void IBasePrintable.Finalize(IPrintingSystem ps, ILink link) {
        }
        void IBasePrintable.Initialize(IPrintingSystem ps, ILink link) {
        }
#endregion
    }
}
