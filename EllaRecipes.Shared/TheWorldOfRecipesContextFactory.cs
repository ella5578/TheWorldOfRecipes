using EllaRecipes.Shared.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO; // Add this using directive

public class TheWorldOfRecipesContextFactory : IDesignTimeDbContextFactory<TheWorldOfRecipesContext>
{
    public TheWorldOfRecipesContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory()) // Ensure required using directives are present  
            .AddJsonFile("appsettings.json", optional: true)
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<TheWorldOfRecipesContext>();
        optionsBuilder.UseSqlServer(
            config.GetConnectionString("TheWorldOfRecipesContext"),
            sqlOptions => sqlOptions.EnableRetryOnFailure()
        );
        optionsBuilder.UseSqlServer(
            config.GetConnectionString("TheWorldOfRecipesContext"),
            sqlOptions => sqlOptions.EnableRetryOnFailure()
        );

        return new TheWorldOfRecipesContext(optionsBuilder.Options);
    }
}
