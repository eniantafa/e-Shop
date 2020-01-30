using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tafa_ECommerce.Models;

namespace Tafa_ECommerce.Models
{
    public class DbInitializer
    {

        public static void Seed(IServiceProvider applicationBuilder)
        {
            AppDbContext context =
                applicationBuilder.GetRequiredService<AppDbContext>();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Clothes.Any())
            {
                context.AddRange
                (
                    new Cloth
                    {
                        Name = "Green T-Shirt",
                        Price = 7.95M,
                        ShortDescription = "A green T-shirt",
                        LongDescription = "A green T-shirt made by Gucci Inc.",
                        Category = Categories["Boys"],
                        ImageUrl = "https://photos.app.goo.gl/3U1MmwbgXE81dBLT6",
                        InStock = true,
                        IsPreferredCloth = true,
                        ImageThumbnailUrl = "~/ProductImages/kMwzLOu.jpg"
                    },

                    new Cloth
                    {
                        Name = "Red Dress",
                        Price = 15.45M,
                        ShortDescription = "A red dress",
                        LongDescription = "A luxury red dress made for going out in big events.",
                        Category = Categories["Girls"],
                        ImageUrl = "https://photos.app.goo.gl/3U1MmwbgXE81dBLT6",
                        InStock = true,
                        IsPreferredCloth = true,
                        ImageThumbnailUrl = "~/ProductImages/redDress.jpg",
                        
                    }
                 );
            }

            context.SaveChanges();
        }

        private static Dictionary<string, Category> categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category { CategoryName = "Boys", Description="All clothes for boys" },
                        new Category { CategoryName = "Girls", Description="All clothes for girls" }
                    };

                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        categories.Add(genre.CategoryName, genre);
                    }
                }

                return categories;

            }
        }
    }
}
