using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grafosv1
{
    public partial class Vista : Form
    {
        private MatrizAdy m;
        public Vista()
        {
            InitializeComponent();
        }

        public void muestra(List<CVertice> ver)
        {
            m = new MatrizAdy(ver.Count);
            m.CreaMatriz(ver, richTextBox1);
        }

        private void Vista_Load(object sender, EventArgs e)
        {

        }
    }
}
