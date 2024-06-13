using Microsoft.AspNetCore.Http;


namespace GestorPaciente.Core.Application.Helpers
{
    public static class UploadFile
    {
        public static string UploadImage(IFormFile file, string directory, 
            int id, bool isEditMode = false, string imageUrl = "")
        {
            if (isEditMode && file == null)
            {
                return imageUrl;
            }
            string basePath = $"/Images/{directory}/{id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            Guid guid = Guid.NewGuid();
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileName = guid + fileInfo.Extension;
            string fileNameWithPath = Path.Combine(path, fileName);
            using (FileStream stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            if (isEditMode)
            {
                string[] oldImagePart = imageUrl.Split("/");
                string oldImage = oldImagePart[^1];
                string completePath = Path.Combine(basePath, oldImage);
                if (File.Exists(completePath))
                {
                    File.Delete(completePath);
                }
            }
            
            return $"{basePath}/{fileName}";
        }

        public static void RemoveUploadedImage(string directory, int id)
        {
            string basePath = $"/Images/{directory}/{id}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
        }
    }
}
