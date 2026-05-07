using exercicio_p1.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Conexão com o mongo, precisa ser antes de constuir a aplicação com o builder.Bild()
builder.Services.Configure<MongoSettings>(
    // MongoConnection está no appsettings
    builder.Configuration.GetSection("MongoConnection"));
builder.Services.AddSingleton<ContextMongoDb>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
