using GMap.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBS
{
    internal class Car
    {
        private string _plaka;
        private string _type;
        private string _from;
        private string _to;
        private PointLatLng _konum;

        public Car(string plaka, string type, string from, string to, PointLatLng konum)
        {
            Plaka = plaka;
            Type = type;
            From = from;
            To = to;
            Konum = konum;
        }

        public string Plaka { get => _plaka; set => _plaka = value; }
        public string Type { get => _type; set => _type = value; }
        public string From { get => _from; set => _from = value; }
        public string To { get => _to; set => _to = value; }
        public PointLatLng Konum { get => _konum; set => _konum = value; }

        public override string ToString()
        {
            return "\n" + Plaka + "\n" + Type + "\n" + From + "\n" + To;

        }
    }
}
