using File = System.IO.File;

namespace Text_reader

{
    internal class Program
    {
        static void Main(string[] args)
        {
            var search = new global::Program();

            search.PrintPathKeys();
            string keysPath = Console.ReadLine() ?? "";

            search.PrintPath();
            string path = Console.ReadLine() ?? "";
            

            while (!Directory.Exists(path) || !File.Exists(keysPath))
            {
                Console.WriteLine();
                Console.WriteLine("========================================");
                Console.WriteLine("ERROR PATHS! PLEASE ENTER THEM CORRECTLY");
                Console.WriteLine("========================================");
                Console.WriteLine();

                search.PrintPathKeys();
                keysPath = Console.ReadLine() ?? "";
                search.PrintPath();
                path = Console.ReadLine() ?? "";               
            }

            List<string> unused = search.CheckAllFiles(path, keysPath);            
            search.PrintFinal(unused);
        }
    }
}