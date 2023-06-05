using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFramework
{
    public partial class CustomerForm : Form
    {

        NorthwindEntities entities = new NorthwindEntities();


        public CustomerForm()
        {
            InitializeComponent();
            GetShowContent();
        }


        private void GetShowContent()
        {
            var customer = entities.Customers.ToList();
            lblCount.Text = entities.Customers.Count().ToString();
            dataGridView1.DataSource = customer;
        }
        private void ClearTextBox()
        {
            txtID.Text = "0";
            txtNAME.Clear();
            txtCOMPANY.Clear();
            txtSEHIR.Clear();
            dataGridView1.ClearSelection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Customer customer = new Customer();
            //customer.CustomerName = txtNAME.Text;
            //customer.CustomerLastName = txtSURNAME.Text;
            //customer.CustomerCity = txtSEHIR.Text;
            //try
            //{
            //    entities.Customer.Add(customer);
            //    entities.SaveChanges();
            //    MessageBox.Show("Müşteri Kaydı Eklendi");
            //    GetShowContent();
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Equals("0"))
            {
                MessageBox.Show("Lütfen bir müşteri seçiniz.");
            }
            else
            {
                try
                {
                    string id = txtID.Text;
                    var customer = entities.Customers.FirstOrDefault(x => x.CustomerID.Equals(id));

                    Console.WriteLine(customer.ContactName);

                    entities.Customers.Remove(customer);
                    entities.SaveChanges();
                    
                    MessageBox.Show("Müşteri Kaydı silindi");
                    GetShowContent();
                    ClearTextBox();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int cell = dataGridView1.SelectedCells[0].RowIndex;
            txtID.Text = dataGridView1.Rows[cell].Cells[0].Value.ToString();
            txtCOMPANY.Text = dataGridView1.Rows[cell].Cells[1].Value.ToString();
            txtNAME.Text = dataGridView1.Rows[cell].Cells[2].Value.ToString();
            
            txtSEHIR.Text = dataGridView1.Rows[cell].Cells[5].Value.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {

            var customer = (from musteri in entities.Customers where DbFunctions.Like(musteri.ContactName, txtNAME.Text + "%") &&
                                                                     DbFunctions.Like(musteri.CompanyName, txtCOMPANY.Text + "%") &&
                                                                     DbFunctions.Like(musteri.City, txtSEHIR.Text + "%")
            select musteri).ToList();

            dataGridView1.DataSource = customer;
            lblCount.Text = customer.Count().ToString();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
