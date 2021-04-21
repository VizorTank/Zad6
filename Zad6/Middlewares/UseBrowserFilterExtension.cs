using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zad6.Middlewares
{
    public static class UseBrowserFilterExtension
    {
        public static IApplicationBuilder UseBrowserFilter(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BrowserFilter>();
        }
    }
}
