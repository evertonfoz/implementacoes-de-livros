using Modelo;
using Servico;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ApresentacaoNew
{
    public partial class FormDisciplina : Form
    {
        private CursoServico cursoServico = new CursoServico();
        private DisciplinaServico disciplinaServico = new DisciplinaServico();
        public FormDisciplina()
        {
            InitializeComponent();
            RefreshDataGridView();
            PopularComboBoxCursos();
        }
        private void PopularComboBoxCursos()
        {
            var cursos = cursoServico.TodosOsCursos().OrderBy(c => c.Nome).ToList<Curso>();
            cursos.Insert(0, new Curso() { CursoID = -1, Nome = "Selecione um curso" } );
            cbxCursos.DataSource = cursos;
            cbxCursos.DisplayMember = "Nome";
            cbxCursos.ValueMember = "CursoID";
        }

        private void BtnGravar_Click(object sender, System.EventArgs e)
        {
            disciplinaServico.Gravar(
                new Disciplina()
                {
                    DisciplinaID = (txtID.Text.Trim() == string.Empty) ? 0 : Convert.ToInt32(txtID.Text),
                    Nome = txtNome.Text,
                    CursoID = Convert.ToInt32(cbxCursos.SelectedValue)
                });
            LimparControles();
        }

        private void LimparControles()
        {
            txtID.Text = string.Empty;
            txtNome.Clear();
            cbxCursos.SelectedIndex = 0;
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            var disciplinas = from d in disciplinaServico.TodosAsDisciplinas()
                              select new
                               {
                                   d.DisciplinaID,
                                   d.Nome,
                                   Curso = d.Curso.Nome
                               };
            dgvDisciplinas.DataSource = disciplinas.ToList();
        }

        private void DgvDisciplinas_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void DgvDisciplinas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PopularControles(disciplinaServico.ObterPorId(ObterIDDisciplinaSelecionada(e.RowIndex)));
        }

        private int ObterIDDisciplinaSelecionada(int rowIndex)
        {
           return Convert.ToInt32(dgvDisciplinas.Rows[rowIndex].Cells[0].Value);
        }

        private void PopularControles(Disciplina disciplina)
        {
            txtID.Text = disciplina.DisciplinaID.ToString();
            txtNome.Text = disciplina.Nome;
            cbxCursos.SelectedValue = disciplina.CursoID;
        }

        private void BtnRemover_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Trim() == string.Empty)
                MessageBox.Show("Selecione uma disciplina");
            else
            {
                disciplinaServico.Remover(Convert.ToInt64(txtID.Text));
                LimparControles();
            }
        }

        private void BntNovo_Click(object sender, EventArgs e)
        {
            LimparControles();
        }
    }
}
