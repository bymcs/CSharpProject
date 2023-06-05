using GMap.NET.MapProviders;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace CBS
{
    public partial class Form1 : Form
    {
        List<Car> cars;
        GMapOverlay katman = new GMapOverlay();
        readonly SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProjelerVT;Integrated Security=True");

        public Form1()
        {
            InitializeComponent();
            InitializeMap();
            InitializeCars();
        }

        private void InitializeCars()
        {
            #region Random List

            //cars = new List<Car>();
            //cars.Add(new Car("11SH585", "Pick-Up", "Medetli", "Üyük", new PointLatLng(40.288120643919974, 30.12300999552497)));
            //cars.Add(new Car("11SH585", "Pick-Up", "City A", "City B", new PointLatLng(40.288120643919974, 30.12300999552497)));
            //cars.Add(new Car("22TG765", "Sedan", "City C", "City D", new PointLatLng(40.512309897465345, 29.87654321098765)));
            //cars.Add(new Car("33KJ123", "Hatchback", "City E", "City F", new PointLatLng(40.111222333444555, 30.444555666777888)));
            //cars.Add(new Car("44UV987", "SUV", "City G", "City H", new PointLatLng(41.23456789012345, 29.345678901234567)));
            //cars.Add(new Car("55PO321", "Convertible", "City I", "City J", new PointLatLng(40.987654321098765, 30.876543210987654)));

            #endregion

            cars = new List<Car>();

            try
            {
                con.Open();
                string sqlCommand = "SELECT [Plaka],[AracTipi],[Nereden],[Nereye],[Enlem],[Boylam] FROM [ProjelerVT].[dbo].[Araclar]";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand, con);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                if(dt.Rows.Count > 0 )
                {
                    dataGridView1.DataSource = dt;
                }

                for(int i = 0; i < dt.Rows.Count; i++)
                {
                    cars.Add(new Car(dt.Rows[i][0].ToString(),
                                     dt.Rows[i][1].ToString(),
                                     dt.Rows[i][2].ToString(),
                                     dt.Rows[i][3].ToString(),
                                     new PointLatLng(Convert.ToDouble(dt.Rows[i][4].ToString()),
                                                     Convert.ToDouble(dt.Rows[i][5].ToString()))));
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("InitializeCars: "+ ex.Message);
            }
            finally 
            { 
                if(con != null)
                {
                    con.Close();
                }
            }
        }

        private void InitializeMap()
        {
            map.DragButton = MouseButtons.Left;
            map.MapProvider = GMapProviders.OpenStreetMap;
            map.Position = new GMap.NET.PointLatLng(40.288120643919974, 30.12300999552497);
            map.MinZoom = 5;
            map.MaxZoom = 18;
            map.Zoom = 10;
            map.ShowCenter = false;
            map.Overlays.Add(katman);

        }



        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            map.Dispose();
            //Application.Exit();

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            PointLatLng lokasyon = new PointLatLng(Convert.ToDouble(txtEn.Text), Convert.ToDouble(txtBoy.Text));
            GMarkerGoogle gMarker = new GMarkerGoogle(lokasyon, GMarkerGoogleType.blue_dot);
            gMarker.ToolTipText = "Marker";
            gMarker.Tag = 101;

            map.Overlays.Add(katman);
            // daha sonra marker'ları katman'a eklememiz lazım
            katman.Markers.Add(gMarker);

        }

        private void map_OnMarkerClick(GMap.NET.WindowsForms.GMapMarker item, MouseEventArgs e)
        {
            Console.WriteLine(item.Tag+" Marker Tıklandı");
        }

        private void btnLoadList_Click(object sender, EventArgs e)
        {
            foreach (var item in cars)
            {

                GMarkerGoogle markerList = new GMarkerGoogle(item.Konum, GMarkerGoogleType.red_dot);
                markerList.Tag = item.Plaka;
                markerList.ToolTipText = item.ToString();
                markerList.ToolTipMode = MarkerTooltipMode.OnMouseOver;
                markerList.Size = new System.Drawing.Size(21, 21);
                markerList.Offset = new System.Drawing.Point(-10, -10);
                markerList.ToolTip.Font = new Font("Arial", 9, FontStyle.Bold);
                katman.Markers.Add(markerList);


            }
        }

        private void btnLoadList_Click_1(object sender, EventArgs e)
        {

        }

        private void btnLoad_Click_1(object sender, EventArgs e)
        {

        }

        private void txtBoy_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEn_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
