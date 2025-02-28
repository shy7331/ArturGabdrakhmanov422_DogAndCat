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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }
        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameBox.Text;
            var user = App.db.User.FirstOrDefault(u => u.Name == username);

            if (user != null)
            {
                NavigationService.Navigate(new DogsPage(user));
            }
            else
            {
                MessageBox.Show("Пользователь не найден!");
            }
        }
    }
}
