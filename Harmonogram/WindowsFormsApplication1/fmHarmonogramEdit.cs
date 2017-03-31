using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class fmHarmonogramEdit : WindowsFormsApplication1.fmEdit
    {
        Harmonogram harmonogram;
        ListaDniRoboczych dniRobocze;
        ListaPracownikow pracownicy;

        public fmHarmonogramEdit()
        {
            InitializeComponent();
        }
        public override void AssignObjectToForm()
        {
            harmonogram = (Harmonogram)dbObject;
            if (pracownicy == null)
            {
                pracownicy = new ListaPracownikow(harmonogram.connection);
                pracownicy.Load();
                cbPracownicy.Items.Clear();
                for (int ii = 0; ii < pracownicy.Count(); ii++)
                {
                    Pracownik pracownik = pracownicy.Item(ii);
                    //cbPracownicy.Items.Add(pracownik.Nazwisko + " " + pracownik.Imie);
                    cbPracownicy.Items.Add(pracownik);
                }
            }
            if (dniRobocze == null)
            {
                dniRobocze = new ListaDniRoboczych(harmonogram.connection);
                dniRobocze.Load();
                cbDniRobocze.Items.Clear();
                for (int ii = 0; ii < dniRobocze.Count(); ii++)
                {
                    DzienRoboczy dzienRoboczy = dniRobocze.Item(ii);
                    //cbPracownicy.Items.Add(pracownik.Nazwisko + " " + pracownik.Imie);
                    cbDniRobocze.Items.Add(dzienRoboczy);
                }
            }

            cbPracownicy.SelectedIndex = -1;
            if (harmonogram.Id001 != null)
            {
                for (int ii = 0; ii < pracownicy.Count(); ii++)
                {
                    if (pracownicy.Items[ii].Id == harmonogram.Id001)
                    {
                        cbPracownicy.SelectedIndex = ii;
                        break;
                    }
                }
            }
            cbDniRobocze.SelectedIndex = -1;
            if (harmonogram.Id002 != null)
            {
                for (int ii = 0; ii < dniRobocze.Count(); ii++)
                {
                    if (dniRobocze.Items[ii].Id == harmonogram.Id002)
                    {
                        cbDniRobocze.SelectedIndex = ii;
                        break;
                    }
                }
            }
            cbDyzury.SelectedIndex = -1;
            if (harmonogram.Id004 != null)
            {
                cbDyzury.SelectedIndex = (Int16)(harmonogram.Id004) - 1;
            }
        
        
        }
        public override void AssignFormToObject()
        {
            if (cbPracownicy.SelectedIndex == -1)
                harmonogram.Id001 = null;
            else
                harmonogram.Id001 = pracownicy.Items[cbPracownicy.SelectedIndex].Id;

            if (cbDniRobocze.SelectedIndex == -1)
                harmonogram.Id002 = null;
            else
                harmonogram.Id002 = dniRobocze.Items[cbDniRobocze.SelectedIndex].Id;
            if (cbDyzury.SelectedIndex == -1)
                harmonogram.Id004 = null;
            else
                harmonogram.Id004 = cbDyzury.SelectedIndex + 1;
            harmonogram.Recznie = true;
        }

        private void fmHarmonogramEdit_Shown(object sender, EventArgs e)
        {
            


        }
    }
}
