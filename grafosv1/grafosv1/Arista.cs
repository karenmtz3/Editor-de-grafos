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
            int ax1 = orix-xo;
            int ay1 = oriy - yo;
            int ax2 = destx - xo;
            int ay2 = desty - yo;

            orix = xo;
            oriy = yo;
            //orix = xo;
            //oriy = yo;
            //destx = xd;
            //desty = yd;
            destx = destino.x;
            desty = destino.y;
        }
    }
}
