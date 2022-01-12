using CanDbcAdmin.BLL;
using CanDbcAdmin.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CanDbcAdmin {
  public partial class MainForm : Form {
    private IDatabase db = new JsonDatabase($"{Program.StoragePath}/database.json"); // TODO

    public MainForm() => InitializeComponent();

    private void MainForm_Load(object sender, EventArgs e) {
      var filenames = db.List();
      filenames.ForEach(filename => lstFiles.Items.Add(filename));

      if (filenames.Count > 0) lstFiles.SelectedIndex = 0;
    }

    private void LoadCanDbc(string filename) {
      lstItems.Items.Clear();
      db.Get(filename).ToStringItems().ForEach(item => lstItems.Items.Add(item));
    }

    private void btnImport_Click(object sender, EventArgs e) {
      if (openFileDialog.ShowDialog() == DialogResult.OK) {
        var filename = Path.GetFileNameWithoutExtension(openFileDialog.FileName);

        if (lstFiles.Items.Contains(filename))
          Program.ShowErrorMessage($"Database already contains '{filename}'");
        else {
          var canDbc = CanDbcParser.ParseFile(openFileDialog.FileName);
          db.Insert(canDbc);

          lstFiles.Items.Add(filename);
          lstFiles.SelectedIndex = lstFiles.Items.Count - 1;
        }
      }
    }

    private void lstDatabases_SelectedIndexChanged(object sender, EventArgs e) {
      if (lstFiles.SelectedIndex < 0) return;

      LoadCanDbc(lstFiles.GetItemText(lstFiles.SelectedItem));
    }

    private void btnDelete_Click(object sender, EventArgs e) {
      if (lstFiles.SelectedIndex < 0) return;

      var filename = lstFiles.GetItemText(lstFiles.SelectedItem);

      db.Delete(filename);
      lstFiles.Items.Remove(filename);

      if (lstFiles.Items.Count > 0)
        lstFiles.SelectedIndex = 0;
      else
        lstItems.Items.Clear();
    }
  }
}
