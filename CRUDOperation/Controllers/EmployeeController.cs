using CRUDOperation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUDOperation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        String ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=JKJune2024;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;";
        // GET: api/<EmployeeController>
        [HttpGet]
        public List<Employee> Get()
        {
            List<Employee> list = new List<Employee>();
            using (SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=JKJune2024;Integrated Security=True;Connect Timeout=30;Encrypt=False;"))
            {
                try
                {
                    con.Open();
                    Console.WriteLine("Connection successful.");


                    string query = "SELECT * FROM Employee"; // Replace 'YourTableName' with your actual table name

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Employee emp = new Employee();
                                emp.Id = Convert.ToInt32(reader["Id"]);
                                emp.Name = reader["Name"].ToString();
                                emp.age = Convert.ToInt32(reader["age"]);
                                list.Add(emp);
                            }
                        }

                    }
                }
                catch (SqlException ex)
                {
                    Console.WriteLine($"SQL Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            return list;
        }

        [HttpPost]
        public void Post(Employee emp)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=JKJune2024;Integrated Security=True;Connect Timeout=30;Encrypt=False;"))
                {
                    // Define the SQL query with parameter placeholders
                    string query = "INSERT INTO Employee (Name, Age) VALUES (@Name, @Age);";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Add parameters to the SQL command
                        // cmd.Parameters.AddWithValue("@Id", emp.Id);
                        cmd.Parameters.AddWithValue("@Name", emp.Name);
                        cmd.Parameters.AddWithValue("@Age", emp.age);

                        // Open the database connection
                        con.Open();

                        // Execute the SQL query
                        int result = cmd.ExecuteNonQuery(); // Returns the number of rows affected

                        if (result > 0)
                        {
                            Console.WriteLine("Data added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to add data.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        /*
                // POST api/<EmployeeController>
                [HttpPost]
                public void Post(Employee emp)
                {
                    try
                    {
                        using (SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=JKJune2024;Integrated Security=True;Connect Timeout=30;Encrypt=False;"))
                        {
                            // Define the SQL query with parameter placeholders
                            string query = "INSERT INTO Employee (Name, Age) VALUES (@Name, @Age);";

                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {
                                // Add parameters to the SQL command
                                // cmd.Parameters.AddWithValue("@Id", emp.Id);
                                cmd.Parameters.AddWithValue("@Name", emp.Name);
                                cmd.Parameters.AddWithValue("@Age", emp.age);

                                // Open the database connection
                                con.Open();

                                // Execute the SQL query
                                int result = cmd.ExecuteNonQuery(); // Returns the number of rows affected

                                if (result > 0)
                                {
                                    Console.WriteLine("Data added successfully.");
                                }
                                else
                                {
                                    Console.WriteLine("Failed to add data.");
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred: {ex.Message}");
                    }
                }

                */

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee emp)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=JKJune2024;Integrated Security=True;Connect Timeout=30;Encrypt=False;"))
                {
                    string query = "UPDATE Employee SET Name=@Name, Age=@age where id=@Id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Add parameters to the SQL command
                        cmd.Parameters.AddWithValue("@Id",id);
                        cmd.Parameters.AddWithValue("@Name", emp.Name);
                        cmd.Parameters.AddWithValue("@Age", emp.age);

                        // Open the database connection
                        con.Open();

                        // Execute the SQL query
                        int result = cmd.ExecuteNonQuery(); // Returns the number of rows affected

                        if (result > 0)
                        {
                            Console.WriteLine("Data updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to update data.");
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

}

            // DELETE api/<EmployeeController>/5
            [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=JKJune2024;Integrated Security=True;Connect Timeout=30;Encrypt=False;"))
                {
                    string query = "DELETE from Employee where id=@Id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Add parameters to the SQL command
                        cmd.Parameters.AddWithValue("@Id", id);

                        // Open the database connection
                        con.Open();

                        // Execute the SQL query
                        int result = cmd.ExecuteNonQuery(); // Returns the number of rows affected

                        if (result > 0)
                        {
                            Console.WriteLine("Data deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to delete data.");
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
