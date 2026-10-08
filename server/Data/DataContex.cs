using server.Entities;
using Microsoft.EntityFrameworkCore;

namespace server.Data
{
    public class DataContex:DbContext
    {
        private readonly IConfiguration _config;

       
        public DataContex(DbContextOptions<DataContex> options,IConfiguration config) : base(options) {
            this._config = config;
        }
        protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            string conn = _config["ConnectionStrings:Auth"] ?? throw new Exception("Connection string missing");
            string dbName = _config["ConnectionStrings:DbName"] ?? throw new Exception("DbName missing");
            string dbUser = _config["ConnectionStrings:DbUserId"] ?? throw new Exception("DbUserName missing");
            string dbUserPassword = _config["ConnectionStrings:DbUserPassword"] ?? throw new Exception("Db User Password missing");

            string ConnectionStrings = String.Format(conn, dbName, dbUser, dbUser, dbUserPassword);
            optionsBuilder.UseSqlServer(ConnectionStrings);
            base.OnConfiguring(optionsBuilder);
        }



        public DbSet<User> users{get; set;}
        public DbSet<Brand> brand { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductReview> productReviews { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

    }
}
