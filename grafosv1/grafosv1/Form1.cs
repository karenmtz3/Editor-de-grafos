using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace grafosv1
{
    public partial class Form1 : Form
    {
        public int x, y, wid, he; //posiciones del nodo, altura y ancho
        Pen lapiz = new Pen(Color.Blue,3); //color del contorno del nodo
        Pen lapiz2 = new Pen(Color.BlueViolet,3); //color de la arista
        public List<Grafo> ListGrafo; //lista de grafos
        public bool bandera; //bandera cuando se da click en el boton nodo
        public bool bandera2; //bandera que se activa si se selecciono arista dirigida o no dirigida, checa el mouseup y mousedown
        public bool move; //bandera para ver si se activa el mover
        public int banderita; //checa cual sección del menú se presiono
        public int xo, yo, xd, yd; //coordenadas del nodo origen y nodo destino
        public int temp1; //se guarda la posición del nodo origen para poder hacer las aristas

        public Form1()
        {
            InitializeComponent();
            x = y = 100;
            xo = yo = xd = yd = 0;
            wid = he = 40;
            banderita = 0;
            move = bandera2 = false;
            ListGrafo = new List<Grafo>();
            
            ListGrafo.Add(new Grafo());
        }

        private void AristasToolStripMenu_Click(object sender, EventArgs e)
        {

        }

        private void NodoToolStripMenu_Click(object sender, EventArgs e)
        {
            banderita = 1;
            bandera = true;
        }

        private void QuitaNToolStripMenu_Click(object sender, EventArgs e)
        {
            banderita = 2;
            bandera2 = false;
            //habilita los botones de dirgido y no dirigido
            dirigidoToolStripMenuItem.Enabled = true; 
            noDirigidoToolStripMenuItem.Enabled = true;
        }

        private void noDirigidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bandera2 = true;
            banderita = 4;
            //deshabilita el botón de dirigido y se dibuja la línea
            dirigidoToolStripMenuItem.Enabled = false;
            lapiz2.StartCap = LineCap.NoAnchor;
            lapiz2.EndCap = LineCap.NoAnchor;
        }
        
        private void dirigidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bandera2 = true;
            banderita = 4;
            //deshabilita el botón de no dirigido y se dibuja la línea con flecha
            noDirigidoToolStripMenuItem.Enabled = false;
            lapiz2.StartCap = LineCap.ArrowAnchor;
            lapiz2.EndCap = LineCap.NoAnchor;
        }

        private void moverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            banderita = 3;
        }

        private void QuitarAToolStripMenu_Click(object sender, EventArgs e)
        {

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            x = e.X - wid / 2;
            y = e.Y - he / 2;
            if (!bandera2)
            {
                switch (banderita)
                {
                    case 1: //inserta el nodo en la lista grafos
                        ListGrafo[0].InsertaVertice((ListGrafo[0].ListaVer.Count + 1).ToString(), x, y);
                        break;
                    case 2: //elimina el nodo de la lista grafos
                        ListGrafo[0].QuitaVertice(e.X, e.Y);
                        break;
                    /*case 3:
                        break;*/
                }
            }
            Invalidate();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                label4.Text = "moviendo";
                int aux = ListGrafo[0].Buscar(e.X,e.Y);
                if (aux >= 0)
                {
                    CVertice n = ListGrafo[0].ListaVer[aux];
                    label3.Text = "nodo a mover = " + (aux+1).ToString();
                    n.x = e.X-wid/2;
                    n.y = e.Y-he/2;
                    for (int i = 0; i < n.ListAristas.Count; i++)
                    {
                        Arista a = n.ListAristas[i];
                        //a.CambiaCoordDes(e.X - wid / 4, e.Y - he / 4);
                        a.CambiaCoord(e.X - wid / 4, e.Y - he / 4);
                        /*if ((n.x < a.destx && n.x + 40 > a.destx) && (n.y < a.desty && n.y + 40 > a.desty))
                        {
                                //label5.Text = "Se encontró el origen";
                                //label3.Text = "x= "+a.orix+" y= " + a.oriy;
                                //mueve el origen de la arista x,y
                                a.CambiaCoord(e.X, e.Y);
                            //if ((n.x < a.orix && n.x + 40 > a.orix) && (n.y < a.oriy && n.y + 40 > a.oriy))
                                //label5.Text = "Se encontró el destino";
                        }*/

                            /* if ((n.x < a.orix && n.x + 40 > a.orix) && (n.y < a.oriy && n.y + 40 > a.oriy))
                            {
                                label5.Text = "Se encontró el destino";
                                a.CambiaCoordDes(e.X, e.Y);
                            }
                                if ((n.x < a.orix && n.x + 40 > a.orix) && (n.y < a.oriy && n.y + 40 > a.oriy))
                                    a.CambiaCoordDes(e.X, e.Y);
                            }
                                //mueve el origen de la arista x,y
                                //a.CambiaCoord(e.X, e.Y);
                            //else if((n.x < a.orix && n.x + 40 > a.orix) && (n.y < a.oriy && n.y + 40 > a.oriy))
                                //a.CambiaCoordDes(e.X, e.Y);*/
                    }
                        // ListGrafo[0].ListaVer[aux].ListAristas[i].CambiaCoord(e.X,e.Y);
                        Invalidate();
                }
            }
            else
                label4.Text = "No se mueve nada";
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //busca nodo origen y guarda las coordenadas del mousedown
            if (bandera2)
            {
               temp1 = ListGrafo[0].Buscar(e.X, e.Y);
               xo = e.X;
               yo = e.Y;
               label1.Text = "origen = "+ (temp1+1).ToString();
            }
            if(banderita == 3)
                move = true;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

            move = false;
            //busca nodo destino, guarda las coorenadas del mouseup e inserta las aristas
            if (bandera2 && banderita == 4)
            {
                move = false;
                int temp = ListGrafo[0].Buscar(e.X, e.Y);
                xd = e.X;
                yd = e.Y;
                label2.Text = "destino= " + (temp+1).ToString();
                if (temp >= 0)
                    ListGrafo[0].ListaVer[temp1].InsertaArista(xd, yd, xo, yo,ListGrafo[0].ListaVer.ElementAt(temp));
                xo = yo = xd = yd = -1;
            }
        }
     
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            for (int i = 0; i < ListGrafo.Count; i++)
                for (int j = 0; j < ListGrafo[i].ListaVer.Count; j++)
                {
                    //dibuja el circulo y la etiqueta del nodo
                    bandera = false;
                    Rectangle r = new Rectangle(ListGrafo[i].ListaVer[j].x, ListGrafo[i].ListaVer[j].y, wid, he);
                    e.Graphics.DrawRectangle(lapiz,r);
                    CVertice ver = ListGrafo[i].ListaVer[j];
                    e.Graphics.DrawEllipse(lapiz, ver.x, ver.y, wid, he);
                    e.Graphics.DrawString(ver.name, new Font("Times New Roman", 12),
                      new SolidBrush(Color.Blue), ver.x + wid / 3, ver.y + he / 4);
                    //dibuja las líneas 
                    for (int k = 0; k < ver.ListAristas.Count; k++)
                    {
                        Arista arista = ver.ListAristas[k];
                        e.Graphics.DrawLine(lapiz2, arista.destx, arista.desty,arista.orix, arista.oriy);
                    }
                }
        }
    }
}
