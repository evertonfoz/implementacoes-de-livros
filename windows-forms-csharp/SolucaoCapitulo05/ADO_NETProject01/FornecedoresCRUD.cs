using System.Windows.Forms;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace ADO_NETProject01
{
    public partial class FornecedoresCRUD : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["CS_ADO_NET"].ConnectionString;
        private Fornecedor fornecedorAtual;
        private DAL_Fornecedor dal = new DAL_Fornecedor();

        public FornecedoresCRUD()
        {
            InitializeComponent();
            GetAllFornecedores();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            dal.Save(new Fornecedor()
            {
                Id = string.IsNullOrEmpty(txtID.Text) ?
                   (long?)null : Convert.ToInt64(txtID.Text),
                Nome = txtNome.Text,
                CNPJ = txtCNPJ.Text
            });
            MessageBox.Show("Manutenção realizada com sucesso");
            ClearControls();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (txtID.Text == string.Empty) {
                MessageBox.Show("Selecione o FORNECEDOR a ser removido no GRID");
            } else {
                this.dal.RemoveById(this.fornecedorAtual.Id);
                ClearControls();
                MessageBox.Show("Fornecedor removido com sucesso");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void GetAllFornecedores() {
            string connectionString = ConfigurationManager.ConnectionStrings["CS_ADO_NET"].ConnectionString;

            var connection = new SqlConnection(connectionString);
        
            var adapter = new SqlDataAdapter("select id, cnpj, nome from FORNECEDORES", connectionString);
            var builder = new SqlCommandBuilder(adapter);
 
            var table = new DataTable();
            adapter.Fill(table);

            dgvFornecedores.DataSource = table;
            connection.Close();
        }

        private void ClearControls()
        {
            txtID.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtCNPJ.Text = string.Empty;
            GetAllFornecedores();
            dgvFornecedores.ClearSelection();
            this.fornecedorAtual = null;
            txtNome.Focus();
        }

        private Fornecedor GetFornecedorById(long id) {
            Fornecedor fornecedor = new Fornecedor();
            var connection = DBConnection.DB_Connection;
            var command = new SqlCommand("select id, cnpj, nome from FORNECEDORES where id = @id", connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            using (SqlDataReader reader=command.ExecuteReader()) {
                while (reader.Read()) {
                    fornecedor.Id = reader.GetInt32(0);
                    fornecedor.CNPJ = reader.GetString(1);
                    fornecedor.Nome = reader.GetString(2);
                }
            }
            connection.Close();
            return fornecedor;
        }

        private void dgvFornecedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            this.fornecedorAtual = GetFornecedorById(Convert.
                ToInt64(dgvFornecedores.Rows[e.RowIndex].Cells[0].
                Value));
            txtID.Text = this.fornecedorAtual.Id.ToString();
            txtNome.Text = this.fornecedorAtual.Nome;
            txtCNPJ.Text = this.fornecedorAtual.CNPJ;
        }
    }
}
