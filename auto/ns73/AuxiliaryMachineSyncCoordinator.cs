using System;
using System.Net;
using System.Net.Sockets;
using ns100;
using ns109;
using ns11;
using ns121;
using ns146;
using ns19;
using ns34;
using ns43;
using ns56;
using ns63;
using ns71;
using ns74;
using ns75;

namespace ns73;

internal class AuxiliaryMachineSyncCoordinator
{
	public static AuxiliaryMachineServer Server = null;

	public static AuxiliaryMachineClient Client = null;

	public static long long_0 = 0L;

	public static int int_0 = 0;

	public static int ConnectionMode = WindowsRegistryHelper.ReadApplicationRegistryInt32("KieuConnect", 0, "0");

	public static string StatusMessage = null;

	public static int ServerPort = WindowsRegistryHelper.ReadApplicationRegistryInt32("PortServer", 0, "0");

	public static string LocalIpAddress = string.Empty;

	public static int RemotePort = WindowsRegistryHelper.ReadApplicationRegistryInt32("nPort", 0, "0");

	public static string RemoteIpAddress = WindowsRegistryHelper.ReadApplicationRegistryString("ConnectIP", 0);

	private static bool combatTargetSyncPayloadReceived = false;

	public static string[] GetLocalIpv4Addresses()
	{
		string[] ipv4Addresses = null;
		try
		{
			IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
			if (addressList != null)
			{
				for (int addressIndex = 0; addressIndex <= addressList.Length; addressIndex++)
				{
					if (addressList[addressIndex].AddressFamily == AddressFamily.InterNetwork && (!addressList[addressIndex].ToString().Contains(":") & !addressList.ToString().Contains("%")))
					{
						if (ipv4Addresses == null)
						{
							ipv4Addresses = new string[1] { addressList[addressIndex].ToString() };
						}
						else
						{
							Array.Resize(ref ipv4Addresses, ipv4Addresses.Length + 1);
							ipv4Addresses[ipv4Addresses.Length - 1] = addressList[addressIndex].ToString();
						}
					}
				}
			}
		}
		catch
		{
		}
		return ipv4Addresses;
	}

	private static string PadLeftWithZeros(string value, int minWidth = 2)
	{
		if (value == null)
		{
			value = string.Empty;
		}
		while (value.Length < minWidth)
		{
			value = "0" + value;
		}
		return value;
	}

	public static string GetTimestamp()
	{
		DateTime now = DateTime.Now;
		string hourText = PadLeftWithZeros(now.Hour.ToString());
		string minuteText = PadLeftWithZeros(now.Minute.ToString());
		string secondText = PadLeftWithZeros(now.Second.ToString());
		return hourText + ":" + minuteText + ":" + secondText;
	}

	private static string GetMessageField(string[] fields, int fieldIndex, int fieldCount = 0)
	{
		if ((fieldCount <= 0 || fieldCount > fieldIndex) && fields != null && fields.Length > fieldIndex)
		{
			string fieldValue = fields[fieldIndex];
			if (fieldValue == null)
			{
				fieldValue = string.Empty;
			}
			return fields[fieldIndex];
		}
		return string.Empty;
	}

	public static void ApplySyncMessage(string syncMessage)
	{
		Form1.manualAuxiliaryMachineModeEnabled = 0;
		Form1.remoteAuxiliarySyncModeEnabled = 1;
		if (LicenseRuntimeCoordinator.networkTimeTicks != 0L && !AuxiliaryMachineManager.auxiliaryMachineActive)
		{
			if (syncMessage == null || syncMessage == string.Empty)
			{
				return;
			}
			try
			{
				if (syncMessage[0] == 'U' && syncMessage[1] == 'P' && syncMessage[2] == ':')
				{
					string combatPayloadHex = syncMessage.Substring(3);
					int combatPayloadLength = combatPayloadHex.Length;
					if (combatPayloadLength % 2 > 0)
					{
						combatPayloadHex = combatPayloadHex.Substring(0, combatPayloadLength - 1);
					}
					AuxiliaryMachineManager.ApplyCombatTargetSyncPayload(combatPayloadHex);
					combatTargetSyncPayloadReceived = true;
					return;
				}
				if (combatTargetSyncPayloadReceived)
				{
					combatTargetSyncPayloadReceived = false;
					Form1.combatFilterSyncPending = true;
				}
				int messageStartIndex;
				int messageEndIndex;
				while (true)
				{
					messageStartIndex = syncMessage.IndexOf('@');
					messageEndIndex = syncMessage.IndexOf('*');
					if (messageEndIndex >= messageStartIndex)
					{
						break;
					}
					syncMessage = syncMessage.Substring(messageStartIndex);
				}
				if (messageStartIndex < 0 || messageEndIndex < 0)
				{
					return;
				}
				string framedMessage = syncMessage.Substring(messageStartIndex, messageEndIndex + 1);
				string[] fields = framedMessage.Split('|');
				int fieldCount = fields.Length;
				if (fieldCount < 44)
				{
					return;
				}
				if (CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates == null)
				{
					CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates = new uint[2];
				}
				if (CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_11 == null)
				{
					CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_11 = new int[4];
				}
				Form1.mainAccountSelfControlsCongThanhChienEnabled = 0;
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 1, fieldCount));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.fightState = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 2, fieldCount));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates[0] = CommonUtility.ParseUInt32OrZero(GetMessageField(fields, 3, fieldCount));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates[1] = CommonUtility.ParseUInt32OrZero(GetMessageField(fields, 4, fieldCount));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.entityExistsFlag = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 5, fieldCount));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.currentTargetEntityId = CommonUtility.ParseUInt32OrZero(GetMessageField(fields, 6, fieldCount));
				Form1.chienLongDongCombatEnabled = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 7, fieldCount));
				Form1.pkModeIndex = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 8, fieldCount));
				Form1.primaryBattlefieldIndex = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 9, fieldCount));
				Form1.secondaryBattlefieldIndex = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 10, fieldCount));
				ChienLongDongNavigationHelper.int_0 = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 11, fieldCount));
				Form1.findMainAccountInCityEnabled = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 12, fieldCount));
				Form1.attackPlayersEnabled = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 13, fieldCount));
				Form1.attackMonstersEnabled = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 14, fieldCount));
				Form1.prioritizeBossTargetsEnabled = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 15, fieldCount));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_10 = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 16, fieldCount));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.killerStatus = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 17, fieldCount));
				Form1.congThanhChienModeIndex = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 18, fieldCount));
				Form1.mainAccountLeavesRearCampEnabled = 1;
				Form1.auxiliaryAccountsWaitForMainAccountEnabled = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 20, fieldCount));
				FormDame.combinedDamageEnabled = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 21, fieldCount));
				FormDame.attackInputModeIndex = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 22, fieldCount));
				FormDame.autoSwitchToNormalAttackEnabled = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 23, fieldCount));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.packedMousePosition = CommonUtility.ParseUInt32OrZero(GetMessageField(fields, 24, fieldCount));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.lastVirtualKeyCode = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 25, fieldCount));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.currentTargetEntityId = CommonUtility.ParseUInt32OrZero(GetMessageField(fields, 26, fieldCount));
				Form1.shareTargetEnabled = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 27, fieldCount));
				Form1.autoFindTargetEnabled = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 28, fieldCount));
				Form1.findMainAccountEnabled = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 29, fieldCount));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.pendingSyncCommandCode = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 30, fieldCount));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.entityId = CommonUtility.ParseUInt32OrZero(GetMessageField(fields, 31, fieldCount));
				Form1.scoutModeEnabled = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 32, fieldCount));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.spaceKeyPressedFlag = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 33, fieldCount));
				CharacterStateSyncCoordinator.characterSyncSnapshot_0.spaceKeyPressedFlag = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 34, fieldCount));
				Form1.int_48[0] = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 35, fieldCount));
				Form1.int_48[1] = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 36, fieldCount));
				Form1.selectedGameProfileIndex = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 37, fieldCount));
				MapNavigationProfileProvider.int_1 = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 38, fieldCount));
				Form1.congThanhChienTownPortalEnabled = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 39, fieldCount));
				Form1.congThanhChienTownPortalMenuIndices = GetMessageField(fields, 40, fieldCount);
				Form1.syncPkModeWithMainAccountEnabled = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 41, fieldCount));
				Form1.allAccountsGoToCoordinateEnabled = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 42, fieldCount));
				Form1.gatheringPointEnabled = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 43, fieldCount));
				if (fieldCount <= 44)
				{
					return;
				}
				int sharedSlotFlagValue = CommonUtility.ParseInt32OrZero(GetMessageField(fields, 44, fieldCount));
				if (sharedSlotFlagValue <= 0 || Form1.characterAccountConfig_1 == null)
				{
					return;
				}
				for (int accountIndex = 0; accountIndex < Form1.characterAccountConfig_1.Length; accountIndex++)
				{
					if (sharedSlotFlagValue == 1 && Form1.characterAccountConfig_1[accountIndex].bool_25)
					{
						GameProcessInteractionHelper.WriteSharedSlotInt32(Form1.characterAccountConfig_1[accountIndex], GameProcessInteractionHelper.uint_22, 1, 4);
					}
					else
					{
						GameProcessInteractionHelper.WriteSharedSlotInt32(Form1.characterAccountConfig_1[accountIndex], GameProcessInteractionHelper.uint_22, 0, 4);
					}
				}
				return;
			}
			catch
			{
				return;
			}
		}
		CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId = 0;
		CharacterStateSyncCoordinator.characterSyncSnapshot_1.accountId = 0;
		CharacterStateSyncCoordinator.characterSyncSnapshot_1.entityExistsFlag = 0;
	}

	public static string BuildSyncMessage()
	{
		Form1.remoteAuxiliarySyncModeEnabled = 0;
		uint coordinateX = 0u;
		uint coordinateY = 0u;
		int mapId = CharacterStateSyncCoordinator.characterSyncSnapshot_0.mapId;
		if (CharacterStateSyncCoordinator.characterSyncSnapshot_0.coordinates != null)
		{
			coordinateX = CharacterStateSyncCoordinator.characterSyncSnapshot_0.coordinates[0];
			coordinateY = CharacterStateSyncCoordinator.characterSyncSnapshot_0.coordinates[1];
		}
		if (coordinateX != 0 && coordinateY != 0 && mapId > 0)
		{
			string battlefieldSyncValueText = "0";
			if (TongKimBattlefieldHelper.int_0 > 0)
			{
				if (CommonUtility.GetElapsedMilliseconds(TongKimBattlefieldHelper.long_0) < 1500L)
				{
					battlefieldSyncValueText = TongKimBattlefieldHelper.int_0.ToString();
				}
				else
				{
					TongKimBattlefieldHelper.int_0 = 0;
				}
			}
			string syncMessage = "@|" + mapId + "|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.fightState + "|" + coordinateX + "|" + coordinateY + "|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.entityExistsFlag + "|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.currentTargetEntityId + "|" + Form1.chienLongDongCombatEnabled + "|" + Form1.pkModeIndex + "|" + Form1.primaryBattlefieldIndex + "|" + Form1.secondaryBattlefieldIndex + "|" + ChienLongDongNavigationHelper.int_0 + "|" + Form1.findMainAccountInCityEnabled + "|" + Form1.attackPlayersEnabled + "|" + Form1.attackMonstersEnabled + "|" + Form1.prioritizeBossTargetsEnabled + "|" + Form1.defenderFactionEnabled + "|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.killerStatus + "|" + Form1.congThanhChienModeIndex + "|" + Form1.mainAccountLeavesRearCampEnabled + "|" + Form1.auxiliaryAccountsWaitForMainAccountEnabled + "|" + FormDame.combinedDamageEnabled + "|" + FormDame.attackInputModeIndex + "|" + FormDame.autoSwitchToNormalAttackEnabled + "|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.packedMousePosition + "|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.lastVirtualKeyCode + "|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.currentTargetEntityId + "|" + Form1.shareTargetEnabled + "|" + Form1.autoFindTargetEnabled + "|" + Form1.findMainAccountEnabled + "|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.pendingSyncCommandCode + "|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.entityId + "|" + Form1.scoutModeEnabled + "|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.spaceKeyPressedFlag + "|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.spaceKeyPressedFlag + "|" + Form1.int_48[0] + "|" + Form1.int_48[1] + "|" + Form1.selectedGameProfileIndex + "|" + MapNavigationProfileProvider.int_1 + "|" + Form1.congThanhChienTownPortalEnabled + "|" + Form1.congThanhChienTownPortalMenuIndices.Replace(" ", "").Replace(",", "_") + "|" + Form1.syncPkModeWithMainAccountEnabled + "|" + Form1.allAccountsGoToCoordinateEnabled + "|" + Form1.gatheringPointEnabled + "|" + battlefieldSyncValueText + "|*";
			CharacterStateSyncCoordinator.characterSyncSnapshot_0.pendingSyncCommandCode = 0;
			return syncMessage;
		}
		return string.Empty;
	}
}
