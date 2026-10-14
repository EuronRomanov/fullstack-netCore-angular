using server.Entities;
using server.Interface.Repository;
using server.Interface.Service;

namespace server.Service
{
    public class ImageService : IImageService
    {
        private readonly IWebHostEnvironment enviroment;
        private readonly IImageRepository imageRepository;

        public ImageService(IWebHostEnvironment enviroment,IImageRepository imageRepository)
        {
            this.enviroment = enviroment;
            this.imageRepository = imageRepository;
        }

        public async Task DeleteImageAsync(int id)
        {
            Image image = await imageRepository.GetByIdAsync(id);

            if (image == null) throw new ArgumentNullException($"No image found with id {id}");

            var contentPath = enviroment.ContentRootPath;
            var imagePath = contentPath + "Uploads";
            var fileNameWithPath = Path.Combine(imagePath, image.ImageUrl);



            if (!Directory.Exists(imagePath))
            {
                Directory.Delete(imagePath);
            }

            await imageRepository.DeleteAsync(image);

        }




        public async Task<Image> SaveImageAsync(IFormFile file)
        {
            if (file == null) throw new ArgumentNullException("File is empty");

            var contentPath = enviroment.ContentRootPath;
            var imagePath = contentPath + "Uploads";

            if (!Directory.Exists(imagePath))
            {
                Directory.CreateDirectory(imagePath);
            }

            var imageName = file.FileName;
            var imageExt = Path.GetExtension(imageName);
            var fileName = $"{Guid.NewGuid().ToString()}.{imageExt}";
            var fileNameWithPath = Path.Combine(imagePath, fileName);

            using var fileStream = new FileStream(fileNameWithPath, FileMode.Create);
            await file.CopyToAsync(fileStream);

            Image image = new Image() { 
            ImageUrl=fileName,
            ImageName=imageName,
            ImageNameExt=imageExt
            };

           return  await imageRepository.AddAsync(image);

        }
    }
}
