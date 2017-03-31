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
    public partial class fmPreferencje : WindowsFormsApplication1.fmGrid
    {
        public ListaPracownikow pracownicy;
        public fmPreferencje()
        {
            InitializeComponent();
        }

        public override String Order()
        {
            return "  order by data_002, nazwisko_001";
        }
        //public override fmEdit CreateEditForm()
        //{
        //    return new fmPreferencjeDef();
        //}

        public fmPreferencje(NpgsqlConnection AConnection) : base(AConnection)
        {
            InitializeComponent();
            new fmGrid(AConnection);
            AConnection.Close();
            AConnection.Open();
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
        public override string SqlStatement()
        {
            return "select imie_001, nazwisko_001, login_001, data_002,"
                     + "(select wskaznik_003 from public.preferencje_003"
                     + "   where id_001_003 = id_001 "
                     + "     and id_004_003 = 1 "
                     + "     and id_002_003 = id_002) as \"07:00\", "
                     + "(select wskaznik_003 from public.preferencje_003"
                     + "  where id_001_003 = id_001 "
                     + "    and id_004_003 = 2 "
                     + "    and id_002_003 = id_002) as \"08:00\", "
                     + " (select wskaznik_003 from public.preferencje_003 "
                     + "  where id_001_003 = id_001 "
                     + "     and id_004_003 = 3 "
                     + "    and id_002_003 = id_002) as \"09:00\", "
                     + "(select wskaznik_003 from public.preferencje_003 "
                     + "  where id_001_003 = id_001 "
                     + "     and id_004_003 = 4 "
                     + "     and id_002_003 = id_002) as \"10:00\" "
                     + "  from public.pracownicy_001 "
                     + "  join public.dni_robocze_002 on 1 = 1  ";// ;

        }

        public override void AssignColumnTitles()
        {
            for (int ii = 0; ii < dataGridView1.ColumnCount; ii++)
            {
                if (dataGridView1.Columns[ii].Name == "imie_001")
                {
                    dataGridView1.Columns[ii].HeaderText = "Imię";
                }
                else if (dataGridView1.Columns[ii].Name == "nazwisko_001")
                    dataGridView1.Columns[ii].HeaderText = "Nazwisko";
                else if (dataGridView1.Columns[ii].Name == "login_001")
                    dataGridView1.Columns[ii].Visible = false;
                else if (dataGridView1.Columns[ii].Name == "data_002")
                {
                    dataGridView1.Columns[ii].HeaderText = "Data";
                }
                else if (dataGridView1.Columns[ii].Name == "id")
                    dataGridView1.Columns[ii].Visible = false;
            }
        }

        public override String Filter()
        {
            if (cbPracownicy.SelectedItem == null)
                return " where 1 = 2 ";
            else
            {
                Pracownik pracownik = (Pracownik)cbPracownicy.SelectedItem;
                return " where id_001 = " + pracownik.Id.ToString();
            }
        }

        private void fmPreferencje_Shown(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void cbPracownicy_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        //public  void btnModyfikuj_Click(object sender, EventArgs e)
       // {
         
       // }

        private void btnDefine_Click(object sender, EventArgs e)
        {
              fmPreferencjeDef fPreferencjeDef = new fmPreferencjeDef(connection);
              if (cbPracownicy.SelectedIndex > -1)
                  fPreferencjeDef.setPracownik(cbPracownicy.SelectedItem.ToString());
              fPreferencjeDef.ShowDialog();
              RefreshGrid();
        }

        //private void btnUsun_Click(object sender, EventArgs e)
        //{

        //}

    }
}
