using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CompanyData.Models
{
    public partial class SkillDetail
    {
        public SkillDetail()
        {

        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SkillDetailId { get; set; }
        public string DetailName { get; set; }
      

        public virtual ICollection<Companies> Companies { get; set; }   

        [NotMapped]
        public bool IsSelected { get; set; }
        [NotMapped]
        public bool IncludeInSearch { get; set; }
    }
}
