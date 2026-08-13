using System;
using System.Threading;
using ns1;
using ns11;
using ns146;
using ns23;
using ns35;
using ns36;
using ns52;
using ns53;
using ns63;
using ns80;
using ns81;
using ns85;

namespace ns71;

internal class GameProcessInteractionHelper
{
	public static uint uint_0 = 65536u;

	public static uint uint_1 = 512u;

	private static uint playerChatBufferSize = 256u;

	private static uint privateMessageBufferSize = 256u;

	private static uint gameScriptBufferSize = 256u;

	public static uint uint_5 = 1u;

	public static uint uint_6 = 2u;

	public static uint uint_7 = 3u;

	public static uint uint_8 = 4u;

	public static uint uint_9 = 5u;

	public static uint uint_10 = 6u;

	public static uint uint_11 = 7u;

	public static uint uint_12 = 8u;

	public static uint uint_13 = 9u;

	public static uint uint_14 = 10u;

	public static uint uint_15 = 11u;

	public static uint uint_16 = 12u;

	public static uint uint_17 = 15u;

	public static uint uint_18 = 16u;

	public static uint uint_19 = 18u;

	public static uint uint_20 = 20u;

	public static uint uint_21 = 22u;

	public static uint uint_22 = 24u;

	public static uint uint_23 = 25u;

	public static uint uint_24 = 26u;

	public static uint uint_25 = 27u;

	public static uint uint_26 = 29u;

	public static uint uint_27 = 32u;

	public static uint uint_28 = 33u;

	public static uint uint_29 = 34u;

	public static uint uint_30 = 35u;

	public static uint uint_31 = 36u;

	public static uint uint_32 = 37u;

	public static uint uint_33 = 39u;

	public static uint uint_34 = 40u;

	public static uint uint_35 = 41u;

	public static uint uint_36 = 48u;

	public static uint uint_37 = 50u;

	public static uint uint_38 = 64u;

	public static uint uint_39 = 66u;

	public static uint uint_40 = 67u;

	public static uint uint_41 = 68u;

	public static uint uint_42 = 69u;

	public static uint uint_43 = 70u;

	public static uint uint_44 = 71u;

	public static uint uint_45 = 72u;

	public static uint uint_46 = 75u;

	public static uint uint_47 = 76u;

	public static uint uint_48 = 78u;

	public static uint uint_49 = 79u;

	public static uint uint_50 = 80u;

	public static uint uint_51 = 96u;

	public static uint uint_52 = 256u;

	public static uint uint_53 = 0u;

	public static void WriteSharedSlotCurrentSecondOfDay(CharacterAccountConfig characterAccountConfig_0, uint uint_54)
	{
		DateTime now = DateTime.Now;
		int int_ = now.Second + now.Minute * 60 + now.Hour * 60 * 60;
		WriteSharedSlotInt32(characterAccountConfig_0, uint_54, int_, 4);
	}

	public static int GetSharedSlotElapsedSeconds(CharacterAccountConfig characterAccountConfig_0, uint uint_54)
	{
		DateTime now = DateTime.Now;
		int num = now.Second + now.Minute * 60 + now.Hour * 60 * 60;
		int num2 = ReadSharedSlotIntegerValue(characterAccountConfig_0, uint_54, 4);
		return Math.Abs(num2 - num);
	}

	public static void WriteSharedSlotInt32(CharacterAccountConfig characterAccountConfig_0, uint uint_54, int int_0, byte byte_0 = 4)
	{
		int int_1 = 0;
		byte[] bytes = BitConverter.GetBytes(int_0);
		WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_16 + uint_54 * 4, bytes, byte_0, ref int_1);
	}

	public static int ReadSharedSlotIntegerValue(CharacterAccountConfig characterAccountConfig_0, uint uint_54, byte byte_0 = 4)
	{
		int int_ = 0;
		byte[] array = new byte[4];
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_16 + uint_54 * 4, array, 4, ref int_);
		if (byte_0 > 3 && (array[1] > 0 || array[2] > 0 || array[3] > 0))
		{
			return BitConverter.ToInt32(array, 0);
		}
		return array[0];
	}

	public static uint CalculateSquaredCoordinateDistance(uint uint_54, uint uint_55, uint uint_56, uint uint_57)
	{
		long num = (int)(uint_54 - uint_56);
		long num2 = (int)(uint_55 - uint_57);
		return (uint)(num * num + num2 * num2);
	}

	private static void WriteProcessBytes(int int_0, uint uint_54, byte[] byte_0)
	{
		int int_1 = 0;
		WindowsInteropHelper.WriteProcessMemory(int_0, uint_54, byte_0, byte_0.Length, ref int_1);
	}

	private static void WriteProcessSingleByteString(int int_0, uint uint_54, string string_0, bool bool_0 = true)
	{
		byte[] byte_ = CommonUtility.ConvertStringToSingleByteArray(string_0, bool_0);
		WriteProcessBytes(int_0, uint_54, byte_);
	}

	public static bool IsGameSessionReady(CharacterAccountConfig characterAccountConfig_0)
	{
		int int_ = 0;
		byte[] array = new byte[4];
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_11.uint_0, array, 4, ref int_);
		uint num = BitConverter.ToUInt32(array, 0);
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, array, 4, ref int_);
		uint num2 = BitConverter.ToUInt32(array, 0);
		uint num3 = num2 * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_14.uint_0, array, 4, ref int_);
		uint num4 = BitConverter.ToUInt32(array, 0);
		uint num5 = num4 + num3;
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num5 + GameConfigurationManager.memorySignatureScanConfig_55.uint_0, array, 4, ref int_);
		int num6 = BitConverter.ToInt32(array, 0);
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num5 + GameConfigurationManager.memorySignatureScanConfig_50.uint_0, array, 4, ref int_);
		int num7 = BitConverter.ToInt32(array, 0);
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_27.uint_0, array, 4, ref int_);
		int num8 = BitConverter.ToInt32(array, 0);
		int num9 = GameInterfaceMemoryHelper.ReadGatewayConnectionState(characterAccountConfig_0);
		return num7 > 0 && num8 > 0 && num6 > 0 && num9 > 1;
	}

	public static void InitializeRemoteActionStubs(ref CharacterAccountConfig characterAccountConfig_0)
	{
		if (uint_53 == 0)
		{
			uint num = WindowsInteropHelper.FindLoadedModuleBaseAddress(WindowsInteropHelper.ReadCurrentProcessId(), "ntdll.dll");
			uint_53 = WindowsInteropHelper.GetProcAddress(num, "RtlExitUserThread");
		}
		characterAccountConfig_0.uint_18 = 4096u;
		characterAccountConfig_0.uint_98 = CreateRemoteThreadExitStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_51 = CreateRunToRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_88 = CreateCoordinateMovementRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_84 = CreateDoScriptRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_81 = CreatePlayerChatRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_82 = CreatePlayerPrintRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_83 = CreatePlayerSayRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_43 = CreateObjectPickupRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_44 = CreateInventoryItemMoveRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_46 = CreateItemUseRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_71 = CreateSpecialFunctionItemPurchaseRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_60 = CreateSpecialFunction71RemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_62 = CreateMoneyTransferRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_61 = CreateShopItemRecordPurchaseRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_56 = CreateClearSmsRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_40 = CreateSkillSelectionRemoteStub(ref characterAccountConfig_0, bool_0: false);
		characterAccountConfig_0.uint_41 = CreateSkillSelectionRemoteStub(ref characterAccountConfig_0, bool_0: true);
		characterAccountConfig_0.uint_78 = CreateNamedSpecialFunctionRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_79 = CreateKyTranCacCloseRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_58 = CreateItemRepairRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_59 = CreateItemRepairCostRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_90 = CreateTongSpecialFunctionRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_92 = CreateGuildWarDeclarationRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_67 = CreateTradeRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_68 = CreateTradeAcceptRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_69 = CreateTradeApplyRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_70 = CreateTradePutMoneyRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_94 = CreateGuildEntryRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_95 = CreateGuildJoinApprovalRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_96 = CreateGuildPushMoneyRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_53 = CreateTeamCreationRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_54 = CreateTeamLeaveRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_55 = CreateReplyInviteRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_42 = CreateIncreaseSkillLevelRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_45 = CreateItemThrowRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_47 = CreateItemSplitRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_49 = CreateHuyenTinhModeOneRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_48 = CreateHuyenTinhModeZeroRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_91 = CreateCraftingBoxRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_50 = CreateClickToRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_57 = CreateOpenSpecialFunctionRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_63 = CreateInventoryItemFunction88RemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_64 = CreateBoxAcceptRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_66 = CreateBoxUnlockRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_65 = CreateIncreaseAttributePointRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_72 = CreateFollowIndexRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_80 = CreateReturnCityRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_77 = CreateShopPurchaseRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_85 = CreateLastChannelPublishRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_86 = CreateLastChannelTabSelectionRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_87 = CreateFlagBoxEntryRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_89 = CreateVanSuThongBoxRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_97 = CreateCombinedShortcutModeRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_73 = CreatePrimaryMenuCloseRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_74 = CreateSecondaryMenuCloseRemoteStub(ref characterAccountConfig_0);
		characterAccountConfig_0.uint_75 = CreateMenuClickRemoteStub(ref characterAccountConfig_0, 0);
		characterAccountConfig_0.uint_76 = CreateMenuClickRemoteStub(ref characterAccountConfig_0, 1);
	}

	private static uint CreateRemoteThreadExitStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		characterAccountConfig_0.uint_18 += 4u;
		uint num = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		uint num2 = uint_53 - (num + 8);
		string string_ = "33 C0 50E8" + CommonUtility.FormatIntegerAsHex(num2, 8, bool_1: false, bool_2: true);
		int int_ = 0;
		byte[] array = CommonUtility.ParseHexBytePattern(string_, bool_1: false);
		bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num, array, array.Length, ref int_);
		characterAccountConfig_0.uint_18 += (uint)(array.Length + 4);
		return num * Convert.ToByte(flag && characterAccountConfig_0.uint_17 != 0);
	}

	public static string BuildRemoteStubExitSuffix(uint uint_54)
	{
		string result = "C3";
		if (uint_54 != 0 && uint_53 != 0)
		{
			result = "3EC70424" + CommonUtility.FormatIntegerAsHex(uint_54, 8, bool_1: false, bool_2: true) + "C3";
		}
		return result;
	}

	public static uint CreateRemoteCallStub(ref CharacterAccountConfig characterAccountConfig_0, uint uint_54, string string_0, string string_1 = "", uint uint_55 = 0u)
	{
		if (characterAccountConfig_0.uint_17 == 0)
		{
			return 0u;
		}
		string text = BuildRemoteStubExitSuffix(characterAccountConfig_0.uint_98);
		uint num = (uint)(text.Length / 2 - 1);
		byte[] array = CommonUtility.ParseHexBytePattern("60" + string_0 + "E8 00 00 00 00" + string_1 + "61" + text);
		int int_ = 204;
		uint num2 = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num2, array, array.Length, ref int_);
		int num3 = string_1.Replace(" ", "").Length / 2;
		uint num4 = characterAccountConfig_0.uint_7;
		if (uint_55 != 0)
		{
			num4 = uint_55;
		}
		uint num5 = num4 + uint_54;
		uint num6 = (uint)((int)num2 + array.Length - num3 - 2) - num;
		uint num7 = num5 - num6;
		uint num8 = (uint)((int)num2 + array.Length - num3 - 6) - num;
		WindowsInteropHelper.WriteProcessUIntValue(num8, characterAccountConfig_0.int_137, num7);
		characterAccountConfig_0.uint_18 += (uint)(array.Length + 4);
		return num2;
	}

	public static bool ExecuteRemoteStub(int int_0, uint uint_54)
	{
		if (int_0 != 0 && uint_54 != 0)
		{
			uint num = 0u;
			uint num2 = WindowsInteropHelper.CreateRemoteThread(int_0, IntPtr.Zero, 0u, uint_54, 0u, 0u, out num);
			if (num2 != 0)
			{
				WindowsInteropHelper.WaitForSingleObject(num2, 1000u);
				WindowsInteropHelper.CloseHandleSafely((int)num2);
			}
			return num != 0;
		}
		return false;
	}

	private static uint CreateCombinedShortcutModeRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		characterAccountConfig_0.uint_18 += 4u;
		string string_ = "6A 00 6A 01";
		return CreateRemoteCallStub(ref characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_90.uint_0, string_, "83 C4 08");
	}

	public static bool SetCombinedShortcutModeEnabled(CharacterAccountConfig characterAccountConfig_0, bool bool_0)
	{
		if (characterAccountConfig_0.uint_97 != 0)
		{
			int int_ = 0;
			byte[] byte_ = new byte[1] { Convert.ToByte(bool_0) };
			if (!WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_97 + 4, byte_, 1, ref int_))
			{
				return false;
			}
			return ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_97);
		}
		return false;
	}

	private static uint CreateGuildJoinApprovalRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		characterAccountConfig_0.uint_18 += 4u;
		uint num = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		uint num2 = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_196.uint_0 - (num + 32);
		string string_ = "60BA C8283F1581C2" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_205.uint_0, 8, bool_1: false, bool_2: true) + "B8 010000008B0D" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_224.uint_0, 8, bool_1: false, bool_2: true) + "5052 6A 05E8" + CommonUtility.FormatIntegerAsHex(num2, 8, bool_1: false, bool_2: true) + "61" + BuildRemoteStubExitSuffix(characterAccountConfig_0.uint_98);
		int int_ = 0;
		byte[] array = CommonUtility.ParseHexBytePattern(string_, bool_1: false);
		bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num, array, array.Length, ref int_);
		characterAccountConfig_0.uint_18 += (uint)(array.Length + 4);
		return num * Convert.ToByte(flag && characterAccountConfig_0.uint_17 != 0 && GameConfigurationManager.memorySignatureScanConfig_196.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_224.uint_0 != 0);
	}

	public static bool ApproveGuildJoinRequest(CharacterAccountConfig characterAccountConfig_0, uint uint_54, byte byte_0 = 0)
	{
		if (characterAccountConfig_0.uint_95 != 0)
		{
			int int_ = 0;
			byte[] bytes = BitConverter.GetBytes(uint_54);
			bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_95 + 2, bytes, bytes.Length, ref int_);
			if (byte_0 != 1)
			{
				byte_0 = 0;
			}
			bytes = new byte[1] { byte_0 };
			bool flag2 = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_95 + 13, bytes, 1, ref int_);
			if (flag && flag2)
			{
				return ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_95);
			}
			return false;
		}
		return false;
	}

	private static uint CreateGuildWarDeclarationRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		characterAccountConfig_0.uint_18 += 4u;
		uint num = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		string string_ = "60BE 184D4028BF 2BBC418BBB 010000008B0D" + CommonUtility.FormatIntegerAsHex(characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_197.uint_0, 8, bool_1: false, bool_2: true) + "8B 01 8B 50 3C 6A 00 56 57 53 FF D261" + BuildRemoteStubExitSuffix(characterAccountConfig_0.uint_98);
		int int_ = 0;
		byte[] array = CommonUtility.ParseHexBytePattern(string_, bool_1: false);
		bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num, array, array.Length, ref int_);
		characterAccountConfig_0.uint_18 += (uint)(array.Length + 4);
		return num * Convert.ToByte(flag && characterAccountConfig_0.uint_17 != 0 && GameConfigurationManager.memorySignatureScanConfig_197.uint_0 != 0);
	}

	public static bool InvokeGuildWarDeclaration(CharacterAccountConfig characterAccountConfig_0, object object_0)
	{
		if (characterAccountConfig_0.uint_92 != 0 && object_0 != null)
		{
			uint num = CommonUtility.ParseUInt32OrZero(object_0.ToString());
			if (num == 0)
			{
				num = CommonUtility.ComputeLegacyStringHash(object_0.ToString());
				if (num == 0)
				{
					return false;
				}
			}
			int int_ = 0;
			byte[] array = new byte[4];
			byte[] array2 = new byte[4];
			byte[] byte_ = new byte[4];
			byte[] bytes = BitConverter.GetBytes(num);
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_11.uint_0, array, 4, ref int_);
			uint num2 = BitConverter.ToUInt32(array, 0);
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num2 + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, array, 4, ref int_);
			uint num3 = BitConverter.ToUInt32(array, 0);
			uint num4 = num3 * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_14.uint_0, array, 4, ref int_);
			uint num5 = BitConverter.ToUInt32(array, 0);
			uint num6 = num5 + num4;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num6 + GameConfigurationManager.memorySignatureScanConfig_88.uint_0, array2, 4, ref int_);
			if (BitConverter.ToUInt32(array2, 0) != 0)
			{
				uint num7 = num2 + GameConfigurationManager.memorySignatureScanConfig_189.uint_0;
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num7 + 40, byte_, 4, ref int_);
				bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_92 + 2, bytes, bytes.Length, ref int_);
				bool flag2 = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_92 + 7, array2, 4, ref int_);
				bool flag3 = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_92 + 12, byte_, 4, ref int_);
				if (flag && flag2 && flag3)
				{
					return ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_92);
				}
				return false;
			}
			return false;
		}
		return false;
	}

	private static uint CreateItemRepairRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		characterAccountConfig_0.uint_18 += 4u;
		uint num = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		uint num2 = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_237.uint_0 - (num + 38);
		string string_ = "60B8" + CommonUtility.FormatIntegerAsHex(num - 4, 8, bool_1: false, bool_2: true) + "80 38 00 75 25 C6 00 018B0D" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_236.uint_0, 8, bool_1: false, bool_2: true) + "85 C9 74 11 B8 00 00 00 00 55 89 E5 50E8" + CommonUtility.FormatIntegerAsHex(num2, 8, bool_1: false, bool_2: true) + "89 EC 5DC605" + CommonUtility.FormatIntegerAsHex(num - 4, 8, bool_1: false, bool_2: true) + "0061" + BuildRemoteStubExitSuffix(characterAccountConfig_0.uint_98);
		int int_ = 0;
		byte[] array = CommonUtility.ParseHexBytePattern(string_, bool_1: false);
		bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num, array, array.Length, ref int_);
		characterAccountConfig_0.uint_18 += (uint)(array.Length + 4);
		return num * Convert.ToByte(flag && characterAccountConfig_0.uint_17 != 0 && GameConfigurationManager.memorySignatureScanConfig_237.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_236.uint_0 != 0);
	}

	public static bool RepairItemByRecordIndex(CharacterAccountConfig characterAccountConfig_0, uint uint_54)
	{
		if (characterAccountConfig_0.uint_58 != 0 && IsGameSessionReady(characterAccountConfig_0))
		{
			int int_ = 0;
			byte[] bytes = BitConverter.GetBytes(uint_54);
			if (!WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_58 + 25, bytes, bytes.Length, ref int_))
			{
				return false;
			}
			return ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_58);
		}
		return false;
	}

	private static uint CreateItemRepairCostRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		characterAccountConfig_0.uint_18 += 8u;
		uint num = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		uint num2 = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_238.uint_0 - (num + 44);
		string string_ = "60B8" + CommonUtility.FormatIntegerAsHex(num - 4, 8, bool_1: false, bool_2: true) + "80 38 00 75 2F C6 00 01A1" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_105.uint_0, 8, bool_1: false, bool_2: true) + "85 C0 74 18 B9 00 00 00 0069C9" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_106.uint_0, 8, bool_1: false, bool_2: true) + "01 C1 55 89 E5E8" + CommonUtility.FormatIntegerAsHex(num2, 8, bool_1: false, bool_2: true) + "89 EC 5DBF" + CommonUtility.FormatIntegerAsHex(num - 4, 8, bool_1: false, bool_2: true) + "C6 07 00 89 47 FC 61" + BuildRemoteStubExitSuffix(characterAccountConfig_0.uint_98);
		int int_ = 0;
		byte[] array = CommonUtility.ParseHexBytePattern(string_, bool_1: false);
		bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num, array, array.Length, ref int_);
		characterAccountConfig_0.uint_18 += (uint)(array.Length + 4);
		return num * Convert.ToByte(flag && characterAccountConfig_0.uint_17 != 0 && GameConfigurationManager.memorySignatureScanConfig_238.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_105.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_106.uint_0 != 0);
	}

	public static int ReadItemRepairCostByRecordIndex(CharacterAccountConfig characterAccountConfig_0, uint uint_54)
	{
		if (characterAccountConfig_0.uint_59 != 0)
		{
			int num = 0;
			int int_ = 0;
			byte[] array = new byte[1];
			while (num < 300)
			{
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_59 - 4, array, 1, ref int_);
				if (array[0] == 0)
				{
					break;
				}
				num++;
				Thread.Sleep(1);
			}
			array = BitConverter.GetBytes(uint_54);
			if (WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_59 + 24, array, array.Length, ref int_))
			{
				array = new byte[4];
				if (WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_59 - 8, array, array.Length, ref int_))
				{
					if (ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_59))
					{
						num = 0;
						int num2 = 0;
						while (num < 30)
						{
							WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_59 - 8, array, 4, ref int_);
							num2 = BitConverter.ToInt32(array, 0);
							if (num2 > 0)
							{
								break;
							}
							num++;
							Thread.Sleep(10);
						}
						return num2;
					}
					return -1;
				}
				return -1;
			}
			return -1;
		}
		return -1;
	}

	private static uint CreateNamedSpecialFunctionRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		characterAccountConfig_0.uint_18 += 4u;
		uint num = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		characterAccountConfig_0.uint_18 += 80u;
		uint num2 = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		uint num3 = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_225.uint_0 - (num2 + 46);
		string string_ = "60B8" + CommonUtility.FormatIntegerAsHex(num2 - 4, 8, bool_1: false, bool_2: true) + "80 38 00 75 2D C6 00 01 90 90 90 908B0D" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_224.uint_0, 8, bool_1: false, bool_2: true) + "85 C9 74 15B8" + CommonUtility.FormatIntegerAsHex(num, 8, bool_1: false, bool_2: true) + "55 89 E5 6A 00 50 6A 70E8" + CommonUtility.FormatIntegerAsHex(num3, 8, bool_1: false, bool_2: true) + "89 EC 5DC605" + CommonUtility.FormatIntegerAsHex(num2 - 4, 8, bool_1: false, bool_2: true) + "0061" + BuildRemoteStubExitSuffix(characterAccountConfig_0.uint_98);
		int int_ = 0;
		byte[] array = CommonUtility.ParseHexBytePattern(string_, bool_1: false);
		bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num2, array, array.Length, ref int_);
		characterAccountConfig_0.uint_18 += (uint)(array.Length + 4);
		return num2 * Convert.ToByte(flag && characterAccountConfig_0.uint_17 != 0 && GameConfigurationManager.memorySignatureScanConfig_225.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_224.uint_0 != 0);
	}

	private static uint CreateKyTranCacCloseRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		characterAccountConfig_0.uint_18 += 4u;
		uint num = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		uint num2 = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_232.uint_0 - (num + 9);
		string string_ = "60 55 89 E5E8" + CommonUtility.FormatIntegerAsHex(num2, 8, bool_1: false, bool_2: true) + "89 EC 5D61" + BuildRemoteStubExitSuffix(characterAccountConfig_0.uint_98);
		int int_ = 0;
		byte[] array = CommonUtility.ParseHexBytePattern(string_, bool_1: false);
		bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num, array, array.Length, ref int_);
		characterAccountConfig_0.uint_18 += (uint)(array.Length + 4);
		return num * Convert.ToByte(flag && characterAccountConfig_0.uint_17 != 0 && GameConfigurationManager.memorySignatureScanConfig_232.uint_0 != 0);
	}

	private static uint CreateShopPurchaseRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		string string_ = "B8 " + CommonUtility.FormatIntegerAsHex(characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18, 8, bool_1: false, bool_2: true) + "89 45 08 C7 00 10 00 00 00 66 C7 40 04 00 00 66 C7 40 06 A0 08 6A 00 50 6A 188B 0D " + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_224.uint_0, 8, bool_1: false, bool_2: true);
		characterAccountConfig_0.uint_18 += 16u;
		return CreateRemoteCallStub(ref characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_225.uint_0, string_);
	}

	public static bool InvokeNamedSpecialFunction(CharacterAccountConfig characterAccountConfig_0, string string_0)
	{
		if (characterAccountConfig_0.uint_78 != 0)
		{
			int int_ = 0;
			byte[] array = CommonUtility.ConvertStringToSingleByteArray(string_0);
			if (WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_78 - 80, array, array.Length, ref int_))
			{
				return ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_78);
			}
			return false;
		}
		return false;
	}

	public static bool CloseKyTranCac(CharacterAccountConfig characterAccountConfig_0)
	{
		if (characterAccountConfig_0.uint_79 == 0)
		{
			return false;
		}
		return ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_79);
	}

	public static bool PurchaseShopItemByIndex(CharacterAccountConfig characterAccountConfig_0, int int_0, int int_1 = 0)
	{
		if (characterAccountConfig_0.uint_18 != 0 && characterAccountConfig_0.uint_77 != 0)
		{
			int int_2 = 0;
			int value = int_1 * 16 + 2208;
			byte[] bytes = BitConverter.GetBytes(value);
			byte[] bytes2 = BitConverter.GetBytes(int_0);
			bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_77 + 19, bytes2, 2, ref int_2);
			bool flag2 = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_77 + 25, bytes, 2, ref int_2);
			if (flag && flag2)
			{
				return ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_77);
			}
			return false;
		}
		return false;
	}

	public static int ReadBaoVatPurchaseCalibrationRawValue(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = 2712668 + characterAccountConfig_0.uint_7;
		uint num2 = 508u;
		uint num3 = 16u;
		int int_ = 0;
		byte[] array = new byte[4];
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num, array, 4, ref int_);
		uint num4 = BitConverter.ToUInt32(array, 0);
		if (num4 == 0)
		{
			return -1000000;
		}
		uint num5 = num4 + num2 + num3;
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num5, array, 4, ref int_);
		uint num6 = BitConverter.ToUInt32(array, 0);
		if (num6 == 0)
		{
			return -1000001;
		}
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num6, array, 1, ref int_);
		if (array[0] != 16)
		{
			return -1000002;
		}
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num6 + 6, array, 2, ref int_);
		return array[1] * 256 + array[0];
	}

	private static uint CreateSkillSelectionRemoteStub(ref CharacterAccountConfig characterAccountConfig_0, bool bool_0)
	{
		characterAccountConfig_0.uint_18 += 4u;
		uint num = 0u;
		num = ((!bool_0) ? GameConfigurationManager.memorySignatureScanConfig_67.uint_0 : GameConfigurationManager.memorySignatureScanConfig_69.uint_0);
		uint num2 = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		uint num3 = characterAccountConfig_0.uint_7 + num - (num2 + 44);
		string string_ = "60B8" + CommonUtility.FormatIntegerAsHex(num2 - 4, 8, bool_1: false, bool_2: true) + "80 38 00 75 2B C6 00 018B0D" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, 8, bool_1: false, bool_2: true) + "85 C9 74 1781C1" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_12.uint_0, 8, bool_1: false, bool_2: true) + "BB 53 00 00 00 55 89 E5 53E8" + CommonUtility.FormatIntegerAsHex(num3, 8, bool_1: false, bool_2: true) + "89 EC 5DC605" + CommonUtility.FormatIntegerAsHex(num2 - 4, 8, bool_1: false, bool_2: true) + "0061" + BuildRemoteStubExitSuffix(characterAccountConfig_0.uint_98);
		int int_ = 0;
		byte[] array = CommonUtility.ParseHexBytePattern(string_, bool_1: false);
		bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num2, array, array.Length, ref int_);
		characterAccountConfig_0.uint_18 += (uint)(array.Length + 4);
		return num2 * Convert.ToByte(flag && characterAccountConfig_0.uint_17 != 0 && num != 0 && GameConfigurationManager.memorySignatureScanConfig_11.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_12.uint_0 != 0);
	}

	public static bool SetLeftSkillIdViaRemoteScript(CharacterAccountConfig characterAccountConfig_0, uint uint_54)
	{
		if (characterAccountConfig_0.uint_40 == 0)
		{
			return false;
		}
		int int_ = 0;
		byte[] array = new byte[1];
		int num = 0;
		while (!CommonUtility.bool_0)
		{
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_40 - 4, array, 1, ref int_);
			if (array[0] == 0)
			{
				break;
			}
			num++;
			if (num <= 350)
			{
				Thread.Sleep(1);
				continue;
			}
			return false;
		}
		array = BitConverter.GetBytes(uint_54);
		if (!WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_40 + 31, array, array.Length, ref int_))
		{
			return false;
		}
		return ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_40);
	}

	public static bool SetRightSkillIdViaRemoteScript(CharacterAccountConfig characterAccountConfig_0, uint uint_54)
	{
		if (characterAccountConfig_0.uint_41 == 0)
		{
			return false;
		}
		int int_ = 0;
		byte[] array = new byte[1];
		int num = 0;
		while (!CommonUtility.bool_0)
		{
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_41 - 4, array, 1, ref int_);
			if (array[0] == 0)
			{
				break;
			}
			num++;
			if (num <= 350)
			{
				Thread.Sleep(1);
				continue;
			}
			return false;
		}
		array = BitConverter.GetBytes(uint_54);
		if (!WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_41 + 31, array, array.Length, ref int_))
		{
			return false;
		}
		return ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_41);
	}

	private static uint CreateClearSmsRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		characterAccountConfig_0.uint_18 += 4u;
		uint num = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		uint num2 = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_169.uint_0 - (num + 36);
		string string_ = "60B9" + CommonUtility.FormatIntegerAsHex(num - 4, 8, bool_1: false, bool_2: true) + "80 39 00 75 23 C6 01 018B0D" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_165.uint_0, 8, bool_1: false, bool_2: true) + "85 C9 74 0F 55 89 E5 6A 00 6A 00E8" + CommonUtility.FormatIntegerAsHex(num2, 8, bool_1: false, bool_2: true) + "89 EC 5DC605" + CommonUtility.FormatIntegerAsHex(num - 4, 8, bool_1: false, bool_2: true) + "0061" + BuildRemoteStubExitSuffix(characterAccountConfig_0.uint_98);
		int int_ = 0;
		byte[] array = CommonUtility.ParseHexBytePattern(string_, bool_1: false);
		bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num, array, array.Length, ref int_);
		characterAccountConfig_0.uint_18 += (uint)(array.Length + 4);
		return num * Convert.ToByte(flag && characterAccountConfig_0.uint_17 != 0 && GameConfigurationManager.memorySignatureScanConfig_169.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_165.uint_0 != 0);
	}

	private static uint CreateShopItemRecordPurchaseRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		characterAccountConfig_0.uint_18 += 4u;
		uint num = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		uint num2 = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_104.uint_0 - (num + 51);
		string string_ = "60B8" + CommonUtility.FormatIntegerAsHex(num - 4, 8, bool_1: false, bool_2: true) + "80 38 00 75 32 C6 00 01A1" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_105.uint_0, 8, bool_1: false, bool_2: true) + "85 C0 74 1F B9 00 00 00 0069C9" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_106.uint_0, 8, bool_1: false, bool_2: true) + "01 C88B88" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_103.uint_0, 8, bool_1: false, bool_2: true) + "55 89 E5 51E8" + CommonUtility.FormatIntegerAsHex(num2, 8, bool_1: false, bool_2: true) + "89 EC 5DC605" + CommonUtility.FormatIntegerAsHex(num - 4, 8, bool_1: false, bool_2: true) + "0061" + BuildRemoteStubExitSuffix(characterAccountConfig_0.uint_98);
		int int_ = 0;
		byte[] array = CommonUtility.ParseHexBytePattern(string_, bool_1: false);
		bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num, array, array.Length, ref int_);
		characterAccountConfig_0.uint_18 += (uint)(array.Length + 4);
		return num * Convert.ToByte(flag && characterAccountConfig_0.uint_17 != 0 && GameConfigurationManager.memorySignatureScanConfig_105.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_106.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_103.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_104.uint_0 != 0);
	}

	public static bool PurchaseShopItemByRecordIndex(CharacterAccountConfig characterAccountConfig_0, uint uint_54)
	{
		if (characterAccountConfig_0.uint_61 != 0 && IsGameSessionReady(characterAccountConfig_0))
		{
			int int_ = 0;
			byte[] array = new byte[4];
			int num = 0;
			while (num < 300)
			{
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_61 - 4, array, 4, ref int_);
				if (BitConverter.ToInt32(array, 0) == 0)
				{
					break;
				}
				num++;
				Thread.Sleep(1);
			}
			byte[] bytes = BitConverter.GetBytes(uint_54);
			if (WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_61 + 24, bytes, bytes.Length, ref int_))
			{
				array = new byte[4];
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_11.uint_0, array, 4, ref int_);
				uint num2 = BitConverter.ToUInt32(array, 0);
				array = new byte[4];
				WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num2 + 35664, array, 4, ref int_);
				WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num2 + 55416, array, 4, ref int_);
				return ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_61);
			}
			return false;
		}
		return false;
	}

	private static uint CreateMoneyTransferRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		characterAccountConfig_0.uint_18 += 4u;
		uint num = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		uint num2 = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_225.uint_0 - (num + 41);
		string string_ = "60B8" + CommonUtility.FormatIntegerAsHex(num - 4, 8, bool_1: false, bool_2: true) + "80 38 00 75 28 C6 00 018B0D" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_224.uint_0, 8, bool_1: false, bool_2: true) + "85 C9 74 14 55 89 E5 68 00 01 00 00 6A 00 6A 05E8" + CommonUtility.FormatIntegerAsHex(num2, 8, bool_1: false, bool_2: true) + "89 EC 5DC605" + CommonUtility.FormatIntegerAsHex(num - 4, 8, bool_1: false, bool_2: true) + "0061" + BuildRemoteStubExitSuffix(characterAccountConfig_0.uint_98);
		int int_ = 0;
		byte[] array = CommonUtility.ParseHexBytePattern(string_, bool_1: false);
		bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num, array, array.Length, ref int_);
		characterAccountConfig_0.uint_18 += (uint)(array.Length + 4);
		return num * Convert.ToByte(flag && characterAccountConfig_0.uint_17 != 0 && GameConfigurationManager.memorySignatureScanConfig_224.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_225.uint_0 != 0);
	}

	public static bool TransferStoredMoneyToCharacter(CharacterAccountConfig characterAccountConfig_0, uint uint_54)
	{
		if (characterAccountConfig_0.uint_62 != 0 && IsGameSessionReady(characterAccountConfig_0))
		{
			int int_ = 0;
			byte[] array = new byte[1];
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_62 - 4, array, 1, ref int_);
			if (array[0] > 0)
			{
				return false;
			}
			array[0] = 0;
			byte[] bytes = BitConverter.GetBytes(uint_54);
			bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_62 + 33, array, 1, ref int_);
			bool flag2 = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_62 + 28, bytes, 4, ref int_);
			if (flag && flag2)
			{
				return ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_62);
			}
			return false;
		}
		return false;
	}

	public static bool TransferCharacterMoneyToStorage(CharacterAccountConfig characterAccountConfig_0, uint uint_54)
	{
		if (characterAccountConfig_0.uint_62 != 0 && IsGameSessionReady(characterAccountConfig_0))
		{
			int int_ = 0;
			byte[] array = new byte[1];
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_62 - 4, array, 1, ref int_);
			if (array[0] > 0)
			{
				return false;
			}
			array[0] = 1;
			byte[] bytes = BitConverter.GetBytes(uint_54);
			bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_62 + 33, array, 1, ref int_);
			bool flag2 = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_62 + 28, bytes, 4, ref int_);
			if (flag && flag2)
			{
				return ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_62);
			}
			return false;
		}
		return false;
	}

	public static uint ReadMoneyValueByType(CharacterAccountConfig characterAccountConfig_0, int int_0 = 1)
	{
		uint num = GameConfigurationManager.memorySignatureScanConfig_74.uint_0;
		if (int_0 == 1 || int_0 == 3)
		{
			num = GameConfigurationManager.memorySignatureScanConfig_73.uint_0;
		}
		uint num2 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137) + GameConfigurationManager.memorySignatureScanConfig_12.uint_0;
		uint num3 = num2 + GameConfigurationManager.memorySignatureScanConfig_75.uint_0 + num;
		return WindowsInteropHelper.ReadProcessUInt32(num3, characterAccountConfig_0.int_137);
	}

	private static uint CreateSpecialFunctionItemPurchaseRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		string string_ = "B8" + CommonUtility.FormatIntegerAsHex(characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18, 8, bool_1: false, bool_2: true) + "80 38 0075 3D8B 0D" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_224.uint_0, 8, bool_1: false, bool_2: true) + "85 C974 33C6 00 01 83 C0 04 89 45 08C7 00 0B 00 00 00C7 40 04 01 00 00 006A 00 50 6A 18";
		string string_2 = "B8" + CommonUtility.FormatIntegerAsHex(characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18, 8, bool_1: false, bool_2: true) + "FE 48 0180 78 01 007F C866 C7 00 00 00";
		characterAccountConfig_0.uint_18 += 256u;
		return CreateRemoteCallStub(ref characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_225.uint_0, string_, string_2);
	}

	public static uint PurchaseSpecialFunctionItemByIndex(CharacterAccountConfig characterAccountConfig_0, int int_0)
	{
		if (characterAccountConfig_0.uint_71 != 0 && IsGameSessionReady(characterAccountConfig_0))
		{
			uint result = characterAccountConfig_0.uint_71 - 256;
			int int_1 = 0;
			byte[] array = new byte[1];
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, result, array, 1, ref int_1);
			if (array[0] == 0)
			{
				array = BitConverter.GetBytes(int_0);
				if (!WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_71 + 39, array, 4, ref int_1))
				{
					return 0u;
				}
				if (!ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_71))
				{
					return 0u;
				}
			}
			return result;
		}
		return 0u;
	}

	private static uint CreateItemUseRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		characterAccountConfig_0.uint_18 += 4u;
		uint num = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		uint num2 = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_121.uint_0 - (num + 51);
		string string_ = "60B8" + CommonUtility.FormatIntegerAsHex(num - 4, 8, bool_1: false, bool_2: true) + "80 38 00 75 32 C6 00 018B0D" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, 8, bool_1: false, bool_2: true) + "85 C9 74 1E81C1" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_12.uint_0, 8, bool_1: false, bool_2: true) + "55 89 E5 6A 00 6A 09 6A 05 6A 03 68 01 00 00 00E8" + CommonUtility.FormatIntegerAsHex(num2, 8, bool_1: false, bool_2: true) + "89 EC 5DC605" + CommonUtility.FormatIntegerAsHex(num - 4, 8, bool_1: false, bool_2: true) + "0061" + BuildRemoteStubExitSuffix(characterAccountConfig_0.uint_98);
		int int_ = 0;
		byte[] array = CommonUtility.ParseHexBytePattern(string_, bool_1: false);
		bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num, array, array.Length, ref int_);
		characterAccountConfig_0.uint_18 += (uint)(array.Length + 4);
		return num * Convert.ToByte(flag && characterAccountConfig_0.uint_17 != 0 && GameConfigurationManager.memorySignatureScanConfig_121.uint_0 != 0);
	}

	public static bool UseInventoryItemByRecordIndexAndPosition(CharacterAccountConfig characterAccountConfig_0, uint uint_54, int int_0, int int_1, int int_2 = 3)
	{
		if (characterAccountConfig_0.uint_46 != 0)
		{
			int int_3 = 0;
			byte[] bytes = BitConverter.GetBytes(uint_54);
			byte[] byte_ = new byte[1] { (byte)int_2 };
			byte[] byte_2 = new byte[1] { (byte)int_0 };
			byte[] byte_3 = new byte[1] { (byte)int_1 };
			bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_46 + 36, byte_3, 1, ref int_3);
			bool flag2 = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_46 + 38, byte_2, 1, ref int_3);
			bool flag3 = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_46 + 40, byte_, 1, ref int_3);
			bool flag4 = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_46 + 42, bytes, 4, ref int_3);
			if (flag && flag2 && flag3 && flag4)
			{
				return ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_46);
			}
			return false;
		}
		return false;
	}

	public static bool UseMatchingInventoryItem(CharacterAccountConfig characterAccountConfig_0, string string_0, bool bool_0 = false, int int_0 = -1, bool bool_1 = false)
	{
		if (string_0 != null && !(string_0 == string.Empty) && characterAccountConfig_0.uint_18 != 0 && characterAccountConfig_0.uint_46 != 0 && GameConfigurationManager.memorySignatureScanConfig_121.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_11.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_12.uint_0 != 0)
		{
			int num = 1;
			string[] array = string_0.Split('|', ',', ';');
			string[] array2 = new string[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == null)
				{
					array[i] = string.Empty;
				}
				if (num < array[i].Length)
				{
					num = array[i].Length;
				}
				array2[i] = array[i].Trim().ToLower();
			}
			num += 3;
			int int_1 = 0;
			byte[] array3 = new byte[4];
			byte[] array4 = new byte[1];
			byte[] byte_ = new byte[num];
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_11.uint_0, array3, 4, ref int_1);
			uint num2 = BitConverter.ToUInt32(array3, 0) + GameConfigurationManager.memorySignatureScanConfig_97.uint_0;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_105.uint_0, array3, 4, ref int_1);
			uint num3 = BitConverter.ToUInt32(array3, 0);
			int num4 = Class85.GetInventoryEntryCount(characterAccountConfig_0);
			int num5 = 0;
			uint num6 = 0u;
			int int_2 = 0;
			int int_3 = 0;
			uint num7 = 0u;
			int num8 = 0;
			int num9 = 0;
			for (uint num10 = 1u; num10 < GameConfigurationManager.int_1 && num4 > num5; num10++)
			{
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num2 + (num10 * 5 + GameConfigurationManager.memorySignatureScanConfig_99.uint_0) * 4, array3, 4, ref int_1);
				uint num11 = BitConverter.ToUInt32(array3, 0);
				if (num11 == 0)
				{
					continue;
				}
				uint num12 = num3 + num11 * GameConfigurationManager.memorySignatureScanConfig_106.uint_0;
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num12 + GameConfigurationManager.memorySignatureScanConfig_106.uint_0 - 4, array3, 4, ref int_1);
				if (BitConverter.ToInt32(array3, 0) != 0)
				{
					continue;
				}
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num12 + GameConfigurationManager.memorySignatureScanConfig_107.uint_0, array4, 1, ref int_1);
				if (array4[0] == 0)
				{
					continue;
				}
				num5++;
				uint num13 = num2 + num10 * 20;
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num13 + GameConfigurationManager.memorySignatureScanConfig_100.uint_0 - 8, array4, 1, ref int_1);
				if (array4[0] != 3)
				{
					continue;
				}
				if (0 <= int_0)
				{
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num12 + GameConfigurationManager.memorySignatureScanConfig_108.uint_0, array3, 4, ref int_1);
					int num14 = BitConverter.ToInt32(array3, 0);
					if (num14 != int_0)
					{
						continue;
					}
				}
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num13 + GameConfigurationManager.memorySignatureScanConfig_100.uint_0 - 4, array4, 1, ref int_1);
				int num15 = array4[0];
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num13 + GameConfigurationManager.memorySignatureScanConfig_100.uint_0, array4, 1, ref int_1);
				int num16 = array4[0];
				if (array != null)
				{
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num12 + GameConfigurationManager.memorySignatureScanConfig_107.uint_0, byte_, num, ref int_1);
					string text = GameTextEncodingHelper.DecodeNullTerminatedUtf7(byte_);
					string text2 = text.Trim().ToLower();
					for (int j = 0; j < array.Length; j++)
					{
						if (!(text == array[j]) && !(text2 == array2[j]))
						{
							if (!bool_0)
							{
								if (0 <= text2.IndexOf(array2[j]))
								{
									num6 = num11;
									int_2 = num15;
									int_3 = num16;
									break;
								}
								if (0 <= array2[j].IndexOf(text2))
								{
									num7 = num11;
									num8 = num15;
									num9 = num16;
									break;
								}
							}
							continue;
						}
						return UseInventoryItemByRecordIndexAndPosition(characterAccountConfig_0, num11, num15, num16);
					}
				}
				if (!bool_1 && (num6 != 0 || num7 != 0))
				{
					break;
				}
			}
			if (num6 == 0 && num7 != 0)
			{
				num6 = num7;
				int_2 = num8;
				int_3 = num9;
			}
			if (num6 == 0)
			{
				return false;
			}
			return UseInventoryItemByRecordIndexAndPosition(characterAccountConfig_0, num6, int_2, int_3);
		}
		return false;
	}

	private static uint CreateInventoryItemMoveRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		characterAccountConfig_0.uint_18 += 4u;
		uint num = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		uint num2 = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_102.uint_0 - (num + 50);
		string string_ = "60B9" + CommonUtility.FormatIntegerAsHex(num - 4, 8, bool_1: false, bool_2: true) + "80 39 00 75 31 C6 01 018B0D" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, 8, bool_1: false, bool_2: true) + "85 C9 74 1D81C1" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_12.uint_0, 8, bool_1: false, bool_2: true) + "55 89 E5 6A 00 6A 00 6A 01 6A 02 6A 02 6A 03E8" + CommonUtility.FormatIntegerAsHex(num2, 8, bool_1: false, bool_2: true) + "89 EC 5DC605" + CommonUtility.FormatIntegerAsHex(num - 4, 8, bool_1: false, bool_2: true) + "0061" + BuildRemoteStubExitSuffix(characterAccountConfig_0.uint_98);
		int int_ = 0;
		byte[] array = CommonUtility.ParseHexBytePattern(string_, bool_1: false);
		bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num, array, array.Length, ref int_);
		characterAccountConfig_0.uint_18 += (uint)(array.Length + 4);
		return num * Convert.ToByte(flag && characterAccountConfig_0.uint_17 != 0 && GameConfigurationManager.memorySignatureScanConfig_102.uint_0 != 0);
	}

	public static void MoveInventoryItemBetweenPositions(CharacterAccountConfig characterAccountConfig_0, uint uint_54, uint uint_55, uint uint_56, uint uint_57, uint uint_58, uint uint_59)
	{
		if (characterAccountConfig_0.uint_18 != 0 && characterAccountConfig_0.uint_44 != 0 && IsGameSessionReady(characterAccountConfig_0))
		{
			int int_ = 0;
			int num = 0;
			byte[] array = new byte[1];
			while (WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_44 - 4, array, 1, ref int_) && array[0] > 0 && num < 150)
			{
				Thread.Sleep(1);
				num++;
			}
			byte[] byte_ = new byte[1] { (byte)uint_57 };
			byte[] byte_2 = new byte[1] { (byte)uint_58 };
			byte[] byte_3 = new byte[1] { (byte)uint_59 };
			byte[] byte_4 = new byte[1] { (byte)uint_54 };
			byte[] byte_5 = new byte[1] { (byte)uint_55 };
			byte[] byte_6 = new byte[1] { (byte)uint_56 };
			bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_44 + 34, byte_2, 1, ref int_);
			bool flag2 = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_44 + 36, byte_, 1, ref int_);
			bool flag3 = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_44 + 38, byte_3, 1, ref int_);
			bool flag4 = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_44 + 40, byte_5, 1, ref int_);
			bool flag5 = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_44 + 42, byte_4, 1, ref int_);
			bool flag6 = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_44 + 44, byte_6, 1, ref int_);
			if (flag && flag2 && flag3 && flag4 && flag5 && flag6)
			{
				ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_44);
			}
		}
	}

	private static uint CreateObjectPickupRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		characterAccountConfig_0.uint_18 += 4u;
		uint num = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		uint num2 = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_142.uint_0 - (num + 44);
		string string_ = "60B8" + CommonUtility.FormatIntegerAsHex(num - 4, 8, bool_1: false, bool_2: true) + "80 38 00 75 2B C6 00 01 B8 00 00 00 008B0D" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, 8, bool_1: false, bool_2: true) + "85 C9 74 1281C1" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_12.uint_0, 8, bool_1: false, bool_2: true) + "55 89 E5 50E8" + CommonUtility.FormatIntegerAsHex(num2, 8, bool_1: false, bool_2: true) + "89 EC 5DC605" + CommonUtility.FormatIntegerAsHex(num - 4, 8, bool_1: false, bool_2: true) + "0061" + BuildRemoteStubExitSuffix(characterAccountConfig_0.uint_98);
		int int_ = 0;
		byte[] array = CommonUtility.ParseHexBytePattern(string_, bool_1: false);
		bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num, array, array.Length, ref int_);
		characterAccountConfig_0.uint_18 += (uint)(array.Length + 4);
		return num * Convert.ToByte(flag && characterAccountConfig_0.uint_17 != 0 && GameConfigurationManager.memorySignatureScanConfig_142.uint_0 != 0);
	}

	public static void PickupGroundObjectByIndex(CharacterAccountConfig characterAccountConfig_0, uint uint_54 = 0u)
	{
		if (characterAccountConfig_0.uint_43 != 0)
		{
			int int_ = 0;
			byte[] bytes = BitConverter.GetBytes(uint_54);
			if (WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_43 + 15, bytes, bytes.Length, ref int_))
			{
				ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_43);
			}
		}
	}

	private static uint CreatePlayerSayRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		characterAccountConfig_0.uint_18 += 4u;
		uint num = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		characterAccountConfig_0.uint_18 += privateMessageBufferSize;
		uint num2 = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		uint num3 = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_218.uint_0 - (num2 + 50);
		string string_ = "60B8" + CommonUtility.FormatIntegerAsHex(num2 - 4, 8, bool_1: false, bool_2: true) + "80 38 00 75 31 C6 00 01B8" + CommonUtility.FormatIntegerAsHex(num, 8, bool_1: false, bool_2: true) + "BF" + CommonUtility.FormatIntegerAsHex(num + 32, 8, bool_1: false, bool_2: true) + "8B D7 8A 1A 84 DB 74 03 42 EB F7 2B D7 7E 0E 55 89 E5 52 57 50E8" + CommonUtility.FormatIntegerAsHex(num3, 8, bool_1: false, bool_2: true) + "89 EC 5DC605" + CommonUtility.FormatIntegerAsHex(num2 - 4, 8, bool_1: false, bool_2: true) + "0061" + BuildRemoteStubExitSuffix(characterAccountConfig_0.uint_98);
		int int_ = 0;
		byte[] array = CommonUtility.ParseHexBytePattern(string_, bool_1: false);
		bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num2, array, array.Length, ref int_);
		characterAccountConfig_0.uint_18 += (uint)(array.Length + 4);
		return num2 * Convert.ToByte(flag && characterAccountConfig_0.uint_17 != 0 && GameConfigurationManager.memorySignatureScanConfig_218.uint_0 != 0);
	}

	public static void SendPrivatePlayerMessage(CharacterAccountConfig characterAccountConfig_0, string string_0, string string_1)
	{
		if (characterAccountConfig_0.uint_18 != 0 && characterAccountConfig_0.uint_83 != 0 && string_0 != null && !(string_0 == string.Empty) && string_1 != null && !(string_1 == string.Empty))
		{
			if (127 <= string_1.Length)
			{
				string_1 = string_1.Substring(0, 126);
			}
			if (privateMessageBufferSize <= string_1.Length)
			{
				string_1 = string_1.Substring(0, (int)(privateMessageBufferSize - 1));
			}
			int int_ = 0;
			byte[] array = CommonUtility.ConvertStringToSingleByteArray(string_1);
			bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_83 - privateMessageBufferSize + 32, array, array.Length, ref int_);
			byte[] array2 = CommonUtility.ConvertStringToSingleByteArray(string_0);
			bool flag2 = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_83 - privateMessageBufferSize, array2, array2.Length, ref int_);
			if (flag && flag2)
			{
				ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_83);
			}
		}
	}

	private static uint CreatePlayerPrintRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		characterAccountConfig_0.uint_18 += 4u;
		uint num = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		characterAccountConfig_0.uint_18 += uint_1;
		uint num2 = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		uint num3 = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_219.uint_0 - (num2 + 40);
		string string_ = "60B8" + CommonUtility.FormatIntegerAsHex(num2 - 4, 8, bool_1: false, bool_2: true) + "80 38 00 75 27 C6 00 01 B8 00 00 00 00BA" + CommonUtility.FormatIntegerAsHex(num, 8, bool_1: false, bool_2: true) + "B9 01 00 00 00 55 89 E5 51 50 52E8" + CommonUtility.FormatIntegerAsHex(num3, 8, bool_1: false, bool_2: true) + "89 EC 5DC605" + CommonUtility.FormatIntegerAsHex(num2 - 4, 8, bool_1: false, bool_2: true) + "0061" + BuildRemoteStubExitSuffix(characterAccountConfig_0.uint_98);
		int int_ = 0;
		byte[] array = CommonUtility.ParseHexBytePattern(string_, bool_1: false);
		bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num2, array, array.Length, ref int_);
		characterAccountConfig_0.uint_18 += (uint)(array.Length + 4);
		return num2 * Convert.ToByte(flag && characterAccountConfig_0.uint_17 != 0 && characterAccountConfig_0.uint_7 != 0 && GameConfigurationManager.memorySignatureScanConfig_219.uint_0 != 0);
	}

	public static void PrintGameMessage(CharacterAccountConfig characterAccountConfig_0, string string_0, int int_0 = 1)
	{
		if (characterAccountConfig_0.uint_18 != 0 && characterAccountConfig_0.uint_82 != 0 && string_0 != null)
		{
			if (uint_1 <= string_0.Length - 1)
			{
				string_0 = string_0.Substring(0, (int)(uint_1 - 1));
			}
			int int_1 = 0;
			byte[] array = CommonUtility.ConvertStringToSingleByteArray(string_0);
			byte[] bytes = BitConverter.GetBytes(string_0.Length);
			byte[] bytes2 = BitConverter.GetBytes(int_0);
			bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_82 - uint_1, array, array.Length, ref int_1);
			bool flag2 = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_82 + 15, bytes, 4, ref int_1);
			bool flag3 = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_82 + 25, bytes2, 4, ref int_1);
			if (flag && flag2 && flag3)
			{
				ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_82);
			}
		}
	}

	private static uint CreatePlayerChatRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		characterAccountConfig_0.uint_18 += 4u;
		uint num = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		characterAccountConfig_0.uint_18 += playerChatBufferSize;
		uint num2 = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		uint num3 = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_217.uint_0 - (num2 + 31);
		string string_ = "60B8" + CommonUtility.FormatIntegerAsHex(num2 - 4, 8, bool_1: false, bool_2: true) + "80 38 00 75 1E C6 00 01 55 89 E5 6A 0068" + CommonUtility.FormatIntegerAsHex(num, 8, bool_1: false, bool_2: true) + "6A 01E8" + CommonUtility.FormatIntegerAsHex(num3, 8, bool_1: false, bool_2: true) + "89 EC 5DC605" + CommonUtility.FormatIntegerAsHex(num2 - 4, 8, bool_1: false, bool_2: true) + "0061" + BuildRemoteStubExitSuffix(characterAccountConfig_0.uint_98);
		int int_ = 0;
		byte[] array = CommonUtility.ParseHexBytePattern(string_, bool_1: false);
		bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num2, array, array.Length, ref int_);
		characterAccountConfig_0.uint_18 += (uint)(array.Length + 4);
		return num2 * Convert.ToByte(flag && characterAccountConfig_0.uint_17 != 0 && GameConfigurationManager.memorySignatureScanConfig_217.uint_0 != 0);
	}

	public static void SendChatMessageByChannelId(CharacterAccountConfig characterAccountConfig_0, string string_0, int int_0)
	{
		if (characterAccountConfig_0.uint_18 != 0 && characterAccountConfig_0.uint_81 != 0)
		{
			if (string_0.Length >= 127)
			{
				string_0 = string_0.Substring(0, 126);
			}
			if (string_0.Length >= playerChatBufferSize)
			{
				string_0 = string_0.Substring(0, (int)(playerChatBufferSize - 1));
			}
			int int_1 = 0;
			byte[] array = CommonUtility.ConvertStringToSingleByteArray(string_0);
			byte[] byte_ = new byte[1] { (byte)string_0.Length };
			byte[] byte_2 = new byte[1] { (byte)int_0 };
			bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_81 - playerChatBufferSize, array, array.Length, ref int_1);
			bool flag2 = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_81 + 18, byte_, 1, ref int_1);
			bool flag3 = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_81 + 25, byte_2, 1, ref int_1);
			if (flag && flag2 && flag3)
			{
				ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_81);
			}
		}
	}

	public static void SendChatMessage(CharacterAccountConfig characterAccountConfig_0, string string_0, object object_0 = null)
	{
		if (object_0 == null)
		{
			object_0 = 1;
		}
		if (object_0.GetType() != string.Empty.GetType())
		{
			SendChatMessageByChannelId(characterAccountConfig_0, string_0, (int)object_0);
			return;
		}
		ExecuteGameScript(characterAccountConfig_0, "Chat('" + object_0.ToString() + "', '" + string_0 + "')");
	}

	private static uint CreateDoScriptRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		characterAccountConfig_0.uint_18 += 4u;
		uint num = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		characterAccountConfig_0.uint_18 += gameScriptBufferSize;
		uint num2 = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		uint num3 = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_221.uint_0 - (num2 + 27);
		string string_ = "60B8" + CommonUtility.FormatIntegerAsHex(num2 - 4, 8, bool_1: false, bool_2: true) + "80 38 00 75 1A C6 00 01 55 89 E568" + CommonUtility.FormatIntegerAsHex(num, 8, bool_1: false, bool_2: true) + "E8" + CommonUtility.FormatIntegerAsHex(num3, 8, bool_1: false, bool_2: true) + "89 EC 5DC605" + CommonUtility.FormatIntegerAsHex(num2 - 4, 8, bool_1: false, bool_2: true) + "0061" + BuildRemoteStubExitSuffix(characterAccountConfig_0.uint_98);
		int int_ = 0;
		byte[] array = CommonUtility.ParseHexBytePattern(string_, bool_1: false);
		bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num2, array, array.Length, ref int_);
		characterAccountConfig_0.uint_18 += (uint)(array.Length + 4);
		return num2 * Convert.ToByte(flag && characterAccountConfig_0.uint_17 != 0 && GameConfigurationManager.memorySignatureScanConfig_221.uint_0 != 0);
	}

	public static void ExecuteGameScript(CharacterAccountConfig characterAccountConfig_0, string string_0)
	{
		if (characterAccountConfig_0.uint_84 == 0 || string_0 == null)
		{
			return;
		}
		if (string_0.Length > 126)
		{
			string_0 = string_0.Substring(0, 126);
		}
		if (gameScriptBufferSize <= string_0.Length)
		{
			string_0 = string_0.Substring(0, (int)(gameScriptBufferSize - 1));
		}
		int int_ = 0;
		int num = 0;
		byte[] array = new byte[1];
		while (true)
		{
			if (!CommonUtility.bool_0)
			{
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_84 - 4, array, 1, ref int_);
				if (array[0] != 0)
				{
					num++;
					if (num <= 150)
					{
						Thread.Sleep(1);
						continue;
					}
					break;
				}
			}
			array = CommonUtility.ConvertStringToSingleByteArray(string_0);
			if (WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_84 - gameScriptBufferSize, array, array.Length, ref int_))
			{
				ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_84);
			}
			break;
		}
	}

	private static uint CreateMenuClickRemoteStub(ref CharacterAccountConfig characterAccountConfig_0, int int_0)
	{
		characterAccountConfig_0.uint_18 += 4u;
		uint num = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		uint num2 = GameConfigurationManager.memorySignatureScanConfig_147.uint_0;
		uint num3 = GameConfigurationManager.memorySignatureScanConfig_147.uint_0;
		uint num4 = GameConfigurationManager.memorySignatureScanConfig_144.uint_0;
		if (int_0 > 0)
		{
			num3 = GameConfigurationManager.memorySignatureScanConfig_149.uint_0;
			num4 = GameConfigurationManager.memorySignatureScanConfig_145.uint_0;
			num2 = GameConfigurationManager.memorySignatureScanConfig_151.uint_0;
		}
		int int_1 = 0;
		long num5 = CommonUtility.ParseInt64OrZero(GameConfigurationManager.int_5.ToString() + GameConfigurationManager.int_6);
		byte b = Convert.ToByte(GClass1.long_1 > num5);
		uint num6 = characterAccountConfig_0.uint_7 + num4 - (uint)(Convert.ToByte(b == 0) * 256);
		uint num7 = num + 47;
		uint num8 = num6 - num7;
		string string_ = "60B9" + CommonUtility.FormatIntegerAsHex(num - 4, 8, bool_1: false, bool_2: true) + "80 39 00 75 2F C6 01 018B0D" + CommonUtility.FormatIntegerAsHex(characterAccountConfig_0.uint_7 + num3, 8, bool_1: false, bool_2: true) + "85 C9 74 1A BA 00 00 00 00833D" + CommonUtility.FormatIntegerAsHex(characterAccountConfig_0.uint_7 + num2, 8, bool_1: false, bool_2: true) + "0074 0C55 89 E5 52E8" + CommonUtility.FormatIntegerAsHex(num8, 8, bool_1: false, bool_2: true) + "89 EC 5DC605" + CommonUtility.FormatIntegerAsHex(num - 4, 8, bool_1: false, bool_2: true) + "0061" + BuildRemoteStubExitSuffix(characterAccountConfig_0.uint_98);
		byte[] array = CommonUtility.ParseHexBytePattern(string_, bool_1: false);
		bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num, array, array.Length, ref int_1);
		characterAccountConfig_0.uint_18 += (uint)(array.Length + 4);
		return num * Convert.ToByte(flag && characterAccountConfig_0.uint_17 != 0);
	}

	public static bool SelectMenuOptionByLayout(CharacterAccountConfig characterAccountConfig_0, int int_0, int int_1)
	{
		int int_2 = 0;
		byte[] array = new byte[1];
		byte[] array2 = new byte[4];
		uint num = GameConfigurationManager.memorySignatureScanConfig_147.uint_0;
		uint num2 = characterAccountConfig_0.uint_75;
		if (int_1 > 0)
		{
			num2 = characterAccountConfig_0.uint_76;
			num = GameConfigurationManager.memorySignatureScanConfig_151.uint_0;
		}
		if (num2 == 0)
		{
			return false;
		}
		for (int i = 0; i < 300; i++)
		{
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num2 - 4, array, 1, ref int_2);
			if (array[0] == 0)
			{
				break;
			}
			Thread.Sleep(1);
		}
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_7 + num, array2, 4, ref int_2);
		if (BitConverter.ToUInt32(array2, 0) != 0 && array[0] == 0)
		{
			array2 = BitConverter.GetBytes(int_0);
			if (!WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num2 + 25, array2, 4, ref int_2))
			{
				return false;
			}
			bool result = ExecuteRemoteStub(characterAccountConfig_0.int_137, num2);
			for (int j = 0; j < 300; j++)
			{
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_7 + num, array2, 4, ref int_2);
				if (BitConverter.ToInt32(array2, 0) == 0)
				{
					break;
				}
				Thread.Sleep(1);
			}
			return result;
		}
		return false;
	}

	private static uint CreateRunToRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		characterAccountConfig_0.uint_18 += 4u;
		uint num = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		uint num2 = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_223.uint_0 - (num + 71);
		string string_ = "60B9" + CommonUtility.FormatIntegerAsHex(num - 4, 8, bool_1: false, bool_2: true) + "80 39 00 75 46 C6 01 018B0D" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, 8, bool_1: false, bool_2: true) + "85 C9 74 328B89" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_13.uint_0, 8, bool_1: false, bool_2: true) + "85 C9 74 28A1" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_14.uint_0, 8, bool_1: false, bool_2: true) + "85 C0 74 1F69C9" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_15.uint_0, 8, bool_1: false, bool_2: true) + "01 C1 55 89 E5 6A 00 68 9E A3 01 00 68 4A A7 00 00E8" + CommonUtility.FormatIntegerAsHex(num2, 8, bool_1: false, bool_2: true) + "89 EC 5DC605" + CommonUtility.FormatIntegerAsHex(num - 4, 8, bool_1: false, bool_2: true) + "0061" + BuildRemoteStubExitSuffix(characterAccountConfig_0.uint_98);
		int int_ = 0;
		byte[] array = CommonUtility.ParseHexBytePattern(string_, bool_1: false);
		bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num, array, array.Length, ref int_);
		characterAccountConfig_0.uint_18 += (uint)(array.Length + 4);
		return num * Convert.ToByte(flag && characterAccountConfig_0.uint_17 != 0);
	}

	public static void RunToCoordinates(CharacterAccountConfig characterAccountConfig_0, uint[] uint_54)
	{
		if (characterAccountConfig_0.uint_51 != 0 && uint_54 != null && uint_54[0] != 0 && uint_54[1] != 0 && IsGameSessionReady(characterAccountConfig_0))
		{
			int int_ = 0;
			byte[] bytes = BitConverter.GetBytes(uint_54[0]);
			byte[] bytes2 = BitConverter.GetBytes(uint_54[1]);
			bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_51 + 57, bytes2, 4, ref int_);
			bool flag2 = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_51 + 62, bytes, 4, ref int_);
			if (CommonUtility.ParseInt64OrZero(GameConfigurationManager.int_5.ToString() + GameConfigurationManager.int_6) < GClass1.long_1)
			{
				characterAccountConfig_0.uint_51++;
			}
			if (flag && flag2)
			{
				ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_51);
			}
		}
	}

	private static uint CreateCoordinateMovementRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		characterAccountConfig_0.uint_18 += 4u;
		uint num = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		uint num2 = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_225.uint_0 - (num + 47);
		string string_ = "60B9" + CommonUtility.FormatIntegerAsHex(num - 4, 8, bool_1: false, bool_2: true) + "80 39 00 75 2E C6 01 018B0D" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_236.uint_0, 8, bool_1: false, bool_2: true) + "83 F9 00 74 19 B8 FF FF FF FF BB FF FF FF FF 55 89 E5 53 50 6A 7EE8" + CommonUtility.FormatIntegerAsHex(num2, 8, bool_1: false, bool_2: true) + "89 EC 5DC605" + CommonUtility.FormatIntegerAsHex(num - 4, 8, bool_1: false, bool_2: true) + "0061" + BuildRemoteStubExitSuffix(characterAccountConfig_0.uint_98);
		int int_ = 0;
		byte[] array = CommonUtility.ParseHexBytePattern(string_, bool_1: false);
		bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num, array, array.Length, ref int_);
		characterAccountConfig_0.uint_18 += (uint)(array.Length + 4);
		return num * Convert.ToByte(flag && characterAccountConfig_0.uint_17 != 0);
	}

	public static bool InvokeCoordinateMovement(CharacterAccountConfig characterAccountConfig_0, uint[] uint_54)
	{
		if (uint_54 != null && characterAccountConfig_0.uint_88 != 0 && IsGameSessionReady(characterAccountConfig_0))
		{
			int num = (int)Math.Round((decimal)uint_54[0] / 32m);
			int num2 = (int)Math.Round((decimal)uint_54[1] / 32m);
			if (num > 0 && num2 > 0)
			{
				int int_ = 0;
				byte[] bytes = BitConverter.GetBytes(num);
				byte[] bytes2 = BitConverter.GetBytes(num2);
				bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_88 + 26, bytes, 4, ref int_);
				bool flag2 = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_88 + 31, bytes2, 4, ref int_);
				if (flag && flag2)
				{
					return ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_88);
				}
				return false;
			}
			return false;
		}
		return false;
	}

	public static bool InvokeCraftingBoxAction(CharacterAccountConfig characterAccountConfig_0)
	{
		if (characterAccountConfig_0.uint_17 != 0 && GameConfigurationManager.memorySignatureScanConfig_182.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_262.uint_0 != 0 && characterAccountConfig_0.uint_91 != 0)
		{
			return ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_91);
		}
		return false;
	}

	private static uint CreateCraftingBoxRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		characterAccountConfig_0.uint_18 += 4u;
		string string_ = "33 C0 50 6A 01 50 6A 56 40A3" + CommonUtility.FormatIntegerAsHex(characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_262.uint_0, 8, bool_1: false, bool_2: true);
		string string_2 = "83 C4 10";
		return CreateRemoteCallStub(ref characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_182.uint_0, string_, string_2);
	}

	private static uint CreateHuyenTinhModeZeroRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		characterAccountConfig_0.uint_18 += 4u;
		uint num = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		characterAccountConfig_0.uint_18 += 48u;
		string string_ = "B9" + CommonUtility.FormatIntegerAsHex(num, 8, bool_1: false, bool_2: true) + "8B 01 85 C0 75 23 40 89 01 83 C1 04 8B C18B 0D" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_236.uint_0, 8, bool_1: false, bool_2: true) + "85 C9 74 0A 6A 00 50 6A 65";
		string string_2 = "C6 05" + CommonUtility.FormatIntegerAsHex(num, 8, bool_1: false, bool_2: true) + "00";
		return CreateRemoteCallStub(ref characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_225.uint_0, string_, string_2);
	}

	public static bool InvokeHuyenTinhModeZeroAction(CharacterAccountConfig characterAccountConfig_0, uint uint_54, uint uint_55, uint uint_56)
	{
		if (characterAccountConfig_0.uint_17 != 0 && GameConfigurationManager.memorySignatureScanConfig_225.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_236.uint_0 != 0 && characterAccountConfig_0.uint_48 != 0)
		{
			uint num = characterAccountConfig_0.uint_48 - 48;
			int int_ = 0;
			byte[] array = new byte[1];
			if (WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num, array, 1, ref int_) && array[0] <= 0)
			{
				array = new byte[8] { 0, 0, 0, 0, 3, 0, 0, 0 };
				byte[] bytes = BitConverter.GetBytes(uint_54);
				byte[] bytes2 = BitConverter.GetBytes(uint_55);
				byte[] bytes3 = BitConverter.GetBytes(uint_56);
				if (WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num + 4, array, 8, ref int_) && WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num + 4 + 8, bytes, 4, ref int_) && WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num + 4 + 12, bytes2, 4, ref int_) && WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num + 4 + 16, bytes3, 4, ref int_))
				{
					return ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_48);
				}
				return false;
			}
			return false;
		}
		return false;
	}

	private static uint CreateHuyenTinhModeOneRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		characterAccountConfig_0.uint_18 += 4u;
		uint num = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		characterAccountConfig_0.uint_18 += 48u;
		string string_ = "B8" + CommonUtility.FormatIntegerAsHex(num, 8, bool_1: false, bool_2: true) + "80 38 0075 218B 0D" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_236.uint_0, 8, bool_1: false, bool_2: true) + "85 C974 17C6 00 0183 C0 046A 0050 6A 65";
		string string_2 = "C6 05" + CommonUtility.FormatIntegerAsHex(num, 8, bool_1: false, bool_2: true) + "00";
		return CreateRemoteCallStub(ref characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_225.uint_0, string_, string_2);
	}

	public static bool InvokeHuyenTinhModeOneAction(CharacterAccountConfig characterAccountConfig_0, uint uint_54, uint uint_55, uint uint_56)
	{
		if (characterAccountConfig_0.uint_17 != 0 && GameConfigurationManager.memorySignatureScanConfig_225.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_236.uint_0 != 0 && characterAccountConfig_0.uint_49 != 0)
		{
			uint num = characterAccountConfig_0.uint_49 - 48;
			int int_ = 0;
			byte[] array = new byte[1];
			if (WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num, array, 1, ref int_) && array[0] <= 0)
			{
				array = new byte[8] { 1, 0, 0, 0, 3, 0, 0, 0 };
				byte[] bytes = BitConverter.GetBytes(uint_54);
				byte[] bytes2 = BitConverter.GetBytes(uint_55);
				byte[] bytes3 = BitConverter.GetBytes(uint_56);
				if (WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num + 4, array, array.Length, ref int_) && WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num + 4 + 8, bytes, 4, ref int_) && WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num + 4 + 8 + 4, bytes2, 4, ref int_) && WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num + 4 + 8 + 4 + 4, bytes3, 4, ref int_))
				{
					return ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_49);
				}
				return false;
			}
			return false;
		}
		return false;
	}

	private static uint CreateItemSplitRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		characterAccountConfig_0.uint_18 += 4u;
		string string_ = "B8 00 00 00 00BA 00 00 00 008B 0D" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_236.uint_0, 8, bool_1: false, bool_2: true) + "85 C974 17C6 05" + CommonUtility.FormatIntegerAsHex(characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18, 8, bool_1: false, bool_2: true) + "0150526A 59";
		string string_2 = "C6 05" + CommonUtility.FormatIntegerAsHex(characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18, 8, bool_1: false, bool_2: true) + "00";
		characterAccountConfig_0.uint_18 += 4u;
		return CreateRemoteCallStub(ref characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_225.uint_0, string_, string_2);
	}

	public static bool InvokeItemSplitAction(CharacterAccountConfig characterAccountConfig_0, uint uint_54, uint uint_55, byte byte_0 = 89)
	{
		if (characterAccountConfig_0.uint_17 != 0 && GameConfigurationManager.memorySignatureScanConfig_225.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_236.uint_0 != 0 && characterAccountConfig_0.uint_47 != 0)
		{
			int int_ = 0;
			byte[] array = new byte[1];
			if (WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_47 - 4, array, 1, ref int_) && array[0] <= 0)
			{
				array[0] = byte_0;
				if (!WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_47 + 31, array, 1, ref int_))
				{
					return false;
				}
				array = BitConverter.GetBytes(uint_55);
				if (WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_47 + 2, array, 4, ref int_))
				{
					array = BitConverter.GetBytes(uint_54);
					if (WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_47 + 7, array, 4, ref int_))
					{
						return ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_47);
					}
					return false;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	private static uint CreateGuildPushMoneyRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		characterAccountConfig_0.uint_18 += 4u;
		uint num = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		uint num2 = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_192.uint_0 - (num + 53);
		string string_ = "60 B8" + CommonUtility.FormatIntegerAsHex(num - 4, 8, bool_1: false, bool_2: true) + "80 38 00 75 37 C6 00 01B8 05000000B9" + CommonUtility.FormatIntegerAsHex(characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_191.uint_0, 8, bool_1: false, bool_2: true) + "8B 1D" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, 8, bool_1: false, bool_2: true) + "81 C3" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_189.uint_0, 8, bool_1: false, bool_2: true) + "8B 5B" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_190.uint_0, 2, bool_1: false, bool_2: true) + "55 6A 00 6A 00 50 53 6A 01E8" + CommonUtility.FormatIntegerAsHex(num2, 8, bool_1: false, bool_2: true) + "83 C4 04 8B E5 5DC605" + CommonUtility.FormatIntegerAsHex(num - 4, 8, bool_1: false, bool_2: true) + "0061" + BuildRemoteStubExitSuffix(characterAccountConfig_0.uint_98);
		int int_ = 0;
		byte[] array = CommonUtility.ParseHexBytePattern(string_, bool_1: false);
		bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num, array, array.Length, ref int_);
		characterAccountConfig_0.uint_18 += (uint)(array.Length + 4);
		return num * Convert.ToByte(flag && characterAccountConfig_0.uint_17 != 0 && GameConfigurationManager.memorySignatureScanConfig_192.uint_0 != 0);
	}

	public static bool PushMoneyToGuild(CharacterAccountConfig characterAccountConfig_0, int int_0)
	{
		int int_1 = 0;
		byte[] bytes = BitConverter.GetBytes(int_0);
		if (WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_96 + 15, bytes, 4, ref int_1))
		{
			return ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_96);
		}
		return false;
	}

	private static uint CreateGuildEntryRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		if (characterAccountConfig_0.uint_17 != 0 && GameConfigurationManager.memorySignatureScanConfig_188.uint_0 != 0)
		{
			uint num = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
			uint num2 = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18 + 4;
			characterAccountConfig_0.uint_18 += 8u;
			uint num3 = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
			string string_ = "60BA" + CommonUtility.FormatIntegerAsHex(num, 8, bool_1: false, bool_2: true) + "C6 42 04 018B0D" + CommonUtility.FormatIntegerAsHex(characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_188.uint_0, 8, bool_1: false, bool_2: true) + "85 C9 74 19 8B 01 85 C0 74 13 8B 40 1C 85 C0 74 0C 6A 00 6A 04 52 68 15 80 00 00 FF D0C6 05" + CommonUtility.FormatIntegerAsHex(num2, 8, bool_1: false, bool_2: true) + "0061" + BuildRemoteStubExitSuffix(characterAccountConfig_0.uint_98);
			int int_ = 0;
			byte[] array = CommonUtility.ParseHexBytePattern(string_, bool_1: false);
			bool value = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num3, array, array.Length, ref int_);
			num3 *= Convert.ToByte(value);
			characterAccountConfig_0.uint_18 += (uint)(array.Length + 4);
			return num3;
		}
		return 0u;
	}

	public static bool InvokeGuildEntryAction(CharacterAccountConfig characterAccountConfig_0, string string_0, uint uint_54 = 32769u, uint uint_55 = 4u, uint uint_56 = 0u)
	{
		if (characterAccountConfig_0.uint_94 != 0 && GameConfigurationManager.memorySignatureScanConfig_191.uint_0 != 0)
		{
			uint num = CommonUtility.ComputeLegacyStringHash(string_0);
			if (WindowsInteropHelper.WriteProcessUIntValue(characterAccountConfig_0.uint_94 - 8, characterAccountConfig_0.int_137, num))
			{
				WindowsInteropHelper.WriteProcessUIntValue(characterAccountConfig_0.uint_94 + 39, characterAccountConfig_0.int_137, uint_54);
				WindowsInteropHelper.WriteProcessUIntValue(characterAccountConfig_0.uint_94 + 36, characterAccountConfig_0.int_137, uint_55, 1);
				WindowsInteropHelper.WriteProcessUIntValue(characterAccountConfig_0.uint_94 + 34, characterAccountConfig_0.int_137, uint_56, 1);
				return ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_94);
			}
			return false;
		}
		return false;
	}

	private static uint CreateLastChannelPublishRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		uint num2 = num + 80;
		characterAccountConfig_0.uint_18 += uint_1;
		string string_ = "B8 03 00 00 00BA 3B 00 00 008B 35" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_209.uint_0.ToString(), 8, bool_1: false, bool_2: true) + "8D 8E" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_208.uint_0.ToString(), 8, bool_1: false, bool_2: true) + "6A 00 6A 00 51 5268" + CommonUtility.FormatIntegerAsHex(num2.ToString(), 8, bool_1: false, bool_2: true) + "68" + CommonUtility.FormatIntegerAsHex(num.ToString(), 8, bool_1: false, bool_2: true) + "50 8B CE";
		return CreateRemoteCallStub(ref characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_210.uint_0, string_);
	}

	private static uint CreateLastChannelTabSelectionRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		if (characterAccountConfig_0.uint_17 == 0)
		{
			return 0u;
		}
		string string_ = "60B8 000000008B0D" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_209.uint_0.ToString(), 8, bool_1: false, bool_2: true) + "85 C9 74 2B69C0" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_215.uint_0.ToString(), 8, bool_1: false, bool_2: true) + "05" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_216.uint_0.ToString(), 8, bool_1: false, bool_2: true) + "03 C8 6A 00 51 68 65 05 00 00 8B 51 60 8B 12 8B 49 60 8B 42 10 85 C0 74 04 FF D0 EB 03 58 58 58 61" + BuildRemoteStubExitSuffix(characterAccountConfig_0.uint_98);
		byte[] array = CommonUtility.ParseHexBytePattern(string_);
		int int_ = 0;
		uint num = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		byte b = Convert.ToByte(WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num, array, array.Length, ref int_));
		uint num2 = (uint)(b * (array.Length + 4));
		characterAccountConfig_0.uint_18 += num2;
		return num * b;
	}

	private static uint CreateReplyInviteRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		string text = CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_11.uint_0.ToString(), 8, bool_1: false, bool_2: true);
		string text2 = CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_166.uint_0.ToString(), 8, bool_1: false, bool_2: true);
		string string_ = "B9 00 00 00 00 6A 01 51 8B 0D " + text + "81 C1 " + text2;
		return CreateRemoteCallStub(ref characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_220.uint_0, string_);
	}

	private static uint CreateIncreaseSkillLevelRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		characterAccountConfig_0.uint_18 += 4u;
		uint num = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		uint num2 = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_164.uint_0 - (num + 43);
		string string_ = "60B8" + CommonUtility.FormatIntegerAsHex(num - 4, 8, bool_1: false, bool_2: true) + "80 38 00 75 27 C6 00 01BE 96 00 00 008B0D" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, 8, bool_1: false, bool_2: true) + "85 C9 74 0E81C1" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_12.uint_0, 8, bool_1: false, bool_2: true) + "6A 01 56E8" + CommonUtility.FormatIntegerAsHex(num2, 8, bool_1: false, bool_2: true) + "C605" + CommonUtility.FormatIntegerAsHex(num - 4, 8, bool_1: false, bool_2: true) + "0061" + BuildRemoteStubExitSuffix(characterAccountConfig_0.uint_98);
		int int_ = 0;
		byte[] array = CommonUtility.ParseHexBytePattern(string_, bool_1: false);
		bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num, array, array.Length, ref int_);
		characterAccountConfig_0.uint_18 += (uint)(array.Length + 4);
		return num * Convert.ToByte(flag && characterAccountConfig_0.uint_17 != 0 && GameConfigurationManager.memorySignatureScanConfig_164.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_11.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_12.uint_0 != 0);
	}

	public static bool IncreaseSkillLevel(CharacterAccountConfig characterAccountConfig_0, uint uint_54, int int_0)
	{
		if (characterAccountConfig_0.uint_18 != 0 && characterAccountConfig_0.uint_42 != 0)
		{
			if (int_0 > 57)
			{
				int_0 = 57;
			}
			int int_1 = 0;
			byte[] byte_ = new byte[1] { (byte)int_0 };
			byte[] bytes = BitConverter.GetBytes(uint_54);
			WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_42 + 15, bytes, 4, ref int_1);
			WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_42 + 36, byte_, 1, ref int_1);
			return ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_42);
		}
		return false;
	}

	private static uint CreateTeamCreationRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		string text = CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_11.uint_0.ToString(), 8, bool_1: false, bool_2: true);
		string text2 = CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_12.uint_0.ToString(), 8, bool_1: false, bool_2: true);
		string string_ = "8B 0D " + text + " 81 C1 " + text2;
		return CreateRemoteCallStub(ref characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_201.uint_0, string_);
	}

	private static uint CreateTeamLeaveRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		string text = CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_11.uint_0.ToString(), 8, bool_1: false, bool_2: true);
		string text2 = CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_12.uint_0.ToString(), 8, bool_1: false, bool_2: true);
		string string_ = "8B 0D " + text + " 81 C1 " + text2;
		return CreateRemoteCallStub(ref characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_206.uint_0, string_);
	}

	private static uint CreateItemThrowRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		string text = CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_11.uint_0.ToString(), 8, bool_1: false, bool_2: true);
		string text2 = CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_12.uint_0.ToString(), 8, bool_1: false, bool_2: true);
		string string_ = "8B 0D" + text + "81 C1" + text2;
		return CreateRemoteCallStub(ref characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_122.uint_0, string_);
	}

	private static uint CreateClickToRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		string string_ = "6A 00 B9 6D 01 00 00 BA 13 01 00 00 51 52";
		return CreateRemoteCallStub(ref characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_222.uint_0, string_);
	}

	private static uint CreateInventoryItemFunction88RemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		string string_ = "BA 00 00 00 008B 0D" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_236.uint_0.ToString(), 8, bool_1: false, bool_2: true) + "85 C9 74 0A 52 6A 05 6A 58";
		return CreateRemoteCallStub(ref characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_225.uint_0, string_);
	}

	private static uint CreateSpecialFunction71RemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		string string_ = "6A 00 6A 00 6A 47";
		return CreateRemoteCallStub(ref characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_225.uint_0, string_);
	}

	private static uint CreateBoxUnlockRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		if (characterAccountConfig_0.uint_17 != 0)
		{
			uint result = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
			string string_ = "6068 00 00 00 0083 EC 108B 0D" + CommonUtility.FormatIntegerAsHex(characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_187.uint_0, 8, bool_1: false, bool_2: true) + "85 C9 8B 44 24 10 C6 04 24 84 C6 44 24 01 04 89 44 24 02 C7 44 24 06 00 00 00 00 74 0E 8B 11 8B52 10 6A 0E 8D 44 24 04 50 FF D2 83 C4 14 61" + BuildRemoteStubExitSuffix(characterAccountConfig_0.uint_98);
			characterAccountConfig_0.uint_18 += 8u;
			byte[] array = CommonUtility.ParseHexBytePattern(string_);
			int int_ = 0;
			WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, result, array, array.Length, ref int_);
			characterAccountConfig_0.uint_18 += (uint)(array.Length + 4);
			return result;
		}
		return 0u;
	}

	private static uint CreateBoxAcceptRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		return CreateRemoteCallStub(ref characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_185.uint_0, "6A 01", "83 C4 04");
	}

	private static uint CreateIncreaseAttributePointRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		string string_ = "6A 00 68 A1 00 00 00 68 11 01 00 00 B9 74 93 68 11";
		return CreateRemoteCallStub(ref characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_186.uint_0, string_);
	}

	private static uint CreateTradeRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		string string_ = "6A 01 68 00 00 00 00";
		return CreateRemoteCallStub(ref characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_226.uint_0, string_, "83 C4 08");
	}

	private static uint CreateTradeAcceptRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		string text = CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_11.uint_0.ToString(), 8, bool_1: false, bool_2: true);
		string text2 = CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_12.uint_0.ToString(), 8, bool_1: false, bool_2: true);
		string string_ = "6A 01A1" + text + "8D 88" + text2;
		return CreateRemoteCallStub(ref characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_227.uint_0, string_);
	}

	private static uint CreateTradeApplyRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		string text = CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_11.uint_0.ToString(), 8, bool_1: false, bool_2: true);
		string text2 = CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_12.uint_0.ToString(), 8, bool_1: false, bool_2: true);
		string string_ = "6A 01A1" + text + "8D 88" + text2;
		return CreateRemoteCallStub(ref characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_228.uint_0, string_);
	}

	private static uint CreateTradePutMoneyRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		string text = CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_11.uint_0.ToString(), 8, bool_1: false, bool_2: true);
		string text2 = CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_12.uint_0.ToString(), 8, bool_1: false, bool_2: true);
		string string_ = "B9 00 00 00 00 518B 0D" + text + "81 C1" + text2;
		return CreateRemoteCallStub(ref characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_229.uint_0, string_);
	}

	private static uint CreateFollowIndexRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		string string_ = "BB 00000000B9" + CommonUtility.FormatIntegerAsHex(characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18, 8, bool_1: false, bool_2: true) + "C701 01000000 51 6A 00 538B0D" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, 8, bool_1: false, bool_2: true) + "85C9 7E 198B89" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_13.uint_0, 8, bool_1: false, bool_2: true) + "69C9" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_15.uint_0, 8, bool_1: false, bool_2: true) + "030D" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_14.uint_0, 8, bool_1: false, bool_2: true);
		string string_2 = "EB 02 59 59 59 C701 00000000";
		characterAccountConfig_0.uint_18 += 4u;
		return CreateRemoteCallStub(ref characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_233.uint_0, string_, string_2);
	}

	private static uint CreatePrimaryMenuCloseRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		characterAccountConfig_0.uint_18 += 4u;
		uint num = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		uint num2 = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_264.uint_0 - (num + 24);
		string string_ = "60B9" + CommonUtility.FormatIntegerAsHex(num - 4, 8, bool_1: false, bool_2: true) + "80 39 00 75 1A C6 01 01 55 8B EC6A 01E8" + CommonUtility.FormatIntegerAsHex(num2, 8, bool_1: false, bool_2: true) + "83 C4 04 8B E5 5DC605" + CommonUtility.FormatIntegerAsHex(num - 4, 8, bool_1: false, bool_2: true) + "0061" + BuildRemoteStubExitSuffix(characterAccountConfig_0.uint_98);
		int int_ = 0;
		byte[] array = CommonUtility.ParseHexBytePattern(string_, bool_1: false);
		bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num, array, array.Length, ref int_);
		characterAccountConfig_0.uint_18 += (uint)(array.Length + 4);
		return num * Convert.ToByte(flag && characterAccountConfig_0.uint_17 != 0);
	}

	private static uint CreateSecondaryMenuCloseRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		characterAccountConfig_0.uint_18 += 4u;
		uint num = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		string string_ = "60B9" + CommonUtility.FormatIntegerAsHex(num - 4, 8, bool_1: false, bool_2: true) + "80 39 00 75 29 C6 01 018B 0D" + CommonUtility.FormatIntegerAsHex(characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_151.uint_0, 8, bool_1: false, bool_2: true) + "85 C9 74 15 8B 11 85 D2 74 0F 8B 42 24 85 C0 74 08 55 8B EC FF D0 8B E5 5DC605" + CommonUtility.FormatIntegerAsHex(num - 4, 8, bool_1: false, bool_2: true) + "0061" + BuildRemoteStubExitSuffix(characterAccountConfig_0.uint_98);
		int int_ = 0;
		byte[] array = CommonUtility.ParseHexBytePattern(string_, bool_1: false);
		bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num, array, array.Length, ref int_);
		characterAccountConfig_0.uint_18 += (uint)(array.Length + 4);
		return num * Convert.ToByte(flag && characterAccountConfig_0.uint_17 != 0 && GameConfigurationManager.memorySignatureScanConfig_151.uint_0 != 0);
	}

	private static uint CreateReturnCityRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		characterAccountConfig_0.uint_18 += 4u;
		string string_ = "60B9" + CommonUtility.FormatIntegerAsHex((characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18).ToString(), 8, bool_1: false, bool_2: true) + "C6 01 00 51B9" + CommonUtility.FormatIntegerAsHex((characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_234.uint_0).ToString(), 8, bool_1: false, bool_2: true) + "8B C105" + CommonUtility.FormatIntegerAsHex(GameConfigurationManager.memorySignatureScanConfig_235.uint_0.ToString(), 8, bool_1: false, bool_2: true) + "6A 00 50 68 65 05 00 00 89 48 60 8B 11 85 D2 74 09 8B 42 10 85 C0 74 02 FF D059 C6 01 0161" + BuildRemoteStubExitSuffix(characterAccountConfig_0.uint_98);
		characterAccountConfig_0.uint_18 += 4u;
		uint num = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
		int int_ = 0;
		byte[] array = CommonUtility.ParseHexBytePattern(string_, bool_1: false);
		bool value = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num, array, array.Length, ref int_);
		characterAccountConfig_0.uint_18 += (uint)(array.Length + 4);
		return num * Convert.ToByte(value);
	}

	private static uint CreateOpenSpecialFunctionRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		characterAccountConfig_0.uint_18 += 4u;
		string string_ = "B8 12 00 00 00 B9 01 00 00 00 BA 01 00 00 00 6A 00 51 52 50";
		string string_2 = "83 C4 10";
		return CreateRemoteCallStub(ref characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_182.uint_0, string_, string_2);
	}

	private static uint CreateFlagBoxEntryRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		if (GameConfigurationManager.memorySignatureScanConfig_174.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_176.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_175.uint_0 != 0)
		{
			uint num = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
			characterAccountConfig_0.uint_18 += 22u;
			uint num2 = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18 - 4;
			string string_ = "A1" + CommonUtility.FormatIntegerAsHex(characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_174.uint_0, 8, bool_1: false, bool_2: true) + "85 C0 74 3A8B 0D" + CommonUtility.FormatIntegerAsHex(characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_175.uint_0, 8, bool_1: false, bool_2: true) + "85 C9 74 30803D" + CommonUtility.FormatIntegerAsHex(characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_176.uint_0, 8, bool_1: false, bool_2: true) + "0074 27C605" + CommonUtility.FormatIntegerAsHex(num2, 8, bool_1: false, bool_2: true) + "016A 00 6A 00 6A 08 6A 03 6A 01 5068" + CommonUtility.FormatIntegerAsHex(num, 8, bool_1: false, bool_2: true) + "51";
			string string_2 = "83 C4 20C605" + CommonUtility.FormatIntegerAsHex(num2, 8, bool_1: false, bool_2: true) + "00";
			return CreateRemoteCallStub(ref characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_176.uint_0, string_, string_2);
		}
		return 0u;
	}

	private static uint CreateVanSuThongBoxRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		if (GameConfigurationManager.memorySignatureScanConfig_174.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_176.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_175.uint_0 != 0)
		{
			uint num = characterAccountConfig_0.uint_17 + characterAccountConfig_0.uint_18;
			characterAccountConfig_0.uint_18 += 80u;
			string string_ = "B8" + CommonUtility.FormatIntegerAsHex(characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_177.uint_0, 8, bool_1: false, bool_2: true) + "B9" + CommonUtility.FormatIntegerAsHex(num, 8, bool_1: false, bool_2: true) + "6A 00 6A 01 6A 20 6A 06 6A 01 50 51 51";
			string string_2 = "83 C4 20";
			return CreateRemoteCallStub(ref characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_176.uint_0, string_, string_2);
		}
		return 0u;
	}

	private static uint CreateTongSpecialFunctionRemoteStub(ref CharacterAccountConfig characterAccountConfig_0)
	{
		string string_ = "BA 01 00 00 00 6A 00 52 6A 26";
		return CreateRemoteCallStub(ref characterAccountConfig_0, GameConfigurationManager.memorySignatureScanConfig_196.uint_0, string_);
	}

	public static bool InvokeTongSpecialFunction(CharacterAccountConfig characterAccountConfig_0, uint uint_54)
	{
		if (characterAccountConfig_0.uint_17 != 0 && GameConfigurationManager.memorySignatureScanConfig_196.uint_0 != 0 && characterAccountConfig_0.uint_90 != 0 && IsGameSessionReady(characterAccountConfig_0))
		{
			if (!WindowsInteropHelper.WriteProcessUIntValue(characterAccountConfig_0.uint_90 + 2, characterAccountConfig_0.int_137, uint_54))
			{
				return false;
			}
			return ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_90);
		}
		return false;
	}

	public static bool InvokeInventoryItemFunction88(CharacterAccountConfig characterAccountConfig_0, uint uint_54)
	{
		if (characterAccountConfig_0.uint_17 != 0 && GameConfigurationManager.memorySignatureScanConfig_225.uint_0 != 0 && characterAccountConfig_0.uint_63 != 0 && IsGameSessionReady(characterAccountConfig_0))
		{
			if (!WindowsInteropHelper.WriteProcessUIntValue(characterAccountConfig_0.uint_63 + 2, characterAccountConfig_0.int_137, uint_54))
			{
				return false;
			}
			return ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_63);
		}
		return false;
	}

	public static bool InvokeFlagBoxEntryAction(CharacterAccountConfig characterAccountConfig_0, object object_0 = null)
	{
		if (characterAccountConfig_0.uint_87 != 0 && IsGameSessionReady(characterAccountConfig_0))
		{
			int int_ = 0;
			byte[] array = new byte[1];
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_87 - 4, array, 1, ref int_);
			if (array[0] > 0)
			{
				return false;
			}
			string string_ = "0/0";
			if (object_0 != null)
			{
				if (CommonUtility.FindSubstringIndex(object_0.GetType().ToString(), "[") <= 0)
				{
					string_ = object_0.ToString();
				}
				else
				{
					uint[] array2 = (uint[])object_0;
					decimal num = Math.Round((decimal)array2[0] / 256m);
					decimal num2 = Math.Round((decimal)array2[1] / 512m);
					string_ = num + "/" + num2;
				}
			}
			array = CommonUtility.ConvertStringToSingleByteArray(string_);
			if (!WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_87 - 22, array, array.Length, ref int_))
			{
				return false;
			}
			return ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_87);
		}
		return false;
	}

	public static bool InvokeVanSuThongBoxAction(CharacterAccountConfig characterAccountConfig_0, string string_0)
	{
		if (characterAccountConfig_0.uint_89 != 0 && IsGameSessionReady(characterAccountConfig_0))
		{
			int int_ = 0;
			byte[] array = CommonUtility.ConvertStringToSingleByteArray(string_0);
			if (WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_89 - 80, array, array.Length, ref int_))
			{
				return ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_89);
			}
			return false;
		}
		return false;
	}

	public static bool InvokeOpenSpecialFunction(CharacterAccountConfig characterAccountConfig_0, uint uint_54, uint uint_55 = 1u, uint uint_56 = 1u)
	{
		if (characterAccountConfig_0.uint_17 != 0 && GameConfigurationManager.memorySignatureScanConfig_182.uint_0 != 0 && characterAccountConfig_0.uint_57 != 0)
		{
			bool flag = WindowsInteropHelper.WriteProcessUIntValue(characterAccountConfig_0.uint_57 + 2, characterAccountConfig_0.int_137, uint_54);
			bool flag2 = WindowsInteropHelper.WriteProcessUIntValue(characterAccountConfig_0.uint_57 + 7, characterAccountConfig_0.int_137, uint_55);
			bool flag3 = WindowsInteropHelper.WriteProcessUIntValue(characterAccountConfig_0.uint_57 + 12, characterAccountConfig_0.int_137, uint_56);
			if (flag && flag2 && flag3)
			{
				ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_57);
				return true;
			}
		}
		return false;
	}

    public static bool IncreaseCharacterAttributePoint(CharacterAccountConfig characterAccountConfig_0, object object_0)
    {
        // 1. Kiểm tra điều kiện đầu vào (Check config)
        if (characterAccountConfig_0.uint_17 == 0 ||
            GameConfigurationManager.memorySignatureScanConfig_186.uint_0 == 0 ||
            characterAccountConfig_0.uint_65 == 0 ||
            GameConfigurationManager.memorySignatureScanConfig_96.uint_0 == 0)
        {
            return false;
        }

        uint num = 500u;
        uint num2 = 297u;
        uint[] array = new uint[4] { 151u, 181u, 166u, 196u };
        uint num3 = 0u;

        // 2. Chờ trạng thái mở bảng nhân vật/tiềm năng
        long startTime = CommonUtility.GetCurrentTicks();
        while ((num3 = WindowsInteropHelper.ReadProcessUInt32(characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_96.uint_0, characterAccountConfig_0.int_137)) == 0)
        {
            if (CommonUtility.GetElapsedMilliseconds(startTime) > 3000L) return false;

            ExecuteGameScript(characterAccountConfig_0, "Open([[status]])");
            Thread.Sleep(600);
        }

        // 3. Xác định loại chỉ số (num4) dựa trên object_0
        uint num4 = 0u;
        string inputType = object_0.GetType().ToString().ToUpper();

        // Nếu object_0 không phải là kiểu số (int/Int32)
        if (!inputType.Contains("INT"))
        {
            string text2 = object_0.ToString().ToUpper().Trim();
            switch (text2)
            {
                case "TP":
                case "THANPHAP":
                case "1":
                    num4 = 1u; // Thân pháp
                    break;
                case "SK":
                case "SINHKHI":
                case "2":
                    num4 = 2u; // Sinh khí
                    break;
                case "NC":
                case "NOICONG":
                case "3":
                    num4 = 3u; // Nội công
                    break;
                default:
                    num4 = 0u;
                    break;
            }
        }
        else
        {
            // Nếu truyền vào là số trực tiếp
            num4 = CommonUtility.ParseUInt32OrZero(object_0.ToString());
            if (num4 > 3) num4 = 3u;
        }

        // 4. Thực hiện ghi dữ liệu vào bộ nhớ (Memory Write)
        bool flag = WindowsInteropHelper.WriteProcessUIntValue(characterAccountConfig_0.uint_65 + 2, characterAccountConfig_0.int_137, num4, 1);
        bool flag2 = WindowsInteropHelper.WriteProcessUIntValue(characterAccountConfig_0.uint_65 + 4, characterAccountConfig_0.int_137, array[num4]);
        bool flag3 = WindowsInteropHelper.WriteProcessUIntValue(characterAccountConfig_0.uint_65 + 9, characterAccountConfig_0.int_137, num2);
        bool flag4 = WindowsInteropHelper.WriteProcessUIntValue(characterAccountConfig_0.uint_65 + 14, characterAccountConfig_0.int_137, num3 + num);

        // 5. Xác nhận kết quả
        if (flag && flag2 && flag3 && flag4)
        {
            bool result = ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_65);
            if (result)
            {
                Thread.Sleep(300);
            }
            return result;
        }

        return false;
    }

    public static bool ReturnToCity(CharacterAccountConfig characterAccountConfig_0)
	{
		if (characterAccountConfig_0.uint_17 != 0 && characterAccountConfig_0.uint_80 != 0)
		{
			int int_ = 0;
			byte[] array = new byte[4];
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_11.uint_0, array, 4, ref int_);
			uint num = BitConverter.ToUInt32(array, 0);
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, array, 4, ref int_);
			uint num2 = BitConverter.ToUInt32(array, 0);
			uint num3 = num2 * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_14.uint_0, array, 4, ref int_);
			uint num4 = BitConverter.ToUInt32(array, 0);
			uint num5 = num4 + num3;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num5 + GameConfigurationManager.memorySignatureScanConfig_55.uint_0, array, 4, ref int_);
			int num6 = BitConverter.ToInt32(array, 0);
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num5 + GameConfigurationManager.memorySignatureScanConfig_50.uint_0, array, 4, ref int_);
			int num7 = BitConverter.ToInt32(array, 0);
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_27.uint_0, array, 4, ref int_);
			int num8 = BitConverter.ToInt32(array, 0);
			int num9 = GameInterfaceMemoryHelper.ReadGatewayConnectionState(characterAccountConfig_0);
			if (num7 != 0 && num8 != 0 && num6 != 0 && num9 > 1)
			{
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num5 + GameConfigurationManager.memorySignatureScanConfig_43.uint_0, array, 4, ref int_);
				int num10 = BitConverter.ToInt32(array, 0);
				if (ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_80))
				{
					int int_2 = 0;
					int i = 0;
					byte[] array2 = new byte[1];
					for (; i < 10; i++)
					{
						Thread.Sleep(100);
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_80 - 4, array2, 1, ref int_2);
						if (array2[0] > 0)
						{
							array2[0] = 0;
							WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_80 - 4, array2, 1, ref int_2);
							break;
						}
					}
					i = 0;
					while (!CommonUtility.bool_0 && i < 50)
					{
						Thread.Sleep(300);
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_11.uint_0, array, 4, ref int_);
						num = BitConverter.ToUInt32(array, 0);
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num + GameConfigurationManager.memorySignatureScanConfig_13.uint_0, array, 4, ref int_);
						num2 = BitConverter.ToUInt32(array, 0);
						num3 = num2 * GameConfigurationManager.memorySignatureScanConfig_15.uint_0;
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_14.uint_0, array, 4, ref int_);
						num4 = BitConverter.ToUInt32(array, 0);
						num5 = num4 + num3;
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num5 + GameConfigurationManager.memorySignatureScanConfig_55.uint_0, array, 4, ref int_);
						num6 = BitConverter.ToInt32(array, 0);
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num5 + GameConfigurationManager.memorySignatureScanConfig_50.uint_0, array, 4, ref int_);
						num7 = BitConverter.ToInt32(array, 0);
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num5 + GameConfigurationManager.memorySignatureScanConfig_43.uint_0, array, 4, ref int_);
						int num11 = BitConverter.ToInt32(array, 0);
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_27.uint_0, array, 4, ref int_);
						int num12 = BitConverter.ToInt32(array, 0);
						num9 = GameInterfaceMemoryHelper.ReadGatewayConnectionState(characterAccountConfig_0);
						if (num7 > 0 && num12 > 0 && num6 > 0 && num9 > 1 && (num12 != num8 || num11 != num10))
						{
							break;
						}
						i++;
					}
					return true;
				}
				return false;
			}
			return false;
		}
		return false;
	}

	public static void SetFollowTargetIndex(CharacterAccountConfig characterAccountConfig_0, int int_0)
	{
		if (characterAccountConfig_0.uint_18 != 0 && characterAccountConfig_0.uint_72 != 0 && GameConfigurationManager.memorySignatureScanConfig_11.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_233.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_13.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_15.uint_0 != 0 && GameConfigurationManager.memorySignatureScanConfig_14.uint_0 != 0)
		{
			int int_1 = 0;
			byte[] array = new byte[1];
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_72 - 4, array, 1, ref int_1);
			if (array[0] <= 0)
			{
				WindowsInteropHelper.WriteProcessUIntValue(characterAccountConfig_0.uint_72 + 2, characterAccountConfig_0.int_137, (uint)int_0);
				ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_72);
			}
		}
	}

	public static bool InvokeBoxAcceptAction(CharacterAccountConfig characterAccountConfig_0, bool bool_0 = true)
	{
		if (characterAccountConfig_0.uint_18 != 0 && GameConfigurationManager.memorySignatureScanConfig_185.uint_0 != 0)
		{
			uint num = Convert.ToUInt32(bool_0);
			WindowsInteropHelper.WriteProcessUIntValue(characterAccountConfig_0.uint_64 + 2, characterAccountConfig_0.int_137, num, 1);
			return ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_64);
		}
		return false;
	}

	public static void InvokeTradeAcceptAction(CharacterAccountConfig characterAccountConfig_0, uint uint_54 = 1u)
	{
		if (characterAccountConfig_0.uint_18 != 0 && characterAccountConfig_0.uint_68 != 0)
		{
			if (uint_54 != 1)
			{
				uint_54 = 0u;
			}
			WindowsInteropHelper.WriteProcessUIntValue(characterAccountConfig_0.uint_68 + 2, characterAccountConfig_0.int_137, uint_54, 1);
			ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_68);
		}
	}

	public static void InvokeTradeApplyAction(CharacterAccountConfig characterAccountConfig_0, uint uint_54 = 1u)
	{
		if (characterAccountConfig_0.uint_18 != 0 && characterAccountConfig_0.uint_69 != 0)
		{
			if (uint_54 != 1)
			{
				uint_54 = 0u;
				uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137) + GameConfigurationManager.memorySignatureScanConfig_12.uint_0;
				uint num2 = num + GameConfigurationManager.memorySignatureScanConfig_75.uint_0;
				uint num3 = (4 + GameConfigurationManager.memorySignatureScanConfig_230.uint_0) * 7;
				WindowsInteropHelper.WriteProcessUIntValue(num2 + num3 * 4, characterAccountConfig_0.int_137, 0u);
			}
			WindowsInteropHelper.WriteProcessUIntValue(characterAccountConfig_0.uint_69 + 2, characterAccountConfig_0.int_137, uint_54, 1);
			ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_69);
		}
	}

	public static uint ReadTradeReceivedMoneyValue(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.uint_0, characterAccountConfig_0.int_137) + GameConfigurationManager.memorySignatureScanConfig_12.uint_0;
		uint num2 = num + GameConfigurationManager.memorySignatureScanConfig_75.uint_0;
		uint num3 = (4 + GameConfigurationManager.memorySignatureScanConfig_230.uint_0) * 7;
		return WindowsInteropHelper.ReadProcessUInt32(num2 + num3 * 4, characterAccountConfig_0.int_137);
	}

	public static void InvokeTradePutMoneyAction(CharacterAccountConfig characterAccountConfig_0, uint uint_54)
	{
		if (characterAccountConfig_0.uint_18 != 0 && characterAccountConfig_0.uint_70 != 0)
		{
			WindowsInteropHelper.WriteProcessUIntValue(characterAccountConfig_0.uint_70 + 2, characterAccountConfig_0.int_137, uint_54);
			ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_70);
		}
	}

	public static void InvokeTradeForLatestMessage(CharacterAccountConfig characterAccountConfig_0, string[] string_0 = null)
	{
		if (characterAccountConfig_0.uint_18 == 0 || characterAccountConfig_0.uint_67 == 0)
		{
			return;
		}
		string text = GameMessageReader.ReadMessages(characterAccountConfig_0, includeMessageId: true);
		string[] array = text.Split(';');
		if (array.Length < 2)
		{
			return;
		}
		if (string_0 != null && string_0.Length != 0)
		{
			for (int i = 0; i < string_0.Length; i++)
			{
				if (array[1] == string_0[i] || GameTextEncodingHelper.ConvertGameTextToDisplayText(array[1], 1) == string_0[i])
				{
					GameMessageReader.ClearMessages(characterAccountConfig_0);
					return;
				}
			}
		}
		uint num = CommonUtility.ParseUInt32OrZero(array[0]);
		WindowsInteropHelper.WriteProcessUIntValue(characterAccountConfig_0.uint_67 + 4, characterAccountConfig_0.int_137, num);
		ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_67);
	}

	public static void InvokeClickToAction(CharacterAccountConfig characterAccountConfig_0, uint uint_54, uint uint_55)
	{
		if (characterAccountConfig_0.uint_18 != 0 && characterAccountConfig_0.uint_50 != 0)
		{
			WindowsInteropHelper.WriteProcessUIntValue(characterAccountConfig_0.uint_50 + 4, characterAccountConfig_0.int_137, uint_55);
			WindowsInteropHelper.WriteProcessUIntValue(characterAccountConfig_0.uint_50 + 9, characterAccountConfig_0.int_137, uint_54);
			ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_50);
		}
	}

	public static bool UnlockInventoryBoxWithPasswordCode(CharacterAccountConfig characterAccountConfig_0, uint uint_54)
	{
		if (characterAccountConfig_0.uint_17 != 0 && GameConfigurationManager.memorySignatureScanConfig_187.uint_0 != 0 && characterAccountConfig_0.uint_66 != 0)
		{
			if (WindowsInteropHelper.WriteProcessUIntValue(characterAccountConfig_0.uint_66 + 2, characterAccountConfig_0.int_137, uint_54))
			{
				return ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_66);
			}
			return false;
		}
		return false;
	}

	public static void OpenSpecialFunction34(CharacterAccountConfig characterAccountConfig_0)
	{
		InvokeOpenSpecialFunction(characterAccountConfig_0, 34u);
	}

	public static void OpenSpecialFunction18(CharacterAccountConfig characterAccountConfig_0)
	{
		InvokeOpenSpecialFunction(characterAccountConfig_0, 18u);
	}

	public static void InvokeSpecialFunction71Action(CharacterAccountConfig characterAccountConfig_0)
	{
		if (characterAccountConfig_0.uint_18 != 0 && characterAccountConfig_0.uint_60 != 0)
		{
			ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_60);
		}
	}

	public static void InvokeItemThrowAction(CharacterAccountConfig characterAccountConfig_0)
	{
		if (characterAccountConfig_0.uint_18 != 0 && characterAccountConfig_0.uint_45 != 0)
		{
			ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_45);
		}
	}

	public static string BuildNpcAndObjectDebugDump(CharacterAccountConfig characterAccountConfig_0, bool bool_0 = true)
	{
		string text = "";
		string text2 = "";
		uint[] array = CurrentCharacterMemoryHelper.GetCurrentCharacterPosition(characterAccountConfig_0);
		if (array != null)
		{
			uint uint_ = array[0];
			uint num = array[1];
			uint num2 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.uint_0, characterAccountConfig_0.int_137);
			uint num3 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_126.uint_0, characterAccountConfig_0.int_137);
			int num4 = 25;
			for (int i = 0; i < 256; i++)
			{
				uint num5 = num2 + (uint)(i * (int)GameConfigurationManager.memorySignatureScanConfig_15.uint_0);
				int num6 = (int)WindowsInteropHelper.ReadProcessUInt32(num5 + GameConfigurationManager.memorySignatureScanConfig_50.uint_0, characterAccountConfig_0.int_137);
				if (num6 > 0)
				{
					int num7 = (int)WindowsInteropHelper.ReadProcessUInt32(num5 + GameConfigurationManager.memorySignatureScanConfig_52.uint_0, characterAccountConfig_0.int_137);
					uint num8 = WindowsInteropHelper.ReadProcessUInt32(num5 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig_0.int_137);
					uint num9 = WindowsInteropHelper.ReadProcessUInt32(num5 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig_0.int_137);
					long num10 = CalculateSquaredCoordinateDistance(uint_, num, num8, num9);
					string text3 = "\"" + WindowsInteropHelper.ReadNullTerminatedUtf7ProcessString(num5 + GameConfigurationManager.memorySignatureScanConfig_16.uint_0, characterAccountConfig_0.int_137) + "\"";
					while (text3.Length < num4)
					{
						text3 += " ";
					}
					string text4 = text;
					text = text4 + "-- " + i + "\t" + num7 + "   \t" + text3 + " {" + num8 + "," + num9 + "}, ( " + num8 / 256 + "," + num9 / 512 + " )\t" + num10 + "\t" + Math.Round(Math.Sqrt(num10), 0) + GameConfigurationManager.string_7;
				}
				int num11 = (int)WindowsInteropHelper.ReadProcessUInt32(num3 + (uint)(i * (int)GameConfigurationManager.memorySignatureScanConfig_127.uint_0), characterAccountConfig_0.int_137);
				if (num11 > 0)
				{
					int num12 = WorldObjectMemoryReader.GetObjectKind(characterAccountConfig_0, i, num3);
					uint[] array2 = WorldObjectMemoryReader.GetObjectPosition(characterAccountConfig_0, i, num3);
					if (array2 == null)
					{
						uint[] array3 = new uint[2];
						array2 = array3;
					}
					long num13 = CalculateSquaredCoordinateDistance(uint_, num, array2[0], array2[1]);
					string text5 = "\"" + WorldObjectMemoryReader.GetObjectName(characterAccountConfig_0, i, num3) + "\"";
					while (text5.Length < num4)
					{
						text5 += " ";
					}
					string text6 = text2;
					text2 = text6 + "-- " + i + "\t" + num12 + "   \t" + text5 + " {" + array2[0] + "," + array2[1] + "}, ( " + array2[0] / 256 + "," + array2[1] / 512 + " )\t" + num13 + "\t" + Math.Round(Math.Sqrt(num13), 0) + GameConfigurationManager.string_7;
				}
			}
			string text7 = "Map " + GameMapCatalog.GetCurrentMapId(characterAccountConfig_0) + " = \"" + GameMapCatalog.ReadCurrentMapName(characterAccountConfig_0) + "\"; { " + uint_.ToString() + "," + num + " }" + GameConfigurationManager.string_7 + "=============================================================================================" + GameConfigurationManager.string_7 + "-- STT\tKind\tNPC name    \t\t  {posx, posy}\t   x/y screen\tLength\tSqrt(Length)" + GameConfigurationManager.string_7 + "[npc]" + GameConfigurationManager.string_7 + "=============================================================================================" + GameConfigurationManager.string_7 + "-- STT\tKind\tObject name  \t\t  {posx, posy}\t   x/y screen\tLength\tSqrt(Length)" + GameConfigurationManager.string_7 + "[object]" + GameConfigurationManager.string_7;
			text7 = text7.Replace("[npc]", text).Replace("[object]", text2) + GameConfigurationManager.string_7 + "=============================================================================================";
			if (bool_0)
			{
				string string_ = "Software\\Microsoft\\Notepad";
				string text8 = WindowsRegistryHelper.ReadRegistryValueAsString(string_, "lfFaceName", 0);
				GameConfigurationManager.WriteTextFileAndOptionallyOpenNotepad("object_npc_info.txt", text7, bool_2: true, "VK Sans Serif", 12, 870, 425, 200, 280);
				if (text8 != "")
				{
					WindowsRegistryHelper.SetRegistryValue(string_, "lfFaceName", text8, "", 1);
				}
			}
			return text7;
		}
		return "";
	}

	public static string GetNearestEntityOrObjectDebugInfo(CharacterAccountConfig characterAccountConfig_0, int int_0 = 0)
	{
		uint[] array = CurrentCharacterMemoryHelper.GetCurrentCharacterPosition(characterAccountConfig_0);
		if (array == null)
		{
			return "";
		}
		int num = CurrentCharacterMemoryHelper.GetCurrentPlayerIndex(characterAccountConfig_0);
		uint uint_ = array[0];
		uint uint_2 = array[1];
		uint num2 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.uint_0, characterAccountConfig_0.int_137);
		uint num3 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_126.uint_0, characterAccountConfig_0.int_137);
		int num4 = -1;
		long num5 = 0L;
		long num6 = 0L;
		uint[] array2 = null;
		string text = "";
		int num7 = -1;
		long num8 = 0L;
		long num9 = 0L;
		uint[] array3 = null;
		string text2 = "";
		for (int i = 0; i < 256; i++)
		{
			uint num10 = num2 + (uint)(i * (int)GameConfigurationManager.memorySignatureScanConfig_15.uint_0);
			int num11 = (int)WindowsInteropHelper.ReadProcessUInt32(num10 + GameConfigurationManager.memorySignatureScanConfig_50.uint_0, characterAccountConfig_0.int_137);
			if (i != num && num11 > 0)
			{
				uint[] array4 = new uint[2]
				{
					WindowsInteropHelper.ReadProcessUInt32(num10 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig_0.int_137),
					WindowsInteropHelper.ReadProcessUInt32(num10 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig_0.int_137)
				};
				num6 = CalculateSquaredCoordinateDistance(uint_, uint_2, array4[0], array4[1]);
				if (num4 < 0 || num6 < num5)
				{
					num4 = i;
					num5 = num6;
					array2 = array4;
					text = WindowsInteropHelper.ReadNullTerminatedUtf7ProcessString(num10 + GameConfigurationManager.memorySignatureScanConfig_16.uint_0, characterAccountConfig_0.int_137);
				}
			}
			int num12 = (int)WindowsInteropHelper.ReadProcessUInt32(num3 + (uint)(i * (int)GameConfigurationManager.memorySignatureScanConfig_127.uint_0), characterAccountConfig_0.int_137);
			if (num12 > 0)
			{
				uint[] array5 = WorldObjectMemoryReader.GetObjectPosition(characterAccountConfig_0, i, num3);
				if (array5 == null)
				{
					uint[] array6 = new uint[2];
					array5 = array6;
				}
				num9 = CalculateSquaredCoordinateDistance(uint_, uint_2, array5[0], array5[1]);
				if (num7 < 0 || num9 < num8)
				{
					num7 = i;
					num8 = num9;
					array3 = array5;
					text2 = WorldObjectMemoryReader.GetObjectName(characterAccountConfig_0, i, num3);
				}
			}
		}
		if (num7 > 0 && (num4 < 0 || num8 < num5))
		{
			num4 = num7;
			num5 = num8;
			array2 = array3;
			text = text2;
		}
		string result = "";
		switch (int_0)
		{
		default:
			if (num4 > 0 && array2 != null)
			{
				result = num4 + "|" + text + "|X = " + array2[0] + ", Y = " + array2[1] + "|" + num5;
			}
			break;
		case 2:
			result = "{ X = " + array2[0] + ", Y = " + array2[1] + " }";
			break;
		case 1:
			result = text;
			break;
		}
		return result;
	}

	public static string BuildEntityDebugInfoByIndex(CharacterAccountConfig characterAccountConfig_0, int int_0)
	{
		uint[] array = CurrentCharacterMemoryHelper.GetCurrentCharacterPosition(characterAccountConfig_0);
		if (array == null)
		{
			return "";
		}
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.uint_0, characterAccountConfig_0.int_137);
		WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_126.uint_0, characterAccountConfig_0.int_137);
		uint num2 = num + (uint)(int_0 * (int)GameConfigurationManager.memorySignatureScanConfig_15.uint_0);
		int num3 = (int)WindowsInteropHelper.ReadProcessUInt32(num2 + GameConfigurationManager.memorySignatureScanConfig_50.uint_0, characterAccountConfig_0.int_137);
		int num4 = (int)WindowsInteropHelper.ReadProcessUInt32(num2 + GameConfigurationManager.memorySignatureScanConfig_52.uint_0, characterAccountConfig_0.int_137);
		uint uint_ = WindowsInteropHelper.ReadProcessUInt32(num2 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_58.uint_0, characterAccountConfig_0.int_137);
		uint uint_2 = WindowsInteropHelper.ReadProcessUInt32(num2 + GameConfigurationManager.memorySignatureScanConfig_57.uint_0 + GameConfigurationManager.memorySignatureScanConfig_59.uint_0, characterAccountConfig_0.int_137);
		long num5 = CalculateSquaredCoordinateDistance(array[0], array[1], uint_, uint_2);
		string text = "\"" + WindowsInteropHelper.ReadNullTerminatedUtf7ProcessString(num2 + GameConfigurationManager.memorySignatureScanConfig_16.uint_0, characterAccountConfig_0.int_137) + "\"";
		int num6 = GameMapCatalog.GetCurrentMapId(characterAccountConfig_0);
		return "MapID = " + num6.ToString() + GameConfigurationManager.string_7 + GameMapCatalog.ReadCurrentMapName(characterAccountConfig_0) + GameConfigurationManager.string_7 + "=============================" + GameConfigurationManager.string_7 + "- Exist\t: " + num3.ToString() + GameConfigurationManager.string_7 + "- Kind\t: " + num4.ToString() + GameConfigurationManager.string_7 + "- Name\t: " + text + GameConfigurationManager.string_7 + "- NOPos\t: {" + array[0].ToString() + "," + array[1] + "}" + GameConfigurationManager.string_7 + "- Length\t: " + num5.ToString() + GameConfigurationManager.string_7 + "- Sqrt(L)\t: " + ((int)Math.Sqrt(num5)).ToString();
	}
}
