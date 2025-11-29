using System.ComponentModel.Design;
using Kangaro.TodoApp.Application.Services;
using Kangaro.TodoApp.Contracts.Interfaces;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using MyBlazor;
using MyBlazor.Libraroes.Product;
using MyBlazor.Libraroes.Ptoduct;
using MyBlazor.Libraroes.ShoppingCart;
using MyBlazor.Libraroes.Storage;
using MyBlazor.Pages.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped<ITaskItemService, TaskItemLocalStorageService>();
//builder.Services.AddScoped<ICategoryService, CategoryLocalStorageervice>();


builder.Services.AddScoped<ITaskItemService, TaskItemApiService>();
builder.Services.AddScoped<ICategoryService, CategoryApiService>();


builder.Services.AddScoped<ILocalStorage, LocalStorageService>();

builder.Services.AddMudServices();

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("https://localhost:7180")
    //BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)

});
builder.Services.AddSingleton<IStorageService, StorageService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IShappingCartService, ShappingCartService>();

builder.Services.AddScoped<IHealthCheckService, HealthCheckService>();
builder.Services.AddScoped<LocalStorageService>();
builder.Services.AddScoped<TaskItemLocalStorageService>();
builder.Services.AddScoped<CategoryLocalStorageervice>();



await builder.Build().RunAsync();
