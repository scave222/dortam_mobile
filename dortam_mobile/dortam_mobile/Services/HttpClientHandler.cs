using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;

namespace dortam_mobile.Services
{
	public sealed class HttpClientHandler
	{
		private static readonly Lazy<HttpClientHandler> SingleInstance = new Lazy<HttpClientHandler>(() => new HttpClientHandler());

		public HttpClient HttpClient { get; set; }
		public CancellationTokenSource CancellationToken { get; set; }
		public static HttpClientHandler Instance => SingleInstance.Value;

		private HttpClientHandler()
		{
			CancellationToken = new CancellationTokenSource(40000);
			HttpClient = new HttpClient();

		}
	}
}
