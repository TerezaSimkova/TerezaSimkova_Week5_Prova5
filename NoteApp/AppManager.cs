using NoteApp.Entities;
using NoteApp.ListAdoRepository;
using NoteApp.ListRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NoteApp
{
    internal class AppManager
    {
        //Repository List
        //public static AppointmentRepository apR = new AppointmentRepository();

        //Repository Ado
        public static AppointmentAdoRepository apR = new AppointmentAdoRepository();

        internal static void ShowAll()
        {
            List<Appointment> appointments = apR.Fetch();
            foreach (var app in appointments)
            {
                Console.WriteLine(app.Print());
            }

        }

        internal static void Insert()
        {
            Appointment app = new Appointment();
            app.Title = InsertTitle();
            app.Description = InsertDEscription();
            app.ExpiringDate = InsertExDate();
            app.Importance = InsertImportance();
            app.Done = InsertFlagDone();
      
            apR.Insert(app);
        }

        private static bool InsertFlagDone()
        {            
            Console.WriteLine("Scegli 'true' se impegno é stato portato a termine ,oppure 'false' se non é ancora portato al termine.");
            bool done = true;
            while (!bool.TryParse(Console.ReadLine(), out done))
            {
                Console.WriteLine("Scelta non valida!");
            }
            return done;
        }

        private static EnumLevel InsertImportance()
        {
            int level;
            do
            {
                Console.WriteLine("Inserisci la importanza den impegno 1 - low / 2 - medium / 3- hight:");

            } while (!int.TryParse(Console.ReadLine(), out level) || level < 1 || level > 3);
            return (EnumLevel)level;
        }

        internal static void FilterByDate()
        {
            DateTime done = InsertExDate();
            List<Appointment> appointments = apR.GetByDate(done);
            foreach (var ap in appointments)
            {
                Console.WriteLine(ap.Print());
            }
        }

        internal static void FilterByImportance()
        {
            EnumLevel important = InsertImportance();
            List<Appointment> appointments = apR.GetByImportance(important);
            foreach (var ap in appointments)
            {
                Console.WriteLine(ap.Print());
            }
        }

        internal static void FilterByDone()
        {
            bool done = InsertFlagDone();
            List<Appointment> appointments = apR.GetByFlag(done);
            foreach (var ap in appointments)
            {
                Console.WriteLine(ap.Print());
            }
        }

        internal static void Delete()
        {
            Appointment ap = ChooseImpegno();
            apR.Delete(ap);
        }

        internal static void Update()
        {

            Appointment ap = ChooseImpegno();

            
            if (ap.Id == null)
            {
                apR.Delete(ap);
            }

            int scelta;

                do
                {
                    Console.WriteLine("Cosa vuoi modificare?\n");
                    Console.WriteLine("Scegli 1 - Title ");
                    Console.WriteLine("Scegli 2 - Descrizione");
                    Console.WriteLine("Scegli 3 - Data ");
                    Console.WriteLine("Scegli 4 - Importanza del impegno");
                    Console.WriteLine("Scegli 5 - Impegno terminato o no\n");

                } while (!int.TryParse(Console.ReadLine(), out scelta) || scelta < 0 || scelta > 5);

                switch (scelta)
                {
                    case 1:
                        ap.Title = InsertTitle();
                        break;
                    case 2:
                        ap.Description = InsertDEscription();
                        break;
                    case 3:
                        ap.ExpiringDate = InsertExDate();
                        break;
                    case 4:
                        ap.Importance = InsertImportance();
                        break;
                    case 5:
                        ap.Done = InsertFlagDone();
                        break;
                }

            apR.Update(ap);
        }

        private static Appointment ChooseImpegno()
        {
            List<Appointment> appointments = apR.Fetch();

            int i = 1;
            foreach (var app in appointments)
            {
                Console.WriteLine($"Premi {i} per la {app.Print()}");
                i++;
            }

            int chooseImpegno;
            bool isInt;
            do
            {
                Console.WriteLine("Quale impegno vuoi modificare / cancellare?");
                isInt = int.TryParse(Console.ReadLine(), out chooseImpegno);

            } while (!isInt || chooseImpegno < 0 || chooseImpegno > appointments.Count);

            return appointments.ElementAt(chooseImpegno - 1);
        }

        private static DateTime InsertExDate()
        {
            DateTime dt = new DateTime();
            do
            {
                Console.WriteLine("Inserisci la data di scadenza:");

            } while (!DateTime.TryParse(Console.ReadLine(), out dt) || dt <= DateTime.Today);
            return dt;
        }

        private static string InsertDEscription()
        {
            String description = String.Empty;
            do
            {
                Console.WriteLine("Inserisci la descrizione:");
                description = Console.ReadLine();

            } while (String.IsNullOrEmpty(description));
            return description;

        }

        private static string InsertTitle()
        {
            String title = String.Empty;
            do
            {
                Console.WriteLine("Inserisci il titolo:");
                title = Console.ReadLine();

            } while (String.IsNullOrEmpty(title));
            return title;

        }
    }
}