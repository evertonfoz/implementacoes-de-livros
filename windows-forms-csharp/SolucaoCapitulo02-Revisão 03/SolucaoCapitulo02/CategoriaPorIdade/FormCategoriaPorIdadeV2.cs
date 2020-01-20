using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CategoriaPorIdade
{
    public partial class FormCategoriaPorIdadeV2 : Form
    {
        public FormCategoriaPorIdadeV2()
        {
            InitializeComponent();
            lblHoje.Text = "Hoje é " + DateTime.Now.ToShortDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimeSpan tsQuantidadeDias = DateTime.Now.Date - dtpDataDeNascimento.Value;
            int idade = (tsQuantidadeDias.Days / 365);
        }
    }
}
