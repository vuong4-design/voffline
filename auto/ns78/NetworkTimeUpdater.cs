using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using ns11;
using ns146;

namespace ns78;

internal class NetworkTimeUpdater
{
	public string TimeServer = null;

	public void Update()
	{
		try
		{
			string server = CommonUtility.DecompressBase64DeflateUtf8(TimeServer);
			string timeText = string.Empty;
			string dateSeparator = CommonUtility.DecodeLengthShiftedString(CommonUtility.string_5);
			string timeSeparator = CommonUtility.DecodeLengthShiftedString(CommonUtility.string_7);
			string alternateDateSeparator = CommonUtility.DecodeLengthShiftedString(CommonUtility.string_2);
			string alternateTimeSeparator = CommonUtility.DecodeLengthShiftedString(CommonUtility.string_4);
			if (server[0] != timeSeparator[0])
			{
				TcpClient tcpClient = new TcpClient(server, 13);
				StreamReader streamReader = new StreamReader(tcpClient.GetStream());
				string response = streamReader.ReadToEnd();
				tcpClient.Close();
				if (response.Length > 24)
				{
					timeText = ((CommonUtility.FindSubstringIndex(response.ToUpper(), CommonUtility.DecodeCharArrayToString(CommonUtility.char_28)) <= 0) ? Convert.ToDateTime(response.Substring(0, 20)).ToString(CommonUtility.DecodeCharArrayToString(CommonUtility.char_29)) : response.Substring(7, 17));
				}
			}
			else
			{
				WebClient webClient = new WebClient();
				byte[] responseBytes = webClient.DownloadData(CommonUtility.DecodeCharArrayToString(CommonUtility.char_13) + server.Substring(1));
				string responseText = Encoding.Default.GetString(responseBytes, 0, responseBytes.Length);
				string timeSection = responseText.Substring(CommonUtility.FindSubstringIndex(responseText, CommonUtility.DecodeCharArrayToString(CommonUtility.char_14)) + 12);
				string compactTime = timeSection.Substring(0, CommonUtility.FindSubstringIndex(timeSection, "<")).Replace(" ", "");
				string[] timeParts = compactTime.Split(alternateTimeSeparator[0], alternateDateSeparator[0], timeSeparator[0], dateSeparator[0]);
				if (timeParts.Length == 6)
				{
					if (timeParts[2].Length > 2)
					{
						int length = timeParts[2].Length;
						timeParts[2] = timeParts[2].Substring(length - 2);
					}
					timeText = timeParts[2] + dateSeparator + timeParts[1] + dateSeparator + timeParts[0] + " " + timeParts[3] + timeSeparator + timeParts[4] + timeSeparator + timeParts[5];
				}
				webClient.CancelAsync();
			}
			if (timeText != null && timeText != string.Empty)
			{
				CultureInfo cultureInfo = new CultureInfo(CultureInfo.CurrentCulture.Name);
				cultureInfo.Calendar.TwoDigitYearMax = 2099;
				DateTime networkTime = DateTime.ParseExact(timeText, CommonUtility.DecodeCharArrayToString(CommonUtility.char_29), cultureInfo, DateTimeStyles.AssumeUniversal);
				if (GClass1.networkTimeTicks < networkTime.Ticks)
				{
					GClass1.networkTimeTicks = networkTime.Ticks;
				}
			}
		}
		catch
		{
		}
	}
}
