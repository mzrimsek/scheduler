using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace scheduler.Models.ManageViewModels
{
    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
    }
}
