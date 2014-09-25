namespace TraverseWindowsDirectory
{
    using System;
    using System.IO;

    public static class DirectoryTraverserDFS
    {
        public static void TraverseDirectory(string path)
        {
            TraverseDirectory(new DirectoryInfo(path), string.Empty);
        }

        private static void TraverseDirectory(DirectoryInfo dir, string spaces)
        {
            try
            {
                FileInfo[] files = dir.GetFiles();
                foreach (var file in files)
                {
                    if (file.FullName.EndsWith(".exe"))
                    {
                        Console.WriteLine(spaces + file.FullName);
                    }
                }

                DirectoryInfo[] subDirectories = dir.GetDirectories();

                foreach (var directory in subDirectories)
                {
                    TraverseDirectory(directory, spaces + " ");
                }
            }
            catch (Exception) 
            {
                Console.WriteLine(spaces + "ACCESS DENIED!");
            }
        }
    }
}
