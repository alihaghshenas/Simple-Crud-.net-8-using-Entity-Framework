using CrudTutorial.Data;
using CrudTutorial.Models.DataModels;
using CrudTutorial.Models.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudTutorial.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CRUDController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public CRUDController(ApplicationDbContext _context)
        {
            this.context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await context.Product.ToListAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await context.Product.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateRequest reqeust)
        {
            Products product = new Products()
            {
                Description = reqeust.Description,
                Name = reqeust.Name,
                Price = reqeust.Price,
                ProductId = reqeust.ProductId
            };
            context.Product.Add(product);
            await context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateReqeust request)
        {
            var product = await context.Product.FirstOrDefaultAsync(x => x.Id == request.Id);
            if (product == null)
                throw new Exception("Product does not exist");

            product.Description = request.Description;
            product.Name = request.Name;
            product.Price = request.Price;
            product.ProductId = request.ProductId;

            context.Product.Update(product);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await context.Product.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
                throw new Exception("Product does not exist");

            context.Product.Remove(product);
            await context.SaveChangesAsync();

            return Ok();
        }
    }
}
