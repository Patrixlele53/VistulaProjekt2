using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using static Projekt2_Karwowski65859.FiguryGeometryczneIndywidualnyNr2;
using System.Windows.Forms;

namespace Projekt2_Karwowski65859
{
    public partial class pkProjektIndywidualnyNr2 : Form
    {

        //deklaracje stałych pomocniczych
        const int pkMarginesFormularza = 2; //odstęp krawędzi formularza np. krawędzi ekranu fizycznego
        const int pkMargines = 10; // odstęp od krawędzi kontrolki PictureBox
        // deklaracja powierzchni graficznej 
        Graphics pkRysownica;
        // utworzenie tymczasowej rysownicy na powierzchni PictureBox
        Graphics pkRysownicaTymczasowa;
        //deklaracja Punktu, któremu przypiszemy współrzędne (x, y) przy naciśnięciu lewego przycisku myszy
        Point pkPunktXY;
        //deklaracja pióra
        Pen pkPioro;
        //deklaracja koloru figur geometrycznych
        Color pkKolor = Color.Black;
        Color pkKolorWypelnienia = Color.White;
        //deklaracja pędzla
        SolidBrush pkPedzel;
        //deklaracja pióra do kreślenia po powierzchni tymczasowej
        Pen pkPioroTymczasowe;

        //lista ewidencji egzemplarzy kreślonych fiur geometrycznych
        List<Punkt> pkLFG = new List<Punkt>();

       
        public pkProjektIndywidualnyNr2()
        {
            InitializeComponent();
            //lokalizacja i zwymiarowanie formularza
            this.Location =
                new Point(Screen.PrimaryScreen.Bounds.X + pkMarginesFormularza,
                          Screen.PrimaryScreen.Bounds.Y + pkMarginesFormularza);
            this.Width = (int)(Screen.PrimaryScreen.Bounds.Width * 0.85f);
            this.Height = (int)(Screen.PrimaryScreen.Bounds.Height * 0.85f);
            //lokalizacja i zwymiarowanie formularza według podanych ustawień
            this.StartPosition = FormStartPosition.Manual;

            pkPbRysownica.Location =
                new Point(Left + pkMargines, pkNaglowek.Height + pkMargines * 2);
            pkPbRysownica.Width = (int)(this.Width * 0.7f);
            pkPbRysownica.Height = (int)(this.Height * 0.6f);



            //ustawienie koloru tła kontrolki PictureBox
            pkPbRysownica.BackColor = Color.Beige;
            //ustalenie obramowania (Jedno wierszowe obramowanie) kontrolki PictureBox
            pkPbRysownica.BorderStyle = BorderStyle.FixedSingle;
            //utworzenie mapy bitowej i podpięcie jej do kontrolki PictureBox
            pkPbRysownica.Image = new Bitmap(pkPbRysownica.Width, pkPbRysownica.Height);
            //Lokalizacje pozostałyvh elementów
            pkNaglowek.Location =
                new Point(pkPbRysownica.Left + (pkPbRysownica.Width - pkNaglowek.Width) / 2, Top + pkMargines);
            pkGbFigury.Location =
                new Point(pkPbRysownica.Left + pkPbRysownica.Width + pkMargines, pkPbRysownica.Top);
            pkGbGrafika.Location =
                new Point(pkGbFigury.Left, pkGbFigury.Top + pkGbFigury.Height + pkMargines);
            pkStopka.Location = new Point((int)(pkPbRysownica.Width * 0.2), pkPbRysownica.Top + pkPbRysownica.Height + pkMargines);

            //lokalizacja btnPrzesunFiguryGeometryczne
            pkBtnPrzesunFiguryGeometryczne.Location = new Point(pkGbFigury.Location.X, pkGbFigury.Top - pkMargines * 5);

            //utworzenie egzemplarza powierzchni graficznej na BitMapie
            pkRysownica = Graphics.FromImage(pkPbRysownica.Image);
            //utworzenie egzemplarza tymczasowej powierzchni graficznej na kontrolce PictureBox
            pkRysownicaTymczasowa = pkPbRysownica.CreateGraphics();
            /* metoda CreateGraphics() klasy Control, jest dziedziczona przez wszystkie klasy 
               pochodne po klasie bazowej Control, a to oznacza, że egzemplarz powierzchni 
               graficznej możemy utowrzyć na dowolnej kontrolce, w tym na powierzchni kontrolki PictureBox 
             */

            //utworzenie egzemplarza pióra głównego
            pkPunktXY = Point.Empty;
            pkPioro = new Pen(Color.Black, 1F);
            pkPioro.DashStyle = DashStyle.Solid;
            pkPioro.StartCap = LineCap.Round; //zaokrąglenie na początku linii
            pkPioro.EndCap = LineCap.Round;   //zaokrąglenie na końcu linii
            //utworzenie egzemplarza pióra niebieskiego dla wizualizacji "rozciągania" kreślonej figury
            pkPioroTymczasowe = new Pen(Color.Black, 1);
            //utworzenie egzemplarza pędzla
            pkPedzel = new SolidBrush(pkKolorWypelnienia);
            pkRodzajLinii.SelectedIndex = 0;

        }



        private void pkProjektIndywidualnyNr2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //utworzeie okna dialogowego z odwpoeidnim pytaniem
            DialogResult OknoDialogowe = MessageBox.Show("czy chcesz zamknac ten formularz i wrocic do formularza glownego?",
                this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //rozpoznanie wybranego (kliknieciem) przycisku: Yes lub No
            if (OknoDialogowe == DialogResult.Yes)
            { //odszukanie formularza glownego w kolekcji OpenForms
                foreach (Form SzukanyFormularz in Application.OpenForms)
                    //sprawdzenie czy jest to formularz glowny 
                    if (SzukanyFormularz.Name == "KokpitNr2")
                    { //ukrycie biezacego formularza 
                        this.Hide();
                        //odsloniecie znalezionego formularza 
                        SzukanyFormularz.Show();
                        //Zakonczenie obslugi zdarzenia FormClicking 
                        return;
                    }
                //a gdy znajdziemy sie tutaj, to jest awaria !!!
                MessageBox.Show("AWARIA: Ktos usunal z kolekcji OpenForms " +
                    "egzemplarz formularza glownego i musi nastapic zamkniecie programu", this.Name, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //zamkniecie calego programu, lacznie z rownolegle dzialajacymi procesami rownoleglymi (zwanymi watkami)
                Application.ExitThread();


            }
            else
                //nie, nie! to przypadkowo
                e.Cancel = true;
        }


        private void pkBtnPowrot_Click_1(object sender, EventArgs e)
        {
            foreach (Form pkSzukanyFormularz in Application.OpenForms)
            {
                if (pkSzukanyFormularz.Name == "pkMainForm")
                {
                    Hide();
                    pkSzukanyFormularz.Show();
                    break;
                }
            }
        }

        private void pkRysownica_MouseDown(object sender, MouseEventArgs e)
        {
            //rozpoznanie czy obsługiwane zdarzenie jest spowodowane naciśnięciem lewego przycisku myszy
            if (e.Button == MouseButtons.Left)
            {//zapamiętanie współrzędnych punktu
                pkPunktXY = e.Location;
                pkPioro.Color = pkTxtKolorLinii.BackColor;
                pkPioro.DashStyle = WybranyStylLinii(pkRodzajLinii.SelectedIndex);
                pkPioro.Width = pkGruboscLinii.Value;
                //obsługa kontrolki dla kreślenia linii myszą
                if (pkLiniaCiagla.Checked)
                {//kontrolka została wybrana

                    //dodanie do LFG egzemplarza linii kreślnejmyszą
                    //LFG.Add(new LiniaKreslonaMysza(Punkt));
                    //wersja do uzupełnienia
                    pkPioro.Color = pkTxtKolorLinii.BackColor;
                    pkPioro.DashStyle = WybranyStylLinii(pkRodzajLinii.SelectedIndex);
                    pkPioro.Width = pkGruboscLinii.Value;
                    pkLFG.Add(new LiniaKreslonaMysza(pkPunktXY, pkPioro.Color, pkPioro.DashStyle, (int)pkPioro.Width));
                }

            }
        }

        DashStyle WybranyStylLinii(int i)
        {
            switch (i)
            {
                case 0:
                    return DashStyle.Solid;
                case 1:
                    return DashStyle.Dash;
                case 2:
                    return DashStyle.Dot;
                case 3:
                    return DashStyle.DashDot;
                case 4:
                    return DashStyle.DashDotDot;
                default:
                    return DashStyle.Solid;
            }
        }

        private void pkPbRysownica_MouseMove(object sender, MouseEventArgs e)
        {
            //wyświetlpkie aktualnego położenia myszy
            pkLblXY.Text = $"X={e.X}, Y={e.Y}";

            if (e.Button == MouseButtons.Left)
            {
                /* deklaracje zmiennych pomocniczych i wyznaczenie parametrów
               opisujących prostokąt, w którym będzie wykreślana figura geometryczna */
                int pkLewyGornyX =
                (pkPunktXY.X > e.Location.X) ? e.Location.X : pkPunktXY.X;
                int pkLewyGornyY =
                    (pkPunktXY.Y > e.Location.Y) ? e.Location.Y : pkPunktXY.Y;
                int pkSzerokosc = Math.Abs(pkPunktXY.X - e.Location.X);
                int pkWysokosc = Math.Abs(pkPunktXY.Y - e.Location.Y);

                if (pkPunkt.Checked)
                {
                    //punktu nie rozciągamy
                }
                if (pkLiniaProsta.Checked)
                {
                    //kreślenie linii na powierzchni tymczasowej
                    pkRysownicaTymczasowa.DrawLine(pkPioroTymczasowe, pkPunktXY.X, pkPunktXY.Y, e.Location.X, e.Location.Y);
                }
                if (pkLiniaCiagla.Checked)
                {
                    //rysowanie punktów
                    ((LiniaKreslonaMysza)pkLFG[pkLFG.Count - 1]).DodajNowyPunktKreslonejLinii(e.Location);
                }
                if (pkElipsa.Checked)
                {
                    pkRysownicaTymczasowa.DrawEllipse(pkPioroTymczasowe,
                        new Rectangle(pkLewyGornyX, pkLewyGornyY, pkSzerokosc, pkWysokosc));
                }
                if (pkOkrag.Checked)
                {
                    pkRysownicaTymczasowa.DrawEllipse(pkPioroTymczasowe,
                        new Rectangle(pkLewyGornyX, pkLewyGornyY, pkWysokosc, pkWysokosc));
                }
                if (pkKwadrat.Checked)
                {
                    pkRysownicaTymczasowa.DrawRectangle
                        (pkPioroTymczasowe, pkLewyGornyX, pkLewyGornyY, pkSzerokosc, pkSzerokosc);

                }
                if (pkProstokat.Checked)
                {
                    pkRysownicaTymczasowa.DrawRectangle
                        (pkPioroTymczasowe, pkLewyGornyX, pkLewyGornyY, pkSzerokosc, pkWysokosc);

                }
                if (pkKolo.Checked)
                {

                    pkRysownicaTymczasowa.FillEllipse(pkPedzel,
                        new Rectangle(pkLewyGornyX, pkLewyGornyY, pkWysokosc, pkWysokosc));
                }
                if (pkFillSquare.Checked)
                {
                    pkRysownicaTymczasowa.FillRectangle(pkPedzel,
                        new Rectangle(pkLewyGornyX, pkLewyGornyY, pkWysokosc, pkWysokosc));
                }

                //itd...

                //odświeżenie powierzchni graficznej
                pkPbRysownica.Refresh();
            }
        }

        private void pkPbRysownica_MouseUp(object sender, MouseEventArgs e)
        {
            /* deklaracje zmiennych pomocniczych i wyznaczenie parametrów
               opisujących prostokąt, w którym będzie wykreślana figura geometryczna */
            int pklewyGórnyNarożnikX =
            (pkPunktXY.X > e.Location.X) ? e.Location.X : pkPunktXY.X;
            int pklewyGórnyNarożnikY =
                (pkPunktXY.Y > e.Location.Y) ? e.Location.Y : pkPunktXY.Y;
            int pkSzerokość = Math.Abs(pkPunktXY.X - e.Location.X);
            int pkWysokość = Math.Abs(pkPunktXY.Y - e.Location.Y);
            //rozpoznanie, czy zdarzenie MouseUp dotyczy lewego przycisku myszy
            if (e.Button == MouseButtons.Left)
            {
                if (pkPunkt.Checked)
                {
                    //utworzenie egzemplarza i dodanie jego referencji do LFG
                    pkLFG.Add(new Punkt(pkPunktXY.X, pkPunktXY.Y));
                    //ustalenie atrybutów geometrycznych i graficznych punktu
                    pkLFG[pkLFG.Count - 1].UstalAtrubutyGraficzne(pkKolor, pkPioro.DashStyle, pkGruboscLinii.Value);
                    //wykreślenie punktu
                    pkLFG[pkLFG.Count - 1].Wykresl(pkRysownica);
                }
                if (pkLiniaProsta.Checked)
                {
                    //utowrzenie egzemplarza i dodanie jego referencji do LFG
                    pkLFG.Add(new Linia(pkPunktXY.X, pkPunktXY.Y, e.Location.X, e.Location.Y));
                    //ustalenie atrybutów geometrycznych i graficznych linii
                    pkLFG[pkLFG.Count - 1].UstalAtrubutyGraficzne(pkKolor, pkPioro.DashStyle, pkGruboscLinii.Value);
                    //wykreślenie linii
                    pkLFG[pkLFG.Count - 1].Wykresl(pkRysownica);
                }
                if (pkElipsa.Checked)
                {
                    //utowrzenie egzemplarza i dodanie jego referencji do LFG
                    pkLFG.Add(new Elipsa(pklewyGórnyNarożnikX, pklewyGórnyNarożnikY, pkSzerokość, pkWysokość));
                    //ustalenie atrybutów geometrycznych i graficznych elipsy
                    pkLFG[pkLFG.Count - 1].UstalAtrubutyGraficzne(pkKolor, pkPioro.DashStyle, pkGruboscLinii.Value);
                    //wykreślenie elipsy
                    pkLFG[pkLFG.Count - 1].Wykresl(pkRysownica);
                }
                if (pkOkrag.Checked)
                {
                    //utowrzenie egzemplarza i dodanie jego referencji do LFG
                    pkLFG.Add(new Okrag(pklewyGórnyNarożnikX, pklewyGórnyNarożnikY, pkSzerokość / 2));
                    //ustalenie atrybutów geometrycznych i graficznych okręgu
                    pkLFG[pkLFG.Count - 1].UstalAtrubutyGraficzne(pkKolor, pkPioro.DashStyle, pkGruboscLinii.Value);
                    //wykreślenie okręgu
                    pkLFG[pkLFG.Count - 1].Wykresl(pkRysownica);
                }
                if (pkLiniaCiagla.Checked)
                {
                    //dodanie do listy punktów linii kreślonej myszą współrzędnych ostatniego punktu
                    ((LiniaKreslonaMysza)pkLFG[pkLFG.Count - 1]).DodajNowyPunktKreslonejLinii(e.Location);
                    ((LiniaKreslonaMysza)pkLFG[pkLFG.Count - 1]).UstalAtrubutyGraficzne(pkKolor, pkPioro.DashStyle, pkGruboscLinii.Value);
                    //Rysownica.DrawCurve(Pioro, )//Rysownica.DrawLine(Pioro, Punkt, e.Location);
                    //uaktualnienie zapisu w zmiennej Punkt
                    pkPunktXY = e.Location;
                    pkLFG[pkLFG.Count - 1].Wykresl(pkRysownica);
                }
                if (pkKwadrat.Checked)
                {
                    //utowrzenie egzemplarza i dodanie jego referencji do LFG
                    pkLFG.Add(new Kwadrat(pklewyGórnyNarożnikX, pklewyGórnyNarożnikY, pkSzerokość, pkSzerokość));
                    //ustalenie atrybutów geometrycznych i graficznych okręgu
                    pkLFG[pkLFG.Count - 1].UstalAtrubutyGraficzne(pkKolor, pkPioro.DashStyle, pkGruboscLinii.Value);
                    //wykreślenie okręgu
                    pkLFG[pkLFG.Count - 1].Wykresl(pkRysownica);
                }
                if (pkProstokat.Checked)
                {
                    //utowrzenie egzemplarza i dodanie jego referencji do LFG
                    pkLFG.Add(new Prostokąt(pklewyGórnyNarożnikX, pklewyGórnyNarożnikY, pkSzerokość, pkWysokość));
                    //ustalenie atrybutów geometrycznych i graficznych okręgu
                    pkLFG[pkLFG.Count - 1].UstalAtrubutyGraficzne(pkKolor, pkPioro.DashStyle, pkGruboscLinii.Value);
                    //wykreślenie okręgu
                    pkLFG[pkLFG.Count - 1].Wykresl(pkRysownica);
                }
                if (pkKolo.Checked)
                {
                    pkLFG.Add(new Koło(pklewyGórnyNarożnikX, pklewyGórnyNarożnikY, pkSzerokość / 2));
                    pkLFG[pkLFG.Count - 1].UstalAtrubutyGraficzne(pkKolorWypelnienia);
                    pkLFG[pkLFG.Count - 1].Wykresl(pkRysownica);
                }
                if (pkFillSquare.Checked)
                {
                    pkLFG.Add(new PełnyKwadrat(pklewyGórnyNarożnikX, pklewyGórnyNarożnikY, pkSzerokość, pkSzerokość));
                    //ustalenie atrybutów geometrycznych i graficznych okręgu
                    pkLFG[pkLFG.Count - 1].UstalAtrubutyGraficzne(pkKolorWypelnienia, pkPioro.DashStyle, pkGruboscLinii.Value);
                    //wykreślenie okręgu
                    pkLFG[pkLFG.Count - 1].Wykresl(pkRysownica);
                }
                if (pkKrzywaBeziera.Checked)
                {
                    if (pkGbFigury.Enabled)
                    {//to jest pierwszy punkt: P0
                        //utworzenie egzemplarza klasy KrzywaBedziera i dodanie go do LFG
                        pkLFG.Add(new KrzywaBeziera(pkRysownica, pkPioro, pkPunktXY));
                        //ustawienie stanu braku aktywności dla kontenera z kontrolkami RadioButton,
                        //które są przypisane różntm figurom geometrycznym
                        pkGbFigury.Enabled = false;
                        //przypisanie wartości 0 dla początkowej wartości LiczbaPunktówKontrolnych,
                        //która jest zadeklarowana w klasie KrzywaBeziera
                        ((KrzywaBeziera)pkLFG[pkLFG.Count - 1]).pkLiczbaPunktowKontrolnych = 0;

                    }
                    else
                    {//dodanie nowego punktu kontrolnego
                        ((KrzywaBeziera)pkLFG[pkLFG.Count - 1]).DodajNowyPunktKontrolny(e.Location, pkRysownica);
                        ((KrzywaBeziera)pkLFG[pkLFG.Count - 1]).pkLiczbaPunktowKontrolnych++;
                        //sprawdzenie, czy jest to już punkt ostatni: P3
                        if (((KrzywaBeziera)pkLFG[pkLFG.Count - 1]).pkLiczbaPunktowKontrolnych == 3)
                        {
                            pkGbFigury.Enabled = true;
                            //wykreślenie krzywej Beziera
                            pkLFG[pkLFG.Count - 1].Wykresl(pkRysownica);
                        }
                    }
                }
                if (pkDrawClosedCurve.Checked)
                {
                    if (pkGbFigury.Enabled)
                    {//to jest pierwszy punkt: P0
                        //utworzenie egzemplarza klasy KrzywaBedziera i dodanie go do LFG
                        pkLFG.Add(new Lamana(pkRysownica, pkPioro, pkPunktXY));
                        //ustawienie stanu braku aktywności dla kontenera z kontrolkami RadioButton,
                        //które są przypisane różntm figurom geometrycznym
                        pkGbFigury.Enabled = false;
                        //przypisanie wartości 0 dla początkowej wartości LiczbaPunktówKontrolnych,
                        //która jest zadeklarowana w klasie KrzywaBeziera
                        ((Lamana)pkLFG[pkLFG.Count - 1]).pkLiczbaPunktowKontrolnych = 0;
                    }
                    else
                    {//ddodanie nowego punktu kontrolnego
                        ((Lamana)pkLFG[pkLFG.Count - 1]).DodajNowyPunktKontrolny(e.Location, pkRysownica);
                        ((Lamana)pkLFG[pkLFG.Count - 1]).pkLiczbaPunktowKontrolnych++;
                        //sprawdzenie, czy jest to już punkt ostatni: P3
                        if (((Lamana)pkLFG[pkLFG.Count - 1]).pkLiczbaPunktowKontrolnych == 5)
                        {
                            pkGbFigury.Enabled = true;
                            //wykreślenie krzywej Beziera
                            pkLFG[pkLFG.Count - 1].Wykresl(pkRysownica);
                        }
                    }
                }
                if (pkOsmiokat.Checked)
                {
                    if (pkGbFigury.Enabled)
                    {//to jest pierwszy punkt: P0
                        //utworzenie egzemplarza klasy KrzywaBedziera i dodanie go do LFG
                        pkLFG.Add(new Ośmiokąt(pkRysownica, pkPioro, pkPunktXY));
                        //ustawienie stanu braku aktywności dla kontenera z kontrolkami RadioButton,
                        //które są przypisane różntm figurom geometrycznym
                        pkGbFigury.Enabled = false;
                        //przypisanie wartości 0 dla początkowej wartości LiczbaPunktówKontrolnych,
                        //która jest zadeklarowana w klasie Ośmiokąt
                        ((Ośmiokąt)pkLFG[pkLFG.Count - 1]).pkLiczbaPunktowKontrolnych = 0;
                    }
                    else
                    {//ddodanie nowego punktu kontrolnego
                        ((Ośmiokąt)pkLFG[pkLFG.Count - 1]).DodajNowyPunktKontrolny(e.Location, pkRysownica);
                        ((Ośmiokąt)pkLFG[pkLFG.Count - 1]).pkLiczbaPunktowKontrolnych++;
                        //sprawdzenie, czy jest to już punkt ostatni: P7
                        if (((Ośmiokąt)pkLFG[pkLFG.Count - 1]).pkLiczbaPunktowKontrolnych == 7)
                        {
                            pkGbFigury.Enabled = true;
                            //wykreślenie Ośmiokąta
                            pkLFG[pkLFG.Count - 1].Wykresl(pkRysownica);
                        }
                    }
                }
                if (pkWypelnionyOsmiokat.Checked)
                {
                    if (pkGbFigury.Enabled)
                    {//to jest pierwszy punkt: P0
                        //utworzenie egzemplarza klasy KrzywaBedziera i dodanie go do LFG
                        pkLFG.Add(new FillOśmiokąt(pkRysownica, pkPioro, pkPunktXY, pkPedzel));
                        //ustawienie stanu braku aktywności dla kontenera z kontrolkami RadioButton,
                        //które są przypisane różntm figurom geometrycznym
                        pkGbFigury.Enabled = false;
                        pkLFG[pkLFG.Count - 1].UstalAtrubutyGraficzne(pkKolorWypelnienia, pkPioro.DashStyle, pkGruboscLinii.Value);
                        //przypisanie wartości 0 dla początkowej wartości LiczbaPunktówKontrolnych,
                        //która jest zadeklarowana w klasie Ośmiokąt
                        ((FillOśmiokąt)pkLFG[pkLFG.Count - 1]).pkLiczbaPunktowKontrolnych = 0;
                    }
                    else
                    {//ddodanie nowego punktu kontrolnego
                        ((FillOśmiokąt)pkLFG[pkLFG.Count - 1]).DodajNowyPunktKontrolny(e.Location, pkRysownica);
                        ((FillOśmiokąt)pkLFG[pkLFG.Count - 1]).pkLiczbaPunktowKontrolnych++;
                        //sprawdzenie, czy jest to już punkt ostatni: P7
                        if (((FillOśmiokąt)pkLFG[pkLFG.Count - 1]).pkLiczbaPunktowKontrolnych == 7)
                        {
                            pkGbFigury.Enabled = true;
                            //wykreślenie Ośmiokąta
                            pkLFG[pkLFG.Count - 1].Wykresl(pkRysownica);
                        }
                    }
                }

                //odświeżenie powierzchni graficznej
                pkPbRysownica.Refresh();
            }
        }

        private void pkBtnPrzesunFiguryGeometryczne_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            if (pkLFG.Count < 1)
            {
                errorProvider1.SetError(pkBtnPrzesunFiguryGeometryczne, "ERROR - Najpierw zrob jakas figure");
                return;
            }
            //wyczyszczenie powierzchni graficznej
            pkRysownica.Clear(pkPbRysownica.BackColor);
            //wyznaczenie rozmiarów powierzchni graficznej
            int anXmax = pkPbRysownica.Width, Ymax = pkPbRysownica.Height;
            //deklaracja i utworzenie egzemplarza generatora współżędnych 
            Random rnd = new Random();
            //losowe współżędne
            ushort anx, any;
            for (int ani = 0; ani < pkLFG.Count; ani++)
            {
                anx = (ushort)rnd.Next(pkMargines, anXmax - pkMargines);
                any = (ushort)rnd.Next(pkMargines, Ymax - pkMargines);
                pkLFG[ani].PrzesunDoNowegoXY(pkPbRysownica, pkRysownica, anx, any);
            }

            pkPbRysownica.Refresh();
        }

        private void pkBtnCofnijFigure_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            //sprawdzenia czy w liście LFG są umieszczone referencje do egzemplarzy figur geometrycznych
            if (pkLFG.Count <= 0)
            {
                errorProvider1.SetError(pkBtnCofnijFigure, "ERROR: Utworz najpierw jakas figure by ja cofnac");
                return;
            }
            //usunięcie ostatniego elementu listy
            pkLFG.RemoveAt(pkLFG.Count - 1);
            //ponowne odrysowanie rysownicy
            //wyczyszczenie powierzchni graficznej
            pkRysownica.Clear(pkPbRysownica.BackColor);
            for (int ani = 0; ani < pkLFG.Count; ani++)
            {
                pkLFG[ani].Wykresl(pkRysownica);
            }
            pkPbRysownica.Refresh();
        }

        private void pkBtnKolorLinii_Click(object sender, EventArgs e)
        {
            ColorDialog pkkolor = new ColorDialog();
            pkkolor.ShowDialog();
            pkKolor = pkkolor.Color;
            pkPioro.Color = pkkolor.Color;
            pkTxtKolorLinii.BackColor = pkkolor.Color;
            pkTxtKolorLinii.ReadOnly = true;
        }

        private void pkBtnKolorWypelnienia_Click(object sender, EventArgs e)
        {
            ColorDialog pkkolor = new ColorDialog();
            pkkolor.ShowDialog();
            pkPedzel.Color = pkkolor.Color;
            pkKolorWypelnienia = pkkolor.Color;
            pkTxtKolorWypelnienia.BackColor = pkkolor.Color;
            pkTxtKolorWypelnienia.ReadOnly = true;
        }

        private void pkBtnWlaczPrezentacje_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            int pkXmax = pkPbRysownica.Width;
            int pkYmax = pkPbRysownica.Height;

            pkRysownica.Clear(pkPbRysownica.BackColor);
            timer1.Tag = 0;
            pkTxtIndeks.Text = 0.ToString();

            if (pkLFG.Count < 1)
            {
                errorProvider1.SetError(pkBtnWylaczPrezentacje, "ERROR: Zrob najpierw jakas figure");
                return;
            }
            pkLFG[0].PrzesunDoNowegoXY(pkPbRysownica, pkRysownica, pkXmax / 2, pkYmax / 2);
            pkPbRysownica.Refresh();

            if (pkAutomatic.Checked)
            {
                //uaktywnienie zegara
                timer1.Enabled = true;
            }
            else
            { //stawienie stanu braku aktywności dla kontrolek slajdera manualnego
                pkNastepny.Enabled = true;
                pkPoprzedni.Enabled = true;
                pkTxtIndeks.Enabled = true;
            }
            pkBtnWlaczPrezentacje.Enabled = false;
            pkBtnWylaczPrezentacje.Enabled = true;

            //reszta kontrolek
            pkBtnPrzesunFiguryGeometryczne.Enabled = false;
            pkGbFigury.Enabled = false;
            pkBtnCofnijFigure.Enabled = false;
            pkBtnKolorLinii.Enabled = false;
            pkBtnKolorWypelnienia.Enabled = false;
            pkGruboscLinii.Enabled = false;
            pkRodzajLinii.Enabled = false;
            pkZapisz.Enabled = false;
            pkWczytaj.Enabled = false;
            pkBtnKolorTla.Enabled = false;

            if (pkManual.Checked)
            {
                pkAutomatic.Enabled = false;
            }
            else
            {
                pkManual.Enabled = false;
                pkNastepny.Enabled = false;
                pkPoprzedni.Enabled = false;
                pkTxtIndeks.Enabled = false;
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //wymazanie całej powierzchni graficznej
            pkRysownica.Clear(pkPbRysownica.BackColor);
            //wyznaczenie rozmiarów powierzchni graficznej
            int anXmax = pkPbRysownica.Width;
            int anYmax = pkPbRysownica.Height;
            //wpisanie do kontrolki slajder indeksu TFG pokazywanej figury
            pkTxtIndeks.Text = timer1.Tag.ToString();
            //wykreślenie figury o indeksie timer1.Tag w środku powierzchni graficznej
            pkLFG[(int)(timer1.Tag)].PrzesunDoNowegoXY(pkPbRysownica, pkRysownica, anXmax / 2, anYmax / 2);
            //odświeżenie pow. graficznej
            pkPbRysownica.Refresh();
            //ustawienie indeksu dla następnej figury do pokazu
            timer1.Tag = ((int)(timer1.Tag) + 1) % (pkLFG.Count);
        }

        private void pkBtnWylaczPrezentacje_Click(object sender, EventArgs e)
        {
            //wyczyszczenie rysownicy
            pkRysownica.Clear(pkPbRysownica.BackColor);
            //wyłączenie zegara
            timer1.Enabled = false;
            //ustawienie indeksu na 0
            pkTxtIndeks.Text = "";
            //uaktywnienie przycisku poleceń WączenieSlajdera
            pkBtnWlaczPrezentacje.Enabled = true;
            //ustawienie stanu braku aktywności dla przycisku btnWyłączenieSlajdera
            pkBtnWylaczPrezentacje.Enabled = false;
            //uaktywnienie/brak aktywności przycisków slajdera
            pkAutomatic.Checked = true;
            pkNastepny.Enabled = false;
            pkPoprzedni.Enabled = false;
            pkTxtIndeks.Enabled = false;
            //aktualizacja pozostalych kontrolek
            pkBtnPrzesunFiguryGeometryczne.Enabled = true;
            pkGbFigury.Enabled = true;
            pkBtnCofnijFigure.Enabled = true;
            pkBtnKolorLinii.Enabled = true;
            pkBtnKolorWypelnienia.Enabled = true;
            pkGruboscLinii.Enabled = true;
            pkRodzajLinii.Enabled = true;
            pkZapisz.Enabled = true;
            pkWczytaj.Enabled = true;
            pkBtnKolorTla.Enabled = true;
            pkAutomatic.Enabled = true;
            pkManual.Enabled = true;

            //ponowne wykreślenie wszystkich figur "zapisanych" w TFG
            Random pkrnd = new Random();
            //deklaracje pomocnicze
            int pkx, pky;
            //wyznaczenie rozmiarów rysownicy
            int pkXmax = pkPbRysownica.Width;
            int pkYmax = pkPbRysownica.Height;
            //wykreślenie wszystkich figur z TFG w losowej lokalizacji
            for (int pki = 0; pki < pkLFG.Count; pki++)
            {
                //wylosowanie nowej lokalizacji: (x, y) dla i-tej figury
                pkx = pkrnd.Next(pkMargines, pkXmax - pkMargines);
                pky = pkrnd.Next(pkMargines, pkYmax - pkMargines);
                //zmiana lokalizacji i-tej figury geometrycznej i wykreślenie
                pkLFG[pki].PrzesunDoNowegoXY(pkPbRysownica, pkRysownica, new Point(pkx, pky));
            }
            //odświeżenie powierzchni graficznej
            pkPbRysownica.Refresh();
        }

        private void pkNastepny_Click(object sender, EventArgs e)
        {
            //deklaracja pomocnicza
            ushort pkIndexFigury;
            // pobieranie z kontrolki textbox indexu aktualnie wykreślonej figury
            pkIndexFigury = ushort.Parse(pkTxtIndeks.Text);
            //wyznaczenie indeksu dla następnej figury
            if (pkIndexFigury < pkLFG.Count - 1)
            {
                pkIndexFigury++;
            }
            else
            {
                pkIndexFigury = 0;
            }

            //deklaracje pomocnicze
            //wyznaczenie rozmiarów rysownicy
            int Xmax = pkPbRysownica.Width;
            int Ymax = pkPbRysownica.Height;

            pkRysownica.Clear(pkPbRysownica.BackColor);
            //zmiana lokalizacji i-tej figury geometrycznej i wykreślenie
            pkLFG[pkIndexFigury].PrzesunDoNowegoXY(pkPbRysownica, pkRysownica, Xmax / 2, Ymax / 2);
            //odświeżenie powierzchni graficznej
            pkPbRysownica.Refresh();
            //uaktualnienie zapisu indeksu aktualnie wykreślonej figury
            pkTxtIndeks.Text = pkIndexFigury.ToString();
        }

        private void pkPoprzedni_Click(object sender, EventArgs e)
        {
            //deklaracja pomocnicza
            ushort pkIndexFigury;
            // pobieranie z kontrolki textbox indexu aktualnie wykreślonej figury
            pkIndexFigury = ushort.Parse(pkTxtIndeks.Text);
            //wyznaczenie indeksu dla następnej figury
            if (pkIndexFigury != 0)
            {
                pkIndexFigury--;
            }
            else
            {
                pkIndexFigury = (ushort)(pkLFG.Count - 1);
            }

            //deklaracje pomocnicze
            //wyznaczenie rozmiarów rysownicy
            int Xmax = pkPbRysownica.Width;
            int Ymax = pkPbRysownica.Height;

            pkRysownica.Clear(pkPbRysownica.BackColor);
            //zmiana lokalizacji i-tej figury geometrycznej i wykreślenie
            pkLFG[pkIndexFigury].PrzesunDoNowegoXY(pkPbRysownica, pkRysownica, Xmax / 2, Ymax / 2);
            //odświeżenie powierzchni graficznej
            pkPbRysownica.Refresh();
            //uaktualnienie zapisu indeksu aktualnie wykreślonej figury
            pkTxtIndeks.Text = pkIndexFigury.ToString();
        }

        private void pkTxtIndeks_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            ushort pkIndeksFigury;

            if (pkTxtIndeks.Text == "")
                return;
            //pobranie numeru indeksu TFG wpisanego do kontrolki TextBox
            if (!ushort.TryParse(pkTxtIndeks.Text, out pkIndeksFigury))
            {
                errorProvider1.SetError(pkTxtIndeks, "ERROR: w zapisie indeksu wystapil nieprawidlowy znak");
                return;
            }
            //sprawdzenie warunku zawartość 
            if (pkIndeksFigury > pkLFG.Count - 1)
            {
                errorProvider1.SetError(pkIndeks, "ERROR: maksymalna ilosc indeksu " + (pkLFG.Count - 1).ToString());
                return;
            }
            //wyczyszczenie rysownicy
            pkRysownica.Clear(pkPbRysownica.BackColor);
            //deklaracje pomocnicze
            //wyznaczenie rozmiarów rysownicy
            int Xmax = pkPbRysownica.Width;
            int Ymax = pkPbRysownica.Height;
            //zmiana lokalizacji i-tej figury geometrycznej i wykreślenie
            pkLFG[pkIndeksFigury].PrzesunDoNowegoXY(pkPbRysownica, pkRysownica, Xmax / 2, Ymax / 2);
            //odświeżenie powierzchni graficznej
            pkPbRysownica.Refresh();
        }

        private void pkKrzywaBeziera_CheckedChanged(object sender, EventArgs e)
        {
            if (pkKrzywaBeziera.Checked)

                MessageBox.Show("Wykreslenie Krzywej Beziera wymaga zaznaczenia  4 punktow", "Krzywa Beziera",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pkDrawClosedCurve_CheckedChanged(object sender, EventArgs e)
        {
            if (pkDrawClosedCurve.Checked)

                MessageBox.Show("Wykreslenie zamknietej krzywej wymaga zaznaczenia 6 punktow",
                                "Krzywa łamana", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pkWypelnionyOsmiokat_CheckedChanged(object sender, EventArgs e)
        {
            if (pkWypelnionyOsmiokat.Checked)
            {
                MessageBox.Show("Wykreslenie wypelnionego osmiokata wymaga zaznaczenia 8 punktów ", "Osmiokat",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pkOsmiokat_CheckedChanged(object sender, EventArgs e)
        {
            if (pkOsmiokat.Checked)
            {
                MessageBox.Show("Wykreslenie osmiokąta wymaga zaznaczenia 8 punktów", "Osmiokat",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void pkBtnKolorTla_Click(object sender, EventArgs e)
        {
            ColorDialog pkkolor = new ColorDialog();
            pkkolor.ShowDialog();
            pkPbRysownica.BackColor = pkkolor.Color;
            pkKolorTla.BackColor = pkkolor.Color;
            pkKolorTla.ReadOnly = true;
        }

        private void pkZapisz_Click(object sender, EventArgs e)
        {
            // Utworz okno dialogowe do zapisu pliku
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Pliki obrazow (*.png)|*.png|Wszystkie pliki (*.*)|*.*";
            saveDialog.Title = "Zapisz obraz";

            // Jesli uzytkownik wybral plik i nacisnał OK
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                // Pobranie sciezki do wybranego pliku
                string sciezkaDoPliku = saveDialog.FileName;

                try
                {
                    // Pobranie mapy bitowej z pictureBox
                    Bitmap mapaBitowa = new Bitmap(pkPbRysownica.Image);

                    // Zapisanie mapy bitowej do pliku
                    mapaBitowa.Save(sciezkaDoPliku, ImageFormat.Png);

                 
                    MessageBox.Show("Plik zostal zapisany pomyslnie.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Obsluz bledy zapisu pliku
                    MessageBox.Show("Wystapil blad podczas zapisywania pliku: " + ex.Message, "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void pkWczytaj_Click(object sender, EventArgs e)
        {
            // Utworzenie okna dialogowego do wyboru pliku
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.Filter = "Pliki obrazow (*.png;*.jpg;*.bmp)|*.png;*.jpg;*.bmp|Wszystkie pliki (*.*)|*.*";
            openDialog.Title = "Wybierz obraz do wczytania";

            // Jesli uzytkownik wybral plik i nacisnal OK
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                // Pobierz sciezke do wybranego pliku
                string sciezkaDoPliku = openDialog.FileName;

                try
                {
                    // Wczytaj mape bitowa z pliku
                    Bitmap mapaBitowa = new Bitmap(sciezkaDoPliku);

                    // Przypisz wczytana mape bitową do kontrolki PictureBox
                    pkPbRysownica.Image = mapaBitowa;


                    // Utworzenie nowego egzemplarza powierzchni graficznej na wczytanym obrazie
                    pkRysownica = Graphics.FromImage(pkPbRysownica.Image);

                    //Odswiez obszar rysowania
                    pkPbRysownica.Invalidate();



                    MessageBox.Show("Plik zostal wczytany pomyslnie.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Obsluga bledow wczytywania pliku
                    MessageBox.Show("Wystapil blad podczas wczytywania pliku: " + ex.Message, "Blad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}