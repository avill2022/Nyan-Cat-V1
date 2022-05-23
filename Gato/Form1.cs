using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Gato
{
    public partial class Form1 : Form
    {
        Bloque[,] Mundo;
        bool gana;
        int ancho = 10;//Largo del mapa
        int largo;//Ancho del mapa
        int eScroll;
        int teclaIzDer;//se usa para ver que tecla se preciono si la drecha o la izquierda
        int auxsD;//variable para el scrolll
        int auxsI;
        int tamBloque = 48;//Tamaño del bloque 
        int nivel;
        Image Fondo;//Imagen de fondo
        int vidas;
        private bool juega;//bandera para iniciar a jugar
        List<Perro> listaPerros;//lista de perros que estan en el mapa
        List<Raton> listaRaton;//lista de perros que estan en el mapa
        List<Bota> listaBotas;//lista de perros que estan en el mapa
        List<Rerods> listaRecords;
        Gato cat;//jugador
        Bandera band;//meta(objeto meta)
        Graphics g;//graficos del juego
        Bitmap bmp;//para la paginacion
        Graphics pagina;//auxiliar para dibujar
        int puntos;
        string nombre;
        float acceleration = 0.5F;
        Random r;

        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
            r = new Random();
            bmp = new Bitmap(ClientSize.Width, ClientSize.Height);
            gana = false;
            pagina = Graphics.FromImage(bmp);
            Fondo = Image.FromFile("Fondo.jpg");
            listaPerros = new List<Perro>();
            listaRaton = new List<Raton>();
            listaBotas = new List<Bota>();
            listaRecords = new List<Rerods>();
            puntos = 0;
            nivel = 1;
            juega = false;
            abreNivel(nivel);
            timer1.Tick += new EventHandler(timer1_Tick);//manejador del taimer
        }
        void timer1_Tick(object sender, EventArgs e)
        {
            mueveJugador();
            this.Text = "Nivel: " + nivel.ToString();
            band.ondeaBandera();
            if (gana == false)
                Vida.Text = "Vidas: " + vidas.ToString();
            else
            {
                timer1.Stop();
            }

            if (vidas == 0)
            {
                timer1.Stop();
                g.Clear(this.BackColor);
                toolStrip1.Visible = true;
                button1.Visible = true;
                button1.Enabled = true;
                button2.Visible = true;
                button2.Enabled = true;
                button3.Visible = true;
                button3.Enabled = true;
                Vida.Visible = false;
                Puntos.Visible = false;
                Records.Visible = true;
                Records.Enabled = true;
                
            }
            if (band.tocaAjugador(cat) == true)
            {
                nivel+=1;
                this.reiniciaJuego();
            }
            cat.rec = new Rectangle((int)cat.X,(int)cat.Y,tamBloque,tamBloque);
            this.Form1_Paint(this,null);
        }
        private void AgregaRecord(Rerods rec)
        {
            int i = 0;
            foreach (Rerods r in listaRecords)
            {
                if (r.Puntos < rec.Puntos)
                {
                    listaRecords.Insert(i, rec);
                    break;
                }
                i++;
            }
            IFormatter formater = new BinaryFormatter();
            Stream stream = new FileStream("Records.dat", FileMode.Create, FileAccess.Write, FileShare.None);
            formater.Serialize(stream, listaRecords);
            stream.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 10;//intervalo del taimer
            timer1.Enabled = true;//activo
            timer1.Stop();//detener el taimer
            pintaMapa(pagina);
            mueveJugador();
            IFormatter formater1 = new BinaryFormatter();
            Stream stream = new FileStream("Records.dat", FileMode.Open, FileAccess.Read, FileShare.None);
            listaRecords = (List<Rerods>)formater1.Deserialize(stream);
            stream.Close();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (juega == true)
            {
                pagina.Clear(this.BackColor);//borra todo
                pintaMapa(pagina);//pinta el mapa
                muevePerros(pagina);//pinta los perros
                mueveRatones(pagina);
                mueveBotas(pagina);
                pagina.DrawImage(band.Imagenes[band.imagen], new Point(band.x, band.y)); //pinta la bandera
                if(cat.direccion ==0)
                    pagina.DrawImage(cat.Imagenes1[cat.imagen1], new Point((int)cat.X, (int)cat.Y));//dibuja la imagen actual del gato
                if (cat.direccion == 1)
                    pagina.DrawImage(cat.Imagenes2[cat.imagen1], new Point((int)cat.X, (int)cat.Y));//dibuja la imagen actual del gato
                
            }g.DrawImage(bmp, 0, 0);//pinta todo 
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 39)//guarda las teclas
            {
                teclaIzDer = 39;
                    cat.direccion =0;
            }
            if (e.KeyValue == 37)
            {
                teclaIzDer = 37;
                    cat.direccion =1;
            }
            if (e.KeyValue == 38 && cat.brincando == false && !cat.TocaArriba(ancho, eScroll, Mundo))
            {
                brinca();
            }
        }
        private void brinca()
        {
            cat.tocaSuelo -= cat.distancia;
            cae();
        }

        private void cae()
        {
            cat.Y += cat.tocaSuelo;
            cat.tocaSuelo = cat.tocaSuelo + acceleration;
            cat.brincando = true;
            tocaSuelo(); 
        }

        private bool tocaSuelo()
        {
            if (cat.tocaAbajo(ancho, eScroll, Mundo) == false)
                return false;
            cat.tocaSuelo = 0;
            return true;

        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 39 || e.KeyValue == 37)//reinicia las teclas
                teclaIzDer = '\0';
        }

        private void mueveJugador()
        {
            cat.modificaCordenadas();
            if (cat.TocaPuntos(ancho, eScroll, Mundo))
            {
                puntos += 1;
                Puntos.Text = "Puntos: " + puntos.ToString();
            }
            if (teclaIzDer == 39)
            if (!cat.TocaSig(ancho, eScroll, Mundo))
                if (cat.X < 700 || eScroll + 20 == largo)//si el jugador esta posicionado en x menor a 224 o el scrol + el ancho de la pantalla es igual al largo
                {
                    cat.X += 2;
                    cat.animacion();
                }
                else
                {
                    scroll();
                    cat.animacion();
                }

            if (teclaIzDer == 37)
            if (!cat.TocaAnt(ancho, eScroll, Mundo))
                if (cat.X > 276 || eScroll == 0)
                {
                    if (cat.X > 0)
                    {
                        cat.X -= 2;
                        cat.animacion();
                    }
                }
                else
                {
                    scroll2();
                    cat.animacion();
                }

            if (cat.Y >= this.Height)
            {
                this.reiniciaJuego();
                vidas -= 1;
            }
            if (cat.TocaArriba(ancho, eScroll, Mundo) && cat.brincando == true)
            {
                cat.tocaSuelo = 1;
                cae();
                cat.brincando = false;
            }

            if (!tocaSuelo())
            {
                cae();
            }
            else
            {
                cat.brincando = false;
            }  
        }
        
        //mueve la lista de perros
        private void muevePerros(Graphics pagina)
        {
            foreach (Perro p in listaPerros)
            {
                p.actua(cat);//le pregunta si el gato esta cerca de el perro para que se empiese a mover
                pagina.DrawImage(p.Imagenes[p.imagen], new Point(p.X, p.Y));//pinto la imagen del perro
                if (p.intersectaJugador(cat) == true)//si lo toca reinicia el juego
                {
                    vidas -= 1;
                    if(vidas == 0)
                        AgregaRecord(new Rerods(puntos, nombre));
                    this.reiniciaJuego();
                    cat.Puntos = 0;
                    Puntos.Text = "Puntos: "+cat.Puntos.ToString();
                    
                    return;
                }
            }
        }
        //Mueve Botas
        private void mueveBotas(Graphics pagina)
        {
            foreach (Bota b in listaBotas)
            {
                b.mueveBota();
                pagina.DrawImage(b.Imagenes,new Point(b.x,b.y));
                if (b.intersectaJugador(cat) == true)//si lo toca reinicia el juego
                {
                    vidas -= 1;
                    if (vidas == 0)
                        AgregaRecord(new Rerods(puntos, nombre));
                    this.reiniciaJuego();
                    cat.Puntos = 0;
                    Puntos.Text = "Puntos: " + cat.Puntos.ToString();

                    return;
                }
            }
        }
        //mueve la lista de ratones
        private void mueveRatones(Graphics pagina)
        {
            foreach (Raton r in listaRaton)
            {
                r.mueveRaton(ancho, largo, Mundo);
                if(r.direccion == 0)
                    pagina.DrawImage(r.Imagenes1[r.imagen1], new Point(r.X, r.Y));//pinto la imagen del ratones
                else
                    pagina.DrawImage(r.Imagenes2[r.imagen1], new Point(r.X, r.Y));//pinto la imagen del ratones
                if (r.intersectaJugador(cat) == true)//si lo toca reinicia el juego
                {
                    vidas -= 1;
                    if (vidas == 0)
                        AgregaRecord(new Rerods(puntos, nombre));
                    this.reiniciaJuego();
                    cat.Puntos = 0;
                    Puntos.Text = "Puntos: " + cat.Puntos.ToString();
                    
                    return;
                }
            }
        }
        private void pintaMapa(Graphics pagina)
        {
            pagina.DrawImage(Fondo, new Point(0, 0));//pinta la imagen de fondo
            //recorre toda el mapa y pinta los obstaculos 
            for (int i = 0; i < ancho; i++)
            {
                for (int j = 0; j < largo; j++)
                {
                   // pagina.DrawLine(new Pen(Color.Red), cat.x1, cat.y1, cat.x1t, cat.y1);
                  //  pagina.DrawLine(new Pen(Color.Red), cat.x1, cat.y1, cat.x1, cat.y1t);
                   // pagina.DrawLine(new Pen(Color.Red), cat.x1, cat.y1t, cat.x1t, cat.y1t);
                  //  pagina.DrawLine(new Pen(Color.Red), cat.x1t, cat.y1, cat.x1t, cat.y1t);
                  //  pagina.DrawRectangle(new Pen(Color.Red), Mundo[i, j].x, Mundo[i, j].y, 48, 48);
                   // pagina.DrawRectangle(new Pen(Color.Red),/*new Rectangle((int)cat.X,(int)cat.Y+15,45,30)*/cat.x1,cat.y1,cat.x1t,cat.y1t);
                    if (Mundo[i, j].tipo == '1' || Mundo[i, j].tipo == '2' || Mundo[i, j].tipo == '3' || Mundo[i, j].tipo == '4' || Mundo[i, j].tipo == '5' || Mundo[i, j].tipo == '6' || Mundo[i, j].tipo == '7')
                        pagina.DrawImage(Mundo[i, j].Imagen, new Point(Mundo[i, j].x, Mundo[i, j].y));
                }
            }
        
        }
        private void reiniciaJuego()
        {
            listaPerros.Clear();//limpia la lista
            listaRaton.Clear();
            Puntos.Text = "Puntos: " + puntos.ToString();
            abreNivel(nivel);//abre el nivel seleccionado desde archivo
            
        }
        //funcion para abrir en nivel
        private void abreNivel(int nivel)
        {
            try//atrapa el error si no existe el archivo con el indice seleccionado
            {
                StreamReader file = new StreamReader("Niveles\\Nivel" + nivel.ToString() + ".txt");//abre el archivo

                char id = '\0';
                string linea = "";
                if (file != null)
                {
                    largo = Convert.ToInt32(file.ReadLine());//le la linea que es el largo del mapa
                    Mundo = new Bloque[ancho, largo];//crea el munodo con ese largo
                    int iAuxL = 0;
                    int iAuxA = 0;

                    for (int i = 0; i < ancho; i++)
                    {
                        linea = file.ReadLine();//lee la linea que contiene todos los bloques
                        //recorre la linea caracter por caracter
                        for (int l = 0; l < largo; l++)
                        {
                            id = linea[l];//guarda el caracter
                            if (id == 'B')
                            {
                                band = new Bandera(0 + iAuxL, 0 + iAuxA);//si es una bandera la crea con las coordenadas dadas
                                Mundo[i, l] = new Bloque(0 + iAuxL, 0 + iAuxA, 0);
                            }
                            else
                                if (id == 'J')
                                {
                                    cat = new Gato(0 + iAuxL, 0 + iAuxA);//si es el jugador lo crea con las coordenadas dadas
                                    Mundo[i, l] = new Bloque(0 + iAuxL, 0 + iAuxA, 0);
                                }
                                else
                                    if (id == 'P')
                                    {
                                        Perro nuevo = new Perro(0 + iAuxL, 0 + iAuxA);//si es un perro lo crea con las coordenadas dadas
                                        Mundo[i, l] = new Bloque(0 + iAuxL, 0 + iAuxA, 0);
                                        listaPerros.Add(nuevo);
                                    }
                                    else
                                        if (id == 'R')
                                        {
                                            Raton nuevo = new Raton(0 + iAuxL, 0 + iAuxA);//si es un perro lo crea con las coordenadas dadas
                                            Mundo[i, l] = new Bloque(0 + iAuxL, 0 + iAuxA, 0);
                                            listaRaton.Add(nuevo);
                                        }
                                        else
                                            if (id == 'Z')
                                            {
                                                Bota nuevo = new Bota(0 + iAuxL, 0 + iAuxA,20*r.Next(10,20));//si es un perro lo crea con las coordenadas dadas
                                                Mundo[i, l] = new Bloque(0 + iAuxL, 0 + iAuxA, 0);
                                                listaBotas.Add(nuevo);
                                            }
                                            else
                                        if (id == '1' || id == '2' || id == '3' || id == '4' || id == '5' || id == '6' || id == '7')//los demas son bloques
                                            Mundo[i, l] = new Bloque(0 + iAuxL, 0 + iAuxA, Image.FromFile("Bloques\\Bloque" + id + ".png"), Convert.ToInt32(id));
                                        else
                                            Mundo[i, l] = new Bloque(0 + iAuxL, 0 + iAuxA, Convert.ToInt32(id));//solo agrega bloques sin imagen
                            iAuxL += tamBloque;
                        }
                        iAuxL = 0;
                        iAuxA += tamBloque;
                    }
                    eScroll = 0;
                    file.Close();
                }
                else
                {
                    MessageBox.Show("No hay mas niveles");

                }
            }
            catch (FileNotFoundException)//si no existen niveles termina el juego
            {
                Vida.Text = "Juego Terminado";
                gana = true;
            }
        }
        private void scroll2()
        {
            auxsI++;
            if (auxsI > 23)
            {
                auxsI = 0;
                eScroll--;
            }
            for (int i = 0; i < ancho; i++)
            {
                for (int j = 0; j < largo; j++)
                {
                    Mundo[i, j].x += 2;
                    Mundo[i, j].rec = new Rectangle(Mundo[i, j].x, Mundo[i, j].y, tamBloque, tamBloque);

                }
            }
            foreach (Perro p in listaPerros)// rrecorre la lista de perros y les aumenta su coordenada en x
            {
                p.x += 2;
                p.rec = new Rectangle(p.x + 10, p.y + 10, 25, 25);
            }
            foreach (Raton r in listaRaton)
            {
                r.x += 2;
                r.rec = new Rectangle(r.x + 10, r.y + 10, 25, 25);
            }
            foreach (Bota b in listaBotas)
            {
                b.x += 2;
                b.rec = new Rectangle(b.x+10, b.y+10, 25, 25);
            }
            band.x += 2;
            band.rec = new Rectangle(band.x, band.y, tamBloque, tamBloque);//mueve la bandera
        }

        private void scroll()
        {
            auxsD++;//determina el imcremento del scroll
            if (auxsD > 23)//si es mallor a 15 lo reinicia, es para el movimiento de el jugador
            {
                auxsD = 0;
                eScroll++;
            }
            //recorre el mapa aumentando a la coordenada x a todos los bloques
            for (int i = 0; i < ancho; i++)
            {
                for (int j = 0; j < largo; j++)
                {
                    Mundo[i, j].x -= 2;
                    Mundo[i, j].rec = new Rectangle(Mundo[i, j].x, Mundo[i, j].y,tamBloque,tamBloque);
                    
                }
            }
            foreach (Perro p in listaPerros)// rrecorre la lista de perros y les aumenta su coordenada en x
            {
                p.x -= 2;
                p.rec = new Rectangle(p.x+5,p.y+5,20,20);
            }
            foreach (Raton r in listaRaton)
            {
                r.x -= 2;
                r.rec = new Rectangle(r.x +5, r.y +5, 20, 20);
            }
             band.x -= 2;
             band.rec = new Rectangle(band.x, band.y, tamBloque, tamBloque);//mueve la bandera
        }
        //manejador del  boton jugar
        private void Jugar_Click(object sender, EventArgs e)
        {
            IngresaNombre.Visible = true;
            Iniciar.Visible = true;
        }
        //manejador del boton la ayuda
        private void Ayuda_Click(object sender, EventArgs e)
        {
            Form2 forma = new Form2(0);// se crea otra forma, se le manda el tipo de forma
            forma.Show();
        }
        //manejador del boton creditos
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form2 forma = new Form2(1);
            forma.Show();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Iniciar_Click(object sender, EventArgs e)
        {
            nivel = 1;
            vidas = 3;
            nombre = IngresaNombre.Text;
            Iniciar.Visible = false;
            IngresaNombre.Visible = false;
            Puntos.Visible = true;
            button1.Visible = false;
            button1.Enabled = false;
            button2.Visible = false;
            button2.Enabled = false;
            button3.Visible = false;
            button3.Enabled = false;
            Records.Visible = false;
            Records.Enabled = false;
            reiniciaJuego();
            toolStrip1.Visible = false;
            Vida.Text = "vidas: 3";
            Vida.Visible = true;
            juega = true;
            timer1.Interval = 10;
            timer1.Enabled = true;
            timer1.Start();
        }

        private void Records_Click(object sender, EventArgs e)
        {
            RecordsForm r = new RecordsForm();
            int i = 0;
            foreach (Rerods rr in listaRecords)
            { 
                r.listaRecords(rr.Nombre,rr.Puntos,i);
                i++;
            }
            r.Show();
        }


    }
}
