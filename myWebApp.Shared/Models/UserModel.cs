using Microsoft.AspNetCore.Identity;
using myWebApp.Shared.Models;
using System.Collections.Generic;

namespace myWebApp.Shared
{
    public class UserModel : IdentityUser
    {
       
        public bool IsAuthenticated { get; set; }
        
    }
}
