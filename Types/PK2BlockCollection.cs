#region Usingsw

using System.Collections.Generic;
using System.Linq;

#endregion Usingsw

namespace SlimPK2.Types
{
    public class PK2BlockCollection
    {
        #region Properties

        /// <summary>
        /// Gets or sets the blocks.
        /// </summary>
        /// <value>
        /// The blocks.
        /// </value>
        public List<PK2Block> Blocks { get; set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PK2BlockCollection"/> class.
        /// </summary>
        public PK2BlockCollection()
        {
            Blocks = new List<PK2Block>();
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Gets the entries.
        /// </summary>
        /// <returns></returns>
        public PK2Entry[] GetEntries()
        {
            return Blocks.SelectMany(block => block.Entries).ToArray();
        }

        #endregion Methods
    }
}