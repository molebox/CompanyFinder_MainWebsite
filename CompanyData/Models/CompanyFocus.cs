using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyData.Models
{
   public class CompanyFocus
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int FocusId { get; set; }

        public Companies Company { get; set; }
        public Focus Focus { get; set; }    
    }
}
