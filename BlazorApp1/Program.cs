using BlazorApp1;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApp1.Data.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44387") });

builder.Services.AddScoped<IClientProvider, ClientsProvider>();
builder.Services.AddScoped<IParcelProvider, ParcelsProvider>();
builder.Services.AddScoped<IReceiverProvider, ReceiversProvider>();
builder.Services.AddScoped<IReceptionProvider, ReceptionsProvider>();
builder.Services.AddScoped<ISenderProvider, SendersProvider>();

await builder.Build().RunAsync();
