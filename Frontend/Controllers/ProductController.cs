using Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;


namespace Frontend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {

        IProductManager productManager = new ProductManager();

        [HttpGet]
        public List<List<String>> Get()
        {

            return productManager.retrieveProductInformation();
        }

        [HttpGet("{cartId}")]
        public List<List<String>> Get(Int32 cartId)
        {
            return productManager.getProductsInCart(cartId);
        }

        [HttpPut("{productId}/{cartId}/{add}")]
        public void Put(int productId, int cartId, bool add)
        {
            productManager.addToCartOrRemoveFromCart(productId, cartId, add);
            return;
        }
    }
}