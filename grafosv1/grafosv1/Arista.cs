using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace grafosv1
{
    [Serializable()]
    public class Arista
    {
        /**
         * Clase Arista, contiene 
         * destx, desty, orix, oriy -> Son las coordenas de inicio y fin de la arista
         * peso -> Es la ponderación que puede tener la arista
         * destino -> Vértice destino de la arista
         * p1, c1, p2, c2 -> Son los puntos para dibujar una curva 
         * dirgido -> Marca si la arista es dirigida o no dirigida
         * recta -> Bandera para ver si las arstas son rectas o curvas
         * TipoArista -> Se utiliza para marcas los tipos de aristas que hay en el bosuqe abarcador
         * Arvisitada -> Bandera de si la arista fue visitada o no
         * **/

        public int destx, desty, orix, oriy;
        public int peso;
        public CVertice destino;
        public string NombreAr;
        public Point p1, c1, p2, c2;
        public bool dirigido;
        private bool recta;
        private int TipoArista;
        private bool Arvisitada;

        /**
        constructores de la clase Arista
        El primero recibe las coordenads finales e iniciales de la arista, el vértice destino, el peso y el nombre de la arista
        El segundo recibe las coordenads finales e iniciales de la arista, el vértice destino, y el nombre de la arista

        **/
        public Arista( int xd, int yd, int xo, int yo, CVertice dest, int p, string n)
        {
            NombreAr = n;
            destino = dest;
            orix = xo;
            oriy = yo;
            destx = xd;
            desty = yd;
            peso = p;
            TipoArista = 0;
            Arvisitada = false;
            puntos();
        }

        public Arista(int xd, int yd, int xo, int yo, CVertice dest, string n)
        {
            NombreAr = n;
            destino = dest;
            orix = xo;
            oriy = yo;
            destx = xd;
            desty = yd;
            TipoArista = 0;
            Arvisitada = false;
            puntos();
        }

        public CVertice RegresaDest
        {
            get { return destino; }
        }

        public bool Visitada
        {
            set => Arvisitada = value;
            get => Arvisitada;
        }

        public int Tipo
        {
            set => TipoArista = value;
            get => TipoArista;
        }

        public bool Recta
        {
            set => recta = value;
            get => recta;
        }
        
        /**
         * Método que calcula los puntos para dibujar la curva y regresa un arreglo de puntos
         * **/
        public Point[] puntos()
        {
            int x1 = (destx - orix)/20;
            int y1 = (desty - oriy)/10;
            //dibuja curvas
            p1 = new Point(orix, oriy);
            p2 = new Point(destx, desty);
            if (orix == destx)
            {
                c1 = new Point(orix + x1*10, oriy);
                c2 = new Point(destx + x1*10, desty);
            }
            else if(oriy == desty)
            {
                c1 = new Point(orix, oriy + y1*10);
                c2 = new Point(destx, desty + y1*10);
            }
            else
            {
                c1 = new Point(orix + x1, oriy + y1);
                c2 = new Point(destx + x1, desty + y1);
            }
            return new Point[] { p2, c2, p1, c1 };
        }
        
        /**
         * Cambia las coordenadas del origen de la arista
         * Recibe las coordenadas del vértice destino
         * **/
        public void CambiaCoord(int xo, int yo) 
        {
            int r = 10;
            int x1 = 0, y1 = 0;
            if (destino.x == xo && destino.y == yo)
            {
                destx = destino.x + 3 * r;
                desty = destino.y + 3 * r;
            }
            else
            {
                destx = destino.x + 2 * r;
                desty = destino.y + 2 * r;
            }
            //primer cuadrante
            if (destino.x > xo && destino.y < yo)
            {
                x1 = xo + r;
                y1 = yo + r;
                
            }
            //segundo cuadrante
            else if(destino.x < xo && destino.y < yo)
            {
                x1 = xo - r;
                y1 = yo - r;
            }
            //tercer cuadrante
            else if(destino.x < xo && destino.y > yo)
            {
                x1 = xo - r;
                y1 = yo - r;
            }
            //cuarto cuadrante
            else if(destino.x > xo && destino.y > yo)
            {
                x1 = xo + r;
                y1 = yo - r;
            }
            orix = x1;
            oriy = y1;
            puntos();
        }
    }
}
