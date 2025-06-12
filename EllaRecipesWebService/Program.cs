using CoreWCF;
using CoreWCF.Configuration;
using EllaRecipes.Shared.Data;
using Microsoft.EntityFrameworkCore;
using ServiceLibrary.Contracts;
using ServiceLibrary.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Register dependencies, e.g. DbContext
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<TheWorldOfRecipesContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("TheWorldOfRecipesContext")
            ?? throw new InvalidOperationException("Connection string 'TheWorldOfRecipesContext' not found."),
            sqlOptions => sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(30),
                errorNumbersToAdd: null
            )
    ));

builder.Services.AddServiceModelServices();
builder.Services.AddServiceModelMetadata(); // <--- REQUIRED FOR WSDL
builder.Services.AddScoped<IUserService, UserService>();

// Register ServiceMetadataBehavior before building the app
builder.Services.AddSingleton<CoreWCF.Description.ServiceMetadataBehavior>(provider =>
{
    var smb = new CoreWCF.Description.ServiceMetadataBehavior { HttpGetEnabled = true };
    return smb;
});

var app = builder.Build();

app.UseServiceModel(serviceBuilder =>
{
    serviceBuilder.AddService<UserService>();
    serviceBuilder.AddServiceEndpoint<UserService, IUserService>(
        new BasicHttpBinding(),
        "/UserService.svc"
    );
    // No service registration here; just retrieve the already-registered ServiceMetadataBehavior if needed
    // var smb = app.Services.GetRequiredService<CoreWCF.Description.ServiceMetadataBehavior>();
    // smb.HttpGetEnabled = true; // Already set during registration
});

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<TheWorldOfRecipesContext>();
    try
    {
        // Try to connect and query the database
        db.Database.CanConnect();
        // Optionally, try a simple query:
        var anyUser = db.Users.FirstOrDefault();
        Console.WriteLine(anyUser?.UserName);
        var anyRecipe = db.Recipes.FirstOrDefault();
        Console.WriteLine(anyRecipe);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Database connection failed: {ex.Message}");
        throw; // Optionally rethrow to stop startup
    }
}


app.Run();
