using System.Diagnostics.CodeAnalysis;

namespace Code.Web.HangmanApi.Request
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class GuessLetterRequest : Web.Request
    {
        public string token;
        public string letter;
    }
}