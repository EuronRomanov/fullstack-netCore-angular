using server.Entities;
using Microsoft.EntityFrameworkCore;

namespace server.Data
{
    public class DataContex:DbContext
    {


        public DataContex(DbContextOptions<DataContex> options) : base(options) { }
        protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<User> users{get; set;}
    }
}
