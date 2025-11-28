using System.Data;
using Microsoft.Data.SqlClient;
using Models;

namespace DbAccess;

public sealed class Core : IDbCore
{
    public IDataReader RunSql(string sql, IParamValue[] args)
    {
        var connection = new SqlConnection(Constants.ConnectionString);
        var command = new SqlCommand(sql, connection);

        connection.Open();

        if (args.Length <= 0) return command.ExecuteReader(CommandBehavior.CloseConnection);

        foreach (var arg in args) command.Parameters.AddWithValue(arg.Name, arg.Value);

        return command.ExecuteReader(CommandBehavior.CloseConnection);
    }
}