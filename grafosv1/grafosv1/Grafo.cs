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
        private int totalArist;
        private bool dirigido;
        public List<string> ListGradosAd;
        public List<string> ListVAdy;

        private MatrizAdy m;
        private MatrizIncid mi;
        private ListaAd l;
        private Isomorfismo GIsomor;
        public int[] TGrados, TGrados2;
        private string VerRecorridos;

        public Grafo()
        {
            auxi = -1;
            ListaVer = new List<CVertice>();
            
        }
        
        public string Recorridos
        {
            get => VerRecorridos;
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

        public void bea(CVertice v)
        {
            List<string> visitados = new List<string>();
            List<string> cola = new List<string>();
            if (v.VerVisitado == false)
            {
                //int s = Int32.Parse(v.name); //´convierte el nombre en entero
                v.VerVisitado = true;
                visitados.Add(v.name);
                cola.Add(v.name);
                while (cola.Any())
                {
                    string actual = cola[0];
                    cola.Remove(actual);
                    int s = Int32.Parse(actual); //´convierte el nombre en entero
                    string ady = ListVAdy[s - 1];
                    char[] ArrAdy = ady.ToCharArray();
                    for (int i = 0; i < ArrAdy.Length; i++)
                    {
                        int pos = Int32.Parse(ArrAdy[i].ToString());
                        CVertice ver = ListaVer[pos - 1];
                        if (ver.VerVisitado == false)
                        {
                            ver.VerVisitado = true;
                            cola.Add(ver.name);
                            visitados.Add(ver.name);
                        }

                    }
                }

                for (int i = 0; i < visitados.Count; i++)
                    VerRecorridos += visitados[i];
                        // Console.Write(" " + visitados[i]);
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

        public void MtzIncd(int n, List<int> TAristas, RichTextBox t)
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
