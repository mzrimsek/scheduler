using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using scheduler.Interfaces;
using scheduler.Mappers;
using scheduler.Models;
using scheduler.Models.DatabaseModels;
using scheduler.Models.SchedulerViewModels;

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

        public async Task<bool> AddInviteeFromEmail(string email, ApplicationUser currentUser, Event invitedEvent)
        {
            var trimmedEmail = email.Trim();
            if(!string.IsNullOrEmpty(trimmedEmail) && trimmedEmail != currentUser.Email)
            {
                var inviteeUser = await _userManager.FindByEmailAsync(trimmedEmail);
                if(inviteeUser != null)
                {
                    var inviteeDbModel = InviteeModelMapper.MapFrom(invitedEvent, inviteeUser);
                    _inviteeRepo.Create(inviteeDbModel);
                    return true;
                }    
            }

            return false;
        }

        public async Task<bool> RemoveInviteeFromEmail(string email, Event invitedEvent)
        {
            var trimmedEmail = email.Trim();
            if(!string.IsNullOrEmpty(trimmedEmail))
            {
                var inviteeUser = await _userManager.FindByEmailAsync(trimmedEmail);
                if(inviteeUser != null)
                {
                    var inviteeDbModel = _inviteeRepo.GetByEventIdAndUserId(invitedEvent.Id, inviteeUser.Id);
                    _inviteeRepo.Delete(inviteeDbModel);
                    return true;
                }    
            }

            return false;
        }

        public List<string> GetInviteeEmailsFromView(EventViewModel model)
        {
            if(string.IsNullOrEmpty(model.InviteeEmails))
            {
                return new List<string>();
            }
            var emails = model.InviteeEmails.Split(',');
            var emailsAsList = new List<string>(emails);
            var trimmedEmails = new List<string>();
            foreach(var email in emailsAsList)
            {
                trimmedEmails.Add(email.Trim());
            }
            return trimmedEmails.Distinct().ToList();
        }
    }
}