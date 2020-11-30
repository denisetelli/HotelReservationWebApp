using AutoMapper;
using Business.Services;
using Commom.DTOs;
using DataAccess.Models;
using DataAccess.Repositories.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Business.UnitTests
{
    public class CategoryServiceTests
    {
        [Fact]
        public void Get_ReturnEmptyListCategories()
        {
            //Arrange
            var categoryRepositoryMock = new Mock<ICategoryRepository>();
            var mapperMock = new Mock<IMapper>();

            List<Category> categories = new List<Category>();
            categoryRepositoryMock.Setup(_ => _.GetAll()).Returns(categories);

            List<CategoryDTO> categoriesDTOs = new List<CategoryDTO>();
            mapperMock.Setup(_ => _.Map<List<CategoryDTO>>(categories)).Returns(categoriesDTOs);

            CategoryService categoryService = new CategoryService(categoryRepositoryMock.Object, mapperMock.Object);

            //Act
            var result = categoryService.Get();

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void Get_ReturnCategories()
        {
            //Arrange
            var categoryRepositoryMock = new Mock<ICategoryRepository>();
            var mapperMock = new Mock<IMapper>();
            Category catOne = new Category
            {
                CategoryId = 1
            };
            Category catTwo = new Category
            {
                CategoryId = 2
            };

            List<Category> categories = new List<Category>();
            categories.Add(catOne);
            categories.Add(catTwo);
            categoryRepositoryMock.Setup(_ => _.GetAll()).Returns(categories);

            List<CategoryDTO> categoriesDTOs = new List<CategoryDTO>();
            CategoryDTO catThree = new CategoryDTO
            {
                CategoryId = 3
            };
            CategoryDTO catFour = new CategoryDTO
            {
                CategoryId = 4
            };
            mapperMock.Setup(_ => _.Map<List<CategoryDTO>>(categories)).Returns(categoriesDTOs);
            categoriesDTOs.Add(catThree);
            categoriesDTOs.Add(catFour);
            CategoryService categoryService = new CategoryService(categoryRepositoryMock.Object, mapperMock.Object);

            //Act
            var result = categoryService.Get();

            //Assert
            Assert.True(result.Any());
        }
    }
}
