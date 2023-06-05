using System;
using System.Windows.Forms;

namespace EntityFramework
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private void btnCustomer_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerForm customerForm = new CustomerForm();
            customerForm.ShowDialog();
            customerForm = null;
            this.Show();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            this.Hide();
            OrderForm orderForm = new OrderForm();
            orderForm.ShowDialog();
            orderForm = null;
            this.Show();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductForm productForm = new ProductForm();
            productForm.ShowDialog();
            productForm = null;
            this.Show();
            
        }
    }
}
