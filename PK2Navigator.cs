#region Usings

using SlimPK2.IO;
using SlimPK2.Types;
using System;
using System.Collections.Generic;
using System.Linq;

#endregion Usings

namespace SlimPK2
{
    public class PK2Navigator : IDisposable
    {
        #region Properties

        /// <summary>
        /// Gets the current directory.
        /// </summary>
        /// <value>
        /// The current directory.
        /// </value>
        public PK2Directory CurrentDirectory { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is disposing.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is disposing; otherwise, <c>false</c>.
        /// </value>
        public bool IsDisposing { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is disposed; otherwise, <c>false</c>.
        /// </value>
        public bool IsDisposed { get; private set; }

        /// <summary>
        /// Gets the files.
        /// </summary>
        /// <value>
        /// The files.
        /// </value>
        public List<PK2File> Files { get; private set; }

        /// <summary>
        /// Gets the directories.
        /// </summary>
        /// <value>
        /// The directories.
        /// </value>
        public List<PK2Directory> Directories { get; private set; }

        /// <summary>
        /// Gets the blocks.
        /// </summary>
        /// <value>
        /// The blocks.
        /// </value>
        public PK2BlockCollection Blocks { get; private set; }

        #endregion Properties

        #region Constructor / Destructor

        /// <summary>
        /// Initializes a new instance of the <see cref="PK2Navigator"/> class.
        /// </summary>
        public PK2Navigator()
        {
            ReadBlockAt(256);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="PK2Navigator"/> class.
        /// </summary>
        ~PK2Navigator()
        {
            if (!IsDisposed && !IsDisposing)
                Dispose();
        }

        #endregion Constructor / Destructor

        #region Methods

        /// <summary>
        /// Changes the directory.
        /// </summary>
        /// <param name="directory">The directory.</param>
        public void ChangeDirectory(PK2Directory directory)
        {
            if (directory.Parent != null && directory.Path != null)
                ReadBlockAt(directory.Position);
            else
                ReadBlockAt(256);

            CurrentDirectory = directory;
        }

        /// <summary>
        /// Changes the directory.
        /// </summary>
        /// <param name="directory">The directory.</param>
        public void ChangeDirectory(string directory)
        {
            var directoryObject = Directories.FirstOrDefault(dir => dir.Name == directory);

            if (directoryObject == null)
                throw new PK2DirectoryNotFoundException(directory);

            if (directoryObject.Parent != null && directoryObject.Path != null)
                ReadBlockAt(directoryObject.Position);
            else
                ReadBlockAt(256);

            CurrentDirectory = directoryObject;
        }

        /// <summary>
        /// Reloads this instance and re-indexes the current block.
        /// </summary>
        public void Reload()
        {
            ReadBlockAt(Blocks.Blocks[0].Offset);
        }

        /// <summary>
        /// A helper method that will return the file by its name
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public PK2File GetFile(string name)
        {
            return Files.FirstOrDefault(file => file.Name == name);
        }

        /// <summary>
        /// Gets the directory.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public PK2Directory GetDirectory(string name)
        {
            return Directories.FirstOrDefault(directory => directory.Name == name);
        }

        /// <summary>
        /// Gets the entry.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns></returns>
        public PK2Entry GetEntry(string name)
        {
            return Blocks.GetEntries().FirstOrDefault(entry => entry.Name == name);
        }

        /// <summary>
        /// Reads the block at.
        /// This function does not recursively ready any "sub-chunks"
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns></returns>
        private void ReadBlockAt(ulong position)
        {
            Blocks = new PK2BlockCollection();
            Directories = new List<PK2Directory>();
            Files = new List<PK2File>();

            while (true)
            {
                try
                {
                    var currentBlockBuffer = FileAdapter.GetInstance().ReadData((long)position, 2560);
                    var currentBlock = new PK2Block(currentBlockBuffer, position);

                    Blocks.Blocks.Add(currentBlock);

                    foreach (var entry in currentBlock.Entries)
                    {
                        switch (entry.Type)
                        {
                            case PK2EntryType.Directory:
                                Directories.Add(new PK2Directory(entry, ""));
                                break;

                            case PK2EntryType.File:
                                Files.Add(new PK2File(entry, ""));
                                break;
                        }
                    }

                    //read the next block (only if the first block was not enough for the folder)
                    if (currentBlock.Entries[19].NextChain > 0)
                    {
                        position = currentBlock.Entries[19].NextChain;
                        continue;
                    }

                    break;
                }
                catch { throw new InvalidBlockException((long)position); } //should only be thrown, if the user fakes any position data in any entry!
            }
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <exception cref="System.ObjectDisposedException">PK2Navigator</exception>
        public void Dispose()
        {
            if (IsDisposed || IsDisposing)
                throw new ObjectDisposedException("PK2Navigator");

            IsDisposing = true;
            Directories = null;
            Files = null;
            IsDisposing = false;
            IsDisposed = true;
        }

        #endregion Methods
    }
}