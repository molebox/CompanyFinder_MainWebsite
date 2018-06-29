using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Competence.Models
{
    /// <summary>
    /// Company focus model
    /// </summary>
    public class CompanyFocus
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Company id
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// Focus id
        /// </summary>
        public int FocusId { get; set; }
        /// <summary>
        /// Company object
        /// </summary>
        public Companies Company { get; set; }
        /// <summary>
        /// Focus Object
        /// </summary>
        public Focus Focus { get; set; }
    }
}
