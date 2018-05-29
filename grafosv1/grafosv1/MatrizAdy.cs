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
        /**
         * Clase de matriz de adyacencia
         * n -> Tamaño de la matriz
         * matriz -> matriz de adyacencia
         * matrizP -> matriz de costos, se utiliza para el algoritmo de floyd
         * caminos -> matriz de caminos, se utiliza para el algoritmo de floyd e impresión de caminos
         * cont, cont2 -> El primero cuenta las aristas origen, el segundo cuenta las aristas origen
         * arr, arr2 -> Se almacenan los contadores anteriores
         * max -> valor maximo, se utiliza para el algoritmo de floyd
         * **/
        private int n;
        private int[,] matriz, matrizP, caminos;
        private int cont = 0, cont2 = 0;
        private List<int> arr, arr2;
        private int max = int.MaxValue;

        /**
         * Contructor de matriz de adyacencia
         * Se pasa por parámetros el tañano de la matriz
         * **/
        public MatrizAdy(int i)
        {
            n = i;
            matriz = new int[n,n];
            matrizP = new int[n,n];
            caminos = new int[n, n];
            arr = new List<int>();
            arr2 = new List<int>();
        }


        /**
         * Método que inicializa la matriz de caminos en si mismo y la matriz de ponderados en el valor maximo
         * Después en la matriz de pesos se guardarán los pesos de cada una de las aristas
         * Se pasa por parámetros una lista de vértices
         * **/
        public void CreaMatrizPon(List<CVertice> ver, RichTextBox t)
        {
            List<string> ListVer = new List<string>();
            for (int i = 0; i < ver.Count; i++)
                ListVer.Add(ver[i].name);
            ListVer.Sort(); //ordena la lista

            //inicializa la matriz de caminos si mismos
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    caminos[i, j] = j + 1;

            //inicializa la matriz en 0
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                {
                    matrizP[i, j] = max;
                    if (i == j)
                        matrizP[i, j] = 0;
                }

            //almacena los pesos a la matriz de ponderados
            for (int i = 0; i < ver.Count; i++)
            {
                string vo = ver[i].name;
                foreach (Arista a in ver[i].ListAristas)
                {
                    string vd = a.destino.name;
                    if (vo == vd)
                        matrizP[ListVer.IndexOf(vo), ListVer.IndexOf(vd)] = 0;
                    else
                        matrizP[ListVer.IndexOf(vo), ListVer.IndexOf(vd)] = a.peso; //dirigido
                    matrizP[ListVer.IndexOf(vd), ListVer.IndexOf(vo)] = max; //no dirigido

                }
            }

            //imprime la matriz de ponderados
            for (int i = 0; i < ver.Count; i++)
            {
                t.Text += ver[i].name + " |   ";
                for (int j = 0; j < n; j++)
                {
                    //Console.Write(string.Format("{0,4:D}", matrizP[i, j]));
                    //t.Text += string.Format("{0,4:D}", matrizP[i, j].ToString());
                    if(matrizP[i,j] == max)
                        t.Text += string.Format("{0,4:D}", "-");

                    else
                        t.Text += string.Format("{0,4:D}", matrizP[i, j].ToString());
                }

                t.Text += Environment.NewLine;
                //Console.WriteLine();
            }

        }

        public int[,] matrizPond 
        {
            get => matrizP;
        }

        public int[,] MatrizC
        {
            get => caminos;
        }

        /**
         * Método que inicializa la matriz de adyacencia en 0
         * Se recorre la matriz y se asignará un 1 en donde hay relación 
         * **/
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
                    //Console.Write(string.Format("{0,4:D}", matriz[i, j]));
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
                //Console.WriteLine(" interno = " + cont2 + " externo = " + cont);
                arr.Add(cont);
                arr2.Add(cont2);
                cont = cont2 = 0;
                t.Text += Environment.NewLine;
                //Console.WriteLine();
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
