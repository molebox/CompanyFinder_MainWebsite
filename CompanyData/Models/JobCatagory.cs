using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CompanyData.Models
{
    public partial class JobCatagory
    {
        public JobCatagory()
        {
            CompanyCatagory = new HashSet<CompanyCatagory>();
        }

        [Key]
        public int JobCatId { get; set; }
        public string JobName { get; set; }

        public ICollection<CompanyCatagory> CompanyCatagory { get; set; }
    }
}
