using Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Frontend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ICartManager cartManager = new CartManager();

        [HttpGet("{userId}")]
        public Int32 Get(Int32 userId)
        {
            return cartManager.getUsersCart(userId);
        }

        [HttpDelete("{cartId}")]
        public void Delete(Int32 cartId)
        {
            cartManager.checkoutCart(cartId);
            return;
        }

    }
}
