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
using System.Threading;
using Microsoft.VisualBasic;


namespace grafosv1
{
    public partial class Form1 : Form
    {
        public int x, y, wid, he; //posiciones del nodo, altura y ancho
        Pen lapiz = new Pen(Color.Blue, 3); //color del contorno del nodo
        Pen lapiz2 = new Pen(Color.BlueViolet, 4); //color de la arista
        public List<Grafo> ListGrafo; //lista de grafos
        public bool BVertice; //bandera cuando se da click en el boton nodo
        public bool TipoArista; //bandera que se activa si se selecciono arista dirigida o no dirigida, checa el mouseup y mousedown
        public bool move, moveG; //bandera para ver si se activa el mover
        public int menu; //checa cual sección del menú se presiono
        public int xo, yo, xd, yd; //coordenadas del nodo origen y nodo destino
        public int temp1, destv; //se guarda la posición del nodo origen y nodo destino para poder hacer las aristas
        public int posG; //posición de la lista de grafos
        bool ponderado = false, dirigido = false, nombrear = false;
        public int x1, y1;

        public List<int> TotalAris = new List<int>();
        int total = 0;
        public bool pintar = false, pAristas = false, impresion = false, bosque = false;

        public Point p1, c1, p2, c2;
        

        //variables para abrir y guardar el grafo
        SaveFileDialog save;
        OpenFileDialog open;
        bool forma = false;

        int dx, dy;

        int[] arreglo, arreglo2;

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

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            pAristas = false;
        }

        //pone los nodos en no visitados
        public void NoVisitados()
        {
            foreach (CVertice v in ListGrafo[posG].ListaVer)
            {
                v.VerVisitado = false;
                foreach (Arista a in v.ListAristas)
                {
                    a.Visitada = false;
                    a.Visitada2 = false;
                }
            }
        
        }

        //nuevo documento
        private void nuevoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NoVisitados();
            pintar = pAristas = false;
            mfloyd.Visible = false;
            vérticeToolStripMenuItem.Enabled = false;
            aristaToolStripMenuItem.Enabled = false;
            //habilita los botones de dirgido y no dirigido
            dirigidoToolStripMenuItem1.Enabled = true;
            noDirigidoToolStripMenuItem1.Enabled = true;
            noPonderadoToolStripMenuItem1.Enabled = true;
            ponderadoToolStripMenuItem.Enabled = true;
            DialogResult b = MessageBox.Show("¿Desea guardar?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (b == DialogResult.Yes)
            {
                guardarToolStripMenuItem_Click(sender, e);
                ListGrafo.Clear();
            }
            else
            {
                ListGrafo.Clear();
                posG = -1;
            }

            temp1 = 0;
            Invalidate();
        }

        //guardar el grafo
        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoVisitados();
            pintar = pAristas = false;
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
            pintar = pAristas = false;
            gradoDeNodoToolStripMenuItem.Enabled = true;
            gradoInternoToolStripMenuItem.Enabled = true;
            aristaToolStripMenuItem.Enabled = true;
            dirigidoToolStripMenuItem1.Enabled = true;
            noDirigidoToolStripMenuItem1.Enabled = true;
            vérticeToolStripMenuItem.Enabled = true;
            nuevoToolStripMenuItem1.Enabled = true;
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

        //crea un nuevo grafo y lo agrega a la lista de grafos
        private void nuevoGrafoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pintar = pAristas = false;
            gradoDeNodoToolStripMenuItem.Enabled = false;
            gradoInternoToolStripMenuItem.Enabled = false;
            aristaToolStripMenuItem.Enabled = true;
            dirigidoToolStripMenuItem1.Enabled = true;
            noDirigidoToolStripMenuItem1.Enabled = true;
            vérticeToolStripMenuItem.Enabled = true;
            nuevoToolStripMenuItem1.Enabled = true;
            Grafo g = new Grafo();
            ListGrafo.Add(g);
            //label5.Text = "grafos en la lista: " + ListGrafo.Count.ToString();
            posG++;
            NumGrafo.Value = posG;
            //label3.Text = "Posición del grafo en la lista: " + posG.ToString();
            menu = 0;
            forma = move = moveG = TipoArista = false;
        }

        //mover grafo   activa variable para mover el grafo
        private void moverGrafoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pintar = pAristas = false;
            mfloyd.Visible = false;
            menu = 6;
        }

        //Crea la matriz de adyacencia  imprime en consola
        private void matrizAdyacenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pintar = pAristas = false;
            mfloyd.Visible = false;
            menu = 8;
            label5.Text = "Matriz de Adyacencia";
            DatosT.Clear();
            ListGrafo[posG].MtzAd(ListGrafo[posG].ListaVer.Count, DatosT, dirigido);
        }

        //Crea la lista de adyacencia   imprime en consola
        private void listaDeAdyacenciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pintar = pAristas = false;
            mfloyd.Visible = false;
            menu = 9;
            label5.Text = "Lista de Adyacencia";
            DatosT.Clear();
            ListGrafo[posG].MtzAd(ListGrafo[posG].ListaVer.Count, DatosT, dirigido);
            ListGrafo[posG].guarda();
            DatosT.Clear();
            ListGrafo[posG].LstAd(DatosT, dirigido);
        }

        //Crea matriz de incidencia
        private void matrizIncidenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pintar = pAristas = false;
            mfloyd.Visible = false;
            menu = 11;
            nombrear = true;
            label5.Text = "Matriz de Incidencia";
            DatosT.Clear();
            ListGrafo[posG].MtzIncd(ListGrafo[posG].ListaVer.Count, TotalAris, DatosT);
        }

        //isomorfismo
        private void isomorfismoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pintar = pAristas = false;
            mfloyd.Visible = false;
            menu = 12;
            if (NumGrafo.Value == 0)
                MessageBox.Show("El indice debe de ser diferente de 0");
            else
            {
                int n = posG - 1;
                ListGrafo[posG].setAris = TotalAris.Count;
                ListGrafo[n].setAris = TotalAris.Count;
                //grafo1
                int[] arreglo = ListGrafo[posG].MtzAd(ListGrafo[posG].ListaVer.Count, DatosT, dirigido);
                ListGrafo[posG].guarda();
                DatosT.Clear();
                ListGrafo[posG].LstAd(DatosT, dirigido);
                DatosT.Clear();

                //grafo2
                int[] arreglo2 = ListGrafo[n].MtzAd(ListGrafo[n].ListaVer.Count, DatosT, dirigido);
                ListGrafo[n].guarda();
                DatosT.Clear();
                ListGrafo[n].LstAd(DatosT, dirigido);
                DatosT.Clear();

                ListGrafo[posG].setGrados = arreglo;
                ListGrafo[n].setGrados = arreglo2;

                if (ListGrafo.Count > 1)
                {
                    if (ListGrafo[posG].Dir == ListGrafo[n].Dir)
                    {
                        if (ListGrafo[posG].Iso(ListGrafo[posG], ListGrafo[n]))
                            MessageBox.Show("Son Isomorficos");
                        else
                            MessageBox.Show("No Son Isomorficos");
                    }
                    else
                        MessageBox.Show("No son del mismo tipo de grafos");
                }
                else
                    MessageBox.Show("Solo hay un grafo");
            }
        } 

        //crea nuevo nodo       activa banderas para dibujar los nodos
        private void nuevoNodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pintar = pAristas = false;
            mfloyd.Visible = false;
            menu = 1;
            //forma = false;
            TipoArista = false;
            BVertice = true;
            temp1 = 0;
        }

        //elimina nodo      activa bandera para eliminar los nodos
        private void quitarNodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pintar = pAristas = false;
            mfloyd.Visible = false;
            menu = 2;
            TipoArista = false;
        }

        //mover nodo        activa bandera para mover el nodo seleccionado
        private void moverNodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pintar = pAristas = false;
            mfloyd.Visible = false;
            menu = 3;
        }

        private void nuevaAristaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pintar = pAristas = false;
            mfloyd.Visible = false;
            total = 0;
            TotalAris.Clear();
        }

        private void medioKuratowskyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pintar = pAristas = false;
            mfloyd.Visible = false;
            //a partir del grafo determinar si contiene un subgrafo homeomórfico a k3,3 o k5
            Grafo g = ListGrafo[posG];
            int NV = g.ListaVer.Count;
            DatosT.Clear();
            int[] arr = g.MtzAd(NV, DatosT, dirigido);
            int[] arr2 = arr;
            g.setGrados = arr;
            List<int> list = new List<int>();
            List<int> list2 = new List<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                //grados del vértice para para k5
                if (arr[i] >= 4)
                    list.Add(i);

            }
            for (int i = 0; i < arr2.Length; i++)
            {
                //grados del vértice para k3,3
                if (arr2[i] >= 3)
                    list2.Add(i);
            }
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine("Lista de k5"); 
                Console.WriteLine("Elemento " + i + " " + list[i]);
            }
            for (int i = 0; i < list2.Count; i++)
            {
                Console.WriteLine("Lista de k3,3");
                Console.WriteLine("Elemento " + i + " " + list2[i]);
            }


            if (list.Count >= 5)
                MessageBox.Show("El grafo contiene a k5");
            else if (list2.Count >= 6)
                MessageBox.Show("El grafo contien a k3,3");
            else if (list.Count >= 5 && list2.Count >= 6)
                MessageBox.Show("Contiene a k5 y k3,3");
            else
                MessageBox.Show("No contiene k5 ni k3,3");
        }

        private void caminoEulerianoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pintar = pAristas = false;
            mfloyd.Visible = false;
            int cont = 0;
            bool resp = false;
            int[] arreglo = ListGrafo[posG].MtzAd(ListGrafo[posG].ListaVer.Count, DatosT, dirigido);
            ListGrafo[posG].setGrados = arreglo;
            DatosT.Clear();
            for(int i = 0; i< ListGrafo[posG].setGrados.Length; i++)
                if (ListGrafo[posG].setGrados[i] % 2 != 0)
                    cont++;
            if (cont == 2)
                resp = true;
            if (resp)
                MessageBox.Show("El grafo tiene un camino Euleriano");
            else
                MessageBox.Show("El grafo no tiene un camino Euleriano");
        }

        private void ciruitoEulerianoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pintar = pAristas = false;
            mfloyd.Visible = false;
            bool resp = true;
            int[] arreglo = ListGrafo[posG].MtzAd(ListGrafo[posG].ListaVer.Count, DatosT, dirigido);
            ListGrafo[posG].setGrados = arreglo;
            DatosT.Clear();
            CVertice vertex = ListGrafo[posG].ListaVer[0];
            for (int i = 0; i < ListGrafo[posG].setGrados.Length; i++)
                if (ListGrafo[posG].setGrados[i] % 2 != 0)
                    resp = false;
            if (resp)
                CircuitoRecursivo(vertex);
            // MessageBox.Show("El grafo tiene un Circuito Euleriano");
            else
                MessageBox.Show("El grafo no tiene un Circuito Euleriano");

        }
        List<CVertice> lista = new List<CVertice>();
        List<Arista> ArVisitadas = new List<Arista>();

        public void CircuitoRecursivo(CVertice ver)
        {
            if(lista.Count == 0)
            {
                lista.Add(ver);
                ver.ListAristas[0].Visitada = true;
                Refresh();
                Thread.Sleep(1000);
                ArVisitadas.Add(ver.ListAristas[0]);
                CircuitoRecursivo(ver.ListAristas[0].destino);
            }
        }

        private void corolario1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pintar = pAristas = false;
            mfloyd.Visible = false;
            ListGrafo[posG].setAris = TotalAris.Count;
            int valor = (3 * ListGrafo[posG].ListaVer.Count) - 6;
            if (ListGrafo[posG].ListaVer.Count >= 3 && ListGrafo[posG].setAris <= valor)
                MessageBox.Show("El grafo es plano");
            else
                MessageBox.Show("El grafo no es plano");
        }

        private void cotolario2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pintar = pAristas = false;
            mfloyd.Visible = false;
            ListGrafo[posG].setAris = TotalAris.Count;
            int valor = (2 * ListGrafo[posG].ListaVer.Count) - 4;
            if (ListGrafo[posG].ListaVer.Count >= 3 && ListGrafo[posG].setAris <= valor)
                MessageBox.Show("El grafo es plano");
            else
                MessageBox.Show("El grafo no es plano");

        }

        private void númeroCromáticoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pAristas = false;
            mfloyd.Visible = false;
            pintar = true;
            int cont = 0;
            int[] arreglo = ListGrafo[posG].MtzAd(ListGrafo[posG].ListaVer.Count, DatosT, dirigido);
            ListGrafo[posG].guarda();
            DatosT.Clear();
            ListGrafo[posG].LstAd(DatosT, dirigido);
            DatosT.Clear();

            //Asegura que en un principio el número cromático de los vértices es 0
            for (int i = 0; i < ListGrafo[posG].ListaVer.Count; i++)
                ListGrafo[posG].ListaVer[i].NumCrom = 0;


            for (int i = 0; i < ListGrafo[posG].ListaVer.Count; i++)
            {
                CVertice ver = ListGrafo[posG].ListaVer[i];
                if (ver.NumCrom == 0)
                {
                    cont++;
                    ver.NumCrom = cont;
                }
                Console.WriteLine("Vértice: " + ver.name + " Número cromático: " + ver.NumCrom);
                string ady = ListGrafo[posG].ListVAdy[i];
                foreach (char n in ady)
                {
                    int p = Int32.Parse(n.ToString());
                    CVertice vertice = ListGrafo[posG].ListaVer[p - 1];
                    if (vertice.NumCrom == 0)
                    {
                        if (i == 0)
                        {
                            cont++;
                            vertice.NumCrom = cont;
                            Console.WriteLine("Vértice: " + vertice.name + " Número cromático: " + vertice.NumCrom);
                        }
                        else if (!ListGrafo[posG].ListVAdy[i - 1].Contains(n))
                        {
                            vertice.NumCrom = ListGrafo[posG].ListaVer[i - 1].NumCrom;
                            if (vertice.NumCrom == ListGrafo[posG].ListaVer[p - 2].NumCrom)
                                vertice.NumCrom = ListGrafo[posG].ListaVer[p - 3].NumCrom;
                            Console.WriteLine("Vértice: " + vertice.name + " Número cromático: " + vertice.NumCrom);
                        }
                        else
                        {
                            cont++;
                            vertice.NumCrom = cont;
                            Console.WriteLine("Vértice: " + vertice.name + " Número cromático: " + vertice.NumCrom);
                        }
                     }
                }
            }
            int mayor = ListGrafo[posG].ListaVer[0].NumCrom;
            for (int i = 0; i < ListGrafo[posG].ListaVer.Count; i++)
            {
                CVertice v = ListGrafo[posG].ListaVer[i];
                if (v.NumCrom > mayor)
                    mayor = v.NumCrom;
                Console.WriteLine("Vértice " + ListGrafo[posG].ListaVer[i].name + " número cromático " + ListGrafo[posG].ListaVer[i].NumCrom);
            }
            //MessageBox.Show("El número cromático es " + mayor);
        }

        private void recorridoEnAmplitudToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pintar = pAristas = false;
            mfloyd.Visible = false;
            int[] arreglo = ListGrafo[posG].MtzAd(ListGrafo[posG].ListaVer.Count, DatosT, dirigido);
            ListGrafo[posG].guarda();
            DatosT.Clear();
            ListGrafo[posG].LstAd(DatosT, dirigido);
            for (int i = 0; i < ListGrafo[posG].ListaVer.Count; i++)
            {
                CVertice ver = ListGrafo[posG].ListaVer[i];
                bea(ver);
            }
        }

        //recorrido en aplitud
        public void bea(CVertice v)
        {
            List<CVertice> visitados = new List<CVertice>();
            List<string> cola = new List<string>();
            string VerRecorridos = "";
            if (v.VerVisitado == false)
            {
                //int s = Int32.Parse(v.name); //´convierte el nombre en entero
                v.VerVisitado = true;
                visitados.Add(v);
                cola.Add(v.name);
                while (cola.Any())
                {
                    string actual = cola[0];
                    cola.Remove(actual);
                    int s = Int32.Parse(actual); //´convierte el nombre en entero
                    string ady = ListGrafo[posG].ListVAdy[s - 1];
                    char[] ArrAdy = ady.ToCharArray();
                    for (int i = 0; i < ArrAdy.Length; i++)
                    {
                        int pos = Int32.Parse(ArrAdy[i].ToString());
                        CVertice ver = ListGrafo[posG].ListaVer[pos - 1];
                        if (ver.VerVisitado == false)
                        {
                            ver.VerVisitado = true;
                            Refresh();
                            Thread.Sleep(1000);
                            cola.Add(ver.name);
                            visitados.Add(ver);
                        }

                    }
                }

                for (int i = 0; i < visitados.Count; i++)
                    VerRecorridos += " " + visitados[i].name;
                MessageBox.Show("Recorrido en amplitud: " + VerRecorridos);
                // Console.Write(" " + visitados[i]);
            }
            //return visitados;
        }

        private void bosqueAbarcadorEnProfundidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pintar = pAristas = false;
            mfloyd.Visible = false;
            bosque = true;
           // Bosque b = new Bosque();
            int[] arreglo = ListGrafo[posG].MtzAd(ListGrafo[posG].ListaVer.Count, DatosT, dirigido);
            ListGrafo[posG].guarda();
            DatosT.Clear();
            ListGrafo[posG].LstAd(DatosT, dirigido);
            CVertice vertex = ListGrafo[posG].ListaVer[0];
            ListGrafo[posG].dfs(vertex);
            for (int i = 0; i < ListGrafo[posG].ListaVer.Count; i++)
            {
                CVertice ver = ListGrafo[posG].ListaVer[i];
                if (ver.VerVisitado == false)
                {
                    //ListGrafo[posG].dfs(ver);
                    ListGrafo[posG].dfs2(ver);
                }
            }
            //List<CVertice> v = ListGrafo[posG].visitados;

            ListGrafo[posG].imprimedfs();
            ListGrafo[posG].Bosque();
            //ListGrafo[posG].imprimedfs();
            //ListGrafo[posG].Bosque();
            // Console.Write("Busqueda en profundidad: " + ListGrafo[posG].Recorridos);
            //NoVisitados();
            //this.Hide();
            //MessageBox.Show("Busqueda en profundidad: " + ListGrafo[posG].Recorridos);

            //b.Show();

        }
        private void floydToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pintar = pAristas = false;
            ponderado = true;
            label5.Text = "";
            DatosT.Clear();
            menu = 8;
            ListGrafo[posG].MatrizAdyP(ListGrafo[posG].ListaVer.Count, DatosT);
            ListGrafo[posG].Floyd(mfloyd);
        }


        private void impresiónDeCaminosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NoVisitados();
            pintar = pAristas = false;
            label5.Text = "";
            DatosT.Clear();
            menu = 8;
            ListGrafo[posG].MatrizAdyP(ListGrafo[posG].ListaVer.Count, DatosT);
            mfloyd.Clear();
            ListGrafo[posG].Floyd(mfloyd);
            string a = Interaction.InputBox("Nodo Inicial", "Impresión de Caminos", "1", 100, 50);
            string b = Interaction.InputBox("Nodo Final", "Impresión de Caminos", "1", 100, 50);
            label1.Text = "";
            label1.Text += "Inicio: " + a + Environment.NewLine + "Fin: " + b;
            int inicio = Convert.ToInt32(a);
            int fin = Convert.ToInt32(b);
            BuscaCamino(inicio, fin);
            impresion = true;
            //ListGrafo[posG].CaminosFloyd(richTextBox1);

        }
        List<CVertice> recorrido = new List<CVertice>();
        public List<CVertice> BuscaCamino(int inicio, int fin)
        {
            //impresion = true;
            int[,] caminos = ListGrafo[posG].caminos;
            
            recorrido.Add(ListGrafo[posG].ListaVer[inicio-1]);
            if (caminos[inicio - 1, fin - 1] == fin)
            {
                recorrido.Add(ListGrafo[posG].ListaVer[fin - 1]);
            }
            else
            {
                int aux;
                for (int j = 0; j < ListGrafo[posG].ListaVer.Count; j++)
                {
                    aux = caminos[inicio - 1, fin - 1] - 1;
                    //Console.WriteLine(i + " " + j);
                    if (caminos[aux, j] == fin)
                    {
                        if (!recorrido.Contains(ListGrafo[posG].ListaVer[aux]))
                            recorrido.Add(ListGrafo[posG].ListaVer[aux]);
                        break;
                    }
                    else
                    {
                        if (!recorrido.Contains(ListGrafo[posG].ListaVer[aux]))
                            recorrido.Add(ListGrafo[posG].ListaVer[aux]);
                        int aux2 = caminos[aux, fin - 1] - 1;
                        if (caminos[aux2, j] == fin)
                        {
                            if (!recorrido.Contains(ListGrafo[posG].ListaVer[aux2]))
                                recorrido.Add(ListGrafo[posG].ListaVer[aux2]);
                            break;
                        }
                    }
                }
            }

            if (!recorrido.Contains(ListGrafo[posG].ListaVer[fin-1]))
                recorrido.Add(ListGrafo[posG].ListaVer[fin-1]);

            for (int i = 0; i < recorrido.Count; i++)
            {
               if (recorrido[i].VerVisitado == false)
                {
                    Refresh();
                    Thread.Sleep(1000);
                    recorrido[i].VerVisitado = true;
                }
                Console.WriteLine(" " + recorrido[i].name);
            }
            return recorrido;
        }

        public void PintaImpresionCaminos(PaintEventArgs e)
        {

            for (int i = 0; i < recorrido.Count-1; i++)
            {
                for (int j = 0; j < recorrido[i].ListAristas.Count; j++)
                {
                    Arista arista = recorrido[i].ListAristas[j];

                    if (arista.destino.name == recorrido[i + 1].name)
                    {
                        //Console.WriteLine("arista: " + arista.peso);
                        e.Graphics.DrawLine(new Pen(Color.Red, 3), arista.destx, arista.desty, arista.orix, arista.oriy);
                    }
                }
            }
            //recorrido.Clear();
            //impresion = false;

        }

        public void PintaAr(PaintEventArgs e)
        {
            List<Arista> aristas = ListGrafo[posG].kruskal();
            for (int i = 0; i < aristas.Count; i++)
            {
                Arista arista = aristas[i];
                Console.WriteLine("arista: " + arista.peso);
                e.Graphics.DrawLine(new Pen(Color.Red, 3), arista.destx, arista.desty, arista.orix, arista.oriy);
            }

        }

        private void kruskalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pintar = false;
            mfloyd.Visible = false;
            ListGrafo[posG].kruskal();
            pAristas = true;
           // ponderado = true;
        }

        private void acíclicosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pintar = pAristas = false;
            mfloyd.Visible = false;
            int[] arreglo = ListGrafo[posG].MtzAd(ListGrafo[posG].ListaVer.Count, DatosT, dirigido);
            ListGrafo[posG].guarda();
            DatosT.Clear();
            ListGrafo[posG].LstAd(DatosT, dirigido);
            CVertice vertex = ListGrafo[posG].ListaVer[0];
            ListGrafo[posG].dfs(vertex);
            if (ListGrafo[posG].ciclico == 0)
                MessageBox.Show("El grafo es acíclico");
            else
                MessageBox.Show("El grafo no es acíclico");
        }

        //grado del vértice     activa bandera la dar el grado del vértice que se de click
        private void gradoDeNodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pintar = pAristas = false;
            mfloyd.Visible = false;
            menu = 7;
            DatosT.Clear();
            arreglo = ListGrafo[posG].MtzAd(ListGrafo[posG].ListaVer.Count, DatosT, dirigido);
        }

        private void gradoInternoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pintar = pAristas = false;
            mfloyd.Visible = false;
            menu = 10;
            DatosT.Clear();
            //arreglo = ListGrafo[posG].MtzAd(ListGrafo[posG].ListaVer.Count, DatosT, dirigido);
            arreglo2 =ListGrafo[posG].mtzad(ListGrafo[posG].ListaVer.Count, DatosT, dirigido);
        }

        private void vérticeToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        //aristas dirigidas
        private void dirigidoToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            gradoDeNodoToolStripMenuItem.Enabled = true;
            gradoInternoToolStripMenuItem.Enabled = true;
            dirigido = true;
            ListGrafo[posG].Dir = true;
            /*TipoArista = true;
            menu = 4;
            //deshabilita el botón de no dirigido y se dibuja la línea con flecha
            noDirigidoToolStripMenuItem1.Enabled = false;
            lapiz2.StartCap = LineCap.ArrowAnchor;
            lapiz2.EndCap = LineCap.NoAnchor;*/
        }

        //Se usan banderas para poner ponderación en las aristas dirigidas
        private void ponderadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ponderado = true;
            TipoArista = true;
            menu = 4;
            //deshabilita el botón de no dirigido y se dibuja la línea con flecha
            noDirigidoToolStripMenuItem1.Enabled = false;
            noPonderadoToolStripMenuItem.Enabled = false;
            lapiz2.StartCap = LineCap.ArrowAnchor;
            lapiz2.EndCap = LineCap.NoAnchor;
        }

        //Se usan banderas para poner aristas sin ponderación
        private void noPonderadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ponderado = false;
            TipoArista = true;
            menu = 4;
            //deshabilita el botón de no dirigido y se dibuja la línea con flecha
            noDirigidoToolStripMenuItem1.Enabled = false;
            ponderadoToolStripMenuItem.Enabled = false;
            lapiz2.StartCap = LineCap.ArrowAnchor;
            lapiz2.EndCap = LineCap.NoAnchor;
        }

        //aristas no dirigidas
        private void noDirigidoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            gradoDeNodoToolStripMenuItem.Enabled = true;
            gradoInternoToolStripMenuItem.Enabled = true;
            dirigido = false;
            ListGrafo[posG].Dir = false;
            /*TipoArista = true;
            menu = 4;
            //deshabilita el botón de dirigido y se dibuja la línea
            dirigidoToolStripMenuItem1.Enabled = false;
            lapiz2.StartCap = LineCap.NoAnchor;
            lapiz2.EndCap = LineCap.NoAnchor;*/
        }

        //Se usan banderas para pner ponderacion a las aristas no dirigidas
        private void ponderadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ponderado = true;
            TipoArista = true;
            menu = 4;
            //deshabilita el botón de dirigido y se dibuja la línea
            dirigidoToolStripMenuItem1.Enabled = false;
            lapiz2.StartCap = LineCap.NoAnchor;
            lapiz2.EndCap = LineCap.NoAnchor;
        }

        //se usan banderas para poner aristas no dirigidas sin ponderación
        private void noPonderadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ponderado = false;
            TipoArista = true;
            menu = 4;
            //deshabilita el botón de dirigido y se dibuja la línea
            dirigidoToolStripMenuItem1.Enabled = false;
            lapiz2.StartCap = LineCap.NoAnchor;
            lapiz2.EndCap = LineCap.NoAnchor;
        }

        //Se activa bandera para poder eliminar una arista
        private void eliminaAristaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pintar = pAristas = false;
            mfloyd.Visible = false;
            menu = 5;
        }

        //Se asigna a la variable de posición de grafo el valor de este numericUpDown
        private void NumGrafo_ValueChanged(object sender, EventArgs e)
        {
            pintar = pAristas = false;
            mfloyd.Visible = false;
            posG = ((int)NumGrafo.Value);

        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            NoVisitados();
           pAristas = impresion = pintar = bosque = false;
            recorrido.Clear();
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

            //si esta activa la bandera de mover grafo se asignan las nuevas coordenadas de los nodos y aristas 
            if (moveG)
            {
                Grafo g = ListGrafo[posG];
                int dx = e.X - xo;
                int dy = e.Y - yo;
                xo = e.X;
                yo = e.Y;
                foreach (CVertice v in g.ListaVer)
                {
                    v.x += dx;
                    v.y += dy;
                    foreach (Arista a in v.ListAristas)
                    {
                        a.orix += dx;
                        a.oriy += dy;
                        a.destx += dx;
                        a.desty += dy;
                        a.puntos();
                    }
                }
                Invalidate();
            }

            //mueve un nodo del grafo
            if (move)
            {
                forma = false;
                moveG = false;
                //label4.Text = "moviendo";
                int aux = ListGrafo[posG].Buscar(e.X, e.Y);
                if (aux >= 0)
                {
                    Grafo g = ListGrafo[posG];
                    CVertice n = ListGrafo[posG].ListaVer[aux];
                    n.x = e.X - wid / 2;
                    n.y = e.Y - he / 2;
                    //label3.Text = "nodo a mover = " + (aux + 1).ToString();
                    for (int i = 0; i < g.ListaVer.Count; i++)
                    g.ListaVer[i].Cambia();
                }
            }
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
               //label1.Text = "origen = "+ (temp1+1).ToString();
            }

            //activa bandera para mover nodos y aristas
            if (menu == 3)
            {
                move = true;
                moveG = false;
                forma = false;
                
            }

            //desactiva la bandera de si se esta en la forma 
            if (menu == 1 || menu == 5 || menu == 8 || menu == 9 || menu == 10)
            {
                forma = false;
            }

            //activa la bandera de mover grafo
            if (menu == 6)
            {
                moveG = true;
                forma = false;
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {

            moveG = false;
            //si esta activa la bandera de mover nodo se cambian las coordenadas el nodo
            if (move)
            {
                x1 = e.X - xo;
                y1 = e.Y - yo;
                move = false;
                Invalidate();
            }
            

            //busca nodo destino, guarda las coorenadas del mouseup e inserta las aristas
            //TotalAris = 0;
            if (TipoArista && menu == 4)
            {
                move = false;
                forma = false;
                int temp = ListGrafo[posG].Buscar(e.X, e.Y);
                xd = e.X;
                yd = e.Y;
                //label2.Text = "destino= " + (temp+1).ToString();
                destv = temp;
                if (temp >= 0)
                {
                    total++;
                    ListGrafo[posG].ListaVer[temp1].InsertaArista(total.ToString(),xd, yd, xo, yo, ListGrafo[posG].ListaVer.ElementAt(temp), ponderado, dirigido);
                    TotalAris.Add(total);
                }
                Console.WriteLine("aristas = " + total.ToString());
                
                destv = 0;
                //xo = yo = xd = yd = -1;
            }
            
            //Llama al método que elimina la arista
            if (menu == 5) 
            {
                forma = false;
                for (int i = 0; i < ListGrafo[posG].ListaVer.Count; i++)
                {
                    ListGrafo[posG].ListaVer[i].EliminaArista(e.X, e.Y);
                    
                    total -= 1;
                }
            }
            //Da el grado del vértice
            if (menu == 7)
            {
                forma = false;
                int t = ListGrafo[posG].Buscar(e.X, e.Y);
                if (t >= 0)
                {
                    for (int i = 0; i < arreglo.Length; i++)
                    {
                        if(t == i)
                        MessageBox.Show("El grado del vértie es: " + arreglo[i], "Grado del vértice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            //Da el grado interno y externo del vértice
            if (menu == 10)
            {
                forma = false;
                int t = ListGrafo[posG].Buscar(e.X, e.Y);
                if (t >= 0)
                {
                    for (int i = 0; i < arreglo2.Length; i++)
                    {
                        if (t == i)
                        {
                            int grade = ListGrafo[posG].ListaVer[t].ListAristas.Count; //externo
                            if (dirigido == true)
                            {

                                int g = arreglo2[i]; //interno
                                //label1.Text = g.ToString();
                                MessageBox.Show("El grado interno del vértice es: " + g.ToString()
                                + Environment.NewLine + "El grado externo del vertice es: " +
                                grade.ToString(), "Grado de vértice", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            //g = arreglo[i] + grade;
                        }
                    }
                }
            }
            Invalidate();
        }
     
        private void PintaCromatico(PaintEventArgs e)
        {
            forma = false;
            foreach (CVertice v in ListGrafo[posG].ListaVer)
            {
                int color = v.NumCrom;
                switch(color)
                {
                    case 1: //rojo
                        e.Graphics.FillEllipse(new SolidBrush(Color.Red), v.x, v.y, wid, he);
                        break;
                    case 2: //verde
                        e.Graphics.FillEllipse(new SolidBrush(Color.Green), v.x, v.y, wid, he);
                        break;
                    case 3://amarillo
                        e.Graphics.FillEllipse(new SolidBrush(Color.Yellow), v.x, v.y, wid, he);
                        break;
                    case 4://naranja
                        e.Graphics.FillEllipse(new SolidBrush(Color.Orange), v.x, v.y, wid, he);
                        break;
                    case 5://rosa
                        e.Graphics.FillEllipse(new SolidBrush(Color.Pink), v.x, v.y, wid, he);
                        break;
                    case 6://cafe
                        e.Graphics.FillEllipse(new SolidBrush(Color.Brown), v.x, v.y, wid, he);
                        break;
                }
            }
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
                                if (k <= 3 && ListGrafo[i].ListaVer.ElementAt(j) != ListGrafo[i].ListaVer[j].ListAristas[k].RegresaDest)
                                {
                                    arista.Recta = true;
                                    e.Graphics.DrawLine(lapiz2, arista.destx, arista.desty, arista.orix, arista.oriy);
                                }
                                else
                                {
                                    arista.Recta = false;
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
                                }
                                //arista.puntos();
                                int xm = (arista.destino.x + arista.orix) / 2;
                                int ym = (arista.destino.y + arista.oriy) / 2;
                                if (nombrear == true)
                                    e.Graphics.DrawString("e"+arista.NombreAr, new Font("Times New Roman", 10),
                                        new SolidBrush(Color.Black), xm, ym);
                                if (ponderado == true)
                                    e.Graphics.DrawString(arista.peso.ToString(), new Font("Times New Roman", 10),
                                        new SolidBrush(Color.Black), xm, ym);
                                //label1.Text = arista.peso.ToString();
                                point.Clear();
                                
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
                                if (k <= 3 && ListGrafo[i].ListaVer.ElementAt(j) != ListGrafo[i].ListaVer[j].ListAristas[k].RegresaDest)
                                {
                                    arista.Recta = true;
                                    e.Graphics.DrawLine(lapiz2, arista.destx, arista.desty, arista.orix, arista.oriy);
                                }
                                else
                                {
                                    arista.Recta = false;
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
                                }
                                //posiciones para el nombre de la arista 
                                int xm = (arista.destino.x + arista.orix) / 2;
                                int ym = (arista.destino.y + arista.oriy) / 2;
                                //bandera para que se visualicen los nombres de las aristas
                                if (nombrear == true)
                                    e.Graphics.DrawString("e"+arista.NombreAr, new Font("Times New Roman", 10),
                                        new SolidBrush(Color.Black), xm, ym);
                                //bandera para que se visualicen las ponderaciones 
                                if (ponderado == true)
                                    e.Graphics.DrawString(arista.peso.ToString(), new Font("Times New Roman", 10),
                                        new SolidBrush(Color.Black),xm, ym);
                                //label1.Text = arista.peso.ToString();
                                point.Clear();
                                
                            }
                        }
                    }
                }
                else
                {
                    if (pintar)
                        PintaCromatico(e);
                    if (impresion)
                        PintaImpresionCaminos(e);
                   // if (bosque)
                    //    PintaBosque(e);

                    //for (int i = 0; i < ListGrafo.Count; i++)
                    for (int j = 0; j < ListGrafo[i].ListaVer.Count; j++)
                    {
                        //dibuja el circulo y la etiqueta del nodo
                        BVertice = false;
                        Rectangle r = new Rectangle(ListGrafo[i].ListaVer[j].x, ListGrafo[i].ListaVer[j].y, wid, he);
                        //e.Graphics.DrawRectangle(lapiz,r);
                        CVertice ver = ListGrafo[i].ListaVer[j];
                        if (ver.VerVisitado)
                        {
                            e.Graphics.DrawEllipse(new Pen(Color.Red, 3), ver.x, ver.y, wid, he);
                            e.Graphics.DrawString(ver.name, new Font("Times New Roman", 12),
                             new SolidBrush(Color.Blue), ver.x + wid / 3, ver.y + he / 4);
                        }
                        else
                        {
                            e.Graphics.DrawEllipse(lapiz, ver.x, ver.y, wid, he);
                            e.Graphics.DrawString(ver.name, new Font("Times New Roman", 12),
                              new SolidBrush(Color.Blue), ver.x + wid / 3, ver.y + he / 4);
                        }


                        //dibuja las líneas 
                        for (int k = 0; k < ver.ListAristas.Count; k++)
                        {
                            Arista arista = ver.ListAristas[k];
                            if (k <= 3 && ListGrafo[i].ListaVer.ElementAt(j) != ListGrafo[i].ListaVer[j].ListAristas[k].RegresaDest)
                            {
                                Pen lapiz3 = new Pen(Color.Red, 4);
                                lapiz3.StartCap = LineCap.ArrowAnchor;
                                lapiz3.EndCap = LineCap.NoAnchor;

                                Pen lapiz4 = new Pen(Color.DarkCyan, 4);
                                lapiz4.DashPattern = new float[] { 2.0F, 2.0F, 1.0F, 2.0F };
                                lapiz4.StartCap = LineCap.ArrowAnchor;
                                lapiz4.EndCap = LineCap.NoAnchor;

                                arista.Recta = true;
                                if (pAristas)
                                    PintaAr(e);
                                else if (arista.Visitada)
                                   e.Graphics.DrawLine(lapiz3, arista.destx, arista.desty, arista.orix, arista.oriy);
                                else if(arista.Visitada2)
                                    e.Graphics.DrawLine(lapiz4, arista.destx, arista.desty, arista.orix, arista.oriy);
                                else
                                    e.Graphics.DrawLine(lapiz2, arista.destx, arista.desty, arista.orix, arista.oriy);


                            }
                            else
                            {
                                arista.Recta = false;
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
                            }
                            //Console.WriteLine("nombre arista = " + arista.NombreAr);
                            int xm = (arista.destino.x + arista.orix) / 2;
                            int ym = (arista.destino.y + arista.oriy) / 2;
                            if(nombrear == true)
                                e.Graphics.DrawString("e"+arista.NombreAr, new Font("Times New Roman", 10),
                                    new SolidBrush(Color.Black),xm, ym );
                            if (ponderado == true)
                                e.Graphics.DrawString(arista.peso.ToString(), new Font("Times New Roman", 10),
                                    new SolidBrush(Color.Black), xm, ym);
                            //label1.Text = arista.peso.ToString();
                            point.Clear();
                        }
                    }
                }
            }
        }
    }
}
