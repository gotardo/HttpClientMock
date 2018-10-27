# HttpClientMockBuilder

A small library that makes easier to configure a mock for System.Net.Http.HttpClient.


## How to build the mock

To build the mock you only need to configure it with the `Builder` class:

```c#
var mock = HttpClientMock.Builder
  .WithBaseUrl("http://baseurl.com")
  .WithResponse(HttpStatusCode.OK, "{\"some\":\"json\"")
  .WithContentType("application/json")
  .WithResponseHeader("header", "value")
  .Get();

var sut = new MyClass(mock);
```
