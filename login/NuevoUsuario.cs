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
        // Objeto de conexión a la base de datos
        MySqlConnection conexionDB = Conexion.conexion();
        private void btnagregar_Click(object sender, EventArgs e)
        {
            try
            {
                //abrir la conexión a la base de datos
                conexionDB.Open();
            }
            catch (Exception ex)
            {
                // Muestra un mensaje de error si no se puede establecer la conexión
                MessageBox.Show(ex.Message);
            }
            // Captura los datos ingresados en el formulario
            string nombre = txtNomCompleto.Text;
            string usuario = txtUsuario.Text;
            string contrasena = txtContrasena.Text;

            // Consulta SQL para insertar un nuevo usuario
            string consulta = "INSERT INTO usuarios" + " (nombreCompleto, nomUsuario, contrasena)" + "VALUES ('" + nombre + "','" + usuario + "','" + contrasena + "')";
           
            // Creación y ejecución del comando SQL
            MySqlCommand comando = new MySqlCommand(consulta, conexionDB);
            try
            {
                // Ejecuta la consulta SQL
                int filasAfectadas = comando.ExecuteNonQuery();
                if (filasAfectadas > 0)
                { // Muestra un mensaje de éxito si el usuario fue registrado correctamente
                    MessageBox.Show("Datos ingresados correctamente");
                    Inicio index = new Inicio();
                    index.Show();
                    this.Hide();
                }
                else
                {
                    // Muestra un mensaje de error si no se insertó el usuario
                    Console.WriteLine("No se pudo guardar correctamente");
                    MessageBox.Show("No se afectaronfilas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                // Captura cualquier error que ocurra durante la ejecución de la consulta y muestra el mensaje de error
                MessageBox.Show("Error al ejecutar en la consulta");
                MessageBox.Show("Error al ejecutar la consulta" + ex.Message,"Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            // Cierra la conexión a la base de datos 
            conexionDB.Close();
        }
        private void btncancelar_Click(object sender, EventArgs e)
        {
            //si cancela, nos redirige al formulario de inicio.
            Inicio index = new Inicio();
            index.Show();
            this.Hide();
        }
    }
}
