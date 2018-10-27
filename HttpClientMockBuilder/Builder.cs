namespace HttpClientMock
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;
    using Moq;
    using Moq.Protected;

    /// <summary>
    /// Builds a new mock of HttpClient.
    /// </summary>
    public sealed class Builder
        : IHttpClientMockBuilder, IResponseConfigurable, IResponseHeaderConfigurable
    {
        private string BaseUrl;
        private HttpResponseMessage ResponseMessage;

        private Builder(string baseUrl)
        {
            this.BaseUrl = baseUrl;
        }

        /// inheritdoc
        public HttpClient Get()
        {
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(this.ResponseMessage)
                .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri(this.BaseUrl),
            };

            return httpClient;
        }

        /// inheritdoc
        public static IResponseConfigurable WithBaseUrl(string baseUrl) => new Builder(baseUrl);

        /// inheritdoc
        public IResponseHeaderConfigurable WithResponse(HttpStatusCode status, string responseBody)
        {
            this.ResponseMessage = new HttpResponseMessage()
            {
                StatusCode = status,
                Content = new StringContent(responseBody),
            };

            return this;
        }

        /// inheritdoc
        public IHttpClientMockBuilder WithContentType(string contentType)
        {
            this.ResponseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue(contentType);
            return this;
        }

        /// inheritdoc
        public IHttpClientMockBuilder WithResponseHeader(string name, string value)
        {
            this.ResponseMessage.Content.Headers.Add(name, value);
            return this;
        }
    }
}
