﻿using System;
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
        public List<CVertice> ListaVer; //lista de los vertices
        public int auxi; //auxiliar que guarda la posición del nodo encontrado
        private int totalArist; //variable que almacena el total de aristas del grafo
        private bool dirigido; //si el grafo es dirigido o no
        public List<string> ListGradosAd; //almacena los grados adyacentes
        public List<string> ListVAdy; //almacena los nombres de los vértices adyacentes
       
        private MatrizAdy m;
        private MatrizIncid mi;
        private ListaAd l;
        private Isomorfismo GIsomor;
        public int[] TGrados, TGrados2;
        public int[,] caminos;

        private int[,] ponderados;

        public List<int> TotalAris = new List<int>();


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

        public List<CVertice> visitados2 = new List<CVertice>();
        List<CVertice> aux2 = new List<CVertice>();

        public List<List<CVertice>> bosque = new List<List<CVertice>>();
        public List<CVertice> aux = new List<CVertice>();
        public int ciclico = -1;

        //busqueda en profundidad
        public void dfs(CVertice v)
        {
           // List<CVertice> visitados2 = new List<CVertice>();
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

        public int AristatasTotales()
        {
            foreach (CVertice v in ListaVer)
                foreach (Arista a in v.ListAristas)
                    totalArist++;
            return totalArist/2;
        }

        public void Niveles()
        {
            for (int i = 0; i < ListaVer.Count; i++)
            {
                ListaVer[2].Niveles = 3;
                ListaVer[3].Niveles = 3;
                CVertice ver = ListaVer[i];
                Console.WriteLine("Vértice " + ver.name + " con nivel: " + ver.Niveles);
            }
        }

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

      public void AgregaBosque()
        {
            bosque.Add(visitados2);
            visitados2 = new List<CVertice>();
        }
        
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

        public void Bosque2()
        {
            List<CVertice> auxv = new List<CVertice>();

            for (int i = 0; i < bosque.Count; i++)
            {
                aux2 = bosque[i];
                for (int j = 0; j < bosque[i].Count; j++)
                {
                    //int auxv = aux2[j].ListAristas.Count;
                    for (int k = 0; k < aux2[j].ListAristas.Count; k++)
                    {

                        Arista a = aux2[j].ListAristas[k];
                        if(aux2.Contains(a.destino))
                        {
                            if (a.destino.VerVisitado == false)
                            {// bosque[i].RemoveAt(0);
                                a.Tipo = 1;
                                //aux2.Remove(a.destino);
                            }
                            if (a.destino != aux2[0])
                                a.Tipo = 1; //pinta las del recorrido en profundidad
                            //auxv.Add(a.destino);
                            //int vaca = aux2[j].ListAristas.Count;
                        }
                    }
                }
            }
        }

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
                            a.Tipo = 2; //conexión al otro árbol
                    }
                }
            }
        }

        //devuelve los grados totales del nodo / externos del nodo
        public int[] MtzAd(int i, RichTextBox t, bool dir)
        {
            m = new MatrizAdy(i);
            TGrados = new int[i];
            m.CreaMatriz(ListaVer, t, dir);
            TGrados = m.GetList.ToArray();
            return TGrados;
        }

        public void guarda()
        {
            for (int i = 0; i < TGrados.Length; i++)
            {
                ListaVer[i].GetGrado = TGrados[i];
                //Console.WriteLine("vértice = " + ListaVer[i].name + " grado = " + ListaVer[i].GetGrado);
            }
        }

        //devuelve los grados internos 
        public int[] mtzad(int i, RichTextBox t, bool dir)
        {
            m = new MatrizAdy(i);
            TGrados2 = new int[i];
            m.CreaMatriz(ListaVer, t, dir);
            TGrados2 = m.GetList2.ToArray();
            return TGrados2;

        }

        public void LstAd(RichTextBox t, bool dir)
        {
            l = new ListaAd();
            l.CreaLista(ListaVer, t, dir);
            ListGradosAd = l.GradosAd();
            ListVAdy = l.vad;
        }

        public void MatrizAdyP(int i, RichTextBox t)
        {
            m = new MatrizAdy(i);
            m.CreaMatrizPon(ListaVer, t);
            ponderados = m.matrizPond;
            caminos = m.MatrizC;
        }

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
            /*foreach (Arista a in ArisOrd)
                Console.WriteLine("Arista: " + a.NombreAr + " peso: " + a.peso);*/
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

        public int BuscaK(CVertice v, List<List<CVertice>> c)
        {
            int index = 0;
            for (int i = 0; i < c.Count; i++)
                if (c[i].Contains(v))
                    index = i;
            return index;
        }

        public void Unir(int i, int j, List<List<CVertice>> c)
        {
            foreach (CVertice v in c[j])
                c[i].Add(v);
            c[j].Clear();
        }

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

        public void MtzIncd(int n, int TAristas, RichTextBox t)
        {
            mi = new MatrizIncid(n,TAristas);
            mi.CreaMatrizI(ListaVer, t);
            
        }

        public bool Iso(Grafo g1, Grafo g2)
        {
            GIsomor = new Isomorfismo(g1,g2);
            return GIsomor.SonIsomosfos();
        }

        //inserta un nuevo vertice a la lista
        public void InsertaVertice(string n, int x, int y)
        {
            ListaVer.Add(new CVertice(n, x, y));
        }

        //inserta vértice corte en el grafo k3,3 o k5
       /* public bool InsertaVCut(CVertice inicio, CVertice destino, int posi, int posd)
        {
            bool encontro = false;
            int name = setAris+1;
            for(int i = 0; i < inicio.ListAristas.Count; i++)
            {
                Arista arista = inicio.ListAristas[i];
                int xm = (arista.destino.x + arista.orix) / 2;
                int ym = (arista.destino.y + arista.oriy) / 2;
                if(arista.destino == destino)
                {
                    ListaVer.Add(new CVertice((name + 1).ToString(), xm, ym));
                    ListaVer[posi].InsertaArista( arista.orix, arista.oriy, xm+50, ym, ListaVer.ElementAt(name-1), false, false,name.ToString());
                    ListaVer[posd].InsertaArista(xm + 50, ym, arista.destx, arista.desty, arista.destino, false, false, (name+1).ToString());
                    inicio.ListAristas.Remove(arista);
                    setAris += 2;
                    encontro = true;
                    break;

                }
            }
            return encontro;
        }*/

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
                     if ((int)ecy <= y + 6 && (int)ecy >= y - 6)
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

        //busca nodo y guarda el indice en una variable auxiliar
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

        //elimina el vertice junto con las aristas que tiene
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
