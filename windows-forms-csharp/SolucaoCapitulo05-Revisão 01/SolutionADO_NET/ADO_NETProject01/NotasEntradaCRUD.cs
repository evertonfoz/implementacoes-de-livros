using System;
using System.Windows.Forms;

namespace ADO_NETProject01
{
    public partial class NotasEntradaCRUD : Form
    {
        private DAL_NotaEntrada dal = new DAL_NotaEntrada();
        private DAL_Fornecedor dalFornecedor = new DAL_Fornecedor();
        private DAL_Produto dalProduto = new DAL_Produto();
        private NotaEntrada notaAtual;

        public NotasEntradaCRUD()
        {
            InitializeComponent();
            InicializaComboBoxs();
            GetAllNotas();
        }

        private void InicializaComboBoxs()
        {
            cbxFornecedor.Items.Clear();
            cbxProduto.Items.Clear();

            foreach (Fornecedor fornecedor in this.dalFornecedor.GetAllAsIList())
            {
                cbxFornecedor.Items.Add(fornecedor);
            }

            foreach (Produto produto in this.dalProduto.GetAllAsIList())
            {
                cbxProduto.Items.Add(produto);
            }
        }

        private void btnGravarNota_Click(object sender, System.EventArgs e)
        {
            dal.Save(new NotaEntrada()
            {
                Id = string.IsNullOrEmpty(txtIDNotaEntrada.Text) ? (long?)null : Convert.ToInt64(txtIDNotaEntrada.Text),
                Numero = txtNumero.Text,
                DataEmissao = Convert.ToDateTime(dtpEmissao.Value),
                DataEntrada = Convert.ToDateTime(dtpEntrada.Value),
                FornecedorNota = (Fornecedor) cbxFornecedor.SelectedItem
            });
            MessageBox.Show("Manutenção realizada com sucesso");
            ClearControls();
        }

        private void ClearControls()
        {
            txtIDNotaEntrada.Text = string.Empty;
            txtNumero.Text = string.Empty;
            cbxFornecedor.SelectedIndex = -1;
            dtpEmissao.Value = DateTime.Now;
            dtpEntrada.Value = DateTime.Now;
            dgvNotasEntrada.ClearSelection();
            dgvProdutos.ClearSelection();
            GetAllNotas();
            cbxFornecedor.Focus();
            this.notaAtual = null;
        }

        private void GetAllNotas()
        {
            dgvNotasEntrada.DataSource = dal.GetAllAsDataTable();
        }

        private void dgvNotasEntrada_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            this.notaAtual = dal.GetById(Convert.ToInt64(dgvNotasEntrada.Rows[e.RowIndex].Cells[0].Value));
            txtIDNotaEntrada.Text = notaAtual.Id.ToString();
            txtNumero.Text = notaAtual.Numero;
            dtpEmissao.Value = notaAtual.DataEmissao;
            dtpEntrada.Value = notaAtual.DataEntrada;
            cbxFornecedor.SelectedItem = notaAtual.FornecedorNota;
        }

        private void ChangeStatusOfControls(bool newStatus)
        {
            cbxProduto.Enabled = newStatus;
            txtCusto.Enabled = newStatus;
            txtQuantidade.Enabled = newStatus;
            BtnNovoProduto.Enabled = !newStatus;
            BtnGravarProduto.Enabled = newStatus;
            BtnCancelarProduto.Enabled = newStatus;
            BtnRemoverProduto.Enabled = newStatus;
        }

        private void BtnNovoProduto_Click(object sender, EventArgs e)
        {
            ClearControlsProduto();
            if (txtIDNotaEntrada.Text == string.Empty)
            {
                MessageBox.Show("Selecione a NOTA, que terá inserção de produtos, no GRID");
            }
            else
            {
                ChangeStatusOfControls(true);
            }
        }

        private void ClearControlsProduto()
        {
            dgvProdutos.ClearSelection();
            txtIDProduto.Text = string.Empty;
            cbxProduto.SelectedIndex = -1;
            txtCusto.Text = string.Empty;
            txtQuantidade.Text = string.Empty;
            cbxProduto.Focus();
        }

        private void BtnGravarProduto_Click(object sender, EventArgs e)
        {
            dal.SaveProduto(notaAtual, new ProdutoNotaEntrada()
            {
                Id = string.IsNullOrEmpty(txtIDProduto.Text) ? (long?)null : Convert.ToInt64(txtIDProduto.Text),
                ProdutoNota = (Produto) cbxProduto.SelectedItem,
                PrecoCustoCompra = Convert.ToDouble(txtCusto.Text),
                QuantidadeComprada = Convert.ToDouble(txtQuantidade.Text)
            });
            MessageBox.Show("Manutenção realizada com sucesso");
            //ClearControls();
        }
    }
}
