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
        List<CVertice> ListA;
        List<CVertice> VOrd;
        //List<int> GradosAd;
        List<string> Grados;
        public List<string> vad;


        public ListaAd()
        {
            ListA = new List<CVertice>();
            Grados = new List<string>();
            vad = new List<string>(); //lista de vértices adyacentes
        }

        public void CreaLista(List<CVertice> vertice, RichTextBox t, bool dir)
        {
            
            //List<int> g = new List<int>();

            for (int i = 0; i < vertice.Count; i++)
            {
                ListA.Add(vertice[i]);
                vad.Add("");
                Grados.Add("");
                
            }

            //ListA.Sort(); //ordena la lista
            VOrd = ListA.OrderBy(o => o.name).ToList();

            for (int i = 0; i < vertice.Count; i++)
            {
                CVertice vo = vertice[i]; //vértice origen
                foreach (Arista a in vertice[i].ListAristas)
                {
                    CVertice vd = a.destino; //vértice destino
                    int or = VOrd.IndexOf(vo);  //posición del vértice origen
                    int des = VOrd.IndexOf(vd); //posición del vértice destino 
                    vad[or] += vd.name; //agrega a la lista el vértice destino 
                    Grados[or] += a.destino.GetGrado;
                    if (dir == false)
                    {
                        vad[des] += vo.name; //agrega a la lista el vértice origen
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
                Console.WriteLine(VOrd[i].name + "        |" + vad[i] + "       |" + Grados[i]);

            t.Text += "Vértice|  Vértices Ady" + Environment.NewLine;
           for(int i = 0; i < VOrd.Count; i++)
            {
                t.Text += VOrd[i].name + "       | " + vad[i].ToString();
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
