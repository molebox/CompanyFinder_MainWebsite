
using Competence.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Competence.ViewModels
{
    /// <summary>
    /// Company Editor view model for creating and editing companies in the db
    /// </summary>
    public class CompanyEditorViewModel
    {
        /// <summary>
        /// The company id
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// The company name
        /// </summary>
        [Required]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        /// <summary>
        /// The contact person
        /// </summary>
        [Required]
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }
        /// <summary>
        /// The contact email
        /// </summary>
        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }
        /// <summary>
        /// The company biography
        /// </summary>
        [Display(Name = "Biography")]
        public string Bio { get; set; }
        /// <summary>
        /// The company website address
        /// </summary>
        [Required]
        public string Website { get; set; }
        /// <summary>
        /// The contact phone number
        /// </summary>
        [Required]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; }
        /// <summary>
        /// Bool to set if the company is a production company
        /// </summary>
        public bool IsProductCompany { get; set; }
        /// <summary>
        /// Bool to set if the company is a consultancy company
        /// </summary>
        public bool IsConsultantCompany { get; set; }
        /// <summary>
        /// Bool to set if the company is a internal systems company
        /// </summary>
        public bool IsInternalSystemCompany { get; set; }
        /// <summary>
        /// Company object to hold the actual company
        /// </summary>
        public Companies Company { get; set; }  
        /// <summary>
        /// List of the associated skillsets
        /// </summary>
        public List<SkillSet> SkillSetsList { get; set; }
        /// <summary>
        /// List of the associated details
        /// </summary>
        public List<SkillDetail> SkillDetailsList { get; set; }
        /// <summary>
        /// List of all the focuses
        /// </summary>
        public List<Focus> FocusList { get; set; }
      
    }
}
