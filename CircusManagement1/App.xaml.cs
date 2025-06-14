using CircusManagement1.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CircusManagement1
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static CircusDBEntities1 CircusModel { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            // Инициализация вашего контекста БД
            CircusModel = new CircusDBEntities1();
            Database.SetInitializer<CircusDBEntities1>(null);
            base.OnStartup(e);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            CircusModel?.Dispose();
            base.OnExit(e);
        }
    }
}
