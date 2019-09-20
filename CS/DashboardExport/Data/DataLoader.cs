using System.Collections.Generic;
using System.Data;
using System;
using DevExpress.Utils;

namespace DashboardExport {
    public static class DataLoader {
        static DataSet LoadData(string fileName) {
            string path = $@"Data\{fileName}.xml";
            DataSet ds = new DataSet();
            ds.ReadXml(path, XmlReadMode.ReadSchema);
            return ds;
        }
        public static DataSet LoadEmployees() {
            return LoadData("EmployeesAndDepartments");
        }
        public static DataSet LoadCustomerSupport() {
            return LoadData("CustomerSupportData");
        }
    }
}
