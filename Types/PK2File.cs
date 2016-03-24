namespace SlimPK2.Types
{
    public class PK2File : PK2Entry
    {
        #region Properties

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        public string Path => Name != "" ? Parent + "/" + Name : "";

        /// <summary>
        /// Gets the directory.
        /// </summary>
        /// <value>
        /// The directory.
        /// </value>
        public string Parent { get; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PK2File"/> class.
        /// </summary>
        public PK2File() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PK2File" /> class.
        /// </summary>
        /// <param name="entry">The entry.</param>
        /// <param name="parent">The parent.</param>
        public PK2File(PK2Entry entry, string parent)
        {
            Parent = parent;

            Index = entry.Index;
            Block = entry.Block;
            AccessTime = entry.AccessTime;
            CreateTime = entry.CreateTime;
            ModifyTime = entry.ModifyTime;
            Name = entry.Name;
            NextChain = entry.NextChain;
            Position = entry.Position;
            Size = entry.Size;

            Type = PK2EntryType.File;
        }

        #endregion Constructor
    }
}