using BrowserNET;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zad6.Middlewares
{
    public class BrowserFilter
    {
        private RequestDelegate _next;
        public BrowserFilter(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var parser = new UserAgentParser(context.Request.Headers["User-Agent"]);
            parser.Determine();

            var browserName = parser.BrowserName;

            var forbiddenBrowsers = new List<string> { "Edge", "Internet Explorer", "EdgeChromium" };

            if (forbiddenBrowsers.Any(browserName.Contains))
                await context.Response.WriteAsync("Przeglądarka nie jest obsługiwana");
            else
                await _next(context);
        }
    }
}
