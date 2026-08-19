using System;
using System.Threading;
using ns100;
using ns106;
using ns11;
using ns121;
using ns23;
using ns35;
using ns40;
using ns53;
using ns61;
using ns71;
using ns77;
using ns83;
using ns85;

namespace ns43;

internal class CharacterStateSyncCoordinator
{
	public static CharacterSyncSnapshot characterSyncSnapshot_0;

	public static CharacterSyncSnapshot characterSyncSnapshot_1;

	public static bool bool_0 = false;

	public static bool bool_1 = false;

	public static uint[] uint_0 = null;

	private static int queuedTownTeleportCharacterId = 0;

	public static void RunPrimaryCharacterSyncLoop()
	{
		while (true)
		{
			try
			{
				if (CommonUtility.bool_0)
				{
					break;
				}
				RefreshPrimaryCharacterSyncSnapshot();
			}
			catch
			{
			}
			Thread.Sleep(999);
		}
	}

	public static void RefreshPrimaryCharacterSyncSnapshot()
	{
		CharacterAccountConfig primaryAccountConfig = default(CharacterAccountConfig);
		characterSyncSnapshot_0 = new CharacterSyncSnapshot
		{
			coordinates = new uint[2]
		};
		int lastPrimaryAccountId = -1;
		int previousEntityExistsFlag = -1;
		int accountRefreshCountdown = 0;
		string[] primaryStatusTemplates = new string[2] { "<color=yellow>Ac chÝnh: XXX bÞ mÊt kÕt nèi.", "<color=yellow>Ac chÝnh: XXX ®ang ho¹t ®éng." };
		long lastChannelSelectionTicks = 0L;
		long lastGlobalStateRefreshTicks = 0L;
		int bytesTransferred = 0;
		int missingEntityRetryCount = 0;
		int entityStateTransitionRetryCount = 0;
		byte[] globalByteBuffer = new byte[1];
		byte[] globalTwoByteBuffer = new byte[2];
		byte[] readBuffer = new byte[4];
		while (!CommonUtility.bool_0)
		{
			Thread.Sleep(200);
			if (CommonUtility.GetElapsedMilliseconds(lastGlobalStateRefreshTicks) > 6000L)
			{
				uint_0 = ReadCurrentCharacterTableValuesForAllAccounts();
				lastGlobalStateRefreshTicks = CommonUtility.GetCurrentTicks();
				WindowsInteropHelper.ReadProcessMemory(CommonUtility.int_1, CommonUtility.uint_1 + GameConfigurationManager.uint_2 * 4, globalByteBuffer, 1, ref bytesTransferred);
				WindowsInteropHelper.ReadProcessMemory(CommonUtility.int_1, CommonUtility.uint_1 + GameConfigurationManager.uint_3 * 4, globalTwoByteBuffer, 2, ref bytesTransferred);
			}
			if (Form1.mainAccountId != 0)
			{
				if (Form1.remoteAuxiliarySyncModeEnabled > 0 || Form1.manualAuxiliaryMachineModeEnabled > 0)
				{
					if (Form1.remoteAuxiliarySyncModeEnabled <= 0 && Form1.manualAuxiliaryMachineModeEnabled > 0)
					{
						AuxiliaryMachineManager.ProcessIncomingAuxiliarySyncText(primaryAccountConfig);
					}
					if (characterSyncSnapshot_1.pendingSyncCommandCode > 0)
					{
						ApplySyncCommandToEnabledAccounts(characterSyncSnapshot_1.pendingSyncCommandCode);
					}
					if (CommonUtility.GetElapsedMilliseconds(lastChannelSelectionTicks) > 30000L)
					{
						GameInterfaceMemoryHelper.SelectLastChannelTab(primaryAccountConfig, 0u);
						lastChannelSelectionTicks = CommonUtility.GetCurrentTicks();
					}
					characterSyncSnapshot_1.pendingSyncCommandCode = 0;
				}
				if (lastPrimaryAccountId != primaryAccountConfig.int_136)
				{
					lastPrimaryAccountId = primaryAccountConfig.int_136;
					SignalNonPrimaryAccountsForSync();
					BroadcastSyncStatusMessage("<color=yellow>Ac chÝnh: " + primaryAccountConfig.string_22);
					accountRefreshCountdown = -100;
				}
				accountRefreshCountdown--;
				if (accountRefreshCountdown <= 0)
				{
					int primaryAccountIndex = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, Form1.mainAccountId);
					if (primaryAccountIndex < 0 || WindowsInteropHelper.IsProcessExitedOrUnavailable(Form1.characterAccountConfig_1[primaryAccountIndex].process_0))
					{
						Form1.mainAccountId = 0;
						continue;
					}
					primaryAccountConfig = Form1.characterAccountConfig_1[primaryAccountIndex];
					accountRefreshCountdown = 10;
				}
				characterSyncSnapshot_0.gameModuleBaseAddress = primaryAccountConfig.uint_7;
				WindowsInteropHelper.ReadProcessMemory(primaryAccountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, readBuffer, 4, ref bytesTransferred);
				uint memoryRootPointer = BitConverter.ToUInt32(readBuffer, 0);
				WindowsInteropHelper.ReadProcessMemory(primaryAccountConfig.int_137, memoryRootPointer + GameConfigurationManager.memorySignatureScanConfig_13.resolvedValue, readBuffer, 4, ref bytesTransferred);
				uint memoryEntryIndex = BitConverter.ToUInt32(readBuffer, 0);
				uint memoryEntryOffset = memoryEntryIndex * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
				WindowsInteropHelper.ReadProcessMemory(primaryAccountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, readBuffer, 4, ref bytesTransferred);
				uint memoryTableBaseAddress = BitConverter.ToUInt32(readBuffer, 0);
				uint characterStateAddress = memoryTableBaseAddress + memoryEntryOffset;
				WindowsInteropHelper.ReadProcessMemory(primaryAccountConfig.int_137, characterStateAddress + GameConfigurationManager.memorySignatureScanConfig_50.resolvedValue, readBuffer, 4, ref bytesTransferred);
				characterSyncSnapshot_0.entityExistsFlag = BitConverter.ToInt32(readBuffer, 0);
				WindowsInteropHelper.ReadProcessMemory(primaryAccountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, readBuffer, 4, ref bytesTransferred);
				int currentMapId = BitConverter.ToInt32(readBuffer, 0);
				WindowsInteropHelper.ReadProcessMemory(primaryAccountConfig.int_137, characterStateAddress + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, readBuffer, 4, ref bytesTransferred);
				uint coordinateX = BitConverter.ToUInt32(readBuffer, 0);
				WindowsInteropHelper.ReadProcessMemory(primaryAccountConfig.int_137, characterStateAddress + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, readBuffer, 4, ref bytesTransferred);
				uint coordinateY = BitConverter.ToUInt32(readBuffer, 0);
				if (currentMapId <= 0 || coordinateX == 0 || coordinateY == 0)
				{
					Thread.Sleep(10);
					continue;
				}
				if (characterSyncSnapshot_0.entityExistsFlag <= 0 && missingEntityRetryCount <= 60)
				{
					missingEntityRetryCount++;
					Thread.Sleep(10);
					continue;
				}
				missingEntityRetryCount = 0;
				if (previousEntityExistsFlag != characterSyncSnapshot_0.entityExistsFlag)
				{
					if (characterSyncSnapshot_0.entityExistsFlag <= 0)
					{
						characterSyncSnapshot_0.snapshotUnavailable = true;
						entityStateTransitionRetryCount++;
						if (entityStateTransitionRetryCount < 3)
						{
							continue;
						}
					}
					previousEntityExistsFlag = characterSyncSnapshot_0.entityExistsFlag;
					BroadcastSyncStatusMessage(primaryStatusTemplates[previousEntityExistsFlag].Replace("XXX", primaryAccountConfig.string_22));
				}
				entityStateTransitionRetryCount = 0;
				characterSyncSnapshot_0.accountId = primaryAccountConfig.int_136;
				characterSyncSnapshot_0.processHandle = primaryAccountConfig.int_137;
				characterSyncSnapshot_0.process = primaryAccountConfig.process_0;
				characterSyncSnapshot_0.windowHandle = primaryAccountConfig.uint_4;
				characterSyncSnapshot_0.entityId = WindowsInteropHelper.ReadProcessUInt32(characterStateAddress, primaryAccountConfig.int_137);
				if (Form1.remoteAuxiliarySyncModeEnabled <= 0 && Form1.manualAuxiliaryMachineModeEnabled <= 0)
				{
					characterSyncSnapshot_0.packedMousePosition = GameInterfaceMemoryHelper.ReadPackedMousePosition(primaryAccountConfig);
				}
				else
				{
					characterSyncSnapshot_0.packedMousePosition = characterSyncSnapshot_1.packedMousePosition;
					characterSyncSnapshot_0.lastVirtualKeyCode = characterSyncSnapshot_1.lastVirtualKeyCode;
				}
				WindowsInteropHelper.ReadProcessMemory(primaryAccountConfig.int_137, characterStateAddress + GameConfigurationManager.memorySignatureScanConfig_43.resolvedValue, readBuffer, 4, ref bytesTransferred);
				characterSyncSnapshot_0.fightState = BitConverter.ToInt32(readBuffer, 0);
				if ((Form1.remoteAuxiliarySyncModeEnabled > 0 || Form1.manualAuxiliaryMachineModeEnabled > 0) && characterSyncSnapshot_1.mapId > 0)
				{
					characterSyncSnapshot_0.killerStatus = characterSyncSnapshot_1.killerStatus;
				}
				else
				{
					WindowsInteropHelper.ReadProcessMemory(primaryAccountConfig.int_137, characterStateAddress + GameConfigurationManager.memorySignatureScanConfig_56.resolvedValue, readBuffer, 4, ref bytesTransferred);
					characterSyncSnapshot_0.killerStatus = BitConverter.ToInt32(readBuffer, 0);
				}
				characterSyncSnapshot_0.lastRefreshTicks = CommonUtility.GetCurrentTicks();
				if (characterSyncSnapshot_0.coordinates == null)
				{
					characterSyncSnapshot_0.coordinates = new uint[2];
				}
				characterSyncSnapshot_0.coordinates[0] = coordinateX;
				characterSyncSnapshot_0.coordinates[1] = coordinateY;
				WindowsInteropHelper.ReadProcessMemory(primaryAccountConfig.int_137, characterStateAddress + GameConfigurationManager.memorySignatureScanConfig_54.resolvedValue, readBuffer, 4, ref bytesTransferred);
				characterSyncSnapshot_0.int_5 = BitConverter.ToInt32(readBuffer, 0);
				characterSyncSnapshot_0.characterName = WindowsInteropHelper.ReadNullTerminatedUtf7ProcessString(characterStateAddress + GameConfigurationManager.memorySignatureScanConfig_16.resolvedValue, primaryAccountConfig.int_137, 32);
				if (currentMapId != characterSyncSnapshot_0.mapId)
				{
					characterSyncSnapshot_0.mapId = currentMapId;
					SignalNonPrimaryAccountsForSync();
				}
				characterSyncSnapshot_0.snapshotUnavailable = memoryTableBaseAddress == 0 || characterSyncSnapshot_0.entityExistsFlag == 0 || characterSyncSnapshot_0.mapId == 0 || characterSyncSnapshot_0.characterName == string.Empty || characterSyncSnapshot_0.mapName == string.Empty;
				if (characterSyncSnapshot_0.mapId != 162)
				{
					if (characterSyncSnapshot_0.mapId != 321)
					{
						characterSyncSnapshot_0.mapName = WindowsInteropHelper.ReadNullTerminatedUtf7ProcessString(primaryAccountConfig.uint_7 + GameConfigurationManager.memorySignatureScanConfig_28.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_29.resolvedValue, primaryAccountConfig.int_137, 48);
					}
					else
					{
						characterSyncSnapshot_0.mapName = "Tr\u00adêng B¹ch s¬n Nam";
					}
				}
				else
				{
					characterSyncSnapshot_0.mapName = "§¹i Lý";
				}
				uint currentTargetEntityId = 0u;
				if (characterSyncSnapshot_0.fightState > 0)
				{
					WindowsInteropHelper.ReadProcessMemory(primaryAccountConfig.int_137, characterStateAddress + GameConfigurationManager.memorySignatureScanConfig_72.resolvedValue, readBuffer, 4, ref bytesTransferred);
					uint targetEntryIndex = BitConverter.ToUInt32(readBuffer, 0);
					if ((int)targetEntryIndex > 0)
					{
						uint targetEntryAddress = memoryTableBaseAddress + targetEntryIndex * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
						WindowsInteropHelper.ReadProcessMemory(primaryAccountConfig.int_137, targetEntryAddress + GameConfigurationManager.memorySignatureScanConfig_50.resolvedValue, readBuffer, 4, ref bytesTransferred);
						if (BitConverter.ToUInt32(readBuffer, 0) != 0)
						{
							WindowsInteropHelper.ReadProcessMemory(primaryAccountConfig.int_137, targetEntryAddress + GameConfigurationManager.memorySignatureScanConfig_52.resolvedValue, readBuffer, 4, ref bytesTransferred);
							uint targetEntryStatusCode = BitConverter.ToUInt32(readBuffer, 0);
							if (targetEntryStatusCode <= 1)
							{
								currentTargetEntityId = WindowsInteropHelper.ReadProcessUInt32(targetEntryAddress, primaryAccountConfig.int_137);
							}
						}
					}
					targetEntryIndex = 0u;
				}
				characterSyncSnapshot_0.currentTargetEntityId = currentTargetEntityId;
			}
			else
			{
				if (ApplicationRuntimeCoordinator.foregroundCharacterAccount.int_136 > 0)
				{
					characterSyncSnapshot_0.packedMousePosition = GameInterfaceMemoryHelper.ReadPackedMousePosition(ApplicationRuntimeCoordinator.foregroundCharacterAccount);
					uint[] foregroundCoordinates = CurrentCharacterMemoryHelper.GetCurrentCharacterPosition(ApplicationRuntimeCoordinator.foregroundCharacterAccount);
					if (foregroundCoordinates != null)
					{
						characterSyncSnapshot_0.coordinates = new uint[2]
						{
							foregroundCoordinates[0],
							foregroundCoordinates[1]
						};
					}
				}
				characterSyncSnapshot_0.accountId = 0;
				characterSyncSnapshot_0.entityId = 0u;
				characterSyncSnapshot_0.currentTargetEntityId = 0u;
				characterSyncSnapshot_0.mapId = 0;
				characterSyncSnapshot_0.snapshotUnavailable = false;
				lastPrimaryAccountId = -1;
			}
			WindowsInteropHelper.WriteProcessMemory(CommonUtility.int_1, CommonUtility.uint_1 + GameConfigurationManager.uint_4 * 4, globalByteBuffer, 1, ref bytesTransferred);
			WindowsInteropHelper.WriteProcessMemory(CommonUtility.int_1, CommonUtility.uint_1 + GameConfigurationManager.uint_5 * 4, globalTwoByteBuffer, 2, ref bytesTransferred);
		}
	}

	private static uint[] ReadCurrentCharacterTableValuesForAllAccounts()
	{
		if (Form1.characterAccountConfig_1 != null && Form1.characterAccountConfig_1.Length != 0)
		{
			uint[] tableValues = new uint[Form1.characterAccountConfig_1.Length];
			for (int accountIndex = 0; accountIndex < tableValues.Length; accountIndex++)
			{
				CharacterAccountConfig accountConfig = Form1.characterAccountConfig_1[accountIndex];
				uint memoryRootPointer = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, accountConfig.int_137);
				uint memoryEntryIndex = WindowsInteropHelper.ReadProcessUInt32(memoryRootPointer + GameConfigurationManager.memorySignatureScanConfig_13.resolvedValue, accountConfig.int_137);
				uint memoryTableBaseAddress = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, accountConfig.int_137);
				uint characterStateAddress = memoryTableBaseAddress + memoryEntryIndex * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
				tableValues[accountIndex] = WindowsInteropHelper.ReadProcessUInt32(characterStateAddress, accountConfig.int_137);
			}
			return tableValues;
		}
		return null;
	}

	private static void SignalNonPrimaryAccountsForSync()
	{
		try
		{
			if (Form1.characterAccountConfig_1 == null)
			{
				return;
			}
			for (int accountIndex = 0; accountIndex < Form1.characterAccountConfig_1.Length; accountIndex++)
			{
				if (Form1.characterAccountConfig_1[accountIndex].int_136 != characterSyncSnapshot_0.accountId)
				{
					GameProcessInteractionHelper.WriteSharedSlotInt32(Form1.characterAccountConfig_1[accountIndex], GameProcessInteractionHelper.routeSyncInterruptSlot, 1, 4);
				}
			}
		}
		catch
		{
		}
	}

	private static void BroadcastSyncStatusMessage(string message)
	{
		if (Form1.changeWindowTitleEnabled > 0 || Form1.characterAccountConfig_1 == null)
		{
			return;
		}
		try
		{
			for (int accountIndex = 0; accountIndex < Form1.characterAccountConfig_1.Length; accountIndex++)
			{
				int busyWaitCount = 0;
				while (Form1.characterAccountConfig_1[accountIndex].bool_2 && busyWaitCount < 30)
				{
					Thread.Sleep(10);
					busyWaitCount++;
				}
				if (!Form1.characterAccountConfig_1[accountIndex].bool_2)
				{
					GameProcessInteractionHelper.PrintGameMessage(Form1.characterAccountConfig_1[accountIndex], message);
				}
			}
		}
		catch
		{
		}
	}

	public static int RefreshTrackedEntityPositionAndDetectSeparation(uint trackedEntityId, ref uint[] trackedCoordinates, ref uint trackedEntryIndex)
	{
		uint memoryRootPointer = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, characterSyncSnapshot_0.processHandle);
		uint currentEntryOffset = WindowsInteropHelper.ReadProcessUInt32(memoryRootPointer + GameConfigurationManager.memorySignatureScanConfig_13.resolvedValue, characterSyncSnapshot_0.processHandle) * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
		uint memoryTableBaseAddress = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, characterSyncSnapshot_0.processHandle);
		uint currentCharacterStateAddress = memoryTableBaseAddress + currentEntryOffset;
		uint trackedEntryAddress = memoryTableBaseAddress + trackedEntryIndex * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
		uint entityIdAtTrackedEntry = WindowsInteropHelper.ReadProcessUInt32(trackedEntryAddress, characterSyncSnapshot_0.processHandle);
		uint currentCharacterX = WindowsInteropHelper.ReadProcessUInt32(currentCharacterStateAddress + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, characterSyncSnapshot_0.processHandle);
		uint currentCharacterY = WindowsInteropHelper.ReadProcessUInt32(currentCharacterStateAddress + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, characterSyncSnapshot_0.processHandle);
		if (currentCharacterX != 0 && currentCharacterY != 0)
		{
			if (characterSyncSnapshot_0.coordinates == null)
			{
				characterSyncSnapshot_0.coordinates = new uint[2];
			}
			characterSyncSnapshot_0.coordinates[0] = currentCharacterX;
			characterSyncSnapshot_0.coordinates[1] = currentCharacterY;
			if (entityIdAtTrackedEntry != trackedEntityId)
			{
				int bytesRead = 0;
				byte[] readBuffer = new byte[4];
				uint moduleBaseAddress = characterSyncSnapshot_0.gameModuleBaseAddress;
				if (moduleBaseAddress == 0)
				{
					moduleBaseAddress = 4194304u;
				}
				uint entityCountAddress = moduleBaseAddress + GameConfigurationManager.memorySignatureScanConfig_9.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_10.resolvedValue + 4;
				WindowsInteropHelper.ReadProcessMemory(characterSyncSnapshot_0.processHandle, entityCountAddress, readBuffer, 4, ref bytesRead);
				if (bytesRead != 4)
				{
					return 0;
				}
				int activeEntityCount = BitConverter.ToInt32(readBuffer, 0);
				if (activeEntityCount <= 1)
				{
					return 0;
				}
				int currentEntryIndex = (int)WindowsInteropHelper.ReadProcessUInt32(memoryRootPointer + GameConfigurationManager.memorySignatureScanConfig_13.resolvedValue, characterSyncSnapshot_0.processHandle);
				int scannedEntityCount = 0;
				trackedEntryIndex = 0u;
				for (uint candidateEntryIndex = 1u; candidateEntryIndex < 256; candidateEntryIndex++)
				{
					if (candidateEntryIndex % 50 == 0)
					{
						Thread.Sleep(10);
					}
					if (activeEntityCount <= scannedEntityCount)
					{
						break;
					}
					if (candidateEntryIndex == currentEntryIndex)
					{
						scannedEntityCount++;
						continue;
					}
					trackedEntryAddress = memoryTableBaseAddress + candidateEntryIndex * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
					WindowsInteropHelper.ReadProcessMemory(characterSyncSnapshot_0.processHandle, trackedEntryAddress + GameConfigurationManager.memorySignatureScanConfig_16.resolvedValue, readBuffer, 4, ref bytesRead);
					if (readBuffer[0] == 0 || bytesRead != 4)
					{
						continue;
					}
					scannedEntityCount++;
					WindowsInteropHelper.ReadProcessMemory(characterSyncSnapshot_0.processHandle, trackedEntryAddress + GameConfigurationManager.memorySignatureScanConfig_50.resolvedValue, readBuffer, 4, ref bytesRead);
					if (bytesRead == 4 && BitConverter.ToInt32(readBuffer, 0) > 0)
					{
						entityIdAtTrackedEntry = WindowsInteropHelper.ReadProcessUInt32(trackedEntryAddress, characterSyncSnapshot_0.processHandle);
						if (trackedEntityId == entityIdAtTrackedEntry)
						{
							trackedEntryIndex = candidateEntryIndex;
							break;
						}
					}
				}
				if (trackedEntryIndex == 0)
				{
					return -1;
				}
			}
			long previousDistanceSquared = GameAutomationUtility.GetSquaredCoordinateDistance(trackedCoordinates, characterSyncSnapshot_0.coordinates);
			trackedCoordinates = new uint[2]
			{
				WindowsInteropHelper.ReadProcessUInt32(trackedEntryAddress + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, characterSyncSnapshot_0.processHandle),
				WindowsInteropHelper.ReadProcessUInt32(trackedEntryAddress + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, characterSyncSnapshot_0.processHandle)
			};
			long currentDistanceSquared = GameAutomationUtility.GetSquaredCoordinateDistance(trackedCoordinates, characterSyncSnapshot_0.coordinates);
			int separationDistanceThreshold = Form1.mainAccountSearchDistance;
			if (separationDistanceThreshold < 200)
			{
				separationDistanceThreshold = 200;
			}
			if (currentDistanceSquared - previousDistanceSquared > 22500L && separationDistanceThreshold * separationDistanceThreshold <= currentDistanceSquared && currentDistanceSquared <= 1000000L)
			{
				return 1;
			}
			return 0;
		}
		return 0;
	}

	public static void MoveTowardCoordinateWithOffset(CharacterAccountConfig accountConfig, uint[] sourceCoordinates, uint[] destinationCoordinates, bool bool_2 = false)
	{
		if (destinationCoordinates != null && destinationCoordinates[0] != 0 && destinationCoordinates[1] != 0)
		{
			bool hasSourceCoordinates = sourceCoordinates != null && sourceCoordinates[0] != 0 && sourceCoordinates[1] != 0;
			long distanceSquared = GameAutomationUtility.GetSquaredCoordinateDistance(sourceCoordinates, destinationCoordinates);
			if (hasSourceCoordinates && (bool_2 || distanceSquared < 14400L))
			{
				uint[] offsetDestinationCoordinates = GameAutomationUtility.GetCoordinateOffsetAlongLine(sourceCoordinates, destinationCoordinates, -150);
				GameProcessInteractionHelper.RunToCoordinates(accountConfig, offsetDestinationCoordinates);
			}
			else
			{
				GameProcessInteractionHelper.RunToCoordinates(accountConfig, destinationCoordinates);
			}
			Thread.Sleep(60);
		}
	}

	public static bool DetectPrimaryAccountInputActivity(CharacterAccountConfig accountConfig, ref int previousKeyPressCount)
	{
		if (ApplicationRuntimeCoordinator.foregroundCharacterAccount.int_136 == accountConfig.int_136)
		{
			if (Form1.globalHotkeysEnabled > 0)
			{
				return 48 < characterSyncSnapshot_0.lastVirtualKeyCode && characterSyncSnapshot_0.lastVirtualKeyCode < 58;
			}
			int currentKeyPressCount = GameInterfaceMemoryHelper.ReadKeyPressCount(accountConfig);
			bool result = previousKeyPressCount != currentKeyPressCount;
			previousKeyPressCount = currentKeyPressCount;
			return result;
		}
		return false;
	}

	public static void ApplySyncCommandToEnabledAccounts(int syncCommandCode)
	{
		if (Form1.characterAccountConfig_1 == null)
		{
			return;
		}
		for (int accountIndex = 0; Form1.characterAccountConfig_1.Length > accountIndex; accountIndex++)
		{
			if (!Form1.characterAccountConfig_1[accountIndex].bool_25)
			{
				continue;
			}
			switch (syncCommandCode)
			{
			case 1:
			case 2:
				Form1.characterAccountConfig_1[accountIndex].int_76[4] = syncCommandCode;
				continue;
			case 3:
			case 4:
				Form1.boatDockIndex = syncCommandCode;
				Form1.characterAccountConfig_1[accountIndex].bool_55 = Form1.characterAccountConfig_1[accountIndex].bool_25;
				continue;
			case 5:
				new Thread(FormClickNPC.SelectNearestNpcForAllEnabledAccounts).Start();
				continue;
			}
			if (100 <= syncCommandCode && syncCommandCode <= 102)
			{
				Form1.boatDockIndex = syncCommandCode - 100;
				CommonUtility.AppendIntIfMissing(ref PhongLangDoBoardingAutomation.int_0, Form1.characterAccountConfig_1[accountIndex].int_136);
				if (!PhongLangDoBoardingAutomation.bool_0)
				{
					PhongLangDoBoardingAutomation.RunQueue();
				}
				continue;
			}
			switch (syncCommandCode)
			{
			case 104:
			{
				for (int waitIteration = 0; waitIteration < 100; waitIteration++)
				{
					if (queuedTownTeleportCharacterId <= 0)
					{
						break;
					}
					Thread.Sleep(1);
				}
				queuedTownTeleportCharacterId = Form1.characterAccountConfig_1[accountIndex].int_136;
				new Thread(UseTownTeleportForQueuedAccount).Start();
				break;
			}
			case 103:
			{
				int bytesWritten = 0;
				byte[] enabledFlagBuffer = new byte[1] { Convert.ToByte(Form1.characterAccountConfig_1[accountIndex].bool_25) };
				WindowsInteropHelper.WriteProcessMemory(Form1.characterAccountConfig_1[accountIndex].int_137, Form1.characterAccountConfig_1[accountIndex].uint_16 + GameProcessInteractionHelper.uint_33 * 4, enabledFlagBuffer, 1, ref bytesWritten);
				break;
			}
			}
		}
	}

	private static void UseTownTeleportForQueuedAccount()
	{
		int characterId = queuedTownTeleportCharacterId;
		queuedTownTeleportCharacterId = 0;
		int accountIndex = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, characterId);
		if (0 <= accountIndex)
		{
			GameAutomationUtility.TryUseTownTeleportItem(Form1.characterAccountConfig_1[accountIndex]);
		}
	}
}
