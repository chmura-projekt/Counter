using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter.Models
{
    public class LicznikDane
    {
        public string Nazwa {  get; set; }
        public int Wartosc {  get; set; }
        public int WartoscPoczatkowa { get; set; }

        public string Kolor { get; set; }

        public LicznikDane(string nazwa, int wartosc, int wartoscPoczatkowa, string kolor)
        {
            Nazwa = nazwa;
            Wartosc = wartosc;
            WartoscPoczatkowa = wartoscPoczatkowa;
            Kolor = kolor;
        }
    }
}
