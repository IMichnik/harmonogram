using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class fmPracownikEdycja: WindowsFormsApplication1.fmEdit
    {
        Pracownik pracownik;

        public override Boolean DoAfterSave()
        {
            if (!pracownik.UserExists())
                fmPasswordChanging.CreateUserExecute(pracownik);
            return true;
        }

        public fmPracownikEdycja()
        {
            InitializeComponent();
        }

        public override void AssignObjectToForm()
        {
            pracownik = (Pracownik)dbObject;
            txtbNazwisko.Text = pracownik.Nazwisko;
            txtbImie.Text = pracownik.Imie;
            txbLogin.Text = pracownik.Login;
            chbAktywny.Checked = ((pracownik.Aktywny != null) && (bool)pracownik.Aktywny);
        }
        public override void AssignFormToObject()
        {
            pracownik = (Pracownik)dbObject;
            pracownik.Nazwisko = txtbNazwisko.Text;
            pracownik.Imie = txtbImie.Text;
            pracownik.Login = txbLogin.Text;
            pracownik.Aktywny = chbAktywny.Checked;
        }

        private void fmPracownikEdycja_Load(object sender, EventArgs e)
        {

        }
    }
}
