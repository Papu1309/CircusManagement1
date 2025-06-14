using CircusManagement1.Models;
using System;
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

namespace CircusManagement1.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для ArtistEditDialog.xaml
    /// </summary>
    public partial class ArtistEditDialog : Window
    {
        public Artist Artist { get; private set; }

        public ArtistEditDialog(Artist artist)
        {
            InitializeComponent();
            Artist = artist;
            DataContext = Artist;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}


