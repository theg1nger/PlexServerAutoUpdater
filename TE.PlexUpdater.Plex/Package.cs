using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TE.PlexUpdater.Plex
{
    /// <summary>
    /// Information about an installation package for Plex.
    /// </summary>
    public class Package
    {
        #region Properties
        /// <summary>
        /// Gets the full path to the installation package.
        /// </summary>
        public string FullPath { get; private set; }

        /// <summary>
        /// Gets the checksum of the installation package.
        /// </summary>
        public string CheckSum { get; private set; }

        /// <summary>
        /// Gets the version of the installation package.
        /// </summary>
        public Version Version { get; private set; } 
            = default(Version);
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes an instance of the <see cref="Package"/> class when
        /// provided with the full path to the installation package.
        /// </summary>
        /// <param name="fullPath">
        /// The full path to the installation package.
        /// </param>
        public Package(string fullPath)
        {
            FullPath = fullPath ?? throw new ArgumentNullException(nameof(fullPath));
            CheckSum = GetCheckSum();
            Version = GetVersion();
        }
        #endregion

        #region Private Members
        /// <summary>
        /// Generates and returns the SHA1 hash for the installation package.
        /// </summary>
        /// <returns>
        /// The hash of the installation package.
        /// </returns>
        private string GetCheckSum()
        {
            if (string.IsNullOrEmpty(FullPath))
            {
                return null;
            }

            if (!File.Exists(FullPath))
            {
                return null;
            }

            using (SHA1 sha = SHA1.Create())
            {
                try
                {
                    using (var stream = File.OpenRead(FullPath))
                    {
                        byte[] hash = sha.ComputeHash(stream);

                        if (hash == null || hash.Length == 0)
                        {
                            return null;
                        }

                        return BitConverter.ToString(hash).Replace("-", "").ToLower();
                    }
                }
                catch
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Parses the verison number from the installation file name and then
        /// returns a <see cref="Version"/> object containing the details of
        /// the file version.
        /// </summary>
        /// <returns>
        /// A <see cref="Version"/> object that represents the version of
        /// the installation file.
        /// </returns>
        private Version GetVersion()
        {
            if (string.IsNullOrEmpty(FullPath) || !File.Exists(FullPath))
            {
                return default(Version);
            }

            // Get the name of the installation file
            string fileName = Path.GetFileName(FullPath);

            // The regular expression used to parse the version from the file
            // name
            string pattern = 
                @"^\S+(?<Major>\d+)\.(?<Minor>\d+)\.(?<Build>\d+)\.(?<Revision>\d+)\S+$";

            try
            {
                // Try to find a match for the pattern in the file name
                Match match =
                    Regex.Match(fileName, pattern);

                // Ensure the match was successful
                if (match.Success)
                {
                    // Return the version object
                    return new Version(
                        Convert.ToInt32(match.Groups["Major"].Value),
                        Convert.ToInt32(match.Groups["Minor"].Value),
                        Convert.ToInt32(match.Groups["Build"].Value),
                        Convert.ToInt32(match.Groups["Revision"].Value));

                }
                else
                {
                    return default(Version);
                }
            }
            catch (Exception ex)
                when (ex is ArgumentOutOfRangeException || ex is RegexMatchTimeoutException)
            {
                return default(Version);
            }
        }
        #endregion

        #region Public Members
        /// <summary>
        /// Installs the installation package.
        /// </summary>
        /// <returns>
        /// True if the installation was succcessful, flase if the installation
        /// was not successful.
        /// </returns>
        public bool Install()
        {
            return true;
        }
        #endregion
    }
}
