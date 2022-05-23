using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Gato
{
    class Bandera
    {
        public Image[] Imagenes;//todas las imagenes
        public Rectangle rec;//rectangulo para la interseccion del jugador
        public int imagen;//imagen actual
        private int anima;//tiempo dela animacion
        public int x, y;//coordenadas

        public Bandera(int xb, int yb)
        {
            anima = 0;
            x = xb;
            y = yb;
            Imagenes = new Image[3];
            rec = new Rectangle(xb,yb,32,32);
            Random a = new Random();
            imagen = 0;
            for (int i = 0; i < 3; i++)
            {
                Imagenes[i] = Image.FromFile("Bloques\\bandera" + i + ".png");
            }
        }
        //animacion para la bandera
        public void ondeaBandera()
        {
            anima += 1;
            if (anima == 10)
            {
                imagen += 1;
                if (imagen == 3)
                {
                    imagen = 0;
                }
                anima = 0;
            
            }
        }
        //verifica si toca al jugador
        public bool tocaAjugador(Gato cat)
        {
            if (rec.IntersectsWith(cat.rec) == true)
                return true;
            else
                return false;
        }
    }
}
