using DevExpress.DashboardCommon;
using System;

namespace DashboardExport
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        CustomDashboardExporter customDashboardExporter;
        CustomDashboardExporter CustomDashboardExporter {
            get {
                if(customDashboardExporter == null)
                    customDashboardExporter = new CustomDashboardExporter(dashboardViewer1);
                return customDashboardExporter;
            }
        }
        public Form1() {
            InitializeComponent();
            
        }
        void Form1_Load(object sender, EventArgs e) {
            Dashboard dashboard = new DevExpress.DashboardCommon.Dashboard();
            dashboard.LoadFromXml(@"Data\CustomerSupport.xml");
            dashboard.DataSources[0].Data = 
                new CustomerSupportData(
                    DataLoader.LoadCustomerSupport(), 
                    DataLoader.LoadEmployees()
                    ).CustomerSupport;
            dashboardViewer1.Dashboard = dashboard;
        }
        void button1_Click_1(object sender, EventArgs e) {
            CustomDashboardExporter.ShowPrintPreview(true);
        }
        private void button2_Click(object sender, EventArgs e) {
            CustomDashboardExporter.ShowPrintPreview(false);
        }
    }
}