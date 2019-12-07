using System.Windows.Forms;
using ControllerProject;
using System;
using ModelProject;

namespace ViewProject
{
    public partial class FormFornecedor : Form
    {
        private FornecedorController controller = new FornecedorController();

        public FormFornecedor(FornecedorController controller)
        {
            InitializeComponent();
            this.controller = controller;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            var fornecedor = new Fornecedor()
            {
                Id = (txtID.Text == string.Empty ?
                      Guid.NewGuid() : new Guid(txtID.Text)),
                Nome = txtNome.Text,
                CNPJ = txtCNPJ.Text
            };
            fornecedor = (txtID.Text == string.Empty ?
                      this.controller.Insert(fornecedor) :
                      this.controller.Update(fornecedor));
            dgvFornecedores.DataSource = null;
            dgvFornecedores.DataSource = this.controller.GetAll();
            ClearControls();
        }

        private void ClearControls()
        {
            dgvFornecedores.ClearSelection();
            txtID.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtCNPJ.Text = string.Empty;
            txtNome.Focus();
        }
        
        private void btnNovo_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void dgvFornecedores_SelectionChanged(object sender, EventArgs e)
        {
            txtID.Text = dgvFornecedores.CurrentRow.Cells[0].Value.ToString();
            txtNome.Text = dgvFornecedores.CurrentRow.Cells[1].Value.ToString();
            txtCNPJ.Text = dgvFornecedores.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (txtID.Text == string.Empty)
            {
                MessageBox.Show(
                 "Selecione o FORNECEDOR a ser removido no GRID");
            }
            else
            {
                this.controller.Remove(
                    new Fornecedor()
                    {
                        Id = new Guid(txtID.Text)
                    }
                );
                dgvFornecedores.DataSource = null;
                dgvFornecedores.DataSource =
                    this.controller.GetAll();
                ClearControls();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ClearControls();
        }
    }
}
