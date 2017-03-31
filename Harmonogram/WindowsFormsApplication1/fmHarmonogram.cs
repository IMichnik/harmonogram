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
    public partial class fmHarmonogram : WindowsFormsApplication1.fmGrid
    {
        public fmHarmonogram()
        {
            InitializeComponent();
        }
        public fmHarmonogram(NpgsqlConnection AConnection) : base(AConnection)
        {
            InitializeComponent();
            new fmGrid(AConnection);
        }

        public override DbClass CreateDbObject()
        {
            return new Harmonogram(connection);
        }

        public override fmEdit CreateEditForm()
        {
            return new fmHarmonogramEdit();
        }

        public override string SqlStatement()
        {
            return "select id_005, id_001_005, id_002_005, id_004_005, imie_001, nazwisko_001, data_002, opis_004, "
                 + "  CASE EXTRACT(DOW FROM data_002)"
                 + "    when 1 then 'poniedziałek'"
                 + "    when 2 then 'wtorek'"
                 + "    when 3 then 'środa'"
                 + "    when 4 then 'czwartek'"
                 + "    when 5 then 'piątek'"
                 + "    when 6 then 'sobota'"
                 + "    when 0 then 'niedziela'"
                 + "    else 'nie wiem' end as dzien_tygodnia,"
                 + "  recznie_005"
                 + "  from public.harmonogram_005"
                 + "  join public.pracownicy_001 on ID_001_005 = ID_001"
                 + "  left join public.dyzury_004 on ID_004_005 = ID_004"
                 + "  left join public.dni_robocze_002 on id_002_005 = id_002"
                 + "  order by data_002, nazwisko_001";
        }

        public override void AssignColumnTitles()
        {
            for (int ii = 0; ii < dataGridView1.ColumnCount; ii++)
            {
                if (dataGridView1.Columns[ii].Name == "imie_001")
                    dataGridView1.Columns[ii].HeaderText = "Imię";
                else if (dataGridView1.Columns[ii].Name == "nazwisko_001")
                    dataGridView1.Columns[ii].HeaderText = "Nazwisko";
                else if (dataGridView1.Columns[ii].Name == "opis_004")
                    dataGridView1.Columns[ii].HeaderText = "Dyżur";
                else if (dataGridView1.Columns[ii].Name == "data_002")
                    dataGridView1.Columns[ii].HeaderText = "Data";
                else if (dataGridView1.Columns[ii].Name == "dzien_tygodnia")
                    dataGridView1.Columns[ii].HeaderText = "Dzień tygodnia";
                else
                    dataGridView1.Columns[ii].Visible = false;
            }
        }

        private void fmHarmonogram_Shown(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void btnGeneruj_Click(object sender, EventArgs e)
        {
            fmGenerate fGenerate = new fmGenerate(connection);
            fGenerate.ShowDialog();
            RefreshGrid();
        }
    }
}
