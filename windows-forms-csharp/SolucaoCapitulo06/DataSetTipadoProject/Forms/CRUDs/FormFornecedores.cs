using System;
using System.Windows.Forms;

namespace DataSetTipadoProject.Forms.CRUDs {
    public partial class FormFornecedores : Form {
        public FormFornecedores() {
            InitializeComponent();
        }

        private void FormFornecedores_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'dSEstadosECidades.Cidades' table. You can move, or remove it, as needed.
            this.cidadesTableAdapter.FillByNomeComUF(this.dSEstadosECidades.Cidades);
            // TODO: This line of code loads data into the 'dSEstadosECidades.Fornecedores' table. You can move, or remove it, as needed.
            this.fornecedoresTableAdapter.Fill(this.dSEstadosECidades.Fornecedores);
        }

        private void fornecedoresBindingNavigatorSaveItem_Click(object sender, EventArgs e) {
            this.Validate();
            this.fornecedoresBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSEstadosECidades);

        }
    }
}
