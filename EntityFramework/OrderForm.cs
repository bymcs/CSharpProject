using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFramework
{
    public partial class OrderForm : Form
    {
        NorthwindEntities entities = new NorthwindEntities();

        public OrderForm()
        {
            InitializeComponent();
            GetShowContent();
        }

        private void GetShowContent()
        {
            //var orders = entities.Orders.ToList();
            //dataGridView1.DataSource = orders;

            var orders = (from siparis in entities.Orders select new
            {
                siparis.OrderID,
                siparis.OrderDate,
                siparis.CustomerID,
                siparis.EmployeeID,
                siparis.Freight
            }).ToList();

            dataGridView1.DataSource = orders;

        }

        private void OrderForm_Load(object sender, EventArgs e)
        {

            var customers = (from musteri in entities.Customers
                             select new
                             {
                                 musteri.CustomerID,
                                 musteri.ContactName,
                                 //musteri.CompanyName

                             }).ToList();
            comboBox1.DataSource = customers;



        }
    }
}
