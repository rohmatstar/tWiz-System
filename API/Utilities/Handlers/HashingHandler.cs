namespace API.Utilities.Handlers
{
    public class HashingHandler
    {
        private static string GenerateSalt()
        {
            return BCrypt.Net.BCrypt.GenerateSalt(12); // 12 is the default
        }

        public static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, GenerateSalt());
        }

        public static bool ValidatePassword(string password, string hashPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashPassword);
        }
    }
}
