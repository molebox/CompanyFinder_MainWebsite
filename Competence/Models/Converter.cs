using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Competence.Models
{
    /// <summary>
    /// Handles the Json Serializer settings
    /// </summary>
    public class Converter
    {
        /// <summary>
        /// Statis method to set the Json Serializer settings
        /// </summary>
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}
