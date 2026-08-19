using Common.Domen;
using Common.Komunikacija;
using Forme.GuiControllers;
using System.Text.Json;

namespace Forme
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            btnLogin.Click += LoginGuiController.Instance.Login;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
        }
    }
}
