using Competence.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Competence.ViewModels
{
    /// <summary>
    /// View model to show the skills
    /// </summary>
    public class SkillsViewModel
    {
        /// <summary>
        /// List of all the companies in the database
        /// </summary>
        public List<Companies> Companies { get; set; }
        /// <summary>
        /// List of the skills
        /// </summary>
        public List<SkillSet> SkillSetsList { get; set; }
        /// <summary>
        /// List of the details
        /// </summary>
        public List<SkillDetail> SkillDetailsList { get; set; }
        /// <summary>
        /// List of the Focuses
        /// </summary>
        public List<Focus> FocusList { get; set; }

        /// <summary>
        /// view model constructor that initializes the lists
        /// </summary>
        public SkillsViewModel()
        {
            SkillSetsList = new List<SkillSet>();
            SkillDetailsList = new List<SkillDetail>();
            FocusList = new List<Focus>();
        }
        /// <summary>
        /// Bool for production company
        /// </summary>
        [Required]
        [Display(Name = "Product CompanyList")]
        public bool IsProductComp { get; set; }
        /// <summary>
        /// Bool for consultancy company
        /// </summary>
        [Required]
        [Display(Name = "Consultancy CompanyList")]
        public bool IsConsultancyComp { get; set; }
        /// <summary>
        /// Bool for internal systems company
        /// </summary>
        [Required]
        [Display(Name = "Internal Systems CompanyList")]
        public bool IsInternalSystemsComp { get; set; }



    }
}
