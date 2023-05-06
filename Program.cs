using Quiz.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using Quiz.Screens;
using Quiz.Repositories;

namespace Quiz
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Quiz;User ID=sa;Password=Sh@rk250535; TrustServerCertificate=True";
        static void Main(string[] args)
        {
            Database.Connection = new SqlConnection(CONNECTION_STRING);
            Database.Connection.Open();
            MainMenu.Start();
            Database.Connection.Close();
        }
    }
}