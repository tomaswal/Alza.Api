using Alza.Api.Core.DomainModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Alza.Api.Infrastructure
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, long>
    {
    }
}
