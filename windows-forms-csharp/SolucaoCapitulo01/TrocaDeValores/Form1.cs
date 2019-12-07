using System;
using System.Windows.Forms;

namespace TrocaDeValores
{
    public partial class frmTrocaDeValores : Form
    {
        public frmTrocaDeValores()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string auxiliar;
            auxiliar = txtPrimeiroValor.Text;
            txtPrimeiroValor.Text = txtSegundoValor.Text;
            txtSegundoValor.Text = auxiliar;
            MessageBox.Show("Troca de valores concluída",
                "Informação", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

        }
    }
}
