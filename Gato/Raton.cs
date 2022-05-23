using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Gato
{
    class Raton
    {
        public int x, y;//coordenadas del raton
        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public Image[] Imagenes1;//imagenes del gato
        public Image[] Imagenes2;//imagenes del gato
        public Rectangle rec;//parala interseccion con el jugador
        public int direccion;
        public int imagen1=0;

        public Raton(int xp, int yp)
        {
            rec = new Rectangle( xp, yp, 32, 32);
            //Imagen = Image.FromFile("Enemigos\\Rat1.png");//lee las imagen
            Imagenes1 = new Image[2];//numero de imagenes
            Imagenes2 = new Image[2];//numero de imagenes
            for (int i = 0; i < 2; i++)
            {
                Imagenes1[i] = Image.FromFile("Enemigos\\Rat" + i + ".png");//lee las imagenes
                Imagenes2[i] = Image.FromFile("Enemigos\\Rat" + i + ".png");//lee las imagenes
            }
            for (int i = 0; i < 2; i++)
            {
                Imagenes2[i].RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            x = xp;
            y = yp;
            direccion = 0;
        }
        //verifica si toca al jugador regresa true
        public bool intersectaJugador(Gato cat)
        {
            if (rec.IntersectsWith(cat.rec) == true)
                return true;
            else
                return false;
        }
        //cambia la direccion del movimiento del raton
        public void mueveRaton(int ancho, int Scroll, Bloque[,] Mundo)
        {
            if (direccion == 0 && !TocaAnt(ancho, Scroll, Mundo))
                this.X -= 1;
            else
                direccion = 1;

            if (direccion == 1 && !TocaSig(ancho, Scroll, Mundo))
                this.X += 1;
            else
                direccion = 0;

            if (imagen1 == 0)
                imagen1 = 1;
            else
                imagen1 = 0;

            rec = new Rectangle(x + 10, y + 10, 25, 25);
        }
        public bool TocaAnt(int ancho, int largo, Bloque[,] Mundo)
        {
            //recorre el mapa y verifica bloque por bloque el tipo si es 1 checa si lo esta tocando
            for (int i = 0; i < ancho; i++)
            {
                for (int j = 0; j < largo; j++)
                {
                    if (Mundo[i, j].tipo == '1' || Mundo[i, j].tipo == '2' || Mundo[i, j].tipo == '3')
                        if (X - 1 > Mundo[i, j].x && X - 1 < Mundo[i, j].x + 48 && Y + 24 > Mundo[i, j].y && Y + 24 < Mundo[i, j].y + 48)
                            return true;
                }
            }
            return false;
        }
        //verifica si toca a algun objeto adelante de el
        public bool TocaSig(int ancho, int largo, Bloque[,] Mundo)
        {
            for (int i = 0; i < ancho; i++)
            {
                for (int j = 0; j < largo; j++)
                {
                    if (Mundo[i, j].tipo == '1' || Mundo[i, j].tipo == '2' || Mundo[i, j].tipo == '3')
                        if (X + 47 > Mundo[i, j].x && X + 24 < Mundo[i, j].x + 48 && Y + 24 > Mundo[i, j].y && Y + 24 < Mundo[i, j].y + 48)
                            return true;
                }
            }
            return false;
        }
    }
}
