using System;
using System.IO;
using System.Net;
using System.Threading;
using ns11;
using ns146;
using ns53;

namespace ns25;

internal class AdvertisementAssetLoader
{
	public static string[] SourceEntries = null;

	public static GStruct14[] Advertisements = null;

	public static void LoadWithRetries()
	{
		int retryCount = 0;
		while (true)
		{
			try
			{
				ParseAndDownload();
				break;
			}
			catch
			{
				Thread.Sleep(300);
				retryCount++;
				if (retryCount < 3)
				{
					continue;
				}
				break;
			}
		}
	}

	public static void ParseAndDownload()
	{
		if (SourceEntries == null || SourceEntries.Length == 0)
		{
			return;
		}
		int advertisementCount = 0;
		GStruct14[] parsedAdvertisements = new GStruct14[SourceEntries.Length];
		for (int i = 0; i < SourceEntries.Length; i++)
		{
			string sourceEntry = SourceEntries[i];
			if (sourceEntry == null || sourceEntry == string.Empty)
			{
				continue;
			}
			string[] fields = sourceEntry.Split('|');
			if (fields[0] == string.Empty || fields[0] == null)
			{
				continue;
			}
			parsedAdvertisements[advertisementCount].string_1 = fields[0];
			parsedAdvertisements[advertisementCount].string_2 = null;
			parsedAdvertisements[advertisementCount].int_1 = 30000;
			if (fields.Length > 1)
			{
				parsedAdvertisements[advertisementCount].string_2 = fields[1];
			}
			if (fields.Length > 2 && fields[2] != null && fields[2] != string.Empty)
			{
				string[] dateParts = fields[2].Split('.', '/', '-');
				if (dateParts.Length == 3)
				{
					int day = Class11.smethod_11(dateParts[0]);
					int month = Class11.smethod_11(dateParts[1]);
					int year = Class11.smethod_11(dateParts[2]);
					if (0 < day && day <= 31 && 0 < month && month <= 12 && year > 0)
					{
						long expirationTicks = new DateTime(year, month, day, 12, 30, 0, 0).Ticks;
						parsedAdvertisements[advertisementCount].long_0 = expirationTicks;
						parsedAdvertisements[advertisementCount].bool_0 = GClass1.long_1 > expirationTicks;
					}
					parsedAdvertisements[advertisementCount].string_3 = fields[2];
				}
			}
			if (fields.Length > 3 && fields[3] != null && fields[3] != string.Empty)
			{
				int displayDuration = Class11.smethod_11(fields[3]);
				if (displayDuration > 0)
				{
					parsedAdvertisements[advertisementCount].int_1 = displayDuration;
				}
			}
			parsedAdvertisements[advertisementCount].int_0 = Class11.smethod_11(parsedAdvertisements[advertisementCount].string_2);
			if (parsedAdvertisements[advertisementCount].int_0 <= 0)
			{
				parsedAdvertisements[advertisementCount].string_0 = DownloadToTempFile(parsedAdvertisements[advertisementCount].string_1);
				if (parsedAdvertisements[advertisementCount].string_0 == null)
				{
					continue;
				}
			}
			advertisementCount++;
		}
		if (advertisementCount > 0)
		{
			Advertisements = new GStruct14[advertisementCount];
			for (int j = 0; j < advertisementCount; j++)
			{
				Advertisements[j].string_0 = parsedAdvertisements[j].string_0;
				Advertisements[j].string_1 = parsedAdvertisements[j].string_1;
				Advertisements[j].string_2 = parsedAdvertisements[j].string_2;
				Advertisements[j].long_0 = parsedAdvertisements[j].long_0;
				Advertisements[j].int_0 = parsedAdvertisements[j].int_0;
				Advertisements[j].bool_0 = parsedAdvertisements[j].bool_0;
				Advertisements[j].string_3 = parsedAdvertisements[j].string_3;
				Advertisements[j].int_1 = parsedAdvertisements[j].int_1;
			}
		}
	}

	private static byte[] DownloadWithHttpRequest(string url, int timeout = 15000)
	{
		try
		{
			Uri requestUri = new Uri(url);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUri);
			httpWebRequest.Timeout = timeout;
			httpWebRequest.ReadWriteTimeout = timeout;
			HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			MemoryStream memoryStream = new MemoryStream();
			httpWebResponse.GetResponseStream().CopyTo(memoryStream);
			return memoryStream.ToArray();
		}
		catch
		{
		}
		return null;
	}

	private static byte[] DownloadWithWebClient(string url)
	{
		try
		{
			WebClient webClient = new WebClient();
			Uri address = new Uri(url);
			byte[] result = webClient.DownloadData(address);
			webClient.CancelAsync();
			return result;
		}
		catch
		{
		}
		return null;
	}

	private static string DownloadToTempFile(string url)
	{
		string downloadedPath = null;
		try
		{
			byte[] data = DownloadWithHttpRequest(url);
			if (data == null || data.Length == 0)
			{
				data = DownloadWithWebClient(url);
			}
			if (data != null && data.Length != 0)
			{
				string tempDirectory = Path.GetTempPath();
				if (tempDirectory == null)
				{
					tempDirectory = GameConfigurationManager.string_10;
				}
				while (tempDirectory != null && tempDirectory != string.Empty && (tempDirectory[tempDirectory.Length - 1] == '\\' || tempDirectory[tempDirectory.Length - 1] == '/'))
				{
					tempDirectory = tempDirectory.Substring(0, tempDirectory.Length - 1);
				}
				string[] pathParts = url.Split('/', '\\');
				downloadedPath = tempDirectory + "\\" + pathParts[pathParts.Length - 1];
				Class11.smethod_51(downloadedPath, data);
			}
		}
		catch
		{
		}
		return downloadedPath;
	}
}
