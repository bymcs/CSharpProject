using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class Rectangle
    {

        private int kisaKenar;
        private int uzunKenar;

        public int KisaKenar { get => kisaKenar; set => kisaKenar = value; }
        public int UzunKenar { get => uzunKenar; set => uzunKenar = value; }

        public Rectangle(int kisaKenar, int uzunKenar)
        {
            KisaKenar = kisaKenar;
            UzunKenar = uzunKenar;
        }


        public int alanHesapla()
        {
            return KisaKenar * UzunKenar;
        }

        public int cevreHesapla()
        {
            return (2 * (UzunKenar + KisaKenar));
        }



    }
}
