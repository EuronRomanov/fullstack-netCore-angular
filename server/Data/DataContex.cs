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

            string ConnectionStrings = string.Format(conn, dbName, dbUser, dbUserPassword);
            optionsBuilder.UseSqlServer(ConnectionStrings);


            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductReview>().HasOne(r=>r.Product).WithMany(p=>p.ProductReviews).HasForeignKey(r=>r.ProductId);
            modelBuilder.Entity<Product>().Property(p=>p.Price).HasPrecision(18,2);
            
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Thumbnail)
                .WithOne(i => i.Product)
                .HasForeignKey<Product>(p => p.ThumbnailId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Category>()
                .HasOne(p => p.Image)
                .WithOne(i => i.Category)
                .HasForeignKey<Category>(p => p.ImageId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Brand>()
                .HasOne(p => p.Image)
                .WithOne(i => i.Brand)
                .HasForeignKey<Brand>(p => p.ImageId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> users{get; set;}
        public DbSet<Brand> brand { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ProductReview> productReviews { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Image> Images { get; set; }

    }
}
