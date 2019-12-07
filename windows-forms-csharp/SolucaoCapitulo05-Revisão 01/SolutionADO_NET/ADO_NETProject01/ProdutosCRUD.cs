using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO_NETProject01
{
    public partial class ProdutosCRUD : Form
    {
        private DAL_Produto dal = new DAL_Produto();
        private Produto produtoAtual;

        public ProdutosCRUD()
        {
            InitializeComponent();
            GetAllProdutos();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            dal.Save(new Produto()
            {
                Id = string.IsNullOrEmpty(txtID.Text) ? (long?)null : Convert.ToInt64(txtID.Text),
                Descricao = txtDescricao.Text,
                PrecoDeCusto = Convert.ToDouble(txtCusto.Text),
                PrecoDeVenda = Convert.ToDouble(txtVenda.Text),
                Estoque = Convert.ToDouble(txtEstoque.Text)
            });
            MessageBox.Show("Manutenção realizada com sucesso");
            ClearControls();
        }

        private void ClearControls()
        {
            txtID.Text = string.Empty;
            txtDescricao.Text = string.Empty;
            txtCusto.Text = string.Empty;
            txtVenda.Text = string.Empty;
            txtEstoque.Text = string.Empty;
            GetAllProdutos();
            dgvProdutos.ClearSelection();
            this.produtoAtual = null;
            txtDescricao.Focus();
        }

        private void GetAllProdutos()
        {
            dgvProdutos.DataSource = dal.GetAllAsDataTable();
        }
    }
}
