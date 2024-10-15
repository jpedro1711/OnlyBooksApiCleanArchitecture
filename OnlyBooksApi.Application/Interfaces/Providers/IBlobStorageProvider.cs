using Microsoft.AspNetCore.Http;

namespace OnlyBooksApi.Application.Interfaces.Providers
{
    public interface IBlobStorageProvider
    {
        string GetFile(string fileName);
        Task UploadFile(IFormFile file, string filename);
    }
}
