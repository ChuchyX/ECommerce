using Blazored.LocalStorage;
using Blazored.Toast;
using ECommerce.Client;
using ECommerce.Client.Services.CartService;
using ECommerce.Client.Services.CategoryService;
using ECommerce.Client.Services.ProductService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredToast();


await builder.Build().RunAsync();
