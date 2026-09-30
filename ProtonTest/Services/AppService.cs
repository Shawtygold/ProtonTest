using System.Collections.ObjectModel;
using System.Windows;

namespace ProtonTest.Services
{
    public static class ThemeManager
    {
        public static bool IsDark { get; private set; } = false;

        public static void ToggleTheme()
        {
            IsDark = !IsDark;

            string themePath = IsDark
                ? "pack://application:,,,/Themes/DarkTheme.xaml"
                : "pack://application:,,,/Themes/LightTheme.xaml";

            var newTheme = new ResourceDictionary { Source = new Uri(themePath, UriKind.Absolute) };

            var appResources = Application.Current.Resources.MergedDictionaries;
            appResources.Clear();
            appResources.Add(newTheme);
        }
    }

    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string PasswordHash { get; set; }
    }

    public static class UserSession
    {
        public static User CurrentUser { get; set; }
    }
}
