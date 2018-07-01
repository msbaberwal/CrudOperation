using ContactInformation.Core.Repositories;

namespace ContactInformation.Core
{
    public interface IUnitofWork
    {
        IContactRepository Contacts { get; }
        void Complete();
    }
}