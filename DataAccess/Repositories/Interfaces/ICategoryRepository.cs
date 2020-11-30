using DataAccess.Models;
using System.Collections.Generic;

namespace DataAccess.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();

        double GetRate(int roomCategoryId);
    }
}
