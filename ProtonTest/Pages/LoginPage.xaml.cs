using ProtonTest.Services;
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

namespace ProtonTest.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private bool _isRegisterMode = false;

        public LoginPage()
        {
            InitializeComponent();
        }

        private void SwitchMode_Click(object sender, RoutedEventArgs e)
        {
            _isRegisterMode = !_isRegisterMode;
            TitleText.Text = _isRegisterMode ? "Регистрация" : "Вход в систему";
            FullNameLabel.Visibility = _isRegisterMode ? Visibility.Visible : Visibility.Collapsed;
            FullNameBox.Visibility = _isRegisterMode ? Visibility.Visible : Visibility.Collapsed;
            SubmitBtn.Content = _isRegisterMode ? "Зарегистрироваться" : "Войти";
            SwitchModeBtn.Content = _isRegisterMode ? "Уже есть аккаунт? Войти" : "Нет аккаунта? Зарегистрироваться";
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameBox.Text))
            {
                MessageBox.Show("Введите логин", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            UserSession.CurrentUser = new User
            {
                Username = UsernameBox.Text,
                FullName = _isRegisterMode && !string.IsNullOrWhiteSpace(FullNameBox.Text) ? FullNameBox.Text : UsernameBox.Text
            };

            NavigationService?.Navigate(new DashboardPage());
        }
    }
}
