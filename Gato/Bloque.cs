using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Gato
{
    class Bloque
    {
        public Image Imagen;//imagen del bloque
        public int x, y, tipo;//tipo de bloque
        public Rectangle rec;//para las intersecciones
        private Point PC;//punto actual
        public Point pc { get { return PC; } }
        public Bloque(int X, int Y, Image ima, int t)//constructor 1 por si tiene imagen
        {
            PC = new Point(X, Y);
            x = X;
            y = Y;
            rec = new Rectangle(x,y,48,48);
            Imagen = ima;
            tipo = t;
        }
        public Bloque(int X, int Y, int t)//constructor 2 si no tiene imagen
        {
            PC = new Point(X, Y);
            x = X;
            y = Y;
            tipo = t;
            rec = new Rectangle(x, y, 48, 48);
        }
    }
}
