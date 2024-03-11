using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformacijosSaugumas2
{
    public class MenuManager
    {
        public static void LoadMenu()
        {
            while (true)
            {
                Console.WriteLine("------Meniu------");
                Console.WriteLine("0. Išeiti iš programos");
                Console.WriteLine("1. DES Šifravimas");
                Console.WriteLine("2. Dešifravimas");
                Console.WriteLine("3. Dešifravimas iš failo");

                if (int.TryParse(Console.ReadLine(), out int userChoice))
                {
                    switch (userChoice)
                    {
                        case 0:
                            Environment.Exit(0);
                            break;
                        case 1:
                            LoadModeMenu("Encryption");
                            break;
                        case 2:
                            LoadModeMenu("Decryption");
                            break;
                        case 3:
                            LoadModeMenu("DecryptionFromFile");
                            break;
                        default:
                            Console.WriteLine("Tokio pasirinkimo nėra!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Netinkama įvestis. Įveskite skaičių.");
                }
            }
        }

        public static void LoadModeMenu(string operation)
        {
            while (true)
            {
                Console.WriteLine("----Modos pasirinkimas----");
                Console.WriteLine("0. Grižti atgal");
                Console.WriteLine("1. ECB moda");
                Console.WriteLine("2. CFB moda");
                Console.WriteLine("3. CBC moda");

                if (int.TryParse(Console.ReadLine(), out int userChoice))
                {
                    if (userChoice == 0)
                    {
                        break;
                    }

                    switch (userChoice)
                    {
                        case 0:
                            break;
                        case 1:
                            if (operation == "Encryption")
                            {
                                EncryptionHandler.Encryption("ECB");
                            }
                            else if (operation == "Decryption")
                            {
                                EncryptionHandler.DecryptionFromText("ECB");
                            }
                            else if (operation == "DecryptionFromFile")
                            {
                                EncryptionHandler.DecryptionFromFile("ECB");
                            }
                            break;
                        case 2:
                            if (operation == "Encryption")
                            {
                                EncryptionHandler.Encryption("CFB");
                            }
                            else if (operation == "Decryption")
                            {
                                EncryptionHandler.DecryptionFromText("CFB");
                            }
                            else if (operation == "DecryptionFromFile")
                            {
                                EncryptionHandler.DecryptionFromFile("CFB");
                            }
                            break;
                        case 3:
                            if (operation == "Encryption")
                            {
                                EncryptionHandler.Encryption("CBC");
                            }
                            else if (operation == "Decryption")
                            {
                                EncryptionHandler.DecryptionFromText("CBC");
                            }
                            else if (operation == "DecryptionFromFile")
                            {
                                EncryptionHandler.DecryptionFromFile("CBC");
                            }
                            break;
                        default:
                            Console.WriteLine("Netinkamas pasirinkimas.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Netinkama įvestis. Įveskite skaičių.");
                }   
            }
        }
    }
}
