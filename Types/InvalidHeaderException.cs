#region Usings

using System;

#endregion Usings

namespace SlimPK2.Types
{
    public class InvalidHeaderException : Exception
    {
        #region Properties

        /// <summary>
        /// Ruft eine Meldung ab, die die aktuelle Ausnahme beschreibt.
        /// </summary>
        public override string Message => "The requested file has an invalid PK2 header. Either the file is damaged or not a Joymax PK2 archive.";

        #endregion Properties
    }
}