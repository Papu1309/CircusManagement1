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
    /// Логика взаимодействия для AnimalEditDialog.xaml
    /// </summary>
    public partial class AnimalEditDialog : Window
    {
        public string AnimalName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public decimal Weight { get; set; }
        public string Food { get; set; }
        public string Care { get; set; }
        public int TrainerId { get; set; }
        public int CageId { get; set; }

        public AnimalEditDialog()
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
