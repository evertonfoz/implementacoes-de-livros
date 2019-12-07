using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsumoEnergiaCondominio
{
    public partial class FormConsumoDeEnergiaCondominio : Form
    {
        IList<Leitura> leituras = new List<Leitura>();

        public FormConsumoDeEnergiaCondominio()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Leitura leitura = new Leitura(txtCasa.Text, Convert.ToDouble(txtConsumo.Text));
            if (leituras.Contains(leitura))
            {
                MessageBox.Show("A leitura para esta casa já foi registrada", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.leituras.Add(leitura);
                dgvLeituras.DataSource = this.leituras;
            }
        }
    }
}
