using ManagementCentral.Client;
using ManagementCentral.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("ManagementCentral.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ManagementCentral.ServerAPI"));

builder.Services.AddApiAuthorization();

var apiBaseAddress = "https://localhost:7169";
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseAddress) });
builder.Services.AddHttpClient<IDeviceDataService, DeviceServiceData>(client =>
{
    client.BaseAddress = new Uri(apiBaseAddress/*builder.HostEnvironment.BaseAddress*/);
});

builder.Services.AddScoped<IDeviceDataService, DeviceServiceData>();

await builder.Build().RunAsync();
