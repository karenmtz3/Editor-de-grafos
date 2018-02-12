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
        public int temp1, destv; //se guarda la posición del nodo origen y nodo destino para poder hacer las aristas
        public int posG; //posición de la lista de grafos

        //variables para abrir y guardar el grafo
        SaveFileDialog save;
        OpenFileDialog open;
        bool forma = false;

        public Form1()
        {
            InitializeComponent();
            x = y = 100;
            xo = yo = xd = yd = 0;
            wid = he = 40;
            posG = banderita = 0;
            move = bandera2 = false;
            temp1 = 0;
            ListGrafo = new List<Grafo>();
            
            ListGrafo.Add(new Grafo());
        }

        private void AristasToolStripMenu_Click(object sender, EventArgs e){ }

        private void NodoToolStripMenu_Click(object sender, EventArgs e)
        {
            banderita = 1;
            bandera = true;
        }

        private void QuitaNToolStripMenu_Click(object sender, EventArgs e)
        {
            banderita = 2;
            bandera2 = false;
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

        private void moverToolStripMenuItem_Click(object sender, EventArgs e) { banderita = 3; }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save = new SaveFileDialog();
            if (save.ShowDialog() == DialogResult.OK)
            {
                Stream st = File.Open(save.FileName, FileMode.Create);
                BinaryFormatter bin = new BinaryFormatter();
                bin.Serialize(st, ListGrafo);
                
            }
        }

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
                    st.Close();
                }
            }
            else
            {
                open = new OpenFileDialog();
                if (open.ShowDialog() == DialogResult.OK)
                {
                    Stream st = File.Open(open.FileName, FileMode.Open);
                    BinaryFormatter bin = new BinaryFormatter();
                    ListGrafo = (List<Grafo>)bin.Deserialize(st);
                    st.Close();
                }
            }
            Invalidate();
        }

        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //habilita los botones de dirgido y no dirigido
            dirigidoToolStripMenuItem.Enabled = true;
            noDirigidoToolStripMenuItem.Enabled = true;
            DialogResult b = MessageBox.Show("¿Desea guardar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (b == DialogResult.Yes)
            {
                guardarToolStripMenuItem_Click(sender, e);
                ListGrafo.Clear();
            }
            else
            {
                ListGrafo.Clear();
            }
            ListGrafo = new List<Grafo>();
            posG = 0;
            Invalidate();
        }

        private void QuitarAToolStripMenu_Click(object sender, EventArgs e)
        {
            banderita = 5;
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            x = e.X - wid / 2;
            y = e.Y - he / 2;
            if (!bandera2)
            {
                ListGrafo.Add(new Grafo());
                switch (banderita)
                {
                    case 1: //inserta el nodo en la lista grafos
                        ListGrafo[posG].InsertaVertice((ListGrafo[posG].ListaVer.Count + 1).ToString(), x, y);
                        break;
                    case 2: //elimina el nodo de la lista grafos
                        ListGrafo[posG].QuitaVertice(e.X, e.Y);
                        break;
                    case 5:
                        for(int i = 0; i < ListGrafo[posG].ListaVer.Count; i++)
                        {
                            ListGrafo[posG].ListaVer[i].EliminaArista(e.X, e.Y);
                        }
                        break;
                }
            }
            Invalidate();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
           if (bandera2)
            {
                xd = e.X;
                yd = e.Y;
            }
            if (move)
            {
                forma = false;
                label4.Text = "moviendo";
                int aux = ListGrafo[posG].Buscar(e.X, e.Y);
                if (aux >= 0)
                {
                    Grafo n1 = ListGrafo[posG];
                    CVertice n = ListGrafo[posG].ListaVer[aux];
                    label3.Text = "nodo a mover = " + (aux + 1).ToString();
                    n.x = e.X - wid / 2;
                    n.y = e.Y - he / 2;
                    n1.Cambiar();
                }
                Invalidate();
            }
            else
                label4.Text = "No se mueve nada";
            Invalidate();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //busca nodo origen y guarda las coordenadas del mousedown
            if (bandera2)
            {
                forma = true;
               temp1 = ListGrafo[posG].Buscar(e.X, e.Y);
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
                forma = false;
                int temp = ListGrafo[posG].Buscar(e.X, e.Y);
                xd = e.X;
                yd = e.Y;
                label2.Text = "destino= " + (temp+1).ToString();
                destv = temp;
                if (temp >= 0)
                    ListGrafo[posG].ListaVer[temp1].InsertaArista(xd, yd, xo, yo,ListGrafo[posG].ListaVer.ElementAt(temp));
                //xo = yo = xd = yd = -1;
            }
            if (banderita == 5) //activa elimina arista
            {
                for(int i = 0; i < ListGrafo[posG].ListaVer.Count; i++)
                    ListGrafo[posG].ListaVer[i].EliminaArista(xd, yd, xo, yo);
            }
        }
     
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if(forma)
                e.Graphics.DrawLine(lapiz2, xd, yd, xo, yo);
            for (int i = 0; i < ListGrafo.Count; i++)
                for (int j = 0; j < ListGrafo[i].ListaVer.Count; j++)
                {
                    //dibuja el circulo y la etiqueta del nodo
                    bandera = false;
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
                        e.Graphics.DrawLine(lapiz2, arista.destx, arista.desty,arista.orix, arista.oriy);
                    }
                }
        }
    }
}
