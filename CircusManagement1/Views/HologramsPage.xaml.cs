using CircusManagement1.Dialogs;
using CircusManagement1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CircusManagement1.Views
{
    /// <summary>
    /// Логика взаимодействия для HologramsPage.xaml
    /// </summary>
    public partial class HologramsPage : Page
    {
        public HologramsPage()
        {
            InitializeComponent();
            LoadCabinets();
        }

        private void LoadCabinets()
        {
            App.CircusModel.HologramCabinets.Load();
            cabinetsGrid.ItemsSource = App.CircusModel.HologramCabinets.Local;
        }

        private void AddCabinet_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Dialogs.HologramEditDialog();
            if (dialog.ShowDialog() == true)
            {
                var newCabinet = new HologramCabinet
                {
                    location = dialog.Location
                };

                App.CircusModel.HologramCabinets.Add(newCabinet);
                App.CircusModel.SaveChanges();
                LoadCabinets();
            }
        }

        private void EditCabinet_Click(object sender, RoutedEventArgs e)
        {
            if (cabinetsGrid.SelectedItem is HologramCabinet selected)
            {
                var dialog = new Dialogs.HologramEditDialog
                {
                    Location = selected.location
                };
                if (dialog.ShowDialog() == true)
                {
                    selected.location = dialog.Location;
                    App.CircusModel.SaveChanges();
                    LoadCabinets();
                }
            }
        }

        private void DeleteCabinet_Click(object sender, RoutedEventArgs e)
        {
            if (cabinetsGrid.SelectedItem is HologramCabinet selected)
            {
                MessageBoxResult result = MessageBox.Show("Удалить кабинет?", "Подтверждение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    App.CircusModel.HologramCabinets.Remove(selected);
                    App.CircusModel.SaveChanges();
                    LoadCabinets();
                }
            }
        }
    }
}

