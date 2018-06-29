using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Competence.Models
{
    /// <summary>
    /// Company details model
    /// </summary>
    public class CompanyDetails
    {
        /// <summary>
        /// Id
        /// </summary>
        public int CompanyDetailsId { get; set; }
        /// <summary>
        /// Company id
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// Detail id
        /// </summary>
        public int SkillDetailId { get; set; }
        /// <summary>
        /// Company object
        /// </summary>
        public virtual Companies Company { get; set; }
        /// <summary>
        /// Detail object
        /// </summary>
        public virtual SkillDetail SkillDetail { get; set; }
    }
}
