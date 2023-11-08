using PayRollManagement;

class Program {

    public void Menu()
    {
        Console.WriteLine("Choose \n 1.View Employee profiles \n 2.Insert Your Profile \n 3.Update Employee  \n 4.Delete Employee \n 5. View My Profile  \n6.Exit");
        Console.WriteLine("What do you Need ????");
        int options = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("************************************************");
   

        switch (options)
        {

            case 1:
                Read.GetEmployeeDetails();
                break;
            case 2:
                Create.InsertEmployee();
                break;
            case 3:
                Update.UpdateEmployee();
                break;
            case 4:
                Delete.DeleteEmployee();
                break;
            case 5:
               Read.MyProfile();   
                break;
            case 6:
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid option");
                break;

        }
    }
    static void Main(String[] args)
    {

        {
            Console.WriteLine("Welcome to HR PayRoll  Management");
            Console.WriteLine("\n **************************************");

            Login lg = new Login();
             lg.logincheck();
          
        


                
        }

    }


}
