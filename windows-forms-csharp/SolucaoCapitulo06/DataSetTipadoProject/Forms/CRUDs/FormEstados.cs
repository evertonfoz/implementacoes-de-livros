using System;
using System.Windows.Forms;

namespace DataSetTipadoProject.Forms.CRUDs {
    public partial class FormEstados : Form {
        public FormEstados() {
            InitializeComponent();
        }

        private void FormEstados_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'dSEstadosECidades.Estados' table. You can move, or remove it, as needed.
            this.estadosTableAdapter.Fill(this.dSEstadosECidades.Estados);
        }

        private void estadosBindingNavigatorSaveItem_Click(object sender, EventArgs e) {
            this.Validate();
            this.estadosBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSEstadosECidades);
        }
    }
}
