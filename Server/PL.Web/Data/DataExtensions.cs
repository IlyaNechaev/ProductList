using Microsoft.Data.SqlClient;

namespace PL.Web.Data;

public static class DataExtensions
{
    public static void AddSqlDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionStrings = configuration
            .GetSection("ConnectionStrings")
            .GetChildren()
            .Select(n => n.Value);

        foreach (var connectionString in connectionStrings)
        {
            if (IsConnected(connectionString))
            {
                services.AddDbContext<EShopDbContext>(builder =>
                {
                    builder.UseSqlServer(connectionString);
                });
                return;
            }
        }
    }

    private static bool IsConnected(string connectionString)
    {
        using var sqlConnection = new SqlConnection(connectionString);

        try
        {
            sqlConnection.Open();
        }
        catch(SqlException)
        {
            return false;
        }

        return true;
    }
}