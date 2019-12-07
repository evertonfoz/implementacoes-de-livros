using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IdadeAlunosMatriculados
{
    public partial class FormCategoriaPorIdade : Form
    {
        public FormCategoriaPorIdade()
        {
            InitializeComponent();
        }

        private void txtAnoUltimoAniversario_Enter(object sender, EventArgs e)
        {
            if (txtAnoNascimento.Text.Trim().Length < 4)
            {
                MessageBox.Show(
                    "É preciso informar o ANO DE NASCIMENTO com 4 dígitos", "Atenção!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                txtAnoNascimento.Focus();
            }
        }

        private void txtAnoUltimoAniversario_Validating(object sender, CancelEventArgs e)
        {
            if (txtAnoUltimoAniversario.Text != String.Empty && 
                Convert.ToInt32(txtAnoUltimoAniversario.Text) <= Convert.ToInt32(txtAnoNascimento.Text))
            {
                MessageBox.Show(
                    "O ANO DO ÚLTIMO ANIVERSÁRIO deve ser superior ao do ANO DE NASCIMENTO.",
                    "Atenção!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                e.Cancel = true;
            }
        }

        private void btnIdentificarCategoria_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == String.Empty ||
                txtAnoNascimento.Text == String.Empty ||
                txtAnoUltimoAniversario.Text == String.Empty)
            {
                MessageBox.Show(
                    "Todos os dados solicitados devem ser informados.",
                    "Atenção!!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else
            {
                int idade = Convert.ToInt32(txtAnoUltimoAniversario.Text) - Convert.ToInt32(txtAnoNascimento.Text);
                if (idade > 17)
                {
                    lblCategoriaValue.Text = "Adulto";
                }
                else if (idade > 13)
                {
                    lblCategoriaValue.Text = "Juvenil B";
                }
                else if (idade > 10)
                {
                    lblCategoriaValue.Text = "Juvenil A";
                }
                else if (idade > 7)
                {
                    lblCategoriaValue.Text = "Infantil B";
                }
                else if (idade >= 5)
                {
                    lblCategoriaValue.Text = "Infantil A";
                }
                else
                {
                    lblCategoriaValue.Text = "Não existe categoria";
                }
            }
        }
    }
}
