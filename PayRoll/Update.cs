using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRollManagement
{
    internal class Update
    {
        public static string empname;
        public static string deptname;
        public static int leavedays;
        static string path = "Data Source=10.1.193.167\\SQLEXPRESS;Initial Catalog=TBsasi;Persist Security Info=True;User ID=sa; Password=sql@123;";

        public static void UpdateEmployee()
        {

            using (var con = new SqlConnection(path))

            {
                Console.WriteLine("update your leave days ");
                Console.WriteLine("Enter Your name :");
                empname = Console.ReadLine();
                Console.WriteLine("Enter the leavedays :");
                leavedays = Convert.ToInt32(Console.ReadLine());
                DateTime currentDate = DateTime.Now;
                int days = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
                int salary = (days * 500) - (leavedays * 500);



                using (var cmd = new SqlCommand("updateempdetails", con))
                {


                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@empname", empname);
                    cmd.Parameters.AddWithValue("@leavedays", leavedays);
                    cmd.Parameters.AddWithValue("@salary", salary);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine($"Now your salary of Your {currentDate.Month} month is {salary}");
                    Console.WriteLine("your leave days  updated");


                }
            }
        }
    }
}
