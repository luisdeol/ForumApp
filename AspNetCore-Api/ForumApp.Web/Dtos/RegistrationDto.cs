using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumApp.Core;

namespace ForumApp.Web.Dtos
{
    public class ApplicationUserDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ApplicationUser GetApplicationUser()
        {
            return new ApplicationUser
            {
                Email = Email,
                UserName = UserName
            };
        }
    }
}
