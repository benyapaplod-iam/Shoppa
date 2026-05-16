using Microsoft.AspNetCore.Mvc;
using Shoppa.Logic;
using Shoppa.Data.Models;

namespace Shoppa.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    // GET ALL PRODUCTS
    [HttpGet("products")]
    public List<Product> GetAllProducts()
    {
        var domain = new DomainLogic(MyConfig.ConnStr);

        return domain.GetAllProducts();
    } 
}