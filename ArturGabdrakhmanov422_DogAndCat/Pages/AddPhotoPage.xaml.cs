using ArturGabdrakhmanov422_DogAndCat.Components;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddPhotoPage.xaml
    /// </summary>
    public partial class AddPhotoPage : Page
    {
        private string selectedFilePath;

        public AddPhotoPage()
        {
            InitializeComponent();
            PhotoNameTb.MaxLength = 20;
            LoadDogs();
        }

        private void LoadDogs()
        {
            DogComboCb.ItemsSource = App.db.Dog.ToList();
            DogComboCb.DisplayMemberPath = "Name";
            DogComboCb.SelectedValuePath = "Id";
        }



        private void SelectPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Изображения|*.jpg;*.png;*.bmp";

            if (openFileDialog.ShowDialog() == true)
            {
                selectedFilePath = openFileDialog.FileName;
                PhotoPreview.Source = new BitmapImage(new Uri(selectedFilePath));
            }
        }

        private void AddPhotoBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (string.IsNullOrWhiteSpace(PhotoNameTb.Text))
                {
                    MessageBox.Show("Введите название фото!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }


                if (DogComboCb.SelectedValue == null)
                {
                    MessageBox.Show("Выберите собаку!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }


                if (string.IsNullOrEmpty(selectedFilePath))
                {
                    MessageBox.Show("Выберите фото!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }


                var newPhoto = new PhotoDog
                {
                    PhotoName = PhotoNameTb.Text,
                    DogId = (int)DogComboCb.SelectedValue,
                    PhotoBit = File.ReadAllBytes(selectedFilePath)
                };


                App.db.PhotoDog.Add(newPhoto);
                App.db.SaveChanges();

                MessageBox.Show("Фото добавлено!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
