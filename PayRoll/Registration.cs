using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRollManagement
{
    internal class Registration
    {
        public static  void UserRegistration()
           
        {
            Login l = new Login();
           l. loginUserInput();
            using (var con = new SqlConnection(l.connectionString))
            {


                using (var cmd = new SqlCommand("userregistration", con))
                {


                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", l.username);
                    cmd.Parameters.AddWithValue("@pwd", l.pwd);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("User registration successfull");
                   l. ShowMenu();


                }
            }
        }
    }
}
