using Microsoft.Extensions.DependencyInjection;
using TheWorldOfRecipes.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<TheWorldOfRecipesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TheWorldOfRecipesContext") ?? throw new InvalidOperationException("Connection string 'TheWorldOfRecipesContext' not found.")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddSession();

// Add authentication services
builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies", options =>
    {
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/AccessDenied";
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<TheWorldOfRecipesContext>();
    context.Database.EnsureCreated();
    DbInitializer.Initialize(context);
}

//הפעל את שירותי האימות והמשך

app.UseAuthentication(); //הגבלת גישה
app.UseAuthorization();
app.UseSession(); //זכירה שהוא עבר את האימות

//
app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages().WithStaticAssets();

app.Run();
