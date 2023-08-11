using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamburgerProject.Utilitys
{
    public class Helper
    {
        public static void Temizle(Control.ControlCollection kontroller)
        {
            foreach (Control control in kontroller)
            {
                if (control is ComboBox)
                {
                    ComboBox cb = (ComboBox)control;
                    cb.SelectedIndex = 0;
                }
                else if (control is FlowLayoutPanel)
                {
                    FlowLayoutPanel flp = (FlowLayoutPanel)control;
                    Temizle(flp.Controls);
                }
                else if (control is CheckBox)
                {
                    CheckBox chb = (CheckBox)control;
                    chb.Checked = false;
                }
                else if (control is GroupBox)
                {
                    GroupBox gbox = (GroupBox)control;
                    Temizle(gbox.Controls);
                }
                else if (control is RadioButton)
                {
                    RadioButton rb = (RadioButton)control;
                    if (rb.Text == "Küçük")
                    {
                        rb.Checked = true;
                    }
                    else rb.Checked = false;
                }
                else if (control is NumericUpDown)
                {
                    NumericUpDown nub= (NumericUpDown)control;
                    nub.Value = 1;
                }
                else if(control is TextBox)
                {
                    TextBox txt= (TextBox)control;
                    txt.Clear();
                }
            }
        }
    }
}
