namespace Bizness;
using System.IO;
using System.Text;
using System.Security.Cryptography;

class Program
{
    static void Main(string[] args)
    {
        // Set properties, based on findings from the targetmachine:  
        string salt = "d";
        string hashToCompare = "uP0_QaVBpDWFeo8-dRzDqRwXQ2I";

        // Since SHA is based on a non-linear function, there is no decryption.
        // For this reason we need to "HashAndCompare" the entries from our wordlist...
        List<string> wordlist = new List<string>(File.ReadAllLines($"{System.Environment.CurrentDirectory}/rockyou.txt"));
        foreach (string passwordToCompare in wordlist)
        {
            string saltAndPassword = string.Concat(salt, passwordToCompare);
            byte[] hashFromSaltAndPassword = SHA1.HashData(Encoding.UTF8.GetBytes(saltAndPassword));
            string hashAsBase64 = Convert.ToBase64String(hashFromSaltAndPassword);

            // ... and bring it into the expected, comparable format :
            string result = hashAsBase64.Replace("/", "_").Replace("+", "-").Replace("=", "");

            if (result == hashToCompare)
            {
                Console.WriteLine($"Password found: {passwordToCompare}");
                break;
            }
        }
        Console.WriteLine("Done.");
    }
}
