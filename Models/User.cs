using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Heroes.Models
{
    public class User : IdentityUser
    {
       public List<Hero> userHeroList;
    }
}
