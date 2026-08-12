using System;
using System.Net;
using System.Net.Sockets;
using ns100;
using ns109;
using ns11;
using ns121;
using ns146;
using ns19;
using ns34;
using ns43;
using ns56;
using ns63;
using ns71;
using ns74;
using ns75;

namespace ns73;

internal class AuxiliaryMachineSyncCoordinator
{
	public static AuxiliaryMachineServer Server = null;

	public static AuxiliaryMachineClient Client = null;

	public static long long_0 = 0L;

	public static int int_0 = 0;

	public static int ConnectionMode = WindowsRegistryHelper.ReadApplicationRegistryInt32("KieuConnect", 0, "0");

	public static string StatusMessage = null;

	public static int ServerPort = WindowsRegistryHelper.ReadApplicationRegistryInt32("PortServer", 0, "0");

	public static string LocalIpAddress = string.Empty;

	public static int RemotePort = WindowsRegistryHelper.ReadApplicationRegistryInt32("nPort", 0, "0");

	public static string RemoteIpAddress = WindowsRegistryHelper.ReadApplicationRegistryString("ConnectIP", 0);

	private static bool bool_0 = false;

	public static string[] GetLocalIpv4Addresses()
	{
		string[] array = null;
		try
		{
			IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
			if (addressList != null)
			{
				for (int i = 0; i <= addressList.Length; i++)
				{
					if (addressList[i].AddressFamily == AddressFamily.InterNetwork && (!addressList[i].ToString().Contains(":") & !addressList.ToString().Contains("%")))
					{
						if (array == null)
						{
							array = new string[1] { addressList[i].ToString() };
						}
						else
						{
							Array.Resize(ref array, array.Length + 1);
							array[array.Length - 1] = addressList[i].ToString();
						}
					}
				}
			}
		}
		catch
		{
		}
		return array;
	}

	private static string PadLeftWithZeros(string string_3, int int_4 = 2)
	{
		if (string_3 == null)
		{
			string_3 = string.Empty;
		}
		while (string_3.Length < int_4)
		{
			string_3 = "0" + string_3;
		}
		return string_3;
	}

	public static string GetTimestamp()
	{
		DateTime now = DateTime.Now;
		string text = PadLeftWithZeros(now.Hour.ToString());
		string text2 = PadLeftWithZeros(now.Minute.ToString());
		string text3 = PadLeftWithZeros(now.Second.ToString());
		return text + ":" + text2 + ":" + text3;
	}

	private static string GetMessageField(string[] string_3, int int_4, int int_5 = 0)
	{
		if ((int_5 <= 0 || int_5 > int_4) && string_3 != null && string_3.Length > int_4)
		{
			string text = string_3[int_4];
			if (text == null)
			{
				text = string.Empty;
			}
			return string_3[int_4];
		}
		return string.Empty;
	}

	public static void ApplySyncMessage(string string_3)
	{
		Form1.int_11 = 0;
		Form1.int_10 = 1;
		if (GClass1.long_1 != 0L && !AuxiliaryMachineManager.bool_1)
		{
			if (string_3 == null || string_3 == string.Empty)
			{
				return;
			}
			try
			{
				if (string_3[0] == 'U' && string_3[1] == 'P' && string_3[2] == ':')
				{
					string text = string_3.Substring(3);
					int length = text.Length;
					if (length % 2 > 0)
					{
						text = text.Substring(0, length - 1);
					}
					AuxiliaryMachineManager.ApplyCombatTargetSyncPayload(text);
					bool_0 = true;
					return;
				}
				if (bool_0)
				{
					bool_0 = false;
					Form1.bool_17 = true;
				}
				int num;
				int num2;
				while (true)
				{
					num = string_3.IndexOf('@');
					num2 = string_3.IndexOf('*');
					if (num2 >= num)
					{
						break;
					}
					string_3 = string_3.Substring(num);
				}
				if (num < 0 || num2 < 0)
				{
					return;
				}
				string text2 = string_3.Substring(num, num2 + 1);
				string[] array = text2.Split('|');
				int num3 = array.Length;
				if (num3 < 44)
				{
					return;
				}
				if (CharacterStateSyncCoordinator.characterSyncSnapshot_1.uint_4 == null)
				{
					CharacterStateSyncCoordinator.characterSyncSnapshot_1.uint_4 = new uint[2];
				}
				if (CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_11 == null)
				{
					CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_11 = new int[4];
				}
				Form1.int_119 = 0;
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_4 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 1, num3));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_3 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 2, num3));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.uint_4[0] = CommonUtility.ParseUInt32OrZero(GetMessageField(array, 3, num3));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.uint_4[1] = CommonUtility.ParseUInt32OrZero(GetMessageField(array, 4, num3));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_6 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 5, num3));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.uint_3 = CommonUtility.ParseUInt32OrZero(GetMessageField(array, 6, num3));
				Form1.int_121 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 7, num3));
				Form1.int_24 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 8, num3));
				Form1.int_113 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 9, num3));
				Form1.int_115 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 10, num3));
				ChienLongDongNavigationHelper.int_0 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 11, num3));
				Form1.int_26 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 12, num3));
				Form1.int_34 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 13, num3));
				Form1.int_35 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 14, num3));
				Form1.int_36 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 15, num3));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_10 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 16, num3));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_2 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 17, num3));
				Form1.int_28 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 18, num3));
				Form1.int_94 = 1;
				Form1.int_95 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 20, num3));
				FormDame.int_6 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 21, num3));
				FormDame.int_9 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 22, num3));
				FormDame.int_11 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 23, num3));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.uint_5 = CommonUtility.ParseUInt32OrZero(GetMessageField(array, 24, num3));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_7 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 25, num3));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.uint_3 = CommonUtility.ParseUInt32OrZero(GetMessageField(array, 26, num3));
				Form1.int_37 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 27, num3));
				Form1.int_38 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 28, num3));
				Form1.int_25 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 29, num3));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_9 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 30, num3));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.uint_2 = CommonUtility.ParseUInt32OrZero(GetMessageField(array, 31, num3));
				Form1.int_96 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 32, num3));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_8 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 33, num3));
				CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_8 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 34, num3));
				Form1.int_48[0] = CommonUtility.ParseInt32OrZero(GetMessageField(array, 35, num3));
				Form1.int_48[1] = CommonUtility.ParseInt32OrZero(GetMessageField(array, 36, num3));
				Form1.int_4 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 37, num3));
				MapNavigationProfileProvider.int_1 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 38, num3));
				Form1.int_112 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 39, num3));
				Form1.string_37 = GetMessageField(array, 40, num3);
				Form1.int_89 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 41, num3));
				Form1.int_81 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 42, num3));
				Form1.int_120 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 43, num3));
				if (num3 <= 44)
				{
					return;
				}
				int num4 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 44, num3));
				if (num4 <= 0 || Form1.characterAccountConfig_1 == null)
				{
					return;
				}
				for (int i = 0; i < Form1.characterAccountConfig_1.Length; i++)
				{
					if (num4 == 1 && Form1.characterAccountConfig_1[i].bool_25)
					{
						GameProcessInteractionHelper.WriteSharedSlotInt32(Form1.characterAccountConfig_1[i], GameProcessInteractionHelper.uint_22, 1, 4);
					}
					else
					{
						GameProcessInteractionHelper.WriteSharedSlotInt32(Form1.characterAccountConfig_1[i], GameProcessInteractionHelper.uint_22, 0, 4);
					}
				}
				return;
			}
			catch
			{
				return;
			}
		}
		CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_4 = 0;
		CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_0 = 0;
		CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_6 = 0;
	}

	public static string BuildSyncMessage()
	{
		Form1.int_10 = 0;
		uint num = 0u;
		uint num2 = 0u;
		int int_ = CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_4;
		if (CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4 != null)
		{
			num = CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4[0];
			num2 = CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_4[1];
		}
		if (num != 0 && num2 != 0 && int_ > 0)
		{
			string text = "0";
			if (TongKimBattlefieldHelper.int_0 > 0)
			{
				if (CommonUtility.GetElapsedMilliseconds(TongKimBattlefieldHelper.long_0) < 1500L)
				{
					text = TongKimBattlefieldHelper.int_0.ToString();
				}
				else
				{
					TongKimBattlefieldHelper.int_0 = 0;
				}
			}
			string result = "@|" + int_ + "|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_3 + "|" + num + "|" + num2 + "|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_6 + "|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_3 + "|" + Form1.int_121 + "|" + Form1.int_24 + "|" + Form1.int_113 + "|" + Form1.int_115 + "|" + ChienLongDongNavigationHelper.int_0 + "|" + Form1.int_26 + "|" + Form1.int_34 + "|" + Form1.int_35 + "|" + Form1.int_36 + "|" + Form1.int_29 + "|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_2 + "|" + Form1.int_28 + "|" + Form1.int_94 + "|" + Form1.int_95 + "|" + FormDame.int_6 + "|" + FormDame.int_9 + "|" + FormDame.int_11 + "|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_5 + "|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_7 + "|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_3 + "|" + Form1.int_37 + "|" + Form1.int_38 + "|" + Form1.int_25 + "|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_9 + "|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.uint_2 + "|" + Form1.int_96 + "|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_8 + "|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_8 + "|" + Form1.int_48[0] + "|" + Form1.int_48[1] + "|" + Form1.int_4 + "|" + MapNavigationProfileProvider.int_1 + "|" + Form1.int_112 + "|" + Form1.string_37.Replace(" ", "").Replace(",", "_") + "|" + Form1.int_89 + "|" + Form1.int_81 + "|" + Form1.int_120 + "|" + text + "|*";
			CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_9 = 0;
			return result;
		}
		return string.Empty;
	}
}
