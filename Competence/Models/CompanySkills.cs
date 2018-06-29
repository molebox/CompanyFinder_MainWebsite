using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Competence.Models
{
    /// <summary>
    /// Company skills model
    /// </summary>
    public class CompanySkills
    {
        /// <summary>
        /// Id
        /// </summary>
        public int CompSkillId { get; set; }
        /// <summary>
        /// Company id
        /// </summary>
        public int CompanyId { get; set; }
        /// <summary>
        /// Skill id
        /// </summary>
        public int SkillId { get; set; }

        /// <summary>
        /// Company object
        /// </summary>
        public Companies Company { get; set; }
        /// <summary>
        /// Skill object
        /// </summary>
        public SkillSet SkillSet { get; set; }
    }
}
