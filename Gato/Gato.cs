using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Gato
{
    class Gato
    {
        private float x, y;//coordenadas del gato
        public float x1, y1;//coordenadas del gato
        public float x1t, y1t;//coordenadas del gato
        public float X { get { return x; } set { x = value; } }
        public float Y { get { return y; } set { y = value; } }
        public Image[] Imagenes1;//imagenes del gato
        public Image[] Imagenes2;//imagenes del gato
        public Rectangle rec;//rectangulo para las intersecciones
        public int distancia = 10;////la distancia que puede brincar
        public int imagen1;//la imagen actual
        public bool brincando = false;//si el gato esta brincando
        public int Puntos;
        private int tiempo;//tienpo en el que se cambian als imagenes
        public string nombre;
        int bloquesEvalua = 20;
        public int direccion = 0;
        public float tocaSuelo;

        public Gato(int cx,int cy) 
        {
            Puntos = 0;
            nombre = "..";
            rec = new Rectangle(cx,cy,32,32);// rectangulo inicial
            Imagenes1 = new Image[2];//numero de imagenes
            Imagenes2 = new Image[2];//numero de imagenes
            distancia = 10;
            imagen1 = 0;
            for (int i = 0; i < 2; i++)
            {
                Imagenes1[i] = Image.FromFile("Cat\\Cat" + i + ".png");//lee las imagenes
                Imagenes2[i] = Image.FromFile("Cat\\Cat" + i + ".png");//lee las imagenes
            }
            for (int i = 0; i < 2; i++)
            {
                Imagenes2[i].RotateFlip(RotateFlipType.RotateNoneFlipX);
            }
            this.x = cx;
            this.y = cy;
        }
        public void modificaCordenadas()
        {
            x1 = x;
            y1 = y + 15;
            x1t = x1 + 45;
            y1t = y + 45;
        
        }
        // icrementa la variable imagen segun el tiepo
        public void animacion()
        {
            tiempo += 1;
            if (tiempo >= 4)
            {
                if(brincando == false)
                {
                    if (imagen1 == 0)
                        imagen1 = 1;
                    else
                        imagen1 = 0;

                    tiempo = 0;
                }
            }
        }
        public bool TocaPuntos(int ancho, int Scroll, Bloque[,] Mundo)
        {
            //recorre el mapa y verifica bloque por bloque el tipo si es 1 checa si lo esta tocando
            for (int i = 0; i < ancho; i++)
            {
                for (int j = Scroll; j < bloquesEvalua + Scroll; j++)
                {
                    if (Mundo[i, j].tipo == 54 || Mundo[i, j].tipo == 55)
                    {
                        if (this.rec.IntersectsWith(Mundo[i, j].rec))
                        {
                            Mundo[i, j].tipo = 0;
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        //verifica si toca a algun objeto atras de el, si es asi retorna true
        public bool TocaAnt(int ancho, int Scroll,Bloque[,] Mundo)
        {
            //recorre el mapa y verifica bloque por bloque el tipo si es 1 checa si lo esta tocando
            for (int i = 0; i < ancho; i++)
            {
                for (int j = Scroll; j < bloquesEvalua + Scroll; j++)
                {
                    if (Mundo[i, j].tipo == '1' || Mundo[i, j].tipo == '2' || Mundo[i, j].tipo == '3')
                    {
                        if (x1 > Mundo[i, j].x &&
                            x1 - 2 < Mundo[i, j].x + 48 &&
                            y1t - 7 > Mundo[i, j].y &&
                            y1t - 7 < Mundo[i, j].y + 48)
                            return true;
                       }
                }
            }
            return false;
        }
        //verifica si toca a algun objeto adelante de el
        public bool TocaSig(int ancho, int Scroll, Bloque[,] Mundo)
        {
            for (int i = 0; i < ancho; i++)
            {
                for (int j = Scroll; j < bloquesEvalua + Scroll; j++)
                {
                    if (Mundo[i, j].tipo == '1' || Mundo[i, j].tipo == '2' || Mundo[i, j].tipo == '3')
                    {
                        if (x1t + 2 > Mundo[i, j].x && 
                            x1t < Mundo[i, j].x + 48 &&
                            y1t - 7 > Mundo[i, j].y &&
                            y1t - 7 < Mundo[i, j].y + 48)
                            return true;
                    }
                }
            }
            return false;
        }
        //verifica si toca a algun objeto arriv de el
        public bool TocaArriba(int ancho, int Scroll, Bloque[,] Mundo)
        {
            for (int i = 0; i < ancho; i++)
            {
                for (int j = Scroll; j < bloquesEvalua + Scroll; j++)
                {
                    if (Mundo[i, j].tipo == '1' || Mundo[i, j].tipo == '2' || Mundo[i, j].tipo == '3')
                    {
                        if (x1t > Mundo[i, j].x &&
                            x1t < Mundo[i, j].x + 48 &&
                            Y > Mundo[i, j].y &&
                            Y < Mundo[i, j].y + 48)
                            return true;
                        if (x1 > Mundo[i, j].x &&
                            x1 < Mundo[i, j].x + 48 &&
                            Y > Mundo[i, j].y &&
                            Y < Mundo[i, j].y + 48)
                            return true;
                    }

                }
            }
            return false;
        }
        //verifica si toca a algun objeto abajo de el
        public bool tocaAbajo(int ancho, int Scroll, Bloque[,] Mundo)
        {
            for (int i = 0; i < ancho; i++)
            {
                for (int j = Scroll; j < bloquesEvalua + Scroll; j++)
                {
                    if (Mundo[i, j].tipo == '1' || Mundo[i, j].tipo == '2' || Mundo[i, j].tipo == '3')
                    {                    
                       if (x1t > Mundo[i, j].x &&
                           x1t < Mundo[i, j].x + 48 &&
                        Y + 47 >= Mundo[i, j].y && 
                        Y + 47 <= Mundo[i, j].y + 48)
                               return true;
                       if (x1 > Mundo[i, j].x &&
                           x1 < Mundo[i, j].x + 48 &&
                        Y + 47 >= Mundo[i, j].y &&
                        Y + 47 <= Mundo[i, j].y + 48)
                           return true;
                    }
                        
                }
            }
            return false;
        }
       
    }
}
