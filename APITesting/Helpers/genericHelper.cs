using System.Text.RegularExpressions;

namespace APITesting.Helpers
{
    public class GenericHelper
    {

        public static string responseSpaceConverter(string postCode)
        {
           
             return Regex.Replace(postCode, ".{4}", " $0");
        }
        public static string stringSpaceConveter(string postCode)
        {
            return Regex.Replace(postCode, ".{4}", "$0 ");
        }

    }
}
