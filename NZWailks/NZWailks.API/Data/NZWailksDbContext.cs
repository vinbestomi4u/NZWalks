using Microsoft.EntityFrameworkCore;
using NZWailks.API.Models.Domain;

namespace NZWailks.API.Data
{
	public class NZWailksDbContext: DbContext
	{
        public NZWailksDbContext(DbContextOptions<NZWailksDbContext>options): base(options)
        {
            
        }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        public DbSet<WalkDifficulty> WalksDifficulty { get; set; }
    }
}
