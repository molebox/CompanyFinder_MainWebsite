using System;

namespace Competence.Models
{
    /// <summary>
    /// Error view model not currently used but will be implemented in the future
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// The requested id
        /// </summary>
        public string RequestId { get; set; }
        /// <summary>
        /// Checks the id
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}