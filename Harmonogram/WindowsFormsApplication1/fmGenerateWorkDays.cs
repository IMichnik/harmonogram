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
    public partial class fmGenerateWorkDays : Form
    {
        public NpgsqlConnection connection;
        public NpgsqlCommand cmd;
        public NpgsqlDataReader dr;
        public fmGenerateWorkDays()
        {
            InitializeComponent();
        }

        public fmGenerateWorkDays(NpgsqlConnection Aconnection)
        {
            InitializeComponent();
            connection = Aconnection;
            connection.Close();
            connection.Open();
            cmd = new NpgsqlCommand("select coalesce(max(data_002) + 1, 'now') as NextDate, coalesce(max(data_002), 'now') + 366 as AfterYearDate from dni_robocze_002", connection);
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                dtpOd.Value = dr.GetDateTime(DbClass.FieldByName(dr, "NextDate"));
                dtpDo.Value = dr.GetDateTime(DbClass.FieldByName(dr, "AfterYearDate")); 
            }
            //            connection.Close();

        }

        private void btUstaw_Click(object sender, EventArgs e)
        {
            int iWeekDay=-1;
            System.DateTime DateFrom = dtpOd.Value;
            System.DateTime DateTo = dtpDo.Value;
            String Query = " select cast(extract(dow from @iDateFrom) as integer) as WEEK_DAY"; //
            Engine engine = new Engine(connection);
            connection.Close();
            connection.Open();
            cmd = new NpgsqlCommand(Query, connection);
            cmd.Parameters.AddWithValue("@iDateFrom", DateFrom);
            dr = cmd.ExecuteReader();

            DateTime NewDate = DateFrom;
            if (dr.Read())
            {
                
                iWeekDay = dr.GetInt16(DbClass.FieldByName(dr, "WEEK_DAY")) - 1;
                if (iWeekDay == 5)
                {
                    iWeekDay = 0;

                    NewDate = NewDate.AddDays(2);
                }
                if (iWeekDay == 6)
                {
                    iWeekDay = 1;

                    NewDate = NewDate.AddDays(1);
                }

                while (NewDate <= DateTo)
                {
                    if (iWeekDay < 5)
                    {
                        connection.Close();
                        connection.Open();
                        string QueryIns = "insert into dni_robocze_002 (data_002, roboczy_002, ustalone_002) "
                            + " select distinct CAST('" + NewDate.ToString() + "' as date), true, false"
                            + " from public.dyzury_004 where not exists(select 1 from dni_robocze_002 where data_002 = '" + NewDate.ToString() + "')";
                        cmd = new NpgsqlCommand(QueryIns, connection);
                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception er)
                        {
                            MessageBox.Show(er.Message);
                        }
                    }
                    NewDate = NewDate.AddDays(1);
                    iWeekDay = (iWeekDay + 1) % 7;
                }
                connection.Close();
                connection.Open();
                cmd = new NpgsqlCommand("insert into public.preferencje_003 (id_001_003, id_002_003, id_004_003, wskaznik_003, data_003)"
                                       + " select id_001, id_002, id_004, 25, data_002"
                                       + "   from public.dni_robocze_002"
                                       + "   left join public.dyzury_004 on true"
                                       + "   left join public.pracownicy_001 on true"
                                      + "    left join public.preferencje_003 on id_002_003 = id_002 and id_001_003 = id_001 and id_004_003 = id_004"
                                      + "    where id_003 is null", connection);
                cmd.Parameters.AddWithValue("@iDate", NewDate);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }
                
            }
            Close(); 
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            string SqlWhere002 = "";
            string SqlWhereStart = "";
            string SqlWhereStop = "";
            string SqlAnd = "";
            string SqlDelete002 = "delete from public.dni_robocze_002";
            string SqlDelete003 = "delete from public.preferencje_003";
            string SqlDelete005 = "delete from public.harmonogram_005";
            String Query = "";
            if (dtpOd.Checked)
                SqlWhereStart = "data_002 >= '" + dtpOd.Value.ToString() + "'";
            if (dtpDo.Checked)
                SqlWhereStop = "data_002 <= '" + dtpDo.Value.ToString() + "'";
            if ((SqlWhereStart != "") && (SqlWhereStop != ""))
                SqlAnd = " and ";
            if ((SqlWhereStart != "") || (SqlWhereStop != ""))
                SqlWhere002 = " where " + SqlWhereStart + SqlAnd + SqlWhereStop;

            if (SqlWhere002 != "")
                Query = SqlDelete005 + " where id_002_005 in (select id_002 from public.dni_robocze_002 " + SqlWhere002 + ")";
            else
                Query = SqlDelete005;
                

            connection.Close();
            connection.Open();
            cmd = new NpgsqlCommand(Query, connection);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            if (SqlWhere002 != "")
                Query = SqlDelete003 + " where id_002_003 in (select id_002 from public.dni_robocze_002 " + SqlWhere002 + ")";
            else
                Query = SqlDelete003;


            connection.Close();
            connection.Open();
            cmd = new NpgsqlCommand(Query, connection);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

            Query = SqlDelete002 + SqlWhere002;
            connection.Close();
            connection.Open();
            cmd = new NpgsqlCommand(Query, connection);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
            Close();
        }
    }
}
