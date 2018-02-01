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

        public CVertice RegresaDest
        {
            get { return destino; }
        }
    }
}
