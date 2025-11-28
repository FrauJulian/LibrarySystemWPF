using Models;

namespace DbAccess.Access.Publisher;

public class Publisher(IDbCore dbCore) : IPublisher
{
    public IList<PublisherModel> GetAll()
    {
        var publisherList = new List<PublisherModel>();

        const string sql = "SELECT * FROM Publisher";
        var reader = dbCore.RunSql(sql, []);

        while (reader.Read())
            publisherList.Add(new PublisherModel
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Name = reader.GetString(reader.GetOrdinal("Name")),
                Location = reader.GetString(reader.GetOrdinal("Location"))
            });

        return publisherList;
    }
}