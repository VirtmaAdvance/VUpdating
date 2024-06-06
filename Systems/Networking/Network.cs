using System.Net.NetworkInformation;
using VUpdating.Systems.Extensions.Strings;

namespace VUpdating.Systems.Networking
{
	internal class Network
	{

		public static bool IsOnline => NetworkInterface.GetIsNetworkAvailable();


		public Network()
		{

		}

		public static async Task<bool> Download(string url, string destinationPath)
		{
			var data=await SendAsync(url);
			if (data is not null)
			{
				destinationPath.Write(data);
				return true;
			}
			return false;
		}

		public static async Task<byte[]> SendAsync(string url, HttpMethod? method = null)
		{
			method ??= HttpMethod.Get;
			if (IsOnline)
			{
				var uri = new Uri(url);
				HttpClient client = new()
				{
					BaseAddress = uri
				};
				var res = await client.SendAsync(new HttpRequestMessage(method, uri));
				return res.IsSuccessStatusCode ? await res.Content.ReadAsByteArrayAsync() : [];
			}
			return [];
		}

		public static bool IsReachable(string url)
		{
			if (IsOnline)
			{
				var uri = new Uri(url);
				_ = new HttpClient
				{
					BaseAddress = uri
				};
				var ins = new Ping().Send(uri.AbsoluteUri, 3000);
				return ins.Status != IPStatus.DestinationUnreachable;
			}
			return false;
		}

	}
}
