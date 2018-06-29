using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Competence.ViewModels
{
    /// <summary>
    /// View model to represent the details model
    /// </summary>
    public class AddSkillDetailsViewModel
    {
        /// <summary>
        /// The detail id
        /// </summary>
        public int SkillDetailId { get; set; }
        /// <summary>
        /// The detail name
        /// </summary>
        public string DetailName { get; set; }
        /// <summary>
        /// Bool to check if the db successfully added the new detail to the db. Not currently in use
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// Constructor to set the success bool to false as default
        /// </summary>
        public AddSkillDetailsViewModel()
        {
            Success = false;
        }
    }
}
