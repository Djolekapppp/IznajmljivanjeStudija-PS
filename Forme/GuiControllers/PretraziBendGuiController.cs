using Common.Domen;
using Forme.UserControls;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forme.GuiControllers
{
    internal class PretraziBendGuiController
    {
        private static PretraziBendGuiController instance;

        public static PretraziBendGuiController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PretraziBendGuiController();
                }
                return instance;
            }
        }

        private PretraziBendGuiController()
        {
        }

        private UCPretraziBend ucPretraziBend;
        internal List<Bend> bendovi;

        internal Control CreatePretraziBend()
        {
            ucPretraziBend = new UCPretraziBend();
            ucPretraziBend.btnVratiBendove.Click += BtnVratiBendove_Click;
            ucPretraziBend.btnObrisiBend.Click += BtnObrisiBend_Click;
            ucPretraziBend.btnPromeniBend.Click += BtnPromeniBend_Click;
            ucPretraziBend.btnPretraziBend.Click += BtnPretraziBend_Click;
            return ucPretraziBend;
        }

        private void BtnPretraziBend_Click(object? sender, EventArgs e)
        {
            if (ucPretraziBend.dgvBendovi.CurrentCell != null)
            {
                int selected_index = ucPretraziBend.dgvBendovi.CurrentCell.RowIndex;
                if (selected_index != -1)
                {
                    Bend selected_bend = bendovi[selected_index];
                    FillForm(selected_bend);
                    try
                    {
                        VratiBendove();
                        if (bendovi.Count == 0)
                        {
                            MessageBox.Show("Sistem ne moze da nadje bend", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    } catch
                    {
                        MessageBox.Show("Sistem ne moze da nadje bend", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Niste selektovali bend za pretrazivanje", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Niste selektovali bend za pretrazivanje", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnPromeniBend_Click(object? sender, EventArgs e)
        {
            if (ucPretraziBend.dgvBendovi.CurrentCell != null)
            {
                int selected_index = ucPretraziBend.dgvBendovi.CurrentCell.RowIndex;
                if (selected_index != -1)
                {
                    Bend selected_bend = bendovi[selected_index];
                    try
                    {
                        MainCoordinator.Instance.ShowPromeniBendPanel(sender, e, selected_bend);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Sistem ne moze da nadje bend", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Niste selektovali bend za brisanje!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Niste selektovali bend za brisanje!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObrisiBend()
        {
            if (ucPretraziBend.dgvBendovi.CurrentCell != null)
            {
                int selected_index = ucPretraziBend.dgvBendovi.CurrentCell.RowIndex;
                if (selected_index != -1)
                {
                    Bend selected_bend = bendovi[selected_index];
                    try
                    {
                        selected_bend.DeleteCondition = $"WHERE IdBend={selected_bend.Id}";
                        bendovi = Komunikacija.Instance.VratiListuBend(selected_bend);
                        MessageBox.Show("Sistem je nasao bend", "Uspešno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        VratiBendove();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Sistem ne moze da obrise bend", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Niste selektovali bend za brisanje!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Niste selektovali bend za brisanje!", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        
        private void BtnObrisiBend_Click(object? sender, EventArgs e)
        {
            ObrisiBend();
        }
        
        private void VratiBendove() 
        {
            Zanr zanr = ucPretraziBend.cbZanr.SelectedItem as Zanr;
            if (zanr == null)
            {
                zanr = new Zanr() { Id = -1 };
            }

            string condition = "";
            if (ucPretraziBend.txtNaziv.Text != "")
            {
                condition += $"NazivBend = '{ucPretraziBend.txtNaziv.Text}' AND ";
            }
            if (ucPretraziBend.txtEmail.Text != "")
            {
                condition += $"Email = '{ucPretraziBend.txtEmail.Text}' AND ";
            }
            if (ucPretraziBend.txtKontaktIme.Text != "")
            {
                condition += $"KontaktIme = '{ucPretraziBend.txtKontaktIme.Text}' AND ";
            }
            if (int.TryParse(ucPretraziBend.txtBrojClanova.Text, out int brojClanova))
            {
                condition += $"BrojClanova = {brojClanova} AND ";
            }
            if (ucPretraziBend.txtKontaktTelefon.Text != "")
            {
                condition += $"KontaktTelefon = '{ucPretraziBend.txtKontaktTelefon.Text}'";
            }
            if (condition.EndsWith(' '))
            {
                condition = condition.Substring(0, condition.Length - 4);
            }
            if (condition != "")
            {
                condition = "WHERE " + condition;
            }
            try
            {
                bendovi = Komunikacija.Instance.VratiListuBend(new Bend() { Zanr = zanr, SelectCondition = condition });
                ucPretraziBend.dgvBendovi.DataSource = bendovi;
                ucPretraziBend.dgvBendovi.Columns["Id"].Visible = false;
                ucPretraziBend.dgvBendovi.Columns["InsertCondition"].Visible = false;
                ucPretraziBend.dgvBendovi.Columns["SelectCondition"].Visible = false;
                ucPretraziBend.dgvBendovi.Columns["UpdateCondition"].Visible = false;
                ucPretraziBend.dgvBendovi.Columns["DeleteCondition"].Visible = false;
                ucPretraziBend.dgvBendovi.Columns["TableName"].Visible = false;
                ucPretraziBend.dgvBendovi.Columns["Values"].Visible = false;
                ucPretraziBend.dgvBendovi.Columns["Join"].Visible = false;
                ucPretraziBend.dgvBendovi.Columns["Set"].Visible = false;

                ucPretraziBend.dgvBendovi.AllowUserToAddRows = false;
                ucPretraziBend.dgvBendovi.AllowUserToDeleteRows = false;
                ucPretraziBend.dgvBendovi.ReadOnly = true;
                ucPretraziBend.dgvBendovi.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                ucPretraziBend.dgvBendovi.MultiSelect = false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void BtnVratiBendove_Click(object? sender, EventArgs e)
        {
            try
            {
                VratiBendove();
                if (bendovi.Count == 0)
                {
                    MessageBox.Show("Sistem ne moze da nadje bendove po zadatim kriterijumima", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sistem ne moze da nadje bendove po zadatim kriterijumima", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void FillForm(Bend bend)
        {
            ucPretraziBend.cbZanr.SelectedItem = bend.Zanr;
            ucPretraziBend.txtNaziv.Text = bend.Naziv;
            ucPretraziBend.txtEmail.Text = bend.Email;
            ucPretraziBend.txtBrojClanova.Text = bend.BrojClanova.ToString();
            ucPretraziBend.txtKontaktIme.Text = bend.KontaktIme;
            ucPretraziBend.txtKontaktTelefon.Text = bend.KontaktTelefon;
        }
    }
}
