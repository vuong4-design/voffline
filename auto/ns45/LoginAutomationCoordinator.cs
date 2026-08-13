using System;
using System.Diagnostics;
using System.Threading;
using ns1;
using ns100;
using ns11;
using ns118;
using ns146;
using ns149;
using ns2;
using ns21;
using ns23;
using ns49;
using ns53;
using ns63;
using ns77;
using ns89;

namespace ns45;

internal class LoginAutomationCoordinator
{
	public static int[] PendingAccountIndexes = null;

	public static int[] PendingUiRefreshIndexes = null;

	public static bool StopRequested = false;

	public static int RemainingWaitMilliseconds = 0;

	public static bool QueueUpdateInProgress = false;

	public static bool bool_2 = false;

	private static int int_3 = 0;

	public const int int_4 = 2;

	private static void KillWerFaultProcesses()
	{
		Process[] processesByName = Process.GetProcessesByName("WerFault");
		if (processesByName != null && processesByName.Length != 0)
		{
			for (int i = 0; i < processesByName.Length; i++)
			{
				WindowsInteropHelper.TryKillProcess(processesByName[i]);
			}
		}
	}

	private static void ImportQueuedCharacterIdsFromRegistry()
	{
		string text = WindowsRegistryHelper.ReadApplicationRegistryString(GameConfigurationManager.string_4, 0);
		if (text == null || text == string.Empty)
		{
			return;
		}
		WindowsRegistryHelper.SetRegistryValue(WindowsRegistryHelper.GetApplicationRegistryPath(), GameConfigurationManager.string_4, "", "", 0);
		string[] array = text.Split('|');
		bool flag = false;
		for (int i = 0; i < array.Length; i++)
		{
			int num = CommonUtility.ParseInt32OrZero(array[i]);
			if (num > 0)
			{
				flag = true;
				CommonUtility.AppendIntIfMissing(ref ThemXoaDanhsach.int_0, num);
			}
		}
		if (flag)
		{
			Form1.string_26 = null;
			Form1.int_138 = 0;
			Form1.bool_26 = true;
		}
	}

	public static void Run()
	{
		while (true)
		{
			if (!GameConfigurationManager.bool_1)
			{
				if (!CommonUtility.bool_0)
				{
					Thread.Sleep(100);
					continue;
				}
				break;
			}
			LoginAccountStore.LoadAccounts();
			LoginAccountStore.AttachRunningGameProcesses();
			while (true)
			{
				try
				{
					smethod_3();
					break;
				}
				catch
				{
				}
			}
			break;
		}
	}

	private static void smethod_3()
	{
		int num = -1;
		int num2 = 0;
		int num3 = 0;
		Process process = null;
		uint num4 = 0u;
		uint num5 = 0u;
		int num6 = 0;
		int num7 = 0;
		string text = string.Empty;
		int num8 = 200;
		long long_ = 0L;
		long long_2 = 0L;
		while (true)
		{
			IL_0038:
			Thread.Sleep(450);
			if (CommonUtility.bool_0)
			{
				break;
			}
			if (!Form1.bool_15 && CommonUtility.GetElapsedMilliseconds(long_) > 60000L)
			{
				KillWerFaultProcesses();
				long_ = CommonUtility.GetCurrentTicks();
			}
			if (CommonUtility.GetElapsedMilliseconds(long_2) > 6000L)
			{
				ImportQueuedCharacterIdsFromRegistry();
				long_2 = CommonUtility.GetCurrentTicks();
			}
			RemainingWaitMilliseconds = -1;
			if (StopRequested)
			{
				if (PendingAccountIndexes != null)
				{
					GameLaunchHelper.ReportStatus("Login dừng lại bởi người dùng.");
					PendingAccountIndexes = null;
				}
				process = null;
				StopRequested = false;
				RemainingWaitMilliseconds = 0;
				num = -1;
			}
			if (0 <= num)
			{
				goto IL_03d5;
			}
			if (QueueUpdateInProgress || PendingAccountIndexes == null || PendingAccountIndexes.Length == 0)
			{
				continue;
			}
			if (!Form1.bool_15 && (Form1.bool_14 || GClass1.bool_1 || GClass1.string_4 == null || GClass1.string_4 == string.Empty || Form1.int_7 > Form1.int_6))
			{
				PendingAccountIndexes = null;
				continue;
			}
			num = PendingAccountIndexes[0];
			int num13;
			if (num >= 0 && FormLogin.gstruct0_0.Length > num)
			{
				GStruct0 gstruct0_ = FormLogin.gstruct0_0[num];
				if (gstruct0_.int_1 > 0 && !WindowsInteropHelper.IsProcessExitedOrUnavailable(gstruct0_.process_0))
				{
					uint num9 = WindowsInteropHelper.ReadProcessUInt32(LoginProcessMemoryLayout.uint_0, gstruct0_.int_2);
					uint num10 = WindowsInteropHelper.ReadProcessUInt32(num9 + LoginProcessMemoryLayout.uint_2, gstruct0_.int_2) * LoginProcessMemoryLayout.uint_4;
					uint num11 = WindowsInteropHelper.ReadProcessUInt32(LoginProcessMemoryLayout.uint_3, gstruct0_.int_2);
					uint num12 = num11 + num10;
					num3 = LoginProcessRemoteBridge.smethod_33(gstruct0_);
					if (num3 > 1)
					{
						string text2 = WindowsInteropHelper.ReadNullTerminatedUtf7ProcessString(num12 + LoginProcessMemoryLayout.uint_5, gstruct0_.int_2);
						if (text2 != null && text2.Length > 5)
						{
							goto IL_12e3;
						}
					}
					WindowsInteropHelper.KillProcessByIdWithRetry(gstruct0_.int_1);
				}
				if (bool_2 && ApplicationRuntimeCoordinator.int_4 > 0)
				{
					int[] array = WindowsInteropHelper.FindMatchingWindowProcessIds(GameConfigurationManager.string_21);
					if (array != null && ApplicationRuntimeCoordinator.int_4 <= array.Length)
					{
						goto IL_12e3;
					}
				}
				string text3 = CommonUtility.DecodeBase64Utf8(FormLogin.gstruct0_0[num].string_1);
				if (text3 != null && !(text3 == string.Empty) && text3[0] <= text3.Length - 1 && FormLogin.gstruct0_0[num].string_0 != null && !(FormLogin.gstruct0_0[num].string_0 == string.Empty))
				{
					text = text3.Substring(1, text3[0]);
					num2 = 0;
					num6 = -1;
					num7 = -1;
					string string_ = FormLogin.gstruct0_0[num].string_2;
					string string_2 = FormLogin.gstruct0_0[num].string_3;
					string text4 = GameTextEncodingHelper.ConvertGameTextToDisplayText(FormLogin.gstruct0_0[num].string_4, 1);
					if (text4 == string.Empty)
					{
						text4 = FormLogin.gstruct0_0[num].string_0;
					}
					GameLaunchHelper.ReportStatus("Đang đăng nhập <" + text4 + "> đợi chút xíu...");
					for (int i = 0; i < FormLogin.string_6.Length; i++)
					{
						string[] array2 = FormLogin.string_6[i].Split('|');
						if (array2[0] != string_)
						{
							continue;
						}
						num7 = i;
						num13 = 1;
						while (num13 < array2.Length)
						{
							if (!(array2[num13] == string_2))
							{
								num13++;
								continue;
							}
							goto IL_03cf;
						}
					}
					GameLaunchHelper.ReportStatus("Lỗi dữ liệu không đúng Phân đà và Server, không thể login.");
				}
			}
			goto IL_12e3;
			IL_123f:
			int num14;
			while (!CommonUtility.bool_0 && int_3 > 0 && num14 < 15)
			{
				num14++;
				Thread.Sleep(100);
			}
			int id;
			int_3 = id;
			new Thread(FinalizePendingCharacterIdQueue).Start();
			goto IL_12e3;
			IL_03cf:
			num6 = num13 - 1;
			goto IL_03d5;
			IL_1287:
			RemainingWaitMilliseconds = 0;
			num2++;
			if (num2 < 3)
			{
				continue;
			}
			GameLaunchHelper.ReportStatus("Không thể login !");
			goto IL_12a4;
			IL_088d:
			int num15 = 0;
			GStruct0 gstruct0_2;
			while (true)
			{
				if (num15 % 3 == 0)
				{
					LoginProcessRemoteBridge.WritePassword(gstruct0_2, text);
				}
				num15++;
				Thread.Sleep(100);
				if (num15 > 10 || WindowsInteropHelper.IsProcessExitedOrUnavailable(gstruct0_2.process_0))
				{
					break;
				}
				string text5 = LoginProcessRemoteBridge.ReadPassword(gstruct0_2, text.Length + 1);
				if (!(text5 == text))
				{
					continue;
				}
				goto IL_08f2;
			}
			goto IL_1287;
			IL_03d5:
			FormLogin.gstruct0_0[num].int_1 = 0;
			FormLogin.gstruct0_0[num].int_2 = 0;
			FormLogin.gstruct0_0[num].uint_0 = 0u;
			FormLogin.gstruct0_0[num].uint_1 = 0u;
			FormLogin.gstruct0_0[num].uint_2 = 0u;
			FormLogin.gstruct0_0[num].uint_3 = 0u;
			FormLogin.gstruct0_0[num].int_0 = 0;
			num4 = 0u;
			num5 = 0u;
			Process process2 = GameLaunchHelper.LaunchGameProcess();
			if (!WindowsInteropHelper.IsProcessExitedOrUnavailable(process))
			{
				WindowsInteropHelper.TryKillProcess(process);
				Thread.Sleep(100);
			}
			process = process2;
			if (process == null)
			{
				Thread.Sleep(100);
			}
			else
			{
				int num16 = 0;
				int num17 = 0;
				while (true)
				{
					bool flag = false;
					GStruct8[] array3;
					if (num16 == 0)
					{
						array3 = WindowsInteropHelper.FindProcessWindowsAndControls(process.Id, "WIN_CLASS:#32770|CTR_CLASS:Button");
						if (array3 != null && array3.Length != 0 && array3[0].gstruct7_0 != null)
						{
							for (int j = 0; j < array3[0].gstruct7_0.Length; j++)
							{
								if (array3[0].gstruct7_0[j].int_0 == 1)
								{
									WindowsInteropHelper.PostKeyPressWithScanCode(array3[0].gstruct7_0[j].uint_0, 32u);
									Thread.Sleep(300);
									flag = true;
									break;
								}
							}
						}
						num16 = 1;
						if (flag)
						{
							KillWerFaultProcesses();
							continue;
						}
					}
					if (num17 != 0)
					{
						break;
					}
					array3 = WindowsInteropHelper.FindProcessWindowsAndControls(process.Id, "CTR_INSTANCE:1");
					if (array3 != null && array3.Length != 0)
					{
						for (num13 = 0; num13 < array3.Length; num13++)
						{
							if (array3[num13].gstruct7_0 == null)
							{
								continue;
							}
							for (int k = 0; k < array3[num13].gstruct7_0.Length; k++)
							{
								if (array3[num13].gstruct7_0[k].int_0 == 1)
								{
									WindowsInteropHelper.PostKeyPressWithScanCode(array3[num13].gstruct7_0[k].uint_0, 32u);
									Thread.Sleep(300);
									flag = true;
								}
							}
						}
					}
					num17 = 1;
					if (!flag)
					{
						break;
					}
					KillWerFaultProcesses();
				}
				num14 = 0;
				id = process.Id;
				while (num4 == 0)
				{
					try
					{
						num4 = (uint)(int)process.MainModule.BaseAddress;
					}
					catch
					{
					}
					num14++;
					if (num14 <= 10)
					{
						Thread.Sleep(300);
						continue;
					}
					goto IL_1287;
				}
				num5 = 0u;
				GStruct8[] array4 = WindowsInteropHelper.FindProcessWindowsAndControls(id, "WIN_CLASS:" + GameConfigurationManager.string_21);
				if (array4 != null && array4.Length != 0)
				{
					num5 = array4[0].uint_0;
				}
				FormLogin.gstruct0_0[num].int_1 = id;
				FormLogin.gstruct0_0[num].int_2 = WindowsInteropHelper.OpenProcess(2035711, bool_0: false, id);
				FormLogin.gstruct0_0[num].process_0 = process;
				FormLogin.gstruct0_0[num].uint_0 = num5;
				FormLogin.gstruct0_0[num].uint_1 = num4;
				if (LoginProcessRemoteBridge.InitializeRemoteRoutines(ref FormLogin.gstruct0_0[num]) >= 0)
				{
					gstruct0_2 = FormLogin.gstruct0_0[num];
					if (LoginProcessRemoteBridge.smethod_15(gstruct0_2))
					{
						Thread.Sleep(100 + num8);
						if (LoginProcessRemoteBridge.smethod_16(gstruct0_2))
						{
							Thread.Sleep(100 + num8);
							if (LoginProcessRemoteBridge.smethod_17(gstruct0_2, num7))
							{
								Thread.Sleep(200 + num8);
								if (LoginProcessRemoteBridge.smethod_18(gstruct0_2, num6))
								{
									Thread.Sleep(200 + num8);
									if (LoginProcessRemoteBridge.smethod_19(gstruct0_2))
									{
										if (FormLogin.int_8 > 1000)
										{
											GameLaunchHelper.ReportStatus("Chờ " + FormLogin.int_8 / 1000 + " giây trước khi nhập tài khoản...");
										}
										long long_3 = CommonUtility.GetCurrentTicks();
										while (!CommonUtility.bool_0)
										{
											Thread.Sleep(100);
											if (StopRequested)
											{
												goto IL_0038;
											}
											long num18 = CommonUtility.GetElapsedMilliseconds(long_3);
											if (num18 > FormLogin.int_8)
											{
												break;
											}
											RemainingWaitMilliseconds = (int)(FormLogin.int_8 - num18);
										}
										num15 = 0;
										while (true)
										{
											if (num15 % 3 == 0)
											{
												LoginProcessRemoteBridge.WriteAccountName(gstruct0_2, gstruct0_2.string_0);
											}
											num15++;
											Thread.Sleep(100);
											if (num15 > 80 || WindowsInteropHelper.IsProcessExitedOrUnavailable(gstruct0_2.process_0))
											{
												break;
											}
											string text6 = LoginProcessRemoteBridge.ReadAccountName(gstruct0_2, gstruct0_2.string_0.Length + 1);
											if (!(text6 == gstruct0_2.string_0))
											{
												continue;
											}
											goto IL_088d;
										}
									}
								}
							}
						}
					}
				}
				else
				{
					FormLogin.gstruct0_0[num].int_1 = 0;
					FormLogin.gstruct0_0[num].process_0 = null;
				}
			}
			goto IL_1287;
			IL_12e3:
			CommonUtility.RemoveIntFromArray(ref PendingAccountIndexes, num);
			if (FormLogin.bool_0)
			{
				CommonUtility.AppendIntIfMissing(ref PendingUiRefreshIndexes, num);
			}
			process = null;
			num = -1;
			continue;
			IL_08f2:
			Thread.Sleep(100);
			string text11;
			if (LoginProcessRemoteBridge.smethod_24(gstruct0_2))
			{
				uint num19 = 2699940u;
				uint num20 = 4880u;
				uint num21 = 472u;
				int num22 = 6 + Convert.ToByte(FormLogin.int_4 <= 0) * 14;
				int l = 0;
				string text7 = string.Empty;
				for (; l < num22; l++)
				{
					if (!(text7 == string.Empty))
					{
						break;
					}
					uint num23 = WindowsInteropHelper.ReadProcessUInt32(gstruct0_2.uint_1 + num19, gstruct0_2.int_2);
					text7 = WindowsInteropHelper.ReadNullTerminatedUtf7ProcessString(num23 + num20 + num21, gstruct0_2.int_2);
					Thread.Sleep(100);
				}
				Thread.Sleep(600 + num8);
				if (LoginProcessRemoteBridge.smethod_25(gstruct0_2, gstruct0_2.int_4 - 1))
				{
					Thread.Sleep(200 + num8);
					bool flag2 = false;
					if (FormLogin.bool_1 != null && num < FormLogin.bool_1.Length)
					{
						flag2 = FormLogin.bool_1[num];
					}
					if (flag2)
					{
						string string_3 = "TẠO NHÂN VẬT";
						string string_4 = "[" + gstruct0_2.string_0 + "] Đã vào giao diện tạo nhân vật...";
						CommonUtility.AppendStringIfMissing(ref CommonUtility.string_17, string_4);
						if (FormLogin.bool_0)
						{
							CommonUtility.AppendStringIfMissing(ref FormLogin.string_0, string_4);
						}
						FormLogin.gstruct0_0[num].string_4 = string_3;
						FormLogin.gstruct0_0[num].int_0 = 1;
						Thread.Sleep(500);
						uint uint_ = gstruct0_2.uint_0;
						WindowsInteropHelper.POINT point_ = default(WindowsInteropHelper.POINT);
						WindowsInteropHelper.GetCursorPos(out point_);
						GameLaunchHelper.ReportStatus("Bước 1: Click vào nút Tạo nhân vật tại (200, 560)...");
						WindowsInteropHelper.POINT point_2 = new WindowsInteropHelper.POINT
						{
							x = 200,
							y = 560
						};
						WindowsInteropHelper.ClientToScreen(uint_, ref point_2);
						WindowsInteropHelper.SetCursorPos(point_2.x, point_2.y);
						Thread.Sleep(100);
						WindowsInteropHelper.mouse_event(2, 0, 0, 0, 0);
						Thread.Sleep(50);
						WindowsInteropHelper.mouse_event(4, 0, 0, 0, 0);
						Thread.Sleep(800);
						GameLaunchHelper.ReportStatus("Bước 2: Gọi DLL C++ để gửi phím Enter...");
						try
						{
							int num24 = WindowsInteropHelper.SendEnterKey(uint_);
							if (num24 == 1)
							{
								GameLaunchHelper.ReportStatus("Đã gửi phím Enter thành công qua DLL.");
							}
							else
							{
								GameLaunchHelper.ReportStatus("Lỗi gửi phím Enter qua DLL, code: " + num24);
							}
						}
						catch (Exception ex)
						{
							GameLaunchHelper.ReportStatus("Lỗi gọi DLL: " + ex.Message);
						}
						Thread.Sleep(800);
						string text8 = "Kim";
						if (FormLogin.string_1 != null && num < FormLogin.string_1.Length)
						{
							text8 = FormLogin.string_1[num];
						}
						if (text8.Trim() == "Kim")
						{
							GameLaunchHelper.ReportStatus("Bước 3: Hệ Kim được chọn - Giữ nguyên mặc định, không click.");
						}
						else
						{
							FormLogin.GetFiveElementSelectionCoordinates(text8, out var int_, out var int_2);
							GameLaunchHelper.ReportStatus("Bước 3: Click chọn hệ " + text8 + " tại tọa độ (" + int_ + ", " + int_2 + ")...");
							WindowsInteropHelper.POINT point_3 = default(WindowsInteropHelper.POINT);
							WindowsInteropHelper.GetCursorPos(out point_3);
							WindowsInteropHelper.POINT point_4 = new WindowsInteropHelper.POINT
							{
								x = int_,
								y = int_2
							};
							WindowsInteropHelper.ClientToScreen(uint_, ref point_4);
							GameLaunchHelper.ReportStatus("Tọa độ screen: (" + point_4.x + ", " + point_4.y + ")");
							WindowsInteropHelper.SetCursorPos(point_4.x, point_4.y);
							Thread.Sleep(150);
							GameLaunchHelper.ReportStatus("Đang thực hiện click chuột...");
							WindowsInteropHelper.mouse_event(2, 0, 0, 0, 0);
							Thread.Sleep(100);
							WindowsInteropHelper.mouse_event(4, 0, 0, 0, 0);
							Thread.Sleep(200);
							WindowsInteropHelper.SetCursorPos(point_3.x, point_3.y);
							GameLaunchHelper.ReportStatus("Đã click chọn hệ " + text8 + " thành công.");
						}
						if (!string.IsNullOrEmpty(FormLogin.string_2))
						{
							int num25 = num + 1;
							int num26 = FormLogin.CountUtf8FileLines(FormLogin.string_2);
							GameLaunchHelper.ReportStatus("Bước 4: Đọc tên nhân vật từ file (dòng " + num25 + "/" + num26 + ")...");
							if (num25 <= num26)
							{
								string text9 = FormLogin.ReadTrimmedUtf8FileLine(FormLogin.string_2, num25);
								if (!string.IsNullOrEmpty(text9))
								{
									GameLaunchHelper.ReportStatus("Tên nhân vật (dòng " + num25 + "): " + text9);
									Thread.Sleep(300);
									if (FormLogin.SendTextToWindowByKeyboardEvents(uint_, text9))
									{
										GameLaunchHelper.ReportStatus("Đã gửi tên nhân vật thành công.");
									}
									else
									{
										GameLaunchHelper.ReportStatus("Lỗi gửi tên nhân vật.");
									}
								}
								else
								{
									GameLaunchHelper.ReportStatus("Dòng " + num25 + " trống - bỏ qua nhập tên.");
								}
							}
							else
							{
								GameLaunchHelper.ReportStatus("File chỉ có " + num26 + " dòng, không đủ cho account " + num25 + " - bỏ qua nhập tên.");
							}
						}
						else
						{
							GameLaunchHelper.ReportStatus("Chưa chọn file tên nhân vật - bỏ qua bước nhập tên.");
						}
						GameLaunchHelper.ReportStatus("Đã hoàn thành quy trình tạo nhân vật hệ " + text8);
						Thread.Sleep(500);
						if (!string.IsNullOrEmpty(FormLogin.string_2))
						{
							GameLaunchHelper.ReportStatus("Bước 5: Gửi Enter để xác nhận tên nhân vật...");
							try
							{
								int num27 = WindowsInteropHelper.SendEnterKey(uint_);
								if (num27 == 1)
								{
									GameLaunchHelper.ReportStatus("Đã gửi Enter thành công qua DLL.");
								}
								else
								{
									GameLaunchHelper.ReportStatus("Lỗi gửi Enter qua DLL, code: " + num27);
								}
							}
							catch (Exception ex2)
							{
								GameLaunchHelper.ReportStatus("Lỗi gọi DLL Enter: " + ex2.Message);
							}
							Thread.Sleep(500);
						}
						GameLaunchHelper.ReportStatus("Bước 6: Đóng game bằng ProcessKill...");
						Thread.Sleep(3000);
						try
						{
							if (gstruct0_2.process_0 != null && !gstruct0_2.process_0.HasExited)
							{
								gstruct0_2.process_0.Kill();
								GameLaunchHelper.ReportStatus("Đã đóng game thành công bằng ProcessKill.");
							}
							else
							{
								GameLaunchHelper.ReportStatus("Process đã đóng hoặc không tồn tại.");
							}
						}
						catch (Exception ex3)
						{
							GameLaunchHelper.ReportStatus("Lỗi ProcessKill: " + ex3.Message);
							try
							{
								if (gstruct0_2.int_1 > 0)
								{
									WindowsInteropHelper.KillProcessByIdWithRetry(gstruct0_2.int_1);
									GameLaunchHelper.ReportStatus("Đã fallback kill process bằng TerminateProcess.");
								}
							}
							catch (Exception ex4)
							{
								GameLaunchHelper.ReportStatus("Fallback lỗi: " + ex4.Message);
							}
						}
						GameLaunchHelper.ReportStatus("Đã hoàn thành tạo nhân vật hệ " + text8 + " cho: " + gstruct0_2.string_0);
						if (FormLogin.int_9 > 0)
						{
							WindowsInteropHelper.ShowWindow(num5, WindowsInteropHelper.int_26);
						}
						if (FormLogin.bool_1 != null && num < FormLogin.bool_1.Length)
						{
							FormLogin.bool_1[num] = false;
						}
						num14 = 0;
						goto IL_123f;
					}
					string text10 = string.Empty;
					bool flag3 = false;
					num14 = 0;
					long long_4 = CommonUtility.GetCurrentTicks();
					while (true)
					{
						if (CommonUtility.bool_0)
						{
							goto IL_1176;
						}
						if (StopRequested)
						{
							break;
						}
						if (num14 % 60 != 0 || LoginProcessRemoteBridge.smethod_26(gstruct0_2) || num14 != 0)
						{
							Thread.Sleep(100);
							text11 = LoginProcessRemoteBridge.ReadLoginStatusText(gstruct0_2);
							if (0 > text11.IndexOf("Xin nhËp vµo Tµi") && 0 > text11.IndexOf("KÕt nèi m\u00b8y chñ th") && 0 > text11.IndexOf("HÖ thèng ®ang bËn"))
							{
								if (0 <= text11.IndexOf("Xin h·y n¹p tµi kho¶n") || 0 <= text11.IndexOf("Tµi kho¶n nµy ®· bÞ khãa") || 0 <= text11.IndexOf("Tµi kho¶n nµy hiÖn ®ang") || 0 <= text11.IndexOf("Tµi kho¶n hoÆc MËt khÈu"))
								{
									goto IL_1150;
								}
								num3 = LoginProcessRemoteBridge.smethod_33(gstruct0_2);
								if (num3 > 1)
								{
									uint num28 = WindowsInteropHelper.ReadProcessUInt32(LoginProcessMemoryLayout.uint_0, gstruct0_2.int_2);
									uint num29 = WindowsInteropHelper.ReadProcessUInt32(num28 + LoginProcessMemoryLayout.uint_2, gstruct0_2.int_2) * LoginProcessMemoryLayout.uint_4;
									uint num30 = WindowsInteropHelper.ReadProcessUInt32(LoginProcessMemoryLayout.uint_3, gstruct0_2.int_2);
									uint num31 = num30 + num29;
									text10 = WindowsInteropHelper.ReadNullTerminatedUtf7ProcessString(num31 + LoginProcessMemoryLayout.uint_5, gstruct0_2.int_2);
									if (text10 != null && text10 != string.Empty && text10.Length > 5)
									{
										flag3 = true;
										goto IL_1176;
									}
								}
								long num32 = CommonUtility.GetElapsedMilliseconds(long_4);
								if (num32 <= FormLogin.int_7)
								{
									RemainingWaitMilliseconds = (int)(FormLogin.int_7 - num32);
									num14++;
									continue;
								}
								GameLaunchHelper.ReportStatus("Không thể đăng nhập, đang thử lại...");
							}
							else
							{
								GameLaunchHelper.ReportStatus(GameTextEncodingHelper.ConvertGameTextToDisplayText(text11, 1));
							}
						}
						goto IL_1287;
						IL_1176:
						string string_5 = "[" + GameTextEncodingHelper.ConvertGameTextToDisplayText(text10, 1) + "] Đã đăng nhập...";
						CommonUtility.AppendStringIfMissing(ref CommonUtility.string_17, string_5);
						if (FormLogin.bool_0)
						{
							CommonUtility.AppendStringIfMissing(ref FormLogin.string_0, string_5);
						}
						FormLogin.gstruct0_0[num].string_4 = text10;
						FormLogin.gstruct0_0[num].int_0 = 1;
						if (flag3 && FormLogin.gstruct0_0[num].string_5 != text10)
						{
							FormLogin.gstruct0_0[num].string_5 = text10;
							LoginAccountStore.SaveAccounts();
						}
						if (FormLogin.int_9 > 0)
						{
							WindowsInteropHelper.ShowWindow(num5, WindowsInteropHelper.int_26);
						}
						num14 = 0;
						goto IL_123f;
					}
					continue;
				}
			}
			goto IL_1287;
			IL_1150:
			GameLaunchHelper.ReportStatus(GameTextEncodingHelper.ConvertGameTextToDisplayText(text11, 1));
			goto IL_12a4;
			IL_12a4:
			WindowsInteropHelper.TryKillProcess(process);
			if (FormLogin.gstruct0_0 != null && 0 <= num && num < FormLogin.gstruct0_0.Length)
			{
				FormLogin.gstruct0_0[num].int_1 = 0;
				FormLogin.gstruct0_0[num].process_0 = null;
			}
			goto IL_12e3;
		}
	}

	private static void FinalizePendingCharacterIdQueue()
	{
		int num = 0;
		while (!CommonUtility.bool_0 && int_3 > 0 && num < 20)
		{
			Thread.Sleep(100);
			num++;
		}
		if (int_3 > 0)
		{
			Form1.string_26 = null;
			CommonUtility.AppendIntIfMissing(ref ThemXoaDanhsach.int_0, int_3);
		}
		int_3 = 0;
		Form1.int_138 = 0;
		Form1.bool_26 = true;
	}

	public static string CloseBrokenGameProcesses()
	{
		int num = 0;
		int[] array = WindowsInteropHelper.FindMatchingWindowProcessIds(GameConfigurationManager.string_21);
		if (array != null)
		{
			for (int i = 0; i < array.Length; i++)
			{
				try
				{
					GStruct8[] array2 = WindowsInteropHelper.FindProcessWindowsAndControls(array[i], "WIN_CLASS:Sword3 Class");
					if (array2 == null || array2.Length == 0)
					{
						WindowsInteropHelper.KillProcessByIdWithRetry(array[i]);
						Thread.Sleep(100);
						num++;
					}
				}
				catch
				{
				}
			}
		}
		if (!(GameConfigurationManager.string_19 == string.Empty) && GameConfigurationManager.string_19 != null)
		{
			string processName = GameConfigurationManager.string_19;
			if (CommonUtility.FindSubstringIndex(GameConfigurationManager.string_19.ToUpper(), ".EXE") > 0)
			{
				string[] array3 = CommonUtility.SplitPrefixAndLastSegment(GameConfigurationManager.string_19, '.');
				processName = array3[0];
			}
			Process[] processesByName = Process.GetProcessesByName(processName);
			if (processesByName == null || processesByName.Length == 0)
			{
				processesByName = Process.GetProcessesByName(GameConfigurationManager.string_19 + "\u00a0");
				if (processesByName == null || processesByName.Length == 0)
				{
					goto IL_013d;
				}
			}
			for (int j = 0; j < processesByName.Length; j++)
			{
				try
				{
					GStruct8[] array4 = WindowsInteropHelper.FindProcessWindowsAndControls(processesByName[j].Id, "WIN_CLASS:Sword3 Class");
					if (array4 == null || array4.Length == 0)
					{
						WindowsInteropHelper.KillProcessByIdWithRetry(processesByName[j].Id);
						num++;
					}
				}
				catch
				{
				}
			}
		}
		goto IL_013d;
		IL_013d:
		if (num == 0)
		{
			return "Không tìm thấy game hư chạy ngầm nào.";
		}
		return "Đã thoát " + num + " game hư đang chạy ngầm.";
	}
}
