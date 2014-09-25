namespace SystemTree
{
    public class Folder
    {
        public Folder(string name)
        {
            this.Name = name;
        }

        public Folder(string name, File[] files, Folder[] childFolders)
            : this(name)
        {
            this.Files = files;
            this.ChildFolders = childFolders;
        }

        public string Name { get; set; }

        public File[] Files { get; set; }

        public Folder[] ChildFolders { get; set; }
    }
}
