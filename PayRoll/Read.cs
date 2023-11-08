using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRollManagement
{
    internal class Read
    {
        public static string empname;
        public static string deptname;
        public static int leavedays;
        static string path = "Data Source=10.1.193.167\\SQLEXPRESS;Initial Catalog=TBsasi;Persist Security Info=True;User ID=sa; Password=sql@123;";

        public static void GetEmployeeDetails()

        {
            Login l = new Login();
            Console.WriteLine("Only Hr Can see all the Employee Profiles");
            l.loginUserInput();
            if (l.username.Equals("sasi") && l.pwd.Equals("123"))
            {


                using (var con = new SqlConnection(path))
                {

                    using (var cmd = new SqlCommand("getempdetails", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        con.Open();

                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {

                            Console.WriteLine($"Employee Id :{reader["empid"]}," + "\n" +
                                  $"Employee Name :{reader["empname"]}," + "\n" +
                                  $"Department Name :{reader["deptname"]}," + "\n" +
                                  $" Leave days :{reader["leavedays"]}," + "\n" +
                                  $"salary :{reader["salary"]}," + "\n"
                                 );

                        }


                    }

                }

            }
            else
            {

                Console.WriteLine("Employees cannot see All Profiles");

            }
        }


        public static void MyProfile()
        {

            Console.WriteLine("Enter the  employee name :");
            empname = Console.ReadLine();

            using (var con = new SqlConnection(path))
            {

                using (var cmd = new SqlCommand("MyProfile", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    cmd.Parameters.AddWithValue("@empname", empname);

                    var reader = cmd.ExecuteReader();
                    Console.WriteLine();
                    while (reader.Read())
                    {


                        Console.WriteLine(


                              $"Department Name :{reader["deptname"]}" + "\n" +
                              $"Leave days :{reader["leavedays"]}" + "\n" +
                              $"salary :{reader["salary"]}" + "\n"
                             );

                    }


                }



            }

        }



    }
}
