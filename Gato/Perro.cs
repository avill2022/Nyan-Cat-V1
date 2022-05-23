using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Gato
{
    class Perro
    {
        public int x, y;//coordenadas del perro
        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public Image[] Imagenes;
        public Rectangle rec;//parala interseccion con el jugador
        public int imagen;//imgen actual
        public bool dormido;//por si se puede mover
        private int movimieto;//que tan rapido se mueve
        private int direccion;//la direccion derecha o izquierda
        private int tiempo;//tiempo en el que cambia las imagenes
        private int anima;//
        public Perro(int xp, int yp)
        {
            dormido = true;
            tiempo = 0;
            anima = 0;
            Imagenes = new Image[10];
            rec = new Rectangle(xp,yp,32,32);
            Random a = new Random();
            direccion = a.Next(0, 1);
            imagen = 0;
            cargaImagenes();
            x = xp;
            y = yp;
        }
        
        public void cargaImagenes()
        {
            int num = 0;
            for (int i = 0; i < 9; i++)
            {
                Imagenes[i] = Image.FromFile("Enemigos\\Dog" + num + ".png");//lee las imagenes
                if (num == 4)
                    num = 0;
                num++;
            }
            for (int i = 5; i < 9; i++)
            {
                Imagenes[i].RotateFlip(RotateFlipType.RotateNoneFlipX);//rota las imagenes

            }
        }
        //verifica si toca al jugador regresa true
        public bool intersectaJugador(Gato cat)
        {
            if (rec.IntersectsWith(cat.rec) == true)
                return true;
            else
                return false;
        }
        //verifica si esta tocando al jugador si si se empieza a mover si no solo dibuja la imagen dormido
        public void actua(Gato cat)
        {
            if (dormido == true)
            {
                imagen = 0;
                Rectangle r = new Rectangle(x - 32, y - 32, 94,93);
                if (r.IntersectsWith(cat.rec))
                    dormido = false;
            }
            else
            {
                animacion();
                tiempo += 1;
                if (tiempo == 5)
                {
                    muevePerro();
                    tiempo = 0;
                }
            }
        
        }
        //cambia las imagenes para generar la animacion
        public void animacion()
        {
            anima+=1;
            if (anima == 41)
                anima = 0;
            if (direccion == 0)
            {
                if (anima == 10)
                    imagen = 1;
                if (anima == 20)
                    imagen = 2;
                if (anima == 30)
                    imagen = 3;
                if (anima == 40)
                    imagen = 4;
            }
            if (direccion == 1)
            {
                if (anima == 10)
                    imagen = 5;
                if (anima == 20)
                    imagen = 6;
                if (anima == 30)
                    imagen = 7;
                if (anima == 40)
                    imagen = 8;
            }
        }
        //cambia la direccion del movimiento del perro
        public void muevePerro()
        {
            movimieto += 1;
            if(movimieto==40)
            {
                movimieto = 0;
                if (direccion == 0)
                {
                    imagen = 5;
                    direccion = 1;
                }
                else
                {
                    imagen = 1;
                    direccion = 0;
                }
            }
            if (direccion == 0)
                this.x += 2;
            if(direccion == 1)
                this.x-=2;
            rec = new Rectangle(x+5,y+5,20,20);
        }

    }
}
