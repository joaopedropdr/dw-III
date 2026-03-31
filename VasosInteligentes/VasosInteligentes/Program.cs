using AspNetCore.Identity.MongoDbCore.Infrastructure;
using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;
using VasosInteligentes.Data;
using VasosInteligentes.Models;
using VasosInteligentes.Seeds;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Conexão com o mongo
builder.Services.Configure<MongoSettings>(
    builder.Configuration.GetSection("MongoConnection"));
builder.Services.AddSingleton<ContextMongoDb>();

// Configuração do indentity
var mongoSettings = builder.Configuration
    .GetSection("MongoConnection")
    .Get<MongoSettings>();
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>
    (options => 
        {
            // Itens que a senha deve ter. 
            // Minimo 6 letras
            options.Password.RequiredLength = 6;
            // Letras maiusculas
            options.Password.RequireUppercase = false;
            // Letras minusculas
            options.Password.RequireLowercase = false;
            // Letras caracter especial
            options.Password.RequireNonAlphanumeric = false;
            // Numeros
            options.Password.RequireDigit = false;
        })
        .AddMongoDbStores<ApplicationUser, ApplicationRole, string>(mongoSettings.ConnectionString, mongoSettings.Database)
        .AddDefaultTokenProviders();
// Importante para fazer o Scaffolding e as RazorPages para o identity
builder.Services.AddRazorPages();
    
var app = builder.Build();

// Seeds
using (var Scope = app.Services.CreateScope())
{
    var service = Scope.ServiceProvider;
    try
    {
        await IdentitySeeds.SeedRolesAndUser(service, "Adm@123");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro no seed: {ex.Message}");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();
// Acrescentar o UseAuthentication antes do UseAuthorization
// Ele garante que o usuario tem que se logar/autenticar antes de usar o sistema
app.UseAuthentication();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
