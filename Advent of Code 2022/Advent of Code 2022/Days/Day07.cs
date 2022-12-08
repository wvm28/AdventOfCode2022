namespace Advent_of_Code_2022.Days
{
    class Day07 : IDay
    {
        private Directory _directory;
        public Day07()
        {
            List<string> input = File.ReadAllLines(@"Days\Input\Day07.txt").ToList();
            Directory currentDirectory = new Directory(new List<Directory>(), new List<elvesFile>(), null, "/");
            _directory = currentDirectory;
            input.ForEach(row =>
            {
                var rowElements = row.Split(' ').ToList();
                switch (rowElements[0])
                {
                    case ("$"):
                        switch (rowElements[1])
                        {
                            case ("cd"):
                                switch (rowElements[2])
                                {
                                    case ("/"):
                                        currentDirectory = _directory;
                                        break;
                                    case (".."):
                                        currentDirectory = currentDirectory.Parent;
                                        break;
                                    case ("ls"):
                                        break;
                                    default:
                                        currentDirectory = currentDirectory.Directories.Where(d => d.Name == rowElements[2]).FirstOrDefault();
                                        break;
                                }
                                break;
                        }

                        break;
                    case ("dir"):
                        currentDirectory.Directories.Add(new Directory(new List<Directory>(), new List<elvesFile>(), currentDirectory, rowElements[1]));
                        break;
                    default:
                        currentDirectory.Files.Add(new elvesFile(rowElements[1], int.Parse(rowElements[0])));
                        break;
                }
            });
        }

        public void partOne()
        {
            Console.WriteLine(_directory.getLowerThanOrEqualToAmount(100000));
        }

        public void partTwo()
        {
            Console.WriteLine(_directory.getDirectoryClosestToButHigherThanSize(30000000 - (70000000 - _directory.getSize()), null).getSize());
        }
    }

    class Directory
    {
        public Directory? Parent;
        public string Name;
        public List<Directory> Directories = new List<Directory>();
        public List<elvesFile> Files = new List<elvesFile>();

        public Directory(List<Directory> directories, List<elvesFile> files, Directory? parent, string name)
        {
            Directories = directories;
            Files = files;
            Parent = parent;
            Name = name;
        }

        public int getSize()
        {
            int size = 0;
            foreach (Directory directory in Directories) size += directory.getSize();
            foreach (elvesFile file in Files) size += file.Size;
            return size;
        }

        public int getLowerThanOrEqualToAmount(int amount)
        {
            int rtn = 0;
            if (getSize() <= amount) rtn += getSize();
            Directories.ForEach(directory =>
            {
                rtn += directory.getLowerThanOrEqualToAmount(amount);
            });
            return rtn;
        }

        public Directory getDirectoryClosestToButHigherThanSize(int size, Directory? currentClosest)
        {
            Directory? rtn = currentClosest;
            if (getSize() > size)
            {
                if (rtn != null)
                {
                    if (getSize() < rtn.getSize())
                    {
                        rtn = this;
                    }
                }
                else rtn = this;
            }
            foreach (Directory directory in Directories)
            {
                rtn = directory.getDirectoryClosestToButHigherThanSize(size, rtn);
            }
            return rtn;
        }

        public void Display(int indention)
        {
            for (int i = 0; i < indention; i++) Console.Write("\t");
            Console.WriteLine(Name + " (dir)");
            foreach (Directory directory in Directories)
            {
                for (int i = 0; i < indention; i++) Console.Write("\t");
                directory.Display(indention + 1);
            }
            foreach (elvesFile file in Files)
            {
                for (int i = 0; i < indention; i++) Console.Write("\t");
                Console.WriteLine("\t" + file.Name + " " + file.Size + " (file)");
            }
        }
    }

    class elvesFile
    {
        public string Name;
        public int Size;

        public elvesFile(string name, int size)
        {
            Name = name;
            Size = size;
        }
    }
}
