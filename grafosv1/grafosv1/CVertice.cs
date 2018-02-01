using System;
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

        public void InsertaArista(int x1, int y1, int x2, int y2, CVertice des)
        {
            ListAristas.Add(new Arista(x1,y1,x2,y2,des));
        }

        public List<Arista> Regresa()
        {
            return ListAristas;
        }

       
    }
}
