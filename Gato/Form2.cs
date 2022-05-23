using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gato
{
    public partial class Form2 : Form
    {
        public Form2(int tipoMensaje)
        {
            InitializeComponent();
            if (tipoMensaje == 0)
                cargaAyudas();
            else
                cargaCreditos();
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void cargaAyudas()
        {
            this.Text = "Ayuda";
            this.label1.Visible = false;
            this.label2.Visible = false;
            this.label3.Visible = false;
            this.label4.Visible = false;
            this.label5.Visible = false;
            this.label6.Visible = false;
        }
        private void cargaCreditos()
        {
            this.Text = "Creditos";
            this.pictureBox1.Visible = false;
        }
    }
}
