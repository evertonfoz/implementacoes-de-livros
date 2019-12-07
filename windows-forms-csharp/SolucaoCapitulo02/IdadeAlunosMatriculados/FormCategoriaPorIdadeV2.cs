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
    public partial class FormCategoriaPorIdadeV2 : Form
    {
        public FormCategoriaPorIdadeV2()
        {
            InitializeComponent();
            lblHoje.Text = "Hoje é " + DateTime.Now.ToShortDateString();
        }

        private void btnIdentificarCategoria_Click(object sender, EventArgs e)
        {
            if (txtNome.Text == String.Empty)
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
                TimeSpan tsQuantidadeDias = DateTime.Now.Date - dtpDataDeNascimento.Value;
                
                //considerar sempre um ano com 365 dias e
                //um mês com 30 dias, não resultará em um 
                //resultado preciso.
                int idade = (tsQuantidadeDias.Days / 365);
                
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
