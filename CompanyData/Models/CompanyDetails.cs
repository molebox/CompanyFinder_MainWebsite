using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CompanyData.Models
{
   public class CompanyDetails
    {
        [Key]
        public int CompanyDetailsId { get; set; }

        public int CompanyId { get; set; }
        public int SkillDetailId { get; set; }

        public virtual Companies Company { get; set; }
        public virtual SkillDetail SkillDetail { get; set; }

        [NotMapped]
        public bool IsSelected { get; set; }
    }
}
