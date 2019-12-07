using DataSetTipadoProject.Forms.CRUDs;
using System;
using System.Windows.Forms;

namespace DataSetTipadoProject.Forms {
    public partial class FormPrincipal : Form {
        public FormPrincipal() {
            InitializeComponent();
        }

        private void estadosToolStripMenuItem_Click(object sender, EventArgs e) {
            new FormEstados().ShowDialog();
        }

        private void cidadesToolStripMenuItem_Click(object sender, EventArgs e) {
            new FormCidades().ShowDialog();
        }

        private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e) {
            new FormFornecedores().ShowDialog();
        }

        private void gruposToolStripMenuItem_Click(object sender, EventArgs e) {
            new FormGrupos().ShowDialog();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e) {
            new FormProdutos().ShowDialog();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e) {
            new FormClientes().ShowDialog();
        }

        private void notasDeEntradaToolStripMenuItem_Click(object sender, EventArgs e) {
            new FormNotasDeEntrada().ShowDialog();
        }

        private void notasDeVendaToolStripMenuItem_Click(object sender, EventArgs e) {
            new FormNotasDeVenda().ShowDialog();
        }
    }
}
