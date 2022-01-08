using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Contracts.Request;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class ProductsController : ControllerBase
   {
      private readonly ApiContext _context;
      public ProductsController(ApiContext context)
      {
         _context = context;
      }

      [HttpGet]
      public async Task<ActionResult<List<Product>>> GetProducts()
      {
         var products = await _context.Products.ToListAsync();

         return Ok(products);
      }

      [HttpGet("{id}")]
      public async Task<ActionResult<Product>> GetProduct([FromRoute] int id)
      {
         var product = await _context.Products.FindAsync(id);

         if (product == null) return NotFound();

         return Ok(product);
      }

      [HttpPost]
      public async Task<Boolean> AddProduct([FromBody] ProductDto newProduct)
      {

         var product = new Product();
         product.Name = newProduct.Name;

         await _context.Products.AddAsync(product);
         return await _context.SaveChangesAsync() > 0;

      }
   }
}