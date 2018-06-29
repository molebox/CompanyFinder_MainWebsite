using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Competence.ViewModels
{
    /// <summary>
    /// Page info view model used to show/set items on a page
    /// </summary>
    public class PagingInfoViewModel
    {
        /// <summary>
        /// The total items on a page
        /// </summary>
        public int TotalItems { get; set; }
        /// <summary>
        /// Sets how many items are allowed on a page
        /// </summary>
        public int ItemsPerPage { get; set; }
        /// <summary>
        /// The current page number
        /// </summary>
        public int CurrentPage { get; set; }
        /// <summary>
        /// Method to set how many pages there should be given how many items there are in total
        /// </summary>
        public int TotalPages => (int) Math.Ceiling((decimal) TotalItems / ItemsPerPage);
    }
}
