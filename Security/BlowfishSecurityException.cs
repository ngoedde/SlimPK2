#region Usings

using System;

#endregion Usings

namespace SlimPK2.Security
{
    public class BlowfishSecurityException : Exception
    {
        #region Properties

        /// <summary>
        /// Gets a message that describes the exception.
        /// </summary>
        public override string Message => "An exception was thrown while initializing the blowfish on this archive. The most common reason is that a wrong key has been provided.";

        /// <summary>
        /// Gets the key that was used as the passphrase in the current PK2 archive
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public string Key { get; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BlowfishSecurityException"/> class.
        /// </summary>
        /// <param name="key"></param>
        public BlowfishSecurityException(string key)
        {
            Key = key;
        }

        #endregion Constructor
    }
}