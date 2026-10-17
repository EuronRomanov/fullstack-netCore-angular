using server.Data;
using server.Entities;
using server.Interface.Repository;


namespace server.Repository
{
    public class ImageRepository:GenericRepository<Image>, IImageRepository
    {
       

        public ImageRepository(DataContex contex) : base(contex)
        {
        
        }

    }
}
