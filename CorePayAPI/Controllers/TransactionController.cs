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
        [HttpPost("Transaction/{userid}")]
        public async Task<IActionResult> TransferMoney(string userId, [FromBody] TransactionRequest request)
        {
            var sender = await _dataContext.Users.SingleOrDefaultAsync(u => u.UserId == request.senderId);
            var receiver = await _dataContext.Users.SingleOrDefaultAsync(u => u.UserId == request.receiverId);


            if (sender == null || receiver == null)
            {
                return NotFound("User not found");
            }

            if (sender.Balance < request.amount)
            {
                return BadRequest("Insufficient balance");
            }

            sender.Balance -= request.amount;
            receiver.Balance += request.amount;


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

        public class TransactionRequest
        {
            public int senderId { get; set; }
            public int receiverId { get; set; }
            public decimal amount { get; set; }
        }
    }
}
