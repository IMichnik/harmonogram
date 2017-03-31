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
    public partial class fmMainForm : Form
    {
        private NpgsqlConnection connection;
        private int childFormNumber = 0;
        ObsadaDyzurow obsadaDyzurow; //= new Obsada()
        string ServerName;
        string Port;
        string Database;
        //string UserName;
        //string Password;
        fmPracownicy fPracownicy;
        fmDniRobocze fDniRobocze;
        fmHarmonogram fHarmonogram;
        fmObsada fObsada;
        fmPreferencje fPreferencje;
        fmStatystyki fStatystyki;
        fmNieobecnosci fNieobecnosci;
        public fmMainForm()
        {

            var MyIni = new IniFile("Harmonogram.ini");
            InitializeComponent();
            ServerName = MyIni.Read("ServerName", "Connection"); //"127.0.0.1";
            Port = MyIni.Read("Port", "Connection");//"5432";
            Database = MyIni.Read("Database", "Connection"); //"postgres";



        }
        
        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private Form findForm(String FormName)
        {
            foreach (Form childForm in MdiChildren)
            {
                if(childForm.Name == FormName)
                    return childForm;
            }
            return null;
        }
        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void pracownicyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //
            fPracownicy = (fmPracownicy)findForm("fPracownicy");
            if (fPracownicy == null)
            {
                fPracownicy = new fmPracownicy(connection);
                fPracownicy.MdiParent = this;
                fPracownicy.Name = "fPracownicy";
                fPracownicy.Text = "Pracownicy";
                //fPracownicy.Anchor = 
                fPracownicy.Show();
            }
            else
            {
                fPracownicy.BringToFront();
            }
        }
        

        private void preferencjeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fPracownicy = (fmPracownicy)findForm("fPracownicy");
            if (fPracownicy == null)
            {
                fPracownicy = new fmPracownicy(connection);
                fPracownicy.MdiParent = this;
                fPracownicy.Name = "fPracownicy";
                fPracownicy.Text = "Pracownicy";
                fPracownicy.Show();
            }
            else
            {
                fPracownicy.BringToFront();
            }
        }
        
        private void harmonogramToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fHarmonogram =(fmHarmonogram)findForm("fHarmonogram");
            if (fHarmonogram == null)
            {
                fHarmonogram = new fmHarmonogram(connection);
                fHarmonogram.Name = "fHarmonogram";
                fHarmonogram.MdiParent = this;
                fHarmonogram.Text = "Harmonogram";
                fHarmonogram.Show();
            }
            else
            {
                fHarmonogram.BringToFront();
            }
        }

        private void toolsMenu_Click(object sender, EventArgs e)
        {
            if (fPracownicy == null)
            {
                fPracownicy = new fmPracownicy(connection);
                fPracownicy.MdiParent = this;
                fPracownicy.Text = "Pracownicy";
                fPracownicy.Show();
            }
            else
            {
                fPracownicy.BringToFront();
            }
        }

        private void preferencjeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            fPreferencje = (fmPreferencje)findForm("fPreferencje");
            if (fPreferencje == null)
            {
                fPreferencje = new fmPreferencje(connection);
                fPreferencje.MdiParent = this;
                fPreferencje.Name = "fPreferencje";
                fPreferencje.Text = "Preferencje";
                fPreferencje.Show();
            }
            else
            {
                fPreferencje.BringToFront();
            }
        }

        private void dniRoboczeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fDniRobocze = (fmDniRobocze)findForm("fDniRobocze");
            if (fDniRobocze == null)
            {
                fDniRobocze = new fmDniRobocze(connection);
                fDniRobocze.MdiParent = this;
                fDniRobocze.Name = "fDniRobocze";
                fDniRobocze.Text = "DniRobocze";
                fDniRobocze.Show();
            }
            else
            {
                fDniRobocze.BringToFront();
            }
        }

        private void obsadaDyżurówToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fObsada = (fmObsada)findForm("fObsada");
            if (fObsada == null)
            {
                obsadaDyzurow = new ObsadaDyzurow(connection);
                fObsada = new fmObsada(obsadaDyzurow);
                fObsada.MdiParent = this;
                fObsada.Name = "fObsada";
                fObsada.Text = "Obsada";
                fObsada.Show();
            }
            else
            {
                fObsada.BringToFront();
            }
        }

        private void statystykiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fStatystyki = (fmStatystyki)findForm("fStatystyki");
            if (fStatystyki == null)
            {
                fStatystyki = new fmStatystyki(connection);
                fStatystyki.MdiParent = this;
                fStatystyki.Name = "fStatystyki";
                fStatystyki.Text = "Statystyki";
                fStatystyki.Show();
            }
            else
            {
                fStatystyki.BringToFront();
            }
        }

        private void fmMainForm_Shown(object sender, EventArgs e)
        {
            connection = fLogIn.LogInExecute(ServerName, Port, Database, "postgres", "masterkey");
            if (connection == null)
                Close();
        }

        private void fileMenu_Click(object sender, EventArgs e)
        {

        }

        private void miChangePassword_Click(object sender, EventArgs e)
        {
            NpgsqlCommand cmd = new NpgsqlCommand("select \"current_user\"() ", connection);
            NpgsqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                
                String sLogin = dr.GetString(0);
                connection.Close();
                connection.Open();

                Pracownik pracownik = new Pracownik(connection);
                pracownik.Login = sLogin;
                fmPasswordChanging.ChangePasswordExecute(pracownik);
            }
        }

        private void logowanieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connection = fLogIn.LogInExecute(ServerName, Port, Database, "postgres", "masterkey");
            if (connection == null)
                Close();
        }

        private void nieobecnościToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fNieobecnosci = (fmNieobecnosci)findForm("fNieobecnosci");
            if (fNieobecnosci == null)
            {
                fNieobecnosci = new fmNieobecnosci(connection);
                fNieobecnosci.MdiParent = this;
                fNieobecnosci.Name = "fNieobecnosci";
                fNieobecnosci.Text = "Nieobecnosci";
                fNieobecnosci.Show();
            }
            else
            {
                fNieobecnosci.BringToFront();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Combination combination = new Combination(6, 3);
            combination.Reset();
            combination.ToString();
            Console.WriteLine(combination.ToStringAll());
            while (combination.Next())
            {
                Console.WriteLine(combination.ToStringAll());
            }    
        }
    }
}
