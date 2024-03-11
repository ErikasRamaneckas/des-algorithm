using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InformacijosSaugumas2
{
    public class EncryptionHandler
    {
        public static void Encryption(string chosenMode)
        {
            using (DES des = DES.Create())
            {
                byte[] iv = des.IV;
                byte[] inputBytes = EncryptionHelper.InputPlainTextValue(des);
                des.Key = EncryptionHelper.InputKeyValue(des);

                byte[] encryptedBytes = null;
                if (chosenMode == "ECB")
                {
                    encryptedBytes = des.EncryptEcb(inputBytes, PaddingMode.PKCS7);
                }
                else if (chosenMode == "CFB")
                {
                    encryptedBytes = des.EncryptCfb(inputBytes, iv, PaddingMode.PKCS7);
                }
                else if (chosenMode == "CBC")
                {
                    encryptedBytes = des.EncryptCbc(inputBytes, iv, PaddingMode.PKCS7);
                }
                string encryptedText = DisplayEncryptedText(encryptedBytes, iv);
                EncryptionHelper.PromptSaveToFile(encryptedText);
            }
        }

        public static byte[] Decryption(string encryptedText, string chosenMode, DES des)
        {
            int ivStartIndex = encryptedText.Length - 12;
            string ivBase64 = encryptedText.Substring(ivStartIndex);
            string textBeforeIV = encryptedText.Substring(0, ivStartIndex);
            byte[] iv = Convert.FromBase64String(ivBase64);
            byte[] encryptedBytes = Convert.FromBase64String(textBeforeIV);

            byte[] decryptedBytes = null;
            if (chosenMode == "ECB")
            {
                decryptedBytes = des.DecryptEcb(encryptedBytes, PaddingMode.PKCS7);
            }
            else if (chosenMode == "CFB")
            {
                decryptedBytes = des.DecryptCfb(encryptedBytes, iv, PaddingMode.PKCS7);
            }
            else if (chosenMode == "CBC")
            {
                decryptedBytes = des.DecryptCbc(encryptedBytes, iv, PaddingMode.PKCS7);
            }
            return decryptedBytes;
        }

        public static void DecryptionFromText(string chosenMode)
        {
            using (DES des = DES.Create())
            {
                des.Key = EncryptionHelper.InputKeyValue(des);

                Console.WriteLine("Įveskite užšifruotą tekstą:");
                string encryptedText = Console.ReadLine();

                byte[] decryptedBytes = Decryption(encryptedText, chosenMode, des);
                DisplayDecryptedText(decryptedBytes);
            }
        }


        public static void DecryptionFromFile(string chosenMode)
        {
            using (DES des = DES.Create())
            {
                des.Key = EncryptionHelper.InputKeyValue(des);
                string fileName = EncryptionHelper.InputFileName();

                try
                {
                    if (File.Exists(fileName))
                    {
                        string encryptedText = File.ReadAllText(fileName);

                        byte[] decryptedBytes = Decryption(encryptedText, chosenMode, des);
                        DisplayDecryptedText(decryptedBytes);
                    }
                    else
                    {
                        Console.WriteLine("Failas tokiu pavadinimu neegzistuoja.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ivyko klaida: {ex.Message}");
                }
            }
        }

        private static void DisplayDecryptedText(byte[] decryptedBytes)
        {
            string decryptedText = Encoding.UTF8.GetString((byte[])decryptedBytes);
            Console.WriteLine("Dešifruotas tekstas: " + decryptedText);
        }

        private static string DisplayEncryptedText(byte[] encryptedBytes, byte[] iv)
        {
            string encryptedText = Convert.ToBase64String(encryptedBytes) + Convert.ToBase64String(iv);
            Console.WriteLine("Uzsifruotas tekstas: " + encryptedText);
            return encryptedText;
        }
    }
}
