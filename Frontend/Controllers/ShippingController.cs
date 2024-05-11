using Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Accessors;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Frontend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShippingController : ControllerBase
    {
        SqlConnection conn =
            new SqlConnection("data source = Kalelius\\SQLEXPRESS; initial catalog = grocery; TrustServerCertificate = True; user id = sa; password = sixpeasinapod");

        IShippingManager shippingManager = new ShippingManager();
        

        [HttpGet("{id}")]
        public List<string> Get(int id)
        {
            return shippingManager.RetrieveAddress(id);
        }

        [HttpPut("{id}/{address}/{state}/{city}/{zip}")]
        public void Put(int id, string address, string state, string city, string zip)
        {
            shippingManager.UpdateAddress(id, address, state, city, zip);
            return;
        }
    }
}
