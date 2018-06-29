using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Competence.Models
{
    /// <summary>
    /// Skill detail model
    /// </summary>
    public class SkillDetail
    {
        /// <summary>
        /// Detail id
        /// </summary>
        public int SkillDetailId { get; set; }
        /// <summary>
        /// Deatil name
        /// </summary>
        public string DetailName { get; set; }

        /// <summary>
        /// Linked companies
        /// </summary>
        public virtual ICollection<Companies> Companies { get; set; }
    }
}
