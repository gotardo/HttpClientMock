namespace HttpClientMock
{
    /// <summary>
    /// Response header configurable.
    /// </summary>
    public interface IResponseHeaderConfigurable : IHttpClientMockBuilder
    {
        /// <summary>
        /// Sets the content type on the response headers.
        /// </summary>
        /// <returns>A builder ready to get the mock.</returns>
        /// <param name="contentType">Content type.</param>
        IResponseHeaderConfigurable WithContentType(string contentType);

        /// <summary>
        /// Sets a header on the response.
        /// </summary>
        /// <returns>A builder ready to get the mock.</returns>
        /// <param name="name">Header Name.</param>
        /// <param name="value">Header Value.</param>
        IResponseHeaderConfigurable WithResponseHeader(string name, string value);
    }
}
