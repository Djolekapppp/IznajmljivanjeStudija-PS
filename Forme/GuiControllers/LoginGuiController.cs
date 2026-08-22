using Common.Domen;
using Common.Komunikacija;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Forme.GuiControllers
{
    internal class LoginGuiController
    {
        private static LoginGuiController instance;

        public static LoginGuiController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new LoginGuiController();
                }
                return instance;
            }
        }

        private LoginGuiController()
        {
        }

        private frmLogin frmLogin;
        internal void ShowFrmLogin()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmLogin = new frmLogin();
            frmLogin.AutoSize = true;
            frmLogin.Text = "Login";
            Application.Run(frmLogin);
        }

        internal void Login(object? sender, EventArgs e)
        {
            try
            {
                Komunikacija.Instance.Connect();
                try
                {
                    Zaposleni zaposleni = Komunikacija.Instance.Login(frmLogin.txtUsername.Text, frmLogin.txtPassword.Text);
                    frmLogin.Visible = false;
                    try
                    {
                        MainCoordinator.Instance.ShowFrmGlavna(zaposleni);
                    } catch
                    {
                        MessageBox.Show("Ne moze da se otvori glavna forma i meni", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                } catch
                {
                    MessageBox.Show("Korisnicko ime i sifra nisu ispravni", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Neuspesno povezivanje sa serverom", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
