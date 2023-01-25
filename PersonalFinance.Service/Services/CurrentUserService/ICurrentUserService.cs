using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinance.Service.Services.CurrentUserService
{
    public interface ICurrentUserService
    {
        int GetCurrentUserId();
    }
}
