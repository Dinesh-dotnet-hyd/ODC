namespace PatientService.Helpers
{
    public class ImageStorageHelper
    {
        private readonly IWebHostEnvironment _env;

        public ImageStorageHelper(IWebHostEnvironment env)
        {
            _env = env;
        }

        public async Task<string> SaveProfileImageAsync(IFormFile file)
        {
            var folder = Path.Combine(_env.WebRootPath, "uploads", "patients");
            Directory.CreateDirectory(folder);

            var fileName = $"{Guid.NewGuid()}_{file.FileName}";
            var filePath = Path.Combine(folder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"/uploads/patients/{fileName}";
        }
    }
}
