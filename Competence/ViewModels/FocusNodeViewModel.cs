using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Competence.ViewModels
{
    /// <summary>
    /// Focus view model for the focus tree view
    /// </summary>
    public class FocusNodeViewModel
    {
        /// <summary>
        /// The name of the focus node
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// The focus tree node id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The nodes parents id, can be null. The root node is null
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// List of the children nodes
        /// </summary>
        public virtual List<FocusNodeViewModel> Nodes { get; set; }
    }
}
