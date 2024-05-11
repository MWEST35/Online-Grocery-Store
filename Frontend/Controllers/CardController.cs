using Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Frontend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CardController : ControllerBase
    {
        ICardManager cardManager = new CardManager();

        [HttpGet("{id}")]
        public List<string> Get(int id)
        {
            return cardManager.RetrieveCardInfo(id);
        }

        [HttpPut("{id}/{name}/{num}/{cvv}/{date_month}/{date_year}")]
        public void Put(int id, string name, string num, string cvv, string date_month, string date_year)
        {
            cardManager.UpdateCardInfo(id, name, num, cvv, date_month, date_year);
            return;
        }
    }
}
