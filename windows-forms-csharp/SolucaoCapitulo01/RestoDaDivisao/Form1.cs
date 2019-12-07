using System;
using System.Windows.Forms;

namespace RestoDaDivisao
{
    public partial class frmRestoDeDivisao : Form
    {
        public frmRestoDeDivisao()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int dividendo = Convert.ToInt32(txtDividendo.Text);
            int divisor = Convert.ToInt32(txtDivisor.Text);
            int resto = dividendo % divisor;
            txtResto.Text = resto.ToString();
        }
    }
}
