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
        public List<CVertice> ListaVer; //lista de los vertices
        public int auxi; //auxiliar que guarda la posición del nodo encontrado
        private MatrizAdy m;
        private ListaAd l;
        public int[] TGrados, TGrados2;

        public Grafo()
        {
            auxi = -1;
            ListaVer = new List<CVertice>();
            
        }

        public int[] MtzAd(int i, RichTextBox t, bool dir)
        {
            m = new MatrizAdy(i);
            TGrados = new int[i];
            //string s = "Matriz de Adyacencia";
            /*v = new Vista(s);
            v.muestra(ListaVer);
            v.Visible = true;*/
            m.CreaMatriz(ListaVer, t, dir);
            TGrados = m.GetList.ToArray();
            return TGrados; 
        }

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
            /*string s = "Lista de Adyacencia";
            v = new Vista(s);
            v.MuestraLis(ListaVer);
            v.Visible = true;*/
            l.CreaLista(ListaVer, t, dir);
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
