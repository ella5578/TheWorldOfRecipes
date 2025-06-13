using CoreWCF;
using CoreWCF.Configuration;
using CoreWCF.Description;
using EllaRecipes.Shared.Data;
using Microsoft.EntityFrameworkCore;
using ServiceLibrary.Contracts;
using ServiceLibrary.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Register dependencies, e.g. DbContext
builder.Services.AddRazorPages();
builder.Services.AddDbContext<TheWorldOfRecipesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TheWorldOfRecipesContext")
        ?? throw new InvalidOperationException("Connection string 'TheWorldOfRecipesContext' not found.")));

builder.Services.AddServiceModelServices();
builder.Services.AddServiceModelMetadata();
builder.Services.AddScoped<IUserService, UserService>();

// Enable detailed exception information for debugging
builder.Services.AddSingleton<ServiceDebugBehavior>(provider =>
    new ServiceDebugBehavior
    {
        IncludeExceptionDetailInFaults = true
    });

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

    // DO NOT add ServiceDebugBehavior explicitly here; CoreWCF handles it
    // serviceBuilder.ConfigureServiceHostBase<UserService>(host =>
    // {
    //     var debugBehavior = app.Services.GetRequiredService<ServiceDebugBehavior>();
    //     host.Description.Behaviors.Add(debugBehavior);
    // });
});

app.Run();
