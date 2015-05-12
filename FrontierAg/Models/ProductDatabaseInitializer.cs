using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FrontierAg.Models
{
    public class ProductDatabaseInitializer : DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext context)
        { 
            GetCategories().ForEach(c => context.Categories.Add(c));
            GetProducts().ForEach(p => context.Products.Add(p));            
            GetPrice().ForEach(r => context.Prices.Add(r));
        }

        private static List<Category> GetCategories()
        {
            var categories = new List<Category> {
                new Category
                {
                    CategoryId = 1,
                    CategoryName = "Lepidoptra Eggs and Larvae",
                    DateCreated = DateTime.Now,
                    
                },
                new Category
                {
                    CategoryId = 2,
                    CategoryName = "Diet Ingrediants",
                    DateCreated = DateTime.Now,
                    
                },
                new Category
                {
                    CategoryId = 3,
                    CategoryName = "Trays and Lids",
                    DateCreated = DateTime.Now,
                    
                },
                new Category
                {
                    CategoryId = 4,
                    CategoryName = "Cups and Lids",
                    DateCreated = DateTime.Now,
                    
                },
                new Category
                {
                    CategoryId = 5,
                    CategoryName = "Diet Preparation Equipment",
                    DateCreated = DateTime.Now,
                    
                },
                new Category
                {
                    CategoryId = 6,
                    CategoryName = "Vitamin and Mineral Mixes",
                    DateCreated = DateTime.Now,
                    
                },
                new Category
                {
                    CategoryId = 7,
                    CategoryName = "Insect Diets",
                    DateCreated = DateTime.Now,
                    
                },
            };

            return categories;
        }

        private static List<Product> GetProducts()
        {
            var products = new List<Product> {
                new Product
                {
                    ProductId = 1,
                    ProductNo = "E9219",
                    ProductName = "Beet Armyworm, Eggs",
                    Description = "1000/Container",                     
                    DateCreated = DateTime.Now,
                    CategoryId = 1,
                    
               },
                new Product
                {
                    ProductId = 2,
                    ProductNo = "L9219",
                    ProductName = "Beet Armyworm, Larvae",
                    Description = "56/Tray", 
                    DateCreated = DateTime.Now,
                    CategoryId = 1,
                    

               },
                new Product
                {
                    ProductId = 3,
                    ProductNo = "7060",
                    ProductName = "Agar, NF/FCC, 100 Mesh",
                    Description = "", 
                    DateCreated = DateTime.Now,
                    CategoryId = 2,
                    
               },
                new Product
                {
                    ProductId = 4,
                    ProductNo = "1010",
                    ProductName = "Alfalfa Meal, Coarse, Feed Grade",
                    Description = "", 
                    DateCreated = DateTime.Now,
                    CategoryId = 2,
                    
               },
                new Product
                {
                    ProductId = 5,
                    ProductNo = "BAW128",
                    ProductName = "Bio-Assay Tray - 128 Cells",
                    Description = "White, High Intensity Poly Styrene, 120/Case",
                    DateCreated = DateTime.Now,
                    CategoryId = 3,
                    
                },
                new Product
                {
                    ProductId = 6,
                    ProductNo = "BAC128",
                    ProductName = "Bio-Assay Tray - 128 Cells",
                    Description = "Clear, PETG",
                    DateCreated = DateTime.Now,
                    CategoryId = 3,
                    
                },
                new Product
                {
                    ProductId = 7,
                    ProductNo = "9051",
                    ProductName = "1 oz. Creamer",
                    Description = "Clear, Plastic",
                    DateCreated = DateTime.Now,
                    CategoryId = 4,
                    
                },
                new Product
                {
                    ProductId = 8,
                    ProductNo = "9053",
                    ProductName = "1 oz. & 1 1/4 oz. Over Snap Cap",
                    Description = "Translucent",
                    DateCreated = DateTime.Now,
                    CategoryId = 4,
                    
                },
                new Product
                {
                    ProductId = 9,
                    ProductNo = "F9050",
                    ProductName = "Davis Insect Inoculator",
                    Description = "Product# 9046 Plastic Bottle - Required",
                    DateCreated = DateTime.Now,
                    CategoryId = 5,
                    
                },
                new Product
                {
                    ProductId = 10,
                    ProductNo = "9146",
                    ProductName = "Plastic Bottle Inoculator",
                    Description = "Use with Product# F9050",
                    DateCreated = DateTime.Now,
                    CategoryId = 5,
                    
                },
                new Product
                {
                    ProductId = 11,
                    ProductNo = "6265",
                    ProductName = "USDA Vitamin Premix",
                    Description = "",
                    DateCreated = DateTime.Now,
                    CategoryId = 6,
                    
                },
                new Product
                {
                    ProductId = 12,
                    ProductNo = "F8537",
                    ProductName = "Salt Mix, Beck's",
                    Description = "",
                    DateCreated = DateTime.Now,
                    CategoryId = 6,
                    
                },   
                new Product
                {
                    ProductId = 13,
                    ProductNo = "F9219B",
                    ProductName = "Beet Armyworm",
                    Description = "Lepidoptera Spodoptera exigua / Noctuidae Antibiotic: Aureomycin Wheat Germ Base",
                    DateCreated = DateTime.Now,
                    CategoryId = 7,
                    
                },   
                new Product
                {
                    ProductId = 14,
                    ProductNo = "F9441B",
                    ProductName = "Diamondback Moth",
                    Description = "Lepidoptera, Plutella xylostella / plutellidae, Antibiotic: Aureomycin, Soy Flour Base",
                    DateCreated = DateTime.Now,
                    CategoryId = 7,
                    
                },   
            };

            return products;
        }

        private static List<Price> GetPrice()
        {
            var Prices = new List<Price> {
                new Price
                {
                    PriceId = 1,
                    From = 1,
                    To = 4,
                    Unit = Unit.Kg,
                    PriceNumber = 100,                    
                    DateCreated = DateTime.Now,
                    ProductId = 3
                },
                new Price
                {
                    PriceId = 2,
                    From = 5,
                    To = 49,
                    Unit = Unit.Kg,
                    PriceNumber = 85,                    
                    DateCreated = DateTime.Now,
                    ProductId = 3
                },
                new Price
                {
                    PriceId = 3,
                    From = 50,
                    To = 1000000,
                    Unit = Unit.Kg,
                    PriceNumber = 75,                    
                    DateCreated = DateTime.Now,
                    ProductId = 3
                },
                new Price
                {
                    PriceId = 4,
                    From = 1,
                    To = 9,
                    Unit = Unit.Pack,
                    PriceNumber = 4,                    
                    DateCreated = DateTime.Now,
                    ProductId = 4
                },
                new Price
                {
                    PriceId = 5,
                    From = 10,
                    To = 1000000,
                    Unit = Unit.Pack,
                    PriceNumber = 2,                    
                    DateCreated = DateTime.Now,
                    ProductId = 4
                },
            };

            return Prices;
        }
    }
}