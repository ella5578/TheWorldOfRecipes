using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;
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
builder.Services.AddServiceModelMetadata();
builder.Services.AddScoped<IUserService, UserService>();

// Remove or comment out this block, as ServiceBehaviorOptions does not exist in CoreWCF
// builder.Services.Configure<ServiceBehaviorOptions>(options =>
// {
//     options.IncludeExceptionDetailInFaults = true;
// });

var app = builder.Build();

app.UseServiceModel(serviceBuilder =>
{
    serviceBuilder.AddService<UserService>();
    serviceBuilder.AddServiceEndpoint<UserService, IUserService>(
        new BasicHttpBinding(),
        "/UserService.svc"
    );
    // Enable WSDL
    var smb = app.Services.GetRequiredService<ServiceMetadataBehavior>();
    smb.HttpGetEnabled = true;
});

app.Run();
