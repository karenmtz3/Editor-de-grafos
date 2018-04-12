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

        public ListaAd()
        {
            ListA = new List<string>();
        }

        public void CreaLista(List<CVertice> vertice, RichTextBox t, bool dir)
        {
            List<string> vad = new List<string>();
            for (int i = 0; i < vertice.Count; i++)
            {
                ListA.Add(vertice[i].name);
                vad.Add("");
            }

            ListA.Sort(); //ordena la lista


            for(int i = 0; i < vertice.Count; i++)
            {
                string vo = vertice[i].name;
                foreach(Arista a in vertice[i].ListAristas)
                {
                    string vd = a.destino.name;
                    int or = ListA.IndexOf(vo);
                    int des = ListA.IndexOf(vd);
                    vad[or] += vd;
                    if(dir == false)
                        vad[des] += vo;
                }
            }

            //Imprime las listas 
            Console.WriteLine("Vértice|  Vértices Ady");
           for(int i = 0; i < ListA.Count; i++)
            {
                Console.WriteLine(ListA[i]+ "      |  " + vad[i]);
                //Console.WriteLine(vad[i]);
            }

            t.Text += "Vértice|  Vértices Ady" + Environment.NewLine;
           for(int i = 0; i < ListA.Count; i++)
            {
                t.Text += ListA[i].ToString() + "       | " + vad[i].ToString();
                t.Text += Environment.NewLine;
            }


        }
    }
}
