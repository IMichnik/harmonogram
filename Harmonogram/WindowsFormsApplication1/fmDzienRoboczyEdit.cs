using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class fmDzienRoboczyEdit : WindowsFormsApplication1.fmEdit
    {
        DzienRoboczy dzienRoboczy;
        ListaDniRoboczych dniRobocze;
        public fmDzienRoboczyEdit()
        {
            InitializeComponent();
        }

        public override void AssignObjectToForm()
        {
            dzienRoboczy = (DzienRoboczy)dbObject;
            
            if (dniRobocze == null)
            {
                dniRobocze = new ListaDniRoboczych(dzienRoboczy.connection);
                dniRobocze.Load();
                cbDniRobocze.Items.Clear();
                for (int ii = 0; ii < dniRobocze.Count(); ii++)
                {
                    DzienRoboczy dzienRoboczy = dniRobocze.Item(ii);
                    //cbPracownicy.Items.Add(pracownik.Nazwisko + " " + pracownik.Imie);
                    cbDniRobocze.Items.Add(dzienRoboczy);
                }
            }

            
            cbDniRobocze.SelectedIndex = -1;
            if (dzienRoboczy.Id != null)
            {
                for (int ii = 0; ii < dniRobocze.Count(); ii++)
                {
                    if (dniRobocze.Items[ii].Id == dzienRoboczy.Id)
                    {
                        cbDniRobocze.SelectedIndex = ii;
                        break;
                    }
                }
            }
            if (cbDniRobocze.SelectedIndex > -1)
                cbDniRobocze.Enabled = false;
            chbUstalone.Checked = (bool)dzienRoboczy.Ustalone;
            chbRoboczy.Checked = (bool)dzienRoboczy.Roboczy;
        }
        public override void AssignFormToObject()
        {
            if (cbDniRobocze.SelectedIndex == -1)
                dzienRoboczy.Id = null;
            else
                dzienRoboczy.Id = dniRobocze.Items[cbDniRobocze.SelectedIndex].Id;
            dzienRoboczy.Roboczy = chbRoboczy.Checked;
            dzienRoboczy.Ustalone = chbUstalone.Checked;
        }

    }
}
