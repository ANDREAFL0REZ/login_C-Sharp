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
    public partial class Logueado: BaseForm
    {
        public Logueado()
        {
            InitializeComponent();
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            //si no posible resultado cuando el usuario se le pregunta si desea salir
            DialogResult resultado = MessageBox.Show("¿Seguro deseas SALIR?","Confirmar salida",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(resultado == DialogResult.Yes)
            {
                //codigo para terminar la aplicacion
                Application.Exit();
            }

            

        }

        private void btnnuevo_Click(object sender, EventArgs e)
        {
            //conexion entre formularios
            NuevoLibro nuevoLibro = new NuevoLibro();
            nuevoLibro.Show();
            this.Hide();
        }

        private void btnlistar_Click(object sender, EventArgs e)
        {
            ListarUsuarios llamar = new ListarUsuarios();
            llamar.Show();
            this.Hide();
        }

       
    }
}
