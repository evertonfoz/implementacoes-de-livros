using DataSetTipadoProject.DataSets;
using System;
using System.Data;
using System.Windows.Forms;

namespace DataSetTipadoProject.Forms.CRUDs {
    public partial class FormNotasDeVenda : Form {
        private bool adding, editing;

        public FormNotasDeVenda() {
            InitializeComponent();
            adding = false;
            editing = false;
        }

        private void FormNotasDeVenda_Load(object sender, EventArgs e) {
            this.produtosNotaDeSaidaTableAdapter.Fill(this.dSEstadosECidades.ProdutosNotaDeSaida);
            this.clientesTableAdapter.Fill(this.dSEstadosECidades.Clientes);
            this.notasDeVendaTableAdapter.Fill(this.dSEstadosECidades.NotasDeVenda);
            this.produtosTableAdapter.FillByDescricao(this.dSEstadosECidades.Produtos);
            ((DataGridViewComboBoxColumn)dgvProdutos.Columns[0]).DataSource = this.dSEstadosECidades.Produtos;
            ((DataGridViewComboBoxColumn)dgvProdutos.Columns[0]).DisplayMember = this.dSEstadosECidades.Produtos.descricaoColumn.ColumnName;
            ((DataGridViewComboBoxColumn)dgvProdutos.Columns[0]).ValueMember = this.dSEstadosECidades.Produtos.idprodutoColumn.ColumnName;

            if (notasDeVendaBindingSource.Current == null) {
                SetBindingNavigatorButtonsState();
            }
        }

        private void notasDeVendaBindingNavigatorSaveItem_Click(object sender, EventArgs e) {
            this.Validate();
            this.notasDeVendaBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSEstadosECidades);
            adding = false;
            editing = false;
            SetBindingNavigatorButtonsState();
        }

        private void bnbEdit_Click(object sender, EventArgs e) {
            editing = true;
            SetBindingNavigatorButtonsState();
        }

        private void notasDeVendaBindingNavigatorFechamentoItem_Click(object sender, EventArgs e) {

        }

        private void bnbAdd_Click(object sender, EventArgs e) {
            adding = true;
            SetBindingNavigatorButtonsState();
        }

        private void bnbRemove_Click(object sender, EventArgs e) {
            adding = false;
            editing = true;
            SetBindingNavigatorButtonsState();
        }

        private void notasDeVendaBindingSource_PositionChanged(object sender, EventArgs e) {
            DataRowView drv = (DataRowView)
            notasDeVendaBindingSource.Current;
            if (drv != null) {
                DataRow dr = drv.Row;
                if (drv != null && !(dr.RowState == DataRowState.
                        Detached)) {
                    SetBindingNavigatorButtonsState();
                }
            }
        }
        
        private void SetBindingNavigatorButtonsState() {
            bool podeFecharNota = false;
            if (notasDeVendaBindingSource.Current != null) {
                DataRowView drv = (DataRowView)
                    notasDeVendaBindingSource.Current;
                DSEstadosECidades.NotasDeVendaRow nvRow =
                    (DSEstadosECidades.NotasDeVendaRow)drv.Row;
                podeFecharNota = nvRow.notafechada.Equals("N");
            }
            bnbFirst.Enabled = !adding && !editing;
            bnbPrior.Enabled = bnbFirst.Enabled;
            bindingNavigatorCountItem.Enabled = bnbFirst.Enabled;
            bnbNext.Enabled = bnbFirst.Enabled;
            bnbLast.Enabled = bnbFirst.Enabled;

            bnbAdd.Enabled = bnbFirst.Enabled;
            bnbEdit.Enabled = bnbFirst.Enabled && podeFecharNota;
            bnbRemove.Enabled = !editing && podeFecharNota;
            bnbSave.Enabled = adding || editing;
            bnbFecharNota.Enabled = podeFecharNota &&
                (!adding && !editing);

            gbxDadosDaNota.Enabled = adding || editing;
            gbxProdutosDaNota.Enabled = editing;
        }
    }
}
