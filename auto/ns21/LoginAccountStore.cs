using System.Diagnostics;
using ns11;
using ns118;
using ns23;
using ns49;
using ns53;
using ns89;

namespace ns21;

internal class LoginAccountStore
{
	public static string TransformStoredText(string string_0)
	{
		if (string_0 != null && !(string_0 == ""))
		{
			string text = "";
			char[] array = string_0.ToCharArray();
			for (int i = 0; i < array.Length; i++)
			{
				text += (char)(255 - array[i]);
			}
			return text;
		}
		return "";
	}

	public static void SaveAccounts()
	{
		string text = string.Empty;
		if (FormLogin.gstruct0_0 != null)
		{
			for (int i = 0; i < FormLogin.gstruct0_0.Length; i++)
			{
				GStruct0 gStruct = FormLogin.gstruct0_0[i];
				string string_ = gStruct.accountName + "\u0002" + gStruct.encodedPassword + "\u0002" + gStruct.characterSlotNumber + "\u0002" + gStruct.serverGroupName + "\u0002" + gStruct.serverName + "\u0002" + gStruct.characterName + "\u0002" + gStruct.string_5 + "\u0002" + gStruct.string_6 + "\u0002" + gStruct.int_3 + "\u0002None";
				string text2 = CommonUtility.EncodeBase64Utf8(TransformStoredText(string_));
				if (text != string.Empty)
				{
					text += "\u0001";
				}
				text += text2;
			}
		}
		CommonUtility.EnsureDirectoryExists(FormLogin.loginDataDirectoryPath);
		CommonUtility.WriteAllTextWithEncodingOption(FormLogin.loginAccountListFilePath, text, 1);
	}

	public static void LoadAccounts()
	{
		FormLogin.accountsLoadCompleted = false;
		FormLogin.accountsDirty = false;
		int num = 10;
		string text = CommonUtility.ReadAllTextWithEncodingOption(FormLogin.loginAccountListFilePath, 0, 0, 1);
		if (text == string.Empty)
		{
			FormLogin.accountsLoadCompleted = true;
			FormLogin.accountsDirty = true;
			return;
		}
		string[] array = text.Split('\u0001');
		string[,] array2 = new string[array.Length, num];
		int num2 = 0;
		for (int i = 0; i < array.Length; i++)
		{
			string text2 = CommonUtility.DecodeBase64Utf8(array[i]);
			if (text2 == null || text2 == string.Empty)
			{
				continue;
			}
			string[] array3 = TransformStoredText(text2).Split('\u0002');
			if (array3.Length >= num)
			{
				for (int j = 0; j < num; j++)
				{
					array2[num2, j] = array3[j];
				}
				num2++;
			}
		}
		if (num2 != 0)
		{
			FormLogin.gstruct0_0 = new GStruct0[num2];
			for (int k = 0; k < num2; k++)
			{
				FormLogin.gstruct0_0[k].accountName = array2[k, 0];
				FormLogin.gstruct0_0[k].encodedPassword = array2[k, 1];
				FormLogin.gstruct0_0[k].characterSlotNumber = CommonUtility.ParseInt32OrZero(array2[k, 2]);
				FormLogin.gstruct0_0[k].serverGroupName = array2[k, 3];
				FormLogin.gstruct0_0[k].serverName = array2[k, 4];
				FormLogin.gstruct0_0[k].characterName = array2[k, 5];
				FormLogin.gstruct0_0[k].string_5 = array2[k, 6];
				FormLogin.gstruct0_0[k].string_6 = array2[k, 7];
				FormLogin.gstruct0_0[k].int_3 = CommonUtility.ParseInt32OrZero(array2[k, 8]);
			}
			FormLogin.accountsLoadCompleted = true;
			FormLogin.accountsDirty = true;
		}
		else
		{
			FormLogin.accountsLoadCompleted = true;
			FormLogin.accountsDirty = true;
		}
	}

	public static void AttachRunningGameProcesses()
	{
		if (FormLogin.gstruct0_0 == null || FormLogin.gstruct0_0.Length == 0)
		{
			return;
		}
		int[] array = WindowsInteropHelper.FindMatchingWindowProcessIds(GameConfigurationManager.gameWindowClassName);
		if (array == null)
		{
			return;
		}
		for (int i = 0; i < array.Length; i++)
		{
			try
			{
				int num = array[i];
				GStruct8[] array2 = WindowsInteropHelper.FindProcessWindowsAndControls(num, "WIN_CLASS:Sword3 Class");
				if (array2 == null || array2.Length == 0)
				{
					continue;
				}
				uint uint_ = array2[0].windowHandle;
				uint num2 = WindowsInteropHelper.GetMainModuleBaseAddressByProcessId(num);
				if (num2 == 0)
				{
					continue;
				}
				int num3 = WindowsInteropHelper.OpenProcess(2035711, bool_0: false, num);
				if (num3 <= 0)
				{
					continue;
				}
				uint num4 = WindowsInteropHelper.ReadProcessUInt32(LoginProcessMemoryLayout.uint_0, num3);
				uint num5 = WindowsInteropHelper.ReadProcessUInt32(num4 + LoginProcessMemoryLayout.uint_2, num3) * LoginProcessMemoryLayout.uint_4;
				uint num6 = WindowsInteropHelper.ReadProcessUInt32(LoginProcessMemoryLayout.uint_3, num3);
				uint num7 = num6 + num5;
				string text = WindowsInteropHelper.ReadNullTerminatedUtf7ProcessString(num7 + LoginProcessMemoryLayout.uint_5, num3);
				if (text != null && text.Length >= 6)
				{
					Process processById = Process.GetProcessById(num);
					int num8 = -1;
					if (FormLogin.gstruct0_0 != null)
					{
						for (int j = 0; j < FormLogin.gstruct0_0.Length; j++)
						{
							if (text == FormLogin.gstruct0_0[j].characterName)
							{
								num8 = j;
								break;
							}
						}
					}
					if (0 <= num8)
					{
						FormLogin.gstruct0_0[num8].processId = num;
						FormLogin.gstruct0_0[num8].processHandle = num3;
						FormLogin.gstruct0_0[num8].process = processById;
						FormLogin.gstruct0_0[num8].moduleBaseAddress = num2;
						FormLogin.gstruct0_0[num8].windowHandle = uint_;
						LoginProcessRemoteBridge.InitializeRemoteRoutines(ref FormLogin.gstruct0_0[num8]);
					}
				}
				else
				{
					WindowsInteropHelper.CloseHandleSafely(num3);
				}
			}
			catch
			{
			}
		}
	}
}
