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
    public partial class Inicio: BaseForm
    {
        private int conteo;
        public Inicio()
        {
            InitializeComponent();
            conteo = 0;
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            label5.BackColor = Color.White;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            conteo+=25;
            label5.Text = conteo.ToString() + "%";
            progressBar1.Value = conteo;
            if(conteo == 100)
            {
                timer1.Enabled = false;
                Form1 llamar = new Form1();
                llamar.Show();
                this.Hide();
            }
        }
    }
}
