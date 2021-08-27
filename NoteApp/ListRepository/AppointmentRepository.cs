using NoteApp.Entities;
using NoteApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.ListRepository
{
    class AppointmentRepository : IAppointmentManager
    {
        List<Appointment> appointments = new List<Appointment>()
        {
            new Appointment(null,"Birthday_Party","Friends and family",new DateTime(2021,08,30),EnumLevel.hight,false),
            new Appointment(null,"Shopping","For beggining of school",new DateTime(2021,09,01),EnumLevel.medium,false),
            new Appointment(null,"Apperitive with Friends","In city center n.32",new DateTime(2021,08,28),EnumLevel.low,false),
        };

        public void Delete(Appointment appointment)
        {
            appointments.Remove(appointment);
        }

        public List<Appointment> Fetch()
        {
            return appointments;
        }

        public List<Appointment> GetByDate(DateTime expiringDate)
        {
            return appointments.Where(ap => ap.ExpiringDate >= expiringDate).ToList();
        }

        public List<Appointment> GetByFlag(bool done)
        {
            return appointments.Where(ap => ap.Done == done).ToList();
        }

        public List<Appointment> GetByImportance(EnumLevel importance)
        {
            return appointments.Where(ap => ap.Importance == importance).ToList();
        }

        public void Insert(Appointment appointment)
        {
            appointments.Add(appointment);
        }

        public void Update(Appointment appointment)
        {
            Insert(appointment);
        }
    }
}
