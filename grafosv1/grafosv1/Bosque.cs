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
        private Grafo bosque = new Grafo();
        private int wid, he;
        private Pen lapiz = new Pen(Color.Blue, 3); //color del contorno del nodo
        private Pen lapiz2 = new Pen(Color.BlueViolet, 4); //color de la arista

        public Bosque(Grafo NuevoGrafo)
        {
            InitializeComponent();
            bosque = NuevoGrafo;
            wid = he = 40;
        }

        public void MarcaBosque(RichTextBox DatosT, bool dirigido)
        {
            int[] arreglo = bosque.MtzAd(bosque.ListaVer.Count, DatosT, dirigido);
            bosque.guarda();
            DatosT.Clear();
            bosque.LstAd(DatosT, dirigido);
            CVertice vertex = bosque.ListaVer[0];
            bosque.dfs(vertex);
            bosque.AgregaBosque();
            for (int i = 0; i < bosque.ListaVer.Count; i++)
            {
                CVertice ver = bosque.ListaVer[i];
                if (ver.VerVisitado == false)
                {
                    bosque.dfs(ver);
                    bosque.AgregaBosque();
                }
            }

            bosque.imprimedfs();
            bosque.Bosque();
            CreaBosque();
        }

        public void CreaBosque()
        {
           for(int i = 0; i < bosque.bosque.Count; i++)
            {
                int x = 50, y = 50;
                CVertice v = bosque.ListaVer[i];
                if (i == 0)
                {
                    v.x = x;
                    v.y = y;
                }
                else
                {
                    v.x = x;
                    v.y -= y;
                    //y += 50;
                }
                foreach(Arista a in v.ListAristas)
                {
                    if (a.Tipo == 1)
                    {
                        a.destino.y += 50;
                    }
                }
              
            }
        }

        private void Bosque_Paint(object sender, PaintEventArgs e)
        {
            PointF[] puntos;
            List<PointF> point = new List<PointF>();
            for (int j = 0; j < bosque.ListaVer.Count; j++)
            {
                //dibuja el circulo y la etiqueta del nodo
                //Rectangle r = new Rectangle(bosque.ListaVer[j].x-100, bosque.ListaVer[j].y, wid, he);
                //e.Graphics.DrawRectangle(lapiz,r);
                CVertice ver = bosque.ListaVer[j];
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
                    if (k <= 3 && bosque.ListaVer.ElementAt(j) != bosque.ListaVer[j].ListAristas[k].RegresaDest)
                    {
                        Pen lapiz3 = new Pen(Color.Red, 4);
                        lapiz3.StartCap = LineCap.ArrowAnchor;
                        lapiz3.EndCap = LineCap.NoAnchor;

                        Pen lapiz4 = new Pen(Color.DarkCyan, 4);
                        lapiz4.DashPattern = new float[] { 2.0F, 2.0F, 1.0F, 2.0F };
                        lapiz4.StartCap = LineCap.ArrowAnchor;
                        lapiz4.EndCap = LineCap.NoAnchor;

                        arista.Recta = true; 
                        if (arista.Visitada || arista.Tipo == 1)
                            e.Graphics.DrawLine(lapiz3, arista.destx, arista.desty, arista.orix, arista.oriy);
                        else if (arista.Tipo == 2)
                            e.Graphics.DrawLine(lapiz4, arista.destx, arista.desty, arista.orix, arista.oriy);
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

                            //e.Graphics.DrawEllipse(lapiz, xb, yb, 2, 2);
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
