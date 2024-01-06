using Application.Services;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TransactionController : ControllerBase
{
    private readonly UserService _userService;
    private readonly UserManager<AppUser> _userManager;


    public TransactionController(UserService userService, UserManager<AppUser> userManager)
    {
        _userService = userService;
        _userManager = userManager;
    }

    [HttpPost("Deposit")]
    public async Task<IActionResult> Deposit(decimal amount)
    {
        if (amount < 1)
            return BadRequest("Amount should be more than 1");
        
        var user = await _userManager.FindByNameAsync(User.Identity.Name);

        await _userService.Deposit(user.BalanceId,user.Id, amount);
        return Ok("Deposit placed Successfully");
    }
    
    [HttpPost("Withdraw")]
    public async Task<IActionResult> Withdraw(decimal amount)
    {
        if (amount < 1)
            return BadRequest("Amount should be more than 1");
        
        var user = await _userManager.FindByNameAsync(User.Identity.Name);

        await _userService.Withdraw(user.BalanceId,user.Id, amount);
        return Ok("Successfully withdraw");
    }

    [HttpPost("Transfer")]
    public async Task<IActionResult> Transfer(decimal amount, string userName)
    {
        if (amount < 1)
            return BadRequest("Amount should be more than 1");
        
        var destinationUser = await _userManager.FindByNameAsync(userName);
        if (destinationUser == null)
            return BadRequest("Destination user not exists");
        
        var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
        
        await _userService.Transfer(currentUser.BalanceId,
                                    currentUser.Id,
                                    destinationUser.BalanceId,
                                    destinationUser.Id,
                                    amount);

        return Ok("Successfully transfer");
    }
}