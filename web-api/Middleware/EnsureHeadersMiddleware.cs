namespace web_api.Middleware;

public class EnsureHeadersMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<EnsureHeadersMiddleware> _logger;

    public EnsureHeadersMiddleware(RequestDelegate next, ILogger<EnsureHeadersMiddleware> logger)
    {
        _next = next;
	_logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
	var acceptHeader = context.Request.Headers["Accept"];
	var contentHeader = context.Request.Headers["Content-Type"];

	_logger.LogInformation($"Accept header: {acceptHeader}; Content-Type header: {contentHeader}");

	if(!acceptHeader.Equals("application/json") && !acceptHeader.Equals("application/xml")) 
	{
	    _logger.LogInformation("Return early with code 406");
	    context.Response.StatusCode = 406;
	    return;
	} 

	if(!contentHeader.Equals("application/json") && !contentHeader.Equals("application/xml")) {
	    _logger.LogInformation("return early with code 415");
	    context.Response.StatusCode = 415;
	    return;
	}

	await _next(context);
    }
}

public static class EnsureHeadersMiddlewareExtension {
    public static IApplicationBuilder UseEnsureHeaders(this IApplicationBuilder builder) 
    {
	return builder.UseMiddleware<EnsureHeadersMiddleware>();
    }
}
