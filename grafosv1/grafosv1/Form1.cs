﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.VisualBasic;


namespace grafosv1
{
    public partial class Form1 : Form
    {
        public int x, y, wid, he; //posiciones del nodo, altura y ancho
        Pen lapiz = new Pen(Color.Blue,3); //color del contorno del nodo
        Pen lapiz2 = new Pen(Color.BlueViolet,3); //color de la arista
        public List<Grafo> ListGrafo; //lista de grafos
        public bool BVertice; //bandera cuando se da click en el boton nodo
        public bool TipoArista; //bandera que se activa si se selecciono arista dirigida o no dirigida, checa el mouseup y mousedown
        public bool move, moveG; //bandera para ver si se activa el mover
        public int menu; //checa cual sección del menú se presiono
        public int xo, yo, xd, yd; //coordenadas del nodo origen y nodo destino
        public int temp1, destv; //se guarda la posición del nodo origen y nodo destino para poder hacer las aristas
        public int posG; //posición de la lista de grafos
        bool ponderado = false;
        public int x1, y1;

        public Point p1, c1, p2, c2;


        //variables para abrir y guardar el grafo
        SaveFileDialog save;
        OpenFileDialog open;
        bool forma = false;

        int dx, dy;

        public Form1()
        {
            InitializeComponent();
            x = y = 100;
            xo = yo = xd = yd = 0;
            wid = he = 40;
            menu = 0;
            move = moveG = TipoArista = false;
            posG = -1;
            ListGrafo = new List<Grafo>();

            vérticeToolStripMenuItem.Enabled = false;
            aristaToolStripMenuItem.Enabled = false;
            nuevoToolStripMenuItem1.Enabled = false;
        }

        //guardar el grafo
        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save = new SaveFileDialog();
            if (save.ShowDialog() == DialogResult.OK)
            {
                Stream st = File.Open(save.FileName, FileMode.Create);
                BinaryFormatter bin = new BinaryFormatter();
                
                //guardado = true;
                bin.Serialize(st, ListGrafo);
                ListGrafo.Clear();
                st.Close();
                
            }
        }

        //abrir un grafo
        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult b = MessageBox.Show("¿Desea guardar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (b == DialogResult.Yes)
            {
                guardarToolStripMenuItem_Click(sender, e);
                ListGrafo.Clear();
                open = new OpenFileDialog();
                if (open.ShowDialog() == DialogResult.OK)
                {
                    Stream st = File.Open(open.FileName, FileMode.Open);
                    BinaryFormatter bin = new BinaryFormatter();
                    ListGrafo = (List<Grafo>)bin.Deserialize(st);
                    posG = 0;
                    NumGrafo.Value = posG;
                    st.Close();
                }
            }
            else
            {
                open = new OpenFileDialog();
                ListGrafo.Clear();
                if (open.ShowDialog() == DialogResult.OK)
                {
                    Stream st = File.Open(open.FileName, FileMode.Open);
                    BinaryFormatter bin = new BinaryFormatter();
                    ListGrafo = (List<Grafo>)bin.Deserialize(st);
                    NumGrafo.Value = posG = 0;
                    st.Close();
                }
            }
            Invalidate();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        private void nuevoNodoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            menu = 1;
            BVertice = true;
            temp1 = 0;
        }

        private void quitarNodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menu = 2;
            TipoArista = false;
        }

        private void ponderadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ponderado = true;
            TipoArista = true;
            menu = 4;
            //deshabilita el botón de no dirigido y se dibuja la línea con flecha
            noDirigidoToolStripMenuItem1.Enabled = false;
            lapiz2.StartCap = LineCap.ArrowAnchor;
            lapiz2.EndCap = LineCap.NoAnchor;
        }

        private void noPonderadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ponderado = false;
            TipoArista = true;
            menu = 4;
            //deshabilita el botón de no dirigido y se dibuja la línea con flecha
            noDirigidoToolStripMenuItem1.Enabled = false;
            lapiz2.StartCap = LineCap.ArrowAnchor;
            lapiz2.EndCap = LineCap.NoAnchor;
        }

        private void gradoDeNodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menu = 7;
        }

        private void matrizAdyacenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menu = 8;
            ListGrafo[posG].MtzAd(ListGrafo[posG].ListaVer.Count);
        }

        private void moverNodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menu = 3;
            //move = true;
            //moveG = false;
        }

        private void dirigidoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            /*TipoArista = true;
            menu = 4;
            //deshabilita el botón de no dirigido y se dibuja la línea con flecha
            noDirigidoToolStripMenuItem1.Enabled = false;
            lapiz2.StartCap = LineCap.ArrowAnchor;
            lapiz2.EndCap = LineCap.NoAnchor;*/
        }

        private void noDirigidoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TipoArista = true;
            menu = 4;
            //deshabilita el botón de dirigido y se dibuja la línea
            dirigidoToolStripMenuItem1.Enabled = false;
            lapiz2.StartCap = LineCap.NoAnchor;
            lapiz2.EndCap = LineCap.NoAnchor;
        }

        private void NumGrafo_ValueChanged(object sender, EventArgs e)
        {
            posG = ((int)NumGrafo.Value);
        }

        private void moverGrafoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menu = 6;
        }

        //crea un nuevo grafo y lo agrega a la lista de grafos
        private void nuevoGrafoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aristaToolStripMenuItem.Enabled = true;
            dirigidoToolStripMenuItem1.Enabled = true;
            noDirigidoToolStripMenuItem1.Enabled = true;
            vérticeToolStripMenuItem.Enabled = true;
            nuevoToolStripMenuItem1.Enabled = true;
            Grafo g = new Grafo();
            ListGrafo.Add(g);
            label5.Text = "grafos en la lista: " + ListGrafo.Count.ToString();
            posG++;
            NumGrafo.Value = posG;
            label3.Text = "Posición del grafo en la lista: " + posG.ToString();
            menu = 0;
           forma = move = moveG = TipoArista = false;
        }

        private void eliminaAristaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menu = 5;
        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            vérticeToolStripMenuItem.Enabled = false;
            aristaToolStripMenuItem.Enabled = false;
            //habilita los botones de dirgido y no dirigido
            dirigidoToolStripMenuItem1.Enabled = true;
            noDirigidoToolStripMenuItem1.Enabled = true;
            DialogResult b = MessageBox.Show("¿Desea guardar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (b == DialogResult.Yes)
            {
                guardarToolStripMenuItem_Click(sender, e);
                ListGrafo.Clear();

                //posG += 1;
            }
            else
            {
                ListGrafo.Clear();
                posG = -1;
            }
            //ListGrafo = new List<Grafo>();

            temp1 = 0;
            Invalidate();
        }


        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            x = e.X - wid / 2;
            y = e.Y - he / 2;
            if (!TipoArista)
            {
                switch (menu)
                {
                    case 1: //inserta el nodo en la lista grafos
                        ListGrafo[posG].InsertaVertice((ListGrafo[posG].ListaVer.Count + 1).ToString(), x, y);
                        
                        break;
                    case 2: //elimina el nodo de la lista grafos
                        ListGrafo[posG].QuitaVertice(e.X, e.Y);
                        break;
                }
            }
            Invalidate();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (TipoArista)
            {
                xd = e.X;
                yd = e.Y;
            }
            
            //mueve un nodo del grafo
            if (move)
            {
                forma = false;
                moveG = false;
                label4.Text = "moviendo";
                int aux = ListGrafo[posG].Buscar(e.X, e.Y);
                if (aux >= 0)
                {
                    Grafo g = ListGrafo[posG];
                    CVertice n = ListGrafo[posG].ListaVer[aux];
                    n.x = e.X - wid / 2;
                    n.y = e.Y - he / 2;
                    label3.Text = "nodo a mover = " + (aux + 1).ToString();
                    for (int i = 0; i < g.ListaVer.Count; i++)
                    {
                       /* CVertice v = g.ListaVer[i];
                        for (int j = 0; j < v.ListAristas.Count; j++)*/
                            //v.ListAristas[j].CambiaCoord(xo,yo);
                             g.ListaVer[i].Cambia();
                            //n1.Cambiar();
                    }
                }
                //Invalidate();
            }
            else
                label4.Text = "No se mueve nada";
            Invalidate();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //xo = e.X;
            //yo = e.Y;
            //busca nodo origen y guarda las coordenadas del mousedown
            if (TipoArista)
            {
               forma = true;
               temp1 = ListGrafo[posG].Buscar(e.X, e.Y);
               xo = e.X;
               yo = e.Y;
               label1.Text = "origen = "+ (temp1+1).ToString();
            }

            //activa bandera para mover nodos y aristas
            if (menu == 3)
            {
                move = true;
                moveG = false;
                forma = false;
                
            }

            //desactiva la bandera de si se esta en la forma 
            if (menu == 5 || menu == 8)
                forma = false;

            //activa la bandera de mover grafo
            if (menu == 6)
            {
                moveG = true;
                forma = false;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if(move)
            {
                x1 = e.X - xo;
                y1 = e.Y - yo;
                move = false;
                Invalidate();
            }
            //si esta activa la bandera de mover grafo se asignan las nuevas coordenadas de los nodos y aristas 
            if (moveG)
            {
                Grafo g = ListGrafo[posG];
                int dx = e.X - xo;
                int dy= e.Y - yo;
                foreach (CVertice v in g.ListaVer)
                {
                    v.x +=dx;
                    v.y +=dy;
                    foreach (Arista a in v.ListAristas)
                    {
                        a.orix += dx;
                        a.oriy += dy;
                        a.destx += dx;
                        a.desty += dy;
                        a.puntos();
                    }
                }
                moveG = false;
                Invalidate();
            }

            //busca nodo destino, guarda las coorenadas del mouseup e inserta las aristas
            if (TipoArista && menu == 4)
            {
                move = false;
                forma = false;
                int temp = ListGrafo[posG].Buscar(e.X, e.Y);
                xd = e.X;
                yd = e.Y;
                label2.Text = "destino= " + (temp+1).ToString();
                destv = temp;
                if (temp >= 0)
                {
                    ListGrafo[posG].ListaVer[temp1].InsertaArista(xd, yd, xo, yo, ListGrafo[posG].ListaVer.ElementAt(temp), ponderado);
                }
                destv = 0;
                //xo = yo = xd = yd = -1;
            }
            if (menu == 5) //activa elimina arista
            {
                forma = false;
                for (int i = 0; i < ListGrafo[posG].ListaVer.Count; i++)
                    ListGrafo[posG].ListaVer[i].EliminaArista(e.X, e.Y);
            }
            if (menu == 7)
            {
                forma = false;
                int t = ListGrafo[posG].Buscar(e.X, e.Y);
                if (t >= 0)
                {
                    int grade = ListGrafo[posG].ListaVer[t].ListAristas.Count;
                    label3.Text = "Las aristas del vértice " + (t+1) + " son: " + grade;
                   // MessageBox.Show("El grado del vértice es: " + grade.ToString(), "Grado de vértice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            Invalidate();
        }
     
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            PointF[] puntos;
            List<PointF> point = new List<PointF>();
            dx = xd - xo;
            dy = yd - yo;
            if (forma)
                e.Graphics.DrawLine(lapiz2, xd, yd, xo, yo);

            for (int i = 0; i < ListGrafo.Count; i++)
            {
                if (moveG) //si se mueve el grafo
                {
                    if (i == posG)
                    {
                        for (int j = 0; j < ListGrafo[i].ListaVer.Count; j++)
                        {
                            //dibuja el circulo y la etiqueta del nodo
                            CVertice ver = ListGrafo[i].ListaVer[j];
                            e.Graphics.DrawEllipse(lapiz, ver.x - (wid / 10) + dx, ver.y - (he / 10) + dy, wid, he);
                            e.Graphics.DrawString(ver.name, new Font("Times New Roman", 12),
                            new SolidBrush(Color.Blue), ver.x + wid / 3 + dx, ver.y + he / 4 + dy);
                            //dibuja las líneas 
                            for (int k = 0; k < ver.ListAristas.Count; k++)
                            {
                                Arista arista = ver.ListAristas[k];
                                for (float t = 0; t <= 1; t += 0.01f)
                                {
                                    float m = (1 - t);
                                    float xb = (int)((arista.p2.X * Math.Pow(m, 3)) + (3 * arista.c2.X * Math.Pow(m, 2) * t) + (2 * arista.c1.X * Math.Pow(t, 2) * m) + arista.p1.X * Math.Pow(t, 3));
                                    float yb = (int)((arista.p2.Y * Math.Pow(m, 3)) + (3 * arista.c2.Y * Math.Pow(m, 2) * t) + (2 * arista.c1.Y * Math.Pow(t, 2) * m) + arista.p1.Y * Math.Pow(t, 3));
                                    PointF p = new PointF(xb, yb);
                                    point.Add(p);
                                    //e.Graphics.DrawEllipse(lapiz, xb, yb, 2, 2);
                                }
                                puntos = point.ToArray();
                                e.Graphics.DrawCurve(lapiz2, puntos);
                                point.Clear();
                                arista.puntos();

                            }
                        }
                    }
                    else
                    {
                        for (int j = 0; j < ListGrafo[i].ListaVer.Count; j++)
                        {
                            //dibuja el circulo y la etiqueta del nodo
                            BVertice = false;
                            Rectangle r = new Rectangle(ListGrafo[i].ListaVer[j].x, ListGrafo[i].ListaVer[j].y, wid, he);
                            //e.Graphics.DrawRectangle(lapiz,r);
                            CVertice ver = ListGrafo[i].ListaVer[j];
                            e.Graphics.DrawEllipse(lapiz, ver.x, ver.y, wid, he);
                            e.Graphics.DrawString(ver.name, new Font("Times New Roman", 12),
                              new SolidBrush(Color.Blue), ver.x + wid / 3, ver.y + he / 4);
                            //dibuja las líneas 
                            for (int k = 0; k < ver.ListAristas.Count; k++)
                            {
                                Arista arista = ver.ListAristas[k];
                                for (float t = 0; t <= 1; t += 0.01f)
                                {
                                    float m = (1 - t);
                                    float xb = (int)((arista.p2.X * Math.Pow(m, 3)) + (3 * arista.c2.X * Math.Pow(m, 2) * t) + (2 * arista.c1.X * Math.Pow(t, 2) * m) + arista.p1.X * Math.Pow(t, 3));
                                    float yb = (int)((arista.p2.Y * Math.Pow(m, 3)) + (3 * arista.c2.Y * Math.Pow(m, 2) * t) + (2 * arista.c1.Y * Math.Pow(t, 2) * m) + arista.p1.Y * Math.Pow(t, 3));
                                    PointF p = new PointF(xb, yb);
                                    point.Add(p);
                                    //e.Graphics.DrawEllipse(lapiz, xb, yb, 2, 2);
                                }
                                puntos = point.ToArray();
                                e.Graphics.DrawCurve(lapiz2, puntos);
                                point.Clear();
                            }
                        }
                    }
                }
                else
                {
                    //for (int i = 0; i < ListGrafo.Count; i++)
                    for (int j = 0; j < ListGrafo[i].ListaVer.Count; j++)
                    {
                        //dibuja el circulo y la etiqueta del nodo
                        BVertice = false;
                        Rectangle r = new Rectangle(ListGrafo[i].ListaVer[j].x, ListGrafo[i].ListaVer[j].y, wid, he);
                        //e.Graphics.DrawRectangle(lapiz,r);
                        CVertice ver = ListGrafo[i].ListaVer[j];
                        e.Graphics.DrawEllipse(lapiz, ver.x, ver.y, wid, he);
                        e.Graphics.DrawString(ver.name, new Font("Times New Roman", 12),
                          new SolidBrush(Color.Blue), ver.x + wid / 3, ver.y + he / 4);
                       
                        //dibuja las líneas 
                        for (int k = 0; k < ver.ListAristas.Count; k++)
                        {
                            Arista arista = ver.ListAristas[k];
                            for (float t = 0; t <= 1; t += 0.01f)
                            {
                                float m = (1 - t);
                                float xb = (int)((arista.p2.X * Math.Pow(m, 3)) + (3 * arista.c2.X * Math.Pow(m, 2) * t) + (2 * arista.c1.X * Math.Pow(t, 2) * m) + arista.p1.X * Math.Pow(t, 3));
                                float yb = (int)((arista.p2.Y * Math.Pow(m, 3)) + (3 * arista.c2.Y * Math.Pow(m, 2) * t) + (2 * arista.c1.Y * Math.Pow(t, 2) * m) + arista.p1.Y * Math.Pow(t, 3));
                                PointF p = new PointF(xb, yb);
                                point.Add(p);
                                
                                //e.Graphics.DrawEllipse(lapiz, xb, yb, 2, 2);
                            }
                            puntos = point.ToArray();
                            e.Graphics.DrawCurve(lapiz2, puntos);
                            if(ponderado == true)
                                e.Graphics.DrawString(arista.peso.ToString(), new Font("Times New Roman", 10),
                                    new SolidBrush(Color.Black), arista.destx, arista.desty);
                            label1.Text = arista.peso.ToString();
                            point.Clear();
                        }
                    }
                }
            }
        }
    }
}
