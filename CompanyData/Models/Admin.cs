using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security;
using System.Text;

namespace CompanyData.Models
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }    
        [StringLength(50)]
        public string Username { get; set; }
    
        public byte[] Password { get; set; }

    }
}
