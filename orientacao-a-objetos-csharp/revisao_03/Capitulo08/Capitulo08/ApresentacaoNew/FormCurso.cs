using Servico;
using System;
using System.Windows.Forms;

namespace ApresentacaoNew
{
    public partial class FormCurso : Form
    {
        private CursoServico cursoServico = new CursoServico();
        public FormCurso()
        {
            InitializeComponent();
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            dgvCursos.DataSource = cursoServico.TodosOsCursos();
        }

        private void BtnGravar_Click(object sender, System.EventArgs e)
        {
            cursoServico.Gravar(
                new Modelo.Curso()
                {
                    Nome = txtNome.Text,
                    CargaHoraria = Convert.ToInt32(nudCH.Value)
                });
            txtNome.Clear();
            nudCH.Value = 0;
            RefreshDataGridView();
        }
    }
}
