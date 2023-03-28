using System.Text.RegularExpressions;

namespace MockData.Helpers
{
    public class GeneralHelpers
    {
        static int count = 0;
        //Oliwier Nowak
        public string GenerateEmail(string name)
        {
            var split = name.Split(' ');
            var email = split[0] +"@"+ split[1]+".at";

            return Regex.IsMatch(email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$") ? email : $"aa{count}@gmail.com";
      
        }
    }
}
