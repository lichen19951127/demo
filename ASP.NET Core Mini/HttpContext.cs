using System;

public class HttpContext
{
    public HttpRequest Request { get; }
    public HttpResponse Response { get; }
}
public class HttpRequest
{
    public Uri Url { get; }
    public NameValueCollection Headers { get; }
    public Stream Body { get; }
}
public class HttpResponse
{
    public NameValueCollection Headers { get; }
    public Stream Body { get; }
    public int StatusCode { get; set; }
}
