using Common.Domen;
using Common.Komunikacija;
using Forme.UserControls;
using Forme.Utils;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Forme.GuiControllers
{
    internal class KreirajUgovorGuiController
    {
        private static KreirajUgovorGuiController instance;

        public static KreirajUgovorGuiController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new KreirajUgovorGuiController();
                }
                return instance;
            }
        }

        private KreirajUgovorGuiController()
        {
        }

        private Ugovor ugovor;
        private UCKreirajUgovor ucKreirajUgovor;
        public Zaposleni ulogovaniZaposleni;

        public Control CreateKreirajUgovor(Zaposleni ulogovaniZaposleni)
        {
            this.ulogovaniZaposleni = ulogovaniZaposleni;
            ucKreirajUgovor = new UCKreirajUgovor();
            ucKreirajUgovor.btnKreirajUgovor.Click += BtnKreirajUgovor_Click;
            ucKreirajUgovor.btnSacuvajUgovor.Click += BtnSacuvajUgovor_Click;
            ucKreirajUgovor.btnOtkazi.Click += BtnOtkazi_Click;
            SrediFormu(FormMode.Disabled);

            ucKreirajUgovor.dgvStavke.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ucKreirajUgovor.dgvStavke.MultiSelect = false;

            return ucKreirajUgovor;
        }

        private void BtnOtkazi_Click(object? sender, EventArgs e)
        {
            if (ugovor == null)
            {
                MessageBox.Show("Sistem ne moze da nadje ugovor", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (ugovor.UkupnaCena == 0)
            {
                ugovor.DeleteCondition = $"WHERE IdUgovor = {ugovor.Id}";
                Odgovor odgovor = Komunikacija.Instance.ObrisiUgovor(ugovor);
                if (odgovor.Uspesno == true)
                {
                    MessageBox.Show("Sistem je obrisao ugovor", "Uspesno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ugovor = null;
                    ucKreirajUgovor.cbBendovi.Enabled = true;
                    ucKreirajUgovor.btnKreirajUgovor.Enabled = true;
                    ucKreirajUgovor.btnSacuvajUgovor.Enabled = false;
                    ucKreirajUgovor.btnOtkazi.Enabled = false;
                    ShowStavkaUC(FormMode.Disabled, ugovor);
                    ucKreirajUgovor.dgvStavke.DataSource = null;
                }
                else
                {
                    MessageBox.Show("Sistem ne moze da obrise ugovor", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void BtnSacuvajUgovor_Click(object? sender, EventArgs e)
        {
            try
            {
                if (ugovor.StavkeUgovora.Count != 0)
                {
                    Komunikacija.Instance.PromeniUgovor(ugovor);
                    MessageBox.Show("Sistem je zapamtio ugovor", "Uspesno", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ucKreirajUgovor.cbBendovi.Enabled = true;
                    ucKreirajUgovor.btnKreirajUgovor.Enabled = false;
                    ucKreirajUgovor.btnSacuvajUgovor.Enabled = false;
                    ucKreirajUgovor.btnOtkazi.Enabled = true;
                    SrediFormu(FormMode.Disabled);
                    ucKreirajUgovor.dgvStavke.DataSource = null;
                    ugovor = null;
                }
                else
                {
                    MessageBox.Show("Ne mozete sacuvati ugovor bez stavki!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnKreirajUgovor_Click(object? sender, EventArgs e)
        {
            ugovor = new Ugovor();
            if (ucKreirajUgovor.cbBendovi.SelectedItem != null)
            {
                ugovor.Bend = (Bend)ucKreirajUgovor.cbBendovi.SelectedItem;
            }
            else
            {
                MessageBox.Show("Ugovor nije kreiran, morate odabrati bend!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ugovor.DatumSklapanja = DateTime.Now;
            ugovor.Zaposleni = ulogovaniZaposleni;

            try
            {
                ugovor.InsertCondition = $"output inserted.IdUgovor values({ugovor.Values})";
                int id = Komunikacija.Instance.KreirajUgovor(ugovor);
                ugovor.Id = id;
                MessageBox.Show("Sistem je kreirao ugovor", "Uspesno", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ucKreirajUgovor.cbBendovi.Enabled = false;
                ucKreirajUgovor.btnKreirajUgovor.Enabled = false;
                ucKreirajUgovor.btnSacuvajUgovor.Enabled = true;
                ucKreirajUgovor.btnOtkazi.Enabled = true;
                PodesiDgvStavke();
                ShowStavkaUC(FormMode.Add, ugovor);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne moze da kreira ugovor", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PodesiDgvStavke()
        {
            ucKreirajUgovor.dgvStavke.DataSource = ugovor.StavkeUgovora;
            ucKreirajUgovor.dgvStavke.Columns["IdUgovor"].Visible = false;
            ucKreirajUgovor.dgvStavke.Columns["RB"].Visible = false;
            ucKreirajUgovor.dgvStavke.Columns["TableName"].Visible = false;
            ucKreirajUgovor.dgvStavke.Columns["Values"].Visible = false;
            ucKreirajUgovor.dgvStavke.Columns["Join"].Visible = false;
            ucKreirajUgovor.dgvStavke.Columns["Set"].Visible = false;
            ucKreirajUgovor.dgvStavke.Columns["SelectCondition"].Visible = false;
            ucKreirajUgovor.dgvStavke.Columns["InsertCondition"].Visible = false;
            ucKreirajUgovor.dgvStavke.Columns["UpdateCondition"].Visible = false;
            ucKreirajUgovor.dgvStavke.Columns["DeleteCondition"].Visible = false;

            ucKreirajUgovor.dgvStavke.AllowUserToAddRows = false;
            ucKreirajUgovor.dgvStavke.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ucKreirajUgovor.dgvStavke.MultiSelect = false;
            ucKreirajUgovor.dgvStavke.ReadOnly = true;
            ucKreirajUgovor.dgvStavke.CellDoubleClick += DgvStavke_CellDoubleClick;

        }

        private void DgvStavke_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                StavkaUgovora stavka = (StavkaUgovora)ucKreirajUgovor.dgvStavke.Rows[e.RowIndex].DataBoundItem;

                ShowStavkaUC(FormMode.Edit, ugovor, stavka);
            }
        }

        private void ShowStavkaUC(FormMode mode, Ugovor ugovor = null, StavkaUgovora stavka = null)
        {
            Control control = StavkaGuiController.Instance.CreateDodajStavku(mode, ugovor, stavka);
            ucKreirajUgovor.pnlStavka.Controls.Clear();
            ucKreirajUgovor.pnlStavka.Controls.Add(control);
            control.Dock = DockStyle.Fill;
            ucKreirajUgovor.pnlStavka.AutoSize = false;

        }

        private void SrediFormu(FormMode mode)
        {
            ShowStavkaUC(mode);
            if (mode == FormMode.Disabled)
            {
                ucKreirajUgovor.btnKreirajUgovor.Enabled = true;
                ucKreirajUgovor.btnSacuvajUgovor.Enabled = false;
                ucKreirajUgovor.btnOtkazi.Enabled = false;
            }
            try
            {
                ucKreirajUgovor.cbBendovi.DataSource = Komunikacija.Instance.VratiSveBendove();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne moze da vrati bendove", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ucKreirajUgovor.txtZaposleni.Enabled = false;
            ucKreirajUgovor.txtIznos.Enabled = false;

            ucKreirajUgovor.txtZaposleni.Text = ulogovaniZaposleni.Ime;

        }

    }
}
