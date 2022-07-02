using Microsoft.AspNetCore.Components.Forms;

namespace BlazorProject.Server.Service
{
    public interface IFileUpload
    {
        Task<string> UploadFile(IBrowserFile file);

        bool DeleteFile(string filePath);
    }
}
