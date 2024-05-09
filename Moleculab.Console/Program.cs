using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moleculab.Core;
using Moleculab.Core.Extensions;
using Moleculab.Core.JSONConvertor;
using Moleculab.Core.Services;
using Moleculab.Core.SQLite;
using Moleculab.Core.SQLite.DTOs;
using Moleculab.Core.SQLite.Services;
using Moleculab.DAL.SQLite;
using Moleculab.DAL.SQLite.Context;
using Moleculab.Math;
using Newtonsoft.Json;
using System;
using System.Text;

public class Program
{
	private static async Task Main(string[] args)
	{
		DotNetEnv.Env.Load();
		Console.WriteLine("Hello, World!");

		// Configure mapper config
		var services = new ServiceCollection();
		var mapper = MapperConfig.RegisterMaps().CreateMapper();
		services.AddSingleton(mapper);
		services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

		// Configure DAL
		services.AddSQLiteDAL("F:\\Projects\\src\\Moleculab\\Database\\QuantumQuerySQLite.db");

		// Configure services
		Moleculab.Core.SQLite.DI.AddSQLiteCore(services);

		var serviceProvider = services.BuildServiceProvider();

		ServiceLocator.SetServiceProvider(serviceProvider);

		var compound = new Compound();

		await compound.Add(Element.H, 2);
		await compound.Add(Element.O, 1);
		await compound.Add(Element.Cl, 1);

		Console.WriteLine(compound.CalculateMolecularWeight());

		// Build the ServiceProvider
		//var serviceProvider = services.BuildServiceProvider();



		// Run your application
		//RunApplication(serviceProvider);

		//DatabaseInitializer.InitializeDatabase();

		//var jsonConverter = new JsonConverter();
		//await jsonConverter.ConvertToJsonFileAsync(
		//	"F:\\Projects\\src\\QuantumQuery\\QuantumQuery.Console\\Input\\PubChemElements_all.json",
		//	"F:\\Projects\\src\\QuantumQuery\\QuantumQuery.Console\\Output\\PubChemElements_all.json");
		//var jsonElementService = new JSONElementService();
		//var elementFromJson = await jsonElementService.GetAllAsync();

		//var sqlBuilder = new StringBuilder();

		//foreach (var element in elementFromJson)
		//{
		//	sqlBuilder.AppendLine(GenerateInsertSql(element));
		//}

		////var outputSql = string.Join("\n", elements);
		//await File.WriteAllTextAsync(@"F:\Projects\src\Moleculab\SQL\Data\ElementData.sql", sqlBuilder.ToString());

		Console.ReadLine();
	}

	private static void ConfigureServices(IServiceCollection services)
	{
        Moleculab.Core.SQLite.DI.AddSQLiteCore(services);
	}

	private static string GenerateInsertSql(ElementDto element)
	{
		var sql = new StringBuilder("INSERT INTO Element (");
		var values = new StringBuilder(" VALUES (");

		AppendSqlPart(sql, values, "Id", $"'{element.Id?.ToString() ?? null}'");
		AppendSqlPart(sql, values, "[Index]", element.Index.ToString());
		AppendSqlPart(sql, values, "ShortName", $"'{element.ShortName}'");
		AppendSqlPart(sql, values, "ElementName", $"'{element.ElementName}'");
		AppendSqlPart(sql, values, "AtomicMass", element.AtomicMass.ToString());
		AppendSqlPart(sql, values, "CpkhexColor", $"'{element.CpkhexColor}'");
		AppendSqlPart(sql, values, "StandardState", $"'{element.StandardState?.ToString() ?? null}'");
		AppendSqlPart(sql, values, "ElectronConfiguration", $"'{element.ElectronConfiguration}'");
		AppendSqlPart(sql, values, "OxidationStates", $"'{element.OxidationStates}'");
		AppendSqlPart(sql, values, "Electronegativity", element.Electronegativity?.ToString() ?? "NULL");
		AppendSqlPart(sql, values, "AtomicRadius", element.AtomicRadius?.ToString() ?? "NULL");
		AppendSqlPart(sql, values, "IonizationEnergy", element.IonizationEnergy?.ToString() ?? "NULL");
		AppendSqlPart(sql, values, "ElectronAffinity", element.ElectronAffinity?.ToString() ?? "NULL");
		AppendSqlPart(sql, values, "MeltingPoint", element.MeltingPoint?.ToString() ?? "NULL");
		AppendSqlPart(sql, values, "BoilingPoint", element.BoilingPoint?.ToString() ?? "NULL");
		AppendSqlPart(sql, values, "Density", element.Density?.ToString() ?? "NULL");
		AppendSqlPart(sql, values, "GroupBlock", $"'{element.GroupBlock}'");
		AppendSqlPart(sql, values, "YearDiscovered", $"'{element.YearDiscovered}'");

		sql.Length--; // Remove the last comma
		values.Length--; // Remove the last comma

		sql.Append(")");
		values.Append(");");

		sql.Append(values.ToString());

		return sql.ToString();
	}

	private static void AppendSqlPart(StringBuilder sql, StringBuilder values, string columnName, string value)
	{
		if (value != null)
		{
			sql.Append($"{columnName},");
			values.Append($"{value},");
		}
	}
}