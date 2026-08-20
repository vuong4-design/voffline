using System;
using System.Threading;
using ns1;
using ns10;
using ns100;
using ns11;
using ns23;
using ns53;
using ns71;
using ns81;
using ns83;
using ns85;

namespace ns44;

internal class InventoryItemHelper
{
	public static int int_0 = 0;

	private static string sharedItemDropName = null;

	public static int int_1 = 0;

	public static int[] GetContainerGridDimensions(uint uint_0 = 3u)
	{
		int[,] array = new int[11, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array, 209866);
		int[,] array2 = array;
		for (int i = 0; i < array2.GetLength(0); i++)
		{
			if (uint_0 == array2[i, 0])
			{
				return new int[2]
				{
					array2[i, 1],
					array2[i, 2]
				};
			}
		}
		return new int[2] { 6, 10 };
	}

	public static bool SupportsDirectContainerTransfer(uint uint_0)
	{
		int[] array = new int[6] { 3, 4, 9, 10, 11, 23 };
		for (int i = 0; i < array.Length; i++)
		{
			if (uint_0 == array[i])
			{
				return true;
			}
		}
		return false;
	}

	private static uint MapContainerIndexToTransferCode(uint uint_0)
	{
		switch (uint_0)
		{
		default:
			return 11u;
		case 0u:
		case 1u:
			return 3u;
		case 2u:
			return 1u;
		case 3u:
			return 7u;
		case 4u:
			return 6u;
		case 5u:
			return 4u;
		case 6u:
			return 2u;
		case 7u:
			return 0u;
		case 8u:
			return 5u;
		case 9u:
			return 9u;
		case 10u:
			return 10u;
		}
	}

	public static bool SubmitDetectedDialogResponse(CharacterAccountConfig characterAccountConfig_0, string string_1 = null)
	{
		if (WindowsInteropHelper.ReadProcessUInt32(characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_172.resolvedValue, characterAccountConfig_0.int_137) == 0)
		{
			return false;
		}
		string text = GetDialogPromptText(characterAccountConfig_0);
		if (text != null && !(text == string.Empty))
		{
			string[] array = new string[2] { "yes", "ok" };
			string[] array2 = text.Split(' ', '"');
			int num = 0;
			while (true)
			{
				if (num < array2.Length)
				{
					int num2 = 0;
					while (num2 < array.Length)
					{
						if (!(array2[num].ToLower() == array[num2]))
						{
							num2++;
							continue;
						}
						goto IL_00bd;
					}
					num++;
					continue;
				}
				string[] array3 = new string[2] { "gâ", "nhËp" };
				for (int i = 0; i < array3.Length; i++)
				{
					bool flag = false;
					for (num = 0; num < array2.Length; num++)
					{
						if (flag)
						{
							if (array2[num] == null || !(array2[num] != string.Empty))
							{
								continue;
							}
							goto IL_0150;
						}
						if (0 <= array2[num].ToLower().IndexOf(array3[i]))
						{
							flag = true;
						}
					}
					continue;
					IL_0150:
					string_1 = array2[num];
					break;
				}
				break;
				IL_00bd:
				string_1 = array2[num];
				break;
			}
		}
		bool result;
		if (result = string_1 != string.Empty && string_1 != null)
		{
			if (string_1[0] > '፻')
			{
				string_1 = CommonUtility.DecodeLengthShiftedString(string_1);
			}
			SetDialogInputText(characterAccountConfig_0, string_1, bool_0: true);
		}
		return result;
	}

	public static string GetDialogPromptText(CharacterAccountConfig characterAccountConfig_0)
	{
		if (characterAccountConfig_0.uint_7 != 0 && GameConfigurationManager.memorySignatureScanConfig_172.resolvedValue != 0 && GameConfigurationManager.memorySignatureScanConfig_173.resolvedValue != 0 && GameConfigurationManager.memorySignatureScanConfig_171.resolvedValue != 0)
		{
			uint num = WindowsInteropHelper.ReadProcessUInt32(characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_172.resolvedValue, characterAccountConfig_0.int_137);
			if (num == 0)
			{
				return string.Empty;
			}
			uint num2 = num + GameConfigurationManager.memorySignatureScanConfig_173.resolvedValue - 40;
			uint uint_ = num2 - 12;
			int int_ = 0;
			byte[] array = new byte[1];
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, uint_, array, 1, ref int_);
			int num3 = array[0];
			if (num3 <= 0)
			{
				num3 = 1;
			}
			array = new byte[num3];
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num2, array, num3, ref int_);
			return GameTextEncodingHelper.DecodeNullTerminatedUtf7(array);
		}
		return string.Empty;
	}

	public static int SetDialogInputText(CharacterAccountConfig characterAccountConfig_0, string string_1, bool bool_0 = false)
	{
		if (characterAccountConfig_0.uint_7 != 0 && GameConfigurationManager.memorySignatureScanConfig_172.resolvedValue != 0 && GameConfigurationManager.memorySignatureScanConfig_173.resolvedValue != 0 && GameConfigurationManager.memorySignatureScanConfig_171.resolvedValue != 0)
		{
			int int_ = 0;
			byte[] array = new byte[4];
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_172.resolvedValue, array, 4, ref int_);
			uint num = BitConverter.ToUInt32(array, 0);
			if (num != 0)
			{
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num + GameConfigurationManager.memorySignatureScanConfig_173.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_171.resolvedValue, array, 4, ref int_);
				uint num2 = BitConverter.ToUInt32(array, 0);
				if (num2 != 0)
				{
					byte[] array2 = CommonUtility.ConvertStringToSingleByteArray(string_1);
					byte[] array3 = new byte[1];
					byte[] byte_ = new byte[1] { (byte)string_1.Length };
					int num3 = 0;
					while (num3 <= 100 && array3[0] == 0)
					{
						num3++;
						Thread.Sleep(1);
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num2, array3, 1, ref int_);
					}
					bool flag = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num2 - 52, byte_, 1, ref int_);
					bool flag2 = WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num2, array2, array2.Length, ref int_);
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num2 - 71, array3, 2, ref int_);
					if (array3[0] == 0)
					{
						array3[0] = 1;
						WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, num2 - 71, array3, 1, ref int_);
					}
					if (bool_0)
					{
						Thread.Sleep(10);
						WindowsInteropHelper.PostKeyPressWithScanCode(characterAccountConfig_0.uint_4, 13u);
					}
					return Convert.ToByte(flag2 && flag);
				}
				if (bool_0)
				{
					WindowsInteropHelper.PostKeyPressWithScanCode(characterAccountConfig_0.uint_4, 13u);
				}
				return 0;
			}
			return 0;
		}
		return -1;
	}

	public static string GetDialogInputText(CharacterAccountConfig characterAccountConfig_0)
	{
		if (characterAccountConfig_0.uint_7 != 0 && GameConfigurationManager.memorySignatureScanConfig_172.resolvedValue != 0 && GameConfigurationManager.memorySignatureScanConfig_173.resolvedValue != 0 && GameConfigurationManager.memorySignatureScanConfig_171.resolvedValue != 0)
		{
			int int_ = 0;
			byte[] array = new byte[4];
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_172.resolvedValue, array, 4, ref int_);
			uint num = BitConverter.ToUInt32(array, 0);
			if (num == 0)
			{
				return null;
			}
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num + GameConfigurationManager.memorySignatureScanConfig_173.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_171.resolvedValue, array, 4, ref int_);
			uint num2 = BitConverter.ToUInt32(array, 0);
			if (num2 != 0)
			{
				int num3 = 0;
				byte[] array2 = new byte[1];
				while (num3 <= 300 && array2[0] == 0)
				{
					num3++;
					Thread.Sleep(1);
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num2, array2, 1, ref int_);
				}
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num2 - 52, array2, 1, ref int_);
				if (array2[0] != 0)
				{
					byte[] byte_ = new byte[array2[0]];
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num2, byte_, array2[0], ref int_);
					return GameTextEncodingHelper.DecodeNullTerminatedUtf7(byte_);
				}
				return string.Empty;
			}
			return null;
		}
		return null;
	}

	public static uint GetShortcutItemRecordIndexBySlot(CharacterAccountConfig characterAccountConfig_0, int int_2)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, characterAccountConfig_0.int_137) + GameConfigurationManager.memorySignatureScanConfig_12.resolvedValue;
		uint num2 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_261.resolvedValue, characterAccountConfig_0.int_137);
		uint result = 0u;
		if (num2 != 0)
		{
			result = WindowsInteropHelper.ReadProcessUInt32(num2 + (uint)(int_2 * 4), characterAccountConfig_0.int_137);
		}
		return result;
	}

	public static bool IsInventoryBoxOpen(CharacterAccountConfig characterAccountConfig_0)
	{
		uint uint_ = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_179.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_180.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_181.resolvedValue;
		uint num = WindowsInteropHelper.ReadProcessUInt32(uint_, characterAccountConfig_0.int_137);
		return num != 0;
	}

	public static int GetCollectionBoxProgressValue(CharacterAccountConfig characterAccountConfig_0)
	{
		uint uint_ = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_158.resolvedValue;
		uint num = WindowsInteropHelper.ReadProcessUInt32(uint_, characterAccountConfig_0.int_137);
		if (num == 0)
		{
			return -1000;
		}
		uint uint_2 = num + GameConfigurationManager.memorySignatureScanConfig_159.resolvedValue;
		return (int)(WindowsInteropHelper.ReadProcessUInt32(uint_2, characterAccountConfig_0.int_137) - 1);
	}

	public static void ShowCollectionBox(CharacterAccountConfig characterAccountConfig_0)
	{
		uint uint_ = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_158.resolvedValue;
		uint num = WindowsInteropHelper.ReadProcessUInt32(uint_, characterAccountConfig_0.int_137);
		if (num != 0)
		{
			uint uint_2 = num + GameConfigurationManager.memorySignatureScanConfig_159.resolvedValue;
			int int_ = 0;
			byte[] byte_ = new byte[4] { 1, 0, 0, 0 };
			WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, uint_2, byte_, 4, ref int_);
		}
	}

	public static bool CloseInventoryBoxAndPrimaryMenu(CharacterAccountConfig characterAccountConfig_0)
	{
		bool result;
		if (result = IsInventoryBoxOpen(characterAccountConfig_0))
		{
			WindowsInteropHelper.PostKeyPressWithScanCode(characterAccountConfig_0.uint_4, 27u);
			Thread.Sleep(999);
		}
		uint uint_ = characterAccountConfig_0.uint_7 + GameConfigurationManager.memorySignatureScanConfig_151.resolvedValue;
		if ((int)WindowsInteropHelper.ReadProcessUInt32(uint_, characterAccountConfig_0.int_137) > 0)
		{
			WindowsInteropHelper.PostKeyPressWithScanCode(characterAccountConfig_0.uint_4, 27u);
		}
		return result;
	}

	public static int GetInventoryBoxItemCount(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_184.resolvedValue, characterAccountConfig_0.int_137);
		uint num2 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_156.resolvedValue, characterAccountConfig_0.int_137);
		return (int)WindowsInteropHelper.ReadProcessUInt32(num2 + GameConfigurationManager.memorySignatureScanConfig_183.resolvedValue, characterAccountConfig_0.int_137);
	}

	public static uint GetHeldItemRecordIndex(CharacterAccountConfig characterAccountConfig_0)
	{
		if (WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_123.resolvedValue, characterAccountConfig_0.int_137) == 0)
		{
			return 0u;
		}
		int int_ = 0;
		byte[] array = new byte[4];
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, array, 4, ref int_);
		uint num = BitConverter.ToUInt32(array, 0) + GameConfigurationManager.memorySignatureScanConfig_97.resolvedValue;
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_105.resolvedValue, array, 4, ref int_);
		uint num2 = BitConverter.ToUInt32(array, 0);
		int num3 = InventoryItemMemoryHelper.GetInventoryEntryCount(characterAccountConfig_0);
		int num4 = 0;
		for (uint num5 = 1u; num5 < GameConfigurationManager.int_1; num5++)
		{
			if (num3 <= num4)
			{
				break;
			}
			uint num6 = num + num5 * 20;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num6 + GameConfigurationManager.memorySignatureScanConfig_99.resolvedValue * 4, array, 4, ref int_);
			uint num7 = BitConverter.ToUInt32(array, 0);
			if (num7 == 0)
			{
				continue;
			}
			uint num8 = num2 + num7 * GameConfigurationManager.memorySignatureScanConfig_106.resolvedValue;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num8 + GameConfigurationManager.memorySignatureScanConfig_106.resolvedValue - 4, array, 4, ref int_);
			if (BitConverter.ToInt32(array, 0) != 0)
			{
				continue;
			}
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num8 + GameConfigurationManager.memorySignatureScanConfig_107.resolvedValue, array, 1, ref int_);
			if (array[0] != 0)
			{
				num4++;
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num6 + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 8, array, 1, ref int_);
				if (array[0] == 1)
				{
					return num5;
				}
			}
		}
		return 0u;
	}

	public static int PlaceHeldItemInAvailableGridSlot(CharacterAccountConfig characterAccountConfig_0, uint uint_0 = 3u)
	{
		int int_ = 0;
		byte[] array = new byte[1];
		byte[] array2 = new byte[4];
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_123.resolvedValue, array2, 4, ref int_);
		if (BitConverter.ToInt32(array2, 0) > 0)
		{
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, array2, 4, ref int_);
			uint num = BitConverter.ToUInt32(array2, 0) + GameConfigurationManager.memorySignatureScanConfig_97.resolvedValue;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_105.resolvedValue, array2, 4, ref int_);
			uint num2 = BitConverter.ToUInt32(array2, 0);
			int num3 = InventoryItemMemoryHelper.GetInventoryEntryCount(characterAccountConfig_0);
			int num4 = 0;
			for (uint num5 = 1u; num5 < GameConfigurationManager.int_1; num5++)
			{
				if (num3 <= num4)
				{
					break;
				}
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num + (num5 * 5 + GameConfigurationManager.memorySignatureScanConfig_99.resolvedValue) * 4, array2, 4, ref int_);
				uint num6 = BitConverter.ToUInt32(array2, 0);
				if (num6 == 0)
				{
					continue;
				}
				uint num7 = num2 + num6 * GameConfigurationManager.memorySignatureScanConfig_106.resolvedValue;
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num7 + GameConfigurationManager.memorySignatureScanConfig_106.resolvedValue - 4, array2, 4, ref int_);
				if (BitConverter.ToInt32(array2, 0) != 0)
				{
					continue;
				}
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num7 + GameConfigurationManager.memorySignatureScanConfig_107.resolvedValue, array, 1, ref int_);
				if (array[0] == 0)
				{
					continue;
				}
				num4++;
				uint num8 = num + num5 * 20;
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num8 + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 8, array, 1, ref int_);
				if (array[0] != 1)
				{
					continue;
				}
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num8 + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 4, array, 1, ref int_);
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num8 + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue, array, 1, ref int_);
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num7 + GameConfigurationManager.memorySignatureScanConfig_111.resolvedValue, array, 1, ref int_);
				uint uint_1 = array[0];
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, num7 + GameConfigurationManager.memorySignatureScanConfig_112.resolvedValue, array, 1, ref int_);
				uint uint_2 = array[0];
				uint num9 = uint_0;
				uint[] array3 = InventoryItemMemoryHelper.FindFreeItemGridPosition(characterAccountConfig_0, num9, uint_1, uint_2);
				if (array3 == null)
				{
					num9 = 3u;
					array3 = InventoryItemMemoryHelper.FindFreeItemGridPosition(characterAccountConfig_0, 3u, uint_1, uint_2);
					if (array3 == null)
					{
						return -1;
					}
				}
				int num10 = 0;
				while (!CommonUtility.bool_0)
				{
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_123.resolvedValue, array2, 4, ref int_);
					if (BitConverter.ToInt32(array2, 0) > 0)
					{
						if (num10 % 5 == 0)
						{
							GameProcessInteractionHelper.MoveInventoryItemBetweenPositions(characterAccountConfig_0, array3[0], array3[1], num9, array3[0], array3[1], num9);
						}
						if (num10 > 30)
						{
							break;
						}
						num10++;
						Thread.Sleep(100);
						continue;
					}
					return 1;
				}
			}
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_123.resolvedValue, array2, 4, ref int_);
			return Convert.ToByte(BitConverter.ToInt32(array2, 0) <= 0);
		}
		return 0;
	}

	public static int TransferMatchingItemEntriesBetweenContainers(CharacterAccountConfig characterAccountConfig_0, uint uint_0, uint uint_1, string string_1, int int_2 = -1, bool bool_0 = false, bool bool_1 = false, bool bool_2 = false)
	{
		if (string_1 != null && !(string_1 == string.Empty))
		{
			int resultCode = 1;
			int bytesTransferred = 0;
			byte[] singleByteBuffer = new byte[1];
			byte[] fourByteBuffer = new byte[4];
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
			uint inventoryEntryTableBaseAddress = BitConverter.ToUInt32(fourByteBuffer, 0) + GameConfigurationManager.memorySignatureScanConfig_97.resolvedValue;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_105.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
			uint itemRecordTableBaseAddress = BitConverter.ToUInt32(fourByteBuffer, 0);
			int itemNameBufferLength = 1;
			string[] itemNamePatterns = string_1.Split('|');
			string[] normalizedItemNamePatterns = new string[itemNamePatterns.Length];
			for (int patternNormalizationIndex = 0; patternNormalizationIndex < itemNamePatterns.Length; patternNormalizationIndex++)
			{
				if (itemNamePatterns[patternNormalizationIndex] == null)
				{
					itemNamePatterns[patternNormalizationIndex] = string.Empty;
				}
				if (itemNameBufferLength < itemNamePatterns[patternNormalizationIndex].Length)
				{
					itemNameBufferLength = itemNamePatterns[patternNormalizationIndex].Length;
				}
				normalizedItemNamePatterns[patternNormalizationIndex] = itemNamePatterns[patternNormalizationIndex].Trim().ToLower();
			}
			itemNameBufferLength += 2;
			byte[] itemNameBuffer = new byte[itemNameBufferLength];
			PlaceHeldItemInInventory(characterAccountConfig_0);
			bool useDirectTransfer = SupportsDirectContainerTransfer(uint_0) && SupportsDirectContainerTransfer(uint_1) && uint_0 != uint_1;
			int inventoryEntryCount = InventoryItemMemoryHelper.GetInventoryEntryCount(characterAccountConfig_0);
			int processedEntryCount = 0;
			for (uint entryIndex = 1u; entryIndex < GameConfigurationManager.int_1 && inventoryEntryCount > processedEntryCount; entryIndex++)
			{
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, inventoryEntryTableBaseAddress + (entryIndex * 5 + GameConfigurationManager.memorySignatureScanConfig_99.resolvedValue) * 4, fourByteBuffer, 4, ref bytesTransferred);
				uint itemRecordIndex = BitConverter.ToUInt32(fourByteBuffer, 0);
				if (itemRecordIndex == 0)
				{
					continue;
				}
				uint itemRecordAddress = itemRecordTableBaseAddress + itemRecordIndex * GameConfigurationManager.memorySignatureScanConfig_106.resolvedValue;
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, itemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_106.resolvedValue - 4, fourByteBuffer, 4, ref bytesTransferred);
				if (BitConverter.ToInt32(fourByteBuffer, 0) != 0)
				{
					continue;
				}
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, itemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_107.resolvedValue, singleByteBuffer, 1, ref bytesTransferred);
				if (singleByteBuffer[0] == 0)
				{
					continue;
				}
				processedEntryCount++;
				uint inventoryEntryAddress = inventoryEntryTableBaseAddress + entryIndex * 20;
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, inventoryEntryAddress + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 8, singleByteBuffer, 1, ref bytesTransferred);
				uint sourceContainerId = singleByteBuffer[0];
				if (sourceContainerId != uint_0)
				{
					continue;
				}
				if (bool_1)
				{
					if (GameConfigurationManager.memorySignatureScanConfig_120.resolvedValue == 0)
					{
						resultCode = -5;
						break;
					}
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, itemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_120.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
					int itemStateCode = BitConverter.ToInt32(fourByteBuffer, 0);
					if (itemStateCode != -2)
					{
						continue;
					}
				}
				bool itemNameMatches;
				if (!(itemNameMatches = itemNamePatterns == null))
				{
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, itemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_107.resolvedValue, itemNameBuffer, itemNameBufferLength, ref bytesTransferred);
					string itemName = GameTextEncodingHelper.DecodeNullTerminatedUtf7(itemNameBuffer);
					string lowerItemName = itemName.ToLower();
					for (int matchPatternIndex = 0; matchPatternIndex < itemNamePatterns.Length; matchPatternIndex++)
					{
						if (itemName == itemNamePatterns[matchPatternIndex] || (!bool_0 && CommonUtility.FindSubstringIndex(lowerItemName, normalizedItemNamePatterns[matchPatternIndex]) == 0))
						{
							itemNameMatches = true;
							break;
						}
					}
					if (!itemNameMatches)
					{
						continue;
					}
				}
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, inventoryEntryAddress + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 4, singleByteBuffer, 1, ref bytesTransferred);
				uint sourceGridX = singleByteBuffer[0];
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, inventoryEntryAddress + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue, singleByteBuffer, 1, ref bytesTransferred);
				uint sourceGridY = singleByteBuffer[0];
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, itemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_111.resolvedValue, singleByteBuffer, 1, ref bytesTransferred);
				uint itemWidth = singleByteBuffer[0];
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, itemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_112.resolvedValue, singleByteBuffer, 1, ref bytesTransferred);
				uint itemHeight = singleByteBuffer[0];
				uint[] targetGridPosition = InventoryItemMemoryHelper.FindFreeItemGridPosition(characterAccountConfig_0, uint_1, itemWidth, itemHeight);
				if (targetGridPosition != null)
				{
					int moveCompletionPollCount = 0;
					if (!useDirectTransfer)
					{
						if (bool_2)
						{
							int requestedSplitQuantity = int_2;
							if (requestedSplitQuantity <= 0)
							{
								requestedSplitQuantity = 1;
							}
							WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, itemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_119.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
							int currentStackQuantity = BitConverter.ToInt32(fourByteBuffer, 0);
							WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, itemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_108.resolvedValue, fourByteBuffer, 0, ref bytesTransferred);
							int stackModeValue = fourByteBuffer[0];
							int splitRetryCount = 0;
							while (!CommonUtility.bool_0 && currentStackQuantity > requestedSplitQuantity && stackModeValue > 1)
							{
								WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_123.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
								int splitOperationState = BitConverter.ToInt32(fourByteBuffer, 0);
								if (splitRetryCount > 30 || splitOperationState > 0)
								{
									break;
								}
								if (splitRetryCount % 8 == 0)
								{
									GameProcessInteractionHelper.InvokeItemSplitAction(characterAccountConfig_0, itemRecordIndex, (uint)requestedSplitQuantity, 89);
								}
								Thread.Sleep(100);
								splitRetryCount++;
							}
						}
						int transferRetryCount = 0;
						while (!CommonUtility.bool_0)
						{
							WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_123.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
							int transferOperationState = BitConverter.ToInt32(fourByteBuffer, 0);
							if (transferOperationState > 0)
							{
								break;
							}
							if (transferRetryCount % 6 == 0)
							{
								GameProcessInteractionHelper.MoveInventoryItemBetweenPositions(characterAccountConfig_0, sourceGridX, sourceGridY, sourceContainerId, sourceGridX, sourceGridY, sourceContainerId);
							}
							if (transferRetryCount <= 40)
							{
								Thread.Sleep(100);
								transferRetryCount++;
								continue;
							}
							goto IL_0629;
						}
						transferRetryCount = 0;
						while (!CommonUtility.bool_0)
						{
							WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_123.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
							if (BitConverter.ToInt32(fourByteBuffer, 0) == 0)
							{
								break;
							}
							if (transferRetryCount % 6 == 0)
							{
								GameProcessInteractionHelper.MoveInventoryItemBetweenPositions(characterAccountConfig_0, targetGridPosition[0], targetGridPosition[1], uint_1, targetGridPosition[0], targetGridPosition[1], uint_1);
							}
							if (transferRetryCount <= 40)
							{
								Thread.Sleep(100);
								transferRetryCount++;
								continue;
							}
							goto IL_062e;
						}
						if (int_2 >= 0)
						{
							int_2--;
							if (int_2 <= 0)
							{
								resultCode = 1;
								break;
							}
						}
						continue;
					}
					GameProcessInteractionHelper.MoveInventoryItemBetweenPositions(characterAccountConfig_0, sourceGridX, sourceGridY, uint_0, targetGridPosition[0], targetGridPosition[1], uint_1);
					for (; moveCompletionPollCount < 30; moveCompletionPollCount++)
					{
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, inventoryEntryAddress + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 8, singleByteBuffer, 1, ref bytesTransferred);
						uint containerIdAfterMove = singleByteBuffer[0];
						if (sourceContainerId != containerIdAfterMove)
						{
							break;
						}
						Thread.Sleep(10);
					}
					if (int_2 >= 0)
					{
						int_2--;
						if (int_2 <= 0)
						{
							resultCode = 1;
							break;
						}
					}
				}
				else if (itemWidth <= 1 && itemHeight <= 1)
				{
					resultCode = 0;
					break;
				}
				continue;
				IL_062e:
				GameProcessInteractionHelper.MoveInventoryItemBetweenPositions(characterAccountConfig_0, sourceGridX, sourceGridY, sourceContainerId, sourceGridX, sourceGridY, sourceContainerId);
				resultCode = -2;
				break;
				IL_0629:
				resultCode = -2;
				break;
			}
			return resultCode;
		}
		return 0;
	}

	public static int TransferMatchingItemQuantityBetweenContainers(CharacterAccountConfig characterAccountConfig_0, uint uint_0, uint uint_1, string string_1, int int_2 = -1, bool bool_0 = false, bool bool_1 = false)
	{
		if (string_1 != null && !(string_1 == string.Empty))
		{
			int resultCode = 1;
			int bytesTransferred = 0;
			byte[] singleByteBuffer = new byte[1];
			byte[] fourByteBuffer = new byte[4];
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
			uint inventoryEntryTableBaseAddress = BitConverter.ToUInt32(fourByteBuffer, 0) + GameConfigurationManager.memorySignatureScanConfig_97.resolvedValue;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_105.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
			uint itemRecordTableBaseAddress = BitConverter.ToUInt32(fourByteBuffer, 0);
			int itemNameBufferLength = 1;
			string[] itemNamePatterns = string_1.Split('|');
			string[] normalizedItemNamePatterns = new string[itemNamePatterns.Length];
			for (int patternNormalizationIndex = 0; patternNormalizationIndex < itemNamePatterns.Length; patternNormalizationIndex++)
			{
				if (itemNamePatterns[patternNormalizationIndex] == null)
				{
					itemNamePatterns[patternNormalizationIndex] = string.Empty;
				}
				if (itemNameBufferLength < itemNamePatterns[patternNormalizationIndex].Length)
				{
					itemNameBufferLength = itemNamePatterns[patternNormalizationIndex].Length;
				}
				normalizedItemNamePatterns[patternNormalizationIndex] = itemNamePatterns[patternNormalizationIndex].Trim().ToLower();
			}
			itemNameBufferLength += 2;
			byte[] itemNameBuffer = new byte[itemNameBufferLength];
			PlaceHeldItemInInventory(characterAccountConfig_0);
			if (!SupportsDirectContainerTransfer(uint_0) || !SupportsDirectContainerTransfer(uint_1))
			{
			}
			int inventoryEntryCount = InventoryItemMemoryHelper.GetInventoryEntryCount(characterAccountConfig_0);
			int processedEntryCount = 0;
			int transferredQuantity = 0;
			uint entryIndex = 1u;
			while (true)
			{
				uint sourceGridX;
				uint sourceGridY;
				if (entryIndex < GameConfigurationManager.int_1 && inventoryEntryCount > processedEntryCount)
				{
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, inventoryEntryTableBaseAddress + (entryIndex * 5 + GameConfigurationManager.memorySignatureScanConfig_99.resolvedValue) * 4, fourByteBuffer, 4, ref bytesTransferred);
					uint itemRecordIndex = BitConverter.ToUInt32(fourByteBuffer, 0);
					if (itemRecordIndex != 0)
					{
						uint itemRecordAddress = itemRecordTableBaseAddress + itemRecordIndex * GameConfigurationManager.memorySignatureScanConfig_106.resolvedValue;
						WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, itemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_106.resolvedValue - 4, fourByteBuffer, 4, ref bytesTransferred);
						if (BitConverter.ToInt32(fourByteBuffer, 0) == 0)
						{
							WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, itemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_107.resolvedValue, singleByteBuffer, 1, ref bytesTransferred);
							if (singleByteBuffer[0] != 0)
							{
								processedEntryCount++;
								uint inventoryEntryAddress = inventoryEntryTableBaseAddress + entryIndex * 20;
								WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, inventoryEntryAddress + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 8, singleByteBuffer, 1, ref bytesTransferred);
								if (singleByteBuffer[0] == uint_0)
								{
									if (bool_1 && GameConfigurationManager.memorySignatureScanConfig_120.resolvedValue != 0)
									{
										int itemStateCode = (int)WindowsInteropHelper.ReadProcessUInt32(itemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_120.resolvedValue, characterAccountConfig_0.int_137);
										if (itemStateCode != -2)
										{
											goto IL_05a1;
										}
									}
									bool itemNameMatches = false;
									WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, itemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_107.resolvedValue, itemNameBuffer, itemNameBuffer.Length, ref bytesTransferred);
									string itemName = GameTextEncodingHelper.DecodeNullTerminatedUtf7(itemNameBuffer);
									for (int matchPatternIndex = 0; matchPatternIndex < itemNamePatterns.Length; matchPatternIndex++)
									{
										string matchPattern = itemNamePatterns[matchPatternIndex];
										if (!(matchPattern == "*"))
										{
											bool exactMatchRequired = bool_0;
											int wildcardIndex = CommonUtility.FindSubstringIndex(matchPattern, "*");
											if (wildcardIndex > 0)
											{
												matchPattern = matchPattern.Substring(0, wildcardIndex);
												exactMatchRequired = false;
											}
											if (itemName == matchPattern || (!exactMatchRequired && CommonUtility.FindSubstringIndex(itemName, matchPattern) == 0))
											{
												itemNameMatches = true;
												break;
											}
											continue;
										}
										itemNameMatches = true;
										break;
									}
									if (itemNameMatches)
									{
										WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, inventoryEntryAddress + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 4, singleByteBuffer, 1, ref bytesTransferred);
										sourceGridX = singleByteBuffer[0];
										WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, inventoryEntryAddress + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue, singleByteBuffer, 1, ref bytesTransferred);
										sourceGridY = singleByteBuffer[0];
										WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, itemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_111.resolvedValue, singleByteBuffer, 1, ref bytesTransferred);
										uint itemWidth = singleByteBuffer[0];
										WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, itemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_112.resolvedValue, singleByteBuffer, 1, ref bytesTransferred);
										uint itemHeight = singleByteBuffer[0];
										uint[] targetGridPosition = InventoryItemMemoryHelper.FindFreeItemGridPosition(characterAccountConfig_0, uint_1, itemWidth, itemHeight);
										if (targetGridPosition != null)
										{
											WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, itemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_119.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
											int itemQuantity = BitConverter.ToInt32(fourByteBuffer, 0);
											WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, itemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_108.resolvedValue, fourByteBuffer, 1, ref bytesTransferred);
											int stackModeValue = fourByteBuffer[0];
											int operationRetryCount = 0;
											if (itemQuantity > 0 && stackModeValue > 1 && int_2 > 0 && itemQuantity > int_2)
											{
												while (!CommonUtility.bool_0)
												{
													WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_123.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
													int splitOperationState = BitConverter.ToInt32(fourByteBuffer, 0);
													if (splitOperationState > 0)
													{
														break;
													}
													if (operationRetryCount % 8 == 0)
													{
														GameProcessInteractionHelper.InvokeItemSplitAction(characterAccountConfig_0, itemRecordIndex, (uint)int_2, 89);
													}
													if (operationRetryCount <= 30)
													{
														Thread.Sleep(100);
														operationRetryCount++;
														continue;
													}
													goto IL_05b7;
												}
												transferredQuantity = int_2;
											}
											else
											{
												while (!CommonUtility.bool_0)
												{
													WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_123.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
													int transferOperationState = BitConverter.ToInt32(fourByteBuffer, 0);
													if (transferOperationState > 0)
													{
														break;
													}
													if (operationRetryCount % 6 == 0)
													{
														GameProcessInteractionHelper.MoveInventoryItemBetweenPositions(characterAccountConfig_0, sourceGridX, sourceGridY, uint_0, sourceGridX, sourceGridY, uint_0);
													}
													if (operationRetryCount <= 40)
													{
														Thread.Sleep(100);
														operationRetryCount++;
														continue;
													}
													goto IL_05bc;
												}
												transferredQuantity = ((itemQuantity <= 0 || stackModeValue <= 1) ? (transferredQuantity + 1) : (transferredQuantity + itemQuantity));
											}
											operationRetryCount = 0;
											while (!CommonUtility.bool_0)
											{
												WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_123.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
												if (BitConverter.ToInt32(fourByteBuffer, 0) == 0)
												{
													break;
												}
												if (operationRetryCount % 6 == 0)
												{
													GameProcessInteractionHelper.MoveInventoryItemBetweenPositions(characterAccountConfig_0, targetGridPosition[0], targetGridPosition[1], uint_1, targetGridPosition[0], targetGridPosition[1], uint_1);
												}
												if (operationRetryCount <= 40)
												{
													Thread.Sleep(100);
													operationRetryCount++;
													continue;
												}
												goto IL_05c1;
											}
											if (int_2 > 0 && transferredQuantity >= int_2)
											{
												resultCode = 1;
												break;
											}
										}
										else if (itemWidth <= 1 && itemHeight <= 1)
										{
											resultCode = 0;
											break;
										}
									}
								}
							}
						}
					}
					goto IL_05a1;
				}
				resultCode = ((transferredQuantity > 0) ? 1 : 2);
				break;
				IL_05a1:
				entryIndex++;
				continue;
				IL_05b7:
				resultCode = -5;
				break;
				IL_05bc:
				resultCode = -2;
				break;
				IL_05c1:
				GameProcessInteractionHelper.MoveInventoryItemBetweenPositions(characterAccountConfig_0, sourceGridX, sourceGridY, uint_0, sourceGridX, sourceGridY, uint_0);
				resultCode = -4;
				break;
			}
			return resultCode;
		}
		return 0;
	}

	private static uint[,] CollectInventoryEntryContainerMappings(CharacterAccountConfig characterAccountConfig_0)
	{
		int bytesTransferred = 0;
		byte[] fourByteBuffer = new byte[4];
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
		uint inventoryEntryTableBaseAddress = BitConverter.ToUInt32(fourByteBuffer, 0) + GameConfigurationManager.memorySignatureScanConfig_97.resolvedValue;
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_105.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
		uint itemRecordTableBaseAddress = BitConverter.ToUInt32(fourByteBuffer, 0);
		int inventoryEntryCount = InventoryItemMemoryHelper.GetInventoryEntryCount(characterAccountConfig_0);
		int collectedEntryCount = 0;
		uint[,] entryContainerMappings = new uint[inventoryEntryCount, 2];
		for (uint entryIndex = 1u; entryIndex < GameConfigurationManager.int_1; entryIndex++)
		{
			if (inventoryEntryCount <= collectedEntryCount)
			{
				break;
			}
			uint inventoryEntryAddress = inventoryEntryTableBaseAddress + entryIndex * 20;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, inventoryEntryAddress + GameConfigurationManager.memorySignatureScanConfig_99.resolvedValue * 4, fourByteBuffer, 4, ref bytesTransferred);
			uint itemRecordIndex = BitConverter.ToUInt32(fourByteBuffer, 0);
			if (itemRecordIndex == 0)
			{
				continue;
			}
			uint itemRecordAddress = itemRecordTableBaseAddress + itemRecordIndex * GameConfigurationManager.memorySignatureScanConfig_106.resolvedValue;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, itemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_106.resolvedValue - 4, fourByteBuffer, 4, ref bytesTransferred);
			if (BitConverter.ToInt32(fourByteBuffer, 0) == 0)
			{
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, itemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_107.resolvedValue, fourByteBuffer, 1, ref bytesTransferred);
				if (fourByteBuffer[0] != 0)
				{
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, inventoryEntryAddress + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 8, fourByteBuffer, 1, ref bytesTransferred);
					entryContainerMappings[collectedEntryCount, 0] = entryIndex;
					entryContainerMappings[collectedEntryCount, 1] = fourByteBuffer[0];
					collectedEntryCount++;
				}
			}
		}
		return entryContainerMappings;
	}

	public static void RunItemDiscardAutomationWorker()
	{
		int targetCharacterId = int_0;
		int_0 = 0;
		bool workerLockAcquired = false;
		while (true)
		{
			try
			{
				int accountIndex = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, targetCharacterId);
				if (!CommonUtility.bool_0 && accountIndex >= 0)
				{
					if (!workerLockAcquired)
					{
						if (Form1.characterAccountConfig_1[accountIndex].bool_41)
						{
							break;
						}
						Form1.characterAccountConfig_1[accountIndex].bool_41 = true;
						workerLockAcquired = true;
					}
					ExecuteItemDiscardWorkflowForAccount(targetCharacterId);
					continue;
				}
				if (0 <= accountIndex)
				{
					Form1.characterAccountConfig_1[accountIndex].bool_41 = false;
				}
				break;
			}
			catch
			{
			}
		}
	}

	private static void ExecuteItemDiscardWorkflowForAccount(int int_2)
	{
		CharacterAccountConfig accountConfig = default(CharacterAccountConfig);
		int accountRefreshCountdown = 0;
		int bytesTransferred = 0;
		byte[] fourByteBuffer = new byte[4];
		byte[] itemNameBuffer = new byte[60];
		long lastDropRequestTicks = 0L;
		while (true)
		{
			accountRefreshCountdown--;
			Thread.Sleep(600);
			if (CommonUtility.bool_0)
			{
				break;
			}
			if (accountRefreshCountdown <= 0)
			{
				int accountIndex = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, int_2);
				if (accountIndex < 0)
				{
					break;
				}
				accountRefreshCountdown = 30;
				accountConfig = Form1.characterAccountConfig_1[accountIndex];
			}
			if (lastDropRequestTicks > 0L && CommonUtility.GetElapsedMilliseconds(lastDropRequestTicks) > 10000L)
			{
				sharedItemDropName = null;
				lastDropRequestTicks = 0L;
			}
			int discardRequestCode = GameProcessInteractionHelper.ReadSharedSlotIntegerValue(accountConfig, GameProcessInteractionHelper.uint_50, 4);
			if (discardRequestCode <= 0)
			{
				continue;
			}
			string targetItemName = null;
			uint inventoryEntryTableBaseAddress = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, accountConfig.int_137) + GameConfigurationManager.memorySignatureScanConfig_97.resolvedValue;
			uint itemRecordTableBaseAddress = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_105.resolvedValue, accountConfig.int_137);
			int inventoryEntryCount;
			int processedEntryCount;
			uint entryIndex;
			if (discardRequestCode > 2)
			{
				long waitForSharedItemNameStartTicks = CommonUtility.GetCurrentTicks();
				while (CommonUtility.GetElapsedMilliseconds(waitForSharedItemNameStartTicks) < 10000L)
				{
					targetItemName = sharedItemDropName;
					if (targetItemName == null || !(targetItemName != string.Empty))
					{
						Thread.Sleep(100);
						continue;
					}
					goto IL_0131;
				}
			}
			else
			{
				lastDropRequestTicks = CommonUtility.GetCurrentTicks();
				if (discardRequestCode == 2)
				{
					GameProcessInteractionHelper.PrintGameMessage(accountConfig, "<bclr=white><color=red>TÊt c¶ ac cïng Qu\u00a8ng ®å...");
				}
				else
				{
					GameProcessInteractionHelper.PrintGameMessage(accountConfig, "<bclr=white><color=red>Qu\u00a8ng ®å...<bclr=blue><color=green>(hoÆc bÊm phÝm CTRL + ALT + F ®Ó tÊt c¶ ac cßn l¹i cïng qu\u00a8ng theo)");
				}
				if ((int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_123.resolvedValue, accountConfig.int_137) > 0)
				{
					inventoryEntryCount = InventoryItemMemoryHelper.GetInventoryEntryCount(accountConfig);
					processedEntryCount = 0;
					for (entryIndex = 1u; entryIndex < GameConfigurationManager.int_1; entryIndex++)
					{
						if (inventoryEntryCount <= processedEntryCount)
						{
							break;
						}
						WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, inventoryEntryTableBaseAddress + (entryIndex * 5 + GameConfigurationManager.memorySignatureScanConfig_99.resolvedValue) * 4, fourByteBuffer, 4, ref bytesTransferred);
						uint itemRecordIndex = BitConverter.ToUInt32(fourByteBuffer, 0);
						if (itemRecordIndex == 0)
						{
							continue;
						}
						uint itemRecordAddress = itemRecordTableBaseAddress + itemRecordIndex * GameConfigurationManager.memorySignatureScanConfig_106.resolvedValue;
						WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, itemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_106.resolvedValue - 4, fourByteBuffer, 4, ref bytesTransferred);
						if (BitConverter.ToInt32(fourByteBuffer, 0) != 0)
						{
							continue;
						}
						WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, itemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_107.resolvedValue, fourByteBuffer, 1, ref bytesTransferred);
						if (fourByteBuffer[0] != 0)
						{
							processedEntryCount++;
							uint inventoryEntryAddress = inventoryEntryTableBaseAddress + entryIndex * 20;
							WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, inventoryEntryAddress + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 8, fourByteBuffer, 1, ref bytesTransferred);
							int containerId = fourByteBuffer[0];
							if (containerId == 1)
							{
								WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, itemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_107.resolvedValue, itemNameBuffer, itemNameBuffer.Length, ref bytesTransferred);
								targetItemName = GameTextEncodingHelper.DecodeNullTerminatedUtf7(itemNameBuffer);
								break;
							}
						}
					}
					if (discardRequestCode <= 2)
					{
						sharedItemDropName = targetItemName;
					}
					goto IL_02cf;
				}
				GameProcessInteractionHelper.PrintGameMessage(accountConfig, "<bclr=blue><color=white>H·y cÇm 1 vËt phÈm, sau ®ã bÊm Ctrl + F (hoÆc Ctrl + Alt + F) ®Ó tiÕn hµnh vøt bá.");
			}
			goto IL_0687;
			IL_0687:
			GameProcessInteractionHelper.WriteSharedSlotInt32(accountConfig, GameProcessInteractionHelper.uint_50, 0, 4);
			continue;
			IL_02cf:
			inventoryEntryCount = InventoryItemMemoryHelper.GetInventoryEntryCount(accountConfig);
			processedEntryCount = 0;
			uint selectedGridX = 255u;
			uint selectedGridY = 255u;
			entryIndex = 1u;
			while (true)
			{
				if (entryIndex < GameConfigurationManager.int_1 && inventoryEntryCount > processedEntryCount)
				{
					if (GameProcessInteractionHelper.ReadSharedSlotIntegerValue(accountConfig, GameProcessInteractionHelper.uint_50, 4) != 0 && targetItemName != null && !(targetItemName == string.Empty))
					{
						int operationRetryCount = 0;
						while (!CommonUtility.bool_0)
						{
							WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_123.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
							if (BitConverter.ToInt32(fourByteBuffer, 0) == 0)
							{
								break;
							}
							if (operationRetryCount % 10 == 0)
							{
								GameProcessInteractionHelper.InvokeItemThrowAction(accountConfig);
							}
							if (operationRetryCount <= 100)
							{
								Thread.Sleep(30);
								operationRetryCount++;
								continue;
							}
							goto IL_058b;
						}
						if (inventoryEntryCount > processedEntryCount)
						{
							WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, inventoryEntryTableBaseAddress + (entryIndex * 5 + GameConfigurationManager.memorySignatureScanConfig_99.resolvedValue) * 4, fourByteBuffer, 4, ref bytesTransferred);
							uint candidateItemRecordIndex = BitConverter.ToUInt32(fourByteBuffer, 0);
							if (candidateItemRecordIndex != 0)
							{
								uint candidateItemRecordAddress = itemRecordTableBaseAddress + candidateItemRecordIndex * GameConfigurationManager.memorySignatureScanConfig_106.resolvedValue;
								WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, candidateItemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_106.resolvedValue - 4, fourByteBuffer, 4, ref bytesTransferred);
								if (BitConverter.ToInt32(fourByteBuffer, 0) == 0)
								{
									WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, candidateItemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_107.resolvedValue, fourByteBuffer, 1, ref bytesTransferred);
									if (fourByteBuffer[0] != 0)
									{
										processedEntryCount++;
										if (fourByteBuffer[0] == targetItemName[0])
										{
											uint candidateInventoryEntryAddress = inventoryEntryTableBaseAddress + entryIndex * 20;
											WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, candidateInventoryEntryAddress + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 8, fourByteBuffer, 1, ref bytesTransferred);
											uint candidateContainerId = fourByteBuffer[0];
											if (candidateContainerId == 3)
											{
												WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, candidateItemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_107.resolvedValue, itemNameBuffer, itemNameBuffer.Length, ref bytesTransferred);
												string candidateItemName = GameTextEncodingHelper.DecodeNullTerminatedUtf7(itemNameBuffer);
												if (!(candidateItemName != targetItemName))
												{
													WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, candidateInventoryEntryAddress + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 4, fourByteBuffer, 1, ref bytesTransferred);
													uint candidateGridX = fourByteBuffer[0];
													WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, candidateInventoryEntryAddress + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue, fourByteBuffer, 1, ref bytesTransferred);
													uint candidateGridY = fourByteBuffer[0];
													operationRetryCount = 0;
													while (!CommonUtility.bool_0)
													{
														WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_123.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
														if (BitConverter.ToInt32(fourByteBuffer, 0) > 0)
														{
															break;
														}
														if (operationRetryCount % 5 == 0)
														{
															GameProcessInteractionHelper.MoveInventoryItemBetweenPositions(accountConfig, candidateGridX, candidateGridY, candidateContainerId, candidateGridX, candidateGridY, candidateContainerId);
														}
														Thread.Sleep(80);
														operationRetryCount++;
														if (operationRetryCount <= 42)
														{
															continue;
														}
														goto IL_05a8;
													}
													selectedGridX = candidateGridX;
													selectedGridY = candidateGridY;
												}
											}
										}
									}
								}
							}
							entryIndex++;
							continue;
						}
					}
					else
					{
						Thread.Sleep(100);
						WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_123.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
						if (selectedGridX != 255 && BitConverter.ToInt32(fourByteBuffer, 0) > 0)
						{
							GameProcessInteractionHelper.MoveInventoryItemBetweenPositions(accountConfig, selectedGridX, selectedGridY, 3u, selectedGridX, selectedGridY, 3u);
						}
						if (discardRequestCode <= 2)
						{
							sharedItemDropName = null;
						}
					}
				}
				if (selectedGridX != 255 && discardRequestCode > 2 && GameProcessInteractionHelper.ReadSharedSlotIntegerValue(accountConfig, GameProcessInteractionHelper.uint_50, 4) > 0)
				{
					Thread.Sleep(100);
					WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_123.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
					if (BitConverter.ToInt32(fourByteBuffer, 0) > 0)
					{
						GameProcessInteractionHelper.InvokeItemThrowAction(accountConfig);
					}
				}
				break;
				IL_05a8:
				GameProcessInteractionHelper.PrintGameMessage(accountConfig, "<bclr=blue><color=white>>Kh«ng thÓ cÇm vËt phÈm <" + targetItemName + ">");
				break;
				IL_058b:
				GameProcessInteractionHelper.PrintGameMessage(accountConfig, "<bclr=blue><color=white>Kh«ng thÓ qu\u00a8ng <" + targetItemName + ">");
				break;
			}
			GameProcessInteractionHelper.PrintGameMessage(accountConfig, "<bclr=white><color=red>Qu\u00a8ng ®å kÕt thóc !");
			goto IL_0687;
			IL_0131:
			GameProcessInteractionHelper.PrintGameMessage(accountConfig, "<bclr=white><color=red>Qu\u00a8ng ®å...");
			goto IL_02cf;
		}
	}

	public static int PlaceHeldItemInInventory(CharacterAccountConfig characterAccountConfig_0)
	{
		int bytesTransferred = 0;
		byte[] fourByteBuffer = new byte[4];
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_123.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
		if (BitConverter.ToInt32(fourByteBuffer, 0) <= 0)
		{
			return 0;
		}
		uint inventoryEntryTableBaseAddress = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, characterAccountConfig_0.int_137) + GameConfigurationManager.memorySignatureScanConfig_97.resolvedValue;
		uint itemRecordTableBaseAddress = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_105.resolvedValue, characterAccountConfig_0.int_137);
		int inventoryEntryCount = InventoryItemMemoryHelper.GetInventoryEntryCount(characterAccountConfig_0);
		int processedEntryCount = 0;
		for (uint entryIndex = 1u; entryIndex < GameConfigurationManager.int_1; entryIndex++)
		{
			if (inventoryEntryCount <= processedEntryCount)
			{
				break;
			}
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, inventoryEntryTableBaseAddress + (entryIndex * 5 + GameConfigurationManager.memorySignatureScanConfig_99.resolvedValue) * 4, fourByteBuffer, 4, ref bytesTransferred);
			uint itemRecordIndex = BitConverter.ToUInt32(fourByteBuffer, 0);
			if (itemRecordIndex == 0)
			{
				continue;
			}
			uint itemRecordAddress = itemRecordTableBaseAddress + itemRecordIndex * GameConfigurationManager.memorySignatureScanConfig_106.resolvedValue;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, itemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_106.resolvedValue - 4, fourByteBuffer, 4, ref bytesTransferred);
			if (BitConverter.ToInt32(fourByteBuffer, 0) != 0)
			{
				continue;
			}
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, itemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_107.resolvedValue, fourByteBuffer, 1, ref bytesTransferred);
			if (fourByteBuffer[0] == 0)
			{
				continue;
			}
			processedEntryCount++;
			uint inventoryEntryAddress = inventoryEntryTableBaseAddress + entryIndex * 20;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, inventoryEntryAddress + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 8, fourByteBuffer, 1, ref bytesTransferred);
			uint containerId = fourByteBuffer[0];
			if (containerId != 1)
			{
				continue;
			}
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, inventoryEntryAddress + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 4, fourByteBuffer, 1, ref bytesTransferred);
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, inventoryEntryAddress + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue, fourByteBuffer, 1, ref bytesTransferred);
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, itemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_111.resolvedValue, fourByteBuffer, 1, ref bytesTransferred);
			int itemWidth = fourByteBuffer[0];
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, itemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_112.resolvedValue, fourByteBuffer, 1, ref bytesTransferred);
			int itemHeight = fourByteBuffer[0];
			uint[] targetGridPosition = InventoryItemMemoryHelper.FindFreeItemGridPosition(characterAccountConfig_0, 3u, (uint)itemWidth, (uint)itemHeight);
			if (targetGridPosition == null)
			{
				return -1;
			}
			int moveRetryCount = 0;
			while (moveRetryCount < 100)
			{
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_123.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
				if (BitConverter.ToInt32(fourByteBuffer, 0) > 0)
				{
					if (moveRetryCount % 30 == 0)
					{
						GameProcessInteractionHelper.MoveInventoryItemBetweenPositions(characterAccountConfig_0, targetGridPosition[0], targetGridPosition[1], 3u, targetGridPosition[0], targetGridPosition[1], 3u);
					}
					moveRetryCount++;
					Thread.Sleep(10);
					continue;
				}
				return 1;
			}
			return -1;
		}
		return 0;
	}

	private static uint FindMappedValueByKey(uint[,] uint_0, uint uint_1)
	{
		if (uint_0 != null)
		{
			for (int mappingRowIndex = 0; mappingRowIndex < uint_0.GetLength(0); mappingRowIndex++)
			{
				if (uint_0[mappingRowIndex, 0] == uint_1)
				{
					return uint_0[mappingRowIndex, 1];
				}
			}
		}
		return 0u;
	}

	public static void RunInventoryTransferMergeSupervisorLoop()
	{
		int targetCharacterId = int_1;
		int_1 = 0;
		bool workerLockAcquired = false;
		while (true)
		{
			try
			{
				int accountIndex = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, targetCharacterId);
				if (!CommonUtility.bool_0 && accountIndex >= 0)
				{
					if (!workerLockAcquired)
					{
						if (Form1.characterAccountConfig_1[accountIndex].bool_40)
						{
							break;
						}
						Form1.characterAccountConfig_1[accountIndex].bool_40 = true;
						workerLockAcquired = true;
					}
					RunInventoryTransferMergeAutomation(targetCharacterId);
					continue;
				}
				if (0 <= accountIndex)
				{
					Form1.characterAccountConfig_1[accountIndex].bool_40 = false;
				}
				break;
			}
			catch
			{
			}
		}
	}

	private static void RunInventoryTransferMergeAutomation(int int_2)
	{
		CharacterAccountConfig accountConfig = default(CharacterAccountConfig);
		int bytesTransferred = 0;
		int accountIndex = 0;
		int accountRefreshCountdown = 0;
		int previousOperationCode = -1;
		int sampleSelectionTimeoutMilliseconds = 12000;
		byte[] fourByteBuffer = new byte[4];
		long operationStartTicks = 0L;
		uint[,] entryContainerMappings = null;
		uint sampleEntryIndex = 0u;
		uint sourceContainerId = 0u;
		uint targetContainerId = 0u;
		int sampleMatchField1 = 0;
		int sampleMatchField2 = 0;
		int sampleSignatureValue = 0;
		int sampleItemWidth = 0;
		int sampleItemHeight = 0;
		while (true)
		{
			accountRefreshCountdown--;
			Thread.Sleep(300);
			if (CommonUtility.bool_0)
			{
				break;
			}
			if (accountRefreshCountdown <= 0)
			{
				accountIndex = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, int_2);
				if (accountIndex < 0)
				{
					break;
				}
				accountRefreshCountdown = 30;
				accountConfig = Form1.characterAccountConfig_1[accountIndex];
			}
			int currentOperationCode = GameProcessInteractionHelper.ReadSharedSlotIntegerValue(accountConfig, GameProcessInteractionHelper.inventoryOperationStateSlot, 4);
			uint inventoryEntryTableBaseAddress;
			uint itemRecordTableBaseAddress;
			if (currentOperationCode != 0)
			{
				if (previousOperationCode != currentOperationCode)
				{
					previousOperationCode = currentOperationCode;
					operationStartTicks = CommonUtility.GetCurrentTicks();
					entryContainerMappings = null;
					string operationDescription = string.Empty;
					switch (currentOperationCode)
					{
					case 1:
						operationDescription = "ChuyÓn ®å (kÝch th\u00adíc)";
						break;
					case 2:
						operationDescription = "ChuyÓn ®å (cïng lo¹i)";
						break;
					case 3:
						operationDescription = "Gép vËt phÈm";
						break;
					}
					GameProcessInteractionHelper.PrintGameMessage(accountConfig, "<color=yellow>" + operationDescription + ": <color=red>B¾t ®Çu..");
					InventoryItemMemoryHelper.PlaceHeldItemInContainer(accountConfig, 3u);
				}
				if (currentOperationCode == 3)
				{
					RunInventoryItemMergeAutomation(accountConfig);
					operationStartTicks = 1L;
					continue;
				}
				WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
				uint inventoryTableRootPointer = BitConverter.ToUInt32(fourByteBuffer, 0);
				inventoryEntryTableBaseAddress = inventoryTableRootPointer + GameConfigurationManager.memorySignatureScanConfig_97.resolvedValue;
				WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_105.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
				itemRecordTableBaseAddress = BitConverter.ToUInt32(fourByteBuffer, 0);
				if (entryContainerMappings == null)
				{
					sampleEntryIndex = 0u;
					sourceContainerId = 0u;
					targetContainerId = 0u;
					entryContainerMappings = CollectInventoryEntryContainerMappings(accountConfig);
					if (entryContainerMappings == null)
					{
						goto IL_0390;
					}
					GameProcessInteractionHelper.PrintGameMessage(accountConfig, "H·y cÇm vËt phÈm mÉu.");
				}
				if (sourceContainerId == 0)
				{
					if (CommonUtility.GetElapsedMilliseconds(operationStartTicks) <= sampleSelectionTimeoutMilliseconds)
					{
						int currentOperationCodeCheck = GameProcessInteractionHelper.ReadSharedSlotIntegerValue(accountConfig, GameProcessInteractionHelper.inventoryOperationStateSlot, 4);
						if (currentOperationCodeCheck != currentOperationCode)
						{
							previousOperationCode = -1;
							continue;
						}
						WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_123.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
						if (BitConverter.ToUInt32(fourByteBuffer, 0) == 0)
						{
							continue;
						}
						sampleEntryIndex = GetHeldItemRecordIndex(accountConfig);
						for (int mappingRowIndex = 0; mappingRowIndex < entryContainerMappings.GetLength(0); mappingRowIndex++)
						{
							if (sampleEntryIndex == entryContainerMappings[mappingRowIndex, 0])
							{
								sourceContainerId = entryContainerMappings[mappingRowIndex, 1];
								break;
							}
						}
						if (sourceContainerId == 0)
						{
							continue;
						}
						uint sampleInventoryEntryAddress = inventoryEntryTableBaseAddress + sampleEntryIndex * 20;
						WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, sampleInventoryEntryAddress + GameConfigurationManager.memorySignatureScanConfig_99.resolvedValue * 4, fourByteBuffer, 4, ref bytesTransferred);
						uint sampleItemRecordIndex = BitConverter.ToUInt32(fourByteBuffer, 0);
						if (sampleItemRecordIndex != 0)
						{
							uint sampleItemRecordAddress = itemRecordTableBaseAddress + sampleItemRecordIndex * GameConfigurationManager.memorySignatureScanConfig_106.resolvedValue;
							WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, sampleItemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_108.resolvedValue, fourByteBuffer, 1, ref bytesTransferred);
							sampleMatchField1 = fourByteBuffer[0];
							WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, sampleItemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_110.resolvedValue, fourByteBuffer, 1, ref bytesTransferred);
							sampleMatchField2 = fourByteBuffer[0];
							WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, sampleItemRecordAddress + InventoryItemMemoryHelper.uint_1, fourByteBuffer, 4, ref bytesTransferred);
							sampleSignatureValue = BitConverter.ToInt32(fourByteBuffer, 0);
							WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, sampleItemRecordAddress + InventoryItemMemoryHelper.uint_1 + 4, fourByteBuffer, 4, ref bytesTransferred);
							BitConverter.ToInt32(fourByteBuffer, 0);
							WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, sampleItemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_111.resolvedValue, fourByteBuffer, 1, ref bytesTransferred);
							sampleItemWidth = fourByteBuffer[0];
							WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, sampleItemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_112.resolvedValue, fourByteBuffer, 1, ref bytesTransferred);
							sampleItemHeight = fourByteBuffer[0];
							GameProcessInteractionHelper.PrintGameMessage(accountConfig, "H·y ®Æt vµo r\u00ad¬ng ®Ých.");
							goto IL_03a2;
						}
					}
					goto IL_0390;
				}
				goto IL_03a2;
			}
			if (operationStartTicks > 0L)
			{
				GameProcessInteractionHelper.PrintGameMessage(accountConfig, "KÕt thóc !");
			}
			operationStartTicks = 0L;
			previousOperationCode = -1;
			entryContainerMappings = null;
			Thread.Sleep(200);
			continue;
			IL_0390:
			GameProcessInteractionHelper.WriteSharedSlotInt32(accountConfig, GameProcessInteractionHelper.inventoryOperationStateSlot, 0, 4);
			continue;
			IL_03a2:
			if (targetContainerId == 0)
			{
				WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, inventoryEntryTableBaseAddress + sampleEntryIndex * 20 + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 8, fourByteBuffer, 1, ref bytesTransferred);
				if (fourByteBuffer[0] == 1)
				{
					continue;
				}
				if (fourByteBuffer[0] == sourceContainerId)
				{
					sourceContainerId = 0u;
					sampleEntryIndex = 0u;
					continue;
				}
				targetContainerId = fourByteBuffer[0];
			}
			while (true)
			{
				int successfulMoveCount = 0;
				int inventoryEntryCount = InventoryItemMemoryHelper.GetInventoryEntryCount(accountConfig);
				int processedEntryCount = 0;
				uint candidateEntryIndex = 0u;
				while (true)
				{
					candidateEntryIndex++;
					if (inventoryEntryCount <= processedEntryCount || GameConfigurationManager.int_1 <= candidateEntryIndex)
					{
						break;
					}
					WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, accountConfig.uint_16 + GameProcessInteractionHelper.inventoryOperationStateSlot * 4, fourByteBuffer, 1, ref bytesTransferred);
					currentOperationCode = fourByteBuffer[0];
					if (currentOperationCode == 0)
					{
						goto end_IL_083a;
					}
					uint candidateInventoryEntryAddress = inventoryEntryTableBaseAddress + candidateEntryIndex * 20;
					WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, candidateInventoryEntryAddress + GameConfigurationManager.memorySignatureScanConfig_99.resolvedValue * 4, fourByteBuffer, 4, ref bytesTransferred);
					uint candidateItemRecordIndex = BitConverter.ToUInt32(fourByteBuffer, 0);
					if (candidateItemRecordIndex == 0)
					{
						continue;
					}
					uint candidateItemRecordAddress = itemRecordTableBaseAddress + candidateItemRecordIndex * GameConfigurationManager.memorySignatureScanConfig_106.resolvedValue;
					WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, candidateItemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_106.resolvedValue - 4, fourByteBuffer, 4, ref bytesTransferred);
					if (BitConverter.ToInt32(fourByteBuffer, 0) != 0)
					{
						continue;
					}
					WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, candidateItemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_107.resolvedValue, fourByteBuffer, 1, ref bytesTransferred);
					if (fourByteBuffer[0] == 0)
					{
						continue;
					}
					processedEntryCount++;
					WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, candidateInventoryEntryAddress + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 8, fourByteBuffer, 1, ref bytesTransferred);
					if (fourByteBuffer[0] != sourceContainerId)
					{
						continue;
					}
					WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, candidateItemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_111.resolvedValue, fourByteBuffer, 1, ref bytesTransferred);
					uint candidateItemWidth = fourByteBuffer[0];
					WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, candidateItemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_112.resolvedValue, fourByteBuffer, 1, ref bytesTransferred);
					uint candidateItemHeight = fourByteBuffer[0];
					bool candidateMatchesSample = candidateItemWidth == sampleItemWidth && candidateItemHeight == sampleItemHeight;
					if (currentOperationCode == 2)
					{
						WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, candidateItemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_108.resolvedValue, fourByteBuffer, 1, ref bytesTransferred);
						int candidateMatchField1 = fourByteBuffer[0];
						WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, candidateItemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_110.resolvedValue, fourByteBuffer, 1, ref bytesTransferred);
						int candidateMatchField2 = fourByteBuffer[0];
						WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, candidateItemRecordAddress + InventoryItemMemoryHelper.uint_1, fourByteBuffer, 4, ref bytesTransferred);
						int candidateSignatureValue = BitConverter.ToInt32(fourByteBuffer, 0);
						WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, candidateItemRecordAddress + InventoryItemMemoryHelper.uint_1 + 4, fourByteBuffer, 4, ref bytesTransferred);
						BitConverter.ToInt32(fourByteBuffer, 0);
						candidateMatchesSample = candidateMatchField1 == sampleMatchField1 && candidateMatchField2 == sampleMatchField2 && candidateSignatureValue == sampleSignatureValue;
					}
					if (!candidateMatchesSample)
					{
						continue;
					}
					uint[] targetGridPosition = InventoryItemMemoryHelper.FindFreeItemGridPosition(accountConfig, targetContainerId, candidateItemWidth, candidateItemHeight);
					if (targetGridPosition != null)
					{
						WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, candidateInventoryEntryAddress + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 4, fourByteBuffer, 1, ref bytesTransferred);
						byte candidateGridX = fourByteBuffer[0];
						WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, candidateInventoryEntryAddress + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue, fourByteBuffer, 1, ref bytesTransferred);
						byte candidateGridY = fourByteBuffer[0];
						int moveStartedFlag = 0;
						int moveRetryCount = 0;
						while (!CommonUtility.bool_0)
						{
							WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_123.resolvedValue, fourByteBuffer, 1, ref bytesTransferred);
							int inventoryOperationState = fourByteBuffer[0];
							if (inventoryOperationState <= 0)
							{
								if (moveRetryCount % 8 == 0)
								{
									GameProcessInteractionHelper.MoveInventoryItemBetweenPositions(accountConfig, candidateGridX, candidateGridY, sourceContainerId, candidateGridX, candidateGridY, sourceContainerId);
								}
								if (moveRetryCount > 60)
								{
									break;
								}
								Thread.Sleep(10);
								moveRetryCount++;
								continue;
							}
							moveStartedFlag = 1;
							break;
						}
						if (moveStartedFlag == 0)
						{
							continue;
						}
						moveRetryCount = 0;
						while (!CommonUtility.bool_0)
						{
							WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_123.resolvedValue, fourByteBuffer, 1, ref bytesTransferred);
							if (fourByteBuffer[0] != 0)
							{
								WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, candidateInventoryEntryAddress + GameConfigurationManager.memorySignatureScanConfig_99.resolvedValue * 4, fourByteBuffer, 4, ref bytesTransferred);
								if (BitConverter.ToInt32(fourByteBuffer, 0) != 0)
								{
									if (moveRetryCount % 8 == 0)
									{
										GameProcessInteractionHelper.MoveInventoryItemBetweenPositions(accountConfig, targetGridPosition[0], targetGridPosition[1], targetContainerId, targetGridPosition[0], targetGridPosition[1], targetContainerId);
									}
									if (moveRetryCount > 60)
									{
										break;
									}
									moveRetryCount++;
									Thread.Sleep(10);
									continue;
								}
								moveStartedFlag = 0;
								break;
							}
							moveStartedFlag = 0;
							successfulMoveCount++;
							break;
						}
						if (moveStartedFlag <= 0)
						{
							continue;
						}
						GameProcessInteractionHelper.MoveInventoryItemBetweenPositions(accountConfig, candidateGridX, candidateGridY, sourceContainerId, candidateGridX, candidateGridY, sourceContainerId);
						for (moveRetryCount = 0; moveRetryCount < 100; moveRetryCount++)
						{
							WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_123.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
							if (BitConverter.ToInt32(fourByteBuffer, 0) == 0)
							{
								break;
							}
							Thread.Sleep(10);
						}
						continue;
					}
					previousOperationCode = -1;
					goto end_IL_083a;
				}
				if (successfulMoveCount <= 0)
				{
					previousOperationCode = -1;
					break;
				}
				continue;
				end_IL_083a:
				break;
			}
		}
	}

	public static void RunInventoryItemMergeAutomation(CharacterAccountConfig characterAccountConfig_0)
	{
		int bytesTransferred = 0;
		int invalidStateRetryCount = 0;
		byte[] fourByteBuffer = new byte[4];
		while (true)
		{
			Thread.Sleep(10);
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
			uint memoryRootPointer = BitConverter.ToUInt32(fourByteBuffer, 0);
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, memoryRootPointer + GameConfigurationManager.memorySignatureScanConfig_13.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
			uint currentEntryIndex = BitConverter.ToUInt32(fourByteBuffer, 0);
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
			uint memoryTableBaseAddress = BitConverter.ToUInt32(fourByteBuffer, 0);
			uint currentCharacterStateAddress = memoryTableBaseAddress + currentEntryIndex * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, currentCharacterStateAddress + GameConfigurationManager.memorySignatureScanConfig_50.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
			int entityStateFlag = BitConverter.ToInt32(fourByteBuffer, 0);
			int gatewayConnectionState = GameInterfaceMemoryHelper.ReadGatewayConnectionState(characterAccountConfig_0);
			if (entityStateFlag <= 0 || gatewayConnectionState <= 1)
			{
				if (invalidStateRetryCount >= 10)
				{
					break;
				}
				invalidStateRetryCount++;
				Thread.Sleep(100);
				continue;
			}
			invalidStateRetryCount = 0;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, currentCharacterStateAddress + GameConfigurationManager.memorySignatureScanConfig_55.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
			int blockingStateCode = BitConverter.ToInt32(fourByteBuffer, 0);
			if (blockingStateCode == 11 || blockingStateCode == 22)
			{
				break;
			}
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_105.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
			uint itemRecordTableBaseAddress = BitConverter.ToUInt32(fourByteBuffer, 0);
			uint inventoryEntryTableBaseAddress = memoryRootPointer + GameConfigurationManager.memorySignatureScanConfig_97.resolvedValue;
			uint[] failedMergeEntryIndices = null;
			int processedEntryCount = 0;
			uint entryIndex = 0u;
			while (true)
			{
				entryIndex++;
				int inventoryEntryCount = InventoryItemMemoryHelper.GetInventoryEntryCount(characterAccountConfig_0);
				if (CommonUtility.bool_0 || inventoryEntryCount <= processedEntryCount || GameConfigurationManager.int_1 <= entryIndex || GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig_0, GameProcessInteractionHelper.inventoryOperationStateSlot, 4) != 3)
				{
					break;
				}
				uint inventoryEntryAddress = inventoryEntryTableBaseAddress + entryIndex * 20;
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, inventoryEntryAddress + GameConfigurationManager.memorySignatureScanConfig_99.resolvedValue * 4, fourByteBuffer, 4, ref bytesTransferred);
				uint itemRecordIndex = BitConverter.ToUInt32(fourByteBuffer, 0);
				if (itemRecordIndex == 0)
				{
					continue;
				}
				uint itemRecordAddress = itemRecordTableBaseAddress + itemRecordIndex * GameConfigurationManager.memorySignatureScanConfig_106.resolvedValue;
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, itemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_106.resolvedValue - 4, fourByteBuffer, 4, ref bytesTransferred);
				if (BitConverter.ToInt32(fourByteBuffer, 0) != 0)
				{
					continue;
				}
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, itemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_107.resolvedValue, fourByteBuffer, 1, ref bytesTransferred);
				if (fourByteBuffer[0] == 0)
				{
					continue;
				}
				processedEntryCount++;
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, inventoryEntryAddress + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 8, fourByteBuffer, 1, ref bytesTransferred);
				if (fourByteBuffer[0] != 3)
				{
					continue;
				}
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, itemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_119.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
				int itemQuantity = BitConverter.ToInt32(fourByteBuffer, 0);
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, itemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_119.resolvedValue + 4, fourByteBuffer, 4, ref bytesTransferred);
				int maxStackQuantity = BitConverter.ToInt32(fourByteBuffer, 0);
				if (itemQuantity > 0 && maxStackQuantity > 0 && maxStackQuantity > itemQuantity)
				{
					int mergeResultCode = TryMergeInventoryItemAtIndex(characterAccountConfig_0, ref failedMergeEntryIndices, entryIndex);
					if (mergeResultCode > 0)
					{
						entryIndex = 0u;
						processedEntryCount = 0;
					}
				}
			}
			InventoryItemMemoryHelper.PlaceHeldItemInContainer(characterAccountConfig_0, 3u);
			break;
		}
		GameProcessInteractionHelper.WriteSharedSlotInt32(characterAccountConfig_0, GameProcessInteractionHelper.inventoryOperationStateSlot, 0, 4);
	}

	private static int TryMergeInventoryItemAtIndex(CharacterAccountConfig characterAccountConfig_0, ref uint[] uint_0, uint uint_1)
	{
		int bytesTransferred = 0;
		byte[] fourByteBuffer = new byte[4];
		byte[] itemNameBuffer = new byte[60];
		int operationStateCode = GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig_0, GameProcessInteractionHelper.inventoryOperationStateSlot, 4);
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
		uint inventoryEntryTableBaseAddress = BitConverter.ToUInt32(fourByteBuffer, 0) + GameConfigurationManager.memorySignatureScanConfig_97.resolvedValue;
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_105.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
		uint itemRecordTableBaseAddress = BitConverter.ToUInt32(fourByteBuffer, 0);
		uint sourceInventoryEntryAddress = inventoryEntryTableBaseAddress + uint_1 * 20;
		WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, sourceInventoryEntryAddress + GameConfigurationManager.memorySignatureScanConfig_99.resolvedValue * 4, fourByteBuffer, 4, ref bytesTransferred);
		uint sourceItemRecordIndex = BitConverter.ToUInt32(fourByteBuffer, 0);
		if (sourceItemRecordIndex != 0)
		{
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, sourceInventoryEntryAddress + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 8, fourByteBuffer, 1, ref bytesTransferred);
			byte sourceContainerId = fourByteBuffer[0];
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, sourceInventoryEntryAddress + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 4, fourByteBuffer, 1, ref bytesTransferred);
			byte sourceGridX = fourByteBuffer[0];
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, sourceInventoryEntryAddress + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue, fourByteBuffer, 1, ref bytesTransferred);
			byte sourceGridY = fourByteBuffer[0];
			uint sourceItemRecordAddress = itemRecordTableBaseAddress + sourceItemRecordIndex * GameConfigurationManager.memorySignatureScanConfig_106.resolvedValue;
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, sourceItemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_111.resolvedValue, fourByteBuffer, 1, ref bytesTransferred);
			byte sourceItemWidth = fourByteBuffer[0];
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, sourceItemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_112.resolvedValue, fourByteBuffer, 1, ref bytesTransferred);
			byte sourceItemHeight = fourByteBuffer[0];
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, sourceItemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_107.resolvedValue, itemNameBuffer, itemNameBuffer.Length, ref bytesTransferred);
			byte sourceItemNameFirstByte = itemNameBuffer[0];
			string sourceItemName = GameTextEncodingHelper.DecodeNullTerminatedUtf7(itemNameBuffer);
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, sourceItemRecordAddress + InventoryItemMemoryHelper.uint_1, fourByteBuffer, 4, ref bytesTransferred);
			uint sourceItemSignatureValue1 = BitConverter.ToUInt32(fourByteBuffer, 0);
			WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, sourceItemRecordAddress + InventoryItemMemoryHelper.uint_1 + 4, fourByteBuffer, 4, ref bytesTransferred);
			uint sourceItemSignatureValue2 = BitConverter.ToUInt32(fourByteBuffer, 0);
			int mergedItemCount = 0;
			int processedEntryCount = 0;
			int inventoryEntryCount = InventoryItemMemoryHelper.GetInventoryEntryCount(characterAccountConfig_0);
			itemNameBuffer = new byte[sourceItemName.Length + 2];
			for (uint candidateEntryIndex = 1u; candidateEntryIndex < GameConfigurationManager.int_1 && inventoryEntryCount > processedEntryCount && GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig_0, GameProcessInteractionHelper.inventoryOperationStateSlot, 4) == operationStateCode; candidateEntryIndex++)
			{
				uint candidateInventoryEntryAddress = inventoryEntryTableBaseAddress + candidateEntryIndex * 20;
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, candidateInventoryEntryAddress + GameConfigurationManager.memorySignatureScanConfig_99.resolvedValue * 4, fourByteBuffer, 4, ref bytesTransferred);
				uint candidateItemRecordIndex = BitConverter.ToUInt32(fourByteBuffer, 0);
				if (candidateItemRecordIndex == 0)
				{
					continue;
				}
				uint candidateItemRecordAddress = itemRecordTableBaseAddress + candidateItemRecordIndex * GameConfigurationManager.memorySignatureScanConfig_106.resolvedValue;
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, candidateItemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_106.resolvedValue - 4, fourByteBuffer, 4, ref bytesTransferred);
				if (BitConverter.ToInt32(fourByteBuffer, 0) != 0)
				{
					continue;
				}
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, candidateItemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_107.resolvedValue, fourByteBuffer, 1, ref bytesTransferred);
				byte candidateItemNameFirstByte = fourByteBuffer[0];
				processedEntryCount++;
				if (candidateEntryIndex == uint_1 || candidateItemNameFirstByte != sourceItemNameFirstByte)
				{
					continue;
				}
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, candidateItemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_107.resolvedValue, itemNameBuffer, itemNameBuffer.Length, ref bytesTransferred);
				string candidateItemName = GameTextEncodingHelper.DecodeNullTerminatedUtf7(itemNameBuffer);
				if (candidateItemName != sourceItemName)
				{
					continue;
				}
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, candidateInventoryEntryAddress + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 8, fourByteBuffer, 1, ref bytesTransferred);
				if (fourByteBuffer[0] != sourceContainerId)
				{
					continue;
				}
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, candidateItemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_108.resolvedValue, fourByteBuffer, 1, ref bytesTransferred);
				if (fourByteBuffer[0] == 0)
				{
					continue;
				}
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, candidateItemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_111.resolvedValue, fourByteBuffer, 1, ref bytesTransferred);
				byte candidateItemWidth = fourByteBuffer[0];
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, candidateItemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_112.resolvedValue, fourByteBuffer, 1, ref bytesTransferred);
				byte candidateItemHeight = fourByteBuffer[0];
				if (sourceItemWidth != candidateItemWidth || sourceItemHeight != candidateItemHeight)
				{
					continue;
				}
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, candidateItemRecordAddress + InventoryItemMemoryHelper.uint_1, fourByteBuffer, 4, ref bytesTransferred);
				uint candidateSignatureValue1 = BitConverter.ToUInt32(fourByteBuffer, 0);
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, candidateItemRecordAddress + InventoryItemMemoryHelper.uint_1 + 4, fourByteBuffer, 4, ref bytesTransferred);
				uint candidateSignatureValue2 = BitConverter.ToUInt32(fourByteBuffer, 0);
				if (candidateSignatureValue1 != sourceItemSignatureValue1 || candidateSignatureValue2 != sourceItemSignatureValue2)
				{
					continue;
				}
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, candidateItemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_119.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
				int candidateQuantity = BitConverter.ToInt32(fourByteBuffer, 0);
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, candidateItemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_119.resolvedValue + 4, fourByteBuffer, 4, ref bytesTransferred);
				int candidateMaxStackQuantity = BitConverter.ToInt32(fourByteBuffer, 0);
				if (candidateQuantity <= 0 || candidateMaxStackQuantity <= 0 || candidateMaxStackQuantity <= candidateQuantity)
				{
					continue;
				}
				if (uint_0 != null)
				{
					bool alreadyFailedCandidate = false;
					for (int failedEntryIndex = 0; failedEntryIndex < uint_0.Length; failedEntryIndex++)
					{
						if (uint_0[failedEntryIndex] == candidateEntryIndex)
						{
							alreadyFailedCandidate = true;
							break;
						}
					}
					if (alreadyFailedCandidate)
					{
						continue;
					}
				}
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, candidateInventoryEntryAddress + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue - 4, fourByteBuffer, 1, ref bytesTransferred);
				uint candidateGridX = fourByteBuffer[0];
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, candidateInventoryEntryAddress + GameConfigurationManager.memorySignatureScanConfig_100.resolvedValue, fourByteBuffer, 1, ref bytesTransferred);
				uint candidateGridY = fourByteBuffer[0];
				int moveRetryCount = 0;
				int moveStartedFlag = 0;
				while (!CommonUtility.bool_0)
				{
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_123.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
					if (BitConverter.ToInt32(fourByteBuffer, 0) <= 0)
					{
						if (moveRetryCount % 8 == 0)
						{
							GameProcessInteractionHelper.MoveInventoryItemBetweenPositions(characterAccountConfig_0, candidateGridX, candidateGridY, sourceContainerId, candidateGridX, candidateGridY, sourceContainerId);
						}
						if (moveRetryCount <= 60)
						{
							Thread.Sleep(10);
							moveRetryCount++;
							continue;
						}
						CommonUtility.AppendUIntIfMissing(ref uint_0, candidateEntryIndex);
						break;
					}
					moveStartedFlag = 1;
					break;
				}
				moveRetryCount = 0;
				while (!CommonUtility.bool_0 && moveStartedFlag > 0)
				{
					WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, GameConfigurationManager.memorySignatureScanConfig_123.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
					if (BitConverter.ToInt32(fourByteBuffer, 0) != 0)
					{
						if (moveRetryCount % 8 == 0)
						{
							GameProcessInteractionHelper.MoveInventoryItemBetweenPositions(characterAccountConfig_0, sourceGridX, sourceGridY, sourceContainerId, sourceGridX, sourceGridY, sourceContainerId);
						}
						if (moveRetryCount <= 60)
						{
							moveRetryCount++;
							Thread.Sleep(10);
							continue;
						}
						GameProcessInteractionHelper.MoveInventoryItemBetweenPositions(characterAccountConfig_0, candidateGridX, candidateGridY, sourceContainerId, candidateGridX, candidateGridY, sourceContainerId);
						CommonUtility.AppendUIntIfMissing(ref uint_0, candidateEntryIndex);
						break;
					}
					mergedItemCount++;
					break;
				}
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, sourceInventoryEntryAddress + GameConfigurationManager.memorySignatureScanConfig_99.resolvedValue * 4, fourByteBuffer, 4, ref bytesTransferred);
				if (BitConverter.ToUInt32(fourByteBuffer, 0) == 0)
				{
					break;
				}
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, sourceItemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_119.resolvedValue, fourByteBuffer, 4, ref bytesTransferred);
				int sourceQuantityAfterMerge = BitConverter.ToInt32(fourByteBuffer, 0);
				WindowsInteropHelper.ReadProcessMemory(characterAccountConfig_0.int_137, sourceItemRecordAddress + GameConfigurationManager.memorySignatureScanConfig_119.resolvedValue + 4, fourByteBuffer, 4, ref bytesTransferred);
				int sourceMaxStackAfterMerge = BitConverter.ToInt32(fourByteBuffer, 0);
				if (sourceMaxStackAfterMerge <= sourceQuantityAfterMerge)
				{
					break;
				}
			}
			return mergedItemCount;
		}
		return 0;
	}
}
