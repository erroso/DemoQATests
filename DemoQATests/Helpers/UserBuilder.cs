using System;
using System.Security.Cryptography;

namespace DemoQATests.Helpers
{
    class UserBuilder
    {
        // The random number provider.
        private readonly static RNGCryptoServiceProvider randomNumber = new RNGCryptoServiceProvider();

        // Return a random integer between a min and max value.
        public static int RandomInteger(int min, int max)
        {
            uint scale = uint.MaxValue;
            while (scale == uint.MaxValue)
            {
                // Get four random bytes.
                byte[] four_bytes = new byte[4];
                randomNumber.GetBytes(four_bytes);

                // Convert that into an uint.
                scale = BitConverter.ToUInt32(four_bytes, 0);
            }

            // Add min to the scaled difference between max and min.
            return (int)(min + (max - min) * (scale / (double)uint.MaxValue));
        }

        public static string RandomChar(string str)
        {
            return str.Substring(RandomInteger(0, str.Length - 1), 1);
        }

        public static string RandomizeString(string str)
        {
            string resultado = "";
            while (str.Length > 0)
            {
                // get a random number
                int i = RandomInteger(0, str.Length - 1);
                resultado += str.Substring(i, 1);
                str = str.Remove(i, 1);
            }
            return resultado;
        }

        public static string GenerateRandomWord(bool password)
        {
            const string LOWERCASE = "abcdefghijklmnopqrstuvwxyz";
            const string UPPERCASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string NUMBERS = "0123456789";
            const string SPECIAL = @"~!@#$%^&*():;[]{}<>,.?/\|";

            // Make a list of allowed characters
            string allowed = LOWERCASE + UPPERCASE;
            if (password)
            {
                allowed += NUMBERS + SPECIAL;
            }
            // Get the number of characters .
            int minimum=5;
            int maximum=5;
            if (password)
            {
                minimum = 8;
                maximum = 15;
            }
            int target = RandomInteger(minimum, maximum);
            // Meeting definitions
            string finalWord = "";
            finalWord += RandomChar(LOWERCASE);
            finalWord += RandomChar(UPPERCASE);
            if (password)
            {
                finalWord += RandomChar(NUMBERS);
                finalWord += RandomChar(SPECIAL);
            }
            // add the remaining random characters
            while (finalWord.Length < target)
                finalWord += RandomChar(allowed);
            // mix the required characters
            finalWord = RandomizeString(finalWord);
            return finalWord;
        }

        public static User getRamdomUser(bool full)
        {
            User user;
            var firstname = GenerateRandomWord(false);
            var lastname = GenerateRandomWord(false);
            if (full)
            {
                user = new User()
                {
                    FirstName = firstname,
                    LastName = lastname,
                    UserName = firstname+" "+ lastname,
                    Password = GenerateRandomWord(true)
                };
            }
            else
            {
                user = new User()
                {
                    UserName = firstname + " " + lastname,
                    Password = GenerateRandomWord(true)
                };
            }

            return user;
        }
    }
}
