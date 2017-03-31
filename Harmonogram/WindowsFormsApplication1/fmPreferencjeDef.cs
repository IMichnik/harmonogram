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
    public partial class fmPreferencjeDef : Form
    {
        public NpgsqlConnection connection;
        public NpgsqlCommand cmd;
        public NpgsqlDataReader dr;
        public ListaPracownikow pracownicy;
        public bool ObliczanieReszty;
        public fmPreferencjeDef()
        {
            InitializeComponent();
        }

        public fmPreferencjeDef(NpgsqlConnection AConnection)
        {
            InitializeComponent();
            connection = AConnection;
            pracownicy = new ListaPracownikow(connection);
            pracownicy.Load();
            cbPracownicy.Items.Clear();
            for (int ii = 0; ii < pracownicy.Count(); ii++)
            {
                Pracownik pracownik = pracownicy.Item(ii);
                //cbPracownicy.Items.Add(pracownik.Nazwisko + " " + pracownik.Imie);
                cbPracownicy.Items.Add(pracownik);

            }
            ObliczanieReszty = false;
        }
        public void setPracownik(String APracownik)
        {
            for (int ii = 0; ii < pracownicy.Count(); ii++)
            {

                if (cbPracownicy.Items[ii].ToString() == APracownik)
                {
                    cbPracownicy.SelectedIndex = ii;
                    return;
                }
            }
            cbPracownicy.SelectedIndex = -1;
        }
        private void numudPreferencje1_ValueChanged(object sender, EventArgs e)
        {
            ObliczanieReszty = true;
            decimal d1 = numudPreferencje1.Value;
            decimal d2 = Math.Round((100 - d1) / 3)         ;
            numudPreferencje2.Maximum = 100 - d1;
            numudPreferencje2.Value =  d2;
            numudPreferencje3.Maximum = 100 - d1 - d2;
            numudPreferencje3.Value = d2;
            numudPreferencje4.Maximum = 100 - d1 - d2 - d2;
            numudPreferencje4.Minimum = 100 - d1 - d2 - d2;
            ObliczanieReszty = false;
        }

        private void numudPreferencje2_ValueChanged(object sender, EventArgs e)
        {
            if (!ObliczanieReszty)
            {
                ObliczanieReszty = true;
                decimal d1 = numudPreferencje1.Value;
                decimal d2 = numudPreferencje2.Value;
                numudPreferencje3.Maximum = 100 - d1 - d2;
                decimal d3 = Math.Round((100 - d1 - d2) / 2);
                numudPreferencje3.Value = d3;
                numudPreferencje4.Maximum = 100 - d1 - d2 - d3;
                numudPreferencje4.Minimum = 100 - d1 - d2 - d3;
                ObliczanieReszty = false;
            }
        }

        private void numudPreferencje3_ValueChanged(object sender, EventArgs e)
        {
            if (!ObliczanieReszty)
            {
                ObliczanieReszty = true;
                decimal d1 = numudPreferencje1.Value;
                decimal d2 = numudPreferencje2.Value;
                decimal d3 = numudPreferencje3.Value;
                decimal d4 = 100 - d1 - d2 - d3;
                numudPreferencje4.Maximum = d4;
                numudPreferencje4.Minimum = d4;
                numudPreferencje4.Value = d4;
                ObliczanieReszty = false;
            }
        }

        private void btUstaw_Click(object sender, EventArgs e)
        {
            string WeekDay = "";
            string Or = "";
            string And = " and ";
            string sqlwhere = "";
            string sqlWhereFill003 = " where id_003 is null";
            string sqlWhereId001 = "";
            
            if (cbPracownicy.SelectedItem != null)
            {
                Pracownik pracownik = (Pracownik)cbPracownicy.SelectedItem;
                sqlwhere = sqlwhere + And + " id_001_003 = " + pracownik.Id.ToString();
                sqlWhereId001 = " and id_001 = " + pracownik.Id.ToString();
                And = " and ";
            }
            if (dtpOd.Checked)
            {
                sqlwhere = sqlwhere + And + " data_003 >= '" + dtpOd.Text + "'";
                sqlWhereFill003 = sqlWhereFill003 + " and data_002 >= '" + dtpOd.Text + "'";
                And = " and ";
            }
            if (dtpDo.Checked)
            {
                sqlwhere = sqlwhere + And + " data_003 <= '" + dtpDo.Text + "'";
                sqlWhereFill003 = sqlWhereFill003 + " and data_002 <= '" + dtpDo.Text + "'";
                And = " and ";
            }
            string sqlFill003 = "insert into public.preferencje_003 (id_001_003, id_002_003, id_004_003, wskaznik_003, data_003)"
                + " select id_001, id_002, id_004, 25, data_002 "
                + " from public.dni_robocze_002"
                + " left join public.dyzury_004 on true"
                + " left join public.pracownicy_001 on true"
                + " left join public.preferencje_003 on id_002_003 = id_002 and id_001_003 = id_001"
                + sqlWhereFill003 + sqlWhereId001
                + " order by data_002, id_004";

            connection.Close();
            connection.Open();
            cmd = new NpgsqlCommand(sqlFill003, connection);
            cmd.ExecuteNonQuery();



            if (chklbDniTygodnia.CheckedItems.Count > 0)
            {
                for (int ii = 0; ii < chklbDniTygodnia.CheckedItems.Count; ii++)
                {
                    string Dzien = chklbDniTygodnia.CheckedItems[ii].ToString();
                    if (String.Equals(Dzien, "Poniedziałek"))
                        WeekDay = WeekDay + Or + "EXTRACT(DOW from data_003) + 1 = 1";
                    else if (String.Equals(Dzien, "Wtorek"))
                        WeekDay = WeekDay + Or + "EXTRACT(DOW from data_003) + 1 = 2";
                    else if (String.Equals(Dzien, "Środa"))
                        WeekDay = WeekDay + Or + "EXTRACT(DOW from data_003) + 1 = 3";
                    else if (String.Equals(Dzien, "Czwartek"))
                        WeekDay = WeekDay + Or + "EXTRACT(DOW from data_003) + 1 = 4";
                    else if (String.Equals(Dzien, "Piątek"))
                        WeekDay = WeekDay + Or + "EXTRACT(DOW from data_003) + 1 = 5";
                    Or = " or ";
                }
                sqlwhere = sqlwhere + And + "(" + WeekDay + ")";
            }


            //
            string statement = "";
            //if (connection == null)
            //  connection = new NpgsqlConnection("Server=127.0.0.1;User Id=postgres;" +
            //                        "Password=masterkey;Database=postgres;");
            connection.Close();
            connection.Open();
            int wsk1 = (int)Math.Round(numudPreferencje1.Value, 0);
            int wsk2 = (int)Math.Round(numudPreferencje2.Value, 0);
            int wsk3 = (int)Math.Round(numudPreferencje3.Value, 0);
            int wsk4 = (int)Math.Round(numudPreferencje4.Value, 0);
            if (!chkLosowo.Checked)
            {
                statement = "update public.preferencje_003"
                                      + "    set wskaznik_003 = " + wsk1.ToString()
                                      + " where id_004_003 = 1" + sqlwhere;
                cmd = new NpgsqlCommand(statement, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                connection.Open();
                statement = "update public.preferencje_003"
                                      + "    set wskaznik_003 = " + wsk2.ToString()
                                      + " where id_004_003 = 2" + sqlwhere;
                cmd = new NpgsqlCommand(statement, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                connection.Open();
                statement = "update public.preferencje_003"
                                      + "    set wskaznik_003 = " + wsk3.ToString()
                                      + " where id_004_003 = 3" + sqlwhere;
                cmd = new NpgsqlCommand(statement, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                connection.Open();
                statement = "update public.preferencje_003"
                                      + "    set wskaznik_003 = " + wsk4.ToString()
                                      + " where id_004_003 = 4" + sqlwhere;
                cmd = new NpgsqlCommand(statement, connection);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            else
            {
                connection.Close();
                connection.Open();
                statement = "update public.preferencje_003"
                            + "      set wskaznik_003 = round(random() * 93 + 1)"
                            + " where id_004_003 = 1" + sqlwhere
                            + " and not exists(select 1 from public.harmonogram_005 where id_001_005 = id_001_003 and id_002_005 = id_002_003)";
                cmd = new NpgsqlCommand(statement, connection);
                cmd.ExecuteNonQuery();

                connection.Close();
                connection.Open();

                statement = "update public.preferencje_003 t003"
                          + "     set wskaznik_003 = round(random() * (93 - "
                          + " (select sum(t0031.wskaznik_003)"
                          + "    from public.preferencje_003 t0031"
                          + "    where t003.id_001_003 = t0031.id_001_003"
                          + "      and t003.id_002_003 = t0031.id_002_003"
                          + "      and t0031.id_004_003 in (1)))   + 1) "
                          + " where id_004_003 = 2" + sqlwhere
                          + " and not exists(select 1 from public.harmonogram_005 where id_001_005 = id_001_003 and id_002_005 = id_002_003)";
                          
                cmd = new NpgsqlCommand(statement, connection);
                cmd.ExecuteNonQuery();

                connection.Close();
                connection.Open();

                statement = "update public.preferencje_003 t003"
                          + " set wskaznik_003 = round(random() * (93 -  "
                          + " (select sum(t0031.wskaznik_003)"
                          + "    from public.preferencje_003 t0031"
                          + "    where t003.id_001_003 = t0031.id_001_003"
                          + "      and t003.id_002_003 = t0031.id_002_003"
                          + "      and t0031.id_004_003 in (1, 2)))   + 1) "
                          + " where id_004_003 = 3" + sqlwhere
                          + " and not exists(select 1 from public.harmonogram_005 where id_001_005 = id_001_003 and id_002_005 = id_002_003)";
                cmd = new NpgsqlCommand(statement, connection);
                cmd.ExecuteNonQuery();

                connection.Close();
                connection.Open();

                statement = "update public.preferencje_003 t003"
                          + " set wskaznik_003 = 100 - "
                          + " (select sum(t0031.wskaznik_003)"
                          + "    from public.preferencje_003 t0031"
                          + "    where t003.id_001_003 = t0031.id_001_003"
                          + "    and t003.id_002_003 = t0031.id_002_003"
                          + "    and t0031.id_004_003 in (1, 2, 3))"
                          + " where id_004_003 = 4" + sqlwhere
                          + " and not exists(select 1 from public.harmonogram_005 where id_001_005 = id_001_003 and id_002_005 = id_002_003)";
                cmd = new NpgsqlCommand(statement, connection);
                cmd.ExecuteNonQuery();
                connection.Close();

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void fmPreferencjeDef_Load(object sender, EventArgs e)
        {

        }
    }
}
