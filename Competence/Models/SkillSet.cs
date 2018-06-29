using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Competence.Models
{
    /// <summary>
    /// Skill model
    /// </summary>
    public class SkillSet
    {
        /// <summary>
        /// Skill id
        /// </summary>
        public int SkillId { get; set; }
        /// <summary>
        /// Skill id
        /// </summary>
        public string SkillName { get; set; }
        /// <summary>
        /// Linked companies
        /// </summary>
        public virtual ICollection<Companies> Companies { get; set; }
    }
}
