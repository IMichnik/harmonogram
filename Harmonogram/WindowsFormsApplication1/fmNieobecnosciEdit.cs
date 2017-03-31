using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Npgsql;

namespace WindowsFormsApplication1
{
    public partial class fmNieobecnosciEdit : WindowsFormsApplication1.fmEdit
    {
        ListaPracownikow pracownicy;
        Nieobecnosc nieobecnosc;
        public fmNieobecnosciEdit()
        {
            InitializeComponent();
        }
        public override void AssignObjectToForm()
        {
            nieobecnosc = (Nieobecnosc)dbObject;
            cbPracownicy.SelectedIndex = -1;
            if (nieobecnosc.Id001 != null)
            {
                for (int ii = 0; ii < pracownicy.Count(); ii++)
                {
                    if (pracownicy.Items[ii].Id == nieobecnosc.Id001)
                    {
                        cbPracownicy.SelectedIndex = ii;
                        break;
                    }
                }
            }

            if (nieobecnosc.Data == null)

                dtpDataOd.Value = DateTime.Now;
            else
                dtpDataOd.Value = (DateTime)nieobecnosc.Data;
            dtpDataDo.Value = dtpDataOd.Value;
            if (nieobecnosc.Typ == null)
                cbTyp.SelectedIndex = -1;
            else
                cbTyp.SelectedIndex = (int)nieobecnosc.Typ;
            if (nieobecnosc.Id != null)
            {
                dtpDataOd.Enabled = false;
                dtpDataDo.Enabled = false;
            }
            if (nieobecnosc.Zatwierdzone != null)
                chbZatwierdzone.Checked = (bool)nieobecnosc.Zatwierdzone;
            else
                chbZatwierdzone.Checked = false;
        }
        public override void AssignFormToObject()
        {
            nieobecnosc = (Nieobecnosc)dbObject;
            if (cbPracownicy.SelectedIndex == -1)
                nieobecnosc.Id001 = null;
            else
                nieobecnosc.Id001 = pracownicy.Items[cbPracownicy.SelectedIndex].Id;

            nieobecnosc.Data = dtpDataOd.Value;
            nieobecnosc.DataDo = dtpDataDo.Value;
            if (cbTyp.SelectedIndex == -1)
                nieobecnosc.Typ = null;
            else
                nieobecnosc.Typ = cbTyp.SelectedIndex;
            nieobecnosc.Zatwierdzone = chbZatwierdzone.Checked;
           
        }
        public fmNieobecnosciEdit(NpgsqlConnection AConnection)
        {
            InitializeComponent();
            AConnection.Close();
            AConnection.Open();
            connection = AConnection;
            NpgsqlCommand cmd = new NpgsqlCommand("select \"current_user\"() ", connection);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            String sLogin = "";
            if (dr.Read())
            {
                sLogin = dr.GetString(0);
            }
            pracownicy = new ListaPracownikow(AConnection);
            pracownicy.Load();
            cbPracownicy.Items.Clear();
            object oCurrentUser = null;
            for (int ii = 0; ii < pracownicy.Count(); ii++)
            {
                Pracownik pracownik = pracownicy.Item(ii);
                //cbPracownicy.Items.Add(pracownik.Nazwisko + " " + pracownik.Imie);
                cbPracownicy.Items.Add(pracownik);
                if (sLogin == pracownik.Login)
                    oCurrentUser = cbPracownicy.Items[ii];
            }
            cbPracownicy.SelectedItem = oCurrentUser;
            if (cbPracownicy.SelectedItem != null)
                cbPracownicy.Enabled = false;


        }
        public override void btnZapisz_Click(object sender, EventArgs e)
        {
            AssignFormToObject();
            DoSave();
            if (nieobecnosc.Id != null)
            {
                dtpDataOd.Enabled = false;
                dtpDataDo.Enabled = false;
            }
        }
    }
}
