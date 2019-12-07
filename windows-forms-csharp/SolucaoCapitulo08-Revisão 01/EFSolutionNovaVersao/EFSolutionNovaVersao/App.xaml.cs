using EFSolutionNovaVersao.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EFSolutionNovaVersao
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            //var optionsBuilder = new DbContextOptionsBuilder<EFContext>();
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=WPF_EFCore;Trusted_Connection=True;");
            //using (var context = new EFContext(optionsBuilder.Options))
            //{
            //    context.Database.EnsureCreated();
            //}

            using (EFContext context = new EFContext())
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();
            }
        }
    }
}
