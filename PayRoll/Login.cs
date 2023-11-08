

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRollManagement
{
    internal class Login
    {
        public string username;
        public string pwd;
        public string connectionString= "Data Source=10.1.193.167\\SQLEXPRESS;Initial Catalog=TBsasi;Persist Security Info=True;User ID=sa; Password=sql@123;";


        public void ShowMenu()
        {

            Program p = new Program();
            p.Menu();
            Console.WriteLine("Would you like to continue (Y / N)");
            char choice = Convert.ToChar(Console.ReadLine());
            while (choice == 'Y' && choice != 'N')
            {
                p.Menu();
            }
        }
        public void loginUserInput()
        {

            Console.WriteLine("Enter a name");
            username = Console.ReadLine();
            Console.WriteLine("Enter a password");
            pwd = Console.ReadLine();
            Console.WriteLine();




        }
     

        public void logincheck()
        {
            using (var con = new SqlConnection(connectionString))
               
            {
              
                loginUserInput();


                using (var cmd = new SqlCommand("select dbo.logincheck(@username,@pwd)", con))
                {
                  

                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@pwd", pwd);
                    con.Open();

                    int count = Convert.ToInt32(value: cmd.ExecuteScalar());

                   

                    if (count == 1)
                    {

                        Console.WriteLine("welcome " + username);
                        ShowMenu();


                    }


                    else
                    {
                        Console.WriteLine("User profile not available,Register Yourself");
                        Console.WriteLine("Choose \n 1.Register Yourself \n 2.Exit");
                        int options = Convert.ToInt32(Console.ReadLine());
                        switch (options)
                        {
                            case 1:
                                Registration.UserRegistration();
                                break;

                            case 2:
                                Environment.Exit(0);
                                break;
                            default:
                                break;
                        }

                    }
                }
            }
        }
    }
        }
