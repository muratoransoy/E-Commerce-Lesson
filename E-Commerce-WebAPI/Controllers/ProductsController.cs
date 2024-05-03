using E_Commerce.DAL.Abstract;
using E_Commerce.Data.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductDAL _productDAL;

        public ProductsController(IProductDAL productDAL)
        {
            _productDAL = productDAL;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_productDAL.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if(id == null || _productDAL.GetAll() == null)
                return BadRequest();

            var product = _productDAL.Get(Convert.ToInt32(id));
            if (product == null)
                return NotFound();  

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                _productDAL.Add(product);
                return Ok(product);
            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Put([FromBody] Product product)
        {
            if (ModelState.IsValid)
            {
                _productDAL.Update(product);
                return Ok(product);
            }
            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var product = _productDAL.Get(x => x.Id == id);

            if (product == null)
                return BadRequest();

            _productDAL.Delete(id);
            return Ok(product);
        }
    }
}
