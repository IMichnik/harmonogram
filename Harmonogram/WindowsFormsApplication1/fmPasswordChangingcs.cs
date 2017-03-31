using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class fmPasswordChanging : Form
    {
        public fmPasswordChanging()
        {
            InitializeComponent();
        }

        //public Pracownik pracownik;

        public String Login
        {
            get
            {
                return tbLogin.Text;
            }
            set
            {
                tbLogin.Text = value;
            }
        }

        public String NewPassword
        {
            get
            {
                return tbNewPassword.Text;
            }
            set
            {
                tbNewPassword.Text = value;
            }
        }

        public String RepeatedPassword
        {
            get
            {
                return tbRepeatedPassword.Text;
            }
            set
            {
                tbRepeatedPassword.Text = value;
            }
        }


        public static void ChangePasswordExecute(Pracownik APracownik)
        {
            fmPasswordChanging fPasswordChanging = new fmPasswordChanging();
            //fPasswordChanging.pracownik = APracownik;
            fPasswordChanging.Login = APracownik.Login;
            

            if (fPasswordChanging.ShowDialog() == DialogResult.OK)
            {
                APracownik.ChangePassword(fPasswordChanging.NewPassword); 
            }
            fPasswordChanging.Close();
        }

        public static void CreateUserExecute(Pracownik APracownik)
        {
            fmPasswordChanging fPasswordChanging = new fmPasswordChanging();
            //fPasswordChanging.pracownik = APracownik;
            fPasswordChanging.Login = APracownik.Login;


            if (fPasswordChanging.ShowDialog() == DialogResult.OK)
            {
                APracownik.CreateUser(fPasswordChanging.NewPassword, "pracownik");
            }
            fPasswordChanging.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((NewPassword == "") || (NewPassword != RepeatedPassword))
                return;
            else
                
                this.DialogResult = DialogResult.OK;

        }
    }
}
