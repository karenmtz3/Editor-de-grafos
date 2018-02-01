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
        public bool bandera2; //checa el mouseup y mousedown
        public bool move; //bandera para ver si se activa el mover
        public int banderita; //checa cual sección del menú se presiono
        public int x1, y1, x2, y2; //coordenadas del nodo origen y nodo destino
        public int temp1; //se guarda la posición del nodo origen para poder hacer las aristas

        public Form1()
        {
            InitializeComponent();
            x = y = 100;
            x1 = y1 = x2 = y2 = 0;
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
            move = false;
            bandera2 = true;
            //deshabilita el botón de dirigido y se ddibuja la línea
            dirigidoToolStripMenuItem.Enabled = false;
            lapiz2.StartCap = LineCap.NoAnchor;
            lapiz2.EndCap = LineCap.NoAnchor;
        }
        
        private void dirigidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            move = false;
            bandera2 = true;
            //deshabilita el botón de no dirigido y se dibuja la línea con flecha
            noDirigidoToolStripMenuItem.Enabled = false;
            lapiz2.StartCap = LineCap.ArrowAnchor;
            lapiz2.EndCap = LineCap.NoAnchor;
        }

        private void moverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            banderita = 4;
        }

        private void QuitarAToolStripMenu_Click(object sender, EventArgs e)
        {
            
            banderita = 3;
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
                        move = false;
                        ListGrafo[0].InsertaVertice((ListGrafo[0].ListaVer.Count + 1).ToString(), x, y);
                        break;
                    case 2: //elimina el nodo de la lista grafos
                        move = false;
                        ListGrafo[0].QuitaVertice(e.X, e.Y);
                        break;
                    case 3:
                        break;
                    case 4: //activa bandera de mover
                        move = true;
                        break;
                }
            }
            Invalidate();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (move)
            {
                int aux = ListGrafo[0].Buscar(e.X,e.Y);
                {
                    if (aux >= 0)
                    {
                        label3.Text = "nodo a mover = " + aux.ToString();
                        ListGrafo[0].ListaVer[aux].x = e.X-wid/2;
                        ListGrafo[0].ListaVer[aux].y = e.Y-he/2;
                        Invalidate();
                    }
                }
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

            move = true;
            //busca nodo origen y guarda las coordenadas del mousedown
            if (bandera2)
            {
               move = false;
               temp1 = ListGrafo[0].Buscar(e.X, e.Y);
               x1 = e.X;
               y1 = e.Y;
               label1.Text = "origen = "+ temp1.ToString();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

            move = false;
            //busco nodo destino, guarda las coorenadas del mouseup e inserta las aristas
            if (bandera2)
            {
                move = false;
                int temp = ListGrafo[0].Buscar(e.X, e.Y);
                x2 = e.X;
                y2 = e.Y;
                label4.Text = "destino= " + temp.ToString();
                if(temp >= 0)
                    ListGrafo[0].ListaVer[temp1].InsertaArista(x2,y2,x1,y1,ListGrafo[0].ListaVer.ElementAt(temp));
                x1 = y1 = x2 = y2 = -1;
            }
        }
     
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
            for (int i = 0; i < ListGrafo.Count; i++)
                for (int j = 0; j < ListGrafo[i].ListaVer.Count; j++)
                {
                    //dibuja el circulo y la etiqueta del nodo
                    bandera = false;
                    e.Graphics.DrawEllipse(lapiz, ListGrafo[i].ListaVer[j].x, ListGrafo[i].ListaVer[j].y, wid, he);
                    e.Graphics.DrawString(ListGrafo[i].ListaVer[j].name, new Font("Times New Roman", 12),
                        new SolidBrush(Color.Blue), ListGrafo[i].ListaVer[j].x + wid / 3, ListGrafo[i].ListaVer[j].y + he / 4);
                    //dibuja las líneas 
                    for (int k = 0; k < ListGrafo[i].ListaVer[j].ListAristas.Count; k++)
                    {
                        e.Graphics.DrawLine(lapiz2, ListGrafo[i].ListaVer[j].ListAristas[k].orix,
                       ListGrafo[i].ListaVer[j].ListAristas[k].oriy, ListGrafo[i].ListaVer[j].ListAristas[k].destx,
                       ListGrafo[i].ListaVer[j].ListAristas[k].desty);
                    }
                }
        }
    }
}
