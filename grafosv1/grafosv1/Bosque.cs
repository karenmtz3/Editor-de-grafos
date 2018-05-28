using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grafosv1
{
    public partial class Bosque : Form
    {
        private Grafo BosqueCom = new Grafo();
        private List<CVertice> n2, n3, visitados;
        private CVertice raiz;
        private int wid, he;
        private Pen lapiz = new Pen(Color.Blue, 3); //color del contorno del nodo
        private Pen lapiz2 = new Pen(Color.BlueViolet, 4); //color de la arista

        public Bosque(Grafo NuevoGrafo)
        {
            InitializeComponent();
            BosqueCom = NuevoGrafo;
            n2 = new List<CVertice>();
            n3 = new List<CVertice>();
            wid = he = 40;
        }

        public void MarcaBosque(RichTextBox DatosT, bool dirigido)
        {
            int[] arreglo = BosqueCom.MtzAd(BosqueCom.ListaVer.Count, DatosT, dirigido);
            BosqueCom.guarda();
            DatosT.Clear();
            BosqueCom.LstAd(DatosT, dirigido);
            CVertice vertex = BosqueCom.ListaVer[0];
            BosqueCom.dfs(vertex);
            BosqueCom.AgregaBosque();
            for (int i = 0; i < BosqueCom.ListaVer.Count; i++)
            {
                BosqueCom.ListaVer[0].Niveles = 1;
                CVertice ver = BosqueCom.ListaVer[i];
                if (ver.VerVisitado == false)
                {
                    ver.Niveles = 1;
                    BosqueCom.dfs(ver);
                    BosqueCom.AgregaBosque();
                }
            }
            BosqueCom.imprimedfs();
            BosqueCom.Bosque();
            visitados = BosqueCom.aux;
            DibujaArbol();
            //Dibuja();
        }

        public void DibujaArbol()
        {
            label1.Text = "";
            foreach (CVertice v in visitados)
                label1.Text += " " + v.name;
            //visitados[2].ListAristas[1].Tipo = 3;
            int x = 200, x1 = 220, y = 20;
            visitados[0].x = 100;
            visitados[0].y = 100;
            visitados[3].ListAristas[1].Tipo = 3;

            for (int i =1; i < visitados.Count; i++)
            {
                CVertice ver = visitados[i];
                if (i == 1 || i == visitados.Count - 1)
                {
                    ver.x = x;
                    ver.y = y;
                }
                else
                {
                    ver.x = x1;
                    ver.y = y;
                }
                y += 80;
                foreach (Arista a in ver.ListAristas)
                {
                    if (a.Tipo == 0)
                    {
                        a.orix = ver.x;
                        a.oriy = ver.y + (he / 2);
                    }
                    if (a.Tipo == 1)
                    {
                        a.orix = ver.x + (wid / 2);
                        a.oriy = ver.y + he;
                    }
                    if (a.Tipo == 3)
                    {
                        a.orix = ver.x + (wid / 2) - 20;
                        a.oriy = ver.y + 20;
                    }
                }
            }
            for (int i = 0; i < visitados.Count; i++)
            {
                CVertice ver = visitados[i];
                foreach (Arista a in ver.ListAristas)
                {
                    if (a.Tipo == 0)
                    {
                        a.destx = a.destino.x;
                        a.desty = a.destino.y + (he / 2);
                    }
                    if (a.Tipo == 1)
                    {
                        a.destx = a.destino.x + (wid / 2);
                        a.desty = a.destino.y + (he / 4);
                    }
                    if (a.Tipo == 3)
                    {
                        a.destx = a.destino.x + (wid / 2);
                        a.desty = a.destino.y + 40;
                    }

                }
            }

            visitados[4].ListAristas[0].orix = visitados[4].x;
            visitados[4].ListAristas[0].oriy = visitados[4].y;
            visitados[4].ListAristas[0].destx = visitados[0].x+20;
            visitados[4].ListAristas[0].desty = visitados[0].y+40;
        }

        public void Dibuja()
        {
            label1.Text = "";
            foreach (CVertice v in visitados)
                label1.Text += " " + v.name;
            //visitados[2].ListAristas[1].Tipo = 3;
            int x = 200, x1 = 220, y = 20;
            for(int i = 0; i < visitados.Count; i++)
            {
                CVertice ver = visitados[i];
                if (i == 0 || i == visitados.Count - 1)
                {
                    ver.x = x;
                    ver.y = y;
                }
                else
                {
                    ver.x = x1;
                    ver.y = y;
                }
                y += 80;
                foreach (Arista a in ver.ListAristas)
                {
                    if (a.Tipo == 0)
                    {
                        a.orix = ver.x;
                        a.oriy = ver.y + (he / 2);
                    }
                    if (a.Tipo == 1)
                    {
                        a.orix = ver.x + (wid / 2);
                        a.oriy = ver.y + he;
                    }
                    if(a.Tipo == 3)
                    {
                        a.orix = ver.x + (wid / 2)-20;
                        a.oriy = ver.y +20;
                    }
                   
                }
            }
            for (int i = 0; i < visitados.Count; i++)
            {
                CVertice ver = visitados[i];
                foreach (Arista a in ver.ListAristas)
                {
                    if (a.Tipo == 0)
                    {
                        a.destx = a.destino.x;
                        a.desty = a.destino.y + (he / 2);
                    }
                    if (a.Tipo == 1)
                    {
                        a.destx = a.destino.x + (wid / 2);
                        a.desty = a.destino.y + (he / 4);
                    }
                    if(a.Tipo == 3)
                    {
                        a.destx = a.destino.x + (wid / 2);
                        a.desty = a.destino.y + 40;
                    }
                   
                }
            }
        }

        private void Bosque_Paint(object sender, PaintEventArgs e)
        {
            PointF[] puntos;
            List<PointF> point = new List<PointF>();
            for (int j = 0; j < BosqueCom.ListaVer.Count; j++)
            {
                CVertice ver = BosqueCom.ListaVer[j];
                if (ver.VerVisitado)
                {
                    e.Graphics.DrawEllipse(new Pen(Color.Red, 3), ver.x, ver.y, wid, he);
                    e.Graphics.DrawString(ver.name, new Font("Times New Roman", 12),
                     new SolidBrush(Color.Blue), ver.x + wid / 3, ver.y + he / 4);
                }
                else
                {
                    e.Graphics.DrawEllipse(lapiz, ver.x, ver.y, wid, he);
                    e.Graphics.DrawString(ver.name, new Font("Times New Roman", 12),
                      new SolidBrush(Color.Blue), ver.x + wid / 3, ver.y + he / 4);
                }
                
                //dibuja las líneas 
                for (int k = 0; k < ver.ListAristas.Count; k++)
                {
                    Arista arista = ver.ListAristas[k];

                    Pen lapiz5 = new Pen(Color.Green, 4);
                    lapiz5.DashPattern = new float[] { 2.0F, 2.0F, 1.0F, 2.0F };
                    lapiz5.StartCap = LineCap.ArrowAnchor;
                    lapiz5.EndCap = LineCap.NoAnchor;

                    if (k <= 3 && BosqueCom.ListaVer.ElementAt(j) != BosqueCom.ListaVer[j].ListAristas[k].RegresaDest)
                    {
                        lapiz2.StartCap = LineCap.ArrowAnchor;
                        lapiz2.EndCap = LineCap.NoAnchor;

                        Pen lapiz3 = new Pen(Color.Red, 4);
                        lapiz3.StartCap = LineCap.ArrowAnchor;
                        lapiz3.EndCap = LineCap.NoAnchor;

                        Pen lapiz4 = new Pen(Color.Orange, 4);
                        lapiz4.DashPattern = new float[] { 2.0F, 2.0F, 1.0F, 2.0F };
                        lapiz4.StartCap = LineCap.ArrowAnchor;
                        lapiz4.EndCap = LineCap.NoAnchor;
                        
                        arista.Recta = true; 
                        if (arista.Visitada || arista.Tipo == 1)
                            e.Graphics.DrawLine(lapiz3, arista.destx, arista.desty, arista.orix, arista.oriy);
                        else if (arista.Tipo == 2)
                            e.Graphics.DrawLine(lapiz4, arista.destx, arista.desty, arista.orix, arista.oriy);
                        else if(arista.Tipo == 3)
                              e.Graphics.DrawLine(lapiz5, arista.destx, arista.desty, arista.orix, arista.oriy);
                        else if (arista.Tipo == 0)
                            e.Graphics.DrawLine(lapiz2, arista.destx, arista.desty, arista.orix, arista.oriy);
                    }
                    else
                    {
                        arista.Recta = false;
                        for (float t = 0; t <= 1; t += 0.01f)
                        {
                            float m = (1 - t);
                            float xb = (int)((arista.p2.X * Math.Pow(m, 3)) + (3 * arista.c2.X * Math.Pow(m, 2) * t) + (2 * arista.c1.X * Math.Pow(t, 2) * m) + arista.p1.X * Math.Pow(t, 3));
                            float yb = (int)((arista.p2.Y * Math.Pow(m, 3)) + (3 * arista.c2.Y * Math.Pow(m, 2) * t) + (2 * arista.c1.Y * Math.Pow(t, 2) * m) + arista.p1.Y * Math.Pow(t, 3));
                            PointF p = new PointF(xb, yb);
                            point.Add(p);
                        }
                        puntos = point.ToArray();
                        e.Graphics.DrawCurve(lapiz2, puntos);
                    }
                    point.Clear();
                }
            }
        }
    }
}
