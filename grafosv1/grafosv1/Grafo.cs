﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grafosv1
{
    public class Grafo
    {
        public List<CVertice> ListaVer; //lista de los vertices
        public int auxi, auxd; //auxiliares que guardan la posición del nodo origen y nodo destino

        public Grafo()
        {
            auxi = auxd = -1;
            ListaVer = new List<CVertice>();
        }

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

        public void QuitaVertice(int dx, int dy)
        {
            int aux = Buscar(dx, dy);
            string nombre1 = ListaVer.ElementAt(aux).name;
            //Console.WriteLine(aux);
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

        public void EliminaArista()
        {

        }
    }
}