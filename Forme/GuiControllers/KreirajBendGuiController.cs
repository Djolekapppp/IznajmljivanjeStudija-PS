using Common.Domen;
using Forme.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forme.GuiControllers
{
    public class KreirajBendGuiController
    {
        private static KreirajBendGuiController instance;

        public static KreirajBendGuiController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KreirajBendGuiController();
                }
                return instance;
            }
        }
        private KreirajBendGuiController()
        {
        }

        private UCKreirajBend ucKreirajBend;
        private Bend bend;

        internal Control CreateKreirajBend(Bend bend = null)
        {
            this.bend = bend;
            ucKreirajBend = new UCKreirajBend();
            if (this.bend == null)
            {
                Disable();
            } else
            {
                Enable();
                ucKreirajBend.btnKreirajBend.Visible = false;
                FillForm();
            }
            ucKreirajBend.btnKreirajBend.Click += BtnKreirajBend_Click;
            ucKreirajBend.btnSacuvajBend.Click += BtnSacuvajBend_Click;
            ucKreirajBend.btnOtkazi.Click += BtnOtkazi_Click;
            return ucKreirajBend;
        }

        private void BtnOtkazi_Click(object? sender, EventArgs e)
        {
            try
            {
                bend.DeleteCondition = $"WHERE IdBend={bend.Id}";
                Komunikacija.Instance.ObrisiBend(bend);
                MessageBox.Show("Uspešno obrisan bend", "Uspešno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                Disable();
                ucKreirajBend.btnKreirajBend.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSacuvajBend_Click(object? sender, EventArgs e)
        {
            try
            {
                PostaviBend();
                bend.UpdateCondition = $"WHERE IdBend={bend.Id}";
                Komunikacija.Instance.PromeniBend(bend);
                MessageBox.Show("Uspešno sačuvan bend", "Uspešno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                Disable();
                ucKreirajBend.btnKreirajBend.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne moze da zapamti bend", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PostaviBend()
        {
            if (ucKreirajBend.Validacija())
            {
                int id = bend.Id;
                bend = new Bend()
                {
                    Id = id,
                    Naziv = ucKreirajBend.txtNaziv.Text,
                    Email = ucKreirajBend.txtEmail.Text,
                    BrojClanova = int.Parse(ucKreirajBend.txtBrojClanova.Text),
                    KontaktIme = ucKreirajBend.txtKontaktIme.Text,
                    KontaktTelefon = ucKreirajBend.txtKontaktTelefon.Text,
                    Zanr = (Zanr)ucKreirajBend.cbZanr.SelectedItem
                };
            }
            else
            {
                throw new Exception("Morate postaviti sve podatke o bendu");
            }
        }
        private void BtnKreirajBend_Click(object? sender, EventArgs e)
        {
            try
            {
                bend = new Bend();
                bend.Zanr = ucKreirajBend.cbZanr.SelectedItem as Zanr;
                bend.Email = "nesto@nesto";
                bend.InsertCondition = $"output inserted.IdBend values({bend.Values})";
                bend.Id = Komunikacija.Instance.KreirajBend(bend);
                MessageBox.Show("Uspešno kreiran bend!", "Uspešno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm();
                MessageBox.Show($"ID kreiranog benda je: {bend.Id}", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Enable();
                ucKreirajBend.btnKreirajBend.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne moze da kreira bend", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Enable()
        {
            ucKreirajBend.txtBrojClanova.Enabled = true;
            ucKreirajBend.txtEmail.Enabled = true;
            ucKreirajBend.txtKontaktIme.Enabled = true;
            ucKreirajBend.txtKontaktTelefon.Enabled = true;
            ucKreirajBend.txtNaziv.Enabled = true;
            ucKreirajBend.cbZanr.Enabled = true;
            ucKreirajBend.btnSacuvajBend.Enabled = true;
            ucKreirajBend.btnOtkazi.Enabled = true;
        }

        private void Disable()
        {
            ucKreirajBend.txtBrojClanova.Enabled = false;
            ucKreirajBend.txtEmail.Enabled = false;
            ucKreirajBend.txtKontaktIme.Enabled = false;
            ucKreirajBend.txtKontaktTelefon.Enabled = false;
            ucKreirajBend.txtNaziv.Enabled = false;
            ucKreirajBend.cbZanr.Enabled = false;
            ucKreirajBend.btnSacuvajBend.Enabled = false;
            ucKreirajBend.btnOtkazi.Enabled = false;
        }

        private void FillForm()
        {
            ucKreirajBend.txtNaziv.Text = bend.Naziv;
            ucKreirajBend.txtEmail.Text = bend.Email;
            ucKreirajBend.txtBrojClanova.Text = bend.BrojClanova.ToString();
            ucKreirajBend.txtKontaktIme.Text = bend.KontaktIme;
            ucKreirajBend.txtKontaktTelefon.Text = bend.KontaktTelefon;
            ucKreirajBend.cbZanr.SelectedItem = bend.Zanr;
        }

        private void ClearForm()
        {
            ucKreirajBend.txtNaziv.Clear();
            ucKreirajBend.txtEmail.Clear();
            ucKreirajBend.txtBrojClanova.Clear();
            ucKreirajBend.txtKontaktIme.Clear();
            ucKreirajBend.txtKontaktTelefon.Clear();
            ucKreirajBend.cbZanr.SelectedIndex = -1;
        }
    }
}
