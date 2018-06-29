using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CompanyData.Models
{
    public partial class ConstructionJunction
    {
        [Key]
        public int ConstrucJuncid { get; set; }
        public int ConStructId { get; set; }
        public int CompanyId { get; set; }

        public Companies Company { get; set; }
        public ConstructionSkills ConStruct { get; set; }
    }
}
