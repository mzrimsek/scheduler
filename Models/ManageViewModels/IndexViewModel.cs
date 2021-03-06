using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace scheduler.Models.ManageViewModels
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }

        public IList<UserLoginInfo> Logins { get; set; }
    }
}
