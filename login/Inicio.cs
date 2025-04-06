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
    public partial class Inicio: Form
    {
        private int conteo; // Contador para la barra de
        public Inicio()
        {
            InitializeComponent();
            conteo = 0;  // Inicializa el contador en 0
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;// Activa el temporizador

            label5.BackColor = Color.White;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            conteo+=5; // Incrementa el valor del contador en 5
            label5.Text = conteo.ToString() + "%"; // Muestra el porcentaje de carga
            progressBar1.Value = conteo;// Actualiza el valor de la barra de progreso
            if (conteo == 100) // Cuando llega al 100%
            {
                timer1.Enabled = false;// Detiene el temporizador
                Form1 llamar = new Form1();// Abre el formulario principal

                llamar.Show();
                this.Hide();// Oculta la ventana actual
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
