using File = System.IO.File;

namespace Text_reader

{
    internal class Program
    {
        static void Main(string[] args)
        {
            var search = new Search();
            var print = new Print();

            print.PrintPathKeys();
            string keysPath = Console.ReadLine() ?? "";

            print.PrintPath();
            string path = Console.ReadLine() ?? "";
            

            while (!Directory.Exists(path) || !File.Exists(keysPath))
            {
                print.Error();
                print.PrintPathKeys();
                keysPath = Console.ReadLine() ?? "";
                print.PrintPath();
                path = Console.ReadLine() ?? "";               
            }

            List<string> unused = search.CheckAllFiles(path, keysPath);            
            print.PrintFinal(unused);
        }
    }
}