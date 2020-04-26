using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormsApp.Presenter;

namespace WinFormsApp.View
{
    public partial class MainView : Form, IMainView
    {
        public MainView()
        {
            InitializeComponent();
            Presenter = new MainPresenter(this);
        }

        public MainPresenter Presenter { private get; set; }

        private void clientListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientsView clientsView = new ClientsView();
            clientsView.StartPosition = FormStartPosition.CenterParent;
            clientsView.ShowDialog();
        }

        private void importClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.ImportClients();

                label1.ForeColor = Color.Green;
                label1.Text = "Klientų informacija importuota sėkmingai.";
            }
            catch
            {
                label1.ForeColor = Color.Red;
                label1.Text = "Klaida. Nepavyko importuoti klientų informacijos.";
            }
        }

        private void updatePostCodesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Presenter.UpdatePostalCodes();

                label1.ForeColor = Color.Green;
                label1.Text = "Pašto kodai sėkmingai atnaujinti.";
            }
            catch
            {
                label1.ForeColor = Color.Red;
                label1.Text = "Klaida. Nepavyko atnaujinti pašto kodų.";
            }
        }

    }
}
