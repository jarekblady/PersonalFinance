using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.DTOs
{
    public class ExpenditureDto
    {
        public int Id { get; set; }
        public double Price { get; set; }
        public string? Comment { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
