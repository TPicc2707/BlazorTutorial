global using Blazorecommerce.Shared;
global using System.Net.Http.Json;
global using Blazorecommerce.Client.Services.ProductService;
global using Blazorecommerce.Client.Services.CategoryService;
global using Blazorecommerce.Client.Services.AuthService;
global using Blazorecommerce.Client.Services.CartService;
global using Blazorecommerce.Client.Services.OrderService;
global using Microsoft.AspNetCore.Components.Authorization;
global using Blazorecommerce.Client.Services.AddressService;
using Blazorecommerce.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddOptions();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

await builder.Build().RunAsync();
