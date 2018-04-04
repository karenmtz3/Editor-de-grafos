using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grafosv1
{
    [Serializable()]
    public class MatrizAdy
    {
        public int n, auxi;
        public int[,] matriz;

        public MatrizAdy(int i)
        {
            n = i;
            matriz = new int[n,n];
        }

        public void CreaMatriz(List<CVertice> ver)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matriz[i, j] = 0;
                    Console.Write(string.Format("{0,4:D}",matriz[i,j]));
                }
               Console.WriteLine();
            } 
        }
        
    }
}
