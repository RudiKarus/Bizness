namespace Bizness;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.Intrinsics.Arm;

class Program
{
    static void Main(string[] args)
    {
        //string[] wordlist = File.ReadAllLines("/home/b0b24ce0/Downloads/rockyou.txt");
        // foreach (string word in wordlist)
        // {
        //     var shaHash = SHA1.HashData(Encoding.UTF8.GetBytes(word.ToCharArray()));
        //     var encodedHash = Encoding.UTF8.GetString(shaHash);
        //     string result = Convert.ToHexString(shaHash).ToLower();
        //     Console.WriteLine($"{result}");
        // }
        string hashToCompare = "uP0_QaVBpDWFeo8-dRzDqRwXQ2I";
        var hashToCompareAsBase64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(hashToCompare));

        string saltString = "d";
        byte[] salt = Encoding.UTF8.GetBytes(saltString);
        string passwordString = "monkeybizness";
        byte[] password = Encoding.UTF8.GetBytes(passwordString);

        var saltedPassword = passwordString.Concat(saltString).ToArray();
        byte[] saltedPasswordHash = SHA1.HashData(Encoding.UTF8.GetBytes(saltedPassword));

        string saltedPasswordHashToCompareAsBase64 = Convert.ToBase64String(saltedPasswordHash);
        string result = String.Concat("$SHA", $"${saltString}", $"${saltedPasswordHashToCompareAsBase64}");

        Console.WriteLine($"Result: {result}");

        //     var encodedHash = Encoding.UTF8.GetString(shaHash);
        //     string result = Convert.ToHexString(shaHash).ToLower();
        //     Console.WriteLine($"{result}");

    }
}
