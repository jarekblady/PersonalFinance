using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Repository.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<IncomeCategory> IncomeCategories { get; set; }
        public ICollection<ExpenditureCategory> ExpenditureCategories { get; set; }
    }
}
