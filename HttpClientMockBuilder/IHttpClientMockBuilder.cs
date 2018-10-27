namespace HttpClientMock
{
    using System.Net.Http;

    /// <summary>
    /// Allows to get an instance of the HttpClient mock.
    /// </summary>
    public interface IHttpClientMockBuilder
    {
        /// <summary>
        /// Get the instance of the HttpClient mock.
        /// </summary>
        /// <returns>The mock.</returns>
        HttpClient Get();
    }
}
