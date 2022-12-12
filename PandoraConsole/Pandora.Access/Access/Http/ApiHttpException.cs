namespace Pandora.Access.Access.Http;

internal class ApiHttpException : Exception
{
    public int ResultStatusCode { get; }

    public ApiHttpException(int resultStatusCode, string readAsStringAsync) : base(readAsStringAsync)
    {
        ResultStatusCode = resultStatusCode;
    }
}