using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace SistemasSeguros.Infrastructure
{
    public class ContextFactory : IDesignTimeDbContextFactory<SisSeguroContext>
    {
        /// <summary>
        ///     Instantiate a MangaContext.
        /// </summary>
        /// <param name="args">Command line args.</param>
        /// <returns>Manga Context.</returns>
        public SisSeguroContext CreateDbContext(string[] args)
        {
            string connectionString = ReadDefaultConnectionStringFromAppSettings();

            DbContextOptionsBuilder<SisSeguroContext> builder = new DbContextOptionsBuilder<SisSeguroContext>();
            builder.EnableSensitiveDataLogging();
            return new SisSeguroContext(builder.Options);
        }

        private static string ReadDefaultConnectionStringFromAppSettings()
        {
            string? envName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                .AddJsonFile("appsettings.json", false)
                .AddJsonFile($"appsettings.{envName}.json", false)
                .AddEnvironmentVariables()
                .Build();

            string connectionString = configuration.GetValue<string>("PersistenceModule:DefaultConnection");
            return connectionString;
        }
    }
}
