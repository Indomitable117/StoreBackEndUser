using Microsoft.AspNetCore.Mvc;
using StoreBackend.Api.Mappers;
using StoreBackend.Api.Models.Requests;
using StoreBackend.Facade;
using StoreBackend.Exceptions;

namespace StoreBackend.Api.Controllers;

[ApiController]
[Route("api/products")]
public class ProductController : ControllerBase
{
    private readonly IProductFacade productFacade;

    public ProductController(IProductFacade productFacade)
    {
        this.productFacade = productFacade;
    }

    [HttpGet("test")]
    public IActionResult Test()
    {
        return Ok("Funciona");
    }

    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        try
        {
            var products = await productFacade.GetAllAsync();
            var models = ProductMapper.ToModel(products);
            return Ok(models);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(Guid id)
    {
        try
        {
            var product = await productFacade.GetByIdAsync(id);
            var model = ProductMapper.ToModel(product);
            return Ok(model);
        }
        catch (ResourceNotFoundException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] CreateProductRequestModel product)
    {
        try
        {
            var dto = ProductMapper.ToDto(product);
            var addedProduct = await productFacade.AddAsync(dto);
            var model = ProductMapper.ToModel(addedProduct);

            return CreatedAtAction(nameof(GetProduct), new { id = model.ProductResourceId }, model);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        try
        {
            await productFacade.DeleteAsync(id);
            return Ok();
        }
        catch (ResourceNotFoundException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}