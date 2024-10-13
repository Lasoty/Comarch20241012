using System.Windows;
using Bibliotekarz.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Bibliotekarz.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            CheckDataBase();
        }

        private void CheckDataBase()
        {
            using AppDbContext dbContext = new();
            dbContext.Database.Migrate();
        }
    }

}
