using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReajusteDeFolhaDePagamento
{
    public partial class FormCalculoReajusteDeFolha : Form
    {
        public FormCalculoReajusteDeFolha()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormLancamento form = new FormLancamento();
            form.ShowDialog();
        }
    }
}
