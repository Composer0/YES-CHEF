﻿//using Microsoft.CodeAnalysis.CSharp.Syntax;
//using Npgsql;

//namespace Bard.Server.Helpers
//{
//	public class ConnectionHelper
//	{
//		public static string GetConnectionString(IConfiguration configuration)
//		{
//			var connectionString = configuration.GetSection("pgSettings")["pgConnection"];
//			//var connectionString = configuration.GetConnectionString("DefaultConnection");
//			var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL"); //Environment is different on each platform. both the configuration and the environment can not be true. One or the other will run.

//			return string.IsNullOrEmpty(databaseUrl) ? connectionString : BuildConnectionString(databaseUrl);
//			//ternary operator!
//		}
//		//build a connection string from the environment.
//		//Universal Resource Identity = Identifies a resource. Can also be a url. URL is used to find a resource.
//		private static string BuildConnectionString(string databaseUrl)
//		{
//			var databaseUri = new Uri(databaseUrl);
//			var userInfo = databaseUri.UserInfo.Split(':');
//			var builder = new NpgsqlConnectionStringBuilder
//			{
//				Host = databaseUri.Host,
//				Port = databaseUri.Port,
//				Username = userInfo[0],
//				Password = userInfo[1],
//				Database = databaseUri.LocalPath.TrimStart('/'),
//				SslMode = SslMode.Require,
//				TrustServerCertificate = true
//			};
//			return builder.ToString();
//		}
//	}
//}
