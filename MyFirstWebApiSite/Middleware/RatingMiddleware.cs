using Entities;
using Service;

namespace MyFirstWebApiSite.Middleware
{
    public class RatingMiddleware
    {
        private readonly RequestDelegate _next;
        public RatingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IRaitingService ratingService)
        {
            Rating rating = new()
            {
                Host = httpContext.Request.Host.Value,
                Method = httpContext.Request.Method,
                Path = httpContext.Request.Path,
                Referer = httpContext.Request.Headers.Referer,
                UserAgent = httpContext.Request.Headers.UserAgent,
                RecordDate = DateTime.Now
            };
            await ratingService.addRating(rating);
            await _next(httpContext);
        }

        public static class RatingMiddlewareExtensions
        {
            public static IApplicationBuilder UseRatingMiddleware(this IApplicationBuilder builder)
            {
                return builder.UseMiddleware<RatingMiddleware>();
            }
        }
    }
}


/*•	HOST - כתובת האתר בה אנו גולשים כעת
•	METHOD - המתודה אליה נגשנו)
•	[PATH] URL ה-אליו בוצעה הפניה
•	REFERER - הדף ממנו התבצעה הפניה
•	USER_AGENT - מכיל את שם הדפדפן, גירסתו, מערכת ההפעלה ושפתה
•	RECORD_DATE - תאריך הרישום לרייטינג*/
