using System;
using System.Diagnostics;
using System.Threading;
using ns11;
using ns146;
using ns23;
using ns30;
using ns53;
using ns63;

namespace ns32;

internal class AutoVlbs19Patcher
{
	public static string string_0 = WindowsRegistryHelper.ReadApplicationRegistryString("SBLV", 0, "SBLV");

	public static string ErrorMessage = null;

	private static uint findWindowAddress = 0u;

	private static byte originalFindWindowByte = 0;

	public void LaunchAndPatch()
	{
		string text = GameConfigurationManager.applicationDirectory + "\\Login\\AutoVLBS19\\AutoVLBS.exe";
		if (CommonUtility.FileExists(text))
		{
			if (HardwareLicenseIdentity.bool_0 && CommonUtility.long_0 >= GClass1.long_1 && GClass1.long_1 > 0L)
			{
				uint num = 4194304u;
				uint num2 = 4194304u;
				uint num3 = 4319353u;
				uint num4 = 4318750u;
				uint num5 = 4316631u;
				if (findWindowAddress == 0)
				{
					int num6 = WindowsInteropHelper.ReadCurrentProcessId();
					uint uint_ = WindowsInteropHelper.FindLoadedModuleBaseAddress(num6, "user32.dll");
					findWindowAddress = WindowsInteropHelper.GetProcAddress(uint_, "FindWindowA");
					if (findWindowAddress == 0)
					{
						ErrorMessage = "Không thể load modul user32.dll, kết thúc!";
						return;
					}
					int int_ = WindowsInteropHelper.OpenProcess(2035711, bool_0: false, num6);
					int int_2 = 0;
					byte[] array = new byte[1];
					WindowsInteropHelper.ReadProcessMemory(int_, findWindowAddress + 5, array, 1, ref int_2);
					originalFindWindowByte = array[0];
				}
				int int_3 = 0;
				int num7 = 0;
				int num8 = 0;
				int num9 = 0;
				uint num10 = 0u;
				uint num11 = 0u;
				byte[] array2 = new byte[1];
				string environmentVariable = Environment.GetEnvironmentVariable(CommonUtility.DecodeCharArrayToString(GameConfigurationManager.char_0));
				string string_ = environmentVariable + "\\system32\\z_sblv.txt";
				string string_2 = environmentVariable + "\\system32\\z_sblvlog.txt";
				string string_3 = "ᗞᗣᗟᗂᗛᗒᗣᗃᗝᗸᗹᗄᗘᖼᗥᗃᗴᗑᗚᗃᗗᗨᘆᘃᗙᗵᗀᗂᗞᗣᗟᗂᗛᗒᗣᗃᗝᗸᗹᗄᗘᖼᗦᗸᗴᗑᗒᗃᗗᗘᘇᗒᗮᗓᗡᗴᗱᖿᗔᗷᗥᖻᘂᘀᗱᗥᗹᖼᗱᗎᗥᖿᗝᗡᗴᗸᗘᘊᗨᗃᗳᗐᗙᗶᗟᗧᘅᘅᗲᗏᗐᗈᗥᗼᗣᗿᗤᗡᗅᗖᗱᗺᗢᗷᗰᗔᗤᖾᗜᗠᗳᗷᗞᘉᗧᗂᗲᗏᗘᗼᗞᗦᘄᘄᗱᗎᗖᗇᗤᗸᘄᗳᗮᗨᗡᘄᗳᗐᗠᖺᗟᗣᗶᗺᗚᘅᗣᗅᗵᗒᗛᗸᗚᗢᘇᘇᗴᗑᗒᗃᗯᗻᗡᘇᗮᗤᗥᗶᗳᗽᘅᖾᗚᗏᗵᗄᗩᗸᗰᖾᗚᗢᘇᘉᗨᗡᗸᗃᗗᗨᘆᘆᗳᗓᗄᗹᗲᗥᗇᖿᗮᗹᘁᗁᗝᗒᗸᗀᗥᗴᗳᗁᗝᗥᘃᘅᗤᗤᗻᗆᗚᗤᘂᘂᗶᗔᗨᗏᗟᖻᗠᗶᗤᖾᗣᗟᗡᗵᗼᗓᗠᗥᘄᗸᗘᗔᗑᗹᗚᗓᗜᘁᗝᗗᘅᘆᗲᗏᗘᗖᗞᗖᘄᖾᗥᗷᗥᘇᗴᗓᗚᗠᗗᘊᗘᖿᗚᗐᗘᘂᗝᗔᗔᗡᗛᗡᗔᗪᗜᘈᗖᖿᗝᗶᗻᗌ";
				string string_4 = "ᒶᓪᓩᓤᓋᓁᒷᓈᒕᒦᒣᒮ";
				string[] array3 = CommonUtility.SplitPrefixAndLastSegment(text);
				Process process = null;
				CommonUtility.WriteAllTextWithEncodingOption(string_, CommonUtility.DecodeLengthShiftedString(string_3), 1);
				CommonUtility.WriteAllTextWithEncodingOption(string_2, CommonUtility.DecodeLengthShiftedString(string_4), 1);
				GStruct4 gStruct = WindowsInteropHelper.LaunchProcess(text, array3[0]);
				if (!CommonUtility.bool_0 && gStruct.uint_0 != 0)
				{
					int processId = (int)gStruct.uint_0;
					try
					{
						process = Process.GetProcessById(processId);
					}
					catch
					{
					}
					num7 = process.Id;
					num8 = WindowsInteropHelper.OpenProcess(2035711, bool_0: false, num7);
					num9 = 0;
					while (true)
					{
						if (!CommonUtility.bool_0)
						{
							num11 = WindowsInteropHelper.AllocateRemoteMemory(num8);
							if (num11 == 0)
							{
								num9++;
								if (num9 <= 600)
								{
									WindowsInteropHelper.ResumeAllProcessThreads(process);
									Thread.Sleep(1);
									WindowsInteropHelper.SuspendAllProcessThreads(process);
									continue;
								}
								ErrorMessage = "Lỗi 1, kết thúc.";
								break;
							}
						}
						num9 = 0;
						while (true)
						{
							if (!CommonUtility.bool_0)
							{
								WindowsInteropHelper.ReadProcessMemory(num8, findWindowAddress + 5, array2, 1, ref int_3);
								if (array2[0] != originalFindWindowByte)
								{
									num9++;
									if (num9 <= 3000)
									{
										WindowsInteropHelper.ResumeAllProcessThreads(process);
										Thread.Sleep(1);
										WindowsInteropHelper.SuspendAllProcessThreads(process);
										continue;
									}
									ErrorMessage = "Lỗi 1, kết thúc.".Replace("1", "2");
									break;
								}
							}
							string string_5 = "3E 8D 44 24 04 8B 00 85 C0 74 21 81 38 56 42 6F 78 75 19 81 78 04 54 72 61 79 75 10A3" + CommonUtility.FormatIntegerAsHex(num11, 8, bool_1: false, bool_2: true) + "90 9080 3D" + CommonUtility.FormatIntegerAsHex(num11, 8, bool_1: false, bool_2: true) + "0075 F7 8B FF 55 8B ECE9 00 00 00 00";
							array2 = CommonUtility.ParseHexBytePattern(string_5, bool_1: false);
							WindowsInteropHelper.WriteProcessMemory(num8, num11 + 4, array2, array2.Length, ref int_3);
							num10 = (uint)(array2.Length + 16);
							uint num12 = num11 + (uint)array2.Length;
							uint uint_2 = findWindowAddress - num12 + 1;
							WindowsInteropHelper.WriteProcessUIntValue(num12, num8, uint_2);
							array2 = new byte[1] { 233 };
							uint uint_3 = num11 - (findWindowAddress + 1);
							WindowsInteropHelper.WriteProcessMemory(num8, findWindowAddress, array2, 1, ref int_3);
							if (!WindowsInteropHelper.WriteProcessUIntValue(findWindowAddress + 1, num8, uint_3))
							{
								WindowsInteropHelper.TryKillProcess(process);
								ErrorMessage = "Phải đúng phiên bản AutoVLBS1.9";
								break;
							}
							WindowsInteropHelper.ResumeAllProcessThreads(process);
							num9 = 0;
							while (true)
							{
								if (!CommonUtility.bool_0)
								{
									if (WindowsInteropHelper.ReadProcessUInt32(num11, num8) == 0)
									{
										num9++;
										Thread.Sleep(1);
										if (num9 <= 5000)
										{
											if (num9 % 300 == 0 && WindowsInteropHelper.IsProcessExitedOrUnavailable(process))
											{
												break;
											}
											continue;
										}
										ErrorMessage = "Quá thời gian kiểm tra, kết thúc.";
										break;
									}
									WindowsInteropHelper.SuspendAllProcessThreads(process);
								}
								try
								{
									num = (uint)(int)process.MainModule.BaseAddress;
								}
								catch
								{
								}
								uint num13 = num + (num3 - num2);
								num9 = 0;
								while (true)
								{
									if (!CommonUtility.bool_0)
									{
										WindowsInteropHelper.ReadProcessMemory(num8, num13 + 5, array2, 1, ref int_3);
										if (array2[0] != 87)
										{
											num9++;
											if (num9 <= 3000)
											{
												WindowsInteropHelper.ResumeAllProcessThreads(process);
												Thread.Sleep(1);
												WindowsInteropHelper.SuspendAllProcessThreads(process);
												continue;
											}
											ErrorMessage = "Lỗi 1, kết thúc.".Replace("1", "3");
											break;
										}
									}
									uint num14 = num11 + num10;
									array2 = CommonUtility.ConvertStringToSingleByteArray(string_);
									WindowsInteropHelper.WriteProcessMemory(num8, num14, array2, array2.Length, ref int_3);
									num10 += (uint)(array2.Length + 16);
									num12 = num11 + num10;
									string_5 = "B8" + CommonUtility.FormatIntegerAsHex(num14, 8, bool_1: false, bool_2: true) + "3E 8B 4D E0 53 8A 18 88 19 40 41 84 DB 75 F6 5B 68 01 00 00 04E9 00 00 00 00";
									array2 = CommonUtility.ParseHexBytePattern(string_5);
									WindowsInteropHelper.WriteProcessMemory(num8, num11 + num10, array2, array2.Length, ref int_3);
									uint uint_4 = num11 + num10 - (num13 + 5);
									uint num15 = (uint)((int)(num11 + num10) + array2.Length - 4);
									uint uint_5 = num13 - num15 + 1;
									num10 += (uint)(array2.Length + 16);
									array2 = new byte[1] { 233 };
									WindowsInteropHelper.WriteProcessMemory(num8, num13, array2, 1, ref int_3);
									WindowsInteropHelper.WriteProcessUIntValue(num13 + 1, num8, uint_4);
									WindowsInteropHelper.WriteProcessUIntValue(num15, num8, uint_5);
									num13 = num + (num4 - num2);
									WindowsInteropHelper.ReadProcessMemory(num8, num13 + 5, array2, 1, ref int_3);
									if (array2[0] != 106)
									{
										ErrorMessage = "Không kiểm tra được F2, kết thúc.";
										break;
									}
									uint num16 = num11 + num10;
									array2 = CommonUtility.ConvertStringToSingleByteArray(string_2);
									WindowsInteropHelper.WriteProcessMemory(num8, num16, array2, array2.Length, ref int_3);
									num10 += (uint)(array2.Length + 16);
									num12 = num11 + num10;
									string_5 = "B8" + CommonUtility.FormatIntegerAsHex(num16, 8, bool_1: false, bool_2: true) + "3E 8D 8D 98 F7 FF FF 53 8A 18 88 19 40 41 84 DB 75 F6 5B 68 01 00 00 04E9 00 00 00 00";
									array2 = CommonUtility.ParseHexBytePattern(string_5);
									WindowsInteropHelper.WriteProcessMemory(num8, num11 + num10, array2, array2.Length, ref int_3);
									uint_4 = num11 + num10 - (num13 + 5);
									num15 = (uint)((int)(num11 + num10) + array2.Length - 4);
									uint_5 = num13 - num15 + 1;
									num10 += (uint)(array2.Length + 16);
									array2 = new byte[1] { 233 };
									WindowsInteropHelper.WriteProcessMemory(num8, num13, array2, 1, ref int_3);
									WindowsInteropHelper.WriteProcessUIntValue(num13 + 1, num8, uint_4);
									WindowsInteropHelper.WriteProcessUIntValue(num15, num8, uint_5);
									uint num17 = num11 + num10;
									num10 += 80;
									uint num18 = num11 + num10;
									if (string_0 == null || string_0 == string.Empty)
									{
										string_0 = "SBLV";
									}
									array2 = CommonUtility.ConvertStringToSingleByteArray(string_0);
									WindowsInteropHelper.WriteProcessMemory(num8, num17, array2, array2.Length, ref int_3);
									uint num19 = num + (num5 - num2);
									uint_4 = num18 - (num19 + 5);
									array2 = CommonUtility.ParseHexBytePattern("E9" + CommonUtility.FormatIntegerAsHex(uint_4, 8, bool_1: false, bool_2: true), bool_1: false);
									WindowsInteropHelper.WriteProcessMemory(num8, num19, array2, array2.Length, ref int_3);
									string_5 = "60 8B 4C 24 28 80 39 00 74 2C 33 C0 8A 19 40 41 84 DB 75 F8 83 F8 0F 7E 1D 48 49 8A 19 85 C0 74 15 80 FB 7C 75 F341BF" + CommonUtility.FormatIntegerAsHex(num17, 8, bool_1: false, bool_2: true) + "8A 1F 88 19 41 47 84 DB 75 F6 61 E9";
									uint num20 = (uint)string_5.Replace(" ", string.Empty).Length / 2u;
									uint_5 = num19 - (num18 + num20) + 1;
									string_5 += CommonUtility.FormatIntegerAsHex(uint_5, 8, bool_1: false, bool_2: true);
									array2 = CommonUtility.ParseHexBytePattern(string_5);
									WindowsInteropHelper.WriteProcessMemory(num8, num18, array2, array2.Length, ref int_3);
									break;
								}
								break;
							}
							break;
						}
						break;
					}
					if (num11 != 0)
					{
						array2 = new byte[5] { 139, 255, 85, 139, 236 };
						WindowsInteropHelper.WriteProcessMemory(num8, findWindowAddress, array2, array2.Length, ref int_3);
						WindowsInteropHelper.WriteProcessUIntValue(num11, num8, 0u);
					}
					WindowsInteropHelper.ResumeAllProcessThreads(process);
					WindowsInteropHelper.CloseHandleSafely(num8);
				}
				else
				{
					ErrorMessage = "Không thể mở auto, kiểm tra xem auto trong thư mục login có vấn đề gì hay không ?";
				}
			}
			else
			{
				ErrorMessage = "Chỉ có thể sử dụng được khi đăng ký lic hdd";
			}
		}
		else
		{
			ErrorMessage = "Hãy chép AutoVLBS19 vào thư mục X".Replace("X", text);
		}
	}
}
