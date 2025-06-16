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
    /// Логика взаимодействия для ArtistsPage.xaml
    /// </summary>
    public partial class ArtistsPage : Page
    {
        public ArtistsPage()
        {
            InitializeComponent();
            Loaded += (s, e) => LoadArtists();
        }

        private void LoadArtists()
        {
            try
            {
                artistsGrid.ItemsSource = null;
                App.CircusModel.Artists.Load();
                artistsGrid.ItemsSource = App.CircusModel.Artists.Local;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EditArtist_Click(object sender, RoutedEventArgs e)
        {
            if (artistsGrid.SelectedItem is Artist selected)
            {
                var dialog = new ArtistEditDialog(selected);
                if (dialog.ShowDialog() == true)
                {
                    try
                    {
                        App.CircusModel.SaveChanges();
                        LoadArtists();
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show($"Ошибка сохранения: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите артиста для редактирования", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteArtist_Click(object sender, RoutedEventArgs e)
        {
            if (artistsGrid.SelectedItem is Artist selectedA)
            {
                if (MessageBox.Show("Удалить этого артиста?", "Подтверждение", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        App.CircusModel.Artists.Remove(selectedA);
                        App.CircusModel.SaveChanges();
                        LoadArtists();
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show($"Ошибка удаления: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите артиста для удаления", "Внимание", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            LoadArtists();
        }

        private void artistsGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            EditArtist_Click(sender, e);
        }
    }
}

