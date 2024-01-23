using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt2_Karwowski65859
{
    public partial class pkMainForm : Form
    {
        public pkMainForm()
        {
            InitializeComponent();
        
        }

   

        private void MoveToLabNr2(object sender, EventArgs e)
        {
           // Sprawdzenie czy nasz formularz jest w kolekcji OpenForms (otwartych formularzy)
           foreach(Form SzukanyFormularz in Application.OpenForms)
                // sprawdzenie czy jest to szukany formularz (laboratroiumnr2)
                if (SzukanyFormularz.Name == "LaboratoriumNr2")
                    { //formularz zostal znaleziony
                    //ukrywamy biezacy formularz (czyli formularz glowny)
                    Hide();
                    // odslaniamy znaleziony formularz 
                    SzukanyFormularz.Show();
                    // zakonczenie obslugi zdarzenia Click dla przycisku polecen MoveToLabNr2
                    return;
                }
            // poszukiwany formularz nie zostal znaleziony
            //utworzenie egzemplarza dla "poszukiwanego" formularza 
            LaboratoriumNr2 EgzFormularzaLaboratoryjnego =
                                                new LaboratoriumNr2();
            //ukrywamy biezacy formularz (czyli formularz glowny)
            this.Hide();
            //odsloniecie nowo utworzonego egzemplarza formularza 
            EgzFormularzaLaboratoryjnego.Show();
        }

        private void pkMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult OknoDialogowe =
                MessageBox.Show("serio chcesz zamknac?", this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (OknoDialogowe == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else
                // nie nie to tylko pomylka
                e.Cancel = true;
        }

        private void btnMouseShapeForm_Click(object sender, EventArgs e)
        {
            // Sprawdzenie czy nasz formularz jest w kolekcji OpenForms (otwartych formularzy)
            foreach (Form SzukanyFormularz in Application.OpenForms)
                // sprawdzenie czy jest to szukany formularz (laboratroiumnr2)
                if (SzukanyFormularz.Name == "ProjektIndywidualnyNr2")
                { //formularz zostal znaleziony
                    //ukrywamy biezacy formularz (czyli formularz glowny)
                    this.Hide();
                    // odslaniamy znaleziony formularz 
                    SzukanyFormularz.Show();
                    // zakonczenie obslugi zdarzenia Click dla przycisku polecen MoveToLabNr2
                    return;
                }
            // poszukiwany formularz nie zostal znaleziony
            //utworzenie egzemplarza dla "poszukiwanego" formularza 
            pkProjektIndywidualnyNr2 EgzFormularzaIndywidualnego =
                                                new pkProjektIndywidualnyNr2();
            //ukrywamy biezacy formularz (czyli formularz glowny)
            this.Hide();
            //odsloniecie nowo utworzonego egzemplarza formularza 
            EgzFormularzaIndywidualnego.Show();
        }

     
    }
}
