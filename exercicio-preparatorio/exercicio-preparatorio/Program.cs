using exercicio_preparatorio.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Conexão com o mongoDB
// Precisa vir antes do builder.Build() para ser registrado no container de injeção de dependência
builder.Services.Configure<MongoSettings>(
    // MongoConnetion esta no appsettings.json
    builder.Configuration.GetSection("MongoConnection"));
builder.Services.AddSingleton<ContextMongoDb>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
