using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CompanyData.Models
{
   public class Focus
    {
        public Focus()
        {

        }
        public int FocusId { get; set; }

        public string FocusType { get; set; }

        public virtual ICollection<Companies> Companies { get; set; }

        [NotMapped]
        public bool IsSelected { get; set; }
    }
}
