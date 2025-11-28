using Models;

namespace DbAccess.Access.Publisher;

public interface IPublisher
{
    public IList<PublisherModel> GetAll();
}