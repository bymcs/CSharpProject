using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MusteriOtomasyon
{



    public partial class Form1 : Form
    {

        public string RemoveWhitespace(string input)
        {
            return new string(input.ToCharArray()
                .Where(c => !Char.IsWhiteSpace(c))
                .ToArray());
        }

        SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjelerVT;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowContent();
            dataGridView1.ClearSelection();
            txtID.Text = "0";

        }

        private void ShowContent()
        {
            try
            {
                string command = "SELECT * FROM [ProjelerVT].[dbo].[Musteri]";
                SqlDataAdapter adapter = new SqlDataAdapter(command, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally 
            {
                if(conn != null)
                {
                    conn.Close();
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilenSatir = dataGridView1.SelectedCells[0].RowIndex;
            txtID.Text       = dataGridView1.Rows[secilenSatir].Cells[0].Value?.ToString() is null ? "0" : dataGridView1.Rows[secilenSatir].Cells[0].Value?.ToString();
            txtNAME.Text     = dataGridView1.Rows[secilenSatir].Cells[1].Value?.ToString();
            txtSURNAME.Text  = dataGridView1.Rows[secilenSatir].Cells[2].Value?.ToString();
            txtGELIR.Text    = dataGridView1.Rows[secilenSatir].Cells[3].Value?.ToString();
            txtKREDI.Text    = dataGridView1.Rows[secilenSatir].Cells[4].Value?.ToString() == "True" ? "1" : "0";
            txtSEHIR.Text    = dataGridView1.Rows[secilenSatir].Cells[5].Value?.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string command = "INSERT INTO [ProjelerVT].[dbo].[Musteri] ([Ad],[Soyad],[AylikGelir],[KrediyeUygunMu],[Sehir])"+
                                 "VALUES (@P1,@P2,@P3,@P4,@P5)  ";
                SqlCommand sqlCommand = new SqlCommand(command,conn);

                sqlCommand.Parameters.AddWithValue("@P1", txtNAME.Text);
                sqlCommand.Parameters.AddWithValue("@P2", txtSURNAME.Text);
                sqlCommand.Parameters.AddWithValue("@P3", txtGELIR.Text);
                sqlCommand.Parameters.AddWithValue("@P5", txtSEHIR.Text);

                if (Convert.ToInt32(txtGELIR.Text) >= 10000)
                {
                    sqlCommand.Parameters.AddWithValue("@P4", 1);
                }
                else
                {
                    sqlCommand.Parameters.AddWithValue("@P4", 0);
                }

                sqlCommand.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }

                ShowContent();
                ClearTextBox();
            }
        }

        private void ClearTextBox()
        {
            txtID.Text = "0";
            txtNAME.Clear();
            txtSURNAME.Clear();
            txtGELIR.Clear();
            txtKREDI.Clear();
            txtSEHIR.Clear();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Equals("0"))
            {
                MessageBox.Show("Lütfen bir müşteri seçiniz.");
            }
            else
            {
                try
                {
                    conn.Open();
                    string command = "DELETE FROM [ProjelerVT].[dbo].[Musteri] WHERE MusteriId = @P1";
                    SqlCommand sqlCommand = new SqlCommand(command, conn);
                    sqlCommand.Parameters.AddWithValue("@P1", txtID.Text);
                    sqlCommand.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                    ShowContent();
                    ClearTextBox();
                }
                dataGridView1.ClearSelection();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
            ClearTextBox();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Equals("0"))
            {
                MessageBox.Show("Lütfen bir müşteri seçiniz.");
            }
            else
            {
                try
                {
                    conn.Open();
                    string command = "UPDATE [ProjelerVT].[dbo].[Musteri] SET Ad = @P1, Soyad = @P2, AylikGelir = @P3, KrediyeUygunMu = @P4, Sehir = @P5 WHERE MusteriId = @P6";
                    SqlCommand sqlCommand = new SqlCommand(command, conn);
                    
                    sqlCommand.Parameters.AddWithValue("@P1", txtNAME.Text);
                    sqlCommand.Parameters.AddWithValue("@P2", txtSURNAME.Text);
                    sqlCommand.Parameters.AddWithValue("@P3", txtGELIR.Text);
                    sqlCommand.Parameters.AddWithValue("@P4", Convert.ToInt32(txtGELIR.Text) >= 10000 ? "1" : "0");
                    sqlCommand.Parameters.AddWithValue("@P5", txtSEHIR.Text);
                    sqlCommand.Parameters.AddWithValue("@P6", txtID.Text);

                    sqlCommand.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                    ShowContent();
                    ClearTextBox();
                }
            }
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {

            try
            {
                string p1 = txtNAME.TextLength > 0 ? RemoveWhitespace(txtNAME.Text) + "%" : "";
                string p2 = txtSURNAME.TextLength > 0 ? RemoveWhitespace(txtSURNAME.Text) + "%" : "";
                string p3 = txtSEHIR.TextLength > 0 ? RemoveWhitespace(txtSEHIR.Text) + "%" : "";
                string p4 = txtGELIR.TextLength > 0 ? RemoveWhitespace(txtGELIR.Text) : "";

                string command;

                if(!string.IsNullOrEmpty(p1) || !string.IsNullOrEmpty(p2) || !string.IsNullOrEmpty(p3) || !string.IsNullOrEmpty(p4))
                {
                    command = "SELECT * FROM Musteri WHERE Ad LIKE '" + p1 + "' OR Soyad LIKE '" + p2 + "' OR Sehir LIKE '" + p3 + "' OR AylikGelir = " + p4 + " ";
                }
                else
                {
                    command = "SELECT * FROM Musteri";
                    //command = "SELECT * FROM Musteri WHERE Ad LIKE '%' OR Soyad LIKE '%' OR Sehir LIKE '%' OR AylikGelir LIKE '%'";
                }

                Console.WriteLine(command);

                SqlDataAdapter da = new SqlDataAdapter(command, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                Console.WriteLine(dt.Columns);

                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }

        }

    }
    
}
