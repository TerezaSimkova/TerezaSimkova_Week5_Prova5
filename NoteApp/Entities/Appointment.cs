using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Entities
{
    class Appointment
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ExpiringDate { get; set; }
        public EnumLevel Importance { get; set; }
        public bool Done { get; set; }


        public Appointment(int? id, string title, string description, DateTime expiringDate, EnumLevel importance, bool done)
        {
            Id = id;
            Title = title;
            Description = description;
            ExpiringDate = expiringDate;
            Importance = importance;
            Done = done;
        }

        public Appointment() { }

        public virtual string Print()
        {
            return $"{Title} - {Description} - {ExpiringDate} | {Importance} - {Done}";
        }

    }

    public enum EnumLevel
    {
        low = 1,
        medium = 2,
        hight = 3
    }
}
