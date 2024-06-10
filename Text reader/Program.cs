using File = System.IO.File;

namespace Text_reader

{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Settings.Path;
            string keysPath = Settings.KeyPath;

            if (!Directory.Exists(path) || !File.Exists(keysPath))
            {
                Console.Write("Type the path of the data base with all the files: ");
                path = Console.ReadLine() ?? "";
                Console.WriteLine();

                Console.Write("Type the path of the file containing keys: ");
                keysPath = Console.ReadLine() ?? "";
                Console.WriteLine();
            }

            var search = new Search();
            List<string> unused = search.CheckAllFiles(path, keysPath);
            
            search.PrintFinal(unused);
        }
    }
}