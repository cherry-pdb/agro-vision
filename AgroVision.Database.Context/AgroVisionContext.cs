using AgroVision.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace AgroVision.Database.Context;

public class AgroVisionContext : DbContext
{
    public DbSet<AgrochemicalСharacteristicsDb> AgrochemicalСharacteristics { get; set; }
    
    public DbSet<UserDb> Users { get; set; }

    public AgroVisionContext()
    {
    }

    public AgroVisionContext(DbContextOptions<AgroVisionContext> options)
        : base(options)
    {
    }
}