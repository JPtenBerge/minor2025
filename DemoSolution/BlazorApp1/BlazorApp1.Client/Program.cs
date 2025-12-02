using BlazorApp1.Client.Dal;
using Demo.Shared.Dal;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddTransient<IPersonDal, PersonDal>();
builder.Services.AddMudServices();

await builder.Build().RunAsync();