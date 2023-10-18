using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repository
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);

        Task<List<Walk>> GetAllAsync(string? FilterOn = null, string? FilterQuery = null, string? 
            SortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000);

        Task<Walk?> GetByIdAsync(Guid Id);

        Task<Walk?> UpdateAsync(Guid Id, Walk walk);

        Task<Walk?> DeleteAsync(Guid Id);
    }
}