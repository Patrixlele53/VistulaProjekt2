using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//dodanie nowych przestrzeni nazw dla potrzeb Projektu Nr 2
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Projekt2_Karwowski65859
{
    internal class FiguryGeometryczne
    {
        //deklaracje pomocnicze 
        const int SrednicaPunktu = 5;
        //deklaracja znaczników figur geometrycznych
        public enum FiguraGeometryczna : byte
        {
            Punkt, Linia, Elipsa, Okrag,
            Prostokat, Kwadrat, Wielokat, Elipsa_Wypelnialna
        };

        public class Punkt
        {


            // deklaracje atrybutow niezbednych dla wykreslenia 
            public int X, Y;
            public FiguraGeometryczna Figura { get; protected set; }

            public Color Kolor { get; set; }
            public float GruboscPunktu { get; protected set; }

            public float GruboscLinii { get; set; }
            // deklaracja atrybutow waznych dla implementacji funkcjonalnosci udostepnionych w formularzu
            public DashStyle StylLinii { get; set; }
            public Color KolorTla { get; protected set; } // wypelnienia figury
            public bool Widoczny { get; protected set; }
            // deklaracje konstruktorow

            public Punkt(int x, int y)
            {
                // ustalenie wartosci atrybutow: X i Y tworzonego egzemplarza punktu
                X = x; Y = y;
                //ustawienie wartosci domyslnych dla pozostalych atrybutow klasy Punkt
                Kolor = Color.Black; GruboscPunktu = SrednicaPunktu;
                StylLinii = DashStyle.Solid; KolorTla = Color.White;
                Widoczny = false;
                Figura = FiguraGeometryczna.Punkt;



            }

            public virtual void UaktualnijXY(int anx, int any)
            {
                this.X = anx;
                this.Y = any;
            }

            //przeciążenie metody: UaktualnijXY() dla innego sposobu przekazywania argumentów
            public virtual void UaktualnijXY(Point anNowaLokalizacja)
            {
                X = anNowaLokalizacja.X;
                Y = anNowaLokalizacja.Y;
            }
            public Punkt(int x, int y, Color KolorPunktu) : this(x, y)
            {
                Kolor = KolorPunktu;
            }

            // deklaracje metod wirtualnych
            public virtual void Wykresl(Graphics Rysownica)
            {
                using (SolidBrush Pedzel = new SolidBrush(Kolor))
                { //wykreślenie Punktu
                    Rysownica.FillEllipse(Pedzel, X - GruboscPunktu / 2, Y - GruboscPunktu / 2,
                        GruboscPunktu, GruboscPunktu);

                    //uaktualnienie znacznikow
                    Widoczny = true;


                } //tutaj nastapi automatyczne zwolnienie Pedzla
            }

            public virtual void Wymaz(Control Kontrolka, Graphics Rysownica)
            {
                //sprawdzenie czy dany punkt jest aktualnie wykreślony 
                if (Widoczny)
                {
                    using (SolidBrush Pedzel = new SolidBrush(Kontrolka.BackColor))
                    { //wykreślenie Punktu
                        Rysownica.FillEllipse(Pedzel, X - GruboscPunktu / 2, Y - GruboscPunktu / 2,
                            GruboscPunktu, GruboscPunktu);

                        //uaktualnienie znacznikow
                        Widoczny = false;


                    } //tutaj nastapi automatyczne zwolnienie Pedzla


                }
            }
            public virtual void PrzesunDoNowegoXY(Control Kontrolka, Graphics Rysownica,
                                                                        int x, int y)
            {
                //wytmazanie punktu w aktualnym jego polozeniu
                Wymaz(Kontrolka, Rysownica);
                // zmiana lokalizacji punktu
                X = x; Y = y;
                //wykreslenie Punktu w nowej lokalizacji 
                Wykresl(Rysownica);
            }

        } //do class Punkt

        public class Linia : Punkt
        { //deklaracja uzupełniająca opis figury: Linia
            int Xk, Yk; //wspolrzedne konca linii 
                        // poniewaz klasa Linia ma klasę bazową Punkt, to zadeklarowane w niej X i Y beda traktowane w klasie Linia jako wspolrzedne poczatku linii

            //deklaracje konstruktorow  

            public Linia(int Xp, int Yp, int Xk, int Yk) : base(Xp, Yp)
            {
                this.Xk = Xk; this.Yk = Yk;
                //wpisanie znacznika linii 
                Figura = FiguraGeometryczna.Linia;
            }

            public Linia(int Xp, int Yp, int Xk, int Yk, Color KolorLinii,
                DashStyle StylLinii, float GruboscLinii) : this(Xp, Yp, Xk, Yk)
            {
                //przechowanie w egzemplarzu Linii jej atrybutow graficznych 
                Kolor = KolorLinii;
                this.StylLinii = StylLinii; this.GruboscPunktu = GruboscLinii;

            }
            //nadpisanie metod wirtualnych z klasy Punkt (i jest to konieczne, gdyz inaczej kresli sie Punkt, a inaczej Linie)
            public override void Wykresl(Graphics Rysownica)
            {
                using (Pen Pioro = new Pen(Kolor, GruboscPunktu))
                {
                    Pioro.DashStyle = StylLinii;
                    Rysownica.DrawLine(Pioro, X, Y, Xk, Yk);
                    Widoczny = true;
                }
            }
            public override void Wymaz(Control Kontrolka, Graphics Rysownica)
            {
                if (Widoczny)
                {
                    using (Pen Pioro = new Pen(Kontrolka.BackColor, GruboscPunktu))
                    {
                        Pioro.DashStyle = StylLinii;
                        Rysownica.DrawLine(Pioro, X, Y, Xk, Yk);
                        Widoczny = false;
                    }
                }
            }
            public override void PrzesunDoNowegoXY(Control Kontrolka, Graphics Rysownica, int x, int y)
            {
                //wymazanie linii w biezacej lokalizacji 
                Wymaz(Kontrolka, Rysownica);
                // deklaracja pomocnicza dla przechowania wartosci przyrostow zmian X i Y
                int dx, dy;
                // wyznaczenie wartosci przyrostow 
                if (x > X)
                    dx = x - X;
                else
                    dx = X - x;
                if (y > Y)
                    dy = y - Y;
                else
                    dy = Y - y;
                //dokonanie przesuniec wspolrzednych poczatku linii 
                X = x; Y = y;
                //dokonanie przesuniec wspolrzednych konca linii
                Xk = (Xk + dx) % Kontrolka.Width;
                Yk = (Yk + dy) % Kontrolka.Height;
                //wykreslenie linii po przesunieciu 
                Wykresl(Rysownica);
            }
        } //do class Linia


        public class Elipsa : Punkt
        {
            protected int OsDuza, OsMala;

            //deklaracja konstruktora klasy Elipsa
            public Elipsa(int x, int y, int OsDuza, int OsMala, Color KolorLinii, DashStyle StylLinii, float GruboscLinii) : base(x, y, KolorLinii)
            {
                this.OsDuza = OsDuza;
                this.OsMala = OsMala;
                this.StylLinii = StylLinii;
                this.GruboscLinii = GruboscLinii;
            }
            // nadpisanie metod wirtualnych 
            public override void Wykresl(Graphics Rysownica)
            {
                //utworzenie egzemplarza Pióro
                using (Pen Pioro = new Pen(Kolor, GruboscLinii))
                {// ustawienie stylu linii
                    Pioro.DashStyle = StylLinii;
                    // wykreslenie Elipsy 
                    Rysownica.DrawEllipse(Pioro, X, Y, OsDuza, OsMala);
                    //ustawienie atrybutu Widocznosci
                    Widoczny = true;


                } // tutaj nastąpi automatyczne zwolnienie pióra
            } // do Wykresl (...)
            public override void Wymaz(Control Kontrolka, Graphics Rysownica)
            {// sprawdzenie, czy Elipsa jest aktualnie wykreslona
                if (Widoczny)
                {// utworzenie Piora w kolorze tla kontrolki
                    using (Pen Pioro = new Pen(Kontrolka.BackColor, GruboscLinii))
                    {
                        // ustawienie stylu Linii
                        Pioro.DashStyle = StylLinii;
                        //wymazanie (wykreslenie w kolorze tla) Elipsy 
                        Rysownica.DrawEllipse(Pioro, X, Y, OsDuza, OsMala);
                        //ustawienie nowego atrybutu widocznosci
                        Widoczny = false;
                    }
                } // do if (Widoczny)

            } //do void Wymaz( . . . )



        } // do Class Elipsa:Punkt

        public class Prostokat : Punkt
        {
            protected int Szerokosc, Wysokosc;

            // Deklaracja konstruktora klasy Prostokat
            public Prostokat(int x, int y, int Szerokosc, int Wysokosc, Color KolorLinii, DashStyle StylLinii, float GruboscLinii)
                : base(x, y, KolorLinii)
            {
                this.Szerokosc = Szerokosc;
                this.Wysokosc = Wysokosc;
                this.StylLinii = StylLinii;
                this.GruboscLinii = GruboscLinii;
                Figura = FiguraGeometryczna.Prostokat;
            }

            // Nadpisanie metod wirtualnych 
            public override void Wykresl(Graphics Rysownica)
            {
                // Utworzenie egzemplarza Pióra
                using (Pen Pioro = new Pen(Kolor, GruboscLinii))
                {
                    // Ustawienie stylu linii
                    Pioro.DashStyle = StylLinii;
                    // Wykreślenie Prostokata 
                    Rysownica.DrawRectangle(Pioro, X, Y, Szerokosc, Wysokosc);
                    // Ustawienie atrybutu Widocznosci
                    Widoczny = true;
                } // Tutaj nastąpi automatyczne zwolnienie pióra
            }

            public override void Wymaz(Control Kontrolka, Graphics Rysownica)
            {
                // Sprawdzenie, czy Prostokat jest aktualnie wykreślony
                if (Widoczny)
                {
                    // Utworzenie Piora w kolorze tła kontrolki
                    using (Pen Pioro = new Pen(Kontrolka.BackColor, GruboscLinii))
                    {
                        // Ustawienie stylu Linii
                        Pioro.DashStyle = StylLinii;
                        // Wymazanie (wykreślenie w kolorze tła) Prostokata 
                        Rysownica.DrawRectangle(Pioro, X, Y, Szerokosc, Wysokosc);
                        // Ustawienie nowego atrybutu widocznosci
                        Widoczny = false;
                    }
                } // Do if (Widoczny)
            }
        }

        public class Okrag : Elipsa
        {
            // Deklaracja konstruktora klasy Okrag
            public Okrag(int x, int y, int Promien, Color KolorLinii, DashStyle StylLinii, float GruboscLinii)
                : base(x, y, Promien * 2, Promien * 2, KolorLinii, StylLinii, GruboscLinii)
            {
                Figura = FiguraGeometryczna.Okrag;
            }
        }

        public class Kwadrat : Prostokat
        {
            // Deklaracja konstruktora klasy Kwadrat
            public Kwadrat(int x, int y, int Bok, Color KolorLinii, DashStyle StylLinii, float GruboscLinii)
                : base(x, y, Bok, Bok, KolorLinii, StylLinii, GruboscLinii)
            {
                Figura = FiguraGeometryczna.Kwadrat;
            }
        }


        public class ElipsaWypelnialna : Elipsa
        {
            // Deklaracja konstruktora klasy ElipsaWypelnialna
            public ElipsaWypelnialna(int x, int y, int OsDuza, int OsMala, Color KolorLinii, DashStyle StylLinii, float GruboscLinii, Color KolorTla)
                : base(x, y, OsDuza, OsMala, KolorLinii, StylLinii, GruboscLinii)
            {
                this.KolorTla = KolorTla;
                Figura = FiguraGeometryczna.Elipsa_Wypelnialna;
            }

            // Nadpisanie metody rysującej elipsę wypełnioną
            public override void Wykresl(Graphics Rysownica)
            {
                using (SolidBrush Pedzel = new SolidBrush(KolorTla))
                {
                    Rysownica.FillEllipse(Pedzel, X, Y, OsDuza, OsMala);
                }

                base.Wykresl(Rysownica); // Wywołanie metody z klasy bazowej do rysowania obramowania
            }

            // Nadpisanie metody wymazującej elipsę wypełnioną
            public override void Wymaz(Control Kontrolka, Graphics Rysownica)
            {
                // Sprawdzenie, czy ElipsaWypelnialna jest aktualnie wykreślona
                if (Widoczny)
                {
                    using (SolidBrush Pedzel = new SolidBrush(Kontrolka.BackColor))
                    {
                        // Wymazanie (wykreślenie w kolorze tła) Elipsy 
                        Rysownica.FillEllipse(Pedzel, X, Y, OsDuza, OsMala);
                    }

                    base.Wymaz(Kontrolka, Rysownica); // Wywołanie metody z klasy bazowej do wymazania obramowania
                }
            }
        }



     
    }
}