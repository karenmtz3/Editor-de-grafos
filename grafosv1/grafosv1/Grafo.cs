using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grafosv1
{
    [Serializable()]
    public class Grafo
    {
        /**
         * ListaVer -> Lista de los vértices que hay en el grafo
         * auxi -> Auxiliar que guarda la posición del vértice encontrado
         * totalAris -> Variable que almacena el total de aristas que hay el el grafo
         * dirigido -> Variable que dice si el grafo es dirigido o no dirigido
         * ListGradosAd -> Lista que almacena los grados adyacentes
         * ListVAdy -> Lista que almacena los nombre de los vértices adyacentes
         * ciclico -> Variable para saber si un grafo es acíclico o no 
         * m -> Varialbe para llamar a la clase que crea la matriz de adyacencia
         * mi -> Variable para llamar a la clase que crea la matriz de incidencia
         * l -> Variable para llamar a la clase que crea la lista de adyacencia
         * GIsomor -> Varialbe que llama a la clase para realizar el isomorfismo
         * TGrados, TGrados2 -> La primera almacena los grados totales de un grado no dirigido (externos de un grafo dirigido) y la segunda almacena los grados internos
         * caminos -> Almacena la matriz de caminos que se genera en floyd
         * ponderado -> Se almacenan los costos de las aristas 
         * bosque -> Lista de listas vértices en donde se guarda los recorrido en profundidad de un grafo
         * visitados2, aux, aux2 -> Auxiliar en donde se guarda el recorrido en profundidad, en aux y aux2 se guarda el recorrido completo
         * 
         * **/

        public List<CVertice> ListaVer; 
        public int auxi; 
        private int totalArist; 
        private bool dirigido;
        public List<string> ListGradosAd;
        public List<string> ListVAdy;
        public int ciclico = -1;

        private MatrizAdy m;
        private MatrizIncid mi;
        private ListaAd l;
        private Isomorfismo GIsomor;
        public int[] TGrados, TGrados2;
        public int[,] caminos;

        private int[,] ponderados;

        public List<List<CVertice>> bosque = new List<List<CVertice>>();
        public List<CVertice> visitados2 = new List<CVertice>();
        public List<CVertice> aux = new List<CVertice>();
        List<CVertice> aux2 = new List<CVertice>();

        /**
         * Constructor de la clase grafo
         * **/
        public Grafo()
        {
            auxi = -1;
            ListaVer = new List<CVertice>();

        }

        public bool Dir
        {
            get => dirigido;
            set => dirigido = value;
        }

        public int setAris
        {
            get => totalArist;
            set => totalArist = value;
        }

        public int[] setGrados
        {
            set => TGrados = value;
            get => TGrados;
        }

        public int[] setGradosInt
        {
            set => TGrados2 = value;
            get => TGrados2;
        }

       
        /**
         * Busqueda en profundidad recursivo
         * Recibe un vértice 
         * **/
        public void dfs(CVertice v)
        {
            v.VerVisitado = true;
            if (!visitados2.Contains(v))
            {
                visitados2.Add(v);
                aux.Add(v);
                
            }
            int s = Int32.Parse(v.name); //convierte el nombre en entero
            string ady = ListVAdy[s - 1];
            char[] ArrAdy = ady.ToCharArray();
            for (int i = 0; i < ArrAdy.Length; i++)
            {
                int pos = Int32.Parse(ArrAdy[i].ToString());
                CVertice ver = ListaVer[pos - 1];
                ver.Niveles = 2;
                if (ver.VerVisitado == false)
                {
                    ciclico = 0;
                    ver.VerVisitado = true;
                    marca(v, ver);
                    if (!visitados2.Contains(ver))
                    {
                        visitados2.Add(ver);
                        aux.Add(ver);
                    }
                    dfs(ver);
                }
                else
                    ciclico = -1;
            }
        }

        /**
         * Método que cuenta las aristas totales que hay en el grafo
         * Regresa el total de aristas dividido entre dos
         * **/
        public int AristatasTotales()
        {
            foreach (CVertice v in ListaVer)
                foreach (Arista a in v.ListAristas)
                    totalArist++;
            return totalArist/2;
        }
        
        /*public void Niveles()
        {
            for (int i = 0; i < ListaVer.Count; i++)
            {
                ListaVer[2].Niveles = 3;
                ListaVer[3].Niveles = 3;
                CVertice ver = ListaVer[i];
                Console.WriteLine("Vértice " + ver.name + " con nivel: " + ver.Niveles);
            }
        }*/

        /**
         * Método que asigna el tipo de arista 
         * Reibe por parámetro el vértice origen y el vértice destino
         * **/
        public void marca(CVertice origen, CVertice destino)
        {
            for(int i = 0; i < origen.ListAristas.Count; i++)
            {
                Arista a = origen.ListAristas[i];
                if (a.destino == destino)
                {
                    a.Tipo = 1;
                }
                
            }
        }

        /**
         * Método que agrega el recorrido en profundidad a la lista bosque
         * **/
        public void AgregaBosque()
        {
            bosque.Add(visitados2);
            visitados2 = new List<CVertice>();
        }
        
        /**
         * Imprime los nombres de los vértices que se encuentran en el recorrido en profundidad
         * **/
        public void imprimedfs()
        {
            for(int i = 0; i < bosque.Count; i ++)
            {
                //Console.WriteLine(visitados2[i].name);
                Console.WriteLine("Elementos del recorrido " + i);
                foreach(CVertice v in bosque[i])
                    Console.WriteLine(v.name);
            }
            for(int i = 0; i < aux.Count; i++)
            {
                Console.WriteLine(aux[i].name);
            }
        }

        /**
         * Método que asigna la arista de cruce
         * **/
        public void Bosque()
        {
            for(int i = 0; i < bosque.Count; i++)
            {
                aux2 = bosque[i];
                for(int j = 0; j < aux2.Count; j++)
                {
                    for(int k = 0; k < aux2[j].ListAristas.Count; k++)
                    {
                        int x = j;// + 1;
                        Arista a = aux2[j].ListAristas[k];
                        if(!bosque[i].Contains(a.destino))
                            a.Tipo = 3; //conexión al otro árbol
                    }
                }
            }
        }

        /**
         * Devuelve los grados totales del nodo / externos del nodo
         * **/
        public int[] MtzAd(int i, RichTextBox t, bool dir)
        {
            m = new MatrizAdy(i);
            TGrados = new int[i];
            m.CreaMatriz(ListaVer, t, dir);
            TGrados = m.GetList.ToArray();
            return TGrados;
        }

        /**
         * Guarda los grados de los vértices
         * **/
        public void guarda()
        {
            for (int i = 0; i < TGrados.Length; i++)
            {
                ListaVer[i].GetGrado = TGrados[i];
            }
        }

        /**
         * Devuelve los grados internos
         * **/
        public int[] mtzad(int i, RichTextBox t, bool dir)
        {
            m = new MatrizAdy(i);
            TGrados2 = new int[i];
            m.CreaMatriz(ListaVer, t, dir);
            TGrados2 = m.GetList2.ToArray();
            return TGrados2;

        }


        /**
         * Método que hace la lista de adyacencia
         * **/
        public void LstAd(RichTextBox t, bool dir)
        {
            l = new ListaAd();
            l.CreaLista(ListaVer, t, dir);
            ListGradosAd = l.GradosAd();
            ListVAdy = l.vad;
        }

        /**
         * Método que crea la matriz de ponderados
         * **/
        public void MatrizAdyP(int i, RichTextBox t)
        {
            m = new MatrizAdy(i);
            m.CreaMatrizPon(ListaVer, t);
            ponderados = m.matrizPond;
            caminos = m.MatrizC;
        }


        /**
         * Método que hace el algoritmo de floyd y crea la matriz de caminos
         * **/
        public void Floyd(RichTextBox t)
        {
            t.Visible = true;
            int[,] floyd = ponderados;
            for (int k = 0; k < ListaVer.Count; k++)
                for (int i = 0; i < ListaVer.Count; i++)
                    for (int j = 0; j < ListaVer.Count; j++)
                    {
                        if (ponderados[i, k] != int.MaxValue && ponderados[k, j] != int.MaxValue)
                        {
                            int suma = ponderados[i, k] + ponderados[k, j];
                            if (suma < ponderados[i, j])
                            {
                                floyd[i, j] = suma;
                                caminos[i, j] = k+1;
                            }
                        }
                    }

            for (int i = 0; i < ListaVer.Count; i++)
            {
                t.Text += ListaVer[i].name + " |   ";
                for (int j = 0; j < ListaVer.Count; j++)
                {
                    if (floyd[i, j] == int.MaxValue)
                    {
                        //Console.Write(string.Format("{0,4:D}", "-"));
                        t.Text += string.Format("{0,4:D}", "-");
                    }
                    else
                    {
                        //Console.Write(string.Format("{0,4:D}", floyd[i, j]));
                        t.Text += string.Format("{0,4:D}", floyd[i, j]);
                    }
                }
                t.Text += Environment.NewLine;
                //Console.WriteLine();
            }
        }


        /**
         * Método que imprime en el RichTextBox la matriz de caminos que se genero del algoritmo de floyd
         * **/
        public void CaminosFloyd(RichTextBox t)
        {
            for (int i = 0; i < ListaVer.Count; i++)
            {
                t.Text += ListaVer[i].name + " |   ";
                for (int j = 0; j < ListaVer.Count; j++)
                {
                    if (i ==j)
                        t.Text += string.Format("{0,4:D}", "0");
                    else
                        t.Text += string.Format("{0,4:D}", caminos[i, j]);
                }
                t.Text += Environment.NewLine;
            }
        }

        /**
         * Método que hace el algoritmo de kruskal
         * **/
        public List<Arista> kruskal()
        {
            List<List<CVertice>> comp = CreaComp(ListaVer); //lista de componentes del grafo
            List<Arista> AristQ = new List<Arista>(); //lista de aristas del grafo
            List<Arista> ArisOrd; //lista de aristas ordenadas por su peso
            List<Arista> List = new List<Arista>(); //lista para crear el arbol de expansión mínima

            int i = -1, j = -1;
            CVertice origen, destino;
            Arista menorcost;

            foreach(CVertice v in ListaVer)
            {
                foreach (Arista a in v.ListAristas)
                    AristQ.Add(a);
            }
            ArisOrd = AristQ.OrderBy(o => o.peso).ToList();
            while (List.Count < ListaVer.Count - 1)
            {
                origen = null;
                menorcost = ArisOrd[0];
                ArisOrd.Remove(menorcost);
                foreach (CVertice v in ListaVer)
                    foreach (Arista a in v.ListAristas)
                    {
                        if (a == menorcost)
                            origen = v;
                    }
                destino = menorcost.destino;
                i = BuscaK(origen, comp);
                j = BuscaK(destino, comp);
                if( i != j)
                {
                    List.Add(menorcost);
                    Unir(i, j, comp);
                }
            }

            Console.WriteLine("Lista de aristas de menor peso");
            for (int k = 0; k < List.Count; k++)
                Console.WriteLine("arista: " + List[k].NombreAr + " peso: " + List[k].peso);
            return List;
        } 

        /**
         * Busca el vértice que se pasa por parámetro en la lista de componentes que también se pasa por parámetros
         * **/
        public int BuscaK(CVertice v, List<List<CVertice>> c)
        {
            int index = 0;
            for (int i = 0; i < c.Count; i++)
                if (c[i].Contains(v))
                    index = i;
            return index;
        }

        /**
         * Une las componentes
         * Se pasa por parámetros los indices y la lista de componentes
         * **/
        public void Unir(int i, int j, List<List<CVertice>> c)
        {
            foreach (CVertice v in c[j])
                c[i].Add(v);
            c[j].Clear();
        }

        /**
         * Se crea una componente con una lista de  vértices
         * **/
        public List<List<CVertice>> CreaComp(List<CVertice> vertex)
        {
            List<List<CVertice>> lista = new List<List<CVertice>>();
            for(int i = 0; i < vertex.Count; i++)
            {
                lista.Add(new List<CVertice>());
                lista[i].Add(vertex[i]);
            }
            return lista;
        }

        /**
         * Método que crea la matriz de incidencia
         * Se para por parametros el total de vértices y el total de aristas
         * **/
        public void MtzIncd(int n, int TAristas, RichTextBox t)
        {
            mi = new MatrizIncid(n,TAristas);
            mi.CreaMatrizI(ListaVer, t);
            
        }

        /**
         * Método que realiza el isomorfimos
         * Se pasa por parámetros los dos grafos a comparar
         * **/
        public bool Iso(Grafo g1, Grafo g2)
        {
            GIsomor = new Isomorfismo(g1,g2);
            return GIsomor.SonIsomosfos();
        }

        /**
         * Inserta un nuevo vertice a la lista
         * **/
        public void InsertaVertice(string n, int x, int y)
        {
            ListaVer.Add(new CVertice(n, x, y));
        }

        /**
         * Método que busca la arista en donde se va a insertar el vértice nuevo 
         * Se para por parametros las coordenads en x, y del nuevo vértice y el nombre de este vértice
         * **/
        public bool InsertaVCut(int x, int y, string v) //x, y son las coordenadas del click
        {
            bool encontro = false;
            for (int i = 0; i < ListaVer.Count; i++)
            {
                CVertice ver = ListaVer[i];
               for(int j  = 0; j < ver.ListAristas.Count; j++)
                {
                    Arista a = ver.ListAristas[j];
                    float m = (float)(a.desty - a.oriy) / (float)(a.destx - a.orix);
                    float ecy = (m * (x - a.orix) + a.oriy);
                    int xm = (a.orix + a.destx) / 2;
                    int ym = (a.oriy + a.desty) / 2;
                    //if(x > xm - 20 && x < xm + 20 && y > ym - 20 && y < ym + 20)
                    if ((int)ecy < y + 5 && (int)ecy > y - 5)
                    {
                        CVertice aux = new CVertice(v, x, y);
                        ListaVer.Add(aux);
                        Console.WriteLine(ListaVer.Count);
                        int origen = Buscar(a.orix, a.oriy); //se pasan las coords del vértice destino
                        int destino = ListaVer.Count - 1; //el destino siempre sera el último de la lista 
                        int total = setAris + 1;
                        ListaVer[origen].InsertaArista(a.orix, a.orix, aux.x, aux.y, ListaVer.ElementAt(destino), false, false, total.ToString());
                        ListaVer[destino].InsertaArista(aux.x, aux.y, a.destx, a.desty, a.destino, false, false, (total + 1).ToString());
                        ver.ListAristas.Remove(a);
                        setAris += 2;
                        return true;
                     }
                     else
                       Console.WriteLine("No se encontró la arista");
                }
            }
            //return false;
            return encontro;
        }

        /**
         * Busca Vértice y guarda el indice en una variable auxiliar
         * **/
        public int Buscar(int dx, int dy)
        {
            auxi = -1;
            for (int i = 0; i < ListaVer.Count; i++)
            {
                if ((ListaVer[i].x < dx && ListaVer[i].x + 40 > dx ) && (ListaVer[i].y < dy && ListaVer[i].y + 40 > dy))
                {
                    auxi = i;
                    return auxi;
                } 
            }
            return auxi;
        }

        /**
         * Elimina el vertice junto con las aristas que tiene
         * **/
        public void QuitaVertice(int dx, int dy)
        {
            int aux = Buscar(dx, dy);
            string nombre1 = ListaVer.ElementAt(aux).name;
            for (int i = 0; i < ListaVer.Count; i++)
            {
                for(int j = 0; j < ListaVer[i].ListAristas.Count; j++)
                {
                    string nombre = ListaVer[i].ListAristas[j].destino.name;
                    if (nombre == nombre1)
                        ListaVer[i].ListAristas.RemoveAt(j);
                }
            }
            ListaVer.ElementAt(aux).ListAristas.Clear();
            ListaVer.RemoveAt(aux);
        }
    }
}
