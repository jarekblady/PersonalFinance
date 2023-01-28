using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.DTOs
{
    public class IncomeCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<IncomeDto> Incomes { get; set; }
    }
}
