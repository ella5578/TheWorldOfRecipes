using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using UserServiceClientReference;

namespace EllaRecipes.AdminPanel.Pages
{
    public partial class AdminLoginPage : Window, INotifyPropertyChanged
    {
        private bool _isPasswordVisible;
        private string _password = string.Empty; 
        public event PropertyChangedEventHandler? PropertyChanged; 

        public bool IsPasswordVisible
        {
            get => _isPasswordVisible;
            set { _isPasswordVisible = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public AdminLoginPage()
        {
            InitializeComponent();
            TogglePasswordButton.FontFamily = new System.Windows.Media.FontFamily("Segoe MDL2 Assets");
            DataContext = this;
            IsPasswordVisible = true;
        }

        private void TogglePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            IsPasswordVisible = !IsPasswordVisible;
            if (IsPasswordVisible)
                PasswordTextBox.Text = PasswordBox.Password;
            else
                PasswordBox.Password = PasswordTextBox.Text;
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = PasswordBox.Password;
        }

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            ErrorTextBlock.Visibility = Visibility.Collapsed;
            ProgressBar.Visibility = Visibility.Visible;
            LoginButton.IsEnabled = false;

            string username = UsernameTextBox.Text.Trim();
            string password = Password;

            try
            {
                var client = new UserServiceClient();
                // Replace 'AuthenticateAdminAsync' and result check with your actual service method and logic
                var result = await client.LoginAsync(username, password);

                if (result is not null)
                {
                    // Navigate to UserListPage
                    var userListPage = new UserListPage();
                    var navigationWindow = new NavigationWindow
                    {
                        Content = userListPage
                    };
                    navigationWindow.Show();
                    this.Close();
                }
                else
                {
                    ErrorTextBlock.Text = "Invalid credentials or not an admin.";
                    ErrorTextBlock.Visibility = Visibility.Visible;
                }
                await client.CloseAsync();
            }
            catch (Exception ex)
            {
                ErrorTextBlock.Text = "Login failed: " + ex.Message;
                ErrorTextBlock.Visibility = Visibility.Visible;
            }
            finally
            {
                ProgressBar.Visibility = Visibility.Collapsed;
                LoginButton.IsEnabled = true;
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
