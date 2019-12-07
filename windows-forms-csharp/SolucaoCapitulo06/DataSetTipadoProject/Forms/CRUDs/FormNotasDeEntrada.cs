using System;
using System.Windows.Forms;

namespace DataSetTipadoProject.Forms.CRUDs {
    public partial class FormNotasDeEntrada : Form {
        public FormNotasDeEntrada() {
            InitializeComponent();
        }

        private void FormNotaDeEntrada_Load(object sender, EventArgs e) {
            this.fornecedoresTableAdapter.Fill(this.dSEstadosECidades.Fornecedores);
            this.produtosNotaDeEntradaTableAdapter.Fill(this.dSEstadosECidades.ProdutosNotaDeEntrada);
            this.notasDeEntradaTableAdapter.Fill(this.dSEstadosECidades.NotasDeEntrada);
            this.produtosTableAdapter.FillByDescricao(this.dSEstadosECidades.Produtos);
            ((DataGridViewComboBoxColumn)dgvProdutos.Columns[0]).DataSource = this.dSEstadosECidades.Produtos;
            ((DataGridViewComboBoxColumn)dgvProdutos.Columns[0]).DisplayMember = this.dSEstadosECidades.Produtos.descricaoColumn.ColumnName;
            ((DataGridViewComboBoxColumn)dgvProdutos.Columns[0]).ValueMember = this.dSEstadosECidades.Produtos.idprodutoColumn.ColumnName;
        }

        private void notasDeEntradaBindingNavigatorSaveItem_Click(object sender, EventArgs e) {
            this.Validate();
            this.notasDeEntradaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSEstadosECidades);

        }
    }
}
