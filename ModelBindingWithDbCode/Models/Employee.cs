using Microsoft.Data.SqlClient;
using System.Data;

namespace ModelBinding.Models
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public static List<Employee> GetAllEmployees()
        {
            List<Employee> list = new List<Employee>();
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HydJune2024;Integrated Security=True;";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees";

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Employee emp = new Employee();
                    //emp.Name = dr["Name"].ToString();
                    //emp.EmpNo = (int)dr["EmpNo"];
                    //emp.DeptNo= (int)dr["DeptNo"];
                    //emp.Basic = (decimal)dr["Basic"];

                    //emp.EmpNo = dr.GetInt32(0);
                    emp.EmpNo = dr.GetInt32("EmpNo");
                    emp.Name = dr.GetString("Name");
                    emp.DeptNo = dr.GetInt32("DeptNo");
                    emp.Basic = dr.GetDecimal("Basic");

                    list.Add(emp);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return list;
        }

        public static Employee GetSingleEmployee(int EmpNo)
        {
            Employee emp = new Employee();

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HydJune2024;Integrated Security=True;";
            try
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Employees where EmpNo =@EmpNo";
                cmd.Parameters.AddWithValue("@EmpNo", EmpNo);
                SqlDataReader dr = cmd.ExecuteReader();
                //if(dr.HasRows)
                if (dr.Read())
                {
                    //emp.Name = dr["Name"].ToString();
                    //emp.EmpNo = (int)dr["EmpNo"];
                    //emp.DeptNo= (int)dr["DeptNo"];
                    //emp.Basic = (decimal)dr["Basic"];

                    //emp.EmpNo = dr.GetInt32(0);
                    emp.EmpNo = dr.GetInt32("EmpNo");
                    emp.Name = dr.GetString("Name");
                    emp.DeptNo = dr.GetInt32("DeptNo");
                    emp.Basic = dr.GetDecimal("Basic");
                }
                else
                    emp = null;
                dr.Close();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
            return emp;
        }

        public static void Insert(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HydJune2024;Integrated Security=True;";
            try
            {
                cn.Open();
                SqlCommand cmdInsert = new SqlCommand();
                cmdInsert.Connection = cn;
                cmdInsert.CommandType = CommandType.Text;
                cmdInsert.CommandText = "insert into Employees values(@EmpNo,@Name,@Basic,@DeptNo)";

                cmdInsert.Parameters.AddWithValue("@EmpNo", obj.EmpNo);
                cmdInsert.Parameters.AddWithValue("@Name", obj.Name);
                cmdInsert.Parameters.AddWithValue("@Basic", obj.Basic);
                cmdInsert.Parameters.AddWithValue("@DeptNo", obj.DeptNo);

                cmdInsert.ExecuteNonQuery();

               
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }
        public static void Update(Employee obj)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HydJune2024;Integrated Security=True;";
            try
            {
                cn.Open();
                SqlCommand cmdUpdate = new SqlCommand();
                cmdUpdate.Connection = cn;
                cmdUpdate.CommandType = CommandType.Text;
                cmdUpdate.CommandText = "update Employees set Name=@Name,Basic=@Basic,DeptNo=@DeptNo where EmpNo=@EmpNo";

                cmdUpdate.Parameters.AddWithValue("@Name", obj.Name);
                cmdUpdate.Parameters.AddWithValue("@Basic", obj.Basic);
                cmdUpdate.Parameters.AddWithValue("@DeptNo", obj.DeptNo);
                cmdUpdate.Parameters.AddWithValue("@EmpNo", obj.EmpNo);

                cmdUpdate.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }
        public static void Delete(int EmpNo)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HydJune2024;Integrated Security=True;";
            try
            {
                cn.Open();
                SqlCommand cmdDelete = new SqlCommand();
                cmdDelete.Connection = cn;
                cmdDelete.CommandType = CommandType.Text;
                cmdDelete.CommandText = "delete from Employees where EmpNo=@EmpNo";

                cmdDelete.Parameters.AddWithValue("@EmpNo", EmpNo);

                cmdDelete.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                cn.Close();
            }
        }
    }

}
