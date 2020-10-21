namespace MSTestForUserRegistration
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using UserRegistration;

    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// When given Valid Password then expect true.
        /// </summary>
        /// <param name="password">password</param>
        /// <param name="pattern">pattern</param>
        [DataRow("Kamal@99", "^(?=.*[A-Z])(?=.*[0-9])(?=.*[^0-9a-zA-Z])(?!.*[^0-9a-zA-Z].*[^0-9a-zA-Z]).{8,}$")]
        [TestMethod]
        public void TestValidPassword(string password, string pattern)
        {
            // Arrange
            UserDetails userDetails = new UserDetails();

            // ACT
            var actual = userDetails.ValidateFormat(password, pattern);

            // Assert
            Assert.AreEqual(true, actual);
        }

        /// <summary>
        /// When given invalid password then catches exception
        /// </summary>
        /// <param name="password">password</param>
        /// <param name="pattern">pattern</param>
        [DataRow("kamal@99", "^(?=.*[A-Z])(?=.*[0-9])(?=.*[^0-9a-zA-Z])(?!.*[^0-9a-zA-Z].*[^0-9a-zA-Z]).{8,}$")]
        [TestMethod]
        public void TestInvalidPassword(string password, string pattern)
        {
            // Arrange
            UserDetails userDetails = new UserDetails();
            try
            {
                // ACT
                var actual = userDetails.ValidateFormat(password, pattern);
            }
            catch (UserEntryException e)
            {
                // Assert
                Assert.AreEqual("Invalid Entry", e.Message);
            }
        }

        /// <summary>
        /// When given Valid name then exect true
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="pattern">The pattern.</param>
        [DataRow("Kamal", "^([A-Z]+)[a-zA-Z]{2,}$")]
        [TestMethod]
        public void TestValidName(string password, string pattern)
        {
            // Arrange
            UserDetails userDetails = new UserDetails();
            
            // ACT
            var actual = userDetails.ValidateFormat(password, pattern);
            
            // Assert
            Assert.AreEqual(true, actual);
        }

        /// <summary>
        /// When given valid name expect true
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pattern"></param>
        [DataRow("kamal", "^([A-Z]+)[a-zA-Z]{2,}$")]
        [TestMethod]
        public void TestInvalidName(string name, string pattern)
        {
            // Arrange
            UserDetails userDetails = new UserDetails();
            try
            {
                // ACT
                var actual = userDetails.ValidateFormat(name, pattern);
            }
            catch (UserEntryException e)
            {
                // Assert
                Assert.AreEqual("Invalid Entry", e.Message);
            }
        }

        /// <summary>
        /// When given invalid email then it catches exception
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="pattern">The pattern.</param>
        [DataRow("Kamal", "^[a-zA-Z0-9]+([.+_-][a-zA-Z0-9]+)*@[a-zA-Z0-9]+[.][a-zA-Z]+([.][a-zA-Z]{2})?$")]
        [TestMethod]
        public void TestInvalidEmail(string email, string pattern)
        {
            // Arrange
            UserDetails userDetails = new UserDetails();
            try
            {
                // ACT
                var actual = userDetails.ValidateFormat(email, pattern);
            }
            catch (UserEntryException e)
            {
                // Assert
                Assert.AreEqual("Invalid Entry", e.Message);
            }
        }

        /// <summary>
        /// When given valid email then expect true
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="pattern">The pattern.</param>
        [DataRow("Kamal.abc@xyz.co", "^[a-zA-Z0-9]+([.+_-][a-zA-Z0-9]+)*@[a-zA-Z0-9]+[.][a-zA-Z]+([.][a-zA-Z]{2})?$")]
        [DataRow("kamalakars04@gmail.com", "^[a-zA-Z0-9]+([.+_-][a-zA-Z0-9]+)*@[a-zA-Z0-9]+[.][a-zA-Z]+([.][a-zA-Z]{2})?$")]
        [TestMethod]
        public void TestValidEmail(string email, string pattern)
        {
            // Arrange
            UserDetails userDetails = new UserDetails();

            // ACT
            var actual = userDetails.ValidateFormat(email, pattern);
            
            // Assert
            Assert.AreEqual(true, actual);
        }

        /// <summary>
        /// When given invalid Phone Number then catches exception
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="pattern">The pattern.</param>
        [DataRow("91 8971478956", "^[0-9]{2}[ ][0-9]{10}$")]
        [TestMethod]
        public void TestValidPhoneNumber(string phoneNumber, string pattern)
        {
            // Arrange
            UserDetails userDetails = new UserDetails();
            
            // ACT
            var actual = userDetails.ValidateFormat(phoneNumber, pattern);
            
            // Assert
            Assert.AreEqual(true, actual);
        }

        /// <summary>
        /// When given valid Phone number then expext true
        /// </summary>
        /// <param name="phoneNum">The phoneNum</param>
        /// <param name="pattern">The Pattern</param>
        [DataRow("91 895678965", "^[0-9]{2}[ ][0-9]{10}$")]
        [TestMethod]
        public void TestInvalidPhoneNumber(string phoneNum, string pattern)
        {
            // Arrange
            UserDetails userDetails = new UserDetails();
            try
            {
                // ACT
                var actual = userDetails.ValidateFormat(phoneNum, pattern);
            }
            catch (UserEntryException e)
            {
                // Assert
                Assert.AreEqual("Invalid Entry", e.Message);
            }
        }
    }
}
