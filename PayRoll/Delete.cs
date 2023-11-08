using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRollManagement
{
    internal class Delete
    {
        public static string empname;
        public static string deptname;
        public static int leavedays;
        static string path = "Data Source=10.1.193.167\\SQLEXPRESS;Initial Catalog=TBsasi;Persist Security Info=True;User ID=sa; Password=sql@123;";

        // DELETE
        public static void DeleteEmployee()
        {
            Login l = new Login();
            Console.WriteLine("Login as HR");
            l.loginUserInput();
            if (l.username.Equals("sasi") && l.pwd.Equals("123"))
            {

                Console.WriteLine("Enter the Employee name to delete their profile");
                string empname = Console.ReadLine();

                using (var con = new SqlConnection(path))
                {

                    using (var cmd = new SqlCommand("delteempdetails", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();
                        cmd.Parameters.AddWithValue("@empname", empname);
                        cmd.ExecuteNonQuery();
                        Console.WriteLine("Sucessfully dleted");

                    }

                }

            }
            else
            {

                Console.WriteLine("Permission denied");
            }
        }

    }
}
