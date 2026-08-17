using System;
using System.Collections.Generic;
using System.Net;

namespace ns147;

public class CookieAwareWebClient : WebClient
{
	private class HostCookieStore
	{
		private Dictionary<string, string> cookiesByHost;

		public string this[Uri uri_0]
		{
			get
			{
				if (cookiesByHost.TryGetValue(uri_0.Host, out var value))
				{
					return value;
				}
				return null;
			}
			set
			{
				cookiesByHost[uri_0.Host] = value;
			}
		}

		public HostCookieStore()
		{
			cookiesByHost = new Dictionary<string, string>();
		}
	}

	private HostCookieStore hostCookieStore;

	public CookieAwareWebClient()
	{
		hostCookieStore = new HostCookieStore();
	}

	protected override WebRequest GetWebRequest(Uri address)
	{
		WebRequest webRequest = base.GetWebRequest(address);
		if (webRequest is HttpWebRequest)
		{
			string text = hostCookieStore[address];
			if (text != null)
			{
				((HttpWebRequest)webRequest).Headers.Set("cookie", text);
			}
		}
		return webRequest;
	}

	protected override WebResponse GetWebResponse(WebRequest request, IAsyncResult result)
	{
		WebResponse webResponse = base.GetWebResponse(request, result);
		string[] values = webResponse.Headers.GetValues("Set-Cookie");
		if (values != null && values.Length != 0)
		{
			string text = "";
			string[] array = values;
			string[] array2 = array;
			foreach (string text2 in array2)
			{
				text += text2;
			}
			hostCookieStore[webResponse.ResponseUri] = text;
		}
		return webResponse;
	}

	protected override WebResponse GetWebResponse(WebRequest request)
	{
		WebResponse webResponse = base.GetWebResponse(request);
		string[] values = webResponse.Headers.GetValues("Set-Cookie");
		if (values != null && values.Length != 0)
		{
			string text = "";
			string[] array = values;
			string[] array2 = array;
			foreach (string text2 in array2)
			{
				text += text2;
			}
			hostCookieStore[webResponse.ResponseUri] = text;
		}
		return webResponse;
	}
}
