using System.Diagnostics.CodeAnalysis;

namespace Code.Web.HangmanApi.Request
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class GetSolutionRequest : Web.Request
    {
        public string token;
    }
}