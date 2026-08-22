namespace Forme
{
    partial class frmGlavna
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            ugovorToolStripMenuItem = new ToolStripMenuItem();
            kreirajUgovorToolStripMenuItem = new ToolStripMenuItem();
            bendToolStripMenuItem = new ToolStripMenuItem();
            kreirajBendToolStripMenuItem = new ToolStripMenuItem();
            pretražiBendoveToolStripMenuItem = new ToolStripMenuItem();
            terminDežurstvaToolStripMenuItem = new ToolStripMenuItem();
            ubaciTerminDezustvaToolStripMenuItem = new ToolStripMenuItem();
            pnlGlavni = new Panel();
            pretražiUgovoreToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { ugovorToolStripMenuItem, bendToolStripMenuItem, terminDežurstvaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(982, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // ugovorToolStripMenuItem
            // 
            ugovorToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { kreirajUgovorToolStripMenuItem, pretražiUgovoreToolStripMenuItem });
            ugovorToolStripMenuItem.Name = "ugovorToolStripMenuItem";
            ugovorToolStripMenuItem.Size = new Size(72, 24);
            ugovorToolStripMenuItem.Text = "Ugovor";
            // 
            // kreirajUgovorToolStripMenuItem
            // 
            kreirajUgovorToolStripMenuItem.Name = "kreirajUgovorToolStripMenuItem";
            kreirajUgovorToolStripMenuItem.Size = new Size(224, 26);
            kreirajUgovorToolStripMenuItem.Text = "Kreiraj Ugovor";
            // 
            // bendToolStripMenuItem
            // 
            bendToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { kreirajBendToolStripMenuItem, pretražiBendoveToolStripMenuItem });
            bendToolStripMenuItem.Name = "bendToolStripMenuItem";
            bendToolStripMenuItem.Size = new Size(57, 24);
            bendToolStripMenuItem.Text = "Bend";
            // 
            // kreirajBendToolStripMenuItem
            // 
            kreirajBendToolStripMenuItem.Name = "kreirajBendToolStripMenuItem";
            kreirajBendToolStripMenuItem.Size = new Size(204, 26);
            kreirajBendToolStripMenuItem.Text = "Kreiraj Bend";
            // 
            // pretražiBendoveToolStripMenuItem
            // 
            pretražiBendoveToolStripMenuItem.Name = "pretražiBendoveToolStripMenuItem";
            pretražiBendoveToolStripMenuItem.Size = new Size(204, 26);
            pretražiBendoveToolStripMenuItem.Text = "Pretraži Bendove";
            // 
            // terminDežurstvaToolStripMenuItem
            // 
            terminDežurstvaToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ubaciTerminDezustvaToolStripMenuItem });
            terminDežurstvaToolStripMenuItem.Name = "terminDežurstvaToolStripMenuItem";
            terminDežurstvaToolStripMenuItem.Size = new Size(137, 24);
            terminDežurstvaToolStripMenuItem.Text = "Termin Dežurstva";
            // 
            // ubaciTerminDezustvaToolStripMenuItem
            // 
            ubaciTerminDezustvaToolStripMenuItem.Name = "ubaciTerminDezustvaToolStripMenuItem";
            ubaciTerminDezustvaToolStripMenuItem.Size = new Size(248, 26);
            ubaciTerminDezustvaToolStripMenuItem.Text = "Ubaci Termin Dežurstva";
            // 
            // pnlGlavni
            // 
            pnlGlavni.Location = new Point(0, 31);
            pnlGlavni.Name = "pnlGlavni";
            pnlGlavni.Size = new Size(982, 622);
            pnlGlavni.TabIndex = 1;
            // 
            // pretražiUgovoreToolStripMenuItem
            // 
            pretražiUgovoreToolStripMenuItem.Name = "pretražiUgovoreToolStripMenuItem";
            pretražiUgovoreToolStripMenuItem.Size = new Size(224, 26);
            pretražiUgovoreToolStripMenuItem.Text = "Pretraži Ugovore";
            // 
            // frmGlavna
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 653);
            Controls.Add(pnlGlavni);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "frmGlavna";
            Text = "Form1";
            FormClosed += frmGlavna_FormClosed;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem ugovorToolStripMenuItem;
        private ToolStripMenuItem kreirajUgovorToolStripMenuItem;
        public Panel pnlGlavni;
        private ToolStripMenuItem bendToolStripMenuItem;
        private ToolStripMenuItem kreirajBendToolStripMenuItem;
        private ToolStripMenuItem pretražiBendoveToolStripMenuItem;
        private ToolStripMenuItem terminDežurstvaToolStripMenuItem;
        private ToolStripMenuItem ubaciTerminDezustvaToolStripMenuItem;
        private ToolStripMenuItem pretražiUgovoreToolStripMenuItem;
    }
}