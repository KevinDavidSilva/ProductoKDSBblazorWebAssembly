using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProductoKDSBblazorWebAssembly;
using ProductoKDSBblazorWebAssembly.Data.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddHttpClient("JsonPlaceholder_API", client =>
{
    client.BaseAddress = new Uri("http://productokdsb.somee.com/");
});

builder.Services.AddScoped<PostService>();

await builder.Build().RunAsync();
