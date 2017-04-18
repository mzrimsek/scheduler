using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using scheduler.Interfaces;
using scheduler.Models;

namespace scheduler.Helpers
{
    public class InviteeHelper
    {
        private readonly IInviteeRepository _inviteeRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        public InviteeHelper(IInviteeRepository inviteeRepo, UserManager<ApplicationUser> userManager)
        {
            _inviteeRepo = inviteeRepo;
            _userManager = userManager;
        }
        
        public async Task<List<string>> GetInviteeEmails(int eventId)
        {
            var invitees = _inviteeRepo.GetByEventId(eventId);
            var inviteeUserEmails = new List<string>();
            foreach(var invitee in invitees)
            {
                var inviteeUser = await _userManager.FindByIdAsync(invitee.UserId);
                inviteeUserEmails.Add(inviteeUser.Email);
            }

            return inviteeUserEmails;
        }
    }
}