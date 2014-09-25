namespace TraverseWindowsDirectory
{
    public class TraverseWindowsDirectory
    {
        public static void Main()
        {
            string path = @"C:\Windows";
            DirectoryTraverserDFS.TraverseDirectory(path);
        }
    }
}
