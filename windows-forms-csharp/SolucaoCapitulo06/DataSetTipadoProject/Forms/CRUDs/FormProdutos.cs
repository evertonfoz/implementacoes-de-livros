using System;
using System.Windows.Forms;

namespace DataSetTipadoProject.Forms.CRUDs {
    public partial class FormProdutos : Form {
        public FormProdutos() {
            InitializeComponent();
        }

        private void FormProdutos_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'dSEstadosECidades.Grupos' table. You can move, or remove it, as needed.
            this.gruposTableAdapter.FillByNome(this.dSEstadosECidades.Grupos);
            // TODO: This line of code loads data into the 'dSEstadosECidades.Produtos' table. You can move, or remove it, as needed.
            this.produtosTableAdapter.Fill(this.dSEstadosECidades.Produtos);
        }

        private void produtosBindingNavigatorSaveItem_Click(object sender, EventArgs e) {
            this.Validate();
            this.produtosBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSEstadosECidades);
        }
    }
}
