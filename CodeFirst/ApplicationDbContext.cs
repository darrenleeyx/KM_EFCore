using Microsoft.EntityFrameworkCore;

namespace CodeFirst;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
}