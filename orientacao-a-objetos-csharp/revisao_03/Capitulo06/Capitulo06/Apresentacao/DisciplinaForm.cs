using Modelo;
using Servico;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Apresentacao
{
    public partial class DisciplinaForm : Form
    {
        DisciplinaServico disciplinaServico = new DisciplinaServico();

        public DisciplinaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            disciplinaServico.Inserir(new Disciplina()
            {
                Nome = txtNome.Text,
                CargaHoraria = Convert.ToInt16(txtCargaHoraria.Text)
            });
            AtualizarDataGridView();
            MessageBox.Show("Inserção realizada com sucesso");
        }

        private void AtualizarDataGridView()
        {
            dgvDisciplinas.DataSource = null;
            dgvDisciplinas.DataSource = disciplinaServico.ObterTodas();
        }
    }
}
