using System;
using System.Collections;
using System.Data.Entity.Core.Objects;
using System.Net.Sockets;
using EFApplication.Contexts;
using EFApplication.POCO;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace EFApplication
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

        private void PopulateComboBoxEstados()
        {
            cbxEstados.ItemsSource = GetEstados();
            cbxEstados.DisplayMemberPath = "Nome";
            cbxEstados.SelectedValuePath = "Id";
        }

        private IList<Estado> GetEstados()
        {
            using (var context = new EFContext())
            {
                return context.Estados.OrderBy(estado => estado.Nome).ToList<Estado>();
            }
        }

        private void btnGravar_Click(object sender, RoutedEventArgs e)
        {
            var cidade = SaveCidade(new Cidade()
            {
                EstadoId = (long) cbxEstados.SelectedValue,
                Nome = txtNome.Text
            });
            txtID.Text = cidade.Id.ToString();
            RefreshDataGrid();
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

        private IList GetCidades()
        {
            using (var context = new EFContext())
            {
                var query = (from c in context.Cidades
                             orderby c.Nome
                             select new { c.Id, c.Estado, c.Nome });
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

        private void btnRemover_Click(object sender, RoutedEventArgs e)
        {
           RemoveCidade(Convert.ToInt64(txtID.Text));
           RefreshDataGrid();
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

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            UpdateCidade(new Cidade()
            {
                Id = Convert.ToInt64(txtID.Text),
                Nome = txtNome.Text,
                EstadoId = (long) cbxEstados.SelectedValue
            });
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
    }
}
