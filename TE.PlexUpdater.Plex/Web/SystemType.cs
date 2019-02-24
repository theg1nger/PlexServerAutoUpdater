using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TE.PlexUpdater.Plex.Web
{
    /// <summary>
    /// The Plex Media Server for a specific type of system.
    /// </summary>
    public class SystemType
    {
        /// <summary>
        /// Gets or sets the computer Plex Media Server releases.
        /// </summary>
        [JsonProperty("computer")]
        public Dictionary<string, SystemType> Computer { get; internal set; }

        /// <summary>
        /// Gets or sets the NAS Plex Server releases.
        /// </summary>
        [JsonProperty("nas")]
        public Dictionary<string, SystemType> Nas { get; internal set; }
    }
}
