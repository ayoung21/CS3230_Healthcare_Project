
namespace Healthcare_System.Model
{
    public enum Gender
    {
        MALE,
        FEMALE
    }

    public class GenderHelper
    {
        public static Gender? GenderStringToEnum(string gender)
        {
            if (gender.ToUpper().Trim() == "MALE")
            {
                return Gender.MALE;
            } else if (gender.ToUpper().Trim() == "FEMALE")
            {
                return Gender.FEMALE;
            } else
            {
                return null;
            }
        }
    }
}
