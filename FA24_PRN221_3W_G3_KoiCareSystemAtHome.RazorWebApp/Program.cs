using FA24_PRN221_3W_G3_KoiCareSystemAtHome.RazorWebApp;
using FA24_PRN221_3W_G3_KoiCareSystemAtHome.Repositories;
using FA24_PRN221_3W_G3_KoiCareSystemAtHome.Repositories.Models;
using FA24_PRN221_3W_G3_KoiCareSystemAtHome.Services;

var builder = WebApplication.CreateBuilder(args);

//builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Add services to the container.
builder.Services.AddRazorPages();

//Add DI
//builder.Services.AddScoped<FA24_PRN221_3W_G3_KoiCareSystemAtHomeContext>();
builder.Services.AddScoped<PondService>();
//builder.Services.AddScoped<IUserService , UserService>();
//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromMinutes(30);
//    options.Cookie.HttpOnly = true;
//    options.Cookie.IsEssential = true;
//});

builder.Services.AddSignalR();
builder.Services.AddSingleton<SignalRServer>();





var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//app.UseSession();

app.MapRazorPages();

app.MapHub<SignalRServer>("/signalRServer");

app.Run();
