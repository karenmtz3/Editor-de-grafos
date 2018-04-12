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
        public int destx, desty, orix, oriy;
        public int peso;
        public CVertice destino, origen;
        public Point p1, c1, p2, c2;

        //constructor de la clase Arista
        public Arista(int xd, int yd, int xo, int yo, CVertice dest, int p)
        {
            destino = dest;
            orix = xo;
            oriy = yo;
            destx = xd;
            desty = yd;
            peso = p;
            puntos();
        }

        public Arista(int xd, int yd, int xo, int yo, CVertice dest)
        {
            destino = dest;
            orix = xo;
            oriy = yo;
            destx = xd;
            desty = yd;
            puntos();
        }

        //regresa el vertice destino
        public CVertice RegresaDest //vertice
        {
            get { return destino; }
        }
        
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
        
        //cambia las coordenadas del origen de la arista
        public void CambiaCoord(int xo, int yo) //cords de origen de la arista
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
                /*xo += r;
                yo += r;*/
                
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
                // xo -= r;
                //yo += r / 2;
            }
            //cuarto cuadrante
            else if(destino.x > xo && destino.y > yo)
            {
                x1 = xo + r;
                y1 = yo - r;
                // xo += r;
                //yo += r / 2;
            }
            orix = x1;
            oriy = y1;
            puntos();
        }
    }
}
