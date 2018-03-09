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

        //constructor de la clase Arista
        public Arista(int xd, int yd, int xo, int yo, CVertice dest)
        {
            destino = dest;
            orix = xo;
            oriy = yo;
            destx = xd;
            desty = yd;
        }

        //regresa el vertice destino
        public CVertice RegresaDest //vertice
        {
            get { return destino; }
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

        }
    }
}
