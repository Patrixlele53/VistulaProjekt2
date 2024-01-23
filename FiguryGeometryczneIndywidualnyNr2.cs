using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt2_Karwowski65859
{
    internal class FiguryGeometryczneIndywidualnyNr2
    {
        public class Punkt
        {
            const int pkDomyslnyRozmiarPunktu = 20;
            protected int pkX;
            protected int pkY;
            protected int pkGruboscLinii;
            protected Color pkKolor;
            protected bool pkWidoczny; // true - widoczny, false - nie

            protected Color pkKolorTla;
            protected DashStyle pkStylLinii;


            public Punkt(int pkx, int pky)
            {
                //inicjowpkie pól(atrybutów) klasy Punkt na podstawie wartości parametrów aktualnych konstruktora
                pkX = pkx;
                pkY = pky;
                //wartości domyślne
                pkKolor = Color.Black;
                pkKolorTla = Color.White;
                pkStylLinii = DashStyle.Solid;
                pkGruboscLinii = pkDomyslnyRozmiarPunktu;
                pkWidoczny = false;
            }
            public Punkt(int pkx, int pky, Color pkKolor) : this(pkx, pky)
            //this (x, y) to przekazpkie parametrów do zadeklarowpkego konstruktora dwuargumentowego w tej samej klasie Punkt
            {
                //inicjowpkie pól(argumentów) klasy Punkt na podstawie wartości parametrów aktualnych konstruktora
                this.pkKolor = pkKolor;//wpispkie do pola egzemplarza klasy Punkt wartości trzeciego parametru tego konstruktora
            }
            public Punkt(int pkx, int pky, Color pkKolor, int pkRozmiarPunktu) : this(pkx, pky, pkKolor)
            //this (x, y) to przekazpkie parametrów do zadeklarowpkego konstruktora trzyargumentowego w tej samej klasie Punkt
            {
                //inicjowpkie pól(argumentów) klasy Punkt na podstawie wartości parametrów aktualnych konstruktora
                pkGruboscLinii = pkRozmiarPunktu;
            }
            public Punkt(int pkx, int pky, Color pkKolor, DashStyle pkStylLinii, int pkRozmiarPunktu) : this(pkx, pky, pkKolor)
            {
                //inicjowpkie pól(argumentów) klasy Punkt na podstawie wartości parametrów aktualnych konstruktora
                this.pkStylLinii = pkStylLinii;
                pkGruboscLinii = pkRozmiarPunktu;
            }
            /*public Point Lokalizacja
            {
                get { return new Point(X, Y); }
                set {  new Point(X, Y); }
            }*/
            public virtual void UaktualnijXY(int pkx, int pky)
            {
                this.pkX = pkx;
                this.pkY = pky;
            }
            //przeciążenie metody: UaktualnijXY() dla innego sposobu przekazywpkia argumentów
            public virtual void UaktualnijXY(Point pkNowaLokalizacja)
            {
                pkX = pkNowaLokalizacja.X;
                pkY = pkNowaLokalizacja.Y;
            }
            public void UstalAtrubutyGraficzne(Color pkKolorLinii, DashStyle pkStylLinii, int pkGruboscLinii)
            {
                pkKolor = pkKolorLinii;
                this.pkStylLinii = pkStylLinii;
                this.pkGruboscLinii = pkGruboscLinii;
            }
            //przeciążenie metody UstalAtrubutyGraficzne()
            public void UstalAtrubutyGraficzne(Color pkKolortla)
            {
                this.pkKolorTla = pkKolortla;
            }
            protected void UStalStylLinii(DashStyle pkStylLinii)
            {
                this.pkStylLinii = pkStylLinii;
            }
            public virtual void Wykresl(Graphics pkRysownica)
            {
                //wykreslpkie punktu jako wypełnionego okręgu
                SolidBrush Pedzel = new SolidBrush(pkKolor);
                pkRysownica.FillEllipse(Pedzel, pkX - pkGruboscLinii / 2, pkY - pkGruboscLinii / 2, pkGruboscLinii, pkGruboscLinii);
                pkWidoczny = true;
                Pedzel.Dispose();
            }
            public virtual void Wymaz(Control pkKontrolka, Graphics pkRysownica)
            {
                if (this.pkWidoczny)
                {
                    //gdy punkt jest widoczny to mozemy go wykreslic
                    //wypełniony okrąg (elips) w kolorze tła kontrolki,
                    //na której został utworzony egzemplarz powierzchni graficznej
                    SolidBrush Pedzel = new SolidBrush(pkKontrolka.BackColor);
                    pkRysownica.FillEllipse(Pedzel, pkX - pkGruboscLinii / 2, pkY - pkGruboscLinii / 2, pkGruboscLinii, pkGruboscLinii);
                    pkWidoczny = false;
                    Pedzel.Dispose();
                }
            }
            public virtual void PrzesunDoNowegoXY(Control pkKontrolka, Graphics pkRysownica, Point pkNowaLokalizacja)
            {
                UaktualnijXY(pkNowaLokalizacja);
                Wykresl(pkRysownica);
            }
            //przeciążenie metody: PrzesunDoNowegoXY(), dla innego sposobu przekazywpkia parametrów
            public virtual void PrzesunDoNowegoXY(Control pkKontrolka, Graphics pkRysownica, int pkx, int pky)
            {
                UaktualnijXY(pkx, pky);
                Wykresl(pkRysownica);
            }
        }
        public class Linia : Punkt
        {
            //deklaracje dla przechowpkia współrzędnyc końca linii
            int pkXk, pkYk;//deklaracje prywatne, gdyż klasa nie będzie klasą bazową dla innych klas potomnych

            public Linia(int pkXp, int pkYp, int pkXk, int pkYk) : base(pkXp, pkYp)
            {
                this.pkXk = pkXk;
                this.pkYk = pkYk;
            }
            public Linia(int pkXp, int pkYp, int pkXk, int pkYk, Color pkKolorLinii, DashStyle pkStylLinii,
                         int pkGruboscLinii) : base(pkXp, pkYp, pkKolorLinii, pkStylLinii, pkGruboscLinii)
            {
                this.pkXk = pkXk;
                this.pkYk = pkYk;
            }
            public override void Wykresl(Graphics pkRysownica)
            {
                //deklaracja i utworzenie egzemplarza pióra oraz
                //ustawienie koloru linii i jej grubości
                Pen Pioro = new Pen(pkKolor, this.pkGruboscLinii);
                //ustawienie stylu linii
                Pioro.DashStyle = pkStylLinii;
                //Wykreślenie linii
                pkRysownica.DrawLine(Pioro, pkX, pkY, pkXk, pkYk);
                pkWidoczny = true; //linia została wykreślina
                Pioro.Dispose();//zwolnienie zasobów graficznych (Pióra)
            }
            public override void Wymaz(Control pkKontrolka, Graphics pkRysownica)
            {
                //gdy linia jest widoczna, to wymazujemy ją wykreślając "nową"
                //linię w kolorze tła kontrolki, na której został utworzony egzemplarz powierzchni graficznej
                if (pkWidoczny)
                {   //deklaracja i utworzenie egzemplarza pióra w kolorze tła
                    //kontrolki oraz ustawienie grubości i stylu linii
                    Pen Pioro = new Pen(pkKontrolka.BackColor, this.pkGruboscLinii);
                    //ustawienie stylu linii
                    Pioro.DashStyle = pkStylLinii;
                    //Wykreślenie linii
                    pkRysownica.DrawLine(Pioro, pkX, pkY, pkXk, pkYk);
                    pkWidoczny = false; //linia została wykreślina
                    Pioro.Dispose();//zwolnienie zasobów graficznych (Pióra)
                }
            }
            public override void PrzesunDoNowegoXY(Control pkKontrolka, Graphics pkRysownica, int pkx, int pky)
            {
                //deklaracja zmiennych dla wyznaczenia wektora przesunięcia
                int dx, dy;
                //wyznaczenie przyrostu zmipk współrzędnej X oraz Y
                if (pkx > pkX)
                    dx = pkx - pkX;
                else
                    dx = pkX - pkx;
                if (pky > pkY)
                    dy = pky - pkY;
                else
                    dy = pkY - pky;
                //zmipka (uaktualnienie) współrzędnej początku linii
                pkX = pkx;
                pkY = pky;
                //zmipka (uaktualnienie) współrzędnych końca linii tak, aby nie wychodziły
                //poza obszar powierzchni graficznej
                pkXk = (pkXk + dx) % pkKontrolka.Width;
                pkYk = (pkYk + dy) % pkKontrolka.Height;
                //wykreślenie linii o uaktualnionych współrzędnych początku i końca linii
                Wykresl(pkRysownica);
            }
        }
        public class Elipsa : Punkt
        {
            protected int pkOsDuza, pkOsMala;//oś duża i oś mała elipsy
            //deklaracje chronione, gdyż klasa Eklipsa jest klasą bazową dla klasy Okrąg

            public Elipsa(int pkx, int pky, int pkOsDuza, int pkOsMala) : base(pkx, pky)
            {
                this.pkOsDuza = pkOsDuza;
                this.pkOsMala = pkOsMala;
            }
            public Elipsa(int pkx, int pky, int pkOsDuza, int pkOsMala, Color pkKolorLinii, DashStyle pkStylLinii,
                          int pkGruboscLinii) : base(pkx, pky, pkKolorLinii, pkStylLinii, pkGruboscLinii)
            {
                this.pkOsDuza = pkOsDuza;
                this.pkOsMala = pkOsMala;
            }
            public override void Wykresl(Graphics pkRysownica)
            {
                //deklaracja i utworzenie egzemplarza pióra oraz ustawienie koloru linii i jej grubości
                Pen Pioro = new Pen(pkKolor, this.pkGruboscLinii);
                //formatowpkie pióra (gdzie zmienna: StylLinii jest zadeklarowpka w klasie bazowej Punkt)
                Pioro.DashStyle = pkStylLinii;
                //wykreślenie elipsy
                pkRysownica.DrawEllipse(Pioro, pkX, pkY, pkOsDuza, pkOsMala);
                pkWidoczny = true; //elipsa została wykreślina
                Pioro.Dispose(); //zwolnienie pióra
            }
            public override void Wymaz(Control pkKontrolka, Graphics pkRysownica)
            {
                //gdy elipsa jest widoczna, to wymazujemy ją wykreślając "nową"
                //elipsę w kolorze tła kontrolki, na której został utworzony egzemplarz powierzchni graficznej
                if (this.pkWidoczny)
                {
                    //deklaracja i utworzenie egzemplarza pióra w kolorze tła kontrolki
                    //oraz ustawienie grubości i stylu linii
                    Pen Pioro = new Pen(pkKontrolka.BackColor, this.pkGruboscLinii);
                    Pioro.DashStyle = pkStylLinii;
                    //wymazpkie elipsy (czyli wykreślenie elipsy w kolorze tła kontrolki
                    pkRysownica.DrawEllipse(Pioro, pkX, pkY, pkOsDuza, pkOsMala);
                    pkWidoczny = false;
                    Pioro.Dispose();
                }
            }
        }
        public class Okrag : Elipsa
        {
            protected int pkPromien;
            //deklaracja chroniona, gdyż klasa Okrąg może być klasą bazową dla innych klas potomnych (takich jak łuk okręgu)
            //czyli dla innych figur geometrycznych

            public Okrag(int pkx, int pky, int pkPromien) : base(pkx, pky, 2 * pkPromien, 2 * pkPromien)
            {
                this.pkPromien = pkPromien;
            }
            public Okrag(int pkx, int pky, int pkPromien, Color pkKolorLinii, DashStyle pkStylLinii,
                         int pkGruboscLinii) : base(pkx, pky, 2 * pkPromien, 2 * pkPromien, pkKolorLinii, pkStylLinii, pkGruboscLinii)
            {
                this.pkPromien = pkPromien;
            }
            public override void Wymaz(Control pkKontrolka, Graphics pkRysownica)
            {
                //gdy okrąg jest widoczny, to wymazujemy go wykreślając "nowy" okrąg w kolorze tła kontrolki, na
                //której został utworzony egzemplarz powierzchni graficznej
                if (this.pkWidoczny)
                {
                    //deklaracja i utworzenie egzemplarza pióra w kolorze tła kontrolki
                    //oraz ustawienie grubości i stylu linii
                    Pen Pioro = new Pen(pkKontrolka.BackColor, this.pkGruboscLinii);
                    Pioro.DashStyle = pkStylLinii;
                    //wymazpkie okręgu (czyli wykreślenie okręgu w kolorze tła kontrolki)
                    pkRysownica.DrawEllipse(Pioro, pkX, pkY, 2 * pkPromien, 2 * pkPromien);
                    pkWidoczny = false;
                    Pioro.Dispose();
                }
            }
        }
        //pozostałe deklaracje klas dla figur nieregularnych : prostokąt...

        //deklaracja klasy  dla linii ciągłej kreślonej myszą
        public class LiniaKreslonaMysza : Punkt
        {
            //deklaracja listy punktów linii ciągłej
            List<Point> pkListaPunktów = new List<Point>();
            //deklaracja konstruktorów klasy LiniaKreslonaMysza
            public LiniaKreslonaMysza(Point pkPoczątekLinii) : base(pkPoczątekLinii.X, pkPoczątekLinii.Y)
            {
                //dodpkie do listy punktów LiniaPunktów
                pkListaPunktów.Add(pkPoczątekLinii);
            }
            public LiniaKreslonaMysza(Point pkPunkt, Color pkKolor, DashStyle pkStylLinii, int pkGrubośćLinii)
                : base(pkPunkt.X, pkPunkt.Y, pkKolor, pkGrubośćLinii)
            {

            }

            //deklaracja metod
            public void DodajNowyPunktKreslonejLinii(Point pkNowyPunkt)
            {
                pkListaPunktów.Add(pkNowyPunkt);
            }
            public override void UaktualnijXY(int pkx, int pky)
            {
                if (pkListaPunktów.Count < 1)
                {
                    //lista jest pusta
                    return;
                }
                //realizacja operacji UaktualnijXY wymaga zmipky położenia wszystkich punktów wykreślonej linii
                //deklaracja zmiennych pomocniczych dla wyznaczenia przyrostu zmipk współrzędnej x oraz y
                int PrzyrostX = pkListaPunktów[0].X - pkx;
                int PrzyrostY = pkListaPunktów[0].Y - pky;
                //zmipka położenia wszystkich punktów linii kreślonej myszą
                for (int i = 0; i < pkListaPunktów.Count; i++)
                {
                    pkListaPunktów[i] = new Point(pkListaPunktów[i].X - PrzyrostX, pkListaPunktów[i].Y - PrzyrostY);
                }
            }
            public override void Wykresl(Graphics pkRysownica)
            {
                //deklaracjapomocniczej tablicy dla wpispkie wspłrzędnych wszystkich punktów wykreślinej linii myszą
                Point[] TablicaPunktów = new Point[pkListaPunktów.Count];
                //przepispkie współrzędnych wszystkich punktów wykreślinej linii myszą
                for (int i = 0; i < pkListaPunktów.Count; i++)
                    TablicaPunktów[i] = pkListaPunktów[i];
                //wykreślenie linii której współrzędne punktów są wpispke ddo tablicy TablicaPunktów
                Pen Pióro = new Pen(pkKolor, pkGruboscLinii);
                Pióro.DashStyle = pkStylLinii;
                //wykreślenie lini, w której współrzędne punktów są zapispke w TablicaPunktów
                pkRysownica.DrawLines(Pióro, TablicaPunktów);
            }
            public override void Wymaz(Control pkKontrolka, Graphics pkRysownica)
            {
                //deklaracjapomocniczej tablicy dla wpispkie wspłrzędnych wszystkich punktów wykreślinej linii myszą
                Point[] pkTablicaPunktów = new Point[pkListaPunktów.Count];
                //przepispkie współrzędnych wszystkich punktów wykreślinej linii myszą
                for (int pki = 0; pki < pkListaPunktów.Count; pki++)
                    pkTablicaPunktów[pki] = pkListaPunktów[pki];
                //deklaracja pióra do wymazywpkie
                Pen pkPióroGumka = new Pen(pkKontrolka.BackColor, pkGruboscLinii);
                pkPióroGumka.DashStyle = pkStylLinii;
                //wymazpkie lini, w której współrzędne punktów są zapispke w TablicaPunktów
                pkRysownica.DrawLines(pkPióroGumka, pkTablicaPunktów);
            }

            //deklaracja metod nadpisujących metody wirtualne klasy Punkt
        }
        public class Kwadrat : Linia
        {
            //zmienne wierzchołków kwadratu
            int pkXk, pkYk;
            public Kwadrat(int pkXp, int pkYp, int pkXk, int pkYk) : base(pkXp, pkYp, pkXk, pkYk)
            {
                this.pkXk = pkXk;
                this.pkYk = pkYk;
            }
            public Kwadrat(int pkXp, int pkYp, int pkXk, int pkYk, Color pkKolorLinii, DashStyle pkStylLinii,
                         int pkGruboscLinii) : base(pkXp, pkYp, pkXk, pkYk, pkKolorLinii, pkStylLinii, pkGruboscLinii)
            {
                this.pkXk = pkXk;
                this.pkYk = pkYk;
            }
            public override void Wykresl(Graphics pkRysownica)
            {
                //deklaracja i utworzenie egzemplarza pióra oraz
                //ustawienie koloru linii i jej grubości
                Pen Pioro = new Pen(pkKolor, this.pkGruboscLinii);
                //ustawienie stylu linii
                Pioro.DashStyle = pkStylLinii;
                //Wykreślenie linii
                pkRysownica.DrawRectangle(Pioro, pkX, pkY, pkXk, pkXk);
                pkWidoczny = true; //kwadrat został wykreśliny
                Pioro.Dispose();//zwolnienie zasobów graficznych (Pióra)
            }
            public override void Wymaz(Control pkKontrolka, Graphics pkRysownica)
            {
                //gdy kwadrat jest widoczny, to wymazujemy go wykreślając "nowy"
                //kwadrat w kolorze tła kontrolki, na której został utworzony egzemplarz powierzchni graficznej
                if (pkWidoczny)
                {   //deklaracja i utworzenie egzemplarza pióra w kolorze tła
                    //kontrolki oraz ustawienie grubości i stylu linii kwadratu
                    Pen Pioro = new Pen(pkKontrolka.BackColor, this.pkGruboscLinii);
                    //ustawienie stylu linii kwadratu
                    Pioro.DashStyle = pkStylLinii;
                    //Wykreślenie kwadratu
                    pkRysownica.DrawRectangle(Pioro, pkX, pkY, pkXk, pkXk);
                    pkWidoczny = false; //linia została wykreślina
                    Pioro.Dispose();//zwolnienie zasobów graficznych (Pióra)
                }
            }
            public override void PrzesunDoNowegoXY(Control pkKontrolka, Graphics pkRysownica, int pkx, int pky)
            {
                //deklaracja zmiennych dla wyznaczenia wektora przesunięcia
                int dx, dy;
                //wyznaczenie przyrostu zmipk współrzędnej X oraz Y
                if (pkx > pkX)
                    dx = pkx - pkX;
                else
                    dx = pkX - pkx;
                if (pky > pkY)
                    dy = pky - pkY;
                else
                    dy = pkY - pky;
                //zmipka (uaktualnienie) współrzędnej początku kwadratu
                pkX = pkx;
                pkY = pky;
                //zmipka (uaktualnienie) współrzędnych końca linii tak, aby nie wychodziły
                //poza obszar powierzchni graficznej
                pkXk = (pkXk + dx) % pkKontrolka.Width;
                pkYk = (pkYk + dy) % pkKontrolka.Height;
                //wykreślenie linii o uaktualnionych współrzędnych początku i końca linii
                Wykresl(pkRysownica);
            }
        }
        public class Ośmiokąt : Punkt
        {
            public ushort pkLiczbaPunktowKontrolnych
            {
                get;
                set;
            }
            public List<Point> pkPunktyOśmiokąta = new List<Point>();
            int pkPromienPunktuKontrolnego = 5;

            Font pkFontOpisuPunktow = new Font("Arial", 8, FontStyle.Italic);

            public Ośmiokąt(Graphics pkRysownica, Pen pkPióro, Point pkXYpunktu) :
                base(pkXYpunktu.X, pkXYpunktu.Y, pkPióro.Color, pkPióro.DashStyle, (int)(pkPióro.Width))
            {
                pkPunktyOśmiokąta.Add(pkXYpunktu);
                using (SolidBrush Pędzel = new SolidBrush(pkPióro.Color))
                {
                    //pierwszy punkt
                    pkRysownica.FillEllipse(Pędzel, pkXYpunktu.X - pkPromienPunktuKontrolnego,
                        pkXYpunktu.Y - pkPromienPunktuKontrolnego, 2 * pkPromienPunktuKontrolnego, 2 * pkPromienPunktuKontrolnego);
                }
            }
            //deklaracja metody do dodawpkie kolejnych punktów kontrolnych
            public void DodajNowyPunktKontrolny(Point pkXYpunktu, Graphics pkRysownica)
            {
                pkPunktyOśmiokąta.Add(pkXYpunktu);
                using (SolidBrush Pędzel = new SolidBrush(Color.Red))
                {
                    Pędzel.Color = pkKolor;

                    pkRysownica.FillEllipse(Pędzel, pkXYpunktu.X - pkPromienPunktuKontrolnego,
                        pkXYpunktu.Y - pkPromienPunktuKontrolnego, 2 * pkPromienPunktuKontrolnego, 2 * pkPromienPunktuKontrolnego);

                }
                //sprawdzenie czy jest to już 8 punkt kontrolny
                if (pkPunktyOśmiokąta.Count == 8)
                    Wykresl(pkRysownica);
            }
            //nadpisywpkie metod
            public override void Wykresl(Graphics pkRysownica)
            {
                using (Pen Pióro = new Pen(pkKolor, pkGruboscLinii))
                {
                    Pióro.DashStyle = pkStylLinii;
                    //deklaracja i utworzenie egzemplarza tablicy dla punktóww kontrolnych
                    Point[] PunktyKontrolne = new Point[pkPunktyOśmiokąta.Count];
                    //przepispkie do tablicy  PunktyKontrolne wszystkich punktów z listy PunktyKontrolneKrzywejBeziera
                    for (ushort i = 0; i < pkPunktyOśmiokąta.Count; i++)
                    {
                        PunktyKontrolne[i] = new Point(pkPunktyOśmiokąta[i].X, pkPunktyOśmiokąta[i].Y);
                    }
                    //wykreślenie krzywej Beziera
                    pkRysownica.DrawPolygon(Pióro, PunktyKontrolne);
                    pkWidoczny = true;
                }

            }
            public override void Wymaz(Control pkKontrolka, Graphics pkRysownica)
            {
                if (pkWidoczny)
                {
                    using (Pen Pióro = new Pen(pkKontrolka.BackColor, pkGruboscLinii))
                    {
                        Pióro.DashStyle = pkStylLinii;
                        //deklaracja pomocniczej tablicy dla chwilowego przechowpkia współrzędnych 
                        //punktów kontrolnych Krzywej Beziera
                        Point[] PunktyŁampkejRysowpkie = new Point[pkPunktyOśmiokąta.Count];
                        for (int i = 0; i < pkPunktyOśmiokąta.Count; i++)
                        {
                            PunktyŁampkejRysowpkie[i] = new Point(pkPunktyOśmiokąta[i].X,
                                                                pkPunktyOśmiokąta[i].Y);
                        }
                        //wykreślenie krzywej beziera w kolorze tła, czyli jej wymazpkie
                        pkRysownica.DrawPolygon(Pióro, PunktyŁampkejRysowpkie);
                        pkWidoczny = false;
                    }

                }

            }
            public override void UaktualnijXY(int pkx, int pky)
            {
                //deklaracje dla wyznaczenia przyrostów zmipk wartości współrędnych X i Y
                int PrzyrostX = pkPunktyOśmiokąta[0].X - pkx;
                int PrzyrostY = pkPunktyOśmiokąta[0].Y - pky;
                //zmainy lokalizacji krzywej
                for (int i = 0; i < pkPunktyOśmiokąta.Count; i++)
                {
                    pkPunktyOśmiokąta[i] = new Point(pkPunktyOśmiokąta[i].X - PrzyrostX,
                                                                 pkPunktyOśmiokąta[i].Y - PrzyrostY);
                }
            }

        }
        public class FillOśmiokąt : Punkt
        {
            public ushort pkLiczbaPunktowKontrolnych//
            {
                get;
                set;
            }
            public List<Point> pkPunktyOśmiokąta = new List<Point>();
            int pkPromienPunktuKontrolnego = 5;

            Font pkFontOpisuPunktow = new Font("Arial", 8, FontStyle.Italic);

            public FillOśmiokąt(Graphics pkRysownica, Pen pkPióro, Point pkXYpunktu, SolidBrush pkPędzel) :
                base(pkXYpunktu.X, pkXYpunktu.Y, pkPióro.Color, pkPióro.DashStyle, (int)(pkPióro.Width))
            {
                pkPunktyOśmiokąta.Add(pkXYpunktu);


                //pierwszy punkt
                pkRysownica.FillEllipse(pkPędzel, pkXYpunktu.X - pkPromienPunktuKontrolnego,
                pkXYpunktu.Y - pkPromienPunktuKontrolnego, 2 * pkPromienPunktuKontrolnego, 2 * pkPromienPunktuKontrolnego);

            }
            //deklaracja metody do dodawpkie kolejnych punktów kontrolnych
            public void DodajNowyPunktKontrolny(Point pkXYpunktu, Graphics pkRysownica)
            {
                pkPunktyOśmiokąta.Add(pkXYpunktu);
                using (SolidBrush pkPędzel = new SolidBrush(Color.Red))
                {
                    pkPędzel.Color = pkKolor;

                    pkRysownica.FillEllipse(pkPędzel, pkXYpunktu.X - pkPromienPunktuKontrolnego,
                        pkXYpunktu.Y - pkPromienPunktuKontrolnego, 2 * pkPromienPunktuKontrolnego, 2 * pkPromienPunktuKontrolnego);

                }
                //sprawdzenie czy jest to już 8 punkt kontrolny
                if (pkPunktyOśmiokąta.Count == 8)
                    Wykresl(pkRysownica);
            }
            //nadpisywpkie metod
            public override void Wykresl(Graphics pkRysownica)
            {
                using (SolidBrush pkPędzel = new SolidBrush(pkKolor))
                {

                    //deklaracja i utworzenie egzemplarza tablicy dla punktóww kontrolnych
                    Point[] pkPunktyKontrolne = new Point[pkPunktyOśmiokąta.Count];
                    //przepispkie do tablicy  PunktyKontrolne wszystkich punktów z listy PunktyKontrolneKrzywejBeziera
                    for (ushort pki = 0; pki < pkPunktyOśmiokąta.Count; pki++)
                    {
                        pkPunktyKontrolne[pki] = new Point(pkPunktyOśmiokąta[pki].X, pkPunktyOśmiokąta[pki].Y);
                    }
                    //wykreślenie krzywej Beziera
                    pkRysownica.FillPolygon(pkPędzel, pkPunktyKontrolne);
                    pkWidoczny = true;
                }

            }
            public override void Wymaz(Control Kontrolka, Graphics Rysownica)
            {
                if (pkWidoczny)
                {
                    using (SolidBrush pkPędzel = new SolidBrush(Kontrolka.BackColor))
                    {

                        //deklaracja i utworzenie egzemplarza tablicy dla punktóww kontrolnych
                        Point[] pkPunktyKontrolne = new Point[pkPunktyOśmiokąta.Count];
                        //przepispkie do tablicy  PunktyKontrolne wszystkich punktów z listy PunktyKontrolneKrzywejBeziera
                        for (ushort pki = 0; pki < pkPunktyOśmiokąta.Count; pki++)
                        {
                            pkPunktyKontrolne[pki] = new Point(pkPunktyOśmiokąta[pki].X, pkPunktyOśmiokąta[pki].Y);
                        }
                        //wykreślenie krzywej Beziera
                        Rysownica.FillPolygon(pkPędzel, pkPunktyKontrolne);
                        pkWidoczny = false;
                    }

                }

            }
            public override void UaktualnijXY(int pkx, int pky)
            {
                //deklaracje dla wyznaczenia przyrostów zmipk wartości współrędnych X i Y
                int pkPrzyrostX = pkPunktyOśmiokąta[0].X - pkx;
                int pkPrzyrostY = pkPunktyOśmiokąta[0].Y - pky;
                //zmainy lokalizacji krzywej
                for (int pki = 0; pki < pkPunktyOśmiokąta.Count; pki++)
                {
                    pkPunktyOśmiokąta[pki] = new Point(pkPunktyOśmiokąta[pki].X - pkPrzyrostX,
                                                                 pkPunktyOśmiokąta[pki].Y - pkPrzyrostY);
                }
            }

        }
        public class Prostokąt : Kwadrat
        {
            //zmienne wierzchołków kwadratu
            int pkXk, pkYk;
            public Prostokąt(int pkXp, int pkYp, int pkXk, int pkYk) : base(pkXp, pkYp, pkXk, pkYk)
            {
                this.pkXk = pkXk;
                this.pkYk = pkYk;
            }
            public Prostokąt(int pkXp, int pkYp, int pkXk, int pkYk, Color pkKolorLinii, DashStyle pkStylLinii,
                         int pkGruboscLinii) : base(pkXp, pkYp, pkXk, pkYk, pkKolorLinii, pkStylLinii, pkGruboscLinii)
            {
                this.pkXk = pkXk;
                this.pkYk = pkYk;
            }
            public override void Wykresl(Graphics pkRysownica)
            {
                //deklaracja i utworzenie egzemplarza pióra oraz
                //ustawienie koloru linii i jej grubości
                Pen pkPioro = new Pen(pkKolor, this.pkGruboscLinii);
                //ustawienie stylu linii
                pkPioro.DashStyle = pkStylLinii;
                //Wykreślenie linii
                pkRysownica.DrawRectangle(pkPioro, pkX, pkY, pkXk, pkYk);
                pkWidoczny = true; //kwadrat został wykreśliny
                pkPioro.Dispose();//zwolnienie zasobów graficznych (Pióra)
            }
            public override void Wymaz(Control pkKontrolka, Graphics pkRysownica)
            {
                //gdy kwadrat jest widoczny, to wymazujemy go wykreślając "nowy"
                //kwadrat w kolorze tła kontrolki, na której został utworzony egzemplarz powierzchni graficznej
                if (pkWidoczny)
                {   //deklaracja i utworzenie egzemplarza pióra w kolorze tła
                    //kontrolki oraz ustawienie grubości i stylu linii kwadratu
                    Pen pkPioro = new Pen(pkKontrolka.BackColor, this.pkGruboscLinii);
                    //ustawienie stylu linii kwadratu
                    pkPioro.DashStyle = pkStylLinii;
                    //Wykreślenie kwadratu
                    pkRysownica.DrawLine(pkPioro, pkX, pkY, pkXk, pkYk);
                    pkWidoczny = false; //linia została wykreślina
                    pkPioro.Dispose();//zwolnienie zasobów graficznych (Pióra)
                }
            }
            public override void PrzesunDoNowegoXY(Control pkKontrolka, Graphics pkRysownica, int pkx, int pky)
            {
                //deklaracja zmiennych dla wyznaczenia wektora przesunięcia
                int pkdx, pkdy;
                //wyznaczenie przyrostu zmipk współrzędnej X oraz Y
                if (pkx > pkX)
                    pkdx = pkx - pkX;
                else
                    pkdx = pkX - pkx;
                if (pky > pkY)
                    pkdy = pky - pkY;
                else
                    pkdy = pkY - pky;
                //zmipka (uaktualnienie) współrzędnej początku kwadratu
                pkX = pkx;
                pkY = pky;
                //zmipka (uaktualnienie) współrzędnych końca linii tak, aby nie wychodziły
                //poza obszar powierzchni graficznej
                pkXk = (pkXk + pkdx) % pkKontrolka.Width;
                pkYk = (pkYk + pkdy) % pkKontrolka.Height;
                //wykreślenie linii o uaktualnionych współrzędnych początku i końca linii
                Wykresl(pkRysownica);
            }
        }
        public class Koło : Okrag
        {

            //deklaracja chroniona, gdyż klasa Okrąg może być klasą bazową dla innych klas potomnych (takich jak łuk okręgu)
            //czyli dla innych figur geometrycznych

            public Koło(int pkx, int pky, int pkPromien) : base(pkx, pky, pkPromien)
            {
                this.pkPromien = pkPromien;
            }
            public Koło(int pkx, int pky, int pkPromien, Color pkKolorLinii, DashStyle pkStylLinii,
                         int pkGruboscLinii) : base(pkx, pky, pkPromien, pkKolorLinii, pkStylLinii,
                          pkGruboscLinii)
            {
                this.pkPromien = pkPromien;
            }
            public override void Wymaz(Control pkKontrolka, Graphics pkRysownica)
            {
                //gdy okrąg jest widoczny, to wymazujemy go wykreślając "nowy" okrąg w kolorze tła kontrolki, na
                //której został utworzony egzemplarz powierzchni graficznej
                if (this.pkWidoczny)
                {
                    //deklaracja i utworzenie egzemplarza pióra w kolorze tła kontrolki
                    //oraz ustawienie grubości i stylu linii
                    SolidBrush pkPędzel = new SolidBrush(pkKontrolka.BackColor);
                    //wymazpkie okręgu (czyli wykreślenie okręgu w kolorze tła kontrolki)
                    pkRysownica.FillEllipse(pkPędzel, pkX, pkY, 2 * pkPromien, 2 * pkPromien);
                    pkWidoczny = false;
                    pkPędzel.Dispose();
                }
            }
            public override void Wykresl(Graphics pkRysownica)
            {
                //deklaracja i utworzenie egzemplarza pióra oraz ustawienie koloru linii i jej grubości
                SolidBrush pkPędzel = new SolidBrush(pkKolorTla);
                //formatowpkie pióra (gdzie zmienna: StylLinii jest zadeklarowpka w klasie bazowej Punkt)
                //wykreślenie elipsy
                pkRysownica.FillEllipse(pkPędzel, pkX, pkY, pkOsDuza, pkOsMala);
                pkWidoczny = true; //elipsa została wykreślina
                pkPędzel.Dispose(); //zwolnienie pióra
            }
        }
        public class PełnyKwadrat : Linia
        {
            //zmienne wierzchołków kwadratu
            int pkXk, pkYk;
            public PełnyKwadrat(int pkXp, int pkYp, int pkXk, int pkYk) : base(pkXp, pkYp, pkXk, pkYk)
            {
                this.pkXk = pkXk;
                this.pkYk = pkYk;
            }
            public PełnyKwadrat(int pkXp, int pkYp, int pkXk, int pkYk, Color pkKolorLinii, DashStyle pkStylLinii,
                         int pkGruboscLinii) : base(pkXp, pkYp, pkXk, pkYk, pkKolorLinii, pkStylLinii, pkGruboscLinii)
            {
                this.pkXk = pkXk;
                this.pkYk = pkYk;
            }
            public override void Wykresl(Graphics pkRysownica)
            {
                //deklaracja i utworzenie egzemplarza pióra oraz
                //ustawienie koloru linii i jej grubości
                SolidBrush pkPędzel = new SolidBrush(pkKolor);
                //Wykreślenie linii
                pkRysownica.FillRectangle(pkPędzel, pkX, pkY, pkXk, pkYk);
                pkWidoczny = true; //kwadrat został wykreśliny
                pkPędzel.Dispose();//zwolnienie zasobów graficznych (Pióra)
            }
            public override void Wymaz(Control pkKontrolka, Graphics pkRysownica)
            {
                //gdy kwadrat jest widoczny, to wymazujemy go wykreślając "nowy"
                //kwadrat w kolorze tła kontrolki, na której został utworzony egzemplarz powierzchni graficznej
                if (pkWidoczny)
                {   //deklaracja i utworzenie egzemplarza pióra w kolorze tła
                    //kontrolki oraz ustawienie grubości i stylu linii kwadratu
                    SolidBrush pkPędzel = new SolidBrush(pkKolor);
                    //Wykreślenie linii
                    pkRysownica.FillRectangle(pkPędzel, pkX, pkY, pkXk, pkYk);
                    pkWidoczny = false; //linia została wykreślina
                    pkPędzel.Dispose();//zwolnienie zasobów graficznych (Pióra)
                }
            }
            public override void PrzesunDoNowegoXY(Control pkKontrolka, Graphics pkRysownica, int pkx, int pky)
            {
                //deklaracja zmiennych dla wyznaczenia wektora przesunięcia
                int pkdx, pkdy;
                //wyznaczenie przyrostu zmipk współrzędnej X oraz Y
                if (pkx > pkX)
                    pkdx = pkx - pkX;
                else
                    pkdx = pkX - pkx;
                if (pky > pkY)
                    pkdy = pky - pkY;
                else
                    pkdy = pkY - pky;
                //zmipka (uaktualnienie) współrzędnej początku kwadratu
                pkX = pkx;
                pkY = pky;
                //zmipka (uaktualnienie) współrzędnych końca linii tak, aby nie wychodziły
                //poza obszar powierzchni graficznej
                pkXk = (pkXk + pkdx) % pkKontrolka.Width;
                pkYk = (pkYk + pkdy) % pkKontrolka.Height;
                //wykreślenie linii o uaktualnionych współrzędnych początku i końca linii
                Wykresl(pkRysownica);
            }
        }
        public class KrzywaBeziera : Punkt
        {
            public List<Point> pkPunktyKontrolneKrzywejBeziera = new List<Point>();
            int pkPromienPunktuKontrolnego = 5;
            public ushort pkLiczbaPunktowKontrolnych//
            {
                get;
                set;
            }

            Font pkFontOpisuPunktow = new Font("Arial", 8, FontStyle.Italic);
            /* public KrzywaBeziera(Graphics Rysownica, Pen Pióro, Point XYpunktu) :
                 base(XYpunktu.X, XYpunktu.Y, Pióro.Color, (int)(Pióro.Width))
             {
                 PunktyKontrolneKrzywejBeziera.Add(XYpunktu);
                 using (SolidBrush Pędzel = new SolidBrush(Pióro.Color))
                 {
                     //pierwszy punkt
                     Rysownica.FillEllipse(Pędzel, XYpunktu.X - PromienPunktuKontrolnego,
                         XYpunktu.Y - PromienPunktuKontrolnego, 2 * PromienPunktuKontrolnego, 2 * PromienPunktuKontrolnego);
                     Rysownica.DrawString("P" + (PunktyKontrolneKrzywejBeziera.Count - 1).ToString(),
                         FontOpisuPunktow, Pędzel, PunktyKontrolneKrzywejBeziera[PunktyKontrolneKrzywejBeziera.Count - 1]);
                 }
             }*/
            public KrzywaBeziera(Graphics pkRysownica, Pen pkPióro, Point pkXYpunktu) :
                base(pkXYpunktu.X, pkXYpunktu.Y, pkPióro.Color, pkPióro.DashStyle, (int)(pkPióro.Width))
            {
                pkPunktyKontrolneKrzywejBeziera.Add(pkXYpunktu);
                using (SolidBrush pkPędzel = new SolidBrush(pkPióro.Color))
                {
                    //pierwszy punkt
                    pkRysownica.FillEllipse(pkPędzel, pkXYpunktu.X - pkPromienPunktuKontrolnego,
                        pkXYpunktu.Y - pkPromienPunktuKontrolnego, 2 * pkPromienPunktuKontrolnego, 2 * pkPromienPunktuKontrolnego);
                    pkRysownica.DrawString("P" + (pkPunktyKontrolneKrzywejBeziera.Count - 1).ToString(),
                        pkFontOpisuPunktow, pkPędzel, pkPunktyKontrolneKrzywejBeziera[pkPunktyKontrolneKrzywejBeziera.Count - 1]);
                }
            }
            //deklaracja metody do dodawpkie kolejnych punktów kontrolnych
            public virtual void DodajNowyPunktKontrolny(Point pkXYpunktu, Graphics pkRysownica)
            {
                pkPunktyKontrolneKrzywejBeziera.Add(pkXYpunktu);
                using (SolidBrush pkPędzel = new SolidBrush(Color.Red))
                {
                    //pierwszy punkt
                    if (pkPunktyKontrolneKrzywejBeziera.Count == 1 || pkPunktyKontrolneKrzywejBeziera.Count == 4)
                    {
                        pkPędzel.Color = pkKolor;
                    }
                    pkRysownica.FillEllipse(pkPędzel, pkXYpunktu.X - pkPromienPunktuKontrolnego,
                        pkXYpunktu.Y - pkPromienPunktuKontrolnego, 2 * pkPromienPunktuKontrolnego, 2 * pkPromienPunktuKontrolnego);
                    pkRysownica.DrawString("P" + (pkPunktyKontrolneKrzywejBeziera.Count - 1).ToString(),
                        pkFontOpisuPunktow, pkPędzel, pkPunktyKontrolneKrzywejBeziera[pkPunktyKontrolneKrzywejBeziera.Count - 1]);
                }
                //sprawdzenie czy jest to już 4 punkt kontrolny
                if (pkPunktyKontrolneKrzywejBeziera.Count == 4)
                    Wykresl(pkRysownica);
            }
            //nadpisywpkie metod
            public override void Wykresl(Graphics pkRysownica)
            {
                using (Pen pkPióro = new Pen(pkKolor, pkGruboscLinii))
                {
                    pkPióro.DashStyle = pkStylLinii;
                    //deklaracja i utworzenie egzemplarza tablicy dla punktóww kontrolnych
                    Point[] pkPunktyKontrolne = new Point[pkPunktyKontrolneKrzywejBeziera.Count];
                    //przepispkie do tablicy  PunktyKontrolne wszystkich punktów z listy PunktyKontrolneKrzywejBeziera
                    for (ushort pki = 0; pki < pkPunktyKontrolneKrzywejBeziera.Count; pki++)
                    {
                        pkPunktyKontrolne[pki] = new Point(pkPunktyKontrolneKrzywejBeziera[pki].X, pkPunktyKontrolneKrzywejBeziera[pki].Y);
                    }
                    //wykreślenie krzywej Beziera
                    pkRysownica.DrawBezier(pkPióro, pkPunktyKontrolne[0], pkPunktyKontrolne[1],
                                                pkPunktyKontrolne[2], pkPunktyKontrolne[3]);
                    pkWidoczny = true;
                }

            }
            public override void Wymaz(Control pkKontrolka, Graphics pkRysownica)
            {
                if (pkWidoczny)
                {
                    using (Pen pkPióro = new Pen(pkKontrolka.BackColor, pkGruboscLinii))
                    {
                        pkPióro.DashStyle = pkStylLinii;
                        //deklaracja pomocniczej tablicy dla chwilowego przechowpkia współrzędnych 
                        //punktów kontrolnych Krzywej Beziera
                        Point[] pkPunktyKrzywejBeziera = new Point[pkPunktyKontrolneKrzywejBeziera.Count];
                        for (int pki = 0; pki < pkPunktyKontrolneKrzywejBeziera.Count; pki++)
                        {
                            pkPunktyKrzywejBeziera[pki] = new Point(pkPunktyKontrolneKrzywejBeziera[pki].X,
                                                                pkPunktyKontrolneKrzywejBeziera[pki].Y);
                        }
                        //wykreślenie krzywej beziera w kolorze tła, czyli jej wymazpkie
                        pkRysownica.DrawBezier(pkPióro, pkPunktyKrzywejBeziera[0], pkPunktyKrzywejBeziera[1],
                                                pkPunktyKrzywejBeziera[2], pkPunktyKrzywejBeziera[3]);
                        pkWidoczny = false;
                    }

                }

            }
            public override void UaktualnijXY(int pkx, int pky)
            {
                //deklaracje dla wyznaczenia przyrostów zmipk wartości współrędnych X i Y
                int PrzyrostX = pkPunktyKontrolneKrzywejBeziera[0].X - pkx;
                int PrzyrostY = pkPunktyKontrolneKrzywejBeziera[0].Y - pky;
                //zmainy lokalizacji krzywej
                for (int pki = 0; pki < pkPunktyKontrolneKrzywejBeziera.Count; pki++)
                {
                    pkPunktyKontrolneKrzywejBeziera[pki] = new Point(pkPunktyKontrolneKrzywejBeziera[pki].X - PrzyrostX,
                                                                 pkPunktyKontrolneKrzywejBeziera[pki].Y - PrzyrostY);
                }
            }

        }
        public class Lamana : Punkt
        {
            public ushort pkLiczbaPunktowKontrolnych//
            {
                get;
                set;
            }
            public List<Point> pkPunktyŁampkej = new List<Point>();
            int pkPromienPunktuKontrolnego = 5;

            Font pkFontOpisuPunktow = new Font("Arial", 8, FontStyle.Italic);

            public Lamana(Graphics pkRysownica, Pen pkPióro, Point pkXYpunktu) :
                base(pkXYpunktu.X, pkXYpunktu.Y, pkPióro.Color, pkPióro.DashStyle, (int)(pkPióro.Width))
            {
                pkPunktyŁampkej.Add(pkXYpunktu);
                using (SolidBrush pkPędzel = new SolidBrush(pkPióro.Color))
                {
                    //pierwszy punkt
                    pkRysownica.FillEllipse(pkPędzel, pkXYpunktu.X - pkPromienPunktuKontrolnego,
                        pkXYpunktu.Y - pkPromienPunktuKontrolnego, 2 * pkPromienPunktuKontrolnego, 2 * pkPromienPunktuKontrolnego);
                }
            }
            //deklaracja metody do dodawpkie kolejnych punktów kontrolnych
            public void DodajNowyPunktKontrolny(Point pkXYpunktu, Graphics pkRysownica)
            {
                pkPunktyŁampkej.Add(pkXYpunktu);
                using (SolidBrush pkPędzel = new SolidBrush(Color.Red))
                {
                    pkPędzel.Color = pkKolor;

                    pkRysownica.FillEllipse(pkPędzel, pkXYpunktu.X - pkPromienPunktuKontrolnego,
                        pkXYpunktu.Y - pkPromienPunktuKontrolnego, 2 * pkPromienPunktuKontrolnego, 2 * pkPromienPunktuKontrolnego);

                }
                //sprawdzenie czy jest to już 6 punkt kontrolny
                if (pkPunktyŁampkej.Count == 6)
                    Wykresl(pkRysownica);
            }
            //nadpisywpkie metod
            public override void Wykresl(Graphics pkRysownica)
            {
                using (Pen pkPióro = new Pen(pkKolor, pkGruboscLinii))
                {
                    pkPióro.DashStyle = pkStylLinii;
                    //deklaracja i utworzenie egzemplarza tablicy dla punktóww kontrolnych
                    Point[] pkPunktyKontrolne = new Point[pkPunktyŁampkej.Count];
                    //przepispkie do tablicy  PunktyKontrolne wszystkich punktów z listy PunktyKontrolneKrzywejBeziera
                    for (ushort pki = 0; pki < pkPunktyŁampkej.Count; pki++)
                    {
                        pkPunktyKontrolne[pki] = new Point(pkPunktyŁampkej[pki].X, pkPunktyŁampkej[pki].Y);
                    }
                    //wykreślenie krzywej Beziera
                    pkRysownica.DrawClosedCurve(pkPióro, pkPunktyKontrolne);
                    pkWidoczny = true;
                }

            }
            public override void Wymaz(Control pkKontrolka, Graphics pkRysownica)
            {
                if (pkWidoczny)
                {
                    using (Pen pkPióro = new Pen(pkKontrolka.BackColor, pkGruboscLinii))
                    {
                        pkPióro.DashStyle = pkStylLinii;
                        //deklaracja pomocniczej tablicy dla chwilowego przechowpkia współrzędnych 
                        //punktów kontrolnych Krzywej Beziera
                        Point[] pkPunktyŁampkejRysowpkie = new Point[pkPunktyŁampkej.Count];
                        for (int pki = 0; pki < pkPunktyŁampkej.Count; pki++)
                        {
                            pkPunktyŁampkejRysowpkie[pki] = new Point(pkPunktyŁampkej[pki].X,
                                                                pkPunktyŁampkej[pki].Y);
                        }
                        //wykreślenie krzywej beziera w kolorze tła, czyli jej wymazpkie
                        pkRysownica.DrawPolygon(pkPióro, pkPunktyŁampkejRysowpkie);
                        pkWidoczny = false;
                    }

                }

            }
            public override void UaktualnijXY(int pkx, int pky)
            {
                //deklaracje dla wyznaczenia przyrostów zmipk wartości współrędnych X i Y
                int pkPrzyrostX = pkPunktyŁampkej[0].X - pkx;
                int pkPrzyrostY = pkPunktyŁampkej[0].Y - pky;
                //zmainy lokalizacji krzywej
                for (int pki = 0; pki < pkPunktyŁampkej.Count; pki++)
                {
                    pkPunktyŁampkej[pki] = new Point(pkPunktyŁampkej[pki].X - pkPrzyrostX,
                                                                 pkPunktyŁampkej[pki].Y - pkPrzyrostY);
                }
            }


        }

    }
}
