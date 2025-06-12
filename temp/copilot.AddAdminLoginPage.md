Certainly! Here’s how to add an **Admin Login Page** to your `EllaRecipes.AdminPanel` WPF project that authenticates against your CoreWCF service.

---

## 1. **Add a Login Page**

**Right-click** your WPF project → Add → New Item → Page (WPF) → Name it `AdminLoginPage.xaml`.

---

### **AdminLoginPage.xaml**

```xml
<Page x:Class="EllaRecipes.AdminPanel.AdminLoginPage"
      xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
      xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
      Title="Admin Login">
    <Grid>
        <StackPanel HorizontalAlignment="Center" VerticalAlignment="Center" Width="300">
            <TextBlock Text="Admin Login" FontWeight="Bold" FontSize="18" Margin="0,0,0,20" TextAlignment="Center"/>
            <TextBox x:Name="UsernameBox" PlaceholderText="Username" Margin="0,0,0,10"/>
            <PasswordBox x:Name="PasswordBox" PlaceholderText="Password" Margin="0,0,0,20"/>
            <Button Content="Login" Click="Login_Click" Margin="0,0,0,10"/>
            <TextBlock x:Name="ErrorText" Foreground="Red" TextAlignment="Center"/>
        </StackPanel>
    </Grid>
</Page>

```

---

### **AdminLoginPage.xaml.cs**

```csharp
using System.Windows;
using System.Windows.Controls;

namespace EllaRecipes.AdminPanel
{
    public partial class AdminLoginPage : Page
    {
        public AdminLoginPage()
        {
            InitializeComponent();
        }

        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            ErrorText.Text = "";
            var username = UsernameBox.Text;
            var password = PasswordBox.Password;

            try
            {
                var binding = new System.ServiceModel.BasicHttpBinding();
                var endpoint = new System.ServiceModel.EndpointAddress("http://localhost:50234/UserService.svc");
                var client = new UserServiceClient(binding, endpoint);

                var user = await client.LoginAsyncAsync(username, password);

                if (user != null && user.IsAdmin)
                {
                    // Navigate to the main admin page (e.g., UsersPage)
                    NavigationService.Navigate(new UsersPage());
                }
                else
                {
                    ErrorText.Text = "Access denied. Not an admin.";
                }
            }
            catch (Exception ex)
            {
                ErrorText.Text = "Login failed: " + ex.Message;
            }
        }
    }
}

```
- Replace `UserServiceClient` with the actual name of your generated WCF client.
- Adjust the endpoint URL if your service runs on a different port.

---

## 2. **Show Login Page on Startup**

In your `MainWindow.xaml.cs`:

```csharp
public MainWindow()
{
    InitializeComponent();
    MainFrame.Navigate(new AdminLoginPage());
}

```

---

## 3. **Summary**

- Add `AdminLoginPage.xaml` and code-behind.
- On successful login (and if `IsAdmin` is true), navigate to your admin pages.
- Show error messages for failed logins.

Let me know if you need help with the next steps or want a full working example for user management after login!