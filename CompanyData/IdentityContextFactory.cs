using System;
using System.Collections.Generic;
using System.Text;
using CompanyData.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CompanyData
{
    public class IdentityContextFactory : IDesignTimeDbContextFactory<AppIdentityDbContext>
    {
        public AppIdentityDbContext CreateDbContext(string[] args)
        {
            //----LOCAL DB CONNECTION STRING----    
            //@"Server=(localdb)\\mssqllocaldb;Database=CompetenceWebsite;Trusted_Connection=True;MultipleActiveResultSets=true";

            var builder = new DbContextOptionsBuilder<AppIdentityDbContext>();
            builder.UseSqlServer(@"Server = RIHA-PC\SQLEXPRESSHAINES; Database = Identity; Trusted_Connection = True;");
            return new AppIdentityDbContext(builder.Options);
        }
    }
}
