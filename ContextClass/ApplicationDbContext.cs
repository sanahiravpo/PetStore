using Microsoft.EntityFrameworkCore;
using PetStore.Model;

namespace PetStore.ContextClass
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext( DbContextOptions options):base(options) { }


        public DbSet<ProductEntity> Products { get; set; }
        
    }
}
