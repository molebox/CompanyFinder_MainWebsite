using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyData.Models
{
    public partial class Companies
    {
        public Companies()
        {
            CompanyCatagory = new HashSet<CompanyCatagory>();
            CompanySkills = new HashSet<CompanySkills>();
            CompanyDetails = new HashSet<CompanyDetails>();
            CompanyFocuses = new HashSet<CompanyFocus>();
            ConstructionJunction = new HashSet<ConstructionJunction>();

            SkillList = new List<SkillSet>();
            DetailList = new List<SkillDetail>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CompanyId { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }
        public string Email { get; set; }
        [Display(Name = "Biography")]
        public string Bio { get; set; }
        public string Website { get; set; }
        public string Phone { get; set; }
        //[Display(Name = "Product Company")]
        //public bool IsProductCompany { get; set; }
        //[Display(Name = "Consultancy Company")]
        //public bool IsConsultantCompany { get; set; }
        //[Display(Name = "Internal Systems Company")]
        //public bool IsInternalSystemCompany { get; set; }

        public ICollection<CompanyCatagory> CompanyCatagory { get; set; }
        public ICollection<CompanySkills> CompanySkills { get; set; }
        public ICollection<CompanyDetails> CompanyDetails { get; set; }
        public ICollection<CompanyFocus> CompanyFocuses { get; set; }
        public ICollection<ConstructionJunction> ConstructionJunction { get; set; }

        [NotMapped]
        public List<SkillSet> SkillList { get; set; }
        [NotMapped]
        public List<SkillDetail> DetailList { get; set; }
    }
}
