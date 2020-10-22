
namespace Healthcare_System.Model
{
    public enum Gender
    {
        M,
        F
    }

    public class GenderHelper
    {
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
