using Microsoft.Office.Interop.Excel;
using System.Collections;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace WinFormApp1
{
    public partial class Form1 : Form
    {
        readonly SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjelerVT;Integrated Security=True");


        public Form1()
        {
            InitializeComponent();
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            Excel.Application excelApp = new Excel.Application();
            excelApp.Visible = true;
            Excel.Workbook workbook = excelApp.Workbooks.Add(System.Reflection.Missing.Value);
            Excel.Worksheet worksheet = workbook.Sheets[1];

            string[] basliklar = { "Personel No", "Ad", "Soyad", "Semt", "Þehir" };
            Excel.Range range;
            for (int i = 0; i < basliklar.Length; i++)
            {
                range = worksheet.Cells[1, (1 + i)];
                range.Value2 = basliklar[i];
            }

            try
            {
                con.Open();
                string sql = "SELECT PersonelNo, Ad, Soyad, Semt, Sehir FROM Personel";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                int satir = 2;

                while (reader.Read())
                {
                    string? pNo = reader[0].ToString();
                    string? ad = reader[1].ToString();
                    string? soyad = reader[2].ToString();
                    string? semt = reader[3].ToString();
                    string? sehir = reader[4].ToString();

                    richTextBox1.Text = richTextBox1.Text + pNo + " " + ad + " " + soyad + " " + semt + " " + sehir + "\n";

                    range = worksheet.Cells[satir, 1];
                    range.Value2 = pNo;
                    range = worksheet.Cells[satir, 2];
                    range.Value2 = ad;
                    range = worksheet.Cells[satir, 3];
                    range.Value2 = soyad;
                    range = worksheet.Cells[satir, 4];
                    range.Value2 = semt;
                    range = worksheet.Cells[satir, 5];
                    range.Value2 = sehir;

                    satir++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }



        }


        private void btnRead2_Click(object sender, EventArgs e)
        {
            Excel.Application exApp;
            Excel.Workbook exWorkbook;
            Excel.Worksheet exWorksheet;
            Excel.Range range;
            int rowCount = 0;
            int columnCount = 0;

            exApp = new Excel.Application();
            exWorkbook = exApp.Workbooks.Open(@"C:\Users\mc.sahin\Documents\test2.xlsx");
            exWorksheet = (Excel.Worksheet)exWorkbook.Worksheets.get_Item(1);
            range = exWorksheet.UsedRange;
            richTextBox2.Clear();

            // ilk satýr baþlýklarý içerdiði için rowCount'u 2'den baþlatmamýz gerekiyor. 
            // Eðer ilk satýrda veriler baþlamýþ olsaydý 1'den baþlatmamýz gerekirdi.

            //MessageBox.Show(range.Rows.Count + " // " + range.Columns.Count);


            for (rowCount = 2; rowCount <= range.Rows.Count; rowCount++)
            {
                ArrayList list = new ArrayList();

                for (columnCount = 1; columnCount <= range.Columns.Count; columnCount++)
                {

                    string okunanHucre = Convert.ToString((range.Cells[rowCount, columnCount] as Excel.Range).Value2);
                    richTextBox2.Text = richTextBox2.Text + okunanHucre + " ";
                    list.Add(okunanHucre);
                }
                richTextBox2.Text = richTextBox2.Text + "\n";

                try
                {
                    con.Open();
                    SqlCommand command = new SqlCommand("INSERT INTO Personel (PersonelNo,Ad,Soyad,Semt,Sehir)" +
                                                        "VALUES (@P1, @P2, @P3, @P4, @P5)", con);

                    command.Parameters.AddWithValue("@P1", list[0]);
                    command.Parameters.AddWithValue("@P2", list[1]);
                    command.Parameters.AddWithValue("@P3", list[2]);
                    command.Parameters.AddWithValue("@P4", list[3]);
                    command.Parameters.AddWithValue("@P5", list[4]);
                    command.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    if (con != null) con.Close();
                }



            }

            exApp.Quit();
            ReleaseObject(exWorksheet);
            ReleaseObject(exWorkbook);
            ReleaseObject(exApp);

        }

        private void ReleaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }

        }
    }
}