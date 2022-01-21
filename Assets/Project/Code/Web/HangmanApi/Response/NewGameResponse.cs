using System.Diagnostics.CodeAnalysis;

namespace Code.Web.HangmanApi.Response
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class NewGameResponse : Web.Response
    {
        public string hangman;
        public string token;
    }
}