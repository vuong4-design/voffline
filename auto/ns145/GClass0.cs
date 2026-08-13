using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ns100;
using ns109;
using ns126;
using ns134;
using ns142;
using ns23;
using ns29;
using ns43;
using ns71;
using ns77;

namespace ns145;

public class GClass0
{
	private delegate IntPtr Delegate0(int nCode, IntPtr wParam, IntPtr lParam);

	private const int int_0 = 13;

	public static int int_1 = 0;

	public static int int_2 = 0;

	public static int int_3 = 121;

	public static bool bool_0 = false;

	public static IntPtr intptr_0 = IntPtr.Zero;

	private static int currentVirtualKeyCode = 0;

	private static bool controlKeyPressed = false;

	private static bool spaceKeyPressed = false;

	private static bool altKeyPressed = false;

	private static bool shiftKeyPressed = false;

	private static Delegate0 globalKeyboardHookCallback = HandleLowLevelKeyboardHookSafely;

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern IntPtr SetWindowsHookEx(int int_5, Delegate0 delegate0_1, IntPtr intptr_1, uint uint_0);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool UnhookWindowsHookEx(IntPtr intptr_1);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern IntPtr CallNextHookEx(IntPtr intptr_1, int int_5, IntPtr intptr_2, IntPtr intptr_3);

	[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern IntPtr GetModuleHandle(string string_0);

	public static void InstallGlobalKeyboardHook()
	{
		intptr_0 = CreateLowLevelKeyboardHook(globalKeyboardHookCallback);
	}

	public static void RemoveGlobalKeyboardHookAndResetState()
	{
		UnhookWindowsHookEx(intptr_0);
		controlKeyPressed = false;
		spaceKeyPressed = false;
		currentVirtualKeyCode = 0;
	}

	private static IntPtr CreateLowLevelKeyboardHook(Delegate0 delegate0_1)
	{
		using Process process = Process.GetCurrentProcess();
		using ProcessModule processModule = process.MainModule;
		return SetWindowsHookEx(13, delegate0_1, GetModuleHandle(processModule.ModuleName), 0u);
	}

	private static IntPtr HandleLowLevelKeyboardHookSafely(int int_5, IntPtr intptr_1, IntPtr intptr_2)
	{
		try
		{
			return HandleLowLevelKeyboardHookCore(int_5, intptr_1, intptr_2);
		}
		catch
		{
		}
		return IntPtr.Zero;
	}

	private static IntPtr HandleLowLevelKeyboardHookCore(int int_5, IntPtr intptr_1, IntPtr intptr_2)
	{
		if (int_5 < 0)
		{
			currentVirtualKeyCode = 0;
		}
		else
		{
			currentVirtualKeyCode = Marshal.ReadInt32(intptr_2);
			if (WindowsInteropHelper.int_28 != (int)intptr_1)
			{
				if (WindowsInteropHelper.int_29 == (int)intptr_1)
				{
					if (currentVirtualKeyCode == 32)
					{
						CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_8 = 0;
					}
					if (currentVirtualKeyCode != 162 && currentVirtualKeyCode != 163)
					{
						if (currentVirtualKeyCode != 164 && currentVirtualKeyCode != 165)
						{
							if (currentVirtualKeyCode == 160 || currentVirtualKeyCode == 161)
							{
								shiftKeyPressed = false;
							}
						}
						else
						{
							altKeyPressed = false;
						}
					}
					else
					{
						controlKeyPressed = false;
					}
					if (currentVirtualKeyCode <= 48 || 58 <= currentVirtualKeyCode)
					{
						spaceKeyPressed = false;
					}
					currentVirtualKeyCode = 0;
				}
			}
			else
			{
				int_1 = currentVirtualKeyCode;
				if (currentVirtualKeyCode != 32)
				{
					if (48 < currentVirtualKeyCode && currentVirtualKeyCode < 58 && ApplicationRuntimeCoordinator.characterAccountConfig_0.int_136 > 0)
					{
						SignalNumberHotkeyToEnabledAccounts(currentVirtualKeyCode);
					}
				}
				else
				{
					CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_8 = 1;
					spaceKeyPressed = true;
				}
				if (currentVirtualKeyCode != KeyboardKeyCatalog.int_7 && currentVirtualKeyCode != KeyboardKeyCatalog.int_8)
				{
					if (currentVirtualKeyCode == KeyboardKeyCatalog.int_9 || currentVirtualKeyCode == KeyboardKeyCatalog.int_10)
					{
						CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_9 = 2;
						ApplicationRuntimeCoordinator.int_2 = 2;
					}
				}
				else
				{
					CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_9 = 1;
					ApplicationRuntimeCoordinator.int_2 = 1;
				}
				if (currentVirtualKeyCode != 162 && currentVirtualKeyCode != 163)
				{
					if (currentVirtualKeyCode != 164 && currentVirtualKeyCode != 165)
					{
						if (currentVirtualKeyCode == 160 || currentVirtualKeyCode == 161)
						{
							shiftKeyPressed = true;
						}
					}
					else
					{
						altKeyPressed = true;
					}
				}
				else
				{
					controlKeyPressed = true;
				}
			}
			if (ApplicationRuntimeCoordinator.characterAccountConfig_0.int_136 > 0)
			{
				if (controlKeyPressed)
				{
					if (currentVirtualKeyCode != KeyboardKeyCatalog.int_11)
					{
						if (currentVirtualKeyCode == KeyboardKeyCatalog.int_12)
						{
							ApplicationRuntimeCoordinator.int_1 = 2;
						}
						else if (currentVirtualKeyCode != KeyboardKeyCatalog.int_13)
						{
							if (currentVirtualKeyCode != KeyboardKeyCatalog.int_14)
							{
								if (currentVirtualKeyCode != KeyboardKeyCatalog.int_15)
								{
									if (currentVirtualKeyCode == KeyboardKeyCatalog.int_16)
									{
										if (altKeyPressed)
										{
											ApplicationRuntimeCoordinator.int_1 = 6;
										}
										else
										{
											ApplicationRuntimeCoordinator.int_1 = 5;
										}
									}
									else if (currentVirtualKeyCode != KeyboardKeyCatalog.int_17)
									{
										if (currentVirtualKeyCode == KeyboardKeyCatalog.int_18)
										{
											CycleTargetPriorityMode();
										}
										else if (currentVirtualKeyCode == KeyboardKeyCatalog.int_1)
										{
											ApplicationRuntimeCoordinator.int_1 = 7;
										}
										else if (currentVirtualKeyCode != 9)
										{
											if (altKeyPressed)
											{
												if (Form1.int_68 > 0)
												{
													Form1.int_152 = 1;
												}
											}
											else if (shiftKeyPressed && FormDame.int_8 > 0)
											{
												FormDame.int_7 = 1 - Convert.ToByte(FormDame.int_7 > 0);
											}
										}
										else
										{
											bool_0 = true;
										}
									}
									else
									{
										GameProcessInteractionHelper.WriteSharedSlotInt32(ApplicationRuntimeCoordinator.characterAccountConfig_0, GameProcessInteractionHelper.uint_21, 3, 4);
									}
								}
								else
								{
									GameProcessInteractionHelper.WriteSharedSlotInt32(ApplicationRuntimeCoordinator.characterAccountConfig_0, GameProcessInteractionHelper.uint_21, 2, 4);
								}
							}
							else
							{
								GameProcessInteractionHelper.WriteSharedSlotInt32(ApplicationRuntimeCoordinator.characterAccountConfig_0, GameProcessInteractionHelper.uint_21, 1, 4);
							}
						}
						else
						{
							ApplicationRuntimeCoordinator.int_1 = 3;
						}
					}
					else
					{
						ApplicationRuntimeCoordinator.int_1 = 1;
					}
					if (spaceKeyPressed)
					{
						FormTest.int_0 = 32;
					}
				}
				if (spaceKeyPressed)
				{
					GameProcessInteractionHelper.WriteSharedSlotInt32(ApplicationRuntimeCoordinator.characterAccountConfig_0, GameProcessInteractionHelper.uint_21, 0, 4);
					if (Form1.characterAccountConfig_1 != null)
					{
						try
						{
							for (int i = 0; i < Form1.characterAccountConfig_1.Length; i++)
							{
								GameProcessInteractionHelper.WriteSharedSlotInt32(Form1.characterAccountConfig_1[i], GameProcessInteractionHelper.uint_50, 0, 4);
							}
						}
						catch
						{
						}
					}
					if (!FormPhongKy1.bool_1)
					{
						if (FormPhongKy1.bool_2)
						{
							FormPhongKy1.bool_4 = true;
						}
					}
					else
					{
						FormPhongKy1.bool_3 = true;
					}
				}
			}
		}
		int_2 = ApplicationRuntimeCoordinator.int_3;
		CharacterStateSyncCoordinator.characterSyncSnapshot_0.int_7 = currentVirtualKeyCode;
		return CallNextHookEx(intptr_0, int_5, intptr_1, intptr_2);
	}

	private static void SignalNumberHotkeyToEnabledAccounts(int int_5)
	{
		int num = int_5 - 49;
		if (num < 0 || num > 8)
		{
			return;
		}
		int int_6 = 0;
		byte[] byte_ = new byte[1] { 1 };
		if (Form1.characterAccountConfig_1 == null)
		{
			return;
		}
		try
		{
			for (int i = 0; i < Form1.characterAccountConfig_1.Length; i++)
			{
				if (Form1.characterAccountConfig_1[i].bool_25)
				{
					WindowsInteropHelper.WriteProcessMemory(Form1.characterAccountConfig_1[i].int_137, Form1.characterAccountConfig_1[i].uint_16 + GameProcessInteractionHelper.uint_45 * 4 + (uint)num, byte_, 1, ref int_6);
				}
			}
		}
		catch
		{
		}
	}

	private static void CycleTargetPriorityMode()
	{
		try
		{
			Form1 form = null;
			foreach (Form openForm in Application.OpenForms)
			{
				if (openForm is Form1)
				{
					form = (Form1)openForm;
					break;
				}
			}
			if (form == null || form.comboBoxUuTien == null)
			{
				return;
			}
			string text = form.comboBoxUuTien.Text;
			string text2 = "";
			switch (text)
			{
			case "Khoảng cách":
				text2 = "Ngũ hành";
				if (form.checkBox2 != null && !form.checkBox2.Checked)
				{
					form.checkBox2.Checked = true;
				}
				break;
			case "Ngũ hành":
				text2 = "Môn phái";
				break;
			case "Môn phái":
				text2 = "Khoảng cách";
				break;
			default:
				text2 = "Khoảng cách";
				break;
			}
			form.comboBoxUuTien.Text = text2;
			if (text2 == "Khoảng cách")
			{
				form.buttonUuTien.Text = "Áp dụng";
			}
			else
			{
				form.buttonUuTien.Text = "Ưu tiên";
			}
			NotifyPriorityModeForm(text2);
		}
		catch
		{
		}
	}

	private static void NotifyPriorityModeForm(string string_0)
	{
		try
		{
			FormUutienNguHanh formUutienNguHanh = null;
			foreach (Form openForm in Application.OpenForms)
			{
				if (openForm is FormUutienNguHanh)
				{
					formUutienNguHanh = (FormUutienNguHanh)openForm;
					break;
				}
			}
			formUutienNguHanh?.method_7(string_0);
		}
		catch
		{
		}
	}
}
