using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace CompanyData.Models
{
    public partial class SkillSet
    {
        public SkillSet()
        {

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SkillId { get; set; }
        public string SkillName { get; set; }

        public virtual ICollection<Companies> Companies { get; set; }

        [NotMapped]
        public bool IsSelected { get; set; }
        [NotMapped]
        public bool IncludeInSearch { get; set; }
    }
}
