using System.Collections.Generic;
using System.Windows.Forms;
using WinFormsApp.Presenter;
using WinFormsApp.Model;

namespace WinFormsApp.View
{
    public partial class ClientsView : Form, IClientView
    {
        public ClientsView()
        {
            InitializeComponent();
            Presenter = new ClientsPresenter(this);
            var clientList = Presenter.LoadClientList();
            if (clientList.Count > 0)     
            {
                SetUpDataGrid(clientList);
            }
            else
            {
                label1.Visible = true;
            }
        }
        public ClientsPresenter Presenter { private get; set; } 

        private void SetUpDataGrid(List<ClientModel> clientList)
        {
            dataGridView1.Visible = true;
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns.Add("Address", "Address");
            dataGridView1.Columns.Add("PostCode", "PostCode");

            dataGridView1.Columns["Name"].DataPropertyName = "Name";
            dataGridView1.Columns["Address"].DataPropertyName = "Address";
            dataGridView1.Columns["PostCode"].DataPropertyName = "PostCode";

            dataGridView1.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["Address"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns["PostCode"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView1.Columns["Name"].FillWeight = 2;
            dataGridView1.Columns["Address"].FillWeight = 2;
            dataGridView1.Columns["PostCode"].FillWeight = 1;

            dataGridView1.DataSource = clientList;

        }
    }
}