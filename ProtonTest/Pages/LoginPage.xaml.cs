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

            if (string.IsNullOrEmpty(PasswordBox.Text))
            {
                MessageBox.Show("Введите пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_isRegisterMode)
            {
                if (string.IsNullOrEmpty(FullNameBox.Text))
                {
                    MessageBox.Show("Введите ФИО", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(PasswordBox.Text);

                User user = new () { Username = UsernameBox.Text, FullName = FullNameBox.Text, PasswordHash = hashedPassword };
                try
                {
                    using (ApplicationContext context = new())
                    {
                        context.Users.Add(user);
                        context.SaveChanges();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                UserSession.CurrentUser = user;
            }
            else
            {
                try
                {
                    using (ApplicationContext context = new())
                    {
                        User? dbUser = context.Users.FirstOrDefault(u => u.Username == UsernameBox.Text);

                        if (dbUser == null)
                        {
                            MessageBox.Show("Пользователь с таким логином не найден в базе данных");
                            return;
                        }

                        if (!BCrypt.Net.BCrypt.Verify(PasswordBox.Text, dbUser.PasswordHash))
                        {
                            MessageBox.Show("Неверный пароль");
                            return;
                        }

                        UserSession.CurrentUser = dbUser;
                    }        
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            NavigationService?.Navigate(new DashboardPage());
        }
    }
}
