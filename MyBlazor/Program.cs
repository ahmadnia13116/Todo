using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using MyBlazor;
using MyBlazor.Libraroes.Product;
using MyBlazor.Libraroes.Ptoduct;
using MyBlazor.Libraroes.ShoppingCart;
using MyBlazor.Libraroes.Storage;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddMudServices();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddSingleton<IStorageService, StorageService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IShappingCartService, ShappingCartService>();

await builder.Build().RunAsync();
