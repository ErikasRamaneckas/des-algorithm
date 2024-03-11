using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace InformacijosSaugumas2
{
    public class EncryptionHelper
    {
        public static byte[] InputKeyValue(DES des)
        {
            while (true)
            {
                Console.WriteLine("Įveskite raktą (8 simbolių): ");
                string keyInput = Console.ReadLine();
                if (des.ValidKeySize(keyInput.Length * 8))
                {
                    return Encoding.UTF8.GetBytes(keyInput);
                }
                Console.WriteLine("Raktas privalo būti 8 simbolių ilgio.");
            }
        }

        public static byte[] InputPlainTextValue(DES des)
        {
            Console.WriteLine("Įveskite tekstą: ");
            string originalText = Console.ReadLine();
            byte[] inputBytes = Encoding.UTF8.GetBytes(originalText);
            return inputBytes;
        }

        public static string InputFileName()
        {
            Console.WriteLine("Įveskite failo pavadinimą:");
            string fileName = Console.ReadLine() + ".txt";
            return fileName;
        }

        public static void PromptSaveToFile(string encryptedText)
        {
            while (true)
            {
                Console.WriteLine("Ar norite išsaugoti užšifruotą tekstą į failą (Y/N)?:");
                string userChoice = Console.ReadLine().ToUpper();
                if (userChoice == "N")
                {
                    return;
                }
                else if (userChoice == "Y")
                {
                    Console.WriteLine("Įveskite failo pavadinimą:");
                    string fileName = Console.ReadLine();
                    string filePath = Path.Combine(Environment.CurrentDirectory, fileName + ".txt");
                    File.WriteAllText(filePath, encryptedText);
                    Console.WriteLine($"Failas issaugotas: {filePath}");
                    return;
                }
                Console.WriteLine("Tokio pasirinkimo nėra!");
            }
        }
    }
}
