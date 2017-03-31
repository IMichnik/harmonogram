using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;


namespace WindowsFormsApplication1
{
    
    public partial class fmGenerate : Form
    {
        public NpgsqlConnection connection;
        public NpgsqlCommand cmd;
        public NpgsqlDataReader dr;
        //int Id002;
        public fmGenerate()
        {
            InitializeComponent();
        }
        public fmGenerate(NpgsqlConnection Aconnection)
        {
            InitializeComponent();
            connection = Aconnection;
            connection.Close();
            connection.Open();
            cmd = new NpgsqlCommand("select min(data_002) as nextDate from dni_robocze_002 left join harmonogram_005 on id_002_005 = id_002 where id_002_005 is NULL", connection);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                dtpOd.Value = dr.GetDateTime(DbClass.FieldByName(dr, "nextDate"));
                dtpDo.Value = dtpOd.Value;
            }
//            connection.Close();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btUstaw_Click(object sender, EventArgs e)
        {
            System.DateTime DateFrom = dtpOd.Value;
            String Query = " select id_002, data_002, ustalone_002, roboczy_002, CASE EXTRACT(DOW FROM data_002)"
                 + "    when 1 then 'poniedziałek'"
                 + "    when 2 then 'wtorek'"
                 + "  when 3 then 'środa'"
                 + "  when 4 then 'czwartek'"
                 + "  when 5 then 'piątek'"
                 + "  when 6 then 'sobota'"
                 + "  when 0 then 'niedziela'"
                 + "  else 'nie wiem' end as dzien_tygodnia  from public.dni_robocze_002" //
                         + "  where ustalone_002 = FALSE"
                         + "  and data_002 between @iDateFrom and @iDateTo";
            Engine engine = new Engine(connection);
            connection.Close();
            
            connection.Open();
            cmd = new NpgsqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@iDateFrom", dtpOd.Value);
            cmd.Parameters.AddWithValue("@iDateTo", dtpDo.Value);
            dr = cmd.ExecuteReader();
            ListaDniRoboczych dniRobocze = new ListaDniRoboczych(connection);
            while (dr.Read())
            {
                if (dr. HasRows)
                {
                    DzienRoboczy dzienRoboczy = new DzienRoboczy(connection);
                    dzienRoboczy.AssignFromDataset(dr);
                    dniRobocze.Add(dzienRoboczy);

                    
                }
            }
            for (int ii = 0; ii < dniRobocze.Count(); ii++)
            {
                DzienRoboczy dzienRoboczy = dniRobocze.Items[ii];
                engine.Data = (DateTime)dzienRoboczy.Data; 
                engine.Id002 = (int)dzienRoboczy.Id;
                engine.Start();
            }

        }

        private void dtpOd_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
