using Microsoft.AspNetCore.Mvc;
using Mixart.API.Domain.Entities;
using Mixart.API.Domain.Mappers;
using Mixart.API.Domain.Responses;
using Mixart.API.Services;


[ApiController]
[Route("api/[controller]")]
public class TransactionsController : ControllerBase
{
    private readonly ITransactionService _transactionService;

    public TransactionsController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    // GET all transactions
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TransactionResponse>>> GetAll()
    {
        var transactions = await _transactionService.GetAllAsync();
        return transactions.Select(t => t.ToResponse()).ToList();
    }

    // GET transaction by id
    [HttpGet("{id}")]
    public async Task<ActionResult<TransactionResponse>> GetById(Guid id)
    {
        var transaction = await _transactionService.GetByIdAsync(id);
        if (transaction == null) return NotFound();
        return transaction.ToResponse();
    }

    // POST new transaction
    [HttpPost]
    public async Task<ActionResult<TransactionResponse>> Create([FromBody] Transaction transaction)
    {
        if (transaction == null) return BadRequest();

        var createdTransaction = await _transactionService.CreateTransactionAsync(transaction);
        return CreatedAtAction(nameof(GetById), new { id = createdTransaction.Id }, createdTransaction.ToResponse());
    }
}