using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace PL.Web.Data;

public static class DataExtensions
{
    const string ASPNET_CONNECTION = "ASPNET_DB_CONNECTION";

    public static void AddSqlDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var envs = Environment.GetEnvironmentVariables();
        var csType = Environment.GetEnvironmentVariable(ASPNET_CONNECTION);

        if (csType == null)
        {
            var tempColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Переменная {ASPNET_CONNECTION} не задана");
            csType = "Default";

            Console.ForegroundColor = tempColor;

            throw new Exception($"Переменная {ASPNET_CONNECTION} не задана");
        }

        var connectionString = configuration.GetConnectionString(csType);

        services.AddDbContext<EShopDbContext>(builder =>
        {
            builder.UseSqlServer(connectionString);
        });
    }

    //private static bool IsConnected(string connectionString)
    //{
    //    using var sqlConnection = new SqlConnection(connectionString);

    //    try
    //    {
    //        sqlConnection.Open();
    //    }
    //    catch (SqlException)
    //    {
    //        return false;
    //    }

    //    return true;
    //}
}