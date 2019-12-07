using System;
using System.Windows.Forms;

namespace DataSetTipadoProject.Forms.CRUDs {
    public partial class FormGrupos : Form {
        public FormGrupos() {
            InitializeComponent();
        }

        private void FormGrupos_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'dSEstadosECidades.Grupos' table. You can move, or remove it, as needed.
            this.gruposTableAdapter.Fill(this.dSEstadosECidades.Grupos);
        }

        private void gruposBindingNavigatorSaveItem_Click(object sender, EventArgs e) {
            this.Validate();
            this.gruposBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSEstadosECidades);

        }
    }
}
