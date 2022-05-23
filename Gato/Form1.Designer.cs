namespace Gato
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
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
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Vida = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Jugar = new System.Windows.Forms.ToolStripButton();
            this.Ayuda = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.Puntos = new System.Windows.Forms.Label();
            this.IngresaNombre = new System.Windows.Forms.TextBox();
            this.Iniciar = new System.Windows.Forms.Button();
            this.Records = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Vida
            // 
            this.Vida.AutoSize = true;
            this.Vida.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Vida.Font = new System.Drawing.Font("Papyrus", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Vida.Location = new System.Drawing.Point(12, 9);
            this.Vida.Name = "Vida";
            this.Vida.Size = new System.Drawing.Size(54, 18);
            this.Vida.TabIndex = 0;
            this.Vida.Text = "Vidas: 3";
            this.Vida.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Jugar,
            this.Ayuda,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 456);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(960, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // Jugar
            // 
            this.Jugar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Jugar.Font = new System.Drawing.Font("Showcard Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Jugar.Image = ((System.Drawing.Image)(resources.GetObject("Jugar.Image")));
            this.Jugar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Jugar.Name = "Jugar";
            this.Jugar.Size = new System.Drawing.Size(48, 22);
            this.Jugar.Text = "Jugar";
            this.Jugar.Click += new System.EventHandler(this.Jugar_Click);
            // 
            // Ayuda
            // 
            this.Ayuda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Ayuda.Image = ((System.Drawing.Image)(resources.GetObject("Ayuda.Image")));
            this.Ayuda.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Ayuda.Name = "Ayuda";
            this.Ayuda.Size = new System.Drawing.Size(45, 22);
            this.Ayuda.Text = "Ayuda";
            this.Ayuda.Click += new System.EventHandler(this.Ayuda_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(55, 22);
            this.toolStripButton1.Text = "Creditos";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("AR CENA", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(410, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(136, 52);
            this.button1.TabIndex = 2;
            this.button1.Text = "Jugar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Jugar_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("AR CENA", 15.75F, System.Drawing.FontStyle.Bold);
            this.button2.Location = new System.Drawing.Point(410, 129);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 52);
            this.button2.TabIndex = 3;
            this.button2.Text = "Ayuda";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Ayuda_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("AR CENA", 15.75F, System.Drawing.FontStyle.Bold);
            this.button3.Location = new System.Drawing.Point(410, 214);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(136, 48);
            this.button3.TabIndex = 4;
            this.button3.Text = "Creditos";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // Puntos
            // 
            this.Puntos.AutoSize = true;
            this.Puntos.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Puntos.Font = new System.Drawing.Font("Papyrus", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Puntos.Location = new System.Drawing.Point(90, 9);
            this.Puntos.Name = "Puntos";
            this.Puntos.Size = new System.Drawing.Size(62, 18);
            this.Puntos.TabIndex = 5;
            this.Puntos.Text = "Puntos: 0";
            this.Puntos.Visible = false;
            // 
            // IngresaNombre
            // 
            this.IngresaNombre.Location = new System.Drawing.Point(172, 459);
            this.IngresaNombre.Name = "IngresaNombre";
            this.IngresaNombre.Size = new System.Drawing.Size(201, 20);
            this.IngresaNombre.TabIndex = 6;
            this.IngresaNombre.Text = "Nombre";
            this.IngresaNombre.Visible = false;
            // 
            // Iniciar
            // 
            this.Iniciar.Location = new System.Drawing.Point(379, 457);
            this.Iniciar.Name = "Iniciar";
            this.Iniciar.Size = new System.Drawing.Size(75, 23);
            this.Iniciar.TabIndex = 7;
            this.Iniciar.Text = "Iniciar";
            this.Iniciar.UseVisualStyleBackColor = true;
            this.Iniciar.Visible = false;
            this.Iniciar.Click += new System.EventHandler(this.Iniciar_Click);
            // 
            // Records
            // 
            this.Records.Font = new System.Drawing.Font("AR CENA", 15.75F, System.Drawing.FontStyle.Bold);
            this.Records.Location = new System.Drawing.Point(410, 294);
            this.Records.Name = "Records";
            this.Records.Size = new System.Drawing.Size(136, 48);
            this.Records.TabIndex = 8;
            this.Records.Text = "Records";
            this.Records.UseVisualStyleBackColor = true;
            this.Records.Click += new System.EventHandler(this.Records_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(960, 481);
            this.Controls.Add(this.Records);
            this.Controls.Add(this.Iniciar);
            this.Controls.Add(this.IngresaNombre);
            this.Controls.Add(this.Puntos);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.Vida);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label Vida;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Jugar;
        private System.Windows.Forms.ToolStripButton Ayuda;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label Puntos;
        private System.Windows.Forms.TextBox IngresaNombre;
        private System.Windows.Forms.Button Iniciar;
        private System.Windows.Forms.Button Records;

    }
}

