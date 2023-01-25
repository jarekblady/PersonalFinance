using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Service.DTOs;
using PersonalFinance.Service.Services.ExpenditureService;

namespace PersonalFinance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExpenditureController : ControllerBase
    {
        private readonly IExpenditureService _expenditureService;
        public ExpenditureController(IExpenditureService expenditureService)
        {
            _expenditureService = expenditureService;
        }
        [HttpGet]
        public async Task<ActionResult<List<ExpenditureDto>>> GetAllExpenditures()
        {
            var expenditures = await _expenditureService.GetAllExpenditures();

            return Ok(expenditures);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenditureDto>> GetExpenditure(int id)
        {
            return Ok(await _expenditureService.GetByIdExpenditure(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateExpenditure(ExpenditureDto dto)
        {
            await _expenditureService.CreateExpenditure(dto);
            return Ok("Success");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateExpenditure(ExpenditureDto dto)
        {
            await _expenditureService.UpdateExpenditure(dto);
            return Ok("Success");
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExpenditure(int id)
        {
            await _expenditureService.DeleteExpenditure(id);
            return Ok("Success");
        }
    }
}
