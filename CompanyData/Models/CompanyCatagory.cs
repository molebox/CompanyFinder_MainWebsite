using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CompanyData.Models
{
    public partial class CompanyCatagory
    {
        [Key]
        public int CompCatId { get; set; }
        public int CompanyId { get; set; }
        public int JobCatId { get; set; }

        public Companies Company { get; set; }
        public JobCatagory JobCat { get; set; }
    }
}
