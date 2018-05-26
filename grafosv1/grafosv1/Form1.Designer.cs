namespace grafosv1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grafoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoGrafoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moverGrafoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matrizAdyacenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listaDeAdyacenciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matrizIncidenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.isomorfismoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medioKuratowskyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vérticeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoNodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitarNodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moverNodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradoDeNodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gradoInternoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aristaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaAristaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dirigidoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ponderadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noPonderadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noDirigidoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ponderadoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.noPonderadoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminaAristaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algoritmosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.caminoEulerianoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ciruitoEulerianoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.corolario1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cotolario2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.númeroCromáticoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algoritmosDirigidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.floydToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.impresiónDeCaminosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bosqueAbarcadorEnProfundidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acíclicosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algoritmosNoDirigidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kruskalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recorridoEnAmplitudToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.NumGrafo = new System.Windows.Forms.NumericUpDown();
            this.DatosT = new System.Windows.Forms.RichTextBox();
            this.mfloyd = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ElimAr = new System.Windows.Forms.Button();
            this.VerCut = new System.Windows.Forms.Button();
            this.ElimV = new System.Windows.Forms.Button();
            this.ChecaK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumGrafo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.grafoToolStripMenuItem,
            this.vérticeToolStripMenuItem,
            this.aristaToolStripMenuItem,
            this.algoritmosToolStripMenuItem,
            this.algoritmosDirigidosToolStripMenuItem,
            this.algoritmosNoDirigidosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(829, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem1,
            this.guardarToolStripMenuItem,
            this.abrirToolStripMenuItem});
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.nuevoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevoToolStripMenuItem1
            // 
            this.nuevoToolStripMenuItem1.Image = global::grafosv1.Properties.Resources.New_File_36861;
            this.nuevoToolStripMenuItem1.Name = "nuevoToolStripMenuItem1";
            this.nuevoToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.nuevoToolStripMenuItem1.Text = "Nuevo";
            this.nuevoToolStripMenuItem1.Click += new System.EventHandler(this.nuevoToolStripMenuItem1_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Image = global::grafosv1.Properties.Resources.Save_80_icon_icons_com_57276;
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Image = global::grafosv1.Properties.Resources.stock_open_36034;
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // grafoToolStripMenuItem
            // 
            this.grafoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoGrafoToolStripMenuItem,
            this.moverGrafoToolStripMenuItem,
            this.matrizAdyacenciaToolStripMenuItem,
            this.listaDeAdyacenciasToolStripMenuItem,
            this.matrizIncidenciaToolStripMenuItem,
            this.isomorfismoToolStripMenuItem,
            this.medioKuratowskyToolStripMenuItem});
            this.grafoToolStripMenuItem.Name = "grafoToolStripMenuItem";
            this.grafoToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.grafoToolStripMenuItem.Text = "Grafo";
            // 
            // nuevoGrafoToolStripMenuItem
            // 
            this.nuevoGrafoToolStripMenuItem.Image = global::grafosv1.Properties.Resources.Line_Graph_41751;
            this.nuevoGrafoToolStripMenuItem.Name = "nuevoGrafoToolStripMenuItem";
            this.nuevoGrafoToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.nuevoGrafoToolStripMenuItem.Text = "Nuevo Grafo";
            this.nuevoGrafoToolStripMenuItem.Click += new System.EventHandler(this.nuevoGrafoToolStripMenuItem_Click);
            // 
            // moverGrafoToolStripMenuItem
            // 
            this.moverGrafoToolStripMenuItem.Image = global::grafosv1.Properties.Resources.move_78474;
            this.moverGrafoToolStripMenuItem.Name = "moverGrafoToolStripMenuItem";
            this.moverGrafoToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.moverGrafoToolStripMenuItem.Text = "Mover Grafo";
            this.moverGrafoToolStripMenuItem.Click += new System.EventHandler(this.moverGrafoToolStripMenuItem_Click);
            // 
            // matrizAdyacenciaToolStripMenuItem
            // 
            this.matrizAdyacenciaToolStripMenuItem.Name = "matrizAdyacenciaToolStripMenuItem";
            this.matrizAdyacenciaToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.matrizAdyacenciaToolStripMenuItem.Text = "Matriz Adyacencia";
            this.matrizAdyacenciaToolStripMenuItem.Click += new System.EventHandler(this.matrizAdyacenciaToolStripMenuItem_Click);
            // 
            // listaDeAdyacenciasToolStripMenuItem
            // 
            this.listaDeAdyacenciasToolStripMenuItem.Name = "listaDeAdyacenciasToolStripMenuItem";
            this.listaDeAdyacenciasToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.listaDeAdyacenciasToolStripMenuItem.Text = "Lista Adyacencia";
            this.listaDeAdyacenciasToolStripMenuItem.Click += new System.EventHandler(this.listaDeAdyacenciasToolStripMenuItem_Click);
            // 
            // matrizIncidenciaToolStripMenuItem
            // 
            this.matrizIncidenciaToolStripMenuItem.Name = "matrizIncidenciaToolStripMenuItem";
            this.matrizIncidenciaToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.matrizIncidenciaToolStripMenuItem.Text = "Matriz Incidencia";
            this.matrizIncidenciaToolStripMenuItem.Click += new System.EventHandler(this.matrizIncidenciaToolStripMenuItem_Click);
            // 
            // isomorfismoToolStripMenuItem
            // 
            this.isomorfismoToolStripMenuItem.Name = "isomorfismoToolStripMenuItem";
            this.isomorfismoToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.isomorfismoToolStripMenuItem.Text = "Isomorfismo";
            this.isomorfismoToolStripMenuItem.Click += new System.EventHandler(this.isomorfismoToolStripMenuItem_Click);
            // 
            // medioKuratowskyToolStripMenuItem
            // 
            this.medioKuratowskyToolStripMenuItem.Name = "medioKuratowskyToolStripMenuItem";
            this.medioKuratowskyToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.medioKuratowskyToolStripMenuItem.Text = "Kuratowski";
            this.medioKuratowskyToolStripMenuItem.Click += new System.EventHandler(this.medioKuratowskyToolStripMenuItem_Click);
            // 
            // vérticeToolStripMenuItem
            // 
            this.vérticeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoNodoToolStripMenuItem,
            this.quitarNodoToolStripMenuItem,
            this.moverNodoToolStripMenuItem,
            this.gradoDeNodoToolStripMenuItem,
            this.gradoInternoToolStripMenuItem});
            this.vérticeToolStripMenuItem.Name = "vérticeToolStripMenuItem";
            this.vérticeToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.vérticeToolStripMenuItem.Text = "Vértice";
            this.vérticeToolStripMenuItem.Click += new System.EventHandler(this.vérticeToolStripMenuItem_Click);
            // 
            // nuevoNodoToolStripMenuItem
            // 
            this.nuevoNodoToolStripMenuItem.Image = global::grafosv1.Properties.Resources.perfect_circle_icon_icons_com_53928;
            this.nuevoNodoToolStripMenuItem.Name = "nuevoNodoToolStripMenuItem";
            this.nuevoNodoToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.nuevoNodoToolStripMenuItem.Text = "Nuevo Nodo";
            this.nuevoNodoToolStripMenuItem.Click += new System.EventHandler(this.nuevoNodoToolStripMenuItem_Click);
            // 
            // quitarNodoToolStripMenuItem
            // 
            this.quitarNodoToolStripMenuItem.Image = global::grafosv1.Properties.Resources.Close_Icon_Circle_icon_icons_com_69142;
            this.quitarNodoToolStripMenuItem.Name = "quitarNodoToolStripMenuItem";
            this.quitarNodoToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.quitarNodoToolStripMenuItem.Text = "Quitar Nodo";
            this.quitarNodoToolStripMenuItem.Click += new System.EventHandler(this.quitarNodoToolStripMenuItem_Click);
            // 
            // moverNodoToolStripMenuItem
            // 
            this.moverNodoToolStripMenuItem.Image = global::grafosv1.Properties.Resources.movearrowssymbolincircularbutton_79591;
            this.moverNodoToolStripMenuItem.Name = "moverNodoToolStripMenuItem";
            this.moverNodoToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.moverNodoToolStripMenuItem.Text = "Mover Nodo";
            this.moverNodoToolStripMenuItem.Click += new System.EventHandler(this.moverNodoToolStripMenuItem_Click);
            // 
            // gradoDeNodoToolStripMenuItem
            // 
            this.gradoDeNodoToolStripMenuItem.Image = global::grafosv1.Properties.Resources.Plus_36851;
            this.gradoDeNodoToolStripMenuItem.Name = "gradoDeNodoToolStripMenuItem";
            this.gradoDeNodoToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.gradoDeNodoToolStripMenuItem.Text = "Grado de Nodo";
            this.gradoDeNodoToolStripMenuItem.Click += new System.EventHandler(this.gradoDeNodoToolStripMenuItem_Click);
            // 
            // gradoInternoToolStripMenuItem
            // 
            this.gradoInternoToolStripMenuItem.Name = "gradoInternoToolStripMenuItem";
            this.gradoInternoToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.gradoInternoToolStripMenuItem.Text = "Grado Interno y Externo";
            this.gradoInternoToolStripMenuItem.Click += new System.EventHandler(this.gradoInternoToolStripMenuItem_Click);
            // 
            // aristaToolStripMenuItem
            // 
            this.aristaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaAristaToolStripMenuItem,
            this.eliminaAristaToolStripMenuItem});
            this.aristaToolStripMenuItem.Name = "aristaToolStripMenuItem";
            this.aristaToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.aristaToolStripMenuItem.Text = "Arista";
            // 
            // nuevaAristaToolStripMenuItem
            // 
            this.nuevaAristaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dirigidoToolStripMenuItem1,
            this.noDirigidoToolStripMenuItem1});
            this.nuevaAristaToolStripMenuItem.Image = global::grafosv1.Properties.Resources.software_vector_line_39821;
            this.nuevaAristaToolStripMenuItem.Name = "nuevaAristaToolStripMenuItem";
            this.nuevaAristaToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.nuevaAristaToolStripMenuItem.Text = "Nueva Arista";
            this.nuevaAristaToolStripMenuItem.Click += new System.EventHandler(this.nuevaAristaToolStripMenuItem_Click);
            // 
            // dirigidoToolStripMenuItem1
            // 
            this.dirigidoToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ponderadoToolStripMenuItem,
            this.noPonderadoToolStripMenuItem});
            this.dirigidoToolStripMenuItem1.Image = global::grafosv1.Properties.Resources.rightarrow1_80967;
            this.dirigidoToolStripMenuItem1.Name = "dirigidoToolStripMenuItem1";
            this.dirigidoToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.dirigidoToolStripMenuItem1.Text = "Dirigido";
            this.dirigidoToolStripMenuItem1.Click += new System.EventHandler(this.dirigidoToolStripMenuItem1_Click);
            // 
            // ponderadoToolStripMenuItem
            // 
            this.ponderadoToolStripMenuItem.Name = "ponderadoToolStripMenuItem";
            this.ponderadoToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.ponderadoToolStripMenuItem.Text = "Ponderado";
            this.ponderadoToolStripMenuItem.Click += new System.EventHandler(this.ponderadoToolStripMenuItem_Click);
            // 
            // noPonderadoToolStripMenuItem
            // 
            this.noPonderadoToolStripMenuItem.Name = "noPonderadoToolStripMenuItem";
            this.noPonderadoToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.noPonderadoToolStripMenuItem.Text = "No Ponderado";
            this.noPonderadoToolStripMenuItem.Click += new System.EventHandler(this.noPonderadoToolStripMenuItem_Click);
            // 
            // noDirigidoToolStripMenuItem1
            // 
            this.noDirigidoToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ponderadoToolStripMenuItem1,
            this.noPonderadoToolStripMenuItem1});
            this.noDirigidoToolStripMenuItem1.Image = global::grafosv1.Properties.Resources.minus_gross_horizontal_straight_line_symbol_icon_icons_com_74137;
            this.noDirigidoToolStripMenuItem1.Name = "noDirigidoToolStripMenuItem1";
            this.noDirigidoToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.noDirigidoToolStripMenuItem1.Text = "No dirigido";
            this.noDirigidoToolStripMenuItem1.Click += new System.EventHandler(this.noDirigidoToolStripMenuItem1_Click);
            // 
            // ponderadoToolStripMenuItem1
            // 
            this.ponderadoToolStripMenuItem1.Name = "ponderadoToolStripMenuItem1";
            this.ponderadoToolStripMenuItem1.Size = new System.Drawing.Size(151, 22);
            this.ponderadoToolStripMenuItem1.Text = "Ponderado";
            this.ponderadoToolStripMenuItem1.Click += new System.EventHandler(this.ponderadoToolStripMenuItem1_Click);
            // 
            // noPonderadoToolStripMenuItem1
            // 
            this.noPonderadoToolStripMenuItem1.Name = "noPonderadoToolStripMenuItem1";
            this.noPonderadoToolStripMenuItem1.Size = new System.Drawing.Size(151, 22);
            this.noPonderadoToolStripMenuItem1.Text = "No ponderado";
            this.noPonderadoToolStripMenuItem1.Click += new System.EventHandler(this.noPonderadoToolStripMenuItem1_Click);
            // 
            // eliminaAristaToolStripMenuItem
            // 
            this.eliminaAristaToolStripMenuItem.Name = "eliminaAristaToolStripMenuItem";
            this.eliminaAristaToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.eliminaAristaToolStripMenuItem.Text = "Elimina Arista";
            this.eliminaAristaToolStripMenuItem.Click += new System.EventHandler(this.eliminaAristaToolStripMenuItem_Click);
            // 
            // algoritmosToolStripMenuItem
            // 
            this.algoritmosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.caminoEulerianoToolStripMenuItem,
            this.ciruitoEulerianoToolStripMenuItem,
            this.corolario1ToolStripMenuItem,
            this.cotolario2ToolStripMenuItem,
            this.númeroCromáticoToolStripMenuItem});
            this.algoritmosToolStripMenuItem.Name = "algoritmosToolStripMenuItem";
            this.algoritmosToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.algoritmosToolStripMenuItem.Text = "Algoritmos";
            // 
            // caminoEulerianoToolStripMenuItem
            // 
            this.caminoEulerianoToolStripMenuItem.Name = "caminoEulerianoToolStripMenuItem";
            this.caminoEulerianoToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.caminoEulerianoToolStripMenuItem.Text = "Camino Euleriano";
            this.caminoEulerianoToolStripMenuItem.Click += new System.EventHandler(this.caminoEulerianoToolStripMenuItem_Click);
            // 
            // ciruitoEulerianoToolStripMenuItem
            // 
            this.ciruitoEulerianoToolStripMenuItem.Name = "ciruitoEulerianoToolStripMenuItem";
            this.ciruitoEulerianoToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.ciruitoEulerianoToolStripMenuItem.Text = "Ciruito Euleriano";
            this.ciruitoEulerianoToolStripMenuItem.Click += new System.EventHandler(this.ciruitoEulerianoToolStripMenuItem_Click);
            // 
            // corolario1ToolStripMenuItem
            // 
            this.corolario1ToolStripMenuItem.Name = "corolario1ToolStripMenuItem";
            this.corolario1ToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.corolario1ToolStripMenuItem.Text = "Corolario 1";
            this.corolario1ToolStripMenuItem.Click += new System.EventHandler(this.corolario1ToolStripMenuItem_Click);
            // 
            // cotolario2ToolStripMenuItem
            // 
            this.cotolario2ToolStripMenuItem.Name = "cotolario2ToolStripMenuItem";
            this.cotolario2ToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.cotolario2ToolStripMenuItem.Text = "Corolario 2";
            this.cotolario2ToolStripMenuItem.Click += new System.EventHandler(this.cotolario2ToolStripMenuItem_Click);
            // 
            // númeroCromáticoToolStripMenuItem
            // 
            this.númeroCromáticoToolStripMenuItem.Name = "númeroCromáticoToolStripMenuItem";
            this.númeroCromáticoToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.númeroCromáticoToolStripMenuItem.Text = "Número Cromático";
            this.númeroCromáticoToolStripMenuItem.Click += new System.EventHandler(this.númeroCromáticoToolStripMenuItem_Click);
            // 
            // algoritmosDirigidosToolStripMenuItem
            // 
            this.algoritmosDirigidosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.floydToolStripMenuItem,
            this.impresiónDeCaminosToolStripMenuItem,
            this.bosqueAbarcadorEnProfundidadToolStripMenuItem,
            this.acíclicosToolStripMenuItem});
            this.algoritmosDirigidosToolStripMenuItem.Name = "algoritmosDirigidosToolStripMenuItem";
            this.algoritmosDirigidosToolStripMenuItem.Size = new System.Drawing.Size(128, 20);
            this.algoritmosDirigidosToolStripMenuItem.Text = "Algoritmos Dirigidos";
            // 
            // floydToolStripMenuItem
            // 
            this.floydToolStripMenuItem.Name = "floydToolStripMenuItem";
            this.floydToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.floydToolStripMenuItem.Text = "Floyd";
            this.floydToolStripMenuItem.Click += new System.EventHandler(this.floydToolStripMenuItem_Click);
            // 
            // impresiónDeCaminosToolStripMenuItem
            // 
            this.impresiónDeCaminosToolStripMenuItem.Name = "impresiónDeCaminosToolStripMenuItem";
            this.impresiónDeCaminosToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.impresiónDeCaminosToolStripMenuItem.Text = "Impresión de caminos";
            this.impresiónDeCaminosToolStripMenuItem.Click += new System.EventHandler(this.impresiónDeCaminosToolStripMenuItem_Click);
            // 
            // bosqueAbarcadorEnProfundidadToolStripMenuItem
            // 
            this.bosqueAbarcadorEnProfundidadToolStripMenuItem.Name = "bosqueAbarcadorEnProfundidadToolStripMenuItem";
            this.bosqueAbarcadorEnProfundidadToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.bosqueAbarcadorEnProfundidadToolStripMenuItem.Text = "Bosque abarcador en profundidad";
            this.bosqueAbarcadorEnProfundidadToolStripMenuItem.Click += new System.EventHandler(this.bosqueAbarcadorEnProfundidadToolStripMenuItem_Click);
            // 
            // acíclicosToolStripMenuItem
            // 
            this.acíclicosToolStripMenuItem.Name = "acíclicosToolStripMenuItem";
            this.acíclicosToolStripMenuItem.Size = new System.Drawing.Size(254, 22);
            this.acíclicosToolStripMenuItem.Text = "Acíclicos";
            this.acíclicosToolStripMenuItem.Click += new System.EventHandler(this.acíclicosToolStripMenuItem_Click);
            // 
            // algoritmosNoDirigidosToolStripMenuItem
            // 
            this.algoritmosNoDirigidosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kruskalToolStripMenuItem,
            this.recorridoEnAmplitudToolStripMenuItem});
            this.algoritmosNoDirigidosToolStripMenuItem.Name = "algoritmosNoDirigidosToolStripMenuItem";
            this.algoritmosNoDirigidosToolStripMenuItem.Size = new System.Drawing.Size(145, 20);
            this.algoritmosNoDirigidosToolStripMenuItem.Text = "Algoritmos no Dirigidos";
            // 
            // kruskalToolStripMenuItem
            // 
            this.kruskalToolStripMenuItem.Name = "kruskalToolStripMenuItem";
            this.kruskalToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.kruskalToolStripMenuItem.Text = "Kruskal";
            this.kruskalToolStripMenuItem.Click += new System.EventHandler(this.kruskalToolStripMenuItem_Click);
            // 
            // recorridoEnAmplitudToolStripMenuItem
            // 
            this.recorridoEnAmplitudToolStripMenuItem.Name = "recorridoEnAmplitudToolStripMenuItem";
            this.recorridoEnAmplitudToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.recorridoEnAmplitudToolStripMenuItem.Text = "Recorrido en amplitud";
            this.recorridoEnAmplitudToolStripMenuItem.Click += new System.EventHandler(this.recorridoEnAmplitudToolStripMenuItem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(8, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 15);
            this.label5.TabIndex = 6;
            // 
            // NumGrafo
            // 
            this.NumGrafo.Location = new System.Drawing.Point(583, 0);
            this.NumGrafo.Name = "NumGrafo";
            this.NumGrafo.Size = new System.Drawing.Size(33, 20);
            this.NumGrafo.TabIndex = 7;
            this.NumGrafo.ValueChanged += new System.EventHandler(this.NumGrafo_ValueChanged);
            // 
            // DatosT
            // 
            this.DatosT.Location = new System.Drawing.Point(6, 41);
            this.DatosT.Name = "DatosT";
            this.DatosT.ReadOnly = true;
            this.DatosT.Size = new System.Drawing.Size(139, 69);
            this.DatosT.TabIndex = 8;
            this.DatosT.Text = "";
            // 
            // mfloyd
            // 
            this.mfloyd.Location = new System.Drawing.Point(6, 128);
            this.mfloyd.Name = "mfloyd";
            this.mfloyd.ReadOnly = true;
            this.mfloyd.Size = new System.Drawing.Size(139, 78);
            this.mfloyd.TabIndex = 10;
            this.mfloyd.Text = "";
            this.mfloyd.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ElimAr);
            this.groupBox1.Controls.Add(this.VerCut);
            this.groupBox1.Controls.Add(this.ElimV);
            this.groupBox1.Controls.Add(this.ChecaK);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.DatosT);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.mfloyd);
            this.groupBox1.Location = new System.Drawing.Point(4, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(153, 339);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "propiedades";
            // 
            // ElimAr
            // 
            this.ElimAr.ForeColor = System.Drawing.Color.Blue;
            this.ElimAr.Location = new System.Drawing.Point(73, 294);
            this.ElimAr.Name = "ElimAr";
            this.ElimAr.Size = new System.Drawing.Size(49, 36);
            this.ElimAr.TabIndex = 15;
            this.ElimAr.Text = "Elimina Arista";
            this.ElimAr.UseVisualStyleBackColor = true;
            this.ElimAr.Visible = false;
            this.ElimAr.Click += new System.EventHandler(this.ElimAr_Click);
            // 
            // VerCut
            // 
            this.VerCut.ForeColor = System.Drawing.Color.Blue;
            this.VerCut.Location = new System.Drawing.Point(73, 248);
            this.VerCut.Name = "VerCut";
            this.VerCut.Size = new System.Drawing.Size(55, 41);
            this.VerCut.TabIndex = 13;
            this.VerCut.Text = "Vértice Cut";
            this.VerCut.UseVisualStyleBackColor = true;
            this.VerCut.Visible = false;
            this.VerCut.Click += new System.EventHandler(this.VerCut_Click);
            // 
            // ElimV
            // 
            this.ElimV.ForeColor = System.Drawing.Color.Blue;
            this.ElimV.Location = new System.Drawing.Point(6, 295);
            this.ElimV.Name = "ElimV";
            this.ElimV.Size = new System.Drawing.Size(51, 35);
            this.ElimV.TabIndex = 14;
            this.ElimV.Text = "Elimina Vértice";
            this.ElimV.UseVisualStyleBackColor = true;
            this.ElimV.Visible = false;
            this.ElimV.Click += new System.EventHandler(this.ElimV_Click);
            // 
            // ChecaK
            // 
            this.ChecaK.ForeColor = System.Drawing.Color.Blue;
            this.ChecaK.Location = new System.Drawing.Point(0, 247);
            this.ChecaK.Name = "ChecaK";
            this.ChecaK.Size = new System.Drawing.Size(67, 41);
            this.ChecaK.TabIndex = 13;
            this.ChecaK.Text = "Checa Kuratowski";
            this.ChecaK.UseVisualStyleBackColor = true;
            this.ChecaK.Visible = false;
            this.ChecaK.Click += new System.EventHandler(this.ChecaK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(8, 218);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(829, 453);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.NumGrafo);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor de Grafos";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumGrafo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vérticeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoNodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitarNodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moverNodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aristaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevaAristaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dirigidoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem noDirigidoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem grafoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoGrafoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moverGrafoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminaAristaToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown NumGrafo;
        private System.Windows.Forms.ToolStripMenuItem ponderadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noPonderadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gradoDeNodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matrizAdyacenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listaDeAdyacenciasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matrizIncidenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem isomorfismoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ponderadoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem noPonderadoToolStripMenuItem1;
        private System.Windows.Forms.RichTextBox DatosT;
        private System.Windows.Forms.ToolStripMenuItem gradoInternoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medioKuratowskyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem algoritmosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem caminoEulerianoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ciruitoEulerianoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem corolario1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cotolario2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem númeroCromáticoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem algoritmosDirigidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem floydToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem impresiónDeCaminosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bosqueAbarcadorEnProfundidadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acíclicosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem algoritmosNoDirigidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kruskalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recorridoEnAmplitudToolStripMenuItem;
        private System.Windows.Forms.RichTextBox mfloyd;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ElimAr;
        private System.Windows.Forms.Button VerCut;
        private System.Windows.Forms.Button ElimV;
        private System.Windows.Forms.Button ChecaK;
    }
}

