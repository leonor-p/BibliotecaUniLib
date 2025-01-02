using Biblioteca_UniLib.Data;
using Biblioteca_UniLib.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<DbInitializer>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    SeedRoles.Seed(roleManager);

    var services = scope.ServiceProvider;
    var initializer = services.GetRequiredService<DbInitializer>();
    initializer.Run();
}
// Apply migrations automatically and seed the database with initial data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

try
{
        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.Migrate();


        // Seed the database with initial data if necessary
        if (!context.Livros.Any())
        {
            context.Livros.AddRange(
                new Livro
                {
                    Titulo = "Exemplo de Livro",
                    Autor = "Autor Exemplo",
                    Categoria = "Categoria Exemplo",
                    AnoPublicacao = new DateTime(2020, 1, 1),
                    ISBN = "123-4567890123",
                    ImagemUrl = "/imagens/default-book-cover.png",
                    EmDestaque = true
                },
                new Livro
                {
                    Titulo = "Outro Livro Exemplo",
                    Autor = "Outro Autor",
                    Categoria = "Outra Categoria",
                    AnoPublicacao = new DateTime(2021, 1, 1),
                    ISBN = "123-4567890124",
                    ImagemUrl = "/imagens/default-book-cover.png",
                    EmDestaque = false
                }
            );
            context.SaveChanges();
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while migrating or initializing the database.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();