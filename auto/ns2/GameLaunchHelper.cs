using System;
using System.Diagnostics;
using System.Threading;
using ns100;
using ns11;
using ns118;
using ns146;
using ns23;
using ns45;
using ns53;
using ns63;

namespace ns2;

internal class GameLaunchHelper
{
	private static int int_0 = 5;

	public static bool bool_0 = false;

	public static string GameExecutablePathOverride = string.Empty;

	public static string LaunchArguments = null;

	private static long long_0 = 0L;

	private static string string_2 = null;

	private static Process process_0 = null;

	public static void ReportStatus(string string_3)
	{
		if (FormLogin.bool_0)
		{
			CommonUtility.smethod_29(ref FormLogin.string_0, string_3);
		}
		else
		{
			CommonUtility.smethod_29(ref CommonUtility.string_17, string_3);
		}
	}

	public static void RequestLaunch()
	{
		if (CommonUtility.GetElapsedMilliseconds(long_0) >= 600L)
		{
			long_0 = CommonUtility.GetCurrentTicks();
			new Thread(smethod_2).Start();
		}
	}

	private static void smethod_2()
	{
		if (Form1.bool_15 || (!Form1.bool_14 && !GClass1.bool_1 && GClass1.string_4 != null && !(GClass1.string_4 == string.Empty) && Form1.int_7 <= Form1.int_6))
		{
			LaunchGameProcess();
		}
	}

	public static Process LaunchGameProcess()
	{
		try
		{
			bool flag;
			if (!(flag = FormLogin.int_11 > 0 && FormLogin.string_3 != null && FormLogin.string_3 != string.Empty))
			{
				if (string_2 == null || string_2 == string.Empty)
				{
					string_2 = GameConfigurationManager.smethod_0();
					if (string_2 == null || string_2 == string.Empty)
					{
						string_2 = WindowsRegistryHelper.ReadApplicationRegistryString("PathGame", 0);
					}
				}
				if (string_2 != null && string_2 != string.Empty)
				{
					string[] array = CommonUtility.SplitPrefixAndLastSegment(string_2);
					if (array[array.Length - 1].ToUpper().IndexOf("VGGAME") == 0 && CommonUtility.FileExists(array[0] + "\\Game.exe"))
					{
						flag = true;
						FormLogin.string_3 = array[0] + "\\Game.exe";
					}
				}
			}
			if (!flag)
			{
				return smethod_6();
			}
			return smethod_4();
		}
		catch
		{
		}
		return null;
	}

	private static Process smethod_4()
	{
		if (CommonUtility.FileExists(FormLogin.string_3))
		{
			int[] array = WindowsInteropHelper.FindMatchingWindowProcessIds(GameConfigurationManager.string_21);
			int[] array2 = null;
			string[] array3 = CommonUtility.SplitPrefixAndLastSegment(FormLogin.string_3);
			int num = 0;
			while (num < 100 && process_0 != null)
			{
				num++;
				Thread.Sleep(10);
			}
			process_0 = WindowsInteropHelper.StartProcess(FormLogin.string_3, array3[0], LaunchArguments, 0);
			if (process_0 == null)
			{
				ReportStatus("Không thể mở game, hãy kiểm tra lại file khác trong nút Login -> Thiết lập khác");
				return null;
			}
			int id = process_0.Id;
			bool flag = false;
			num = 0;
			while (!CommonUtility.bool_0)
			{
				Thread.Sleep(10);
				if (!flag && num % 20 == 0)
				{
					GStruct8[] array4 = WindowsInteropHelper.FindProcessWindowsAndControls(id, "WIN_CLASS:#32770|CTR_CLASS:Button");
					if (array4 != null && array4.Length != 0 && array4[0].gstruct7_0 != null)
					{
						for (int i = 0; i < array4[0].gstruct7_0.Length; i++)
						{
							if (array4[0].gstruct7_0[i].int_0 == 1)
							{
								WindowsInteropHelper.PostKeyPressWithScanCode(array4[0].gstruct7_0[i].uint_0, 13u);
								flag = true;
								break;
							}
						}
					}
				}
				num++;
				if (num % 30 == 0 && WindowsInteropHelper.IsProcessExitedOrUnavailable(process_0))
				{
					break;
				}
				if (num > 450)
				{
					ReportStatus("Không thể mở game, hãy kiểm tra lại file khác trong nút Login -> Thiết lập khác");
					return null;
				}
			}
			long long_ = CommonUtility.GetCurrentTicks();
			while (!CommonUtility.bool_0)
			{
				Thread.Sleep(100);
				if (!LoginAutomationCoordinator.StopRequested)
				{
					long num2 = CommonUtility.GetElapsedMilliseconds(long_);
					if (num2 > FormLogin.int_6)
					{
						break;
					}
					LoginAutomationCoordinator.RemainingWaitMilliseconds = (int)(FormLogin.int_6 - num2);
					continue;
				}
				return null;
			}
			array2 = WindowsInteropHelper.FindMatchingWindowProcessIds(GameConfigurationManager.string_21);
			Process result = null;
			if (array2 != null && array2.Length != 0)
			{
				if (array != null && array.Length != 0)
				{
					for (int j = 0; j < array2.Length; j++)
					{
						int num3 = array2[j];
						for (int k = 0; k < array.Length; k++)
						{
							if (num3 == array[k])
							{
								num3 = 0;
								break;
							}
						}
						if (num3 > 0)
						{
							result = Process.GetProcessById(num3);
							break;
						}
					}
				}
				else
				{
					result = Process.GetProcessById(array2[0]);
				}
			}
			new Thread(smethod_5).Start();
			return result;
		}
		ReportStatus("Hãy sửa lại file khác trong nút Login -> Thiết lập khác.");
		return null;
	}

	private static void smethod_5()
	{
		Process process = process_0;
		process_0 = null;
		int num = 0;
		while (true)
		{
			if (num < 20)
			{
				if (!WindowsInteropHelper.IsProcessExitedOrUnavailable(process))
				{
					Thread.Sleep(150);
					num++;
					continue;
				}
				break;
			}
			WindowsInteropHelper.TryKillProcess(process);
			break;
		}
	}

	private static Process smethod_6()
	{
		int num = 0;
		string text = GameExecutablePathOverride;
		if (text == null || !(text != string.Empty) || !CommonUtility.FileExists(text))
		{
			text = null;
			int[] array = WindowsInteropHelper.FindMatchingWindowProcessIds(GameConfigurationManager.string_21);
			if (array != null && array.Length != 0)
			{
				num = array.Length;
				for (int i = 0; i < num; i++)
				{
					try
					{
						Process processById = Process.GetProcessById(array[i]);
						text = processById.MainModule.FileName;
						string text2 = WindowsRegistryHelper.ReadApplicationRegistryString("PathGame", 0);
						if (text != null && text != string.Empty)
						{
							if (text2 != text)
							{
								WindowsRegistryHelper.SetRegistryValue(WindowsRegistryHelper.GetApplicationRegistryPath(), "PathGame", text, "", 0);
								WindowsInteropHelper.SetRunAsAdministratorCompatibility(text, bool_0: false);
							}
							break;
						}
					}
					catch
					{
					}
				}
			}
			if (text == null || text == string.Empty)
			{
				num = 0;
				text = WindowsRegistryHelper.ReadApplicationRegistryString("PathGame", 0);
				if (text == null || text == string.Empty || !CommonUtility.FileExists(text))
				{
					ReportStatus("Không thể mở game, vào tab Cài game xem lại thư mục game.");
					return null;
				}
			}
		}
		string[] array2 = CommonUtility.SplitPrefixAndLastSegment(text);
		string text3 = "KernelBase.dll";
		if (Form1.bool_20)
		{
			text3 = "Kernel32.dll";
		}
		string text4 = "User32.dll";
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		Process process = null;
		Process process2 = null;
		while (true)
		{
			GStruct4 gstruct4_ = WindowsInteropHelper.LaunchProcess(text, array2[0], bool_0: false, LaunchArguments);
			if (CommonUtility.bool_0 || gstruct4_.uint_0 == 0)
			{
				break;
			}
			int uint_ = (int)gstruct4_.uint_0;
			try
			{
				process2 = Process.GetProcessById(uint_);
			}
			catch
			{
			}
			if ((bool_0 || num <= 2) && num <= int_0)
			{
				uint num5 = 0u;
				uint num6 = 0u;
				int num7 = 0;
				while (!CommonUtility.bool_0)
				{
					if (num7 <= 500)
					{
						if (num6 == 0)
						{
							num6 = WindowsInteropHelper.FindLoadedModuleBaseAddress(uint_, text3);
						}
						if (FormLogin.int_10 <= 0 && num6 != 0)
						{
							break;
						}
						if (num5 == 0)
						{
							num5 = WindowsInteropHelper.FindLoadedModuleBaseAddress(uint_, text4);
						}
						if (num6 != 0 && num5 != 0)
						{
							break;
						}
						WindowsInteropHelper.ResumeCreatedProcessPrimaryThread(gstruct4_);
						Thread.Sleep(1);
						WindowsInteropHelper.SuspendCreatedProcessPrimaryThread(gstruct4_);
						num7++;
						continue;
					}
					goto IL_04b7;
				}
				uint num8 = 0u;
				uint num9 = 0u;
				num7 = 0;
				while (!CommonUtility.bool_0)
				{
					if (num7 <= 500)
					{
						if (num9 == 0)
						{
							num9 = WindowsInteropHelper.GetProcAddress(num6, "CreateMutexA");
						}
						if (FormLogin.int_10 <= 0 && num9 != 0)
						{
							break;
						}
						if (num8 == 0)
						{
							num8 = WindowsInteropHelper.GetProcAddress(num5, "EnumWindows");
						}
						if (num9 != 0 && num8 != 0)
						{
							break;
						}
						WindowsInteropHelper.ResumeCreatedProcessPrimaryThread(gstruct4_);
						Thread.Sleep(1);
						WindowsInteropHelper.SuspendCreatedProcessPrimaryThread(gstruct4_);
						num7++;
						continue;
					}
					goto IL_04ab;
				}
				num2 = (int)gstruct4_.intptr_0;
				num7 = 0;
				int int_ = 0;
				byte[] array3 = new byte[1];
				while (!CommonUtility.bool_0)
				{
					if (num7 <= 500)
					{
						WindowsInteropHelper.ReadProcessMemory(num2, num9 + 5, array3, 1, ref int_);
						if (array3[0] != 0 && array3[0] != 204)
						{
							break;
						}
						WindowsInteropHelper.ResumeCreatedProcessPrimaryThread(gstruct4_);
						Thread.Sleep(1);
						WindowsInteropHelper.SuspendCreatedProcessPrimaryThread(gstruct4_);
						num7++;
						continue;
					}
					ReportStatus("Lỗi (3): Quá thời gian.");
					break;
				}
				uint num10 = WindowsInteropHelper.AllocateRemoteMemory(num2, 598u);
				uint num11 = num9 - (num10 + 42) + 5;
				uint value = num10 - num9 - 5;
				string string_ = "3E 83 7C 24 0C 00 74 18 50 3E 8B 44 24 10 81 38 4D 75 74 65 75 09 3E C7 44 24 10 00 00 00 00 58 8B FF 55 8B ECE9" + CommonUtility.smethod_46(num11, 8, bool_1: false, bool_2: true);
				array3 = CommonUtility.ParseHexBytePattern(string_, bool_1: false);
				bool flag = WindowsInteropHelper.WriteProcessMemory(num2, num10, array3, array3.Length, ref int_);
				bool flag2 = WindowsInteropHelper.WriteProcessMemory(num2, num9, new byte[1] { 233 }, 1, ref int_);
				array3 = BitConverter.GetBytes(value);
				bool flag3 = WindowsInteropHelper.WriteProcessMemory(num2, num9 + 1, array3, array3.Length, ref int_);
				num7 = 0;
				while (!CommonUtility.bool_0 && FormLogin.int_10 > 0)
				{
					if (num7 <= 500)
					{
						WindowsInteropHelper.ReadProcessMemory(num2, num8 + 2, array3, 1, ref int_);
						if (array3[0] == 85)
						{
							break;
						}
						WindowsInteropHelper.ResumeCreatedProcessPrimaryThread(gstruct4_);
						Thread.Sleep(1);
						WindowsInteropHelper.SuspendCreatedProcessPrimaryThread(gstruct4_);
						num7++;
						continue;
					}
					ReportStatus("Lỗi (4): Quá thời gian.");
					break;
				}
				bool flag4 = true;
				if (FormLogin.int_10 > 0)
				{
					array3 = new byte[3] { 194, 8, 0 };
					flag4 = WindowsInteropHelper.WriteProcessMemory(num2, num8, array3, array3.Length, ref int_);
				}
				WindowsInteropHelper.ResumeCreatedProcessPrimaryThread(gstruct4_);
				WindowsInteropHelper.CloseHandleSafely(num2);
				if (num4 == 0 && (!flag || !flag2 || !flag3 || !flag4))
				{
					if (num3 <= 0)
					{
						process = process2;
						num3 = 1;
						continue;
					}
					ReportStatus("Không thể mở game, chú ý mở auto bằng run as administrators.");
				}
			}
			else
			{
				WindowsInteropHelper.ResumeCreatedProcessPrimaryThread(gstruct4_);
			}
			goto IL_04ca;
			IL_04b7:
			ReportStatus("Lỗi (1): Quá thời gian.");
			goto IL_04ca;
			IL_04ab:
			ReportStatus("Lỗi (2): Quá thời gian.");
			goto IL_04ca;
			IL_04ca:
			if (process != null)
			{
				WindowsInteropHelper.TryKillProcess(process);
			}
			long long_ = CommonUtility.GetCurrentTicks();
			while (!CommonUtility.bool_0)
			{
				Thread.Sleep(100);
				if (!LoginAutomationCoordinator.StopRequested)
				{
					long num12 = CommonUtility.GetElapsedMilliseconds(long_);
					if (num12 > FormLogin.int_6)
					{
						break;
					}
					LoginAutomationCoordinator.RemainingWaitMilliseconds = (int)(FormLogin.int_6 - num12);
					continue;
				}
				return null;
			}
			ReportStatus("Đã mở " + (num + 1) + " cửa sổ game.");
			return process2;
		}
		ReportStatus("Không thể mở game, qua tab Cài đặt xem lại thư mục game có đúng không.");
		return null;
	}

	public static void ConfigureGameUiSettings(string string_3)
	{
		if (string_3 == null || string_3 == string.Empty)
		{
			return;
		}
		string string_4 = string_3 + "\\UserData\\uicommon.ini";
		string text = CommonUtility.ReadAllTextWithEncodingOption(string_4, 0, 0, 1);
		if (!(text == string.Empty))
		{
			string[] array = text.Split('\r', '\n');
			text = string.Empty;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == null || array[i] == string.Empty)
				{
					continue;
				}
				string text2 = array[i];
				string text3 = text2.ToUpper();
				if (text3.IndexOf("WEATHER") == 0)
				{
					text2 = "Weather=0";
				}
				else if (text3.IndexOf("MUSIC") == 0)
				{
					text2 = "MusicValue=0";
				}
				else if (text3.IndexOf("SOUND") == 0)
				{
					int num = text3.IndexOf("=");
					if (num > 0)
					{
						num = CommonUtility.ParseInt32OrZero(text3.Substring(num + 1));
						if (num > 50)
						{
							text2 = "SoundValue=50";
						}
					}
				}
				else if (text3.IndexOf("SHORTCUT") == 0)
				{
					text2 = "ShortcutSet=1";
				}
				text = text + text2 + "\r\n";
			}
			CommonUtility.WriteAllTextWithEncodingOption(string_4, text, 1);
		}
		else
		{
			CommonUtility.EnsureDirectoryExists(string_3 + "\\UserData");
			CommonUtility.WriteAllTextWithEncodingOption(string_4, CommonUtility.smethod_72("JYu7CgIxEAD7/ZoTvDKNWCoqAa8Qi7AuZuHcHPsQ7u+N2s3AzO20ODexO+xXKS/GAz+rpwEmKl5JO51JbSF0flO3jEoklygz+5o2sNPvIGSWxgGOYYzXMscvbSGPv2xHyLWpY3gm7xt8AA=="), 1);
		}
	}
}
