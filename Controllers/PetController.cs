using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetStore.ContextClass;
using PetStore.DTOS;
using PetStore.Model;

namespace PetStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {

        public readonly ApplicationDbContext Context;
        public PetController(ApplicationDbContext context)
        {
            Context = context;
        }




        [HttpPost]
        public async Task<IActionResult> Createproduct([FromBody] CreateProductDto prodcutdto)
        {
            var newproduct = new ProductEntity()
            {
                Brand = prodcutdto.Brand,
                Title = prodcutdto.Title,
            };
            await Context.Products.AddAsync(newproduct);
            await Context.SaveChangesAsync();   
            return Ok("Product added successfully");
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute]long id, CreateProductDto prodcutdto)
        {
            var product = await Context.Products.FirstOrDefaultAsync(o => o.id == id);

            if (product == null)
            {
                return NotFound("product is not found");

            }

            product.Brand= prodcutdto.Brand;
            product.Title= prodcutdto.Title;
            product.UpdatedAt = DateTime.Now;
            await Context.SaveChangesAsync();
           
            return Ok("Product updated  successfully");
        }

        [HttpGet]

        public async Task<ActionResult<List<ProductEntity>>> GetAllProducts()
        {
            var products=await Context.Products.ToListAsync();
            return Ok(products);
        }


        [HttpDelete("{id}")]

        public async Task<IActionResult>  DeleteProducts([FromRoute] long id)
        {
            var productidentified=await Context.Products.FirstOrDefaultAsync(o=>o.id==id);
            if (productidentified == null)
            {
               return NotFound("the product is not found");

            }
             Context.Products.Remove(productidentified);

            await Context.SaveChangesAsync();
            return Ok("product deleted");
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetProductById(long id)
        {
            var productidentified = await Context.Products.FirstOrDefaultAsync(o => o.id == id);
            if (productidentified != null)
            {
               return Ok(productidentified);

            }
            else
            {
                return NotFound("product not found");
            }
            
        }
    }
}
