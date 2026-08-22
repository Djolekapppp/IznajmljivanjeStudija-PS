using Common.Domen;
using Forme.UserControls;
using Forme.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forme.GuiControllers
{
    public class StavkaGuiController
    {
        private static StavkaGuiController instance;

        public static StavkaGuiController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StavkaGuiController();
                }
                return instance;
            }
        }

        private StavkaGuiController()
        {
        }

        private UCDodajStavku ucDodajStavku;
        private Ugovor ugovor;
        private StavkaUgovora stavka;
        private FormMode currentMode;

        public Control CreateDodajStavku(FormMode mode, Ugovor ugovor = null, StavkaUgovora stavkaToEdit = null)
        {
            this.ugovor = ugovor;
            this.stavka = stavkaToEdit;
            this.currentMode = mode;
            
            ucDodajStavku = new UCDodajStavku();
            ucDodajStavku.btnUkloniStavku.Click -= BtnUkloniStavku_Click;
            ucDodajStavku.btnOmoguciIzmenu.Click -= BtnOmoguciIzmenu_Click;
            ucDodajStavku.btnIzmeniStavku.Click -= BtnIzmeniStavku_Click;
            ucDodajStavku.btnDodajStavku.Click -= BtnDodajStavku_Click;

            ucDodajStavku.btnUkloniStavku.Click += BtnUkloniStavku_Click;
            ucDodajStavku.btnOmoguciIzmenu.Click += BtnOmoguciIzmenu_Click;
            ucDodajStavku.btnIzmeniStavku.Click += BtnIzmeniStavku_Click;
            ucDodajStavku.btnDodajStavku.Click += BtnDodajStavku_Click;

            if (mode == FormMode.Disabled)
            {
                Disable();
                SrediFormu(mode);
            }
            else if (mode == FormMode.Add)
            {
                Disable();
                Enable();
                ucDodajStavku.btnUkloniStavku.Enabled = false;
                ucDodajStavku.btnOmoguciIzmenu.Enabled = false;
                ucDodajStavku.btnIzmeniStavku.Enabled = false;

                SrediFormu(mode);
            }
            else if (mode == FormMode.Edit)
            {
                Disable();
                Enable();
                ucDodajStavku.btnOmoguciIzmenu.Enabled = true;
                ucDodajStavku.btnIzmeniStavku.Enabled = false;
                ucDodajStavku.btnDodajStavku.Enabled = false;

                SrediFormu(mode);
                LoadStavka(stavkaToEdit);
            }

            return ucDodajStavku;
        }

        private void IzmeniStavku(StavkaUgovora stavka)
        {
            if (ugovor == null)
            {
                throw new Exception("Nema ucitanog ugovora!");
            }

            int index = ugovor.StavkeUgovora.IndexOf(stavka);
            if (index < 0)
            {
                throw new Exception("Stavka nije pronađena u ugovoru!");
            }

            ugovor.StavkeUgovora.RemoveAt(index);
            PostaviStavku(stavka);
            ugovor.StavkeUgovora.Insert(index, stavka);

            currentMode = FormMode.Add;
            Disable();
            Enable();
            ucDodajStavku.btnUkloniStavku.Enabled = false;
            ucDodajStavku.btnOmoguciIzmenu.Enabled = false;
            ucDodajStavku.btnIzmeniStavku.Enabled = false;
            
            // Clear form
            ClearForm();
        }

        private void BtnIzmeniStavku_Click(object? sender, EventArgs e)
        {
            try
            {
                IzmeniStavku(stavka);
                MessageBox.Show("Stavka je uspešno izmenjena.", "Uspesno", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnOmoguciIzmenu_Click(object? sender, EventArgs e)
        {
            Enable();
            ucDodajStavku.btnOmoguciIzmenu.Enabled = false;
            ucDodajStavku.btnIzmeniStavku.Enabled = true;
            ucDodajStavku.btnDodajStavku.Enabled = false;
        }

        private void UkloniStavku(StavkaUgovora stavka)
        {
            if (ugovor == null || ugovor.StavkeUgovora.Count == 0)
            {
                throw new Exception("Nema stavki za uklanjanje!");
            }
            ugovor.StavkeUgovora.Remove(stavka);
        }

        private void BtnUkloniStavku_Click(object? sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Da li ste sigurni da zelite da obrisete izabranu stavku?", "Potvrda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                UkloniStavku(stavka);
                MessageBox.Show("Stavka je uspešno obrisana.", "Uspesno", MessageBoxButtons.OK, MessageBoxIcon.Information);

                currentMode = FormMode.Add;
                Disable();
                Enable();
                ucDodajStavku.btnUkloniStavku.Enabled = false;
                ucDodajStavku.btnOmoguciIzmenu.Enabled = false;
                ucDodajStavku.btnIzmeniStavku.Enabled = false;
                
                // Clear form
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadStavka(StavkaUgovora stavkaToEdit)
        {
            if (stavkaToEdit != null)
            {
                ucDodajStavku.txtDatum.Text = stavkaToEdit.Datum.ToString("dd/MM/yyyy");
                ucDodajStavku.txtVremeOd.Text = stavkaToEdit.VremeOd.ToString(@"hh\:mm\:ss");
                ucDodajStavku.txtVremeDo.Text = stavkaToEdit.VremeDo.ToString(@"hh\:mm\:ss");
                ucDodajStavku.txtIznos.Text = stavkaToEdit.Iznos.ToString();
                ucDodajStavku.txtCenaPoSatu.Text = stavkaToEdit.CenaPoSatu.ToString();
                
                // Try to select studio
                if (stavkaToEdit.Studio != null && ucDodajStavku.cbStudio.Items.Count > 0)
                {
                    ucDodajStavku.cbStudio.SelectedItem = stavkaToEdit.Studio;
                }
            }
        }

        private void ClearForm()
        {
            ucDodajStavku.txtDatum.Text = "";
            ucDodajStavku.txtVremeOd.Text = "";
            ucDodajStavku.txtVremeDo.Text = "";
            ucDodajStavku.txtIznos.Text = "";
            ucDodajStavku.txtCenaPoSatu.Text = "";
            ucDodajStavku.cbStudio.SelectedIndex = -1;
        }

        private void BtnDodajStavku_Click(object? sender, EventArgs e)
        {
            StavkaUgovora stavka = new StavkaUgovora();
            
            try
            {
                PostaviStavku(stavka);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ugovor == null)
            {
                MessageBox.Show("Nema ucitanog ugovora!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ugovor.StavkeUgovora.Add(stavka);
            MessageBox.Show("Stavka je uspešno dodata.", "Uspesno", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            // Clear form for next entry
            ClearForm();
        }

        private void Disable()
        {
            ucDodajStavku.btnDodajStavku.Enabled = false;
            ucDodajStavku.btnUkloniStavku.Enabled = false;
            ucDodajStavku.btnIzmeniStavku.Enabled = false;
            ucDodajStavku.btnOmoguciIzmenu.Enabled = false;
            ucDodajStavku.txtCenaPoSatu.Enabled = false;
            ucDodajStavku.txtDatum.Enabled = false;
            ucDodajStavku.txtIdUgovor.Enabled = false;
            ucDodajStavku.txtIznos.Enabled = false;
            ucDodajStavku.txtVremeDo.Enabled = false;
            ucDodajStavku.txtVremeOd.Enabled = false;
            ucDodajStavku.cbStudio.Enabled = false;
        }

        private void Enable()
        {
            ucDodajStavku.btnDodajStavku.Enabled = true;
            ucDodajStavku.btnUkloniStavku.Enabled = true;
            ucDodajStavku.txtDatum.Enabled = true;
            ucDodajStavku.txtVremeDo.Enabled = true;
            ucDodajStavku.txtVremeOd.Enabled = true;
            ucDodajStavku.cbStudio.Enabled = true;
        }

        private void SrediFormu(FormMode mode)
        {
            try
            {
                if (ugovor != null && ugovor.Bend != null)
                {
                    ucDodajStavku.cbStudio.DataSource = Komunikacija.Instance.VratiSveStudije()
                        .Where(s => s.Kapacitet >= ugovor.Bend.BrojClanova).ToList();
                    ucDodajStavku.cbStudio.DisplayMember = "Naziv";
                    ucDodajStavku.cbStudio.ValueMember = "Id";
                }
                ucDodajStavku.cbStudio.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greska pri ucitavanju studija: " + ex.Message, "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (ugovor == null || ugovor.Id == 0)
            {
                ucDodajStavku.txtIdUgovor.Text = "-";
            }
            else
            {
                ucDodajStavku.txtIdUgovor.Text = ugovor.Id.ToString();
            }

            ucDodajStavku.txtIznos.Text = "";
        }

        private void Validacija(DateTime datum, TimeSpan vremeOd, TimeSpan vremeDo)
        {
            DateTime danas = DateTime.Today;
            TimeSpan trenutnoVreme = DateTime.Now.TimeOfDay;

            if (datum.Date < danas)
            {
                throw new Exception("Datum ne može biti u prošlosti.");
            }

            if (datum.Date == danas && vremeOd <= trenutnoVreme)
            {
                throw new Exception("Vreme početka mora biti posle trenutnog vremena.");
            }

            if (vremeDo <= vremeOd)
            {
                throw new Exception("Vreme završetka mora biti posle vremena početka.");
            }

            TimeSpan trajanje = vremeDo - vremeOd;

            if (trajanje.TotalMinutes <= 0)
            {
                throw new Exception("Trajanje mora biti veće od 0.");
            }

            if (vremeOd < new TimeSpan(8, 0, 0) || vremeDo > new TimeSpan(22, 0, 0))
            {
                throw new Exception("Termin mora biti između 08:00 i 22:00.");
            }
        }

        private void PostaviStavku(StavkaUgovora stavka)
        {
            if (DateTime.TryParseExact(ucDodajStavku.txtDatum.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime datum))
            {
                stavka.Datum = datum;
            }
            else
            {
                throw new Exception("Pogrešno unet datum! (dd/MM/yyyy)");
            }

            if (TimeSpan.TryParse(ucDodajStavku.txtVremeOd.Text, out TimeSpan vremeOd)
                && TimeSpan.TryParse(ucDodajStavku.txtVremeDo.Text, out TimeSpan vremeDo))
            {
                int brojSati = (vremeDo - vremeOd).Hours;
                Studio? s = (Studio?)ucDodajStavku.cbStudio.SelectedItem;
                if (s != null)
                {
                    Validacija(datum, vremeOd, vremeDo);

                    stavka.Studio = s;
                    stavka.VremeDo = vremeDo;
                    stavka.VremeOd = vremeOd;
                    stavka.BrojSati = brojSati;
                    stavka.CenaPoSatu = s.CenaPoSatu;

                    double iznos = (double)(brojSati * s.CenaPoSatu);
                    stavka.Iznos = iznos;

                    if (ugovor != null) stavka.IdUgovor = ugovor.Id;
                }
                else
                {
                    throw new Exception("Morate uneti studio!");
                }
            }
            else
            {
                throw new Exception("Pogresno uneto vreme! (hh:mm:ss)");
            }
        }

        private void CbStudio_SelectedIndexChanged(object? sender, EventArgs e)
        {
            Studio? s = (Studio?)ucDodajStavku.cbStudio.SelectedItem;

            if (s != null)
            {
                ucDodajStavku.txtCenaPoSatu.Text = s.CenaPoSatu.ToString();
            }
        }
    }
}
