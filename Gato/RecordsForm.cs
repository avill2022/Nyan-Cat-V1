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
    public partial class RecordsForm : Form
    {
        public RecordsForm()
        {
            InitializeComponent();
        }

        private void RecordsForm_Load(object sender, EventArgs e)
        {

        }
        public void listaRecords(string Nombre, int Puntos,int indice)
        {
            if(indice == 0)
            l1.Text = "1.- " + Nombre + "               " + Puntos.ToString();
            if (indice == 1)
                l2.Text = "2.- " + Nombre + "               " + Puntos.ToString();
            if (indice == 2)
                l3.Text = "3.- " + Nombre + "               " + Puntos.ToString();
            if (indice == 3)
                l4.Text = "4.- " + Nombre + "               " + Puntos.ToString();
            if (indice == 4)
                l5.Text = "5.- " + Nombre + "               " + Puntos.ToString();
        
        }
    }
}
