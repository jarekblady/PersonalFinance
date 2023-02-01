using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalFinance.Repository.Queries;
using PersonalFinance.Service.DTOs;
using PersonalFinance.Service.Services.IncomeCategoryService;

namespace PersonalFinance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IncomeCategoryController : ControllerBase
    {
        private readonly IIncomeCategoryService _incomeCategoryService;
        public IncomeCategoryController(IIncomeCategoryService incomeCategoryService)
        {
            _incomeCategoryService = incomeCategoryService;
        }

        [HttpGet]
        public async Task<ActionResult<List<IncomeCategoryDto>>> GetAllIncomeCategories([FromQuery] CategoryQuery query)
        {
            var incomeCategories = await _incomeCategoryService.GetAllIncomeCategories(query);

            return Ok(incomeCategories);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IncomeCategoryDto>> GetIncomeCategory(int id)
        {
            return Ok(await _incomeCategoryService.GetByIdIncomeCategory(id));
        }

        [HttpPost]
        public async Task<ActionResult> CreateIncomeCategory(IncomeCategoryDto dto)
        {
            await _incomeCategoryService.CreateIncomeCategory(dto);
            return Ok("Success");
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateIncomeCategory(IncomeCategoryDto dto)
        {
            await _incomeCategoryService.UpdateIncomeCategory(dto);
            return Ok("Success");
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteIncomeCategory(int id)
        {
            await _incomeCategoryService.DeleteIncomeCategory(id);
            return Ok("Success");
        }
    }
}
