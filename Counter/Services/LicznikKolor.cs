using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter.Services
{
    public class LicznikKolor
    {
        public static string PobierzKolor(string? nazwaKoloru)
        {
            switch (nazwaKoloru)
            {
                case "Niebieski":
                    return "#ADD8E6";

                case "Zielony":
                    return "#90EE90";

                case "Różowy":
                    return "#FF86C1";

                case "Żółty":
                    return "#FFFF99";

                case "Fioletowy":
                    return "#D8BFD8";

                default:
                    return "#ADD8E6";
            }
        }
    }
}
