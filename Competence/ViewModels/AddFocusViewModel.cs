using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Competence.ViewModels
{
    /// <summary>
    /// View model to represent the focus model
    /// </summary>
    public class AddFocusViewModel
    {
        /// <summary>
        /// Focus Id
        /// </summary>
        public int FocusId { get; set; }
        /// <summary>
        /// Focus Name
        /// </summary>
        public string FocusType { get; set; }   
    }
}
