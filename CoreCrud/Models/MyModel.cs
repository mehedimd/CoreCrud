using Microsoft.EntityFrameworkCore;

namespace CoreCrud.Models
{
    public class MyModel : DbContext
    {
        public MyModel(DbContextOptions<MyModel> options) : base(options)
        {

        }
        public DbSet<Faculty> Faculties { get; set;}
    }
}
