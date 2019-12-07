using System;
using System.Windows.Forms;

namespace DataSetTipadoProject.Forms.CRUDs {
    public partial class FormClientes : Form {
        public FormClientes() {
            InitializeComponent();
        }

        private void FormClientes_Load(object sender, EventArgs e) {
            // TODO: This line of code loads data into the 'dSEstadosECidades.Cidades' table. You can move, or remove it, as needed.
            this.cidadesTableAdapter.FillByNomeComUF(this.dSEstadosECidades.Cidades);
            // TODO: This line of code loads data into the 'dSEstadosECidades.Clientes' table. You can move, or remove it, as needed.
            this.clientesTableAdapter.Fill(this.dSEstadosECidades.Clientes);
        }
        
        private void clientesBindingNavigatorSaveItem_Click(object sender, EventArgs e) {
            this.Validate();
            this.clientesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSEstadosECidades);
        }
    }
}
