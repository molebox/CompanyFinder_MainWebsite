using Competence.Models;
using System.Collections.Generic;

namespace Competence.ViewModels
{
    /// <summary>
    /// View Model to hold the Ajax request from the client
    /// </summary>
    public class SearchSelectionsViewModel
    {
      
        /// <summary>
        /// Unique node array with selected roles checkboxes
        /// </summary>
        public List<TreeNodes> UniqueNodeArray { get; set; }
        /// <summary>
        /// Unique node array with selected focus checkboxes
        /// </summary>
        public List<FocusNodes> UniqueFocusNodeArray { get; set; }

    }

    
}
