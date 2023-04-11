using Microsoft.Identity.Client;
using NZWailks.API.Models.Domain;

namespace NZWailks.API.Repository
{
	public interface IRegionRepository
	{
		Task<IEnumerable<Region>>GetAllAsync();

		Task<Region> GetAsync(Guid id);
	}
}
