public class Program
{
    internal List<string> CheckAllFiles(string path, string keysPath)
    {
        string[] files = Directory.GetFiles(path, "*.txt");         // тук сложи path към базата данни
        var keys = File.ReadAllLines(keysPath).ToList();                    // тук сложи path към ключовете

        List<string> unused = new List<string>(keys);
        List<string> used = new List<string>();

        var search = new Program();
        foreach (var file in files)
        {
            var tmpUsed = search.Ckeck(file, keys);
            used.AddRange(tmpUsed);
            if (tmpUsed.Count > 0)
            {
                unused.RemoveAll(key => used.Contains(key));
            }
        }
        return unused;
    }

    internal List<string> Ckeck(string file, List<string> keys)
    {
        List<string> results = [];

        foreach (var key in keys)
        {
            string line;
            StreamReader reader = null!;

            try
            {
                reader = new StreamReader(file);
                line = reader.ReadLine()!;

                while (line != null)
                {
                    if (line.Contains(key!))
                    {
                        results.Add(key);
                    }
                    line = reader.ReadLine()!;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine(e.Message);
                Console.WriteLine();
            }
            finally
            {
                reader.Close();
            }
        }
        return results;    
    }
    

    public void PrintFinal(List<string> unusedKeys)
    {
        Console.WriteLine($"Unused keys: {unusedKeys.Count}");
        Console.WriteLine("Keys:");
        Console.WriteLine();
        foreach (string key in unusedKeys)
        {
            Console.WriteLine(key);
        }
    }

    public void PrintPath()
    {
        Console.WriteLine();
        Console.WriteLine("-----------------------------------------");
        Console.Write("Please enter path to the file containing everything: ");
    }
    public void PrintPathKeys()
    {
        Console.WriteLine();
        Console.WriteLine("-----------------------------------------");
        Console.Write("Please enter path to the file containing only the keywords: ");
    }
}
