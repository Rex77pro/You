using Microsoft.EntityFrameworkCore;

namespace You.Infrastructure.Persistence;

public class YouDbContext: DbContext
{
    public YouDbContext(DbContextOptions<YouDbContext> options)
        : base(options)
    {
    }
}