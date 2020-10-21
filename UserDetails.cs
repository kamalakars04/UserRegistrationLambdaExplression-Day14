namespace UserRegistration
{
    using System;
    using System.Text.RegularExpressions;
    using NLog;

    public class UserDetails
    {
        public readonly Logger logger = LogManager.GetCurrentClassLogger();

        //constants
        const string patternOfFirstName = "^([A-Z]+)[a-zA-Z]{2,}$";
        const string patternOfLastName = "^([A-Z]+)[a-zA-Z]{2,}$";
        const string patternOfEmail = "^[a-zA-Z0-9]+([.+_-][a-zA-Z0-9]+)*@[a-zA-Z0-9]+[.][a-zA-Z]+([.][a-zA-Z]{2})?$";
        const string patternOfMobile = "^[0-9]{2}[ ][0-9]{10}$";
        const string patternOfPassword = "^(?=.*[A-Z])(?=.*[0-9])(?=.*[^0-9a-zA-Z])(?!.*[^0-9a-zA-Z].*[^0-9a-zA-Z]).{8,}$";

        //variables
        public string firstName;
        public string lastName;
        public string email;
        public string mobileNum;
        public string password;

        /// <summary>
        /// Registration of user
        /// </summary>
        public void userRegistration()
        {
            // User to input first Name
            Console.WriteLine("\nEnter the first name");
            firstName = Console.ReadLine();

            //if first name is invalid then exit
            if (!ValidateFormat(firstName, patternOfFirstName)) return;
            logger.Info("User entered a valid first name");

            //user to input last name
            Console.WriteLine("\nEnter the last name");
            lastName = Console.ReadLine();

            //if last name is invalid then exit
            if (!ValidateFormat(lastName, patternOfLastName)) return;
            logger.Info("User entered a valid last name");

            //user to input email
            Console.WriteLine("\nEnter the Email");
            email = Console.ReadLine();

            //if email is invalid
            if (!ValidateFormat(email,patternOfEmail)) return;
            logger.Info("User entered a valid Email");

            //User to input mobile number
            Console.WriteLine("\nEnter the mobile number");
            mobileNum = Console.ReadLine();

            //if mobile number is invalid
            if (!ValidateFormat(mobileNum, patternOfMobile)) return;
            logger.Info("User entered a valid mobile number");

            //User to input Password
            Console.WriteLine("\nEnter the password");
            password = Console.ReadLine();

            //if password is invalid
            if(!ValidateFormat(password, patternOfPassword)) return;
            logger.Info("User entered a validpassword");
            Console.WriteLine("User Registration Successful");

        }

        /// <summary>
        /// UC 13 : To validate format using lambda expression
        /// </summary>
        public Func<string, string, bool> ValidateFormat = (userEntry, pattern) => Regex.IsMatch(userEntry, pattern)? true: throw new UserEntryException("Invalid Entry");
    }      
}
