using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SuperMarket.Core.Models;

namespace SuperMarket.Core.Helpers
{
    public static class SeedHelper
    {
        public static async Task SeedCategories(DataContext context){
            if (await context.Categories.AnyAsync()){
                return;
            }
            await context.Categories.AddAsync(new Category{Name = "Phone"});
            await context.Categories.AddAsync(new Category{Name = "Tivi"});
            await context.SaveChangesAsync();
        }
        public static async Task SeedProducts (DataContext context){
            if (await context.Products.AnyAsync()){
                return;
            }
            await context.Products.AddAsync(new Product{
                Name = "Iphone 11",
                CategoryId = 1,
                Description = "This is a Apple device",
                Price = 500,
                ImageUrl = "This is a image"
            });
            await context.Products.AddAsync(new Product{
                Name = "VSmart TV 2020",
                CategoryId = 2,
                Description = "This is a VSmart device",
                Price = 250,
                ImageUrl = "This is a image"
            });
            await context.SaveChangesAsync();
        }

    }
}
