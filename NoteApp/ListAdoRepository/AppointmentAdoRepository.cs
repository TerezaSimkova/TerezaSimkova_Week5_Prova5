using NoteApp.Entities;
using NoteApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.ListAdoRepository
{
    class AppointmentAdoRepository : IAppointmentManager
    {
        const string connectionString = @"Data Source = (localdb)\mssqllocaldb; Initial Catalog=Appointments; Integrated Security=true;";

        public void Delete(Appointment appointment)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "delete from Appointment where Id=@id";
                command.Parameters.AddWithValue("@id", appointment.Id);

                command.ExecuteNonQuery();
            }
        }

        public List<Appointment> Fetch()
        {
            List<Appointment> appointments = new List<Appointment>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Appointment";

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var id = (int)reader["Id"];
                    var title = (string)reader["Title"];
                    var description = (string)reader["Description"];
                    var expiringDdate = (DateTime)reader["ExpiringDate"];
                    var importance = (EnumLevel)reader["Importance"];
                    var done = (bool)reader["Done"];

                    Appointment appointment = new Appointment(id,title,description,expiringDdate,importance,done);
                    appointments.Add(appointment);
                }

            }
            return appointments;
        }

        public List<Appointment> GetByDate(DateTime expiringDate)  //TO DO - ce un errore ,rescrive le date ad tutti gli impregni invece di mostrare solo una che ha la data scelta ( ma solo in console)
        {
            List<Appointment> appointments = new List<Appointment>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Appointment where ExpiringDate >= @expiringdate";
                command.Parameters.AddWithValue("@expiringdate", expiringDate);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var id = (int)reader["Id"];
                    var title = (string)reader["Title"];
                    var description = (string)reader["Description"];
                    var importance = (EnumLevel)reader["Importance"];
                    var done = (bool)reader["Done"];

                    Appointment appointment = new Appointment(id, title, description, expiringDate, importance, done);
                    appointments.Add(appointment);
                }

            }
            return appointments;
        }

        public List<Appointment> GetByFlag(bool done)
        {
            List<Appointment> appointments = new List<Appointment>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Appointment where Done = @done";
                command.Parameters.AddWithValue("@done", done);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var id = (int)reader["Id"];
                    var title = (string)reader["Title"];
                    var description = (string)reader["Description"];
                    var expiringDdate = (DateTime)reader["ExpiringDate"];
                    var importance = (EnumLevel)reader["Importance"];

                    Appointment appointment = new Appointment(id, title, description, expiringDdate, importance, done);
                    appointments.Add(appointment);
                }

            }
            return appointments;
        }

        public List<Appointment> GetByImportance(EnumLevel importance)
        {
            List<Appointment> appointments = new List<Appointment>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select * from Appointment where Importance = @importance";
                command.Parameters.AddWithValue("@importance", (int)importance);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var id = (int)reader["Id"];
                    var title = (string)reader["Title"];
                    var description = (string)reader["Description"];
                    var expiringDdate = (DateTime)reader["ExpiringDate"];
                    var done = (bool)reader["Done"];

                    Appointment appointment = new Appointment(id, title, description, expiringDdate, importance, done);
                    appointments.Add(appointment);
                }

            }
            return appointments;
        }

        public void Insert(Appointment appointment)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "insert into Appointment values (@title, @description, @date, @importance, @done)";
                command.Parameters.AddWithValue("@title", appointment.Title);
                command.Parameters.AddWithValue("@description", appointment.Description);
                command.Parameters.AddWithValue("@date", appointment.ExpiringDate);
                command.Parameters.AddWithValue("@importance", appointment.Importance);
                command.Parameters.AddWithValue("@done", appointment.Done);


                command.ExecuteNonQuery();
            }
        }

        public void Update(Appointment appointment)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "update Appointment set Title = @title, Description = @description, ExpiringDate = @date, Importance = @importance,Done =  @done where Id=@id";
                command.Parameters.AddWithValue("@id", appointment.Id);
                command.Parameters.AddWithValue("@title", appointment.Title);
                command.Parameters.AddWithValue("@description", appointment.Description);
                command.Parameters.AddWithValue("@date", appointment.ExpiringDate);
                command.Parameters.AddWithValue("@importance", appointment.Importance);
                command.Parameters.AddWithValue("@done", appointment.Done);


                command.ExecuteNonQuery();
            }
        }
    }
}
