using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly HotelContext _appDbContext;

        public CategoryRepository(HotelContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Category> GetAll()
        {
            return _appDbContext.Categories;
        }

        public double GetRate(int roomCategoryId)
        {
            Category category = _appDbContext.Categories
                .FirstOrDefault(_ => _.CategoryId == roomCategoryId);
            
            return category?.Rate ?? 0;
        }
    }
}
