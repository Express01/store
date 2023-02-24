
namespace StoreWebContractors
{
    public interface IWebContractorService
    {
        string UniqueCode { get; }

        string GetUri { get; } 
    }
}