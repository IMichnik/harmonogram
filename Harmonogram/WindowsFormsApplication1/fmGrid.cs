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
    public partial class fmGrid : Form
    {
        private DbClass _dbObject;  
        public DbClass dbObject
        {
            get
            {
                if (_dbObject == null)
                    _dbObject = CreateDbObject();
                if (dr.HasRows) 
                    _dbObject.AssignFromDataGridView(dataGridView1);
                return  _dbObject;
            }
            //set
            //{
            //    _dbObject = value;
            //}
            
        }
        
        public NpgsqlConnection connection;
        public NpgsqlCommand cmd;
        public NpgsqlDataReader dr;
        public fmGrid()
        {
            InitializeComponent();
        }

        public fmGrid(NpgsqlConnection AConnection)//: base(AConnection)
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
            connection = AConnection;
        }

        public void fmGrid_Shown(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        public virtual String Order()
        {
            return "";
        }

        public virtual String Filter()
        {
            return "";
        }
        public virtual DbClass CreateDbObject()
        {
            return new DbClass(connection);
        }

        public virtual fmEdit CreateEditForm() 
        {
            return new fmEdit();
        }
        
        public void RefrershDbObjectList()
        {
            
        }

        public virtual String SqlStatement()
        {
            return "";
        }
        public virtual void AssignColumnTitles()
        {

        }
        public void RefreshGrid()
        {
            try
            {
                connection.Close();
                connection.Open();
                cmd = new NpgsqlCommand(SqlStatement() + Filter() + Order(), connection);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    bindingSource1.DataSource = dr;
                    AssignColumnTitles();
                }
                else
                {
                    bindingSource1.DataSource = null;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }            
        }

        public void btnDodaj_Click(object sender, EventArgs e)
        {
            fmEdit EditForm = CreateEditForm();
            EditForm.dbObject = CreateDbObject();
            EditForm.ShowDialog();
            RefreshGrid();
        }

        public void btnModyfikuj_Click(object sender, EventArgs e)
        {
            fmEdit EditForm = CreateEditForm();

            EditForm.dbObject = dbObject;
            EditForm.ShowDialog();
            RefreshGrid();
        }

        public void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            
        }

        public void btnUsun_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index > -1)
            {
                dbObject.Delete();
                RefreshGrid();
            }
        }

        public void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Index > -1)
            {
                fmEdit EditForm = CreateEditForm();
                EditForm.dbObject = dbObject;
                EditForm.ShowDialog();
                RefreshGrid();
            }
        }

        public void btnAnuluj_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
