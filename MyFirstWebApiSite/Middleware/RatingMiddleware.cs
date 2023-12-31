using Entities;
using Service;

namespace MyFirstWebApiSite.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RatingMiddleware
    {
        private readonly RequestDelegate _next;
        //private readonly ILogger<ErrorHandlingMiddleware> _logger;
        private readonly IRaitingService raitingService;
        public RatingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IRaitingService ratingService)
        {
           // try
            //{
                Rating rating = new()
                {
                    Host = httpContext.Request.Host.Value,
                    Method = httpContext.Request.Method,
                    Path = httpContext.Request.Path,
                    Referer = httpContext.Request.Headers.Referer,
                    UserAgent = httpContext.Request.Headers.UserAgent,
                    RecordDate = DateTime.Now
                };
                await ratingService.addRatingAsync(rating);
                await _next(httpContext);
            //}
           // catch (Exception e)
            //{
                //throw (e);
            //}

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RatingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRatingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RatingMiddleware>();
        }
    }
}

/*•	HOST - כתובת האתר בה אנו גולשים כעת
•	METHOD - המתודה אליה נגשנו)
•	[PATH] URL ה-אליו בוצעה הפניה
•	REFERER - הדף ממנו התבצעה הפניה
•	USER_AGENT - מכיל את שם הדפדפן, גירסתו, מערכת ההפעלה ושפתה
•	RECORD_DATE - תאריך הרישום לרייטינג*/
