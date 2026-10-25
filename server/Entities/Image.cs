using System.Text.Json.Serialization;

namespace server.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }= string.Empty;
        public string ImageName { get; set; }= string.Empty;
        public string ImageNameExt { get; set; }= string.Empty;

        [JsonIgnore]
        public Category Category { get; set; }
         [JsonIgnore]
         public Brand Brand { get; set; }
        [JsonIgnore]
         public Product Product { get; set; }


    }
}
