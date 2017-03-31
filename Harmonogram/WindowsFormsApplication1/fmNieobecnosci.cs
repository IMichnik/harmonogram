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
    public partial class fmNieobecnosci : WindowsFormsApplication1.fmGrid
    {
        public fmNieobecnosci()
        {
            InitializeComponent();
        }
        public override DbClass CreateDbObject()
        {
            return new Nieobecnosc(connection);
        }

        public override fmEdit CreateEditForm()
        {
            return new fmNieobecnosciEdit(connection);
        }

        public fmNieobecnosci(NpgsqlConnection AConnection) : base(AConnection)
        {
            InitializeComponent();
            new fmGrid(AConnection);
        }
        public override String SqlStatement()
        {
            return "select imie_001, nazwisko_001, id_006, id_001_006, data_006, zatwierdzone_006, typ_006,"
                 + "  case when typ_006 = 0 then 'Urlop'"
                 + "    when typ_006 = 1 then 'Choroba'"
                 + "       when typ_006 = 2 then 'Wyjazd'"
                 + "       when typ_006 = 3 then 'Szkolenie'"
                 + "  	   else 'Nieokreślone'"
                 + "  end as Przyczyna"
                 + "  from public.nieobecnosci_006"
                 + "  join public.pracownicy_001 on id_001 = id_001_006";
        }
        public override void AssignColumnTitles()
        {
            for (int ii = 0; ii < dataGridView1.ColumnCount; ii++)
            {
                if ((dataGridView1.Columns[ii].Name == "id_006") 
                    || (dataGridView1.Columns[ii].Name == "id_001_006")
                    || (dataGridView1.Columns[ii].Name == "typ_006"))
                    dataGridView1.Columns[ii].Visible = false;
                else if (dataGridView1.Columns[ii].Name == "imie_001")
                {
                    dataGridView1.Columns[ii].HeaderText = "Imię";
                }
                else if (dataGridView1.Columns[ii].Name == "nazwisko_001")
                    dataGridView1.Columns[ii].HeaderText = "Nazwisko";
                else if (dataGridView1.Columns[ii].Name == "data_006")
                    dataGridView1.Columns[ii].HeaderText = "Data";
                else if (dataGridView1.Columns[ii].Name == "zatwierdzone_006")
                {
                    dataGridView1.Columns[ii].HeaderText = "Zatwierdzone";
                }
            }
        }

        private void fmPracownicy_Shown(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void fmNieobecnosci_Shown(object sender, EventArgs e)
        {
            RefreshGrid();
        }

    
    }
}
