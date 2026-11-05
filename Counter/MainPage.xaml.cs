using Counter.Models;
using Counter.Services;

namespace Counter
{


    public partial class MainPage : ContentPage
    {
        int iloscLicznikow = 0;

        List<LicznikDane> listaLicznikow = new List<LicznikDane>();

       LicznikZapis zapis = new LicznikZapis();

        public MainPage()
        {
            InitializeComponent();

            WczytajLiczniki();
        }

        private void DodajLicznik_Clicked(object? sender, EventArgs e)
        {
            string nazwa = NazwaNowegoLicznika.Text ?? "";

            if (string.IsNullOrWhiteSpace(nazwa))
            {
                nazwa = "Licznik " + (iloscLicznikow + 1);
            }

            int wartosc = 0;

            int.TryParse(WartoscPoczatkowa.Text, out wartosc);

            string kolor = LicznikKolor.PobierzKolor(
                KolorNowegoLicznika.SelectedItem?.ToString()
            );

            iloscLicznikow++;

            LicznikDane nowyLicznik = new LicznikDane(nazwa, wartosc, wartosc, kolor);

            listaLicznikow.Add(nowyLicznik);

            DodajWidokLicznika(nowyLicznik);

            NazwaNowegoLicznika.Text = "";

            WartoscPoczatkowa.Text = "";

            KolorNowegoLicznika.SelectedIndex = 0;

            ZapiszLiczniki();
        }

        private void DodajWidokLicznika(LicznikDane dane)
        {
            Label nazwaLicznika = new Label
            {
                Text = dane.Nazwa,
                FontSize = 22,
                HorizontalOptions = LayoutOptions.Center
            };

            Label wartoscLicznika = new Label
            {
                Text = dane.Wartosc.ToString(),
                FontSize = 35,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            Button minus = new Button
            {
                Text = "-",
                FontSize = 25,
                WidthRequest = 60
            };

            Button plus = new Button
            {
                Text = "+",
                FontSize = 25,
                WidthRequest = 60
            };

            Button reset = new Button
            {
                Text = "Reset",
                FontSize = 14
            };

            Button usun = new Button
            {
                Text = "Usuń",
                FontSize = 14
            };

            VerticalStackLayout nowyLicznik = new VerticalStackLayout
            {
                Spacing = 5,
                Padding = 10,
                BackgroundColor = Color.FromArgb(dane.Kolor)
            };

            minus.Clicked += (s, e) =>
            {
                dane.Wartosc--;
                wartoscLicznika.Text = dane.Wartosc.ToString();

                ZapiszLiczniki();
            };

            reset.Clicked += (s, e) =>
            {
                dane.Wartosc = dane.WartoscPoczatkowa;
                wartoscLicznika.Text = dane.Wartosc.ToString();

                ZapiszLiczniki();
            };

            usun.Clicked += (s, e) =>
            {
                ListaLicznikow.Children.Remove(nowyLicznik);

                listaLicznikow.Remove(dane);

                iloscLicznikow--;

                ZapiszLiczniki();
            };

            plus.Clicked += (s, e) =>
            {
                dane.Wartosc++;
                wartoscLicznika.Text = dane.Wartosc.ToString();

                ZapiszLiczniki();
            };

            HorizontalStackLayout przyciski = new HorizontalStackLayout
            {
                Spacing = 10,
                HorizontalOptions = LayoutOptions.Center
            };
            

            przyciski.Children.Add(minus);
            przyciski.Children.Add(plus);
            przyciski.Children.Add(reset);
            przyciski.Children.Add(usun);

           

            nowyLicznik.Children.Add(nazwaLicznika);
            nowyLicznik.Children.Add(wartoscLicznika);
            nowyLicznik.Children.Add(przyciski);

            ListaLicznikow.Children.Add(nowyLicznik);
        }

        private void ZapiszLiczniki()
        {
            zapis.ZapiszLiczniki(listaLicznikow);
        }

        private void WczytajLiczniki()
        {
            listaLicznikow = zapis.WczytajLiczniki();

            foreach (LicznikDane dane in listaLicznikow)
            {
                DodajWidokLicznika(dane);
            }
            iloscLicznikow = listaLicznikow.Count;
        }

        
    }

}