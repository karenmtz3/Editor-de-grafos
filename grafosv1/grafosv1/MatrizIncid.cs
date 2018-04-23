using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grafosv1
{
    [Serializable()]
    public class MatrizIncid
    {
        private int n, m;
        private int[,] matrizI;
        List<int> total;

        public MatrizIncid(int i, List<int> TArista)
        {
            n = i;
            m = TArista.Count;
            total = TArista;
            matrizI = new int[n,m];
        }

        public void CreaMatrizI(List<CVertice> vertice, RichTextBox t)
        {
            List<string> listv = new List<string>();
            List<string> lista = new List<string>();
            for (int i = 0; i < vertice.Count; i++)
                listv.Add(vertice[i].name);
            listv.Sort(); //ordena la lista

            //inicializa la matriz en 0
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    matrizI[i, j] = 0;

            for(int i = 0; i < vertice.Count; i++)
            {
                string vo = vertice[i].name; //vertice origen
                
                foreach (Arista a in vertice[i].ListAristas)
                {
                    string vd = a.destino.name;
                    string nomar = a.NombreAr; //nombre arista
                    for(int j=0; j < total.Count; j++)
                    {
                        int n = Convert.ToInt32(nomar);
                        if (n == total[j])
                        {
                            Console.WriteLine("hay relacion entre vertice " + vo + " y arista " + nomar);
                            matrizI[listv.IndexOf(vo), n-1] += 1;
                            matrizI[listv.IndexOf(vd), n-1] += 1;
                        }

                    }
                    //string vd = a.destino.name; //vertice destino
                    //matrizI[listv.IndexOf(vo), listv.IndexOf(nomar)] += 1;
                    //if(vo == vd)
                      //  matrizI[listv.IndexOf(vo), listv.IndexOf(vd)] -= 1;
                }
            }



            //imprime en consola
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(string.Format("{0,4:D}", matrizI[i, j]));
                    t.Text += string.Format("{0,4:D}", matrizI[i, j].ToString());
                }
                Console.WriteLine();
            }
        }
    }
}
