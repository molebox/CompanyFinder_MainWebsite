using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Competence.ViewModels
{
    /// <summary>
    /// View model for the treeview
    /// </summary>
    public class TreeNodesViewModel
    {
        /// <summary>
        /// The name of the node
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// The tree node id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The nodes parents id, can be null. The root node is null
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// List of the children nodes
        /// </summary>
        public virtual List<TreeNodesViewModel> Nodes { get; set; }
    }
}
