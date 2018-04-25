using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grafosv1
{
    [Serializable()]
    public class MatrizAdy
    {
        private int n;
        private int[,] matriz;
        private int cont = 0, cont2 = 0;
        private List<int> arr, arr2;

        public MatrizAdy(int i)
        {
            n = i;
            matriz = new int[n,n];
            arr = new List<int>();
            arr2 = new List<int>();
        }

        public void CreaMatriz(List<CVertice> ver, RichTextBox t, bool dir)
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
                    matriz[ListVer.IndexOf(vo), ListVer.IndexOf(vd)] += 1; //dirigido
                    if(dir == false)
                        matriz[ListVer.IndexOf(vd), ListVer.IndexOf(vo)] += 1; //no dirigido
                    if(vo == vd)
                        matriz[ListVer.IndexOf(vo), ListVer.IndexOf(vd)] -= 1;
                    
                }
            }

            //Imprime la matriz
            for (int i = 0; i < ver.Count; i++)
            {
                t.Text += ver[i].name + " |   ";
                //Console.WriteLine(matriz[i,0]);
                for (int j = 0; j < n; j++)
                {
                    Console.Write(string.Format("{0,4:D}", matriz[i, j]));
                    t.Text += string.Format("{0,4:D}", matriz[i, j].ToString());
                    if (dir == true) //grafo dirigido
                    {
                        if (matriz[i, j] >= 1)
                            cont += matriz[i, j];
                        if (matriz[j, i] >= 1)
                            cont2 += matriz[j, i];
                    }
                    else if (dir == false) //grafo no dirigido
                        if (matriz[i, j] >= 1)
                            cont += matriz[i, j];

                }
                Console.WriteLine(" interno = " + cont2 + " externo = " + cont);
                arr.Add(cont);
                arr2.Add(cont2);
                cont = cont2 = 0;
                t.Text += Environment.NewLine;
                Console.WriteLine();
            }
            //return matriz;

        }

        //grados de los nodos 
        public List<int> GetList
        {
            get { return arr; }
        }

        public List<int> GetList2
        {
            get { return arr2; }
        }
    }
}
