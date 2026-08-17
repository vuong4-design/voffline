using System.IO;
using System.Net;
using ns147;

namespace ns69;

internal class FileDownloader
{
	public static FileInfo Download(string url, string destinationPath)
	{
		string googleDriveHost = "drive.google.com";
		string googleDriveBaseUrl = "https://drive.google.com";
		if (!url.StartsWith(googleDriveHost) && !url.StartsWith(googleDriveBaseUrl))
		{
			return DownloadFile(url, destinationPath, null);
		}
		return DownloadGoogleDriveFile(url, destinationPath);
	}

	private static FileInfo DownloadFile(string url, string destinationPath, WebClient webClient)
	{
		try
		{
			if (webClient == null)
			{
				using (webClient = new WebClient())
				{
					webClient.DownloadFile(url, destinationPath);
					return new FileInfo(destinationPath);
				}
			}
			webClient.DownloadFile(url, destinationPath);
			return new FileInfo(destinationPath);
		}
		catch (WebException)
		{
			return null;
		}
	}

	private static FileInfo DownloadGoogleDriveFile(string url, string destinationPath)
	{
		url = NormalizeGoogleDriveUrl(url);
		using CookieAwareWebClient webClient = new CookieAwareWebClient();
		for (int i = 0; i < 2; i++)
		{
			FileInfo downloadedFile = DownloadFile(url, destinationPath, webClient);
			if (downloadedFile != null)
			{
				if (downloadedFile.Length <= 60000L)
				{
					string responseRemainder;
					using (StreamReader streamReader = downloadedFile.OpenText())
					{
						char[] prefix = new char[20];
						int prefixLength = streamReader.ReadBlock(prefix, 0, 20);
						if (prefixLength < 20 || !new string(prefix).Contains("<!DOCTYPE html>"))
						{
							return downloadedFile;
						}
						responseRemainder = streamReader.ReadToEnd();
					}
					int confirmationLinkStart = responseRemainder.LastIndexOf("href=\"/uc?");
					if (confirmationLinkStart >= 0)
					{
						confirmationLinkStart += 6;
						int confirmationLinkEnd = responseRemainder.IndexOf('"', confirmationLinkStart);
						if (confirmationLinkEnd >= 0)
						{
							url = "https://drive.google.com" + responseRemainder.Substring(confirmationLinkStart, confirmationLinkEnd - confirmationLinkStart).Replace("&amp;", "&");
							continue;
						}
						return downloadedFile;
					}
					return downloadedFile;
				}
				return downloadedFile;
			}
			return null;
		}
		return DownloadFile(url, destinationPath, webClient);
	}

	private static string NormalizeGoogleDriveUrl(string url)
	{
		int idStart = url.IndexOf("id=");
		int idEnd;
		if (idStart > 0)
		{
			idStart += 3;
			idEnd = url.IndexOf('&', idStart);
			if (idEnd < 0)
			{
				idEnd = url.Length;
			}
		}
		else
		{
			idStart = url.IndexOf("file/d/");
			if (idStart < 0)
			{
				return string.Empty;
			}
			idStart += 7;
			idEnd = url.IndexOf('/', idStart);
			if (idEnd < 0)
			{
				idEnd = url.IndexOf('?', idStart);
				if (idEnd < 0)
				{
					idEnd = url.Length;
				}
			}
		}
		return "https://drive.google.com/uc?id=" + url.Substring(idStart, idEnd - idStart) + "&export=download";
	}
}
