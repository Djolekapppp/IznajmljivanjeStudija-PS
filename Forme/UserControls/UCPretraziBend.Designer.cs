namespace Forme.UserControls
{
    partial class UCPretraziBend
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
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            txtBrojClanova = new TextBox();
            txtKontaktTelefon = new TextBox();
            txtKontaktIme = new TextBox();
            txtEmail = new TextBox();
            label3 = new Label();
            cbZanr = new ComboBox();
            txtNaziv = new TextBox();
            label2 = new Label();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            dgvBendovi = new DataGridView();
            btnVratiBendove = new Button();
            btnPromeniBend = new Button();
            btnPretraziBend = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvBendovi).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(182, 36);
            label1.Name = "label1";
            label1.Size = new Size(127, 28);
            label1.TabIndex = 0;
            label1.Text = "Pretraži Bend";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(133, 303);
            label7.Name = "label7";
            label7.Size = new Size(39, 20);
            label7.TabIndex = 24;
            label7.Text = "Žanr";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(16, 261);
            label6.Name = "label6";
            label6.Size = new Size(160, 20);
            label6.TabIndex = 23;
            label6.Text = "Broj Telefona Kontakta";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(79, 219);
            label5.Name = "label5";
            label5.Size = new Size(97, 20);
            label5.TabIndex = 22;
            label5.Text = "Ime Kontakta";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(83, 177);
            label4.Name = "label4";
            label4.Size = new Size(93, 20);
            label4.TabIndex = 21;
            label4.Text = "Broj Članova";
            // 
            // txtBrojClanova
            // 
            txtBrojClanova.Location = new Point(182, 174);
            txtBrojClanova.Name = "txtBrojClanova";
            txtBrojClanova.Size = new Size(151, 27);
            txtBrojClanova.TabIndex = 20;
            // 
            // txtKontaktTelefon
            // 
            txtKontaktTelefon.Location = new Point(182, 258);
            txtKontaktTelefon.Name = "txtKontaktTelefon";
            txtKontaktTelefon.Size = new Size(151, 27);
            txtKontaktTelefon.TabIndex = 19;
            // 
            // txtKontaktIme
            // 
            txtKontaktIme.Location = new Point(182, 216);
            txtKontaktIme.Name = "txtKontaktIme";
            txtKontaktIme.Size = new Size(151, 27);
            txtKontaktIme.TabIndex = 18;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(182, 132);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(151, 27);
            txtEmail.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(126, 135);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 16;
            label3.Text = "Email";
            // 
            // cbZanr
            // 
            cbZanr.FormattingEnabled = true;
            cbZanr.Location = new Point(182, 300);
            cbZanr.Name = "cbZanr";
            cbZanr.Size = new Size(151, 28);
            cbZanr.TabIndex = 15;
            // 
            // txtNaziv
            // 
            txtNaziv.Location = new Point(182, 89);
            txtNaziv.Name = "txtNaziv";
            txtNaziv.Size = new Size(151, 27);
            txtNaziv.TabIndex = 14;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(126, 92);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 13;
            label2.Text = "Naziv";
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // dgvBendovi
            // 
            dgvBendovi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBendovi.Location = new Point(354, 89);
            dgvBendovi.MultiSelect = false;
            dgvBendovi.Name = "dgvBendovi";
            dgvBendovi.ReadOnly = true;
            dgvBendovi.RowHeadersWidth = 51;
            dgvBendovi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBendovi.Size = new Size(613, 239);
            dgvBendovi.TabIndex = 25;
            // 
            // btnVratiBendove
            // 
            btnVratiBendove.Location = new Point(182, 343);
            btnVratiBendove.Name = "btnVratiBendove";
            btnVratiBendove.Size = new Size(151, 45);
            btnVratiBendove.TabIndex = 26;
            btnVratiBendove.Text = "Vrati Bendove";
            btnVratiBendove.UseVisualStyleBackColor = true;
            // 
            // btnPromeniBend
            // 
            btnPromeniBend.Location = new Point(559, 343);
            btnPromeniBend.Name = "btnPromeniBend";
            btnPromeniBend.Size = new Size(201, 45);
            btnPromeniBend.TabIndex = 28;
            btnPromeniBend.Text = "Promeni Bend";
            btnPromeniBend.UseVisualStyleBackColor = true;
            // 
            // btnPretraziBend
            // 
            btnPretraziBend.Location = new Point(354, 343);
            btnPretraziBend.Name = "btnPretraziBend";
            btnPretraziBend.Size = new Size(199, 45);
            btnPretraziBend.TabIndex = 29;
            btnPretraziBend.Text = "Pretrazi Bend";
            btnPretraziBend.UseVisualStyleBackColor = true;
            // 
            // UCPretraziBend
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnPretraziBend);
            Controls.Add(btnPromeniBend);
            Controls.Add(btnVratiBendove);
            Controls.Add(dgvBendovi);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtBrojClanova);
            Controls.Add(txtKontaktTelefon);
            Controls.Add(txtKontaktIme);
            Controls.Add(txtEmail);
            Controls.Add(label3);
            Controls.Add(cbZanr);
            Controls.Add(txtNaziv);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UCPretraziBend";
            Size = new Size(982, 622);
            ((System.ComponentModel.ISupportInitialize)dgvBendovi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        public TextBox txtBrojClanova;
        public TextBox txtKontaktTelefon;
        public TextBox txtKontaktIme;
        public TextBox txtEmail;
        public Label label3;
        public ComboBox cbZanr;
        public TextBox txtNaziv;
        private Label label2;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        public Button btnVratiBendove;
        public Button btnObrisiBend;
        public Button btnPromeniBend;
        public DataGridView dgvBendovi;
        public Button btnPretraziBend;
    }
}
