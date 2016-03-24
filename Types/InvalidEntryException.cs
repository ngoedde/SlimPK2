#region Usings

using System;

#endregion Usings

namespace SlimPK2.Types
{
    public class InvalidEntryException : Exception
    {
        #region Properties

        /// <summary>
        /// Gets a message that describes the exception
        /// </summary>
        public override string Message => "An exception was thrown while reading the next PK2 entry. A common reason is a corrupted/damaged PK2 archive";

        /// <summary>
        /// Gets the buffer that was used to decode the PK2 entry.
        /// </summary>
        /// <value>
        /// The buffer.
        /// </value>
        public byte[] Buffer { get; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidEntryException"/> class.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        public InvalidEntryException(byte[] buffer)
        {
            Buffer = buffer;
        }

        #endregion Constructor
    }
}