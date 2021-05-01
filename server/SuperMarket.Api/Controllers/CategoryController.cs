using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.Core.Models;
using SuperMarket.Services;

namespace SuperMarket.Api.Controllers
{
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public List<Category> Get(){
            return _categoryService.GetCategories();
        }
        [HttpGet("{categoryId}")]
        public Category Get([FromRoute]int categoryId){
            return _categoryService.GetCategory(categoryId);
        }
        [HttpPost]
        public Category Post([FromBody]Category category){
            return _categoryService.AddCategory(category);
        }
        [HttpPut("{categoryId}")]
        public Category Put (int categoryId, [FromBody] Category category){
            return _categoryService.EditCategory(categoryId, category);
        }
        [HttpDelete("{categoryId}")]
        public void Delete (int categoryId){
            _categoryService.DeleteCategory(categoryId);
        }
    }
}