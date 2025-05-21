using CorePayAPI.DTOs.Requests;
using CorePayAPI.Services.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CorePayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        //POST api/<TransactionController>
        [HttpPost("Transfers")]
        public async Task<IActionResult> TransferMoneyAsync([FromBody] TransferRequest request)
        {

            var response = await _transactionService.TransferMoneyAsync(request);

            if (!response.Success)
                return BadRequest(new { error = response.ErrorMessage });

            return Ok(response);
        }

    }
}
