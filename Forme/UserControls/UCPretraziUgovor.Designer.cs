namespace Forme.UserControls
{
    partial class UCPretraziUgovor
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
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            txtUkupnaCena = new TextBox();
            cbBend = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            cbZaposleni = new ComboBox();
            dgvUgovor = new DataGridView();
            btnVratiUgovore = new Button();
            btnPretraziUgovor = new Button();
            btnPromeniUgovor = new Button();
            label3 = new Label();
            cbStudio = new ComboBox();
            label4 = new Label();
            txtBrojSati = new TextBox();
            dgvStavke = new DataGridView();
            btnPretraziStavku = new Button();
            btnVratiStavke = new Button();
            dtpDatumSklapanja = new DateTimePicker();
            label8 = new Label();
            txtIznos = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvUgovor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvStavke).BeginInit();
            SuspendLayout();
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(160, 126);
            label7.Name = "label7";
            label7.Size = new Size(46, 20);
            label7.TabIndex = 30;
            label7.Text = "Bend:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(3, 195);
            label6.Name = "label6";
            label6.Size = new Size(123, 20);
            label6.TabIndex = 29;
            label6.Text = "Datum sklapanja:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(109, 228);
            label5.Name = "label5";
            label5.Size = new Size(97, 20);
            label5.TabIndex = 28;
            label5.Text = "Ukupna cena:";
            // 
            // txtUkupnaCena
            // 
            txtUkupnaCena.Location = new Point(215, 225);
            txtUkupnaCena.Name = "txtUkupnaCena";
            txtUkupnaCena.Size = new Size(151, 27);
            txtUkupnaCena.TabIndex = 26;
            // 
            // cbBend
            // 
            cbBend.FormattingEnabled = true;
            cbBend.Location = new Point(215, 119);
            cbBend.Name = "cbBend";
            cbBend.Size = new Size(151, 28);
            cbBend.TabIndex = 25;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(69, 59);
            label1.Name = "label1";
            label1.Size = new Size(195, 28);
            label1.TabIndex = 31;
            label1.Text = "PRETRAŽI UGOVOR";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(132, 156);
            label2.Name = "label2";
            label2.Size = new Size(77, 20);
            label2.TabIndex = 33;
            label2.Text = "Zaposleni:";
            // 
            // cbZaposleni
            // 
            cbZaposleni.FormattingEnabled = true;
            cbZaposleni.Location = new Point(215, 153);
            cbZaposleni.Name = "cbZaposleni";
            cbZaposleni.Size = new Size(151, 28);
            cbZaposleni.TabIndex = 32;
            // 
            // dgvUgovor
            // 
            dgvUgovor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUgovor.Location = new Point(382, 59);
            dgvUgovor.Name = "dgvUgovor";
            dgvUgovor.RowHeadersWidth = 51;
            dgvUgovor.Size = new Size(568, 240);
            dgvUgovor.TabIndex = 34;
            // 
            // btnVratiUgovore
            // 
            btnVratiUgovore.Location = new Point(69, 270);
            btnVratiUgovore.Name = "btnVratiUgovore";
            btnVratiUgovore.Size = new Size(137, 29);
            btnVratiUgovore.TabIndex = 35;
            btnVratiUgovore.Text = "Vrati ugovore";
            btnVratiUgovore.UseVisualStyleBackColor = true;
            // 
            // btnPretraziUgovor
            // 
            btnPretraziUgovor.Location = new Point(229, 270);
            btnPretraziUgovor.Name = "btnPretraziUgovor";
            btnPretraziUgovor.Size = new Size(137, 29);
            btnPretraziUgovor.TabIndex = 36;
            btnPretraziUgovor.Text = "Pretrazi ugovor";
            btnPretraziUgovor.UseVisualStyleBackColor = true;
            // 
            // btnPromeniUgovor
            // 
            btnPromeniUgovor.Location = new Point(147, 305);
            btnPromeniUgovor.Name = "btnPromeniUgovor";
            btnPromeniUgovor.Size = new Size(137, 29);
            btnPromeniUgovor.TabIndex = 37;
            btnPromeniUgovor.Text = "Promeni ugovor";
            btnPromeniUgovor.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(154, 385);
            label3.Name = "label3";
            label3.Size = new Size(55, 20);
            label3.TabIndex = 41;
            label3.Text = "Studio:";
            // 
            // cbStudio
            // 
            cbStudio.FormattingEnabled = true;
            cbStudio.Location = new Point(215, 382);
            cbStudio.Name = "cbStudio";
            cbStudio.Size = new Size(151, 28);
            cbStudio.TabIndex = 40;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(143, 424);
            label4.Name = "label4";
            label4.Size = new Size(66, 20);
            label4.TabIndex = 39;
            label4.Text = "Broj sati:";
            // 
            // txtBrojSati
            // 
            txtBrojSati.Location = new Point(215, 421);
            txtBrojSati.Name = "txtBrojSati";
            txtBrojSati.Size = new Size(151, 27);
            txtBrojSati.TabIndex = 38;
            // 
            // dgvStavke
            // 
            dgvStavke.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStavke.Location = new Point(382, 379);
            dgvStavke.Name = "dgvStavke";
            dgvStavke.RowHeadersWidth = 51;
            dgvStavke.Size = new Size(568, 206);
            dgvStavke.TabIndex = 42;
            // 
            // btnPretraziStavku
            // 
            btnPretraziStavku.Location = new Point(229, 507);
            btnPretraziStavku.Name = "btnPretraziStavku";
            btnPretraziStavku.Size = new Size(137, 29);
            btnPretraziStavku.TabIndex = 44;
            btnPretraziStavku.Text = "Pretrazi stavku";
            btnPretraziStavku.UseVisualStyleBackColor = true;
            // 
            // btnVratiStavke
            // 
            btnVratiStavke.Location = new Point(69, 507);
            btnVratiStavke.Name = "btnVratiStavke";
            btnVratiStavke.Size = new Size(137, 29);
            btnVratiStavke.TabIndex = 43;
            btnVratiStavke.Text = "Vrati stavke";
            btnVratiStavke.UseVisualStyleBackColor = true;
            // 
            // dtpDatumSklapanja
            // 
            dtpDatumSklapanja.CustomFormat = "";
            dtpDatumSklapanja.Location = new Point(132, 190);
            dtpDatumSklapanja.Name = "dtpDatumSklapanja";
            dtpDatumSklapanja.ShowCheckBox = true;
            dtpDatumSklapanja.Size = new Size(234, 27);
            dtpDatumSklapanja.TabIndex = 46;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(143, 457);
            label8.Name = "label8";
            label8.Size = new Size(46, 20);
            label8.TabIndex = 48;
            label8.Text = "Iznos:";
            // 
            // txtIznos
            // 
            txtIznos.Location = new Point(215, 454);
            txtIznos.Name = "txtIznos";
            txtIznos.Size = new Size(151, 27);
            txtIznos.TabIndex = 47;
            // 
            // UCPretraziUgovor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label8);
            Controls.Add(txtIznos);
            Controls.Add(dtpDatumSklapanja);
            Controls.Add(btnPretraziStavku);
            Controls.Add(btnVratiStavke);
            Controls.Add(dgvStavke);
            Controls.Add(label3);
            Controls.Add(cbStudio);
            Controls.Add(label4);
            Controls.Add(txtBrojSati);
            Controls.Add(btnPromeniUgovor);
            Controls.Add(btnPretraziUgovor);
            Controls.Add(btnVratiUgovore);
            Controls.Add(dgvUgovor);
            Controls.Add(label2);
            Controls.Add(cbZaposleni);
            Controls.Add(label1);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(txtUkupnaCena);
            Controls.Add(cbBend);
            Name = "UCPretraziUgovor";
            Size = new Size(982, 622);
            ((System.ComponentModel.ISupportInitialize)dgvUgovor).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvStavke).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Label label7;
        public Label label6;
        public Label label5;
        public TextBox txtUkupnaCena;
        public ComboBox cbBend;
        public Label label1;
        public Label label2;
        public ComboBox cbZaposleni;
        public DataGridView dgvUgovor;
        public Button btnVratiUgovore;
        public Button btnPretraziUgovor;
        public Button btnPromeniUgovor;
        public Label label3;
        public ComboBox cbStudio;
        public Label label4;
        public TextBox txtBrojSati;
        public DataGridView dgvStavke;
        public Button btnPretraziStavku;
        public Button btnVratiStavke;
        public DateTimePicker dtpDatumSklapanja;
        public Label label8;
        public TextBox txtIznos;
    }
}
