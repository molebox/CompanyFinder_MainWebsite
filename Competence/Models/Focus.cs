using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Competence.Models
{
    /// <summary>
    /// Focus model
    /// </summary>
    public class Focus
    {
        /// <summary>
        /// Focus id
        /// </summary>
        public int FocusId { get; set; }
        /// <summary>
        /// Focus name
        /// </summary>
        public string FocusType { get; set; }
        /// <summary>
        /// Linked companies
        /// </summary>
        public virtual ICollection<Companies> Companies { get; set; }
    }
}
