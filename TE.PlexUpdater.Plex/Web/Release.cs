using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TE.PlexUpdater.Plex.Web
{
    /// <summary>
    /// A release of the Plex Media Server.
    /// </summary>
    public class Release
    {
        /// <summary>
        /// The label associated with the release.
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; internal set; }

        /// <summary>
        /// The name of the release.
        /// </summary>
        [JsonProperty("build")]
        public string Build { get; internal set; }

        /// <summary>
        /// The distribution of the release.
        /// </summary>
        [JsonProperty("distro")]
        public string Distro { get; internal set; }

        /// <summary>
        /// The download URL for the build.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; internal set; }

        /// <summary>
        /// The checksum of the build.
        /// </summary>
        [JsonProperty("checksum")]
        public string CheckSum { get; internal set; }
    }
}
