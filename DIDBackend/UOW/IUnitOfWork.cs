using DIDBackend.Repositories.Interface;

namespace DIDBackend.UOW
{
    public interface IUnitOfWork
    {
        IAccountRepository AccountRepository { get; }
    }
}
