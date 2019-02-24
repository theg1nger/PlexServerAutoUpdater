using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TE.PlexUpdater.Plex.Web
{
    /// <summary>
    /// Information about the release for a specified operating system type.
    /// </summary>
    public class OperatingSystem
    {
        /// <summary>
        /// The ID of the system type.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; internal set; }

        /// <summary>
        /// The name of the system type.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; internal set; }

        /// <summary>
        /// The release date of the Plex Media Server.
        /// </summary>
        [JsonProperty("release_date")]
        public string ReleaseDate { get; internal set; }

        /// <summary>
        /// The version number of the Plex Media Server.
        /// </summary>
        [JsonProperty("version")]
        public string Version { get; internal set; }

        /// <summary>
        /// The URL to the requirements of the Plex Media Server.
        /// </summary>
        [JsonProperty("requirements")]
        public string Requirements { get; internal set; }

        /// <summary>
        /// Any additional information associated with this verison of the Plex
        /// Media Server.
        /// </summary>
        [JsonProperty("extra_info")]
        public string ExtraInfo { get; internal set; }

        /// <summary>
        /// A list of items added to this version of the Plex Media Server.
        /// </summary>
        [JsonProperty("items_added")]
        public string ItemsAdded { get; internal set; }

        /// <summary>
        /// A list of items that were fixed with this version of the Plex Media
        /// Server.
        /// </summary>
        [JsonProperty("items_fixed")]
        public string ItemsFixed { get; internal set; }

        /// <summary>
        /// A <see cref="List{T}"/> object of <see cref="Release"/> objects for
        /// each release of the Plex Media Server for this system type.
        /// </summary>
        [JsonProperty("releases")]
        public List<Release> Releases { get; internal set; } = new List<Release>();
    }
}
