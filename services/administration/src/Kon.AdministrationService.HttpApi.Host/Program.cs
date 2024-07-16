using Kon.BillingBash.Shared.Hosting.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Kon.AdministrationService;

public class Program
{
    public static async Task<int> Main(string[] args)
    {
	    var assemblyName = typeof(Program).Assembly.GetName().Name!;
	    SerilogConfigurationHelper.Configure(assemblyName);

	    try
	    {
		    Log.Information($"Starting {assemblyName}.");

		    var builder = WebApplication.CreateBuilder(args);
		    builder.Host
			    .UseAutofac()
			    .UseSerilog();
		    await builder.AddApplicationAsync<AdministrationServiceHttpApiHostModule>();

		    var app = builder.Build();
		    await app.InitializeApplicationAsync();
		    await app.RunAsync();

		    return 0;
	    }
	    catch (Exception ex)
	    {
		    Log.Fatal(ex, $"{assemblyName} terminated unexpectedly!");
		    return 1;
	    }
	    finally
	    {
		    await Log.CloseAndFlushAsync();
	    }
    }
}
