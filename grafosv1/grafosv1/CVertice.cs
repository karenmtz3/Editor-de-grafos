﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace grafosv1
{
    [Serializable()]
    public class CVertice 
    {
        public string name; //nombre del nodo
        public List<Arista> ListAristas; //lista de las aristas
        public int x, y; //cordenadas de vertice
        
        //contructor de la clase CVertice
        public CVertice(string nombre, int dx, int dy)
        {
            name = nombre;
            x = dx;
            y = dy;
            ListAristas = new List<Arista>();
        }

        //recorre la lista de aristas de cada nodo y les cambia las coordenadas
        public void Cambia()
        {
            for (int i = 0; i < ListAristas.Count; i++)
                ListAristas[i].CambiaCoord(x, y);
        }

        //inserta una arista a la lista de aristas
        public void InsertaArista(int xd, int yd, int xo, int yo, CVertice des)
        {
            ListAristas.Add(new Arista(xd, yd, xo, yo,des));
        }

        //regresa la lista de aristas
        public List<Arista> Regresa()
        {
            return ListAristas;
        }

        //elimina la arista de la lista de aristas 
        public void EliminaArista(int x, int y)
        {
            //buscar arista 
            for(int i = 0; i < ListAristas.Count; i++)
            {
                Arista ar = ListAristas[i];
                float m = (float)(ar.desty - ar.oriy) / (float)(ar.destx - ar.orix); //calcula pendiente
                float ecy = (m * (x - ar.orix) + ar.oriy); // calcula la ecuacion de la recta
                if((int)ecy < y+3 && (int)ecy > y - 3)
                {
                    ListAristas.Remove(ar);
                }
            }

        }

    }
}
