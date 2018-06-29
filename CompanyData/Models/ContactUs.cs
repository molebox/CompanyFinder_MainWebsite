using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CompanyData.Models
{
   public class ContactUs
    {
        [Key]
        public int Id { get; set; }
        public string TagLine { get; set; }
        public string ContactAddress { get; set; }
        public string ContactEmail { get; set; }
    }
}
