using Microsoft.AspNetCore.Http;


namespace Application.Services.FileUpload
{
    public interface IFileUploadService
    {
        Task<string> UploadFileAsync(IFormFile file);
        Task<bool> RemoveFile(string path);

    }
}
