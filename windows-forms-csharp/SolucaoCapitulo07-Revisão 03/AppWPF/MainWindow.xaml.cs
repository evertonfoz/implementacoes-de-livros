using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace AppWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Candidato> candidatos = new List<Candidato>();
        public MainWindow()
        {
            InitializeComponent();
            GenerateCandidatos();
            PopulateListBox();
        }

        private void PopulateListBox()
        {
            foreach (var candidato in this.candidatos)
            {
                lbxCandidatos.Items.Add(candidato.Nome);
            }
        }

        private void GenerateCandidatos()
        {
            candidatos.Add(new Candidato() { Nome = "Yuri", Idade = 25 });
            candidatos.Add(new Candidato() { Nome = "Yara", Idade = 23 });
            candidatos.Add(new Candidato() { Nome = "Gabriel", Idade = 20 });
            candidatos.Add(new Candidato() { Nome = "Maria Clara", Idade = 7 });
            candidatos.Add(new Candidato() { Nome = "Vicente Dirceu", Idade = 6 });
            candidatos.Add(new Candidato() { Nome = "Júlia", Idade = 9 });
            candidatos.Add(new Candidato() { Nome = "Lívia", Idade = 64 });
            candidatos.Add(new Candidato() { Nome = "Elio", Idade = 74 });
            candidatos.Add(new Candidato() { Nome = "Alba", Idade = 44 });
            candidatos.Add(new Candidato() { Nome = "Angélica", Idade = 24 });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Início da consulta LINQ
            var maiores =
                from candidato in this.candidatos
                where candidato.Idade >= 18
                select candidato;
            // Término da consulta LINQ

            // Execução da consulta
            foreach (var maior in maiores)
            {
                lbxMaiores.Items.Add(maior.Nome);
            }
        }

    }
}
