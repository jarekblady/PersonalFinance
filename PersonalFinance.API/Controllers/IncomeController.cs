using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Service.DTOs;
using PersonalFinance.Service.Services.IncomeService;

namespace PersonalFinance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeService _incomeService;
        public IncomeController(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }
        [HttpGet]
        public async Task<ActionResult<List<IncomeDto>>> GetAllIncomes()
        {
            var incomes = await _incomeService.GetAllIncomes();

            return Ok(incomes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IncomeDto>> GetIncome(int id)
        {
            return Ok(await _incomeService.GetByIdIncome(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateIncome(IncomeDto dto)
        {
            await _incomeService.CreateIncome(dto);
            return Ok("Success");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateIncome(IncomeDto dto)
        {
            await _incomeService.UpdateIncome(dto);
            return Ok("Success");
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteIncome(int id)
        {
            await _incomeService.DeleteIncome(id);
            return Ok("Success");
        }
    }
}
