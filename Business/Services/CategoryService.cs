using AutoMapper;
using Business.Services.Interfaces;
using Commom.DTOs;
using DataAccess.Repositories.Interfaces;
using System.Collections.Generic;

namespace Business.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public IEnumerable<CategoryDTO> Get()
        {
            var categories = _categoryRepository.GetAll();
            var categoriesDTO = _mapper.Map<List<CategoryDTO>>(categories);
            return categoriesDTO;
        }

        public double GetRate(int roomCategoryId)
        {
            return _categoryRepository.GetRate(roomCategoryId);
        }
    }
}
