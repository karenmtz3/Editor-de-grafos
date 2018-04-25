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
            //Console.WriteLine("grafo 2 / posición 0 / Lista de los grados adyacentes ");
            for(int i = 0; i < grafo2.ListGradosAd.Count; i++)
            {
                string m = grafo2.ListGradosAd[i];
                char[] AdyOrdenados = m.ToCharArray();
                Array.Sort(AdyOrdenados);
                m = new string(AdyOrdenados);
                grafo2.ListGradosAd[i] = m;
            }

            //Console.WriteLine("grafo 1 / posición 1 / Lista de los grados adyacentes ");
            for (int i = 0; i < grafo1.ListGradosAd.Count; i++)
            {
                string m = grafo1.ListGradosAd[i];
                char[] AdyOrdenados = m.ToCharArray();
                Array.Sort(AdyOrdenados);
                m = new string(AdyOrdenados);
                grafo1.ListGradosAd[i] = m;
            }

            for(int i = 0; i < grafo1.ListGradosAd.Count; i++)
            {
                bool esta = false;
                string ady = grafo1.ListGradosAd[i];
                int k = 0;
                for(int j = 0; j < grafo2.ListGradosAd.Count; j++)
                {
                    k = j;
                    string ady2 = grafo2.ListGradosAd[j];
                    if (ady2.Equals(ady))
                    {
                        esta = true;
                        break;
                    }
                }
                if(esta)
                {
                    grafo2.ListGradosAd.RemoveAt(k);
                }
            }
            if (grafo2.ListGradosAd.Count == 0)
                return true;
            else
                return false;
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
