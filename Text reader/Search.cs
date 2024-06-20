public class Search
{
    internal List<string> CheckAllFiles(string path, string keysPath)
    {
        string[] files = Directory.GetFiles(path, "*.txt");         // тук сложи path към базата данни
        var keys = File.ReadAllLines(keysPath).ToList();                    // тук сложи path към ключовете

        List<string> unused = new List<string>(keys);
        List<string> used = new List<string>();

        var search = new Search();
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
}
