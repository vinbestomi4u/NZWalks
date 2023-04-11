using Microsoft.EntityFrameworkCore;
using NZWailks.API.Data;
using NZWailks.API.Models.Domain;


namespace NZWailks.API.Repository
{

	public class RegionRepository : IRegionRepository
	{
		private readonly NZWailksDbContext nZWailksDbContext;

		public RegionRepository(NZWailksDbContext nZWailksDbContext)
        {
			this.nZWailksDbContext = nZWailksDbContext;
		}

        public async Task<IEnumerable<Region>> GetAllAsync()
		{
			return await nZWailksDbContext.Regions.ToListAsync();
		}

		public async Task<Region> GetAsync(Guid id)
		{

			return await nZWailksDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);


		}
	}
}
