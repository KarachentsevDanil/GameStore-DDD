namespace GSP.Template.Wizard.Extensions
{
    public static class StringExtensions
    {
        public static string ToLowerTitleCase(this string inputString)
        {
            return !string.IsNullOrWhiteSpace(inputString) && char.IsUpper(inputString[0])
                ? char.ToLower(inputString[0]) + inputString.Substring(1)
                : inputString;
        }
    }
}