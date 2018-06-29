using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Competence.ViewModels
{
    /// <summary>
    /// Admin view model for the admin login
    /// </summary>
    public class AdminViewModel
    {
        /// <summary>
        /// The admin id
        /// </summary>
        public int AdminID { get; set; }
        /// <summary>
        /// The Admin username
        /// </summary>
        [Required]
        [Display(Name = "Admin Name")]
        public string AdminName { get; set; }
        /// <summary>
        /// The admin password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Admin Password")]
        public string AdminPassword { get; set; }
        
    }
}
