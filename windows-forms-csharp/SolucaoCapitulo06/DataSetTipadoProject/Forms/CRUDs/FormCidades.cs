using System.Windows.Forms;

namespace DataSetTipadoProject.Forms.CRUDs {
    public partial class FormCidades : Form {
        public FormCidades() {
            InitializeComponent();
        }

        private void FormCidades_Load(object sender, System.EventArgs e) {
            // TODO: This line of code loads data into the 'dSEstadosECidades.Estados' table. You can move, or remove it, as needed.
            this.estadosTableAdapter.FillByNome(this.dSEstadosECidades.Estados);
            // TODO: This line of code loads data into the 'dSEstadosECidades.Cidades' table. You can move, or remove it, as needed.
            this.cidadesTableAdapter.Fill(this.dSEstadosECidades.Cidades);
        }

        private void cidadesBindingNavigatorSaveItem_Click(object sender, System.EventArgs e) {
            this.Validate();
            this.cidadesBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dSEstadosECidades);
        }
    }
}
