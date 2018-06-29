using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CompanyData.Models
{
    public partial class ConstructionSkills
    {
        public ConstructionSkills()
        {
            ConstructionJunction = new HashSet<ConstructionJunction>();
        }

        [Key]
        public int ConStrucSkillId { get; set; }
        public string ConstrucName { get; set; }

        public ICollection<ConstructionJunction> ConstructionJunction { get; set; }
    }
}
