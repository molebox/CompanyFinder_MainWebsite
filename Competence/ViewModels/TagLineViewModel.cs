using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Competence.ViewModels
{
    /// <summary>
    /// View model to represent the homepage tagline
    /// </summary>
    public class TagLineViewModel
    {
        /// <summary>
        /// Tagline Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Tagline for the home page
        /// </summary>
        public string Tagline { get; set; }
    }
}
