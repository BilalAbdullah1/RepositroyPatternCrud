using Microsoft.EntityFrameworkCore;
using newproj.Models;

namespace newproj.Data
{
    public class CrudContext : DbContext
    {
        public CrudContext(DbContextOptions<CrudContext>options) : base(options)
        {

        }
        public DbSet<Users> users { get; set; }
    }
}
