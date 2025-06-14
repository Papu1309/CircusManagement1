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
    /// Логика взаимодействия для AnimalsPage.xaml
    /// </summary>
    public partial class AnimalsPage : Page
    {
        public AnimalsPage()
        {
            InitializeComponent();
            LoadAnimals();
        }

        private void LoadAnimals()
        {
            App.CircusModel.Animals.Load();
            animalsGrid.ItemsSource = App.CircusModel.Animals.Local;
        }

        private void AddAnimal_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Dialogs.AnimalEditDialog();
            if (dialog.ShowDialog() == true)
            {
                var newAnimal = new Animal
                {
                    name = dialog.AnimalName,
                    age = dialog.Age,
                    gender = dialog.Gender,
                    weight = dialog.Weight,
                    food_preferences = dialog.Food,
                    care_recommendations = dialog.Care,
                    trainer_id = dialog.TrainerId,
                    cage_id = dialog.CageId
                };

                App.CircusModel.Animals.Add(newAnimal);
                App.CircusModel.SaveChanges();
                LoadAnimals();
            }
        }

        private void EditAnimal_Click(object sender, RoutedEventArgs e)
        {
            if (animalsGrid.SelectedItem is Animal selected)
            {
                var dialog = new Dialogs.AnimalEditDialog
                {
                    AnimalName = selected.name,
                    Age = selected.age,
                    Gender = selected.gender,
                    Weight = selected.weight,
                    Food = selected.food_preferences,
                    Care = selected.care_recommendations,
                    TrainerId = selected.trainer_id,
                    CageId = selected.cage_id
                };

                if (dialog.ShowDialog() == true)
                {
                    selected.name = dialog.AnimalName;
                    selected.age = dialog.Age;
                    selected.gender = dialog.Gender;
                    selected.weight = dialog.Weight;
                    selected.food_preferences = dialog.Food;
                    selected.care_recommendations = dialog.Care;
                    selected.trainer_id = dialog.TrainerId;
                    selected.cage_id = dialog.CageId;

                    App.CircusModel.SaveChanges();
                    LoadAnimals();
                }
            }
        }

        private void DeleteAnimal_Click(object sender, RoutedEventArgs e)
        {
            if (animalsGrid.SelectedItem is Animal selected)
            {
                MessageBoxResult result = MessageBox.Show("Удалить животное?", "Подтверждение", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    App.CircusModel.Animals.Remove(selected);
                    App.CircusModel.SaveChanges();
                    LoadAnimals();
                }
            }
        }
    }
}
