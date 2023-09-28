using HR.LeaveManagement.BlazorWebAssyUI;
using HR.LeaveManagement.BlazorWebAssyUI.Contracts;
using HR.LeaveManagement.BlazorWebAssyUI.Services;
using HR.LeaveManagement.BlazorWebAssyUI.Services.Base;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// For NSwag Studio stuff. TODO: Get https URI programmatically from API launchSettings?
// Microsoft.Extensions.Http
builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:7168"));
// Services that make use of above client:
builder.Services.AddScoped<ILeaveTypeService, LeaveTypeService>();
builder.Services.AddScoped<ILeaveAllocationService, LeaveAllocationService>();
builder.Services.AddScoped<ILeaveRequestService, LeaveRequestService>();

await builder.Build().RunAsync();
