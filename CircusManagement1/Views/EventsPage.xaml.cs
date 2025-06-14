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
    /// Логика взаимодействия для EventsPage.xaml
    /// </summary>
    public partial class EventsPage : Page
    {
        public EventsPage()
        {
            InitializeComponent();
            LoadEvents();
        }

        private void LoadEvents()
        {
            App.CircusModel.Events.Load();
            eventsGrid.ItemsSource = App.CircusModel.Events.Local;
        }

        private void AddEvent_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Dialogs.EventEditDialog();
            if (dialog.ShowDialog() == true)
            {
                var newEvent = new Event
                {
                    date = dialog.EventDate,
                    type = dialog.EventType,
                    prepayment = dialog.Prepayment,
                    company = dialog.Company,
                    category = dialog.Category,
                    room_id = dialog.RoomId
                };

                App.CircusModel.Events.Add(newEvent);
                App.CircusModel.SaveChanges();
                LoadEvents();
            }
        }

        private void GenerateReport_Click(object sender, RoutedEventArgs e)
        {
            var report = new Report
            {
                month = System.DateTime.Now,
                type = "Прошедшие",
                profit = 100000,
                expenses = 50000
            };

            App.CircusModel.Reports.Add(report);
            App.CircusModel.SaveChanges();
            MessageBox.Show("Отчет создан успешно!");
        }
    }
}
