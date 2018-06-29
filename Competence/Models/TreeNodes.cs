using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Competence.Models
{
    /// <summary>
    /// The treeview nodes
    /// </summary>
    public class TreeNodes
    {
       /// <summary>
       /// The node id
       /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The node name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The nodes parent id, can be null
        /// </summary>
        public int? ParentId { get; set; }
        /// <summary>
        /// The nodes order number in the db
        /// </summary>
        public int OrderNumber { get; set; }

        /// <summary>
        /// The nodes parent
        /// </summary>
        public virtual TreeNodes Parent { get; set; }
        /// <summary>
        /// The nodes children
        /// </summary>
        public virtual List<TreeNodes> Children { get; set; }
    }
}
