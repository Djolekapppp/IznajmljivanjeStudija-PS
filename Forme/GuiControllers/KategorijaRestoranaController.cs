using Common.Domen;
using Forme.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forme.GuiControllers
{
    internal class KategorijaRestoranaController
    {
        private static KategorijaRestoranaController instance;
        public static KategorijaRestoranaController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KategorijaRestoranaController();
                }
                return instance;
            }
        }

        private KategorijaRestoranaController()
        {
        }

        private UCUbaciTerminDezurstva ucUbaciTerminDezurstva;

        internal Control CreateUbaciKategorijaRestorana()
        {
            ucUbaciTerminDezurstva = new UCUbaciTerminDezurstva();
            ucUbaciTerminDezurstva.cbSmena.DataSource = Enum.GetValues(typeof(Smena));
            ucUbaciTerminDezurstva.cbSmena.SelectedIndex = -1;
            ucUbaciTerminDezurstva.btnUbaci.Click += BtnUbaci_Click;
            return ucUbaciTerminDezurstva;
        }

        private void BtnUbaci_Click(object? sender, EventArgs e)
        {
            if (TimeSpan.TryParse(ucUbaciTerminDezurstva.txtVremeOd.Text, out TimeSpan vremeOd) &&
                TimeSpan.TryParse(ucUbaciTerminDezurstva.txtVremeDo.Text, out TimeSpan vremeDo) &&
                ucUbaciTerminDezurstva.cbSmena.SelectedIndex != -1)
            {
                TerminDezurstva termin = new TerminDezurstva
                {
                    VremeOd = vremeOd,
                    VremeDo = vremeDo,
                    Smena = (Smena)ucUbaciTerminDezurstva.cbSmena.SelectedItem
                };
                try
                {
                    Komunikacija.Instance.UbaciTerminDezurstva(termin);
                    MessageBox.Show("Sistem je zapamtio termin dezurstva", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                } catch
                {
                    MessageBox.Show("Sistem ne moze da zapamti termin dežurstva", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Morate pravilno uneti sve podatke", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
