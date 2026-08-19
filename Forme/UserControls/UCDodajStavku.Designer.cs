namespace Forme.UserControls
{
    partial class UCDodajStavku
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtDatum = new TextBox();
            txtIdUgovor = new TextBox();
            cbStudio = new ComboBox();
            label6 = new Label();
            txtVremeOd = new TextBox();
            txtIznos = new TextBox();
            label7 = new Label();
            txtVremeDo = new TextBox();
            btnDodajStavku = new Button();
            btnUkloniStavku = new Button();
            btnIzmeniStavku = new Button();
            label8 = new Label();
            txtCenaPoSatu = new TextBox();
            btnOmoguciIzmenu = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, 10);
            label1.Name = "label1";
            label1.Size = new Size(113, 20);
            label1.TabIndex = 0;
            label1.Text = "Stavka Ugovora";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(13, 56);
            label2.Name = "label2";
            label2.Size = new Size(85, 20);
            label2.TabIndex = 1;
            label2.Text = "ID Ugovora";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(178, 176);
            label3.Name = "label3";
            label3.Size = new Size(73, 20);
            label3.TabIndex = 2;
            label3.Text = "Vreme od";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(197, 130);
            label4.Name = "label4";
            label4.Size = new Size(54, 20);
            label4.TabIndex = 3;
            label4.Text = "Datum";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(197, 85);
            label5.Name = "label5";
            label5.Size = new Size(52, 20);
            label5.TabIndex = 4;
            label5.Text = "Studio";
            // 
            // txtDatum
            // 
            txtDatum.Location = new Point(257, 127);
            txtDatum.Name = "txtDatum";
            txtDatum.Size = new Size(144, 27);
            txtDatum.TabIndex = 5;
            // 
            // txtIdUgovor
            // 
            txtIdUgovor.Location = new Point(104, 53);
            txtIdUgovor.Name = "txtIdUgovor";
            txtIdUgovor.Size = new Size(58, 27);
            txtIdUgovor.TabIndex = 6;
            txtIdUgovor.TextChanged += txtIdUgovor_TextChanged;
            // 
            // cbStudio
            // 
            cbStudio.FormattingEnabled = true;
            cbStudio.Location = new Point(257, 82);
            cbStudio.Name = "cbStudio";
            cbStudio.Size = new Size(144, 28);
            cbStudio.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(208, 221);
            label6.Name = "label6";
            label6.Size = new Size(43, 20);
            label6.TabIndex = 8;
            label6.Text = "Iznos";
            // 
            // txtVremeOd
            // 
            txtVremeOd.Location = new Point(257, 173);
            txtVremeOd.Name = "txtVremeOd";
            txtVremeOd.Size = new Size(144, 27);
            txtVremeOd.TabIndex = 9;
            // 
            // txtIznos
            // 
            txtIznos.Location = new Point(257, 218);
            txtIznos.Name = "txtIznos";
            txtIznos.Size = new Size(144, 27);
            txtIznos.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(407, 176);
            label7.Name = "label7";
            label7.Size = new Size(27, 20);
            label7.TabIndex = 11;
            label7.Text = "do";
            // 
            // txtVremeDo
            // 
            txtVremeDo.Location = new Point(440, 173);
            txtVremeDo.Name = "txtVremeDo";
            txtVremeDo.Size = new Size(151, 27);
            txtVremeDo.TabIndex = 12;
            // 
            // btnDodajStavku
            // 
            btnDodajStavku.Location = new Point(125, 261);
            btnDodajStavku.Name = "btnDodajStavku";
            btnDodajStavku.Size = new Size(150, 49);
            btnDodajStavku.TabIndex = 13;
            btnDodajStavku.Text = "Dodaj Stavku";
            btnDodajStavku.UseVisualStyleBackColor = true;
            // 
            // btnUkloniStavku
            // 
            btnUkloniStavku.Location = new Point(437, 261);
            btnUkloniStavku.Name = "btnUkloniStavku";
            btnUkloniStavku.Size = new Size(150, 49);
            btnUkloniStavku.TabIndex = 15;
            btnUkloniStavku.Text = "Ukloni Stavku";
            btnUkloniStavku.UseVisualStyleBackColor = true;
            // 
            // btnIzmeniStavku
            // 
            btnIzmeniStavku.Location = new Point(281, 261);
            btnIzmeniStavku.Name = "btnIzmeniStavku";
            btnIzmeniStavku.Size = new Size(150, 30);
            btnIzmeniStavku.TabIndex = 14;
            btnIzmeniStavku.Text = "Izmeni Stavku";
            btnIzmeniStavku.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(440, 56);
            label8.Name = "label8";
            label8.Size = new Size(95, 20);
            label8.TabIndex = 16;
            label8.Text = "Cena po satu";
            // 
            // txtCenaPoSatu
            // 
            txtCenaPoSatu.Location = new Point(440, 82);
            txtCenaPoSatu.Name = "txtCenaPoSatu";
            txtCenaPoSatu.Size = new Size(151, 27);
            txtCenaPoSatu.TabIndex = 17;
            // 
            // btnOmoguciIzmenu
            // 
            btnOmoguciIzmenu.Location = new Point(281, 290);
            btnOmoguciIzmenu.Name = "btnOmoguciIzmenu";
            btnOmoguciIzmenu.Size = new Size(150, 30);
            btnOmoguciIzmenu.TabIndex = 18;
            btnOmoguciIzmenu.Text = "Omoguci Izmenu";
            btnOmoguciIzmenu.UseVisualStyleBackColor = true;
            // 
            // UCDodajStavku
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDark;
            Controls.Add(btnOmoguciIzmenu);
            Controls.Add(txtCenaPoSatu);
            Controls.Add(label8);
            Controls.Add(btnUkloniStavku);
            Controls.Add(btnIzmeniStavku);
            Controls.Add(btnDodajStavku);
            Controls.Add(txtVremeDo);
            Controls.Add(label7);
            Controls.Add(txtIznos);
            Controls.Add(txtVremeOd);
            Controls.Add(label6);
            Controls.Add(cbStudio);
            Controls.Add(txtIdUgovor);
            Controls.Add(txtDatum);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UCDodajStavku";
            Size = new Size(629, 323);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        public TextBox txtDatum;
        public TextBox txtIdUgovor;
        public ComboBox cbStudio;
        public TextBox txtVremeOd;
        public TextBox txtIznos;
        public TextBox txtVremeDo;
        public Button btnDodajStavku;
        public Button btnUkloniStavku;
        public Button btnIzmeniStavku;
        public TextBox txtCenaPoSatu;
        public Button btnOmoguciIzmenu;
    }
}
