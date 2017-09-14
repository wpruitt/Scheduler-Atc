using ATCScheduler.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATCScheduler.Models.ViewModels
{
    public class EditProfileViewModel
    {
        public ApplicationUser User { get; set; }

        

        public EditProfileViewModel() { }

        public EditProfileViewModel(ApplicationUser currentUser)
        {
            User = currentUser;
        }
    }
}
