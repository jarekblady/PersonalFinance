using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Service.DTOs;
using PersonalFinance.Service.Services.AccountService;

namespace PersonalFinance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("register")]

        public async Task<IActionResult> RegisterUser(RegisterUserDto dto)
        {
            await _accountService.RegisterUser(dto);
            return Ok("Success");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginUserDto dto)
        {
            string token = await _accountService.GenerateJwt(dto);

            var user = new UserDto
            {
                Email = dto.Email,
                Token = token
            };
            return Ok(user);

        }
    }
}
