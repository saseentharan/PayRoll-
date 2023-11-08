using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRollManagement
{
    internal class Create
    {

        public static string empname;
        public static string deptname;
        public static int leavedays;
        static string path = "Data Source=10.1.193.167\\SQLEXPRESS;Initial Catalog=TBsasi;Persist Security Info=True;User ID=sa; Password=sql@123;";

        //INSERT
        public static void GetUserInput()
        {
            Console.WriteLine("Enter the  employee name :");
            empname = Console.ReadLine();

            Console.WriteLine("Enter the Deptname :");
            deptname = Console.ReadLine();

            Console.WriteLine("Enter the leavedays :");
            leavedays = Convert.ToInt32(Console.ReadLine());


        }


        public static  void InsertEmployee()
        {
            GetUserInput();
            DateTime currentDate = DateTime.Now;
            int days = DateTime.DaysInMonth(currentDate.Year, currentDate.Month);
            int salary = (days * 500) - (leavedays * 500);

            using (var con = new SqlConnection(path))
            {

                using (var cmd = new SqlCommand("insertempdetails", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@empname", empname);
                    cmd.Parameters.AddWithValue("@deptname", deptname);
                    cmd.Parameters.AddWithValue("@leavedays", leavedays);
                    cmd.Parameters.AddWithValue("@salary", salary);
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Sucess fully added");

                }
            }




        }

    }
}
