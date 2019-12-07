using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ReajusteDeFolhaDePagamento
{
    public partial class FormLeituraArquivo : Form
    {
        private RepositorioFuncionario repositorio = new RepositorioFuncionario();
        private BindingSource leituraSource = new BindingSource();

        public FormLeituraArquivo()
        {
            InitializeComponent();
            leituraSource.DataSource = repositorio.ObterTodos();
            dgvLeitura.DataSource = leituraSource;
        }

        private void BtnSelecionarArquivo_Click(object sender, EventArgs e)
        {
            if (ofdListaFuncionarios.ShowDialog() == DialogResult.OK)
            {
                txtArquivo.Text = ofdListaFuncionarios.FileName;
                ProcessarArquivo(txtArquivo.Text);
                if (repositorio.ObterTodos().Count > 0)
                {
                    TotalizarValores(repositorio.ObterTodos());
                }
            }
        }

        private void TotalizarValores(IList<Funcionario> dadosLidos)
        {
            double totalSemReajuste = 0, totalComReajuste = 0;
            foreach (var funcionario in dadosLidos)
            {
                totalSemReajuste += funcionario.Salario;
                totalComReajuste += funcionario.NovoSalario;
            }
            double percentualReajuste = 
                (totalComReajuste - totalSemReajuste)*100/totalSemReajuste;
            lblTotalSemReajuste.Text = string.Format("{0:c}", totalSemReajuste);
            lblTotalComReajuste.Text = string.Format("{0:c}", totalComReajuste);
            lblPercentualDoReajuste.Text = string.Format("{0:n}%", percentualReajuste);
        }

        private void ProcessarArquivo(string nomeArquivo)
        {
            repositorio.ObterTodos().Clear();
            string linhaLida;
            var arquivo = new System.IO.StreamReader(@nomeArquivo);
            while ((linhaLida = arquivo.ReadLine()) != null)
            {
                var dadosLidos = linhaLida.Split(';');
                var funcionario = new Funcionario
                    {
                        Codigo = Convert.ToInt32(dadosLidos[0]),
                        Salario = Convert.ToDouble(dadosLidos[1])
                    };
                repositorio.Inserir(funcionario);
            }
            arquivo.Close();
        }
    }
}
