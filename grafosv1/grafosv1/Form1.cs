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
        public bool BVertice; //bandera cuando se da click en el boton nodo
        public bool TipoArista; //bandera que se activa si se selecciono arista dirigida o no dirigida, checa el mouseup y mousedown
        public bool move, moveG; //bandera para ver si se activa el mover
        public int menu; //checa cual sección del menú se presiono
        public int xo, yo, xd, yd; //coordenadas del nodo origen y nodo destino
        public int temp1, destv; //se guarda la posición del nodo origen y nodo destino para poder hacer las aristas
        public int posG; //posición de la lista de grafos

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
            //temp1 = 0;
            posG = -1;
            ListGrafo = new List<Grafo>();

            vérticeToolStripMenuItem.Enabled = false;
            aristaToolStripMenuItem.Enabled = false;
            //ListGrafo.Add(new Grafo());
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
                    posG = 0;
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

        private void moverNodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menu = 3;
        }

        private void dirigidoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TipoArista = true;
            menu = 4;
            //deshabilita el botón de no dirigido y se dibuja la línea con flecha
            noDirigidoToolStripMenuItem1.Enabled = false;
            lapiz2.StartCap = LineCap.ArrowAnchor;
            lapiz2.EndCap = LineCap.NoAnchor;
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

        private void moverGrafoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menu = 6;
        }

        //crea un nuevo grafo y lo agrega a la lista de grafos
        private void nuevoGrafoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aristaToolStripMenuItem.Enabled = true;
            vérticeToolStripMenuItem.Enabled = true;
            //posG = ListGrafo.Count;
            Grafo g = new Grafo();
            ListGrafo.Add(g);
            posG++;
            label3.Text = "Posición de la lista: " + posG.ToString();
            label5.Text = "grafos en la lista: " + ListGrafo.Count.ToString();
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
                
                //posG = -1;
            }
            else
                ListGrafo.Clear();
            ListGrafo = new List<Grafo>();
            //posG = 0;
            //temp1 = 0;
            Invalidate();
        }


        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            x = e.X - wid / 2;
            y = e.Y - he / 2;
            if (!TipoArista)
            {
                ListGrafo.Add(new Grafo());
                switch (menu)
                {
                    case 1: //inserta el nodo en la lista grafos
                        ListGrafo[posG].InsertaVertice((ListGrafo[posG].ListaVer.Count + 1).ToString(), x, y);
                        break;
                    case 2: //elimina el nodo de la lista grafos
                        ListGrafo[posG].QuitaVertice(e.X, e.Y);
                        break;
                    case 5:
                        /*for(int i = 0; i < ListGrafo[posG].ListaVer.Count; i++)
                        {
                            //ListGrafo[posG].ListaVer[i].EliminaArista(e.X, e.Y);
                        }*/
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
            xo = e.X;
            yo = e.Y;
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
            }
            //desactiva la bandera de si se esta en la forma 
            if (menu == 5)
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
            //si esta activa la bandera de mover grafo se masignan las nuevas coordenadas de los nodos y aristas 
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
                    }
                }
                moveG = false;
                forma = false;
            }

            move = false;
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
                    ListGrafo[posG].ListaVer[temp1].InsertaArista(xd, yd, xo, yo,ListGrafo[posG].ListaVer.ElementAt(temp));
                //xo = yo = xd = yd = -1;
            }
            if (menu == 5) //activa elimina arista
            {
                forma = false;
                for (int i = 0; i < ListGrafo[posG].ListaVer.Count; i++)
                    ListGrafo[posG].ListaVer[i].EliminaArista(e.X, e.Y);
            }

        }
     
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (forma)
                e.Graphics.DrawLine(lapiz2, xd, yd, xo, yo);
            if(moveG)
            {
                    for (int j = 0; j < ListGrafo[posG].ListaVer.Count; j++)
                    {
                        dx = xd - xo;
                        dy = yd - yo;
                        //dibuja el circulo y la etiqueta del nodo
                        CVertice ver = ListGrafo[posG].ListaVer[j];
                        e.Graphics.DrawEllipse(lapiz, ver.x-(wid/10)+dx, ver.y-(he/10)+dy, wid, he);
                        e.Graphics.DrawString(ver.name, new Font("Times New Roman", 12),
                          new SolidBrush(Color.Blue), ver.x + wid / 3+dx, ver.y + he / 4 + dy);
                        //dibuja las líneas 
                        for (int k = 0; k < ver.ListAristas.Count; k++)
                        {
                            Arista arista = ver.ListAristas[k];
                            e.Graphics.DrawLine(lapiz2, arista.destx+dx, arista.desty+dy, arista.orix+dx, arista.oriy+dy);
                        }
                    }
            }
            else
            {
                for (int i = 0; i < ListGrafo.Count; i++)
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
                            e.Graphics.DrawLine(lapiz2, arista.destx, arista.desty, arista.orix, arista.oriy);
                            /*Point[] points =
                            {
                                new Point(arista.destx,arista.desty),
                                new Point(arista.orix, arista.oriy)
                            };
                            e.Graphics.DrawClosedCurve(lapiz2, points);*/
                        }
                    }
            }
        }
    }
}
