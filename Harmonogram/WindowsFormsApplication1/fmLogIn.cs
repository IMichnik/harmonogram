using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Npgsql;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class fLogIn : Form
    {

        public fLogIn()
        {
            InitializeComponent();
        }
        public static NpgsqlConnection LogInExecute(String AServer, String APort, String ADatabase, String AUserName, String APassword)
        {
            fLogIn formLogIn = new fLogIn();
            formLogIn.UserName = AUserName;
            formLogIn.Password = APassword;
            if (formLogIn.tbUserName.Text == "")
                formLogIn.tbUserName.Select();
            else
                formLogIn.tbUserName.Select();
            if (formLogIn.ShowDialog() == DialogResult.OK)
            { 
                NpgsqlConnection Result = new NpgsqlConnection("Server=" + AServer + ";Port=" + APort + ";Database=" + ADatabase + ";User Id=" + formLogIn.UserName + ";" +
                                    "Password=" + formLogIn.Password + ";");
               
                try
                {

                    Result.Open();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    //return null;
                    Result = LogInExecute(AServer, APort, ADatabase, formLogIn.UserName, formLogIn.Password);
                }
                return Result;
            }
            else return null;
        }

        public String UserName
        {
            get
            {
                return tbUserName.Text;
            }
            set
            {
                tbUserName.Text = value;
            }
        }

        public String Password
        {
            get
            {
                return tbPassword.Text;
            }
            set
            {
                tbPassword.Text = value;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; 
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void fLogIn_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void tbUserName_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnLogIn_Click(sender, e);
        }
    }
}
