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
        public int etiqueta;
        public CVertice destino;
        public Point p1, c1, p2, c2;

        //constructor de la clase Arista
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
            int x1 = (destx - orix) / 10;
            int y1 = (desty - orix) / 10;
            //dibuja orejas
            if (orix == destx && oriy == desty)
            {
                int radio = 40 / 2;
                p1 = new Point(orix, oriy + radio + 15);
                c1 = new Point(orix - (int)(radio * 2.5), oriy + (radio / 2));
                c2 = new Point(orix - (2 * radio), oriy);
                p2 = new Point(orix, oriy - radio + 12);
            }

            //dibuja curvas
            else
            {
                p1 = new Point(orix, oriy);
                c1 = new Point(orix + x1, oriy + y1);
                c2 = new Point(destx + x1, desty + y1);
                p2 = new Point(destx, desty);
            }
            return new Point[] { p2, c2, p1, c1 };
        }


        //cambia las coordenadas del origen de la arista
        public void CambiaCoord(int xo, int yo) //cords de origen de la arista
        {
            int r = 10;
            int x1 = 0, y1 = 0;
            destx = destino.x + 2*r;
            desty = destino.y + 2*r;
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
