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
    public partial class fmEdit : Form
    {
        public DbClass dbObject;
        public string ServerName;
        public string UserName;
        public string Password;

        public NpgsqlConnection connection;
        public NpgsqlCommand cmd;
        public NpgsqlDataReader dr;
        public fmEdit()
        {
            InitializeComponent();
        }
        public virtual Boolean DoBeforeSave()
        {
            return true;
        }
        public Boolean DoSave()
        {   
            if (DoBeforeSave())
            {
                dbObject.Save();
                return DoAfterSave();
            }
            return false;
        }
        public virtual Boolean DoAfterSave()
        {
            return true;
        }

        private void fmEdit_Shown(object sender, EventArgs e)
        {
            AssignObjectToForm();
        }
        public virtual void AssignObjectToForm()
        {
            

        }
        public virtual void AssignFormToObject()
        {

        }

        private void btnZamknij_Click(object sender, EventArgs e)
        {
            Close();
        }

        public virtual void btnZapisz_Click(object sender, EventArgs e)
        {
            AssignFormToObject();
            DoSave();
        }

        private void btnZapiszZamknij_Click(object sender, EventArgs e)
        {
            AssignFormToObject();
            if (DoSave())
                Close();
        }
        
    }   
}
