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
        /**
         * Clase Isomorfismo
         * grafo1 -> El primer grafo a comparar
         * grafo2 -> El segundo grafo a comparar
         * **/
        private Grafo grafo1;
        private Grafo grafo2;
        
        /**
         * Constructor de la clase isomorfismo
         * Se para los grafos a comparar
         * **/
        public Isomorfismo(Grafo g1, Grafo g2)
        {
            grafo1 = g1;
            grafo2 = g2;
        }

        /**
         * Checa si la cantidad de vértices de los dos grafos son iguales
         * Regresa un true si son iguales o un false si son diferentes
         * **/
        public bool MismosVertices()
        {
            if (grafo1.ListaVer.Count == grafo2.ListaVer.Count)
                return true;
            else
                return false;
        }

        /**
         * Checa si el total de aristas de cada uno de los grafos son los mismos
         * Regresa un true si son iguales o un false si son diferentes
         * **/
        public bool CantAristas()
        {
            
            if (grafo1.setAris == grafo2.setAris)
                return true;
            else
                return false;
        }

        /**
         * Checa si los grados de un grafo coinciden con el otro grafo
         * Regresa un true si son iguales o un false si son diferentes
         * **/
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

        /**
         * Checa si existe la misma secuencia de grados en cada uno de los grafos 
         * Regresa un true si son iguales o un false si son diferentes
         * **/
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
        
        /**
         * Método que regres un true si se cumplen las cuatros condiciones anteriores
         * En caso de no cumplirlas regresaun false
         * **/
        public bool SonIsomosfos()
        {                
            if (MismosVertices() && MismosGrados() && CantAristas() && GradosCoinc())
                return true;
            else
                return false;
        }
    }
}
