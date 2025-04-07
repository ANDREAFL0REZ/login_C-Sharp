using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace login
{
    public partial class ListarUsuarios: BaseForm
    {
        public ListarUsuarios()
        {
            InitializeComponent();
        }
        private void CargarDatos()
        {
            try
            {
                using (MySqlConnection conexioDB = Conexion.conexion())
                {
                    String consulta = "SELECT * FROM libros";
                    //adaptador que va a sevir para traer los adtos
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexioDB);
                    //tabla logica deacuerdo al adpador para recibir los datos
                    DataTable dt = new DataTable();
                    adaptador.Fill(dt);

                    dataGridView1.DataSource = dt;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void desabilitarBotones()
        {
            btnActualizar.Enabled = false;
            btneliminar.Enabled = false;
        }
        private void habilitarBotones()
        {
            btnActualizar.Enabled = true;
            btneliminar.Enabled = true;
        }
        private void limpiarTextos()
        {
            //para limpiar textbox todos de una
            foreach(Control ctr in this.Controls)
            {
                if(ctr is TextBox textBox)
                {
                    textBox.Clear();
                }
            }
        }

        private void btnlistar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void ListarUsuarios_Load(object sender, EventArgs e)

        {
            //cuando llegue al formulario automaticamente muestre los datod sin pisar boton listar
            CargarDatos();
            desabilitarBotones();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //llevar datos a actualizar datos--arreglo empieza en 0
            txtid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txttitulo.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtautor.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txteditorial.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtestado.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            habilitarBotones();

        }

        private void btncancelar_Click(object sender, EventArgs e)
        {
            limpiarTextos();
            desabilitarBotones();
        }

        private void btnvolver_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Datos ingresados correctamente");
            Logueado llamar = new Logueado();
            llamar.Show();
            this.Hide();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conexionDB = Conexion.conexion()) 
                {
                    conexionDB.Open();
                    int bandera = 0;
                    string id = txtid.Text;
                    string titulo = txttitulo.Text;
                    string autor = txtautor.Text;
                    string editorial = txteditorial.Text;
                    string estado= txtestado.Text;
                    //consulta para actualizar
                    string consulta = "UPDATE libros SET id='" + id + "', titulo='" + titulo + "', autor='" + autor + "', editorial='" + editorial + "', estado='" + estado + "'WHERE id='" + id + "'";
                    //
                    MySqlCommand comando = new MySqlCommand(consulta, conexionDB);
                    bandera = comando.ExecuteNonQuery();
                    if(bandera == 1)
                    {
                        MessageBox.Show("Datos actualizados correctamente");
                        CargarDatos();
                        limpiarTextos();
                        desabilitarBotones();
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar");
                    }
                    conexionDB.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conexionDB = Conexion.conexion())
                {
                    conexionDB.Open();
                    int bandera = 0;
                    string id = txtid.Text;
                    string titulo = txttitulo.Text;
                    string autor = txtautor.Text;
                    string usuario = txteditorial.Text;
                    string contrasena = txtestado.Text;
                    string consulta = "DELETE FROM libros WHERE id='" + id + "'";
                    DialogResult respuesta = MessageBox.Show("Realmete quieres eliminar este libro '"+titulo +"'?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(respuesta == DialogResult.Yes)
                    {
                        MySqlCommand comando = new MySqlCommand(consulta, conexionDB);
                        bandera = comando.ExecuteNonQuery();
                        if (bandera == 1)
                        {
                            MessageBox.Show("Datos actualizados correctamente");
                            CargarDatos();
                            limpiarTextos();
                            desabilitarBotones();
                        }
                        else
                        {
                            MessageBox.Show("Error al actualizar");
                        }
                   
                    }
                    conexionDB.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
