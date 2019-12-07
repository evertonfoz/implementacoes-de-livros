using System.Windows.Forms;
using ControllerProject;
using ModelProject;
using System;

namespace ViewProject
{
    public partial class FormNotaEntrada : Form
    {
        private NotaEntradaController controller;
        private FornecedorController fornecedorController;
        private ProdutoController produtoController;

        private NotaEntrada notaAtual;

        public FormNotaEntrada(NotaEntradaController controller, FornecedorController fornecedorController, ProdutoController produtoController) {
            InitializeComponent();
            this.controller = controller;
            this.fornecedorController = fornecedorController;
            this.produtoController = produtoController;
            InicializaComboBoxs();
        }

        private void InicializaComboBoxs() {
            cbxFornecedor.Items.Clear();
            cbxProduto.Items.Clear();

            foreach (Fornecedor fornecedor in this.fornecedorController.GetAll())
            {
                cbxFornecedor.Items.Add(fornecedor);
            }

            foreach (Produto produto in this.produtoController.GetAll())
            {
                cbxProduto.Items.Add(produto);
            }
        }

        private void btnNovoNota_Click(object sender, System.EventArgs e)
        {
            ClearControlsNota();
        }

        private void btnGravarNota_Click(object sender, System.EventArgs e)
        {
            var notaEntrada = new NotaEntrada()
            {
                Id = (txtIDNota.Text == string.Empty ? Guid.NewGuid() : new Guid(txtIDNota.Text)),
                DataEmissao = dtpEmissao.Value,
                DataEntrada = dtpEntrada.Value,
                FornecedorNota = (Fornecedor)cbxFornecedor.SelectedItem,
                Numero = txtNumero.Text
            };
            
            notaEntrada = (txtIDNota.Text == string.Empty ? 
                this.controller.Insert(notaEntrada) : 
                this.controller.Update(notaEntrada));
            dgvNotasEntrada.DataSource = null;
            dgvNotasEntrada.DataSource = this.controller.GetAll();
            ClearControlsNota();
        }

        private void btnCancelarNota_Click(object sender, System.EventArgs e)
        {
            ClearControlsNota();
        }

        private void btnRemoverNota_Click(object sender, System.EventArgs e)
        {
            if (txtIDNota.Text == string.Empty)
            {
                MessageBox.Show(
                   "Selecione a NOTA a ser removida no GRID");
            }
            else
            {
                this.controller.Remove(
                    new NotaEntrada()
                    {
                        Id = new Guid(txtIDNota.Text)
                    }
                );
                dgvNotasEntrada.DataSource = null;
                dgvNotasEntrada.DataSource =
                    this.controller.GetAll();
                ClearControlsNota();
            }
        }

        private void ClearControlsNota()
        {
            dgvNotasEntrada.ClearSelection();
            dgvProdutos.ClearSelection();
            txtIDNota.Text = string.Empty;
            cbxFornecedor.SelectedIndex = -1;
            txtNumero.Text = string.Empty;
            dtpEmissao.Value = DateTime.Now;
            dtpEntrada.Value = DateTime.Now;
            cbxFornecedor.Focus();
        }

        private void dgvNotasEntrada_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                this.notaAtual = this.controller.
                    GetNotaEntradaById((Guid)dgvNotasEntrada.
                    CurrentRow.Cells[0].Value);
                txtIDNota.Text = notaAtual.Id.
                    ToString();
                txtNumero.Text = notaAtual.Numero;
                cbxFornecedor.SelectedItem = notaAtual.
                    FornecedorNota;
                dtpEmissao.Value = notaAtual.DataEmissao;
                dtpEntrada.Value = notaAtual.DataEntrada;
                UpdateProdutosGrid();
            }
            catch
            {
                this.notaAtual = new NotaEntrada();
            }
        }

        private void UpdateProdutosGrid()
        {
            dgvProdutos.DataSource = null;
            if (this.notaAtual.Produtos.Count > 0)
            {
                dgvProdutos.DataSource = this.notaAtual.
                    Produtos;
            }
        }

        private void btnNovoProduto_Click(object sender, EventArgs e)
        {
            ClearControlsProduto();
            if (txtIDNota.Text == string.Empty)
            {
                MessageBox.Show("Selecione a NOTA, que terá " + 
                    "inserção de produtos, no GRID");
            }
            else
            {
                ChangeStatusOfControls(true);
            }
        }

        private void ChangeStatusOfControls(bool newStatus)
        {
            cbxProduto.Enabled = newStatus;
            txtCusto.Enabled = newStatus;
            txtQuantidade.Enabled = newStatus;
            btnNovoProduto.Enabled = !newStatus;
            btnGravarProduto.Enabled = newStatus;
            btnCancelarProduto.Enabled = newStatus;
            btnRemoverProduto.Enabled = newStatus;
        }

        private void btnGravarProduto_Click(object sender, EventArgs e)
        {
            var produtoNota = new ProdutoNotaEntrada()
            {
                Id = (txtIDProduto.Text == string.Empty ?
                    Guid.NewGuid() : new Guid(txtIDProduto.
                    Text)),
                PrecoCustoCompra = Convert.ToDouble(
                    txtCusto.Text),
                ProdutoNota = (Produto)cbxProduto.
                    SelectedItem,
                QuantidadeComprada = Convert.ToDouble(
                    txtQuantidade.Text)
            };
            this.notaAtual.RegistrarProduto(produtoNota);
            this.notaAtual = this.controller.Update(
                this.notaAtual);
            ChangeStatusOfControls(false);
            UpdateProdutosGrid();
            ClearControlsProduto();
        }

        private void btnCancelarProduto_Click(object sender, EventArgs e)
        {
            ClearControlsProduto();
            ChangeStatusOfControls(false);
        }

        private void btnRemoverProduto_Click(object sender, EventArgs e)
        {
            this.notaAtual.RemoverProduto(
                new ProdutoNotaEntrada()
                {
                    Id = new Guid(txtIDProduto.Text)
                }
            );
            this.controller.Update(this.notaAtual);
            UpdateProdutosGrid();
            ClearControlsProduto();
            ChangeStatusOfControls(false);
        }

        private void ClearControlsProduto()
        {
            //TODO: [Implementar]
            MessageBox.Show("Implementar");
        }
    }
}
