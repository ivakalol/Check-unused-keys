
public class Print
{
    public void PrintFinal(List<string> unusedKeys)
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("==================================");
        Console.WriteLine($"The program found _{unusedKeys.Count}_ unused key words.");
        Console.WriteLine("The key words are: ");
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
        Console.Write("Please enter path to the FOLDER containing everything: ");
    }
    public void PrintPathKeys()
    {
        Console.WriteLine();
        Console.WriteLine("-----------------------------------------");
        Console.Write("Please enter path to the file containing only the keywords: ");
    }

    internal void Error()
    {
        Console.WriteLine();
        Console.WriteLine("========================================");
        Console.WriteLine("WRONG PATHS! PLEASE ENTER THEM CORRECTLY, without \"\"");
        Console.WriteLine("========================================");
        Console.WriteLine();
    }
}
