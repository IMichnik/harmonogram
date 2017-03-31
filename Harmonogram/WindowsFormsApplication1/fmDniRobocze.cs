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
    public partial class fmDniRobocze : WindowsFormsApplication1.fmGrid
    {
        public fmDniRobocze()
        {
            InitializeComponent();
        }

        public override DbClass CreateDbObject()
        {
            return new DzienRoboczy(connection);
        }

        public override fmEdit CreateEditForm()
        {
            return new fmDzienRoboczyEdit();
        }
        public fmDniRobocze(NpgsqlConnection AConnection) : base(AConnection)
        {
            InitializeComponent();
            new fmGrid(AConnection);
            connection = AConnection;
        }
        public override String SqlStatement()
        {
            return "select id_002, data_002, case EXTRACT(dow from data_002) when  1 then 'Poniedziałek' when 2 then 'Wtorek'  when 3 then 'Środa'  when 4 then 'Czwartek'  when 5 then 'Piątek' " 
              + "   when 6 then 'Sobota'   when 0 then 'Niedziela'   else 'Inny' end as dzien_tygodnia_002, roboczy_002, ustalone_002  from public.dni_robocze_002 order by data_002";
        }

        public override void AssignColumnTitles()
        {
            for (int ii = 0; ii < dataGridView1.ColumnCount; ii++)
            {
                if (dataGridView1.Columns[ii].Name == "data_002")
                    dataGridView1.Columns[ii].HeaderText = "Data";
                else if (dataGridView1.Columns[ii].Name == "dzien_tygodnia_002")
                    dataGridView1.Columns[ii].HeaderText = "Dzień tygodnia";
                else if (dataGridView1.Columns[ii].Name == "roboczy_002")
                    dataGridView1.Columns[ii].HeaderText = "Roboczy";
                else if (dataGridView1.Columns[ii].Name == "ustalone_002")
                    dataGridView1.Columns[ii].HeaderText = "Ustalony grafik";
                else
                    dataGridView1.Columns[ii].Visible = false;
            }
        }

        private void fmDniRobocze_Shown(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void btnGenerujGrafik_Click(object sender, EventArgs e)
        {
            fmGenerateWorkDays fGenerateWorkDays = new fmGenerateWorkDays(connection);
            fGenerateWorkDays.ShowDialog();
            RefreshGrid();
        }
    }
}
