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
    public partial class fmStatystyki : WindowsFormsApplication1.fmGrid
    {
        public fmStatystyki()
        {
            InitializeComponent();
        }
        public fmStatystyki(NpgsqlConnection AConnection) : base(AConnection)
        {
            InitializeComponent();
            new fmGrid(AConnection);
        }
        public override String SqlStatement()
        {
            String Result = "select data_002 as Data, imie_001 as \"Imię\", nazwisko_001 as Nazwisko, t0057.id_004_005 as \"Dyżur\", t0031.wskaznik_003 as \"wskaznik 7\",  "
                 + " t0032.wskaznik_003 as \"wskaznik 8\",  "
                 + "   t0033.wskaznik_003 as \"wskaznik 9\", t0034.wskaznik_003 as \"wskaznik 10\",  "
                 + " (select count(*) from public.harmonogram_005 t0051 where id_004_005 = 1  and id_001_005 = id_001 and t0051.id_002_005 <= t002.id_002)  as \"dyzury na 7\",  "
                 + " (select count(*) from public.harmonogram_005 t0052 where id_004_005 = 2  and id_001_005 = id_001 and t0052.id_002_005 <= t002.id_002)  as \"dyzury na 8\",  "
                 + " (select count(*) from public.harmonogram_005 t0053 where id_004_005 = 3  and id_001_005 = id_001 and t0053.id_002_005 <= t002.id_002)  as \"dyzury na 9\",  "
                 + " (select count(*) from public.harmonogram_005 t0054 where id_004_005 = 4  and id_001_005 = id_001 and t0054.id_002_005 <= t002.id_002)  as \"dyzury na 10\",  "
                 + "  (select count(*) "
                 + "   from public.harmonogram_005 t0056 "
                 + "   left join public.preferencje_003 on id_001_005 = id_001_003 and id_002_005 = id_002_003 and id_004_005 = id_004_003 "
                 + "   where id_001_005 = id_001 and t0056.id_002_005 <= t002.id_002) as \"Przeprac. dni\", "
                 + "   (select COALESCE(sum(wskaznik_003), 0) "
                 + "   from public.harmonogram_005 t0055 "
                 + "   left join public.preferencje_003 on id_001_005 = id_001_003 and id_002_005 = id_002_003 and id_004_005 = id_004_003 "
                 + "   where id_001_005 = id_001  and t0055.id_002_005 <= t002.id_002) as suma_wskaznik_003, "
                 + "   (select COALESCE(sum(wskaznik_003), 0) "
                 + "   from public.harmonogram_005 t0059 "
                 + "   left join public.preferencje_003 on id_001_005 = id_001_003 and id_002_005 = id_002_003 and id_004_005 = id_004_003 "
                 + "   where id_001_005 = id_001  and t0059.id_002_005 <= t002.id_002)/ "
                 + "   (select count(*) "
                 + "   from public.harmonogram_005 t0058 "
                 + "   left join public.preferencje_003 on id_001_005 = id_001_003 and id_002_005 = id_002_003 and id_004_005 = id_004_003 "
                 + "   where id_001_005 = id_001 and t0058.id_002_005 <= t002.id_002) as \"Poziom zadowolenia\" "
                 + "    "
                 + "   from dni_robocze_002 t002"
                 + "   join public.harmonogram_005 t0057 on t0057.id_002_005 = t002.id_002"
                 + "   join preferencje_003 t0031 on t0031.id_001_003 = t0057.id_001_005 and t0031.id_002_003 = id_002 and t0031.id_004_003 = 1"
                 + "   join preferencje_003 t0032 on t0032.id_001_003 = t0057.id_001_005 and t0032.id_002_003 = id_002 and t0032.id_004_003 = 2"
                 + "   join preferencje_003 t0033 on t0033.id_001_003 = t0057.id_001_005 and t0033.id_002_003 = id_002 and t0033.id_004_003 = 3"
                 + "   join preferencje_003 t0034 on t0034.id_001_003 = t0057.id_001_005 and t0034.id_002_003 = id_002 and t0034.id_004_003 = 4"
                 + "   left join public.nieobecnosci_006 on ID_001_006 = t0057.id_001_005 and data_006 = data_002"
                 + "   left join pracownicy_001 t001 on t0057.id_001_005 = t001.id_001 "
                 + "   where data_002 = '" + dtpDay.Value.ToString() +  "' and ID_006 is null  and aktywny_001 = true";
                 return Result;

                ;

        }
        public override String Order()
        {
            return " order by 1, 3, 2";
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
         
        }

        private void fmStatystyki_Shown(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void dtpDay_ValueChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void fmStatystyki_Load(object sender, EventArgs e)
        {

        }
    }
}
