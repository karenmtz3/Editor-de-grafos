using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grafosv1
{
    [Serializable()]
    public class ListaAd
    {
        List<string> ListA;
        //List<int> GradosAd;
        List<string> Grados;


        public ListaAd()
        {
            ListA = new List<string>();
            //GradosAd = new List<int>(); //lista de los grados de los vértices adyacentes
            Grados = new List<string>();
        }

        public void CreaLista(List<CVertice> vertice, RichTextBox t, bool dir)
        {
            List<string> vad = new List<string>(); //lista de vértices adyacentes
            //List<int> g = new List<int>();
            
            //List<int> GradosAd = new List<int>(); //lista de los grados de los vértices adyacentes 
            for (int i = 0; i < vertice.Count; i++)
            {
                ListA.Add(vertice[i].name);
                vad.Add("");
                Grados.Add("");
                
            }

            ListA.Sort(); //ordena la lista


            for(int i = 0; i < vertice.Count; i++)
            {
                string vo = vertice[i].name; //vértice origen
                foreach (Arista a in vertice[i].ListAristas)
                {
                    string vd = a.destino.name; //vértice destino
                    int or = ListA.IndexOf(vo);  //posición del vértice origen
                    int des = ListA.IndexOf(vd); //posición del vértice destino 
                    vad[or] += vd; //agrega a la lista el vértice destino 
                    //g.Add(a.destino.GetGrado);
                    Grados[or] += a.destino.GetGrado;
                    //Console.WriteLine("vértice:  " + vad[or] + " grado: " + a.destino.GetGrado);
                    //GradosAd.Add(a.destino.GetGrado);
                    if (dir == false)
                    {
                        vad[des] += vo; //agrega a la lista el vértice origen
                        //g.Add(vertice[i].GetGrado);
                        //g.Sort();
                        //Grados[des] += g.ToString();
                        //Console.WriteLine(Grados[des]);
                        Grados[des] += vertice[i].GetGrado;
                        //Console.WriteLine("vértice:  " + vo + " grado: " +vertice[i].GetGrado);
                        //GradosAd.Add(vertice[i].GetGrado);

                    }
                    /*Console.WriteLine("Vértice " + vertice[i].name);
                    g.Sort();
                    for (int j = 0; j < g.Count; j++)
                        Console.WriteLine("grado : " + g[j]);
                    Console.WriteLine();
                    g.Clear();*/
                }
            }

            //Imprime las listas 
            /*Console.WriteLine("Vértice|  Vértices Ady");
           for(int i = 0; i < ListA.Count; i++)
            {
                Console.WriteLine(ListA[i]+ "      |  " + vad[i]);
                //Console.WriteLine(vad[i]);
            }*/

            //Console.WriteLine("Vértices con sus grados");
            
            Console.WriteLine("Vértices |Ady|" + " Grados ");
            for (int i = 0; i < Grados.Count; i++)
                Console.WriteLine(ListA[i] + "        |" + vad[i] + "       |" + Grados[i]);

            t.Text += "Vértice|  Vértices Ady" + Environment.NewLine;
           for(int i = 0; i < ListA.Count; i++)
            {
                t.Text += ListA[i].ToString() + "       | " + vad[i].ToString();
                t.Text += Environment.NewLine;
            }
        }

        public List<string> GradosAd()
        {
            //imprime lista de los grados adyacentes
            //Console.WriteLine("Lista de los grados de vértices adyacentes");
            //GradosAd.Sort();
            /*for (int i = 0; i < GradosAd.Count; i++)
            {
                Console.WriteLine("grado " + GradosAd[i]);
            }*/
            return Grados;
        }
    }
}
