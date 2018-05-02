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
        public List<string> vad;


        public ListaAd()
        {
            ListA = new List<string>();
            Grados = new List<string>();
            vad = new List<string>(); //lista de vértices adyacentes
        }

        public void CreaLista(List<CVertice> vertice, RichTextBox t, bool dir)
        {
            
            //List<int> g = new List<int>();

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
                    Grados[or] += a.destino.GetGrado;
                    if (dir == false)
                    {
                        vad[des] += vo; //agrega a la lista el vértice origen
                        Grados[des] += vertice[i].GetGrado;

                    }
                }
            }

           
            for(int i = 0; i < vad.Count; i++)
            {
                string m = vad[i];
                char[] AdyOrdenados = m.ToCharArray();
                Array.Sort(AdyOrdenados);
                m = new string(AdyOrdenados);
                vad[i] = m;
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
