using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperMarket.Core;
using SuperMarket.Core.Models;

namespace SuperMarket.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;
        public CategoryService (DataContext context){
            _context = context;
        }
        public Category AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Id == categoryId);
            if (category == null){
                return;
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public Category EditCategory(int categoryId, Category category)
        {
            var editCategory = _context.Categories.FirstOrDefault(x => x.Id == categoryId);
            if (editCategory == null){
                return null;
            }
            editCategory.Name = category.Name;
            _context.SaveChanges();
            return editCategory;
        }

        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategory(int categoryId)
        {
            return _context.Categories.FirstOrDefault(x => x.Id == categoryId);
        }
    }
}