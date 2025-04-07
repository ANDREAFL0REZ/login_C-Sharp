using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class BaseForm : Form
    {

        public BaseForm()
        {
            this.FormClosing += BaseForm_FormClosing;
        }

        private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!GlobalFlags.isClosing)
            {
                // Lógica compartida para el cierre
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas cerrar este formulario?", "Confirmar cierre", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Cancela el cierre si el usuario selecciona "No"
                }
                else
                {

                    GlobalFlags.isClosing = true;

                    foreach (Form form in Application.OpenForms)
                    {
                        if (form != this)
                        {
                            form.Close();
                        }
                    }
                    Application.Exit();
                }
            }
        }
    }
}
