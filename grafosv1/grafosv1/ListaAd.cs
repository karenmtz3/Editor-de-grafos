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
        /**
         * Clase lista de adyacencia
         * ListA ->Almacena todos los vértices del grafo
         * Vord -> Lista en donde se guardan los vértices ordenados por su nombre
         * Grados-> Lista que almacena los grados de los vértices adyacentes de un vértice
         * vad -> Lista en donde se almacena los vértices adyacentes de cada vértice
         * **/
        List<CVertice> ListA;
        List<CVertice> VOrd;
        //List<int> GradosAd;
        List<string> Grados;
        public List<string> vad;

        /**
         * Constructor de la clase
         * **/
        public ListaAd()
        {
            ListA = new List<CVertice>();
            Grados = new List<string>();
            vad = new List<string>(); //lista de vértices adyacentes
        }

        /**
         * Método en donde se crea la lista de adyacencia
         * **/
        public void CreaLista(List<CVertice> vertice, RichTextBox t, bool dir)
        {
            for (int i = 0; i < vertice.Count; i++)
            {
                ListA.Add(vertice[i]);
                vad.Add("");
                Grados.Add("");
            }

             //ordena la lista
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
            return Grados;
        }
    }
}
