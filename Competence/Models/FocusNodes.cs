using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Competence.Models
{
    /// <summary>
    /// FocusNdoes model
    /// </summary>
    public class FocusNodes
    {
        /// <summary>
        /// Node id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Node name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Parent id, can be null
        /// </summary>
        public int? ParentId { get; set; }
        /// <summary>
        /// Order number
        /// </summary>
        public int OrderNumber { get; set; }
        /// <summary>
        /// Node parent
        /// </summary>
        public virtual FocusNodes Parent { get; set; }
        /// <summary>
        /// Nodes children
        /// </summary>
        public virtual List<FocusNodes> Children { get; set; }
    }
}
