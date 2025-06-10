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
    options.UseSqlServer(builder.Configuration.GetConnectionString("TheWorldOfRecipesContext")
        ?? throw new InvalidOperationException("Connection string 'TheWorldOfRecipesContext' not found.")));

builder.Services.AddServiceModelServices();
builder.Services.AddSingleton<IUserService, UserService>();

var app = builder.Build();

app.UseServiceModel(serviceBuilder =>
{
    serviceBuilder.AddService<UserService>();
    serviceBuilder.AddServiceEndpoint<UserService, IUserService>(
        new BasicHttpBinding(),
        "/UserService.svc"
    );
    // Enable WSDL
    var smb = app.Services.GetRequiredService<CoreWCF.Description.ServiceMetadataBehavior>();
    smb.HttpGetEnabled = true;
});

app.Run();
