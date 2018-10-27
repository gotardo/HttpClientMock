namespace HttpClientMock
{
    using System.Net;

    /// <summary>
    /// Allows to configure the response of an instance of the HttpClient mock.
    /// </summary>
    public interface IResponseConfigurable
    {
        /// <summary>
        /// Configure the mock's reponse with the status and the body.
        /// </summary>
        /// <returns>A builder to configure the response headers.</returns>
        /// <param name="status">Http Status.</param>
        /// <param name="responseBody">Response body.</param>
        IResponseHeaderConfigurable WithResponse(HttpStatusCode status, string responseBody);
    }
}
