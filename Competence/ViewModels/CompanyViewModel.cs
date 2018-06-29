using System.Collections.Generic;
using Competence.Models;

namespace Competence.ViewModels
{
    /// <summary>
    /// View model to show the matched companies
    /// </summary>
    public class CompanyViewModel
    {
        /// <summary>
        /// Company object to represent the matched company
        /// </summary>
        public Companies CompanyToShow { get; set; }

        /// <summary>
        /// List of the matched companies
        /// </summary>
        public List<Companies> MatchedCompanies { get; set; }

        /// <summary>
        /// View model constructor that initializes the lists
        /// </summary>
        public CompanyViewModel()
        {
            MatchedCompanies = new List<Companies>();
            CompanyToShow = new Companies();
        }
    }
}
