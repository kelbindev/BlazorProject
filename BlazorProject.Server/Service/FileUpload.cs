using Microsoft.AspNetCore.Components.Forms;

namespace BlazorProject.Server.Service
{
    public class FileUpload : IFileUpload
    {
        private readonly IWebHostEnvironment webHostEnvironment;

        public FileUpload(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }
        public bool DeleteFile(string filePath)
        {
            if (File.Exists(webHostEnvironment.WebRootPath+filePath) && !filePath.EndsWith("default.png")) {
                File.Delete(webHostEnvironment.WebRootPath+filePath);
                return true;
            }
            return false;
        }

        public async Task<string> UploadFile(IBrowserFile file)
        {
            FileInfo fileInfo = new(file.Name);
            var fileName = Guid.NewGuid().ToString() + fileInfo.Extension;
            var folderDirectory = $"{webHostEnvironment.WebRootPath}\\images\\Product";

            if (!Directory.Exists(folderDirectory)) Directory.CreateDirectory(folderDirectory);

            var filePath = Path.Combine(folderDirectory, fileName);

            await using FileStream fs = new FileStream(filePath,FileMode.Create);
            await file.OpenReadStream().CopyToAsync(fs);

            var fullPath = $"/images/Product/{fileName}";
            return fullPath;
        }
    }
}
