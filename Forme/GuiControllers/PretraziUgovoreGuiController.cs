using Common.Domen;
using Forme.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forme.GuiControllers
{
    internal class PretraziUgovoreGuiController
    {
        private static PretraziUgovoreGuiController instance;

        public static PretraziUgovoreGuiController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PretraziUgovoreGuiController();
                }
                return instance;
            }
        }

        private PretraziUgovoreGuiController()
        {
        }

        private UCPretraziUgovor ucPretraziUgovor;
        private List<Ugovor> ugovori;
        private Ugovor selected_ugovor;
        private BindingList<StavkaUgovora> stavkeUgovora;

        internal Control CreatePretraziUgovor()
        {
            ucPretraziUgovor = new UCPretraziUgovor();
            ucPretraziUgovor.btnVratiUgovore.Click += BtnVratiUgovore_Click;
            ucPretraziUgovor.btnPretraziUgovor.Click += BtnPretraziUgovor_Click;
            ucPretraziUgovor.btnPromeniUgovor.Click += BtnPromeniUgovor_Click;
            ucPretraziUgovor.btnPromeniUgovor.Enabled = false;
            FillComboBoxes();
            return ucPretraziUgovor;
        }
        private void FillForm()
        {
            for (int i = 0; i < ucPretraziUgovor.cbBend.Items.Count; i++)
            {
                Bend bend = (Bend)ucPretraziUgovor.cbBend.Items[i];

                if (bend.Id == selected_ugovor.Bend.Id)
                {
                    ucPretraziUgovor.cbBend.SelectedIndex = i;
                    break;
                }
            }

            for (int i = 0; i < ucPretraziUgovor.cbZaposleni.Items.Count; i++)
            {
                Zaposleni zaposleni = (Zaposleni)ucPretraziUgovor.cbZaposleni.Items[i];

                if (zaposleni.Id == selected_ugovor.Zaposleni.Id)
                {
                    ucPretraziUgovor.cbZaposleni.SelectedIndex = i;
                    break;
                }
            }

            ucPretraziUgovor.dtpDatumSklapanja.Value =
                selected_ugovor.DatumSklapanja;

            ucPretraziUgovor.dtpDatumSklapanja.Checked = true;

            ucPretraziUgovor.txtUkupnaCena.Text =
                selected_ugovor.UkupnaCena.ToString();
        }
        private void FillComboBoxes()
        {
            try
            {
                List<Bend> bendovi = Komunikacija.Instance.VratiSveBendove();
                bendovi.Insert(0, new Bend
                {
                    Id = -1,
                    Naziv = "Svi bendovi",
                    Zanr = new Zanr { Id = -1 }
                });

                List<Zaposleni> zaposleni = Komunikacija.Instance.VratiSveZaposlene();
                zaposleni.Insert(0, new Zaposleni
                {
                    Id = -1,
                    Ime = "Svi",
                    Prezime = "zaposleni"
                });

                ucPretraziUgovor.cbBend.DataSource = bendovi;
                ucPretraziUgovor.cbZaposleni.DataSource = zaposleni;
                ucPretraziUgovor.cbStudio.DataSource = Komunikacija.Instance.VratiSveStudije();

                ucPretraziUgovor.cbBend.SelectedIndex = 0;
                ucPretraziUgovor.cbZaposleni.SelectedIndex = 0;
                ucPretraziUgovor.cbStudio.SelectedIndex = -1;

                ucPretraziUgovor.dtpDatumSklapanja.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Sistem ne moze da ucita podatke",
                    "Greska",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void BtnPretraziUgovor_Click(object? sender, EventArgs e)
        {
            if (ucPretraziUgovor.dgvUgovor.CurrentCell != null)
            {
                int selected_index = ucPretraziUgovor.dgvUgovor.CurrentCell.RowIndex;
                if (selected_index != -1 && selected_index < ugovori.Count)
                {
                    Ugovor ugovorToSearch = ugovori[selected_index];
                    
                    try
                    {
                        ugovorToSearch.SelectCondition = $"WHERE IdUgovor = {ugovorToSearch.Id}";
                        
                        this.selected_ugovor = Komunikacija.Instance.PretraziUgovor(ugovorToSearch);

                        if (this.selected_ugovor == null)
                        {
                            MessageBox.Show("Sistem ne moze da nadje ugovor", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Sistem je nasao ugovor", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ucPretraziUgovor.btnPromeniUgovor.Enabled = true;
                            FillForm();
                            FillDgvStavke(this.selected_ugovor.StavkeUgovora);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Sistem ne moze da nadje ugovor: " + ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Morate na pocetku izabrati ugovor iz tabele!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillDgvStavke(BindingList<StavkaUgovora> stavke)
        {
            stavkeUgovora = stavke;
            ucPretraziUgovor.dgvStavke.DataSource = stavkeUgovora;

            ucPretraziUgovor.dgvStavke.Columns["IdUgovor"].Visible = false;
            ucPretraziUgovor.dgvStavke.Columns["RB"].Visible = false;
            ucPretraziUgovor.dgvStavke.Columns["Set"].Visible = false;
            ucPretraziUgovor.dgvStavke.Columns["InsertCondition"].Visible = false;
            ucPretraziUgovor.dgvStavke.Columns["SelectCondition"].Visible = false;
            ucPretraziUgovor.dgvStavke.Columns["UpdateCondition"].Visible = false;
            ucPretraziUgovor.dgvStavke.Columns["DeleteCondition"].Visible = false;
            ucPretraziUgovor.dgvStavke.Columns["TableName"].Visible = false;
            ucPretraziUgovor.dgvStavke.Columns["Values"].Visible = false;
            ucPretraziUgovor.dgvStavke.Columns["Join"].Visible = false;

            ucPretraziUgovor.dgvStavke.AllowUserToAddRows = false;
            ucPretraziUgovor.dgvStavke.AllowUserToDeleteRows = false;
            ucPretraziUgovor.dgvStavke.ReadOnly = true;
            ucPretraziUgovor.dgvStavke.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ucPretraziUgovor.dgvStavke.MultiSelect = false;

            ucPretraziUgovor.btnPretraziStavku.Click -= BtnPretraziStavku_Click;
            ucPretraziUgovor.btnPretraziStavku.Click += BtnPretraziStavku_Click;
            
            ucPretraziUgovor.btnVratiStavke.Click -= BtnVratiStavke_Click;
            ucPretraziUgovor.btnVratiStavke.Click += BtnVratiStavke_Click;
        }

        private void BtnVratiStavke_Click(object? sender, EventArgs e)
        {
            VratiStavke();
        }

        private void VratiStavke()
        {
            if (selected_ugovor != null)
            {
                int? filter_iznos = null;
                double? filter_brojSati = null;
                Studio filter_studio = null;
                if (int.TryParse(ucPretraziUgovor.txtIznos.Text, out int iznos))
                {
                    filter_iznos = iznos;
                }
                if (double.TryParse(ucPretraziUgovor.txtBrojSati.Text, out double brojSati))
                {
                    filter_brojSati = brojSati;
                }
                if (ucPretraziUgovor.cbStudio.SelectedItem != null)
                {
                    filter_studio = (Studio)ucPretraziUgovor.cbStudio.SelectedItem;
                }
                var filtrirane_stavke = new BindingList<StavkaUgovora>(
                    selected_ugovor.StavkeUgovora
                        .Where(s =>
                            (!filter_iznos.HasValue || s.Iznos == filter_iznos.Value) &&
                            (!filter_brojSati.HasValue || s.BrojSati == filter_brojSati.Value) &&
                            (filter_studio == null || s.Studio.Id == filter_studio.Id)
                        )
                        .ToList()
                );

                FillDgvStavke(filtrirane_stavke);
            }
        }

        private void BtnPretraziStavku_Click(object? sender, EventArgs e)
        {
            if (ucPretraziUgovor.dgvStavke.CurrentCell != null)
            {
                int selected_index = ucPretraziUgovor.dgvStavke.CurrentCell.RowIndex;
                if (selected_index != -1 && selected_index < stavkeUgovora.Count)
                {
                    StavkaUgovora selected_stavka = stavkeUgovora[selected_index];
                    FillFormStavka(selected_stavka);
                }
            }
            else
            {
                MessageBox.Show("Morate izabrati stavku iz tabele!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillFormStavka(StavkaUgovora stavka)
        {
            ucPretraziUgovor.cbStudio.SelectedItem = stavka.Studio;
            ucPretraziUgovor.txtIznos.Text = stavka.Iznos.ToString();
            ucPretraziUgovor.txtBrojSati.Text = stavka.BrojSati.ToString();
        }

        private void BtnPromeniUgovor_Click(object? sender, EventArgs e)
        {
            if (ucPretraziUgovor.dgvUgovor.CurrentCell != null)
            {
                int selected_index = ucPretraziUgovor.dgvUgovor.CurrentCell.RowIndex;
                if (selected_index != -1 && selected_index < ugovori.Count)
                {
                    Ugovor ugovorToEdit = ugovori[selected_index];
                    
                    try
                    {
                        ugovorToEdit.SelectCondition = $"WHERE IdUgovor = {ugovorToEdit.Id}";
                        Ugovor fullyLoadedUgovor = Komunikacija.Instance.PretraziUgovor(ugovorToEdit);
                        
                        if (fullyLoadedUgovor == null)
                        {
                            MessageBox.Show("Sistem ne moze da nadje ugovor", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        MainCoordinator.Instance.ShowPromeniUgovorPanel(sender, e, fullyLoadedUgovor);
                        MessageBox.Show("Sistem je ucitao ugovor za izmenu", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Sistem ne moze da ucita ugovor: " + ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Morate izabrati ugovor iz tabele za izmenu!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VratiUgovore()
        {
            Bend bend;
            Zaposleni zaposleni;
            string condition = "";
            if (ucPretraziUgovor.cbBend.SelectedIndex != 0)
            {
                bend = (Bend)ucPretraziUgovor.cbBend.SelectedItem;
                condition = "WHERE Ugovor.IdBend = " + bend.Id;
            } else
            {
                bend = new Bend() { Id = -1, Zanr = new Zanr { Id = -1 } };
            }
            if (ucPretraziUgovor.cbZaposleni.SelectedIndex != 0)
            {
                zaposleni = (Zaposleni)ucPretraziUgovor.cbZaposleni.SelectedItem;
                if (!string.IsNullOrEmpty(condition))
                {
                    condition += " AND ";
                }
                else
                {
                    condition = "WHERE ";
                }
                condition += "Ugovor.IdZaposleni = " + zaposleni.Id;
            } else
            {
                zaposleni = new Zaposleni() { Id = -1 };
            }

            if (ucPretraziUgovor.dtpDatumSklapanja.Checked)
            {
                if (!string.IsNullOrEmpty(condition))
                {
                    condition += " AND ";
                }
                else
                {
                    condition = "WHERE ";
                }
                condition += "WHERE CAST(DatumSklapanja AS DATE) = '" +
            ucPretraziUgovor.dtpDatumSklapanja.Value.ToString("yyyy-MM-dd") + "'";
            }
            if (int.TryParse(ucPretraziUgovor.txtUkupnaCena.Text, out int ukupnaCena))
            {
                if (!string.IsNullOrEmpty(condition))
                {
                    condition += " AND ";
                }
                else
                {
                    condition = "WHERE ";
                }
                condition += "UkupnaCena = " + ukupnaCena;
            }
            try
            {
                ugovori = Komunikacija.Instance.VratiListuUgovor(new Ugovor { Bend = bend, Zaposleni = zaposleni, SelectCondition = condition });
                ucPretraziUgovor.dgvUgovor.DataSource = ugovori;

                ucPretraziUgovor.dgvUgovor.Columns["Id"].Visible = false;
                ucPretraziUgovor.dgvUgovor.Columns["Set"].Visible = false;
                ucPretraziUgovor.dgvUgovor.Columns["InsertCondition"].Visible = false;
                ucPretraziUgovor.dgvUgovor.Columns["SelectCondition"].Visible = false;
                ucPretraziUgovor.dgvUgovor.Columns["UpdateCondition"].Visible = false;
                ucPretraziUgovor.dgvUgovor.Columns["DeleteCondition"].Visible = false;
                ucPretraziUgovor.dgvUgovor.Columns["TableName"].Visible = false;
                ucPretraziUgovor.dgvUgovor.Columns["Values"].Visible = false;
                ucPretraziUgovor.dgvUgovor.Columns["Join"].Visible = false;

                ucPretraziUgovor.dgvUgovor.AllowUserToAddRows = false;
                ucPretraziUgovor.dgvUgovor.AllowUserToDeleteRows = false;
                ucPretraziUgovor.dgvUgovor.ReadOnly = true;
                ucPretraziUgovor.dgvUgovor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                ucPretraziUgovor.dgvUgovor.MultiSelect = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne moze da nadje ugovore: " + ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnVratiUgovore_Click(object? sender, EventArgs e)
        {
            try
            {
                VratiUgovore();
                if (ugovori != null && ugovori.Count > 0)
                {
                    MessageBox.Show($"Sistem je nasao {ugovori.Count} ugovor(a) po zadatim kriterijumima", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Sistem nije nasao ugovore po zadatim kriterijumima", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne moze da nadje ugovore: " + ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
