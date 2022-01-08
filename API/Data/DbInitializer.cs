using System.Collections.Generic;
using System.Linq;
using API.Entities;

namespace API.Data
{
   public static class DbInitializer
   {
      public static void Initialize(ApiContext context)
      {
         if (context.Products.Any()) return;

         var products = new List<Product>()
         {
            new Product{
               Name = "Product 1"
            },
            new Product
            {
               Name = "Product 2"
            },
            new Product
            {
               Name = "Product 3"
            }
         };

         foreach (var product in products)
         {
            context.Add(product);
         }

         context.SaveChanges();
      }
   }
}