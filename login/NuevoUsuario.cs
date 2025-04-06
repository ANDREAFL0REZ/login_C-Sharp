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
    public partial class NuevoUsuario: Form
    {
        public NuevoUsuario()
        {
            InitializeComponent();
        }
        MySqlConnection conexionDB = Conexion.conexion();
        private void btnagregar_Click(object sender, EventArgs e)
        {
            try
            {
                conexionDB.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //instruccion para que se guarde en la db

            string nombre = txtNomCompleto.Text;
            string usuario = txtUsuario.Text;
            string contrasena = txtContrasena.Text;

            string consulta = "INSERT INTO usuarios" + " (nombreCompleto, nomUsuario, contrasena)" + "VALUES ('" + nombre + "','" + usuario + "','" + contrasena + "')";

            //impulso paar que vaya a la db
            MySqlCommand comando = new MySqlCommand(consulta, conexionDB);
            try
            {
                int filasAfectadas = comando.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Datos ingresados correctamente");
                    Inicio index = new Inicio();
                    index.Show();
                    this.Hide();
                }
                else
                {
                    Console.WriteLine("No se pudo guardar correctamente");
                    MessageBox.Show("No se afectaronfilas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al ejecutar en la consulta");
                MessageBox.Show("Error al ejecutar la consulta" + ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            conexionDB.Close();
        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            Inicio index = new Inicio();
            index.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtNomCompleto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
