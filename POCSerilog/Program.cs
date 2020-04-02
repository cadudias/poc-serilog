using Serilog;
using Serilog.Events;
using System;

namespace POCSerilog
{
	class Program
	{
		static void Main(string[] args)
		{
			Log.Logger = new LoggerConfiguration()
			.MinimumLevel.Debug()
			.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
			.Enrich.FromLogContext()
			.WriteTo.Console()
			.CreateLogger();

			try
			{
				// Use the static Serilog.Log class for logging.
				Log.Verbose("Here's a Verbose message.");
				Log.Debug("Here's a Debug message. Only Public Properties (not fields) are shown on structured data. Structured data: {@sampleData}. Simple data: {simpleData}.", structuredData, simpleData);
				Log.Information(new Exception("Exceptions can be put on all log levels"), "Here's an Info message.");
				Log.Warning("Here's a Warning message.");
				Log.Error(new Exception("This is an exception."), "Here's an Error message.");
				Log.Fatal("Here's a Fatal message.");
			}
			catch (Exception ex)
			{
				Log.Fatal(ex, "An unhandled exception occurred.");
			}
			finally
			{
				Log.CloseAndFlush();
			}
		}
	}
}
