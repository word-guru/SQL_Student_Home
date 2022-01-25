using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using Student.Model;
using System.Data;

namespace Student.Lib
{
    public class DB
    {
        private SqlConnection _db;
        private SqlCommand _command;    

        public DB()
        {
            _db = new SqlConnection(GetConnectionString());
            _command = new SqlCommand { Connection = _db };
        }

        private string GetConnectionString()
        {
            using var file = new StreamReader("connection_db.ini");
            return file.ReadToEnd();
        }

        public List<Stud> GetStudents()
        {
            var students = new List<Stud>();

            _db.Open();

            _command.CommandText = "SELECT id, lastName, surName, averageRating FROM studentsdb";
            var result = _command.ExecuteReader();

            while(result.Read())
            {
                var stud = new Stud
                {
                    Id = result.GetInt32("id"),
                    LastName = result.GetString("lastName"),
                    SurName = result.GetString("surName"),
                    AverageRating = result.GetInt32("averageRating")
                };
                students.Add(stud);
            }
            _db.Close();

            return students;
        }
    }
}
