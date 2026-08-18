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

public class GlobalKeyboardHookManager
{
	private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

	private const int LowLevelKeyboardHookId = 13;

	public static int pendingVirtualKeyCode = 0;

	public static int cachedKeyPressCount = 0;

	public static int int_3 = 121;

	public static bool ctrlTabToggleRequested = false;

	public static IntPtr globalKeyboardHookHandle = IntPtr.Zero;

	private static int currentVirtualKeyCode = 0;

	private static bool controlKeyPressed = false;

	private static bool spaceKeyPressed = false;

	private static bool altKeyPressed = false;

	private static bool shiftKeyPressed = false;

	private static LowLevelKeyboardProc globalKeyboardHookCallback = HandleLowLevelKeyboardHookSafely;

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern IntPtr SetWindowsHookEx(int hookType, LowLevelKeyboardProc hookCallback, IntPtr moduleHandle, uint threadId);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool UnhookWindowsHookEx(IntPtr hookHandle);

	[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern IntPtr CallNextHookEx(IntPtr hookHandle, int hookCode, IntPtr message, IntPtr hookData);

	[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern IntPtr GetModuleHandle(string moduleName);

	public static void InstallGlobalKeyboardHook()
	{
		globalKeyboardHookHandle = CreateLowLevelKeyboardHook(globalKeyboardHookCallback);
	}

	public static void RemoveGlobalKeyboardHookAndResetState()
	{
		UnhookWindowsHookEx(globalKeyboardHookHandle);
		controlKeyPressed = false;
		spaceKeyPressed = false;
		currentVirtualKeyCode = 0;
	}

	private static IntPtr CreateLowLevelKeyboardHook(LowLevelKeyboardProc hookCallback)
	{
		using Process process = Process.GetCurrentProcess();
		using ProcessModule processModule = process.MainModule;
		return SetWindowsHookEx(13, hookCallback, GetModuleHandle(processModule.ModuleName), 0u);
	}

	private static IntPtr HandleLowLevelKeyboardHookSafely(int hookCode, IntPtr message, IntPtr hookData)
	{
		try
		{
			return HandleLowLevelKeyboardHookCore(hookCode, message, hookData);
		}
		catch
		{
		}
		return IntPtr.Zero;
	}

	private static IntPtr HandleLowLevelKeyboardHookCore(int hookCode, IntPtr message, IntPtr hookData)
	{
		if (hookCode < 0)
		{
			currentVirtualKeyCode = 0;
		}
		else
		{
			currentVirtualKeyCode = Marshal.ReadInt32(hookData);
			if (WindowsInteropHelper.WindowMessageKeyDown != (int)message)
			{
				if (WindowsInteropHelper.WindowMessageKeyUp == (int)message)
				{
					if (currentVirtualKeyCode == 32)
					{
						CharacterStateSyncCoordinator.characterSyncSnapshot_0.spaceKeyPressedFlag = 0;
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
				pendingVirtualKeyCode = currentVirtualKeyCode;
				if (currentVirtualKeyCode != 32)
				{
					if (48 < currentVirtualKeyCode && currentVirtualKeyCode < 58 && ApplicationRuntimeCoordinator.foregroundCharacterAccount.int_136 > 0)
					{
						SignalNumberHotkeyToEnabledAccounts(currentVirtualKeyCode);
					}
				}
				else
				{
					CharacterStateSyncCoordinator.characterSyncSnapshot_0.spaceKeyPressedFlag = 1;
					spaceKeyPressed = true;
				}
				if (currentVirtualKeyCode != KeyboardKeyCatalog.virtualKeyNumpadAdd && currentVirtualKeyCode != KeyboardKeyCatalog.virtualKeyOemPlus)
				{
					if (currentVirtualKeyCode == KeyboardKeyCatalog.virtualKeyNumpadSubtract || currentVirtualKeyCode == KeyboardKeyCatalog.virtualKeyOemMinus)
					{
						CharacterStateSyncCoordinator.characterSyncSnapshot_0.pendingSyncCommandCode = 2;
						ApplicationRuntimeCoordinator.pendingSyncCommandCode = 2;
					}
				}
				else
				{
					CharacterStateSyncCoordinator.characterSyncSnapshot_0.pendingSyncCommandCode = 1;
					ApplicationRuntimeCoordinator.pendingSyncCommandCode = 1;
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
			if (ApplicationRuntimeCoordinator.foregroundCharacterAccount.int_136 > 0)
			{
				if (controlKeyPressed)
				{
					if (currentVirtualKeyCode != KeyboardKeyCatalog.virtualKeyZ)
					{
						if (currentVirtualKeyCode == KeyboardKeyCatalog.virtualKeyX)
						{
							ApplicationRuntimeCoordinator.pendingHotkeyActionCode = 2;
						}
						else if (currentVirtualKeyCode != KeyboardKeyCatalog.virtualKeyK)
						{
							if (currentVirtualKeyCode != KeyboardKeyCatalog.virtualKeyA)
							{
								if (currentVirtualKeyCode != KeyboardKeyCatalog.virtualKeyS)
								{
									if (currentVirtualKeyCode == KeyboardKeyCatalog.virtualKeyF)
									{
										if (altKeyPressed)
										{
											ApplicationRuntimeCoordinator.pendingHotkeyActionCode = 6;
										}
										else
										{
											ApplicationRuntimeCoordinator.pendingHotkeyActionCode = 5;
										}
									}
									else if (currentVirtualKeyCode != KeyboardKeyCatalog.virtualKeyG)
									{
										if (currentVirtualKeyCode == KeyboardKeyCatalog.virtualKey1)
										{
											CycleTargetPriorityMode();
										}
										else if (currentVirtualKeyCode == KeyboardKeyCatalog.virtualKeyF1)
										{
											ApplicationRuntimeCoordinator.pendingHotkeyActionCode = 7;
										}
										else if (currentVirtualKeyCode != 9)
										{
											if (altKeyPressed)
											{
												if (Form1.repairHotkeyEnabled > 0)
												{
													Form1.repairAllOperationState = 1;
												}
											}
											else if (shiftKeyPressed && FormDame.ctrlShiftToggleEnabled > 0)
											{
												FormDame.requestedCombinedDamageEnabled = 1 - Convert.ToByte(FormDame.requestedCombinedDamageEnabled > 0);
											}
										}
										else
										{
											ctrlTabToggleRequested = true;
										}
									}
									else
									{
										GameProcessInteractionHelper.WriteSharedSlotInt32(ApplicationRuntimeCoordinator.foregroundCharacterAccount, GameProcessInteractionHelper.inventoryOperationStateSlot, 3, 4);
									}
								}
								else
								{
									GameProcessInteractionHelper.WriteSharedSlotInt32(ApplicationRuntimeCoordinator.foregroundCharacterAccount, GameProcessInteractionHelper.inventoryOperationStateSlot, 2, 4);
								}
							}
							else
							{
								GameProcessInteractionHelper.WriteSharedSlotInt32(ApplicationRuntimeCoordinator.foregroundCharacterAccount, GameProcessInteractionHelper.inventoryOperationStateSlot, 1, 4);
							}
						}
						else
						{
							ApplicationRuntimeCoordinator.pendingHotkeyActionCode = 3;
						}
					}
					else
					{
						ApplicationRuntimeCoordinator.pendingHotkeyActionCode = 1;
					}
					if (spaceKeyPressed)
					{
						FormTest.int_0 = 32;
					}
				}
				if (spaceKeyPressed)
				{
					GameProcessInteractionHelper.WriteSharedSlotInt32(ApplicationRuntimeCoordinator.foregroundCharacterAccount, GameProcessInteractionHelper.inventoryOperationStateSlot, 0, 4);
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
					if (!FormPhongKy1.isRecordingPrimaryRoute)
					{
						if (FormPhongKy1.isRecordingSecondaryRoute)
						{
							FormPhongKy1.secondaryRouteCaptureRequested = true;
						}
					}
					else
					{
						FormPhongKy1.primaryRouteCaptureRequested = true;
					}
				}
			}
		}
		cachedKeyPressCount = ApplicationRuntimeCoordinator.currentKeyPressCount;
		CharacterStateSyncCoordinator.characterSyncSnapshot_0.lastVirtualKeyCode = currentVirtualKeyCode;
		return CallNextHookEx(globalKeyboardHookHandle, hookCode, message, hookData);
	}

	private static void SignalNumberHotkeyToEnabledAccounts(int virtualKeyCode)
	{
		int hotkeyIndex = virtualKeyCode - 49;
		if (hotkeyIndex < 0 || hotkeyIndex > 8)
		{
			return;
		}
		int bytesWritten = 0;
		byte[] triggerBytes = new byte[1] { 1 };
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
					WindowsInteropHelper.WriteProcessMemory(Form1.characterAccountConfig_1[i].int_137, Form1.characterAccountConfig_1[i].uint_16 + GameProcessInteractionHelper.uint_45 * 4 + (uint)hotkeyIndex, triggerBytes, 1, ref bytesWritten);
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
			Form1 mainForm = null;
			foreach (Form openForm in Application.OpenForms)
			{
				if (openForm is Form1)
				{
					mainForm = (Form1)openForm;
					break;
				}
			}
			if (mainForm == null || mainForm.comboBoxUuTien == null)
			{
				return;
			}
			string currentPriorityMode = mainForm.comboBoxUuTien.Text;
			string nextPriorityMode = "";
			switch (currentPriorityMode)
			{
			case "Khoảng cách":
				nextPriorityMode = "Ngũ hành";
				if (mainForm.checkBox2 != null && !mainForm.checkBox2.Checked)
				{
					mainForm.checkBox2.Checked = true;
				}
				break;
			case "Ngũ hành":
				nextPriorityMode = "Môn phái";
				break;
			case "Môn phái":
				nextPriorityMode = "Khoảng cách";
				break;
			default:
				nextPriorityMode = "Khoảng cách";
				break;
			}
			mainForm.comboBoxUuTien.Text = nextPriorityMode;
			if (nextPriorityMode == "Khoảng cách")
			{
				mainForm.buttonUuTien.Text = "Áp dụng";
			}
			else
			{
				mainForm.buttonUuTien.Text = "Ưu tiên";
			}
			NotifyPriorityModeForm(nextPriorityMode);
		}
		catch
		{
		}
	}

	private static void NotifyPriorityModeForm(string priorityModeText)
	{
		try
		{
			FormUutienNguHanh priorityForm = null;
			foreach (Form openForm in Application.OpenForms)
			{
				if (openForm is FormUutienNguHanh)
				{
					priorityForm = (FormUutienNguHanh)openForm;
					break;
				}
			}
			priorityForm?.method_7(priorityModeText);
		}
		catch
		{
		}
	}
}
