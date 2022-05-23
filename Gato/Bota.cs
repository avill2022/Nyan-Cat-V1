using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Gato
{
    class Bota
    {
        public int x, y;//coordenadas del raton
        public Rectangle rec;//parala interseccion con el jugador
        public Image Imagenes;
        public int t;
        public Bota(int xp, int yp,int tiempoEspera)
        {
            x = xp;
            y = yp;
            Imagenes = Image.FromFile("Enemigos\\Bota.png");//lee las imagenes
            rec = new Rectangle(x,y,32,32);
            t = tiempoEspera;
        }
        //verifica si toca al jugador regresa true
        public bool intersectaJugador(Gato cat)
        {
            if (rec.IntersectsWith(cat.rec) == true)
                return true;
            else
                return false;
        }
        public void mueveBota()
        {

            if (t > 0)
            {
                t -= 1;
            }
            else
            {
                x -= 5;
                rec = new Rectangle(x,y,32,32);
            }
        
        }

    }
}
