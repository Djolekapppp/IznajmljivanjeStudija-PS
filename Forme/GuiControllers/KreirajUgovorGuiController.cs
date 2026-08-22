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

        public Control CreateKreirajUgovor(Zaposleni ulogovaniZaposleni, Ugovor selected_ugovor = null)
        {
            this.ulogovaniZaposleni = ulogovaniZaposleni;
            ugovor = selected_ugovor;
            
            ucKreirajUgovor = new UCKreirajUgovor();
            ucKreirajUgovor.btnKreirajUgovor.Click += BtnKreirajUgovor_Click;
            ucKreirajUgovor.btnSacuvajUgovor.Click += BtnSacuvajUgovor_Click;
            ucKreirajUgovor.btnOtkazi.Click += BtnOtkazi_Click;

            ucKreirajUgovor.dgvStavke.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ucKreirajUgovor.dgvStavke.MultiSelect = false;
            ucKreirajUgovor.dgvStavke.CellDoubleClick += DgvStavke_CellDoubleClick;

            // If ugovor is provided, load it; otherwise start with disabled mode
            if (ugovor != null)
            {
                SrediFormu(FormMode.Edit);
                LoadUgovorData();
            }
            else
            {
                SrediFormu(FormMode.Disabled);
            }

            return ucKreirajUgovor;
        }

        private void LoadUgovorData()
        {
            if (ugovor == null) return;
            
            try
            {
                ucKreirajUgovor.cbBendovi.SelectedIndex =
                    ucKreirajUgovor.cbBendovi.Items.Cast<Bend>()
                        .ToList()
                        .FindIndex(b => b.Id == ugovor.Bend.Id);

                ucKreirajUgovor.txtZaposleni.Text = ugovor.Zaposleni.Ime;
                ucKreirajUgovor.txtIznos.Text = ugovor.UkupnaCena.ToString();

                PodesiDgvStavke();

                ucKreirajUgovor.cbBendovi.Enabled = false;
                ucKreirajUgovor.btnKreirajUgovor.Enabled = false;
                ucKreirajUgovor.btnSacuvajUgovor.Enabled = true;
                ucKreirajUgovor.btnOtkazi.Enabled = true;

                ShowStavkaUC(FormMode.Add, ugovor);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska pri ucitavanju ugovora: " + ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvStavke_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < ugovor.StavkeUgovora.Count)
            {
                StavkaUgovora stavka = ugovor.StavkeUgovora[e.RowIndex];
                ShowStavkaUC(FormMode.Edit, ugovor, stavka);
            }
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
                var confirm = MessageBox.Show("Da li ste sigurni da zelite da obrisete ugovor?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                ugovor.DeleteCondition = $"WHERE IdUgovor = {ugovor.Id}";
                try
                {
                    Odgovor odgovor = Komunikacija.Instance.ObrisiUgovor(ugovor);
                    if (odgovor.Uspesno == true)
                    {
                        MessageBox.Show("Sistem je obrisao ugovor", "Uspesno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ugovor = null;
                        ucKreirajUgovor.cbBendovi.Enabled = true;
                        ucKreirajUgovor.btnKreirajUgovor.Enabled = true;
                        ucKreirajUgovor.btnSacuvajUgovor.Enabled = false;
                        ucKreirajUgovor.btnOtkazi.Enabled = false;
                        ShowStavkaUC(FormMode.Disabled, null);
                        ucKreirajUgovor.dgvStavke.DataSource = null;
                    }
                    else
                    {
                        MessageBox.Show("Sistem ne moze da obrise ugovor: " + odgovor.Greska, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Greska pri brisanju ugovora: " + ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Mozete obrisati samo ugovor bez stavki!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSacuvajUgovor_Click(object? sender, EventArgs e)
        {
            try
            {
                if (ugovor == null)
                {
                    MessageBox.Show("Nema ucitanog ugovora za cuvanje!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (ugovor.StavkeUgovora.Count == 0)
                {
                    MessageBox.Show("Ne mozete sacuvati ugovor bez stavki!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // If this is an existing ugovor (has Id), update it; otherwise create it
                if (ugovor.Id > 0)
                {
                    Komunikacija.Instance.PromeniUgovor(ugovor);
                    MessageBox.Show("Sistem je zapamtio ugovor", "Uspesno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ugovor.InsertCondition = $"output inserted.IdUgovor values({ugovor.Values})";
                    int id = Komunikacija.Instance.KreirajUgovor(ugovor);
                    ugovor.Id = id;
                    MessageBox.Show("Sistem je kreirao ugovor", "Uspesno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ucKreirajUgovor.cbBendovi.Enabled = true;
                ucKreirajUgovor.btnKreirajUgovor.Enabled = true;
                ucKreirajUgovor.btnSacuvajUgovor.Enabled = false;
                ucKreirajUgovor.btnOtkazi.Enabled = false;
                SrediFormu(FormMode.Disabled);
                ucKreirajUgovor.dgvStavke.DataSource = null;
                ugovor = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska pri cuvanju ugovora: " + ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                ugovor = null;
                return;
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
                MessageBox.Show("Sistem ne moze da kreira ugovor: " + ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ugovor = null;
            }
        }

        private void PodesiDgvStavke()
        {
            if (ugovor == null) return;

            ucKreirajUgovor.dgvStavke.DataSource = ugovor.StavkeUgovora;
            
            // Hide internal columns
            ucKreirajUgovor.dgvStavke.Columns["IdUgovor"].Visible = false;
            ucKreirajUgovor.dgvStavke.Columns["RB"].Visible = false;
            ucKreirajUgovor.dgvStavke.Columns["TableName"].Visible = false;
            ucKreirajUgovor.dgvStavke.Columns["Values"].Visible = false;
            ucKreirajUgovor.dgvStavke.Columns["Join"].Visible = false;
            
            if (ucKreirajUgovor.dgvStavke.Columns.Contains("Set"))
                ucKreirajUgovor.dgvStavke.Columns["Set"].Visible = false;
            if (ucKreirajUgovor.dgvStavke.Columns.Contains("SelectCondition"))
                ucKreirajUgovor.dgvStavke.Columns["SelectCondition"].Visible = false;
            if (ucKreirajUgovor.dgvStavke.Columns.Contains("InsertCondition"))
                ucKreirajUgovor.dgvStavke.Columns["InsertCondition"].Visible = false;
            if (ucKreirajUgovor.dgvStavke.Columns.Contains("UpdateCondition"))
                ucKreirajUgovor.dgvStavke.Columns["UpdateCondition"].Visible = false;
            if (ucKreirajUgovor.dgvStavke.Columns.Contains("DeleteCondition"))
                ucKreirajUgovor.dgvStavke.Columns["DeleteCondition"].Visible = false;

            ucKreirajUgovor.dgvStavke.AllowUserToAddRows = false;
            ucKreirajUgovor.dgvStavke.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ucKreirajUgovor.dgvStavke.MultiSelect = false;
            ucKreirajUgovor.dgvStavke.ReadOnly = true;
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
            ShowStavkaUC(mode, ugovor);
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
                MessageBox.Show("Sistem ne moze da vrati bendove: " + ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ucKreirajUgovor.txtZaposleni.Enabled = false;
            ucKreirajUgovor.txtIznos.Enabled = false;

            ucKreirajUgovor.txtZaposleni.Text = ulogovaniZaposleni.Ime;
        }
    }
}
