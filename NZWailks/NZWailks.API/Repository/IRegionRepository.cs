using NZWailks.API.Models.Domain;

namespace NZWailks.API.Repository
{
	public interface IRegionRepository
	{
		Task<IEnumerable<Region>>GetAllAsync();
	}
}
