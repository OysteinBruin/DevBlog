using DevBlog.Extensions;
using DevBlog.Infrastructure.Extensions;
using DevBlog.Wasm;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Serilog;
using Serilog.Debugging;

//SelfLog.Enable(m => Console.Error.WriteLine(m));

//Log.Logger = new LoggerConfiguration()
//    .MinimumLevel.Information()
//    .WriteTo.BrowserConsole()
//    .CreateLogger();

//Log.Information("Starting up application");

try
{
    var builder = WebAssemblyHostBuilder.CreateDefault(args);
    builder.RootComponents.Add<App>("#app");
    builder.RootComponents.Add<HeadOutlet>("head::after");

    //Log.Information("Adding infrastructure layer");
    builder.AddServices();
    builder.Services.AddMudBlazor();

    await builder.Build().RunAsync();
}
catch (Exception ex)
{
    //Log.Fatal(ex, "An exception occurred while creating the Blazor WASM client aplication");
    throw;
}


