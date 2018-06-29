using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Competence.ViewModels
{
    /// <summary>
    /// View model for the search results
    /// </summary>
    public class SearchResultsViewModel
    {
        /// <summary>
        /// Company Id
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// Compnay Name
        /// </summary>
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        /// <summary>
        /// Contact Person
        /// </summary>
        [Display(Name = "Contact Person")]
        public string ContactPerson { get; set; }
        /// <summary>
        /// Company Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Company biography
        /// </summary>
        [Display(Name = "Biography")]
        public string Bio { get; set; }
        /// <summary>
        /// Company website
        /// </summary>
        public string Website { get; set; }
        /// <summary>
        /// Company Phone
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Company recruitment web address
        /// </summary>
        [Display(Name = "Recruitment Address")]
        public string RecruitmentWebAddress { get; set; }
    }
}
