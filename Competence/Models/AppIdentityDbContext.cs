using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Competence.Models
{
    /// <summary>
    /// Identity context
    /// </summary>
    public class AppIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options) { }

    }
}
