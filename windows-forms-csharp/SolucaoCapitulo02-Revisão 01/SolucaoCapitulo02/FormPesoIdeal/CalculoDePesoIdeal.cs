using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormPesoIdeal
{
    public partial class CalculoDePesoIdeal : Form
    {
        RadioButton rbSelecionado = null;

        public CalculoDePesoIdeal()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            SetPesoIdeal();
        }

        private void txtAltura_TextChanged(object sender, EventArgs e)
        {
            SetPesoIdeal();
        }

        private void SetPesoIdeal()
        {
            try
            {
                double altura = Convert.ToDouble(txtAltura.Text);
                double pesoIdeal;

                rbSelecionado = gbxSexo.Controls.OfType<RadioButton>().
                    SingleOrDefault(r => r.Checked == true);

                if (rbSelecionado.Text.Equals("Masculino"))
                    pesoIdeal = (72.7 * altura) - 58;
                else
                    pesoIdeal = (62.1 * altura) - 44.7;
                lblPesoIdeal.Text = pesoIdeal.ToString("N");
            }
            catch (Exception e)
            {
                MessageBox.Show("Selecione o sexo e informe a altura corretamente", 
                    "Atenção!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
