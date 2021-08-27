using System;

namespace NoteApp
{
    internal class Start
    {
        internal static void Menu()
        {
            int scelta;
            bool continua= true;


            while (continua)
            {
                Console.WriteLine("\n***Welcome***\n");

                Console.WriteLine("Premi 1 per scegliere di vedere tutti gli impegni.");
                Console.WriteLine("Premi 2 per modificare un impegno.");
                Console.WriteLine("Premi 3 per eliminare un impegno.");
                Console.WriteLine("Premi 4 per inserire un nuovo impegno.");
                Console.WriteLine("Premi 5 per filtrare per la data maggiore o uguale a quella inserita da te.");
                Console.WriteLine("Premi 6 per filtrare per il livello di importanza.");
                Console.WriteLine("Premi 7 per vedere gli impegni portati al termine");
                Console.WriteLine("Premi 0 per uscire.\n");

                do
                {
                    Console.WriteLine("Cosa scegli?\n");

                } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > 7);

                switch (scelta)
                {
                    case 1:
                        AppManager.ShowAll();
                        break;
                    case 2:
                        AppManager.Update();
                        break;
                    case 3:
                        AppManager.Delete();
                        break;
                    case 4:
                        AppManager.Insert();
                        break;
                    case 5:
                        AppManager.FilterByDate();
                        break;
                    case 6:
                        AppManager.FilterByImportance();
                        break;
                    case 7:
                        AppManager.FilterByDone();
                        break;
                    case 0:
                        Console.WriteLine("***Bye***");
                        Console.WriteLine("***See you soon***");
                        continua = false;
                        break;
                }
            }
        }
    }
}