using AutoMapper;
using AutoMapper.QueryableExtensions;
using Csms_api.Models;
using Microsoft.EntityFrameworkCore;

namespace Csms_api.Helpers
{
    public static class PaginationHelper
    {
        public static async Task<List<TDestination>> paginateandproject<TSource, TDestination>(
            IQueryable<TSource> query,
            int pageNumber,
            int pageSize, 
            IMapper mapper)
        {
            return await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<TDestination>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public static Paginate<T> paginatedresponse<T>(
            List<T> items,
            int totalCount,
            int pageNumber,
            int pageSize)
        {
            return new Paginate<T>
            {
                Items = items,
                Total_count = totalCount,
                Page_number = pageNumber,
                Page_size = pageSize
            };
        }

    }
}
