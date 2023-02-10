var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// abilita le richieste di Cors , 
app.UseCors(
    // abilita l'origin da cui puo ricevere una richiesta 
    options => options.WithOrigins("http://localhost:4200")
    //metodi abilitati nella richiesta di Cors
                      .WithMethods("GET","POST","PUT","DELETE")
    //consente qualunque header 
                      .AllowAnyHeader()
);

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
