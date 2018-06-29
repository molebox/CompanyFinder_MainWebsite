using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Competence.Browsers
{
    /// <summary>
    /// Class to match the expressions
    /// </summary>
    public class MatchExpression
    {
        /// <summary>
        /// List of regeses
        /// </summary>
        public List<Regex> Regexes { get; set; }
        /// <summary>
        /// Action method
        /// </summary>
        public Action<System.Text.RegularExpressions.Match, object> Action { get; set; }
    }
}
