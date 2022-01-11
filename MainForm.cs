using CanDbcAdmin.BLL;
using CanDbcAdmin.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanDbcAdmin
{
    public partial class MainForm : Form
    {
        private IDatabase db = new JsonDatabase(); // TODO
        private List<Dbc> dbcs = new List<Dbc>();

        public MainForm() => InitializeComponent();

        private void MainForm_Load(object sender, EventArgs e) => Reload();

        private void Reload()
        {
            lstDatabases.Items.Clear();
            lstItems.Items.Clear();

            dbcs = db.GetAll();
            dbcs.ForEach(dbc => lstDatabases.Items.Add(dbc.Filename));

            if (dbcs.Count > 0)
            {
                lstDatabases.SelectedIndex = 0;
                ShowDatabase(dbcs.First());
            }
        }

        private void ShowDatabase(Dbc dbc)
        {
            lstItems.Items.Clear();
            dbc.ToStringItems().ForEach(item => lstItems.Items.Add(item));
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                  var dbc = new Dbc(openFileDialog.FileName);
                  db.Insert(dbc);
                  Reload();
                  ShowDatabase(dbc);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lstDatabases_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowDatabase(db.GetAll()[lstDatabases.SelectedIndex]);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstDatabases.SelectedIndex < 0) return;

            db.Delete(dbcs[lstDatabases.SelectedIndex].Filename);
            Reload();
        }
    }
}
