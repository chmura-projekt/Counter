
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Microsoft.Maui.Storage;
using Counter.Models;

namespace Counter.Services
{
    public class LicznikZapis
    {
        string sciezkaPliku = Path.Combine(FileSystem.AppDataDirectory, "licznik.xml");

        public void ZapiszLiczniki(List<LicznikDane> listaLicznikow)
        {
            XElement glownyElement = new XElement("Liczniki");

            foreach (LicznikDane dane in listaLicznikow)
            {
                XElement licznik = 
                    new XElement("Licznik",
                    new XElement("Nazwa", dane.Nazwa),
                    new XElement("Wartosc", dane.Wartosc),
                    new XElement("WartoscPoczatkowa", dane.WartoscPoczatkowa),
                    new XElement("Kolor", dane.Kolor));

                glownyElement.Add(licznik);
            }

            XDocument dokument = new XDocument(glownyElement);

            dokument.Save(sciezkaPliku);
        }

        public List<LicznikDane> WczytajLiczniki()
        {
            List<LicznikDane> listaLicznikow = new List<LicznikDane>();

            if (File.Exists(sciezkaPliku))
            {
                XDocument dokument = XDocument.Load(sciezkaPliku);

                if (dokument.Root != null)
                {

                    foreach (XElement element in dokument.Root.Elements("Licznik"))
                    {
                        string nazwa = element.Element("Nazwa")?.Value ?? "Licznik";

                        int wartosc = 0;
                        int.TryParse(element.Element("Wartosc")?.Value, out wartosc);

                        int wartoscPoczatkowa = wartosc;

                        if (!int.TryParse(
                            element.Element("WartoscPoczatkowa")?.Value,
                            out wartoscPoczatkowa))
                        {
                            wartoscPoczatkowa = wartosc;
                        }

                        string kolor = element.Element("Kolor")?.Value ?? "#ADD8E6";

                        LicznikDane dane = new LicznikDane(
                            nazwa,
                            wartosc,
                            wartoscPoczatkowa,
                            kolor
                        );

                        listaLicznikow.Add(dane);
                    }
                }
            }

            return listaLicznikow;
        }
    }
}
