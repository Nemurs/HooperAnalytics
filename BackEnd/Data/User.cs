using Microsoft.AspNetCore.Identity;

namespace BackEnd.Data
{
    public class User : IdentityUser
    {
        public int Tier {get; set;}
   }
}
