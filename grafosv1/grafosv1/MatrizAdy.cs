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
        private int n;
        private int[,] matriz;

        public MatrizAdy(int i)
        {
            n = i;
            matriz = new int[n,n];
        }

        public void CreaMatriz(List<CVertice> ver)
        {
            List<string> ListVer = new List<string>();
            for (int i = 0; i < ver.Count; i++)
                ListVer.Add(ver[i].name);
            ListVer.Sort(); //ordena la lista

            //Inicializa la matriz en 0
            for (int i = 0; i < n; i++)
                    for (int j = 0; j < n; j++)
                        matriz[i, j] = 0;

            //Suma 1 a la matriz en donde hay relación
            for (int i = 0; i < ver.Count; i++)
            {
                string vo = ver[i].name;
                foreach (Arista a in ver[i].ListAristas)
                {
                    string vd = a.destino.name;
                    matriz[ListVer.IndexOf(vo), ListVer.IndexOf(vd)] += 1;
                    matriz[ListVer.IndexOf(vd), ListVer.IndexOf(vo)] += 1;
                    if(vo == vd)
                        matriz[ListVer.IndexOf(vo), ListVer.IndexOf(vd)] -= 1;

                }
            }

            //Imprime la matriz
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                    Console.Write(string.Format("{0,4:D}", matriz[i, j]));
                Console.WriteLine();
            }

        }
        
    }
}
