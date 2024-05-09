using Microsoft.Extensions.Logging;
using Moleculab.Core.Extensions;
using Moleculab.DAL.SQLite;
using Serilog;

namespace Moleculab.UI
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			DotNetEnv.Env.Load();

			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});

#if DEBUG
			builder.Logging.AddDebug();

			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Debug()
				.WriteTo.Console()
				.WriteTo.Seq("http://localhost:5341")
				.CreateLogger();

			Log.Information("Application Starting Up");

#endif

			var mapper = Core.SQLite.MapperConfig.RegisterMaps().CreateMapper();
			builder.Services.AddSingleton(mapper);
			builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

			// Configure DAL
			var SQLitePath = Path.Combine(
				DirectoryExtensions.GetRootDirectory(),
				"Database",
				"MoleculabSQLite.db");
			var directory = Path.GetDirectoryName(SQLitePath);
			if (!Directory.Exists(directory))
			{
				Directory.CreateDirectory(directory);
			}

			builder.Services.AddSQLiteDAL(SQLitePath);

			//register dependency injection
			Core.SQLite.DI.AddSQLiteCore(builder.Services);

			//add service locator
			ServiceLocator.SetServiceProvider(builder.Services.BuildServiceProvider());

			// initialize database
			if (!File.Exists(SQLitePath))
			{
				DatabaseInitializer.Initialize();
			}

			return builder.Build();
		}
	}
}