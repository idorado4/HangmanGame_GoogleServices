using System.Diagnostics.CodeAnalysis;

namespace Code.Web.HangmanApi.Response
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class GetSolutionResponse : Web.Response
    {
        public string solution;
        public string token;
    }
}