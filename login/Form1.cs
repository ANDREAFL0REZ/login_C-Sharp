using MySql.Data.MySqlClient;
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
    public partial class Form1: Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MySqlConnection conexionDB = Conexion.conexion();
        private void btnlogin_Click(object sender, EventArgs e)
        {
            //generar un try caht para abrir la conexion o diga cual es el error de la conexion
            try
            {
                //siempres se dee abrir y cerrar la conexion 
                conexionDB.Open();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // despues de que esta abierta la base de datos generamos una instruccion que mes irve para hacer la ejecucion de un query
            MySqlCommand codigo = new MySqlCommand();
            //abrimos conexion
            codigo.Connection = conexionDB;
            // texto -> sentencia que le voy a enviar para que lo haga
            // el comman necesita conexion y instruccion
            codigo.CommandText = ("SELECT * FROM usuarios WHERE nomUsuario='"+ textusuario.Text+"' and contrasena='"+ textcontrasena.Text+ "'");

            //vamos a ejecutarla para trabajar con la DB
            MySqlDataReader leer = codigo.ExecuteReader();
            //vamos a utilizar el leer con condicional
            //si leyo bien ] todo correcto 
            if (leer.Read())
            {
                //llamamos el formulario si el primer formulario se lleno correctamente
                Logueado llamar = new Logueado();
                llamar.Show();
                this.Hide();

            }
            else
            {
                //si no mostrar este mensaje de advertencia---titulo del cuadro---va a apraecer boton acepta(ok)--simboloError
                MessageBox.Show("usuario o contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textusuario.Clear();
                textcontrasena.Clear();
                //focus para que el cursor se ponga automaticamente
                textusuario.Focus();
            }
            //cerramos conexion antes de que termine el codigo 
            conexionDB.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            NuevoUsuario newUser = new NuevoUsuario();
            newUser.Show();
            this.Hide();
        }
    }
}
