using System;
using System.Threading;
using ns1;
using ns100;
using ns11;
using ns23;
using ns3;
using ns52;
using ns53;
using ns71;

namespace ns84;

internal class PartyManagementHelper
{
	public int int_0 = 0;

	public static void InvokeTeamCreationRemoteAction(CharacterAccountConfig characterAccountConfig_0)
	{
		GameProcessInteractionHelper.ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_53);
	}

	public static void CreateTeam(CharacterAccountConfig characterAccountConfig_0)
	{
		GameProcessInteractionHelper.ExecuteGameScript(characterAccountConfig_0, "CreateTeam()");
	}

	public static void InvokeTeamLeaveRemoteAction(CharacterAccountConfig characterAccountConfig_0)
	{
		GameProcessInteractionHelper.ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_54);
	}

	public static void InviteToTeam(CharacterAccountConfig characterAccountConfig_0, string string_0)
	{
		GameProcessInteractionHelper.ExecuteGameScript(characterAccountConfig_0, "InviteTeam('" + string_0 + "')");
	}

	public static bool IsInTeam(CharacterAccountConfig characterAccountConfig_0)
	{
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, characterAccountConfig_0.int_137);
		return WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_12.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_202.resolvedValue, characterAccountConfig_0.int_137) != 0;
	}

	public static GStruct61 ReadTeamInfo(CharacterAccountConfig characterAccountConfig_0)
	{
		GStruct60[] array = new GStruct60[8];
		int num = 0;
		string string_ = string.Empty;
		for (int i = 0; i < 8; i++)
		{
			string text = WindowsInteropHelper.ReadNullTerminatedUtf7ProcessString(GameConfigurationManager.memorySignatureScanConfig_203.resolvedValue + characterAccountConfig_0.uint_7 + (uint)(i * (int)GameConfigurationManager.memorySignatureScanConfig_198.resolvedValue), characterAccountConfig_0.int_137, 32);
			if (text != string.Empty)
			{
				num++;
				if (i == 0)
				{
					string_ = text;
				}
				array[i].memberName = text;
				array[i].memberSlotIndex = i;
				array[i].int_0 = (int)WindowsInteropHelper.ReadProcessUInt32((uint)(GameConfigurationManager.memorySignatureScanConfig_200.resolvedValue + characterAccountConfig_0.uint_7 + i * GameConfigurationManager.memorySignatureScanConfig_199.resolvedValue), characterAccountConfig_0.int_137);
			}
		}
		return new GStruct61
		{
			memberCount = num,
			leaderName = string_,
			gstruct60_0 = array
		};
	}

	public static void RespondToTeamInvitation(CharacterAccountConfig characterAccountConfig_0, string[] string_0 = null, bool bool_0 = true)
	{
		string text = GameMessageReader.ReadMessages(characterAccountConfig_0, includeMessageId: true);
		string[] array = text.Split(';');
		if (array.Length < 2)
		{
			return;
		}
		if (string_0 != null && string_0.Length != 0)
		{
			bool flag = false;
			array[1] = GameTextEncodingHelper.ConvertGameTextToDisplayText(array[1], 1);
			for (int i = 0; i < string_0.Length; i++)
			{
				if (array[1] == string_0[i])
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				return;
			}
		}
		uint uint_ = CommonUtility.ParseUInt32OrZero(array[0]);
		WindowsInteropHelper.WriteProcessUIntValue(characterAccountConfig_0.uint_55 + 2, characterAccountConfig_0.int_137, uint_);
		WindowsInteropHelper.WriteProcessUIntValue(characterAccountConfig_0.uint_55 + 7, characterAccountConfig_0.int_137, Convert.ToByte(bool_0), 1);
		GameProcessInteractionHelper.ExecuteRemoteStub(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_55);
	}

	private int FindAccountIndexByProcessId(CharacterAccountConfig[] characterAccountConfig_0, int int_1)
	{
		if (characterAccountConfig_0 != null && characterAccountConfig_0.Length != 0)
		{
			for (int i = 0; i < characterAccountConfig_0.Length; i++)
			{
				if (int_1 == characterAccountConfig_0[i].int_136)
				{
					return i;
				}
			}
		}
		return -1;
	}

	public void method_1()
	{
		int int_ = int_0;
		int num = 1;
		int num2 = 255;
		long long_ = 0L;
		string[] array = new string[2] { "chó", "thÝm" };
		GStruct62 gStruct = default(GStruct62);
		while (!CommonUtility.bool_0)
		{
			Thread.Sleep(300);
			int num3 = FindAccountIndexByProcessId(Form1.characterAccountConfig_1, int_);
			if (num3 < 0)
			{
				break;
			}
			CharacterAccountConfig characterAccountConfig_ = Form1.characterAccountConfig_1[num3];
			if (!characterAccountConfig_.bool_25)
			{
				break;
			}
			if (gStruct.string_0 == null || gStruct.string_0 == "")
			{
				continue;
			}
			string[] array2 = gStruct.string_0.Split(',');
			if (array2 == null || array2.Length == 0)
			{
				continue;
			}
			int num4 = -1;
			for (int i = 0; i < array2.Length; i++)
			{
				if (array2[i] == characterAccountConfig_.string_22 || array2[i] == GameTextEncodingHelper.ConvertGameTextToDisplayText(characterAccountConfig_.string_22, 1))
				{
					num4 = i;
					break;
				}
			}
			if (num4 < 0)
			{
				continue;
			}
			gStruct.int_0 = Convert.ToByte(num4 == 0) + 3 * Convert.ToByte(num4 != 0);
			uint num5 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, characterAccountConfig_.int_137);
			uint num6 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_165.resolvedValue, characterAccountConfig_.int_137);
			uint uint_ = WindowsInteropHelper.ReadProcessUInt32(num6 + GameConfigurationManager.memorySignatureScanConfig_167.resolvedValue, characterAccountConfig_.int_137);
			uint num7 = WindowsInteropHelper.ReadProcessUInt32(uint_, characterAccountConfig_.int_137);
			string text = WindowsInteropHelper.ReadNullTerminatedUtf7ProcessString(num7, characterAccountConfig_.int_137, 60);
			GStruct61 gStruct2 = ReadTeamInfo(characterAccountConfig_);
			bool flag = IsInTeam(characterAccountConfig_);
			if (gStruct.int_0 == 1 && (array2 == null || array2.Length == 0))
			{
				continue;
			}
			if (gStruct.int_0 <= 1)
			{
				if (flag)
				{
					if (!(gStruct2.leaderName != characterAccountConfig_.string_22))
					{
						if (gStruct2.memberCount != 8)
						{
							if (num >= num2)
							{
								num = 1;
							}
							int num8 = 0;
							for (int j = num; j < num2; j++)
							{
								num8++;
								uint num9 = (uint)j * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
								uint num10 = WindowsInteropHelper.ReadProcessUInt32(num5 + num9 + GameConfigurationManager.memorySignatureScanConfig_52.resolvedValue, characterAccountConfig_.int_137);
								if (num10 != 1 || WindowsInteropHelper.ReadProcessUInt32(num5 + num9 + GameConfigurationManager.memorySignatureScanConfig_50.resolvedValue, characterAccountConfig_.int_137) == 0)
								{
									continue;
								}
								string text2 = WindowsInteropHelper.ReadNullTerminatedUtf7ProcessString(num5 + num9 + GameConfigurationManager.memorySignatureScanConfig_16.resolvedValue, characterAccountConfig_.int_137, 32);
								if (text2 == "" || text2 == characterAccountConfig_.string_22)
								{
									continue;
								}
								if (CommonUtility.bool_0)
								{
									return;
								}
								Thread.Sleep(200);
								bool flag2 = false;
								string text3 = GameTextEncodingHelper.ConvertGameTextToDisplayText(text2, 1);
								if (gStruct2.memberCount > 0 && gStruct2.gstruct60_0 != null)
								{
									for (int k = 0; k < gStruct2.gstruct60_0.Length; k++)
									{
										if (gStruct2.gstruct60_0[k].memberName != null && gStruct2.gstruct60_0[k].memberName != "" && gStruct2.gstruct60_0[k].memberName == text2)
										{
											flag2 = true;
											break;
										}
									}
								}
								if (flag2)
								{
									continue;
								}
								if (gStruct.int_0 == 1)
								{
									flag2 = true;
									if (array2 != null && array2.Length != 0)
									{
										for (int l = 0; l < array2.Length; l++)
										{
											if (text2 == array2[l] || text3 == array2[l])
											{
												flag2 = false;
												break;
											}
										}
									}
								}
								if (!flag2)
								{
									InviteToTeam(characterAccountConfig_, text2);
									if (CommonUtility.GetElapsedMilliseconds(long_) > 3000L)
									{
										int num11 = Convert.ToByte(GameEntityMemoryHelper.ReadEntitySexValue(characterAccountConfig_, j) > 0);
										string text4 = "<color=green>" + text2 + "<color=white> vµo pt ®i " + array[num11] + " :B";
										GameProcessInteractionHelper.ExecuteGameScript(characterAccountConfig_, "Chat('CH_NEARBY', '" + text4 + "')");
										long_ = CommonUtility.GetCurrentTicks();
									}
									break;
								}
							}
							num = ((num8 != 0) ? (num + num8) : (num + 1));
						}
					}
					else
					{
						InvokeTeamLeaveRemoteAction(characterAccountConfig_);
					}
				}
				else
				{
					CreateTeam(characterAccountConfig_);
				}
			}
			else
			{
				if (text == string.Empty)
				{
					continue;
				}
				if (flag)
				{
					if (gStruct.int_0 == 2 || array2 == null || array2.Length == 0)
					{
						if (gStruct2.leaderName != characterAccountConfig_.string_22)
						{
							goto IL_06cd;
						}
						InvokeTeamLeaveRemoteAction(characterAccountConfig_);
						flag = false;
						Thread.Sleep(450);
					}
					if (gStruct2.gstruct60_0 != null)
					{
						for (int m = 0; m < gStruct2.gstruct60_0.Length; m++)
						{
							Thread.Sleep(100);
							string string_ = gStruct2.gstruct60_0[m].memberName;
							if (string_ == null || string_ == "" || string_ == characterAccountConfig_.string_22)
							{
								continue;
							}
							string_ = GameTextEncodingHelper.ConvertGameTextToDisplayText(string_, 1);
							int num12 = 0;
							while (num12 < array2.Length)
							{
								if (!(string_ == array2[num12]))
								{
									Thread.Sleep(100);
									num12++;
									continue;
								}
								goto IL_06cd;
							}
						}
					}
				}
				if (CommonUtility.FindSubstringIndex(text, "mêi tæ ®éi") > 0)
				{
					string text5 = WindowsInteropHelper.ReadNullTerminatedUtf7ProcessString(num7 + GameConfigurationManager.memorySignatureScanConfig_205.resolvedValue, characterAccountConfig_.int_137, 25);
					if (!(text5 == string.Empty))
					{
						if (!flag || gStruct.int_0 <= 2 || array2 == null || array2.Length == 0)
						{
							goto IL_062a;
						}
						text5 = GameTextEncodingHelper.ConvertGameTextToDisplayText(text5, 1);
						int num13 = 0;
						while (num13 < array2.Length)
						{
							if (!(text5 == array2[num13]))
							{
								num13++;
								continue;
							}
							goto IL_062a;
						}
					}
				}
			}
			goto IL_06cd;
			IL_062a:
			uint num14 = WindowsInteropHelper.ReadProcessUInt32(num7 + GameConfigurationManager.memorySignatureScanConfig_170.resolvedValue, characterAccountConfig_.int_137);
			if (num14 != 0 && num14 < int.MaxValue)
			{
				WindowsInteropHelper.WriteProcessUIntValue(characterAccountConfig_.uint_55 + 2, characterAccountConfig_.int_137, num14);
				WindowsInteropHelper.WriteProcessUIntValue(characterAccountConfig_.uint_55 + 7, characterAccountConfig_.int_137, 1u, 1);
				GameProcessInteractionHelper.ExecuteRemoteStub(characterAccountConfig_.int_137, characterAccountConfig_.uint_55);
				if (CommonUtility.GetElapsedMilliseconds(long_) > 2500L)
				{
					GameProcessInteractionHelper.ExecuteGameScript(characterAccountConfig_, "Chat('CH_NEARBY', 'C\u00b8m ¬n thÝm ®· mêi !:0')");
					long_ = CommonUtility.GetCurrentTicks();
				}
				Thread.Sleep(500);
				continue;
			}
			goto IL_06cd;
			IL_06cd:
			if (text != string.Empty)
			{
				GameProcessInteractionHelper.ExecuteRemoteStub(characterAccountConfig_.int_137, characterAccountConfig_.uint_56);
			}
			Thread.Sleep(300);
		}
	}
}
