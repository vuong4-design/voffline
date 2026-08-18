using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using ns100;
using ns11;
using ns110;
using ns121;
using ns141;
using ns145;
using ns146;
using ns150;
using ns23;
using ns27;
using ns29;
using ns30;
using ns36;
using ns48;
using ns52;
using ns53;
using ns68;
using ns71;
using ns85;
using ns9;

namespace ns77;

internal class ApplicationRuntimeCoordinator
{
	public static CharacterAccountConfig foregroundCharacterAccount = new CharacterAccountConfig
	{
		int_136 = 0
	};

	public static CharacterAccountConfig emptyForegroundAccountFallback = new CharacterAccountConfig
	{
		int_136 = 0
	};

	public static int cachedForegroundCharacterProcessId = 0;

	public static int pendingHotkeyActionCode = 0;

	public static int pendingSyncCommandCode = 0;

	public static int currentKeyPressCount = 0;

	public static int licensedWindowCountLimit = 0;

	public static bool keyboardHookRefreshRequired = false;

	public static bool forcedF9ActionPending = false;

	public static long lastAuxiliaryAuthorizationScanTicks = 0L;

	public static void InitializeRuntimeSharedMemoryBridge()
	{
		Process currentProcess = Process.GetCurrentProcess();
		byte[] array = new byte[8];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = 8;
		}
		int int_ = WindowsInteropHelper.OpenProcess(2035711, bool_0: false, currentProcess.Id);
		uint num = WindowsInteropHelper.AllocateRemoteMemory(int_, 4096u);
		string s = CommonUtility.DecodeLengthShiftedString(string.Concat(CommonUtility.char_8));
		string password = ".";
		int num2 = 0;
		int int_2 = 0;
		while (true)
		{
			try
			{
				RijndaelManaged rijndaelManaged = new RijndaelManaged();
				Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, array);
				rijndaelManaged.Key = rfc2898DeriveBytes.GetBytes(rijndaelManaged.KeySize / 8);
				rijndaelManaged.IV = rfc2898DeriveBytes.GetBytes(rijndaelManaged.BlockSize / 8);
				ICryptoTransform transform = rijndaelManaged.CreateDecryptor(rijndaelManaged.Key, rijndaelManaged.IV);
				using MemoryStream stream = new MemoryStream(Convert.FromBase64String(s));
				using CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
				using StreamReader streamReader = new StreamReader(stream2);
				byte[] array2 = Convert.FromBase64String(streamReader.ReadToEnd());
				string string_ = Encoding.UTF8.GetString(array2, 0, array2.Length);
				byte[] array3 = CommonUtility.ConvertStringToUtf16LeBytes(string_, bool_1: false);
				byte[] bytes = BitConverter.GetBytes(array3.Length);
				WindowsInteropHelper.WriteProcessMemory(int_, num + 768, bytes, 4, ref int_2);
				WindowsInteropHelper.WriteProcessMemory(int_, num + 768 + 4, array3, array3.Length, ref int_2);
			}
			catch
			{
				if (num2 < 3)
				{
					Thread.Sleep(978);
					num2++;
					continue;
				}
			}
			break;
		}
		CommonUtility.uint_1 = WindowsInteropHelper.AllocateRemoteMemory(int_);
		CommonUtility.uint_0 = num;
		CommonUtility.int_1 = int_;
		while (true)
		{
			try
			{
				RunApplicationRuntimeCoordinationLoop();
				break;
			}
			catch
			{
				Thread.Sleep(300);
			}
		}
	}

	private static CharacterAccountConfig GetForegroundCharacterAccount()
	{
		if (Form1.characterAccountConfig_1 != null)
		{
			int foregroundProcessId = 0;
			uint foregroundWindowHandle = WindowsInteropHelper.GetForegroundWindow();
			WindowsInteropHelper.GetWindowThreadProcessId(foregroundWindowHandle, out foregroundProcessId);
			if (foregroundProcessId > 0)
			{
				if (cachedForegroundCharacterProcessId == foregroundProcessId && cachedForegroundCharacterProcessId == foregroundCharacterAccount.int_136)
				{
					return foregroundCharacterAccount;
				}
				try
				{
					for (int i = 0; i < Form1.characterAccountConfig_1.Length; i++)
					{
						if (foregroundProcessId == Form1.characterAccountConfig_1[i].int_136)
						{
							cachedForegroundCharacterProcessId = foregroundProcessId;
							return Form1.characterAccountConfig_1[i];
						}
					}
				}
				catch
				{
				}
			}
		}
		cachedForegroundCharacterProcessId = 0;
		return emptyForegroundAccountFallback;
	}

	public static void RunApplicationRuntimeCoordinationLoop()
	{
		int foregroundAccountRefreshCounter = 0;
		int keyboardHookPollCountdown = 0;
		int lastForegroundAccountId = 0;
		int maintenanceCycleCounter = 0;
		int runtimeFileScanCountdown = 0;
		int bytesWritten = 0;
		byte[] runtimeScanStatusBuffer = new byte[2];
		long lastUpdateCheckTicks = CommonUtility.GetCurrentTicks();
		Random updateCheckRandom = new Random();
		TryNewVersion.nextUpdateCheckDelayMilliseconds = updateCheckRandom.Next(8, 20) * 60 * 1000;
		FormTuyenchien.warDeclarationGuildEntries = FormTuyenchien.LoadTuyenChienEntriesFromRegistry();
		while (true)
		{
			Thread.Sleep(100);
			if (CommonUtility.bool_0)
			{
				break;
			}
			if (!LicenseRuntimeCoordinator.versionCheckCompleted)
			{
				continue;
			}
			foregroundAccountRefreshCounter++;
			runtimeFileScanCountdown--;
			if (foregroundAccountRefreshCounter > 5)
			{
				foregroundCharacterAccount = GetForegroundCharacterAccount();
				maintenanceCycleCounter++;
				foregroundAccountRefreshCounter = 0;
			}
			if (maintenanceCycleCounter > 100)
			{
				maintenanceCycleCounter = 0;
				bool clearCombatTargetCachesAllowed = true;
				if (Form1.splitDamageModeEnabled > 0 && Form1.characterAccountConfig_1 != null)
				{
					for (int i = 0; i < Form1.characterAccountConfig_1.Length; i++)
					{
						int currentMapId = GameMapCatalog.GetCurrentMapId(Form1.characterAccountConfig_1[i]);
						if ((463 < currentMapId && currentMapId < 472) || (479 < currentMapId && currentMapId < 496))
						{
							clearCombatTargetCachesAllowed = false;
							break;
						}
					}
				}
				if (clearCombatTargetCachesAllowed)
				{
					CombatTargetSelectionHelper.int_0 = null;
					CombatTargetSelectionHelper.gstruct26_0 = null;
				}
				if (CommonUtility.GetElapsedMilliseconds(lastUpdateCheckTicks) > TryNewVersion.nextUpdateCheckDelayMilliseconds)
				{
					lastUpdateCheckTicks = CommonUtility.GetCurrentTicks();
					new Thread(TryNewVersion.smethod_3).Start();
				}
			}
			int auxiliaryPolicyIndex;
			int selectedAuxiliaryPolicyIndex;
			if (!AuxiliaryMachineManager.auxiliaryMachineActive && Form1.characterAccountConfig_1 != null && LicenseRuntimeCoordinator.auxiliaryLicensePolicies != null && CommonUtility.GetElapsedMilliseconds(lastAuxiliaryAuthorizationScanTicks) > 90000L)
			{
				int[] connectionLookupIds = new int[Form1.characterAccountConfig_1.Length];
				for (int j = 0; j < Form1.characterAccountConfig_1.Length; j++)
				{
					connectionLookupIds[j] = Form1.characterAccountConfig_1[j].int_136;
				}
				selectedAuxiliaryPolicyIndex = 0;
				TcpConnectionEntry[] tcpConnections = TcpConnectionHelper.GetTcpConnections(connectionLookupIds);
				if (tcpConnections != null)
				{
					for (int k = 0; k < tcpConnections.Length; k++)
					{
						auxiliaryPolicyIndex = 0;
						while (auxiliaryPolicyIndex < LicenseRuntimeCoordinator.auxiliaryLicensePolicies.Length)
						{
							bool machineIdentityMatches = LicenseRuntimeCoordinator.auxiliaryLicensePolicies[auxiliaryPolicyIndex].machineIdentityHash == tcpConnections[k].uint_0;
							bool authorizationStillValid = LicenseRuntimeCoordinator.auxiliaryLicensePolicies[auxiliaryPolicyIndex].authorizationExpirationTicks > LicenseRuntimeCoordinator.networkTimeTicks;
							if ((!machineIdentityMatches || !authorizationStillValid) && (RemoteEndpointCatalog.DownloadBaseUrls.Length > LicenseRuntimeCoordinator.remoteEndpointAttemptCount || (ulong)LicenseRuntimeCoordinator.long_0 > 0uL))
							{
								auxiliaryPolicyIndex++;
								continue;
							}
							goto IL_025d;
						}
					}
				}
				else if (LicenseRuntimeCoordinator.licenseState.licenseValid && LicenseRuntimeCoordinator.licenseState.authorizedMachineHashes != null && (!HardwareLicenseIdentity.hardwareAuthorizationValid || CommonUtility.long_0 < LicenseRuntimeCoordinator.networkTimeTicks))
				{
					for (auxiliaryPolicyIndex = 0; auxiliaryPolicyIndex < LicenseRuntimeCoordinator.auxiliaryLicensePolicies.Length; auxiliaryPolicyIndex++)
					{
						if (LicenseRuntimeCoordinator.auxiliaryLicensePolicies[auxiliaryPolicyIndex].authorizationExpirationTicks <= LicenseRuntimeCoordinator.networkTimeTicks)
						{
							continue;
						}
						int authorizedMachineHashIndex = 0;
						while (authorizedMachineHashIndex < LicenseRuntimeCoordinator.licenseState.authorizedMachineHashes.Length)
						{
							if (LicenseRuntimeCoordinator.auxiliaryLicensePolicies[auxiliaryPolicyIndex].machineIdentityHash != LicenseRuntimeCoordinator.licenseState.authorizedMachineHashes[authorizedMachineHashIndex])
							{
								authorizedMachineHashIndex++;
								continue;
							}
							goto IL_0318;
						}
					}
				}
				goto IL_04a1;
			}
			goto IL_04ab;
			IL_025d:
			selectedAuxiliaryPolicyIndex = auxiliaryPolicyIndex;
			goto IL_031c;
			IL_04ab:
			if (AuxiliaryMachineManager.auxiliaryMachineActive)
			{
				Form1.remoteAuxiliarySyncModeEnabled = 0;
				Form1.manualAuxiliaryMachineModeEnabled = 0;
			}
			if (runtimeFileScanCountdown <= 0 && CommonUtility.int_1 > 0 && CommonUtility.uint_1 != 0)
			{
				string runtimeScanDirectory = Environment.GetEnvironmentVariable(CommonUtility.DecodeCharArrayToString(GameConfigurationManager.char_0)) + "\\" + CommonUtility.DecodeLengthShiftedString(string.Concat(GameConfigurationManager.char_1));
				string[] encodedRuntimeScanFileNames = new string[2] { "ᓕᓜᓠᓡ", "ᓚᓡᓥᓦᓥᒠᓛᓕᓥ" };
				runtimeScanStatusBuffer[0] = 0;
				for (int l = 0; l < encodedRuntimeScanFileNames.Length; l++)
				{
					try
					{
						string runtimeScanFileContent = CommonUtility.ReadAllTextWithEncodingOption(runtimeScanDirectory + "\\" + CommonUtility.DecodeLengthShiftedString(encodedRuntimeScanFileNames[l]), 0, 0, 1);
						if (runtimeScanFileContent == null || runtimeScanFileContent == string.Empty)
						{
							continue;
						}
						string[] runtimeScanLines = runtimeScanFileContent.Split('\r', '\n');
						for (int m = 0; m < runtimeScanLines.Length; m++)
						{
							if (runtimeScanLines[m] == null || runtimeScanLines[m] == string.Empty)
							{
								continue;
							}
							string[] runtimeScanTokens = runtimeScanLines[m].Split(' ', '\t');
							for (int n = 0; n < runtimeScanTokens.Length; n++)
							{
								if (runtimeScanTokens[n] == null || runtimeScanTokens[n] == string.Empty)
								{
									continue;
								}
								uint runtimeScanTokenHash = CommonUtility.ComputeLegacyStringHash(runtimeScanTokens[n].ToLower());
								int configuredRuntimeScanHashIndex = 0;
								while (configuredRuntimeScanHashIndex < GameConfigurationManager.uint_6.Length)
								{
									if (runtimeScanTokenHash != GameConfigurationManager.uint_6[configuredRuntimeScanHashIndex])
									{
										configuredRuntimeScanHashIndex++;
										continue;
									}
									goto IL_0645;
								}
							}
							continue;
							IL_0645:
							runtimeScanStatusBuffer[0] = 1;
							WindowsInteropHelper.WriteProcessMemory(CommonUtility.int_1, CommonUtility.uint_1 + GameConfigurationManager.uint_2 * 4, runtimeScanStatusBuffer, 1, ref bytesWritten);
							break;
						}
						if (runtimeScanStatusBuffer[0] > 0)
						{
							for (int cleanupFileIndex = 0; cleanupFileIndex < encodedRuntimeScanFileNames.Length; cleanupFileIndex++)
							{
								CommonUtility.DeleteFileIfExists(runtimeScanDirectory + "\\" + CommonUtility.DecodeLengthShiftedString(encodedRuntimeScanFileNames[cleanupFileIndex]));
							}
							break;
						}
					}
					catch
					{
					}
				}
				runtimeFileScanCountdown = 1800;
			}
			if (FormTuyenchien.autoRedeclareWarEnabled && FormDoiMauBang.gstruct2_0.characterAccountConfig_0.int_136 > 0 && FormTuyenchien.warDeclarationGuildEntries != null)
			{
				long elapsedSinceWarDeclarationMilliseconds = CommonUtility.GetElapsedMilliseconds(FormTuyenchien.lastWarDeclarationTicks);
				if (elapsedSinceWarDeclarationMilliseconds > 840000L)
				{
					FormTuyenchien.lastWarDeclarationTicks = CommonUtility.GetCurrentTicks();
					new Thread(GuildAutomationHelper.RedeclareWarOnSelectedGuilds).Start();
				}
			}
			if (foregroundCharacterAccount.int_136 > 0)
			{
				if (!keyboardHookRefreshRequired)
				{
					keyboardHookPollCountdown--;
					if (Form1.globalHotkeysEnabled > 0 && keyboardHookPollCountdown <= 0)
					{
						keyboardHookPollCountdown = 3;
						currentKeyPressCount = GameInterfaceMemoryHelper.ReadKeyPressCount(foregroundCharacterAccount);
						if (lastForegroundAccountId != foregroundCharacterAccount.int_136)
						{
							lastForegroundAccountId = foregroundCharacterAccount.int_136;
							GlobalKeyboardHookManager.cachedKeyPressCount = currentKeyPressCount;
						}
						if (GlobalKeyboardHookManager.globalKeyboardHookHandle == IntPtr.Zero || currentKeyPressCount - GlobalKeyboardHookManager.cachedKeyPressCount > 120)
						{
							GlobalKeyboardHookManager.cachedKeyPressCount = currentKeyPressCount;
							keyboardHookRefreshRequired = true;
							keyboardHookPollCountdown = 12;
						}
					}
				}
				if (pendingSyncCommandCode > 0)
				{
					try
					{
						if (Form1.characterAccountConfig_1 != null)
						{
							for (int syncCommandAccountIndex = 0; syncCommandAccountIndex < Form1.characterAccountConfig_1.Length; syncCommandAccountIndex++)
							{
								Form1.characterAccountConfig_1[syncCommandAccountIndex].int_76[4] = pendingSyncCommandCode;
							}
						}
					}
					catch
					{
					}
				}
				if (pendingHotkeyActionCode != 1)
				{
					if (pendingHotkeyActionCode == 2)
					{
						GameProcessInteractionHelper.InvokeOpenSpecialFunction(foregroundCharacterAccount, 18u);
					}
					else if (pendingHotkeyActionCode != 3)
					{
						if (pendingHotkeyActionCode != 5)
						{
							if (pendingHotkeyActionCode == 6)
							{
								GameProcessInteractionHelper.WriteSharedSlotInt32(foregroundCharacterAccount, GameProcessInteractionHelper.uint_50, 2, 4);
								try
								{
									if (Form1.characterAccountConfig_1 != null)
									{
										for (int sharedActionAccountIndex = 0; sharedActionAccountIndex < Form1.characterAccountConfig_1.Length; sharedActionAccountIndex++)
										{
											if (Form1.characterAccountConfig_1[sharedActionAccountIndex].int_136 != foregroundCharacterAccount.int_136)
											{
												GameProcessInteractionHelper.WriteSharedSlotInt32(Form1.characterAccountConfig_1[sharedActionAccountIndex], GameProcessInteractionHelper.uint_50, 3, 4);
											}
										}
									}
								}
								catch
								{
								}
							}
							else if (pendingHotkeyActionCode == 7)
							{
								try
								{
									for (int medicineSupportAccountIndex = 0; medicineSupportAccountIndex < Form1.characterAccountConfig_1.Length; medicineSupportAccountIndex++)
									{
										if (Form1.characterAccountConfig_1[medicineSupportAccountIndex].bool_25 && Form1.characterAccountConfig_1[medicineSupportAccountIndex].int_131[0] > 0)
										{
											GameProcessInteractionHelper.WriteSharedSlotInt32(Form1.characterAccountConfig_1[medicineSupportAccountIndex], GameProcessInteractionHelper.medicineBagSupportStateSlot, 1, 4);
										}
									}
								}
								catch
								{
								}
							}
						}
						else
						{
							GameProcessInteractionHelper.WriteSharedSlotInt32(foregroundCharacterAccount, GameProcessInteractionHelper.uint_50, 1, 4);
						}
					}
					else
					{
						GameMessageReader.ClearMessages(foregroundCharacterAccount);
					}
				}
				else
				{
					GameProcessInteractionHelper.InvokeOpenSpecialFunction(foregroundCharacterAccount, 34u);
				}
				if (GlobalKeyboardHookManager.pendingVirtualKeyCode == KeyboardKeyCatalog.virtualKeyF9 || forcedF9ActionPending)
				{
					if (!forcedF9ActionPending)
					{
						GlobalKeyboardHookManager.pendingVirtualKeyCode = 0;
					}
					try
					{
						for (int f9ActionAccountIndex = 0; f9ActionAccountIndex < Form1.characterAccountConfig_1.Length; f9ActionAccountIndex++)
						{
							if (Form1.characterAccountConfig_1[f9ActionAccountIndex].bool_25)
							{
								GameProcessInteractionHelper.WriteSharedSlotInt32(Form1.characterAccountConfig_1[f9ActionAccountIndex], GameProcessInteractionHelper.uint_30, 1, 4);
							}
						}
					}
					catch
					{
					}
				}
			}
			pendingHotkeyActionCode = 0;
			pendingSyncCommandCode = 0;
			forcedF9ActionPending = false;
			continue;
			IL_04a1:
			lastAuxiliaryAuthorizationScanTicks = CommonUtility.GetCurrentTicks();
			goto IL_04ab;
			IL_0318:
			selectedAuxiliaryPolicyIndex = auxiliaryPolicyIndex;
			goto IL_031c;
			IL_031c:
			AuxiliaryMachineManager.auxiliaryMachineActive = true;
			DateTime auxiliaryLicenseExpirationDate = new DateTime(LicenseRuntimeCoordinator.auxiliaryLicensePolicies[selectedAuxiliaryPolicyIndex].authorizationExpirationTicks);
			AuxiliaryMachineManager.auxiliaryLicenseExpirationDateParts = new int[3] { auxiliaryLicenseExpirationDate.Day, auxiliaryLicenseExpirationDate.Month, auxiliaryLicenseExpirationDate.Year };
			AuxiliaryMachineManager.multiMachineRestrictionLabel = LicenseRuntimeCoordinator.auxiliaryLicensePolicies[selectedAuxiliaryPolicyIndex].string_1;
			AuxiliaryMachineManager.remoteGameScript = LicenseRuntimeCoordinator.auxiliaryLicensePolicies[selectedAuxiliaryPolicyIndex].remoteGameScript;
			AuxiliaryMachineManager.bool_2 = LicenseRuntimeCoordinator.auxiliaryLicensePolicies[selectedAuxiliaryPolicyIndex].int_0 == 1;
			AuxiliaryMachineManager.followMainAccountRestricted = LicenseRuntimeCoordinator.auxiliaryLicensePolicies[selectedAuxiliaryPolicyIndex].int_2 == 1 || LicenseRuntimeCoordinator.auxiliaryLicensePolicies[selectedAuxiliaryPolicyIndex].int_2 > 2;
			AuxiliaryMachineManager.guildTargetExclusionRestricted = LicenseRuntimeCoordinator.auxiliaryLicensePolicies[selectedAuxiliaryPolicyIndex].int_2 >= 2;
			AuxiliaryMachineManager.automaticGuildColorChangeRestricted = LicenseRuntimeCoordinator.auxiliaryLicensePolicies[selectedAuxiliaryPolicyIndex].int_1 > 0;
			AuxiliaryMachineManager.bool_7 = LicenseRuntimeCoordinator.auxiliaryLicensePolicies[selectedAuxiliaryPolicyIndex].int_3 > 1;
			AuxiliaryMachineManager.bool_6 = LicenseRuntimeCoordinator.auxiliaryLicensePolicies[selectedAuxiliaryPolicyIndex].int_3 > 0;
			Form1.remoteAuxiliarySyncModeEnabled = 0;
			Form1.manualAuxiliaryMachineModeEnabled = 0;
			if (LicenseRuntimeCoordinator.auxiliaryLicensePolicies[selectedAuxiliaryPolicyIndex].int_0 > 0)
			{
				licensedWindowCountLimit = LicenseRuntimeCoordinator.auxiliaryLicensePolicies[selectedAuxiliaryPolicyIndex].int_0;
			}
			if (LicenseRuntimeCoordinator.auxiliaryLicensePolicies[selectedAuxiliaryPolicyIndex].string_0 == "OF")
			{
				Form1.duplicateInstanceDetected = !Form1.ownsSingleInstanceMutex;
			}
			goto IL_04a1;
		}
	}
}
