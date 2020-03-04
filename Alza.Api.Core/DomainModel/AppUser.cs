using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alza.Api.Core.DomainModel
{
    public class AppUser : IdentityUser<long>, IEntity<long>
    {
    }
}
