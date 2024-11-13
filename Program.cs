var builder = WebApplication.CreateBuilder(args);

// Configuraci�n de servicios
builder.Services.AddControllersWithViews();

// Crear la aplicaci�n
var app = builder.Build();

// Configuraci�n del middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Mapeo de rutas
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Memory}/{action=Index}/{id?}");

app.Run();
