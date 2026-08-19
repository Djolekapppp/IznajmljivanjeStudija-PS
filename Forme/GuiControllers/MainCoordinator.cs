using Common.Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forme.GuiControllers
{
    internal class MainCoordinator
    {
        private static MainCoordinator instance;

        public static MainCoordinator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainCoordinator();
                }
                return instance;
            }
        }

        private MainCoordinator()
        {
        }

        private frmGlavna frmGlavna;
        private Zaposleni ulogovaniZaposleni;

        internal void ShowFrmGlavna(Zaposleni zaposleni)
        {
            ulogovaniZaposleni = zaposleni;
            frmGlavna = new frmGlavna(zaposleni);
            frmGlavna.FormBorderStyle = FormBorderStyle.FixedSingle;
            frmGlavna.MaximizeBox = false;
            frmGlavna.MinimizeBox = true; 
            frmGlavna.ShowDialog();
        }

        internal void ShowDodajUgovorPanel(object sender, EventArgs e)
        {
            frmGlavna.ChangePanel(KreirajUgovorGuiController.Instance.CreateKreirajUgovor(ulogovaniZaposleni));
        }

        internal void ShowDodajBendPanel(object sender, EventArgs e)
        {
            frmGlavna.ChangePanel(KreirajBendGuiController.Instance.CreateKreirajBend());
        }
        internal void ShowPromeniBendPanel(object sender, EventArgs e, Bend bend)
        {
            frmGlavna.ChangePanel(KreirajBendGuiController.Instance.CreateKreirajBend(bend));
        }

        internal void ShowPretraziBendPanel(object sender, EventArgs e)
        {
            frmGlavna.ChangePanel(PretraziBendGuiController.Instance.CreatePretraziBend());
        }

        internal void ShowUbaciTerminDezurstvaPanel(object? sender, EventArgs e)
        {
            frmGlavna.ChangePanel(KategorijaRestoranaController.Instance.CreateUbaciKategorijaRestorana());
        }
    }
}
