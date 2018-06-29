using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CompanyData.Models
{
    public partial class CompanyDBContext : DbContext 
    {
        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<CompanyCatagory> CompanyCatagory { get; set; }
        public virtual DbSet<CompanySkills> CompanySkills { get; set; }
        public virtual DbSet<CompanyDetails> CompanyDetails { get; set; }
        public virtual DbSet<ConstructionJunction> ConstructionJunction { get; set; }
        public virtual DbSet<ConstructionSkills> ConstructionSkills { get; set; }
        public virtual DbSet<JobCatagory> JobCatagory { get; set; }
        public virtual DbSet<SkillDetail> SkillDetail { get; set; }
        public virtual DbSet<SkillSet> SkillSet { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<ContactUs> ContactUs { get; set; }

        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<HomePage> HomePage { get; set; }
        public virtual DbSet<Focus> Focus { get; set; }
        public virtual DbSet<CompanyFocus> CompanyFocus { get; set; }   
        public virtual DbSet<TreeNodes> TreeNodes { get; set; }
        public virtual DbSet<FocusNodes> FocusNodes { get; set; }



        public CompanyDBContext(DbContextOptions<CompanyDBContext> options) : base(options) { }

        // Unable to generate entity type for table 'dbo.UsersLogin'. Please see the warning messages.

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //        {
        //            if (!optionsBuilder.IsConfigured)
        //            {
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                optionsBuilder.UseSqlServer(@"Server=HAINES\SQLEXPRESS;Database=TestCompanyDB;Trusted_Connection=True;");
        //            }
        //        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
