using Common.Domen;
using Forme.GuiControllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forme
{
    public partial class frmGlavna : Form
    {
        private Zaposleni ulogovaniKorisnik;

        public frmGlavna(Zaposleni k)
        {
            ulogovaniKorisnik = k;
            InitializeComponent();
            this.Text = $"Glavna Forma: {ulogovaniKorisnik.Ime}";
            kreirajUgovorToolStripMenuItem.Click += MainCoordinator.Instance.ShowDodajUgovorPanel;
            kreirajBendToolStripMenuItem.Click += MainCoordinator.Instance.ShowDodajBendPanel;
            pretražiBendoveToolStripMenuItem.Click += MainCoordinator.Instance.ShowPretraziBendPanel;
            ubaciTerminDezustvaToolStripMenuItem.Click += MainCoordinator.Instance.ShowUbaciTerminDezurstvaPanel;
        }

        public void ChangePanel(Control control)
        {
            pnlGlavni.Controls.Clear();
            pnlGlavni.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            pnlGlavni.AutoSize = false;
            pnlGlavni.Refresh();
        }

        private void frmGlavna_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
