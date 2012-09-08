using System.Data.Entity;

namespace Portal.Models
{
    public class PortalEntities: DbContext
    {
        public DbSet<Service> Services { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}