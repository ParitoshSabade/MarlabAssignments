using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

public class AzureSqlCrud
{
    private string connectionString;

    public AzureSqlCrud(string connectionString)
    {
        this.connectionString = connectionString;
    }

    // Create (Insert) Operation
    public bool InsertRecord(int empId, string empName, int deptId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string insertQuery = "INSERT INTO Emptable (EmpId, EmpName, DeptId) VALUES (@EmpId, @EmpName, @DeptId)";

            using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
            {
                cmd.Parameters.AddWithValue("@EmpId", empId);
                cmd.Parameters.AddWithValue("@EmpName", empName);
                cmd.Parameters.AddWithValue("@DeptId", deptId);

                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }

    // Read (Select) Operation
    public DataTable SelectRecords()
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string selectQuery = "SELECT * FROM Emptable";
            DataTable dataTable = new DataTable();

            using (SqlCommand cmd = new SqlCommand(selectQuery, connection))
            {
                connection.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dataTable.Load(reader);
                }
            }

            return dataTable;
        }
    }

    // Update Operation
    public bool UpdateRecord(int empId, string empName, int deptId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string updateQuery = "UPDATE Emptable SET EmpName = @EmpName, DeptId = @DeptId WHERE EmpId = @EmpId";

            using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
            {
                cmd.Parameters.AddWithValue("@EmpId", empId);
                cmd.Parameters.AddWithValue("@EmpName", empName);
                cmd.Parameters.AddWithValue("@DeptId", deptId);

                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }

    // Delete Operation
    public bool DeleteRecord(int empId)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string deleteQuery = "DELETE FROM Emptable WHERE EmpId = @EmpId";

            using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
            {
                cmd.Parameters.AddWithValue("@EmpId", empId);

                connection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Replace with your Azure SQL Database connection string
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(System.IO.Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        string? connectionString = config.GetConnectionString("AzureSqlDB");
        AzureSqlCrud sqlCrud = new AzureSqlCrud(connectionString);

        // Create (Insert) a record
        bool insertResult = sqlCrud.InsertRecord(4, "Walter Mitty", 101);
        if (insertResult)
        {
            Console.WriteLine("Record inserted successfully.");
        }

        // Read (Select) records
        DataTable records = sqlCrud.SelectRecords();
        Console.WriteLine("Records in the database:");
        foreach (DataRow row in records.Rows)
        {
            Console.WriteLine($"EmpId: {row["EmpId"]}, EmpName: {row["EmpName"]}, DeptId: {row["DeptId"]}");
        }

        // Update a record
        bool updateResult = sqlCrud.UpdateRecord(5, "Evan David", 102);
        if (updateResult)
        {
            Console.WriteLine("Record updated successfully.");
        }

        // Delete a record
        bool deleteResult = sqlCrud.DeleteRecord(6);
        if (deleteResult)
        {
            Console.WriteLine("Record deleted successfully.");
        }
    }
}
