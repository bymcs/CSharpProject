using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DLL;

namespace DLL_APP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sayi = Convert.ToInt32(textBox1.Text.ToString());            
            int sayininKaresi = DLL.Math.kareHesapla(sayi);
            textBox3.Text = sayi.ToString();




        }
    }
}
