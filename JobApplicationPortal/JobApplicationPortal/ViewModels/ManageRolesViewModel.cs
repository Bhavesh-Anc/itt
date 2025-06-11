using System.Collections.Generic;

namespace JobApplicationPortal.ViewModels
{
    public class ManageRolesViewModel
    {
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public IList<string> UserRoles { get; set; }
        public IList<string> AllRoles { get; set; }
    }
}