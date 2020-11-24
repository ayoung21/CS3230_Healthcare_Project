
namespace Healthcare_System.Model
{
    /// <summary>
    /// Contains valid values for gender
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// Male
        /// </summary>
        M,
        /// <summary>
        /// Female
        /// </summary>
        F
    }

    /// <summary>
    /// Contains helpers for determining gender
    /// </summary>
    public class GenderHelper
    {
        /// <summary>
        /// Converts the gender string to enum
        /// </summary>
        /// <param name="gender">The gender string to convert.</param>
        /// <returns>The enum for the gender string</returns>
        public static Gender? GenderStringToEnum(string gender)
        {
            if (gender.ToUpper().Trim() == "M")
            {
                return Gender.M;
            } else if (gender.ToUpper().Trim() == "F")
            {
                return Gender.F;
            } else
            {
                return null;
            }
        }
    }
}
