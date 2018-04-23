using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grafosv1
{
    [Serializable()]
    public class Isomorfismo
    {
        private Grafo grafo1;
        private Grafo grafo2;

        public Isomorfismo(Grafo g1, Grafo g2)
        {
            grafo1 = g1;
            grafo2 = g2;
        }

        public bool MismosVertices()
        {
            if (grafo1.ListaVer.Count == grafo2.ListaVer.Count)
                return true;
            else
                return false;
        }

        public bool CantAristas()
        {
            if (grafo1.setAris == grafo2.setAris)
                return true;
            else
                return false;
        }

        public bool MismosGrados()
        {
            List<int> grad1 = new List<int>();
            List<int> grad2 = new List<int>();

            foreach (int i in grafo1.TGrados)
                grad1.Add(i);
            foreach (int i in grafo2.TGrados)
                grad2.Add(i);

            foreach(int i in grad2)
                if (grad1.Contains(i))
                    grad1.Remove(i);

            if (grad1.Count == 0)
                return true;
            return false;
        }

        public bool GradosCoinc()
        {
            //List<int> v1 = grafo1.setGrados.ToList();
            //List<int> v2 = grafo1.setGrados.ToList();
            //v1.Sort();
            //v2.Sort();

            int[] v1 = grafo1.setGrados;
            int[] v2 = grafo2.setGrados;
            if (grafo1.ListaVer.Count != grafo2.ListaVer.Count)
                return false;
            //if (v1.SequenceEqual(v2))
              //  return true;
            for(int i = 0; i < v1.Length; i++)
            {
                if(v1[i] != v2[i])
                    return false;
            }
            return true;
        }

        public bool SonIsomosfos()
        {
            if (MismosVertices() && MismosGrados() && CantAristas() && GradosCoinc())
                return true;
            else
                return false;
        }
    }
}
