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
    public partial class fmPracownicy : WindowsFormsApplication1.fmGrid
    {
        public fmPracownicy()
        {
            InitializeComponent();
        }
        public override DbClass CreateDbObject()
        {
            return new Pracownik(connection);
        }

        public override fmEdit CreateEditForm()
        {
            return new fmPracownikEdycja();
        }

        public fmPracownicy(NpgsqlConnection AConnection) : base(AConnection)
        {
            InitializeComponent();
            new fmGrid(AConnection);
            //RefreshGrid();
        }
        public override String SqlStatement()
        {
            return "select id_001, imie_001, nazwisko_001, login_001, aktywny_001 from public.pracownicy_001";
        }
        public override String Order()
        {
            return " order by nazwisko_001";
        }
        public override void AssignColumnTitles()
        {
            for(int ii = 0; ii < dataGridView1.ColumnCount; ii++)
            {
                if (dataGridView1.Columns[ii].Name == "id_001")
                    dataGridView1.Columns[ii].Visible = false;
                else if (dataGridView1.Columns[ii].Name == "imie_001")
                {
                    dataGridView1.Columns[ii].HeaderText = "Imię";

                }
                else if (dataGridView1.Columns[ii].Name == "nazwisko_001")
                    dataGridView1.Columns[ii].HeaderText = "Nazwisko";
                else if (dataGridView1.Columns[ii].Name == "login_001")
                    dataGridView1.Columns[ii].HeaderText = "Login";
                else if (dataGridView1.Columns[ii].Name == "aktywny_001")
                {
                    dataGridView1.Columns[ii].HeaderText = "Aktywny";
                    //dataGridView1.Columns[ii].Width =  dataGridView1.Width/12;
                }
            }
        }

        private void btnModyfikuj_Click_1(object sender, EventArgs e)
        {

        }

        private void btnDodaj_Click_1(object sender, EventArgs e)
        {

        }
    }
}
