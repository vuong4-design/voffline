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
		GameProcessInteractionHelper.smethod_52(accountConfig, "Xãa Sms...");
		for (int i = 0; i < 10; i++)
		{
			if (ReadMessages(accountConfig) == string.Empty)
			{
				break;
			}
			GameProcessInteractionHelper.smethod_12(accountConfig.int_137, accountConfig.uint_56);
			Thread.Sleep(150);
		}
	}

	public static bool HasMessageContainer(CharacterAccountConfig accountConfig)
	{
		uint messageRoot = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_165.uint_0, accountConfig.int_137);
		uint messageContainer = WindowsInteropHelper.ReadProcessUInt32(messageRoot + GameConfigurationManager.memorySignatureScanConfig_168.uint_0, accountConfig.int_137);
		return messageContainer != 0;
	}

	public static string ReadMessages(CharacterAccountConfig accountConfig, bool includeMessageId = false)
	{
		string messages = string.Empty;
		uint messageRoot = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_165.uint_0, accountConfig.int_137);
		uint messageList = WindowsInteropHelper.ReadProcessUInt32(messageRoot + GameConfigurationManager.memorySignatureScanConfig_167.uint_0, accountConfig.int_137);
		if (messageList == 0)
		{
			return messages;
		}
		for (uint messageIndex = 0u; messageIndex < 10; messageIndex++)
		{
			uint messageAddress = WindowsInteropHelper.ReadProcessUInt32(messageList + messageIndex * 4, accountConfig.int_137);
			if (messageAddress == 0)
			{
				continue;
			}
			string message = WindowsInteropHelper.ReadNullTerminatedUtf7ProcessString(messageAddress, accountConfig.int_137, 78);
			if (message == null || message == string.Empty)
			{
				continue;
			}
			if (includeMessageId)
			{
				int messageId = (int)WindowsInteropHelper.ReadProcessUInt32(messageAddress + GameConfigurationManager.memorySignatureScanConfig_170.uint_0, accountConfig.int_137);
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
