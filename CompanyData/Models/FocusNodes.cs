using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CompanyData.Models
{
   public class FocusNodes
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public int OrderNumber { get; set; }
        public virtual FocusNodes Parent { get; set; }

        public virtual List<FocusNodes> Children { get; set; }
    }
}
