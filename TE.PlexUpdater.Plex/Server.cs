using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TE.PlexUpdater.System.Msi;

namespace TE.PlexUpdater.Plex
{
    #region Enumerations
    /// <summary>
    /// The type of installation channel.
    /// </summary>
    public enum ChannelType
    {
        /// <summary>
        /// The public channel.
        /// </summary>
        Public = 0,
        /// <summary>
        /// The PlexPass, or beta, channel.
        /// </summary>
        PlexPass = 8
    }
    #endregion

    /// <summary>
    /// Properties and methods used to manage the local Plex instance.
    /// </summary>
    public class Server
    {
        #region Constants
        /// <summary>
        /// The default folder for the Plex installation
        /// </summary>
        private const string DefaultPlexInstallFolder 
            = "Plex\\Plex Media Server";

        /// <summary>
        /// The name of the Plex Media Server executable.
        /// </summary>
        private const string PlexExecutable = "Plex Media Server.exe";

        /// <summary>
        /// Maxiumum path length.
        /// </summary>
        private const int MaxPathSize = 256;
        #endregion

        #region Properties
        /// <summary>
        /// Gets a list of available packages that can be installed.
        /// </summary>
        public List<Package> AvailablePackages { get; private set; } 
            = new List<Package>();

        /// <summary>
        /// Gets the Plex installation folder.
        /// </summary>
        public string InstallFolder { get; private set; }

        /// <summary>
        /// Gets the flag indicating if Plex is installed.
        /// </summary>
        public bool IsInstalled { get; private set; }
        
        /// <summary>
        /// Gets the full path to the local data folder used by Plex.
        /// </summary>
        public string LocalDataFolder { get; private set; }

        /// <summary>
        /// Gets the user's token associated with the Plex installation.
        /// </summary>
        public string Token { get; private set; }

        /// <summary>
        /// Gets the selected update channel for the Plex server.
        /// </summary>
        public ChannelType UpdateChannel { get; private set; } 
            = ChannelType.Public;

        /// <summary>
        /// Gets the full path to the updates folder.
        /// </summary>
        public string UpdatesFolder { get; private set; }

        /// <summary>
        /// Gets the installed version of Plex.
        /// </summary>
        public Version Version { get; private set; } = default(Version);
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes an instance of the <see cref="Server"/> class.
        /// </summary>
        public Server()
        {

        }
        #endregion

        #region Private Members
        /// <summary>
        /// Get the latest information about the Plex server.
        /// </summary>
        private void Initialize()
        {
            InstallFolder = GetInstallPath();
        }

        /// <summary>
        /// Gets the Plex Media Server's installation path.
        /// </summary>
        /// <returns>
        /// The installation path of Plex Media Server.
        /// </returns>
        /// <exception cref="AppNotInstalledException">
        /// The Plex Media Server is not installed.
        /// </exception>
        private string GetInstallPath()
        {
            // The installation path of Plex
            string installPath;

            try
            {
                // Get the location of the Program Files (x86) folder since
                // that is the default folder where Plex is installed
                string programFilesFolder =
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.ProgramFilesX86);

                // If the Program Files (x86) folder was found, then try to
                // determine if Plex is installed in that folder
                if (!string.IsNullOrEmpty(programFilesFolder))
                {
                    // Combine the Program Files (x86) and the Plex folder
                    // path to create the full path structure
                    installPath = 
                        Path.Combine(
                            programFilesFolder,
                            DefaultPlexInstallFolder);

                    // If the folder exists, then return the path
                    if (Directory.Exists(installPath))
                    {
                        return installPath;
                    }
                }
            }
            catch (Exception ex)
                when (ex is ArgumentException || ex is PlatformNotSupportedException)
            {

            }

            // Find the Plex installation folder by using the Windows Installer
            // API to get the location of where the Plex executable MSI
            // component is installed
            installPath = Api.GetComponentPathByFile(PlexExecutable);

            if (!string.IsNullOrEmpty(installPath))
            {
                // Verify the path length does not exceed the allowable
                // length of the operating system
                if (installPath.Length < MaxPathSize)
                {
                    installPath = Path.GetDirectoryName(installPath);
                }
            }

            return installPath;
        }
        #endregion

        #region Public Members
        /// <summary>
        /// Gets the number of media files currently being played from the
        /// server.
        /// </summary>
        /// <returns>
        /// The number of media files currently being played.
        /// </returns>
        public int GetPlayCount()
        {
            return 0;
        }

        /// <summary>
        /// Updates the Plex server to a specified version.
        /// </summary>
        /// <returns>
        /// True if the updated was successful, false if the update was not
        /// successful.
        /// </returns>
        public bool Update()
        {
            return true;
        }
        #endregion
    }
}
