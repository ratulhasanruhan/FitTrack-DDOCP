using System;
using System.Linq;

namespace FitTrack_DDOCP.Helpers
{
    public static class ValidationHelper
    {
        public static bool IsValidUsername(string username)
        {
            return !string.IsNullOrEmpty(username)
                   && username.All(char.IsLetterOrDigit);
        }

        public static bool IsValidPassword(string password)
        {
            if (password == null || password.Length != 12)
                return false;

            bool hasUpper = password.Any(char.IsUpper);
            bool hasLower = password.Any(char.IsLower);

            return hasUpper && hasLower;
        }
    }
}
