using System.Security.AccessControl;

namespace Server
{
    public partial class frmServer : Form
    {
        private Server server = new Server();
        public frmServer()
        {
            InitializeComponent();
            txtServer.Enabled = false;
            txtServer.Text = "Server nije pokrenut";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                server.Start();
                txtServer.Text = "Server je pokrenut";
                MessageBox.Show("Server je startovan");
            }
            catch 
            {
                MessageBox.Show("Server vec startovan");
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            try
            {
                server.Stop(); 
                txtServer.Text = "Server nije pokrenut";
                MessageBox.Show("Server je zaustavljen");
            } catch
            {
                MessageBox.Show("Server nije ni startovan");
            }
        }
    }
}
