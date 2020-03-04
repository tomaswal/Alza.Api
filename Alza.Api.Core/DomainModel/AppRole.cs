using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alza.Api.Core.DomainModel
{
    public class AppRole : IdentityRole<long>, IEntity<long>
    {
    }
}
