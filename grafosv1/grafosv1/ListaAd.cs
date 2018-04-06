using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace grafosv1
{
    public class ListaAd
    {
        List<string> ListA;

        public ListaAd()
        {
            ListA = new List<string>();
        }

        public void CreaLista(List<CVertice> vertice)
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
                    vad[des] += vo;
                }
            }

            //Imprime las listas 
           for(int i = 0; i < ListA.Count; i++)
            {
                Console.WriteLine("Vértice " + ListA[i]);
                Console.WriteLine("Vértices Adyacentes " + vad[i]);
            }


        }
    }
}
