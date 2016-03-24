namespace SlimPK2.Types
{
    public class PK2Directory : PK2Entry
    {
        #region Properties

        /// <summary>
        /// Gets or sets the parent.
        /// </summary>
        /// <value>
        /// The parent.
        /// </value>
        public string Parent { get; set; }

        /// <summary>
        /// Gets or sets the path.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        public string Path => Name == null ? null : Parent + "/" + Name;

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PK2Directory"/> class.
        /// </summary>
        public PK2Directory() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PK2Directory"/> class.
        /// </summary>
        /// <param name="entry">The entry.</param>
        /// <param name="parent">The parent.</param>
        public PK2Directory(PK2Entry entry, string parent)
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

            Type = PK2EntryType.Directory;
        }

        #endregion Constructor
    }
}