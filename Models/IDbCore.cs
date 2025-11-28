using System.Data;

namespace Models;

public interface IDbCore
{
    public IDataReader RunSql(string sql, IParamValue[] args);
}