using Common.Domen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Forme.UserControls
{
    public partial class UCKreirajBend : UserControl
    {
        public UCKreirajBend()
        {
            InitializeComponent();
            BindingList<Zanr> zanrovi = new BindingList<Zanr>((List<Zanr>)Komunikacija.Instance.VratiListuSviZanr());
            cbZanr.DataSource = zanrovi;
            btnOtkazi.Enabled = false;
            //btnOtkazi.Visible = false;
            btnSacuvajBend.Enabled = false;
            //btnSacuvajBend.Visible = false;

        }

        public bool Validacija()
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                txtEmail.BackColor = Color.Salmon;
                return false;
            }
            if (string.IsNullOrEmpty(txtNaziv.Text))
            {
                txtNaziv.BackColor = Color.Salmon;
                return false;
            }
            if (string.IsNullOrEmpty(txtKontaktIme.Text))
            {
                txtKontaktIme.BackColor = Color.Salmon;
                return false;
            }
            if (string.IsNullOrEmpty(txtKontaktTelefon.Text))
            {
                txtKontaktTelefon.BackColor = Color.Salmon;
                return false;
            }
            if (!int.TryParse(txtBrojClanova.Text, out int brojClanova))
            {
                txtBrojClanova.BackColor = Color.Salmon;
                return false;
            }
            if (brojClanova <= 0)
            {
                txtBrojClanova.BackColor = Color.Salmon;
                return false;
            }
            if (cbZanr.SelectedItem == null)
            {
                return false;
            }
            return true;
        }

    }
}
