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
			string server = Class11.smethod_72(TimeServer);
			string timeText = string.Empty;
			string dateSeparator = Class11.smethod_54(Class11.string_5);
			string timeSeparator = Class11.smethod_54(Class11.string_7);
			string alternateDateSeparator = Class11.smethod_54(Class11.string_2);
			string alternateTimeSeparator = Class11.smethod_54(Class11.string_4);
			if (server[0] != timeSeparator[0])
			{
				TcpClient tcpClient = new TcpClient(server, 13);
				StreamReader streamReader = new StreamReader(tcpClient.GetStream());
				string response = streamReader.ReadToEnd();
				tcpClient.Close();
				if (response.Length > 24)
				{
					timeText = ((Class11.smethod_1(response.ToUpper(), Class11.smethod_0(Class11.char_28)) <= 0) ? Convert.ToDateTime(response.Substring(0, 20)).ToString(Class11.smethod_0(Class11.char_29)) : response.Substring(7, 17));
				}
			}
			else
			{
				WebClient webClient = new WebClient();
				byte[] responseBytes = webClient.DownloadData(Class11.smethod_0(Class11.char_13) + server.Substring(1));
				string responseText = Encoding.Default.GetString(responseBytes, 0, responseBytes.Length);
				string timeSection = responseText.Substring(Class11.smethod_1(responseText, Class11.smethod_0(Class11.char_14)) + 12);
				string compactTime = timeSection.Substring(0, Class11.smethod_1(timeSection, "<")).Replace(" ", "");
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
				DateTime networkTime = DateTime.ParseExact(timeText, Class11.smethod_0(Class11.char_29), cultureInfo, DateTimeStyles.AssumeUniversal);
				if (GClass1.long_1 < networkTime.Ticks)
				{
					GClass1.long_1 = networkTime.Ticks;
				}
			}
		}
		catch
		{
		}
	}
}
