using EmployeeMVC;
using EmployeeMVC.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<EmployeeService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7150/");
});

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// Register GlobalSettingsService to provide global access to settings
builder.Services.AddSingleton<GlobalSettingsService>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employee}/{action=Index}/{id?}");

app.Run();
