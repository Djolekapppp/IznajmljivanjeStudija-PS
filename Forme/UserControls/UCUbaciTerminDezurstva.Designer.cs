namespace Forme.UserControls
{
    partial class UCUbaciTerminDezurstva
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
            txtVremeOd = new TextBox();
            txtVremeDo = new TextBox();
            cbSmena = new ComboBox();
            btnUbaci = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(307, 150);
            label1.Name = "label1";
            label1.Size = new Size(275, 28);
            label1.TabIndex = 0;
            label1.Text = "UBACI TERMIN DEZURSTVA";
            label1.UseWaitCursor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(307, 225);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 1;
            label2.Text = "Vreme od:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(307, 262);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 2;
            label3.Text = "Vreme do:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(326, 291);
            label4.Name = "label4";
            label4.Size = new Size(57, 20);
            label4.TabIndex = 3;
            label4.Text = "Smena:";
            // 
            // txtVremeOd
            // 
            txtVremeOd.Location = new Point(389, 222);
            txtVremeOd.Name = "txtVremeOd";
            txtVremeOd.Size = new Size(125, 27);
            txtVremeOd.TabIndex = 4;
            // 
            // txtVremeDo
            // 
            txtVremeDo.Location = new Point(389, 255);
            txtVremeDo.Name = "txtVremeDo";
            txtVremeDo.Size = new Size(125, 27);
            txtVremeDo.TabIndex = 5;
            // 
            // cbSmena
            // 
            cbSmena.FormattingEnabled = true;
            cbSmena.Location = new Point(389, 288);
            cbSmena.Name = "cbSmena";
            cbSmena.Size = new Size(125, 28);
            cbSmena.TabIndex = 6;
            // 
            // btnUbaci
            // 
            btnUbaci.Location = new Point(389, 344);
            btnUbaci.Name = "btnUbaci";
            btnUbaci.Size = new Size(125, 29);
            btnUbaci.TabIndex = 7;
            btnUbaci.Text = "Ubaci";
            btnUbaci.UseVisualStyleBackColor = true;
            // 
            // UCUbaciTerminDezurstva
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnUbaci);
            Controls.Add(cbSmena);
            Controls.Add(txtVremeDo);
            Controls.Add(txtVremeOd);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "UCUbaciTerminDezurstva";
            Size = new Size(982, 622);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        public TextBox txtVremeOd;
        public TextBox txtVremeDo;
        public ComboBox cbSmena;
        public Button btnUbaci;
    }
}
