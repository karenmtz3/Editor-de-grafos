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
            this.NodoToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AristasToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.dirigidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noDirigidoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.QuitaNToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.QuitarAToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.moverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.NodoToolStripMenu,
            this.AristasToolStripMenu,
            this.QuitaNToolStripMenu,
            this.QuitarAToolStripMenu,
            this.moverToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(524, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
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
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // NodoToolStripMenu
            // 
            this.NodoToolStripMenu.Image = global::grafosv1.Properties.Resources.perfect_circle_icon_icons_com_53928;
            this.NodoToolStripMenu.Name = "NodoToolStripMenu";
            this.NodoToolStripMenu.Size = new System.Drawing.Size(65, 20);
            this.NodoToolStripMenu.Text = "Nodo";
            this.NodoToolStripMenu.Click += new System.EventHandler(this.NodoToolStripMenu_Click);
            // 
            // AristasToolStripMenu
            // 
            this.AristasToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dirigidoToolStripMenuItem,
            this.noDirigidoToolStripMenuItem});
            this.AristasToolStripMenu.Image = global::grafosv1.Properties.Resources.software_vector_line_39821;
            this.AristasToolStripMenu.Name = "AristasToolStripMenu";
            this.AristasToolStripMenu.Size = new System.Drawing.Size(70, 20);
            this.AristasToolStripMenu.Text = "Aristas";
            this.AristasToolStripMenu.Click += new System.EventHandler(this.AristasToolStripMenu_Click);
            // 
            // dirigidoToolStripMenuItem
            // 
            this.dirigidoToolStripMenuItem.Image = global::grafosv1.Properties.Resources.rightarrow1_80967;
            this.dirigidoToolStripMenuItem.Name = "dirigidoToolStripMenuItem";
            this.dirigidoToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.dirigidoToolStripMenuItem.Text = "Dirigido";
            this.dirigidoToolStripMenuItem.Click += new System.EventHandler(this.dirigidoToolStripMenuItem_Click);
            // 
            // noDirigidoToolStripMenuItem
            // 
            this.noDirigidoToolStripMenuItem.Image = global::grafosv1.Properties.Resources.minus_gross_horizontal_straight_line_symbol_icon_icons_com_74137;
            this.noDirigidoToolStripMenuItem.Name = "noDirigidoToolStripMenuItem";
            this.noDirigidoToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.noDirigidoToolStripMenuItem.Text = "No dirigido ";
            this.noDirigidoToolStripMenuItem.Click += new System.EventHandler(this.noDirigidoToolStripMenuItem_Click);
            // 
            // QuitaNToolStripMenu
            // 
            this.QuitaNToolStripMenu.Image = global::grafosv1.Properties.Resources.Close_Icon_Circle_icon_icons_com_69142;
            this.QuitaNToolStripMenu.Name = "QuitaNToolStripMenu";
            this.QuitaNToolStripMenu.Size = new System.Drawing.Size(101, 20);
            this.QuitaNToolStripMenu.Text = "Quitar Nodo";
            this.QuitaNToolStripMenu.Click += new System.EventHandler(this.QuitaNToolStripMenu_Click);
            // 
            // QuitarAToolStripMenu
            // 
            this.QuitarAToolStripMenu.Name = "QuitarAToolStripMenu";
            this.QuitarAToolStripMenu.Size = new System.Drawing.Size(85, 20);
            this.QuitarAToolStripMenu.Text = "Quitar Arista";
            this.QuitarAToolStripMenu.Click += new System.EventHandler(this.QuitarAToolStripMenu_Click);
            // 
            // moverToolStripMenuItem
            // 
            this.moverToolStripMenuItem.Name = "moverToolStripMenuItem";
            this.moverToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.moverToolStripMenuItem.Text = "Mover";
            this.moverToolStripMenuItem.Click += new System.EventHandler(this.moverToolStripMenuItem_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(524, 330);
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
        private System.Windows.Forms.ToolStripMenuItem NodoToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem AristasToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem QuitaNToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem QuitarAToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem dirigidoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noDirigidoToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
    }
}

