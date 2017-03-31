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
    public partial class fmObsada : Form
    {
        ObsadaDyzurow DataObject;
        public fmObsada(ObsadaDyzurow AObsadaDyzurow)
        {
            InitializeComponent();
            DataObject = AObsadaDyzurow;
            AssignObjectToForm();
        }
        public void AssignObjectToForm()
        {
            tbDyzur1.Text = DataObject.dyzury[0].Obsada.ToString();
            tbDyzur2.Text = DataObject.dyzury[1].Obsada.ToString();
            tbDyzur3.Text = DataObject.dyzury[2].Obsada.ToString();
            tbDyzur4.Text = DataObject.dyzury[3].Obsada.ToString();
        }

        public void AssignFormToObject()
        {
            int iObsada = -1;
            if (int.TryParse(tbDyzur1.Text, out iObsada))
                DataObject.dyzury[0].Obsada = iObsada;
            if (int.TryParse(tbDyzur2.Text, out iObsada))
                DataObject.dyzury[1].Obsada = iObsada;
            if (int.TryParse(tbDyzur3.Text, out iObsada))
                DataObject.dyzury[2].Obsada = iObsada;
            if (int.TryParse(tbDyzur4.Text, out iObsada))
                DataObject.dyzury[3].Obsada = iObsada;
        }
        private void zapiszToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AssignFormToObject();
            DataObject.Save();
            Close();
        }

        private void plikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void zAmknijToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AssignFormToObject();
            DataObject.Save();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
