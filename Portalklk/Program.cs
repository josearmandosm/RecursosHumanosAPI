using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Portalklk;
using Portalklk.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7069") });
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001") });
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7127") });


builder.Services.AddScoped<IBeneficioService, BeneficioService>();
builder.Services.AddScoped<ICapacitacionService, CapacitacionService>();


builder.Services.AddSweetAlert2();


await builder.Build().RunAsync();
