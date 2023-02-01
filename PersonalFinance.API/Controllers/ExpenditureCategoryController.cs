using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Repository.Queries;
using PersonalFinance.Service.DTOs;
using PersonalFinance.Service.Services.ExpenditureCategoryService;

namespace PersonalFinance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExpenditureCategoryController : ControllerBase
    {
        private readonly IExpenditureCategoryService _expenditureCategoryService;
        public ExpenditureCategoryController(IExpenditureCategoryService expenditureCategoryService)
        {
            _expenditureCategoryService = expenditureCategoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ExpenditureCategoryDto>>> GetAllExpenditureCategories([FromQuery] CategoryQuery query)
        {
            var expenditureCategories = await _expenditureCategoryService.GetAllExpenditureCategories(query);

            return Ok(expenditureCategories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenditureCategoryDto>> GetExpenditureCategory(int id)
        {
            return Ok(await _expenditureCategoryService.GetByIdExpenditureCategory(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateExpenditureCategory(ExpenditureCategoryDto dto)
        {
            await _expenditureCategoryService.CreateExpenditureCategory(dto);
            return Ok("Success");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateExpenditureCategory(ExpenditureCategoryDto dto)
        {
            await _expenditureCategoryService.UpdateExpenditureCategory(dto);
            return Ok("Success");
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteExpenditureCategory(int id)
        {
            await _expenditureCategoryService.DeleteExpenditureCategory(id);
            return Ok("Success");
        }
    }
}
