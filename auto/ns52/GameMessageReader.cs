using System.Threading;
using ns23;
using ns53;
using ns71;

namespace ns52;

internal class GameMessageReader
{
	private static string[] interactionKeywords = new string[2] { "mêi tæ ®éi", "giao dÞch" };

	public static void ClearMessages(CharacterAccountConfig accountConfig)
	{
		Class75.smethod_52(accountConfig, "Xãa Sms...");
		for (int i = 0; i < 10; i++)
		{
			if (ReadMessages(accountConfig) == string.Empty)
			{
				break;
			}
			Class75.smethod_12(accountConfig.int_137, accountConfig.uint_56);
			Thread.Sleep(150);
		}
	}

	public static bool HasMessageContainer(CharacterAccountConfig accountConfig)
	{
		uint messageRoot = Class24.smethod_30(Class56.memorySignatureScanConfig_165.uint_0, accountConfig.int_137);
		uint messageContainer = Class24.smethod_30(messageRoot + Class56.memorySignatureScanConfig_168.uint_0, accountConfig.int_137);
		return messageContainer != 0;
	}

	public static string ReadMessages(CharacterAccountConfig accountConfig, bool includeMessageId = false)
	{
		string messages = string.Empty;
		uint messageRoot = Class24.smethod_30(Class56.memorySignatureScanConfig_165.uint_0, accountConfig.int_137);
		uint messageList = Class24.smethod_30(messageRoot + Class56.memorySignatureScanConfig_167.uint_0, accountConfig.int_137);
		if (messageList == 0)
		{
			return messages;
		}
		for (uint messageIndex = 0u; messageIndex < 10; messageIndex++)
		{
			uint messageAddress = Class24.smethod_30(messageList + messageIndex * 4, accountConfig.int_137);
			if (messageAddress == 0)
			{
				continue;
			}
			string message = Class24.smethod_28(messageAddress, accountConfig.int_137, 78);
			if (message == null || message == string.Empty)
			{
				continue;
			}
			if (includeMessageId)
			{
				int messageId = (int)Class24.smethod_30(messageAddress + Class56.memorySignatureScanConfig_170.uint_0, accountConfig.int_137);
				if (messageId <= 0)
				{
					continue;
				}
				message = messageId + ";" + message;
			}
			if (messages != string.Empty)
			{
				messages += "|";
			}
			messages += message;
		}
		return messages;
	}
}
