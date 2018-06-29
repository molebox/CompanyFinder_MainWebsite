using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Competence.Models
{
    /// <summary>
    /// Company model
    /// </summary>
    public class Companies
    {

        /// <summary>
        /// Company id
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// Company Name
        /// </summary>
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        /// <summary>
        /// Contact Person
        /// </summary>
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }
        /// <summary>
        /// Email Address
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Company Biography
        /// </summary>
        [Display(Name = "Biography")]
        public string Bio { get; set; }
        /// <summary>
        /// Company Website
        /// </summary>
        public string Website { get; set; }
        /// <summary>
        /// Company Phone
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Company Skills
        /// </summary>
        public ICollection<CompanySkills> CompanySkills { get; set; }
        /// <summary>
        /// Company Details
        /// </summary>
        public ICollection<CompanyDetails> CompanyDetails { get; set; }
        /// <summary>
        /// Company Focuses
        /// </summary>
        public ICollection<CompanyFocus> CompanyFocuses { get; set; }

        /// <summary>
        /// Skill list
        /// </summary>
        public List<SkillSet> SkillList { get; set; }
        /// <summary>
        /// Detail list
        /// </summary>
        public List<SkillDetail> DetailList { get; set; }

        /// <summary>
        /// Template status
        /// </summary>
        public string TemplateStatus { get; set; }
    }
}
