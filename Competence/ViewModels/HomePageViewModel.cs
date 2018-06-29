using Competence.Browsers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Competence.ViewModels
{
    /// <summary>
    /// ViewModel to pass homepage data from db to view
    /// </summary>
    public class HomePageViewModel
    {
        /// <summary>
        /// Tagline for the home page
        /// </summary>
        public string Tagline { get; set; }

        /// <summary>
        /// Username to access the search
        /// </summary>
        [Required]
        [Display(Name = "Username")]
        public string SearchUsername { get; set; }
        /// <summary>
        /// Password to access the search
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string SearchPassword { get; set; }

        /// <summary>
        /// The return url
        /// </summary>
        public string ReturnUrl { get; set; } = "/";
        /// <summary>
        /// User Agent object
        /// </summary>
        public UserAgent UserAgent { get; set; }

        /// <summary>
        /// User
        /// </summary>
        public IdentityUser User { get; set; }
    }
}
