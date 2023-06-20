
using Blazored.Modal;

using MealOrdering.Server.Services.Extensions;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using MİntiDateAssistant.Server.Data.Models;
using MİntiDateAssistant.Server.Services.Infastruce;
using MİntiDateAssistant.Server.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddBlazoredModal();
builder.Services.ConfigureMapping();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IActivityService, ActivityService>();
builder.Services.AddDbContext<MintiDateAssistantContext>(config => 
{
    config.UseSqlServer("Server=185.8.33.20;Database=MintiDateAssistant;User Id= tugce; Password=Tugçe.54321; TrustServerCertificate=True");
    config.EnableSensitiveDataLogging();


});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
