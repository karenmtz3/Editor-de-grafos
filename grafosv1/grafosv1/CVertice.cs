﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace grafosv1
{
    public class CVertice
    {
        public string name; //nombre del nodo
        public List<Arista> ListAristas; //lista de las aristas
        public int x, y; //cordenadas de vertice
        
        public CVertice(string nombre, int dx, int dy)
        {
            name = nombre;
            x = dx;
            y = dy;
            ListAristas = new List<Arista>();
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

       
    }
}
