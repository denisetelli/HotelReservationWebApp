using Commom.DTOs;
using System.Collections.Generic;

namespace Business.Services.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryDTO> Get();

        double GetRate(int roomCategoryId);
    }
}
