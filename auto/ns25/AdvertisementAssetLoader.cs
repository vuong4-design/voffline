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

	public static AdvertisementMetadata[] Advertisements = null;

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
		AdvertisementMetadata[] parsedAdvertisements = new AdvertisementMetadata[SourceEntries.Length];
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
			parsedAdvertisements[advertisementCount].sourceUrl = fields[0];
			parsedAdvertisements[advertisementCount].contentPayload = null;
			parsedAdvertisements[advertisementCount].displayDurationMilliseconds = 30000;
			if (fields.Length > 1)
			{
				parsedAdvertisements[advertisementCount].contentPayload = fields[1];
			}
			if (fields.Length > 2 && fields[2] != null && fields[2] != string.Empty)
			{
				string[] dateParts = fields[2].Split('.', '/', '-');
				if (dateParts.Length == 3)
				{
					int day = CommonUtility.ParseInt32OrZero(dateParts[0]);
					int month = CommonUtility.ParseInt32OrZero(dateParts[1]);
					int year = CommonUtility.ParseInt32OrZero(dateParts[2]);
					if (0 < day && day <= 31 && 0 < month && month <= 12 && year > 0)
					{
						long expirationTicks = new DateTime(year, month, day, 12, 30, 0, 0).Ticks;
						parsedAdvertisements[advertisementCount].expirationTicks = expirationTicks;
						parsedAdvertisements[advertisementCount].isExpired = GClass1.networkTimeTicks > expirationTicks;
					}
					parsedAdvertisements[advertisementCount].expirationDateText = fields[2];
				}
			}
			if (fields.Length > 3 && fields[3] != null && fields[3] != string.Empty)
			{
				int displayDuration = CommonUtility.ParseInt32OrZero(fields[3]);
				if (displayDuration > 0)
				{
					parsedAdvertisements[advertisementCount].displayDurationMilliseconds = displayDuration;
				}
			}
			parsedAdvertisements[advertisementCount].displayModeCode = CommonUtility.ParseInt32OrZero(parsedAdvertisements[advertisementCount].contentPayload);
			if (parsedAdvertisements[advertisementCount].displayModeCode <= 0)
			{
				parsedAdvertisements[advertisementCount].localImagePath = DownloadToTempFile(parsedAdvertisements[advertisementCount].sourceUrl);
				if (parsedAdvertisements[advertisementCount].localImagePath == null)
				{
					continue;
				}
			}
			advertisementCount++;
		}
		if (advertisementCount > 0)
		{
			Advertisements = new AdvertisementMetadata[advertisementCount];
			for (int j = 0; j < advertisementCount; j++)
			{
				Advertisements[j].localImagePath = parsedAdvertisements[j].localImagePath;
				Advertisements[j].sourceUrl = parsedAdvertisements[j].sourceUrl;
				Advertisements[j].contentPayload = parsedAdvertisements[j].contentPayload;
				Advertisements[j].expirationTicks = parsedAdvertisements[j].expirationTicks;
				Advertisements[j].displayModeCode = parsedAdvertisements[j].displayModeCode;
				Advertisements[j].isExpired = parsedAdvertisements[j].isExpired;
				Advertisements[j].expirationDateText = parsedAdvertisements[j].expirationDateText;
				Advertisements[j].displayDurationMilliseconds = parsedAdvertisements[j].displayDurationMilliseconds;
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
					tempDirectory = GameConfigurationManager.allUserConfigDirectory;
				}
				while (tempDirectory != null && tempDirectory != string.Empty && (tempDirectory[tempDirectory.Length - 1] == '\\' || tempDirectory[tempDirectory.Length - 1] == '/'))
				{
					tempDirectory = tempDirectory.Substring(0, tempDirectory.Length - 1);
				}
				string[] pathParts = url.Split('/', '\\');
				downloadedPath = tempDirectory + "\\" + pathParts[pathParts.Length - 1];
				CommonUtility.WriteAllBytesSafe(downloadedPath, data);
			}
		}
		catch
		{
		}
		return downloadedPath;
	}
}
