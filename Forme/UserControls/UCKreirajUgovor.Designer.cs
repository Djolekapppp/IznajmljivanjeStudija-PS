namespace Forme.UserControls
{
    partial class UCKreirajUgovor
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
            cbBendovi = new ComboBox();
            txtZaposleni = new TextBox();
            txtIznos = new TextBox();
            btnKreirajUgovor = new Button();
            btnSacuvajUgovor = new Button();
            btnOtkazi = new Button();
            dgvStavke = new DataGridView();
            pnlStavka = new Panel();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvStavke).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F);
            label1.Location = new Point(119, 27);
            label1.Name = "label1";
            label1.Size = new Size(134, 25);
            label1.TabIndex = 0;
            label1.Text = "Kreiraj Ugovor";
            // 
            // cbBendovi
            // 
            cbBendovi.FormattingEnabled = true;
            cbBendovi.Location = new Point(119, 86);
            cbBendovi.Name = "cbBendovi";
            cbBendovi.Size = new Size(151, 28);
            cbBendovi.TabIndex = 1;
            // 
            // txtZaposleni
            // 
            txtZaposleni.Location = new Point(119, 120);
            txtZaposleni.Name = "txtZaposleni";
            txtZaposleni.Size = new Size(151, 27);
            txtZaposleni.TabIndex = 2;
            // 
            // txtIznos
            // 
            txtIznos.Location = new Point(119, 153);
            txtIznos.Name = "txtIznos";
            txtIznos.Size = new Size(151, 27);
            txtIznos.TabIndex = 3;
            // 
            // btnKreirajUgovor
            // 
            btnKreirajUgovor.Location = new Point(119, 199);
            btnKreirajUgovor.Name = "btnKreirajUgovor";
            btnKreirajUgovor.Size = new Size(151, 29);
            btnKreirajUgovor.TabIndex = 4;
            btnKreirajUgovor.Text = "Kreiraj Ugovor";
            btnKreirajUgovor.UseVisualStyleBackColor = true;
            // 
            // btnSacuvajUgovor
            // 
            btnSacuvajUgovor.Location = new Point(119, 234);
            btnSacuvajUgovor.Name = "btnSacuvajUgovor";
            btnSacuvajUgovor.Size = new Size(151, 29);
            btnSacuvajUgovor.TabIndex = 5;
            btnSacuvajUgovor.Text = "Sacuvaj Ugovor";
            btnSacuvajUgovor.UseVisualStyleBackColor = true;
            // 
            // btnOtkazi
            // 
            btnOtkazi.Location = new Point(119, 269);
            btnOtkazi.Name = "btnOtkazi";
            btnOtkazi.Size = new Size(151, 29);
            btnOtkazi.TabIndex = 6;
            btnOtkazi.Text = "Obriši";
            btnOtkazi.UseVisualStyleBackColor = true;
            // 
            // dgvStavke
            // 
            dgvStavke.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStavke.Location = new Point(43, 408);
            dgvStavke.Name = "dgvStavke";
            dgvStavke.RowHeadersWidth = 51;
            dgvStavke.Size = new Size(900, 171);
            dgvStavke.TabIndex = 7;
            // 
            // pnlStavka
            // 
            pnlStavka.BorderStyle = BorderStyle.FixedSingle;
            pnlStavka.Location = new Point(314, 50);
            pnlStavka.Name = "pnlStavka";
            pnlStavka.Size = new Size(629, 323);
            pnlStavka.TabIndex = 8;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(70, 89);
            label2.Name = "label2";
            label2.Size = new Size(43, 20);
            label2.TabIndex = 9;
            label2.Text = "Bend";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(43, 123);
            label3.Name = "label3";
            label3.Size = new Size(74, 20);
            label3.TabIndex = 10;
            label3.Text = "Zaposleni";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(70, 156);
            label4.Name = "label4";
            label4.Size = new Size(43, 20);
            label4.TabIndex = 11;
            label4.Text = "Iznos";
            // 
            // UCKreirajUgovor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pnlStavka);
            Controls.Add(dgvStavke);
            Controls.Add(btnOtkazi);
            Controls.Add(btnSacuvajUgovor);
            Controls.Add(btnKreirajUgovor);
            Controls.Add(txtIznos);
            Controls.Add(txtZaposleni);
            Controls.Add(cbBendovi);
            Controls.Add(label1);
            Name = "UCKreirajUgovor";
            Size = new Size(982, 622);
            ((System.ComponentModel.ISupportInitialize)dgvStavke).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        public ComboBox cbBendovi;
        public TextBox txtZaposleni;
        public TextBox txtIznos;
        public Button btnKreirajUgovor;
        public Button btnSacuvajUgovor;
        public Button btnOtkazi;
        public DataGridView dgvStavke;
        public Panel pnlStavka;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}
