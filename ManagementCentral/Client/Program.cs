using ManagementCentral.Client;
using ManagementCentral.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http.Headers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("ManagementCentral.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

//builder.Services.AddHttpClient("ManagementCentral.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ManagementCentral.ServerAPI"));

builder.Services.AddApiAuthorization();

var apiBaseAddress = "https://localhost:7169";
//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(apiBaseAddress) });
//builder.Services.AddHttpClient<IDeviceDataService, DeviceDataService>(client =>
//{
//    client.BaseAddress = new Uri(apiBaseAddress/*builder.HostEnvironment.BaseAddress*/);
//    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
//});

builder.Services.AddHttpClient("DevicesClient", client =>
{
    client.BaseAddress = new Uri(apiBaseAddress);
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

builder.Services.AddHttpClient("CitiesClient", client =>
{
    client.BaseAddress = new Uri(apiBaseAddress);
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

//builder.Services.AddHttpClient<ICityDataService, CityDataService>(client =>
//{
//    client.BaseAddress = new Uri(apiBaseAddress);
//});


builder.Services.AddScoped<IDeviceDataService, DeviceDataService>();
builder.Services.AddScoped<ICityDataService, CityDataService>();

await builder.Build().RunAsync();
