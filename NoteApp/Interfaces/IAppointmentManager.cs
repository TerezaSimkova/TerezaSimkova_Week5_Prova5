using NoteApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Interfaces
{
    interface IAppointmentManager
    {
        public List<Appointment> Fetch();
        public void Insert(Appointment appointment);
        public void Update(Appointment appointment);
        public void Delete(Appointment appointment);
        public List<Appointment> GetByImportance(EnumLevel importance);
        public List<Appointment> GetByFlag(bool done);
        public List<Appointment> GetByDate(DateTime expiringDate);
    }
}
