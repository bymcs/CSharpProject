using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace LoginEkrani
{
    public partial class Form1 : Form
    {
        readonly SqlConnection baglanti = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjelerVT;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
            textBoxSifre.PasswordChar = '*';
        }


        private string sha256KoduOlustur(string s)
        {
            var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));
            var sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                sb.Append(bytes[i].ToString("x2"));
            }
            return sb.ToString();
        }

        private void buttonKaydol_Click(object sender, EventArgs e)
        {
            if (textBoxKullaniciAdi.Text.ToString().Length == 0
                    || textBoxSifre.Text.ToString().Length == 0)
            {
                MessageBox.Show("Alanlar boþ býrakýlmaz!");
                return;
            }

            string sorgu = "SELECT KullaniciAdi FROM Kullanici WHERE KullaniciAdi = @P1";

            try
            {
                baglanti.Open();
                SqlCommand sqlCommand = new SqlCommand(sorgu, baglanti);
                sqlCommand.Parameters.AddWithValue("@P1", textBoxKullaniciAdi.Text);
                SqlDataReader reader = sqlCommand.ExecuteReader();
                Console.WriteLine(sqlCommand.CommandText);
                bool yeniKullaniciEkle = false;

                if (reader.HasRows)
                {
                    // Bu isimde bir kullanýcý varsa veritabanýna ekleme yapýlmaz
                    MessageBox.Show(textBoxKullaniciAdi.Text + " isminde bir kullanýcý zaten mevcut, ekleme yapýlamadý!");
                }
                else
                {
                    // Veritabýna yeni kullnaýcýyý ekleyebiliriz
                    yeniKullaniciEkle = true;
                }
                reader.Close();

                if (yeniKullaniciEkle)
                {
                    sqlCommand = new SqlCommand("INSERT INTO Kullanici VALUES (@P1, @P2)", baglanti);
                    sqlCommand.Parameters.AddWithValue("@P1", textBoxKullaniciAdi.Text);
                    sqlCommand.Parameters.AddWithValue("@P2", sha256KoduOlustur(textBoxSifre.Text));
                    sqlCommand.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (baglanti != null)
                    baglanti.Close();
            }
        }

        private void buttonGiris_Click(object sender, EventArgs e)
        {
            if (textBoxKullaniciAdi.Text.ToString().Length == 0
                    || textBoxSifre.Text.ToString().Length == 0)
            {
                MessageBox.Show("Alanlar boþ býrakýlmaz!");
                return;
            }

            try
            {
                baglanti.Open();
                string sorgu = "SELECT KullaniciAdi, Sifre FROM Kullanici WHERE KullaniciAdi = @P1 " +
                               "AND Sifre = @P2";
                SqlCommand sqlCommand = new SqlCommand(sorgu, baglanti);
                sqlCommand.Parameters.AddWithValue("@P1", textBoxKullaniciAdi.Text);
                sqlCommand.Parameters.AddWithValue("@P2", sha256KoduOlustur(textBoxSifre.Text));
                SqlDataReader reader = sqlCommand.ExecuteReader();


                MessageBox.Show(sqlCommand.CommandText.ToString());

                if (reader.HasRows)
                {
                    
                    MessageBox.Show("Kullanýcý adý ve þifre Doðru! Sisteme Hoþ Geldiniz!!");
                }
                else
                {
                    MessageBox.Show("Kullanýcý adý veya þifre hatalý!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (baglanti != null)
                    baglanti.Close();
            }
        }
    }
}