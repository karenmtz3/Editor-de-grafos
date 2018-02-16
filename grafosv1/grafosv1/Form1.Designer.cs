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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.vérticeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aristaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grafoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminaAristaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoGrafoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moverGrafoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoNodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitarNodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moverNodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaAristaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dirigidoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.noDirigidoToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.grafoToolStripMenuItem,
            this.vérticeToolStripMenuItem,
            this.aristaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(792, 24);
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
            this.nuevoToolStripMenuItem1.Name = "nuevoToolStripMenuItem1";
            this.nuevoToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.nuevoToolStripMenuItem1.Text = "Nuevo";
            this.nuevoToolStripMenuItem1.Click += new System.EventHandler(this.nuevoToolStripMenuItem1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(22, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(22, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Indigo;
            this.label3.Location = new System.Drawing.Point(22, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(22, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "label4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.IndianRed;
            this.label5.Location = new System.Drawing.Point(25, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "label5";
            // 
            // vérticeToolStripMenuItem
            // 
            this.vérticeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoNodoToolStripMenuItem,
            this.quitarNodoToolStripMenuItem,
            this.moverNodoToolStripMenuItem});
            this.vérticeToolStripMenuItem.Name = "vérticeToolStripMenuItem";
            this.vérticeToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.vérticeToolStripMenuItem.Text = "Vértice";
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
            // grafoToolStripMenuItem
            // 
            this.grafoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoGrafoToolStripMenuItem,
            this.moverGrafoToolStripMenuItem});
            this.grafoToolStripMenuItem.Name = "grafoToolStripMenuItem";
            this.grafoToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.grafoToolStripMenuItem.Text = "Grafo";
            // 
            // eliminaAristaToolStripMenuItem
            // 
            this.eliminaAristaToolStripMenuItem.Name = "eliminaAristaToolStripMenuItem";
            this.eliminaAristaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.eliminaAristaToolStripMenuItem.Text = "Elimina Arista";
            this.eliminaAristaToolStripMenuItem.Click += new System.EventHandler(this.eliminaAristaToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Image = global::grafosv1.Properties.Resources.Save_80_icon_icons_com_57276;
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Image = global::grafosv1.Properties.Resources.stock_open_36034;
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // nuevoGrafoToolStripMenuItem
            // 
            this.nuevoGrafoToolStripMenuItem.Image = global::grafosv1.Properties.Resources.Line_Graph_41751;
            this.nuevoGrafoToolStripMenuItem.Name = "nuevoGrafoToolStripMenuItem";
            this.nuevoGrafoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nuevoGrafoToolStripMenuItem.Text = "Nuevo Grafo";
            this.nuevoGrafoToolStripMenuItem.Click += new System.EventHandler(this.nuevoGrafoToolStripMenuItem_Click);
            // 
            // moverGrafoToolStripMenuItem
            // 
            this.moverGrafoToolStripMenuItem.Image = global::grafosv1.Properties.Resources.move_78474;
            this.moverGrafoToolStripMenuItem.Name = "moverGrafoToolStripMenuItem";
            this.moverGrafoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.moverGrafoToolStripMenuItem.Text = "Mover Grafo";
            this.moverGrafoToolStripMenuItem.Click += new System.EventHandler(this.moverGrafoToolStripMenuItem_Click);
            // 
            // nuevoNodoToolStripMenuItem
            // 
            this.nuevoNodoToolStripMenuItem.Image = global::grafosv1.Properties.Resources.perfect_circle_icon_icons_com_53928;
            this.nuevoNodoToolStripMenuItem.Name = "nuevoNodoToolStripMenuItem";
            this.nuevoNodoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nuevoNodoToolStripMenuItem.Text = "Nuevo Nodo";
            this.nuevoNodoToolStripMenuItem.Click += new System.EventHandler(this.nuevoNodoToolStripMenuItem_Click);
            // 
            // quitarNodoToolStripMenuItem
            // 
            this.quitarNodoToolStripMenuItem.Image = global::grafosv1.Properties.Resources.Close_Icon_Circle_icon_icons_com_69142;
            this.quitarNodoToolStripMenuItem.Name = "quitarNodoToolStripMenuItem";
            this.quitarNodoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.quitarNodoToolStripMenuItem.Text = "Quitar Nodo";
            this.quitarNodoToolStripMenuItem.Click += new System.EventHandler(this.quitarNodoToolStripMenuItem_Click);
            // 
            // moverNodoToolStripMenuItem
            // 
            this.moverNodoToolStripMenuItem.Image = global::grafosv1.Properties.Resources.movearrowssymbolincircularbutton_79591;
            this.moverNodoToolStripMenuItem.Name = "moverNodoToolStripMenuItem";
            this.moverNodoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.moverNodoToolStripMenuItem.Text = "Mover Nodo";
            this.moverNodoToolStripMenuItem.Click += new System.EventHandler(this.moverNodoToolStripMenuItem_Click);
            // 
            // nuevaAristaToolStripMenuItem
            // 
            this.nuevaAristaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dirigidoToolStripMenuItem1,
            this.noDirigidoToolStripMenuItem1});
            this.nuevaAristaToolStripMenuItem.Image = global::grafosv1.Properties.Resources.software_vector_line_39821;
            this.nuevaAristaToolStripMenuItem.Name = "nuevaAristaToolStripMenuItem";
            this.nuevaAristaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nuevaAristaToolStripMenuItem.Text = "Nueva Arista";
            // 
            // dirigidoToolStripMenuItem1
            // 
            this.dirigidoToolStripMenuItem1.Image = global::grafosv1.Properties.Resources.rightarrow1_80967;
            this.dirigidoToolStripMenuItem1.Name = "dirigidoToolStripMenuItem1";
            this.dirigidoToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.dirigidoToolStripMenuItem1.Text = "Dirigido";
            this.dirigidoToolStripMenuItem1.Click += new System.EventHandler(this.dirigidoToolStripMenuItem1_Click);
            // 
            // noDirigidoToolStripMenuItem1
            // 
            this.noDirigidoToolStripMenuItem1.Image = global::grafosv1.Properties.Resources.minus_gross_horizontal_straight_line_symbol_icon_icons_com_74137;
            this.noDirigidoToolStripMenuItem1.Name = "noDirigidoToolStripMenuItem1";
            this.noDirigidoToolStripMenuItem1.Size = new System.Drawing.Size(134, 22);
            this.noDirigidoToolStripMenuItem1.Text = "No dirigido";
            this.noDirigidoToolStripMenuItem1.Click += new System.EventHandler(this.noDirigidoToolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(792, 424);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
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
    }
}

