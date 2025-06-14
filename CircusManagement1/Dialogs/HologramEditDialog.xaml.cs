using CircusManagement1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для HologramEditDialog.xaml
    /// </summary>
    public partial class HologramEditDialog : Window
    {

        public string Location { get; set; }

        public HologramEditDialog()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}

