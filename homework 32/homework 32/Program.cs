using System;
using System.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString = "Data Source=(local);Initial Catalog=master;Integrated Security=True";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            string createDatabaseQuery = "CREATE DATABASE MyDatabase";
            ExecuteNonQuery(connection, createDatabaseQuery);

            string createTableQuery = "CREATE TABLE MyTable (Id INT PRIMARY KEY, Name NVARCHAR(50), Age INT)";
            ExecuteNonQuery(connection, createTableQuery);

         
            string insertDataQuery = "INSERT INTO MyTable VALUES (@Id, @Name, @Age)";
            ExecuteNonQuery(connection, insertDataQuery, new SqlParameter("@Id", 1), new SqlParameter("@Name", "John"), new SqlParameter("@Age", 30));

  
            string updateDataQuery = "UPDATE MyTable SET Name = @Name WHERE Id = @Id";
            ExecuteNonQuery(connection, updateDataQuery, new SqlParameter("@Id", 1), new SqlParameter("@Name", "Andriy Balkonskiy"));

            string deleteDataQuery = "DELETE FROM MyTable WHERE Id = @Id";
            ExecuteNonQuery(connection, deleteDataQuery, new SqlParameter("@Id", 1));

            string selectDataQuery = "SELECT * FROM MyTable WHERE Age > @Age";
            SqlDataReader reader = ExecuteReader(connection, selectDataQuery, new SqlParameter("@Age", 20));

            while (reader.Read())
            {
                Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}");
            }

            reader.Close();

            selectDataQuery = "SELECT * FROM MyTable";
            reader = ExecuteReader(connection, selectDataQuery);

            while (reader.Read())
            {
                Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}");
            }

            reader.Close();
        }
    }

    static void ExecuteNonQuery(SqlConnection connection, string query, params SqlParameter[] parameters)
    {
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddRange(parameters);

            command.ExecuteNonQuery();
        }
    }

    static SqlDataReader ExecuteReader(SqlConnection connection, string query, params SqlParameter[] parameters)
    {
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddRange(parameters);

            return command.ExecuteReader();
        }
    }
}
