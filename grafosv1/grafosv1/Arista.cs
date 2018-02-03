using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace grafosv1
{
    public class Arista
    {
        public int destx, desty, orix, oriy;
        public CVertice destino;

        public Arista(int xi, int yi, int xd, int yd, CVertice dest)
        {
            destino = dest;
            orix = xi;
            oriy = yi;
            destx = xd;
            desty = yd;
        }

        public CVertice RegresaDest //vertice
        {
            get { return destino; }
        }

        public void CambiaCoord(int x, int y) //cords de origen de la arista
        {
            destx = x;
            desty = y;
        }

        public void CambiaCoordDes(int x, int y) //cords de destino de la arista
        {
            /*destino.x = x;
            destino.y = y;*/
            orix = x;
            oriy = y;
        }
    }
}
