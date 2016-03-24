#region Usings

using System;

#endregion Usings

namespace SlimPK2
{
    public class PK2FileNotFoundException : Exception
    {
        #region Properties

        /// <summary>
        /// Ruft eine Meldung ab, die die aktuelle Ausnahme beschreibt.
        /// </summary>
        public override string Message => "The requested file does not exist in the current context.";

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PK2DirectoryNotFoundException"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public PK2FileNotFoundException(string name)
        {
            Name = name;
        }

        #endregion Constructor
    }
}