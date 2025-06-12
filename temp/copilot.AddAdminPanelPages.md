Certainly! Here’s a clear, step-by-step guide to add WPF pages for user management in your `EllaRecipes.AdminPanel` project. This will let you view all users, edit user details, reset passwords, add, and delete users, using your CoreWCF service.

---

## 1. **Add User Management Pages**

Create the following WPF Pages (not Windows) in your `EllaRecipes.AdminPanel` project:
- `UsersPage.xaml` (list all users, add, delete, select for edit)
- `EditUserPage.xaml` (edit user details, reset password)

**In Solution Explorer:**  
Right-click the project → Add → New Item → Page (WPF) → Name it `UsersPage.xaml`  
Repeat for `EditUserPage.xaml`.

---

## 2. **Set Up Navigation in MainWindow**

In `MainWindow.xaml`, add a `Frame` to host pages:


```xml
<Window x:Class="EllaRecipes.AdminPanel.MainWindow"
        ...>
    <Grid>
        <Frame x:Name="MainFrame" NavigationUIVisibility="Hidden"/>
    </Grid>
</Window>

```

In `MainWindow.xaml.cs`, navigate to the users page on startup:


```csharp
public MainWindow()
{
    InitializeComponent();
    MainFrame.Navigate(new UsersPage());
}

```

---

## 3. **UsersPage.xaml** (List, Add, Delete, Edit)

**XAML Example:**

```xml
<Page x:Class="EllaRecipes.AdminPanel.UsersPage"
      ...>
    <Grid>
        <StackPanel>
            <Button Content="Add User" Click="AddUser_Click" Width="100"/>
            <ListBox x:Name="UsersList" DisplayMemberPath="UserName" Height="300" SelectionChanged="UsersList_SelectionChanged"/>
            <Button Content="Delete Selected" Click="DeleteUser_Click" Width="120"/>
        </StackPanel>
    </Grid>
</Page>

```

**Code-behind (UsersPage.xaml.cs):**

```csharp
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

public partial class UsersPage : Page
{
    public ObservableCollection<UserDTO> Users { get; set; } = new();

    public UsersPage()
    {
        InitializeComponent();
        LoadUsers();
    }

    private async void LoadUsers()
    {
        var client = new UserServiceClient(); // Use your generated WCF client
        var users = await client.GetAllUsersAsyncAsync();
        Users.Clear();
        foreach (var user in users)
            Users.Add(user);
        UsersList.ItemsSource = Users;
    }

    private void AddUser_Click(object sender, RoutedEventArgs e)
    {
        NavigationService.Navigate(new EditUserPage(null));
    }

    private void UsersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (UsersList.SelectedItem is UserDTO user)
            NavigationService.Navigate(new EditUserPage(user));
    }

    private async void DeleteUser_Click(object sender, RoutedEventArgs e)
    {
        if (UsersList.SelectedItem is UserDTO user)
        {
            var client = new UserServiceClient();
            await client.DeleteUserAsyncAsync(user.Id);
            LoadUsers();
        }
    }
}

```

---

## 4. **EditUserPage.xaml** (Edit, Reset Password)

**XAML Example:**

```xml
<Page x:Class="EllaRecipes.AdminPanel.EditUserPage"
      ...>
    <Grid>
        <StackPanel>
            <TextBox x:Name="UserNameBox" PlaceholderText="Username"/>
            <TextBox x:Name="EmailBox" PlaceholderText="Email"/>
            <!-- Add more fields as needed -->
            <Button Content="Save" Click="Save_Click"/>
            <Button Content="Reset Password" Click="ResetPassword_Click"/>
        </StackPanel>
    </Grid>
</Page>

```

**Code-behind (EditUserPage.xaml.cs):**

```csharp
public partial class EditUserPage : Page
{
    private UserDTO _user;

    public EditUserPage(UserDTO user)
    {
        InitializeComponent();
        _user = user ?? new UserDTO();
        UserNameBox.Text = _user.UserName;
        EmailBox.Text = _user.Email;
        // Set other fields
    }

    private async void Save_Click(object sender, RoutedEventArgs e)
    {
        var client = new UserServiceClient();
        _user.UserName = UserNameBox.Text;
        _user.Email = EmailBox.Text;
        // Set other fields

        if (_user.Id == 0)
            await client.RegisterUserAsyncAsync(_user);
        else
            await client.UpdateUserAsyncAsync(_user);

        NavigationService.GoBack();
    }

    private async void ResetPassword_Click(object sender, RoutedEventArgs e)
    {
        var client = new UserServiceClient();
        // Prompt for new password, then:
        await client.ResetPasswordAsyncAsync(_user.Id, "newPassword");
        MessageBox.Show("Password reset.");
    }
}

```

---

## 5. **Wire Up the WCF Client**

- Use the generated `UserServiceClient` from your service reference.
- Make sure to use `await` and `async` for all service calls.

---

## 6. **DTO Reference**

If you checked "Reuse types in referenced assemblies" and reference your shared DTO project, you can use the same `UserDTO` type. Otherwise, use the generated proxy types.

---

## 7. **Summary**

- Add `UsersPage` and `EditUserPage` as WPF Pages.
- Use a `Frame` in `MainWindow` for navigation.
- Use your WCF client to call the service for all user management actions.
- Use async/await for all service calls.

Let me know if you want the full code for any specific page or have questions about wiring up the WCF client!