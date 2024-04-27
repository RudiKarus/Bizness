namespace Bizness;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        var wordlist = File.ReadAllLines("/usr/share/wordlists/rockyou.txt.gz");
        foreach (var word in wordlist)
        {
            Console.WriteLine(word);
        }
        Console.WriteLine("Hello, World!");
    }
}
