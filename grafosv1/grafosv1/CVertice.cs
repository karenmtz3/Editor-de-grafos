﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using Microsoft.VisualBasic;

namespace grafosv1
{
    [Serializable()]
    public class CVertice
    {
        public string name; //nombre del nodo
        public List<Arista> ListAristas; //lista de las aristas
        public int x, y; //cordenadas de vertice
        //Graphics graphics;
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
            {
                int xm = x + 20;
                int ym = y + 20;
                ListAristas[i].CambiaCoord(xm, ym);
               // ListAristas[i].Coordenadas();
            }
        }

        //inserta una arista a la lista de aristas
        public void InsertaArista(int xd, int yd, int xo, int yo, CVertice des, bool p)
        {
            int r = 8, x1, y1, x2, y2;
            x1 = y1 = x2 = y2 = 0;
            //primer cuadrante
            if (xd > xo && yo > yd)
            {
                x1 = xo + r;
                y1 = yo;
                x2 = xd - r;
                y2 = yd;
            }
            //segundo cuadrante
            else if (xd < xo && yo > yd)
            {
                x1 = xo - r;
                y1 = yo;
                x2 = xd + r;
                y2 = yd;
            }
            //tercer cuadrante
            else if (xd < xo && yo < yd)
            {
                x1 = xo - r;
                y1 = yo;
                x2 = xd + r;
                y2 = yd;
            }
            //cuarto cuadrante
            else if (xd > xo && yo < yd)
            {
                x1 = xo + r;
                y1 = yo;
                x2 = xd - r;
                y2 = yd;
            }
            if (p == true)
            {
                string pes = Interaction.InputBox("Ingrese el peso", "Ponderación", "0", 100, 50);
                int pe = Convert.ToInt32(pes);
                ListAristas.Add(new Arista(x2, y2, x1, y1, des, pe));

            }
            else
                ListAristas.Add(new Arista(x2, y2, x1, y1, des));
            
        }

        //regresa la lista de aristas
        public List<Arista> Regresa()
        {
            return ListAristas;
        }

        public void EliminaArista(int x, int y)
        {
            //buscar arista 
            for (int i = 0; i < ListAristas.Count; i++)
            {
                Arista ar = ListAristas[i];
                Console.WriteLine("x = " + x + ", y = " + y);
                for (float t = 0; t <= 1; t += 0.01f)
                {
                    float m = (1 - t);
                    float xb = (int)((ar.p2.X * Math.Pow(m, 3)) + (3 * ar.c2.X * Math.Pow(m, 2) * t) + (2 * ar.c1.X * Math.Pow(t, 2) * m) + ar.p1.X * Math.Pow(t, 3));
                    float yb = (int)((ar.p2.Y * Math.Pow(m, 3)) + (3 * ar.c2.Y * Math.Pow(m, 2) * t) + (2 * ar.c1.Y * Math.Pow(t, 2) * m) + ar.p1.Y * Math.Pow(t, 3));
                    Console.WriteLine("xb = " + xb + ", yb = " + yb);
                    if (xb + 4 > x && xb - 4 < x && yb + 4 > y && yb - 4 < y)
                    {
                        Console.WriteLine("Arista encontrada");
                        ListAristas.Remove(ar);


                    }
                }

            }
        }

        //elimina la arista de la lista de aristas 
        /*public void EliminaArista(int x, int y)
        {
            //buscar arista 
            for (int i = 0; i < ListAristas.Count; i++)
            {
                Arista ar = ListAristas[i];
               
                int x1 = (ar.destx - ar.orix) / 10;
                int y1 = (ar.desty - ar.oriy) / 10;
                Console.WriteLine("x = " + x + ", y = " + y);
                for (float t = 0; t <= 1; t += 0.001f)
                {
                    float m = (1 - t);
                    float xb = (float)((ar.orix * Math.Pow(m, 3)) + (3 * (ar.orix+x1) * Math.Pow(m, 2) * t) + (2 * (ar.destx+x1) * Math.Pow(t, 2) * m) + (ar.destx * Math.Pow(t, 3)));
                    float yb = (float)((ar.oriy * Math.Pow(m, 3)) + (3 * (ar.oriy+y1) * Math.Pow(m, 2) * t) + (2 * (ar.desty+y1) * Math.Pow(t, 2) * m) + (ar.desty * Math.Pow(t, 3)));
                    Console.WriteLine("xb = " + xb + ", yb = " + yb);
                    if ((int)xb + 4 > x && (int)xb - 4 < x && (int)yb + 4 > y && (int)yb - 4 < y)
                    {
                        Console.WriteLine("Arista encontrada");
                        ListAristas.Remove(ar);

                    }

                }
            }
        }*/
    }
}
       

            /*for(int i = 0; i < ListAristas.Count; i++)
            {
                Arista ar = ListAristas[i];
                float m = (float)(ar.desty - ar.oriy) / (float)(ar.destx - ar.orix); //calcula pendiente
                float ecy = (m * (x - ar.orix) + ar.oriy); // calcula la ecuacion de la recta
                if((int)ecy < y+3 && (int)ecy > y - 3)
                {
                    ListAristas.Remove(ar);
                }*/
