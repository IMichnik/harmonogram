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
    public partial class fmTools : WindowsFormsApplication1.fmGrid
    {
        public fmTools()
        {
            InitializeComponent();
        }
        public fmTools(NpgsqlConnection AConnection) : base(AConnection)
        {
            InitializeComponent();
            new fmGrid(AConnection);
        }
        public override String Filter()
        {
            return "";
        }
        public override String SqlStatement()
        {
            return "SELECT n.nspname as Schema, "
                   + "  pg_catalog.format_type(t.oid, NULL) AS \"Name\" ,"
                   + "  pg_catalog.obj_description(t.oid, 'pg_type') as Description "
                   + " FROM pg_catalog.pg_type t"
                   + "     LEFT JOIN pg_catalog.pg_namespace n ON n.oid = t.typnamespace"
                   + " WHERE(t.typrelid = 0 OR(SELECT c.relkind = 'c' FROM pg_catalog.pg_class c WHERE c.oid = t.typrelid))"
                    + " AND NOT EXISTS(SELECT 1 FROM pg_catalog.pg_type el WHERE el.oid = t.typelem AND el.typarray = t.oid)"
                   + "  AND pg_catalog.pg_type_is_visible(t.oid)"
                   + " ORDER BY 1, 2";
        }

        private void fmTools_Shown(object sender, EventArgs e)
        {
            RefreshGrid();
        }
    }
    
}
