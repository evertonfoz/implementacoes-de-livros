using System.Windows.Forms;
using System;

namespace ADO_NETProject01
{
    public partial class FormNotaEntrada : Form
    {
        private DAL_NotaEntrada dal = new DAL_NotaEntrada();
        private DAL_Fornecedor dalFornecedor = new DAL_Fornecedor();
        //TODO: Implementar
        //private DAL_Produto dalProduto = new DAL_Produto();
        private NotaEntrada notaAtual;

        public FormNotaEntrada() {
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
            
            //TODO: Implementar
            //foreach (Produto produto in this.dalProduto.GetAllAsIList())
            //{
            //    cbxProduto.Items.Add(produto);
            //}
        }

        private void btnGravarNota_Click(object sender, EventArgs e)
        {
            dal.Save(new NotaEntrada()
            {
                Id = string.IsNullOrEmpty(txtIDNota.Text) ? 
                    (long?)null : 
                    Convert.ToInt64(txtIDNota.Text),
                Numero = txtNumero.Text,
                DataEmissao = Convert.ToDateTime(dtpEmissao.Value),
                DataEntrada = Convert.ToDateTime(dtpEntrada.Value),
                FornecedorNota = (Fornecedor)cbxFornecedor.
                    SelectedItem
            });
            MessageBox.Show("Manutenção realizada com sucesso");
            ClearControls();
        }

        private void ClearControls()
        {
          //TODO: implementar
        }

        private void GetAllNotas()
        {
            dgvNotasEntrada.DataSource = dal.GetAllAsDataTable();
        }
    }
}
