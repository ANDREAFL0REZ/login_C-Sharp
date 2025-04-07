using login;
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
    public partial class NuevoLibro : BaseForm
    {
        MySqlConnection conexionDB = Conexion.conexion();
        public NuevoLibro()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                conexionDB.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string titulo = txtTitulo.Text;
            string autor = txtAutor.Text;
            string editorial = txtEditorial.Text;
            string estado = txtEstado.Text;

            string consulta = "INSERT INTO libros" + " (titulo, autor, editorial, estado)" + "VALUES ('" + titulo + "','" + autor + "','" + editorial + "','" + estado + "')";

            //impulso paar que vaya a la db
            MySqlCommand comando = new MySqlCommand(consulta, conexionDB);
            try
            {
                int filasAfectadas = comando.ExecuteNonQuery();
                if (filasAfectadas > 0)
                {
                    MessageBox.Show("Datos ingresados correctamente");
                    Logueado index = new Logueado();
                    index.Show();
                    this.Hide();
                }
                else
                {
                    Console.WriteLine("No se pudo guardar correctamente");
                    MessageBox.Show("No se afectaronfilas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al ejecutar en la consulta");
                MessageBox.Show("Error al ejecutar la consulta" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            conexionDB.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Logueado index = new Logueado();
            index.Show();
            this.Hide();
        }
    }
    }

    

