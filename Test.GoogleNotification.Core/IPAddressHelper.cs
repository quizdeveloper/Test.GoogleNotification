using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test.GoogleNotification.Core
{
   public class IPAddressHelper
    {
		public static string GetClientIPAddress(HttpContext context)
		{
			string ip = string.Empty;
			if (!string.IsNullOrEmpty(context.Request.Headers["X-Forwarded-For"]))
			{
				ip = context.Request.Headers["X-Forwarded-For"];
			}
			else
			{
				ip = context.Request.HttpContext.Features.Get<IHttpConnectionFeature>().RemoteIpAddress.ToString();
			}
			return ip;
		}
	}
}
