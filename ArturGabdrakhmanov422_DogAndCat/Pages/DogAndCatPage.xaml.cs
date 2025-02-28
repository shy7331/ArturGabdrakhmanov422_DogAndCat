using ArturGabdrakhmanov422_DogAndCat.Components;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ArturGabdrakhmanov422_DogAndCat.Pages
{
    /// <summary>
    /// Логика взаимодействия для DogAndCatPage.xaml
    /// </summary>
    public partial class DogAndCatPage : Page
    {
        private List<PhotoDog> photos;
        private User currentUser;

        public DogAndCatPage(User user)
        {
            InitializeComponent();
            currentUser = user;

            this.Loaded += DogsPage_Loaded;
        }

        private void DogsPage_Loaded(object sender, RoutedEventArgs e)
        {
            LoadPhotos();
        }

        private void LoadPhotos()
        {

            App.db.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());

            photos = App.db.PhotoDog
                .Where(p => p.Dog.Name == (currentUser.Name == "Андрей" ? "Ра" : "Нуби"))
                .ToList();

            PhotosListView.ItemsSource = null;
            PhotosListView.ItemsSource = photos;
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdatePhotos();
        }

        private void SortComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdatePhotos();
        }
        private void UpdatePhotos()
        {

            string query = SearchBox.Text.ToLower();
            var filteredPhotos = photos
                .Where(p => p.PhotoName.ToLower().Contains(query))
                .ToList();


            if (SortComboBox.SelectedItem != null)
            {
                string selectedSort = (SortComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
                switch (selectedSort)
                {
                    case "По имени (А-Я)":
                        filteredPhotos = filteredPhotos.OrderBy(p => p.PhotoName).ToList();
                        break;

                    case "По имени (Я-А)":
                        filteredPhotos = filteredPhotos.OrderByDescending(p => p.PhotoName).ToList();
                        break;
                }
            }


            PhotosListView.ItemsSource = filteredPhotos;
        }


        private void AddPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddPhotoPage());
        }

        private void LogoutBtn_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new AuthPage());
        }
    }
}
