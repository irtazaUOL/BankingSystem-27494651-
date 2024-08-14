using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Data;
using System.Windows.Forms;
using BankSystemc_;

namespace BankSystemc_.Tests
{
    [TestClass]
    public class ServiceTests
    {
        private service _form;

        [TestInitialize]
        public void Setup()
        {
            _form = new service();
        }

        [TestMethod]
        public void LoadServiceData_LoadsDataIntoDataGridView()
        {
            // Act
            _form.LoadServiceData();

            // Assert
            Assert.IsNotNull(_form.dataGridView1.DataSource, "DataGridView should have a data source.");
            Assert.IsInstanceOfType(_form.dataGridView1.DataSource, typeof(DataTable), "Data source should be of type DataTable.");

            DataTable dataTable = _form.dataGridView1.DataSource as DataTable;
            Assert.IsTrue(dataTable.Rows.Count > 0, "DataGridView should contain rows after loading data.");
        }
    }
}
