namespace SystemTree
{
    using System;
    using System.IO;

    public class SystemTree
    {
        public static void Main(string[] args)
        {
            string path = @"D:\Telerik";
            Folder mainFolder = new Folder("Telerik");
            TraverseDirs(path, ref mainFolder);

            Folder folder = FindFolder(mainFolder, "CODES");

            long sum = CalculateFilesSum(folder);
            Console.WriteLine(sum);
        }

        private static long CalculateFilesSum(Folder folder)
        {
            long currentSum = 0;
            foreach (var file in folder.Files)
            {
                currentSum += file.Size;
            }

            foreach (var childFolder in folder.ChildFolders)
            {
                long childSum = CalculateFilesSum(childFolder);
                currentSum += childSum;
            }

            return currentSum;
        }

        private static Folder FindFolder(Folder folder, string folderName)
        {
            if (folder.Name == folderName)
            {
                return folder;
            }

            Folder findFolder = null;
            foreach (var child in folder.ChildFolders)
            {
                if (findFolder == null)
                {
                    Folder currentFolder = FindFolder(child, folderName);
                    if (currentFolder != null)
                    {
                        findFolder = currentFolder;
                    }
                }
            }

            return findFolder;
        }

        private static void TraverseDirs(string path, ref Folder folder)
        {
            DirectoryInfo directory = new DirectoryInfo(path);
            string directoryName = directory.Name;
            folder = new Folder(directoryName);

            FileInfo[] currentFiles = directory.GetFiles();
            folder.Files = new File[currentFiles.Length];
            for (int i = 0; i < currentFiles.Length; i++)
            {
                string name = currentFiles[i].Name;
                long length = currentFiles[i].Length;

                folder.Files[i] = new File(name, length);
            }

            DirectoryInfo[] currentDirs = directory.GetDirectories();
            folder.ChildFolders = new Folder[currentDirs.Length];
            for (int i = 0; i < currentDirs.Length; i++)
            {
                string name = currentDirs[i].Name;
                Folder currentFolder = new Folder(name);

                TraverseDirs(currentDirs[i].FullName, ref currentFolder);
                folder.ChildFolders[i] = currentFolder;
            }
        }
    }
}
