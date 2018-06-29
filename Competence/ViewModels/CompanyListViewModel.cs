using Competence.Models;
using System.Collections.Generic;


namespace Competence.ViewModels
{
    /// <summary>
    /// View model to return a list of companies for the search match
    /// </summary>
    public class CompanyListViewModel
    {
        /// <summary>
        /// IEnummerable of companies
        /// </summary>
        public IEnumerable<Companies> Companies { get; set; }
        /// <summary>
        /// Paging info view model object
        /// </summary>
        public PagingInfoViewModel PagingInfo { get; set; }
        /// <summary>
        /// List of the searched skills
        /// </summary>
        public List<SkillSet> SelectedSkillsFromSearch { get; set; }
        /// <summary>
        /// List of the search details
        /// </summary>
        public List<SkillDetail> SelectedDetailsFromSearch { get; set; }
        /// <summary>
        /// Bool to check if the company is a production company
        /// </summary>
        public bool ProductComp { get; set; }
        /// <summary>
        /// Bool to check if the company is a consultancy company
        /// </summary>
        public bool ConsultComp { get; set; }
        /// <summary>
        /// Bool to check if the company is a internal systems company
        /// </summary>
        public bool InternalComp { get; set; }
    }
}
