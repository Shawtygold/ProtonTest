using Microsoft.EntityFrameworkCore;
using ProtonTest.Models;
using ProtonTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private const int _employeeRoleId = 2;

        public LoginPage()
        {
            InitializeComponent();
        }

        private void LoadDepartments()
        {
            using (ApplicationContext context = new())
            {
                DepartmentComboBox.ItemsSource = context.Departments.ToList();
                if (DepartmentComboBox.Items.Count > 0)
                    DepartmentComboBox.SelectedIndex = 0;
            }
        }

        private void SwitchMode_Click(object sender, RoutedEventArgs e)
        {
            _isRegisterMode = !_isRegisterMode;
            TitleText.Text = _isRegisterMode ? "Регистрация" : "Вход в систему";
            FullNameLabel.Visibility = _isRegisterMode ? Visibility.Visible : Visibility.Collapsed;
            FullNameBox.Visibility = _isRegisterMode ? Visibility.Visible : Visibility.Collapsed;

            // Управляем видимостью выбора департамента
            DepartmentLabel.Visibility = _isRegisterMode ? Visibility.Visible : Visibility.Collapsed;
            DepartmentComboBox.Visibility = _isRegisterMode ? Visibility.Visible : Visibility.Collapsed;

            SubmitBtn.Content = _isRegisterMode ? "Зарегистрироваться" : "Войти";
            SwitchModeBtn.Content = _isRegisterMode ? "Уже есть аккаунт? Войти" : "Нет аккаунта? Зарегистрироваться";

            if (_isRegisterMode && DepartmentComboBox.ItemsSource == null)
            {
                LoadDepartments();
            }
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UsernameBox.Text))
            {
                MessageBox.Show("Введите логин", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrEmpty(PasswordBox.Password))
            {
                MessageBox.Show("Введите пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (_isRegisterMode)
            {
                if (string.IsNullOrEmpty(FullNameBox.Text) || !Regex.IsMatch(FullNameBox.Text, "^[А-ЯЁ][а-яё]+(?:-[А-ЯЁ][а-яё]+)*(?:\\s+[А-ЯЁ][а-яё]+(?:-[А-ЯЁ][а-яё]+)*){0,2}$"))
                {
                    MessageBox.Show("Введите ФИО в формате: Иванов Иван Иванович", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                if (DepartmentComboBox.SelectedValue == null)
                {
                    MessageBox.Show("Выберите департамент", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                int selectedDepartmentId = (int)DepartmentComboBox.SelectedValue;
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(PasswordBox.Password);

                // Создаем пользователя с выбранным департаментом
                User user = new(_employeeRoleId, selectedDepartmentId, UsernameBox.Text, FullNameBox.Text, hashedPassword);
                try
                {
                    using (ApplicationContext context = new())
                    {
                        context.Users.Add(user);
                        context.SaveChanges();

                        user = context.Users.Include(x => x.Department).Include(x => x.Role).FirstOrDefault(u => u.Id == user.Id);
                    }
                }
                catch (Exception ex)
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
                        User? dbUser = context.Users.Include(x => x.Department).Include(x => x.Role).FirstOrDefault(u => u.Username == UsernameBox.Text);

                        if (dbUser == null)
                        {
                            MessageBox.Show("Пользователь с таким логином не найден в базе данных");
                            return;
                        }

                        if (!BCrypt.Net.BCrypt.Verify(PasswordBox.Password, dbUser.PasswordHash))
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
