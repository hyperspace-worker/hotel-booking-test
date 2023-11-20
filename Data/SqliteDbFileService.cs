using Microsoft.Extensions.Configuration;

namespace Data;

public sealed class SqliteDbFileService
{
    public SqliteDbFileService(IConfiguration configuration)
    {
        var dbFilePath = configuration.GetSection("SqliteDbFilePath")["Sqlite"]
            ?? throw new Exception("Sqlite DB file path is not provided!");

        DbFilePath = dbFilePath;
        ConnectionString = @$"Data Source = {dbFilePath}";
    }

    public string DbFilePath { get; }
    public string ConnectionString { get; }
}
