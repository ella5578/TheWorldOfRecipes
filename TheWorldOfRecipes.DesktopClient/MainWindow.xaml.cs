using System.Net.Http;
using System.Net.Http.Json;
using EllaRecipes.Shared.Models;

using System.Windows;
using EllaRecipes.Shared.Models;

namespace TheWorldOfRecipes.DesktopClient
{
    public partial class MainWindow : Window
    {
        private readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:5001/") };

        public MainWindow()
        {
            InitializeComponent();
            LoadUsers();
        }

        private async void LoadUsers()
        {
            var users = await _httpClient.GetFromJsonAsync<List<User>>("api/Users");
            // כאן תוכל להציג את המשתמשים ב-DataGrid, ListView וכו'
            // למשל: myDataGrid.ItemsSource = users;
        }
    }
}
