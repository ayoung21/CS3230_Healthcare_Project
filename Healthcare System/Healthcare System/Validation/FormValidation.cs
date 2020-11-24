namespace Healthcare_System.Validation
{

    /// <summary>
    /// Handles form validation
    /// </summary>
    class FormValidation
    {
        public static bool IsValidUsername(string username)
        {
            return !string.IsNullOrEmpty(username);
        }
    }
}
