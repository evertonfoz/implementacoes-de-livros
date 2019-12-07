using EFSolutionNovaVersao.Contexts;
using EFSolutionNovaVersao.POCO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EFSolutionNovaVersao
{
    /// <summary>
    /// Interaction logic for Cidades.xaml
    /// </summary>
    public partial class Cidades : Window
    {
        public Cidades()
        {
            InitializeComponent();
            PopulateComboBoxEstados();
            RefreshDataGrid();
        }

        private IList<Estado> GetEstados()
        {
            using (var context = new EFContext())
            {
                return context.Estados.OrderBy(estado => estado.Nome).ToList<Estado>();
            }
        }

        private void PopulateComboBoxEstados()
        {
            cbxEstados.ItemsSource = GetEstados();
            cbxEstados.DisplayMemberPath = "Nome";
            cbxEstados.SelectedValuePath = "Id";
        }

        private Cidade SaveCidade(Cidade cidade)
        {
            using (var context = new EFContext())
            {
                context.Cidades.Add(cidade);
                context.SaveChanges();
            }
            return cidade;
        }

        private void btnGravar_Click(object sender, RoutedEventArgs e)
        {
            var cidade = SaveCidade(new Cidade()
            {
                EstadoId = (long)cbxEstados.SelectedValue,
                Nome = txtNome.Text
            });
            RefreshDataGrid();
        }

        private IList GetCidades()
        {
            using (var context = new EFContext())
            {
                var query = (
                     from c in context.Cidades
                     orderby c.Nome
                     select new
                     {
                         c.Id,
                         c.Estado,
                         c.Nome
                     });
                return query.ToList();
            }
        }

        private void RefreshDataGrid()
        {
            dgCidades.ItemsSource = GetCidades();
        }

        private void btnNovo_Click(object sender, RoutedEventArgs e)
        {
            dgCidades.UnselectAll();
        }

        private void RemoveCidade(long idCidade)
        {
            using (var context = new EFContext())
            {
                var cidade = context.Cidades.Find(idCidade);
                context.Cidades.Remove(cidade);
                context.SaveChanges();
            }
        }

        private void btnRemover_Click(object sender, RoutedEventArgs e)
        {
            RemoveCidade(Convert.ToInt64(txtID.Text));
            RefreshDataGrid();
        }

        private void UpdateCidade(Cidade cidade)
        {
            using (var context = new EFContext())
            {
                var newCidade = context.Cidades.Find(cidade.Id);
                newCidade.Nome = cidade.Nome;
                newCidade.EstadoId = cidade.EstadoId;
                context.SaveChanges();
            }
        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            UpdateCidade(new Cidade()
            {
                Id = Convert.ToInt64(txtID.Text),
                Nome = txtNome.Text,
                EstadoId = (long)cbxEstados.SelectedValue
            });
            RefreshDataGrid();
        }
    }
}
