using CorePayAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CorePayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public TransactionController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        //POST api/<TransactionController>
        [HttpPost("Transaction")]
        public async Task<IActionResult> TransferMoney(int senderId, int receiverId, decimal amount)
        {
            var sender = await _dataContext.Users.SingleOrDefaultAsync(u => u.UserId == senderId);
            var receiver = await _dataContext.Users.SingleOrDefaultAsync(u => u.UserId == receiverId);


            if (sender == null || receiver == null)
            {
                return NotFound("User not found");
            }

            if (sender.Balance < amount)
            {
                return BadRequest("Insufficient balance");
            }

            sender.Balance -= amount;
            receiver.Balance += amount;
          

            return Ok(new
            {
                SenderId = sender.UserId,
                SenderName = sender.Name,
                SenderBalance = sender.Balance,
                ReceiverId = receiver.UserId,
                ReceiverName = receiver.Name,
                ReceiverBalance = receiver.Balance
            });

        }
    }
}
