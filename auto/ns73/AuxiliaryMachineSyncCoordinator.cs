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
		string[] array = null;
		try
		{
			IPAddress[] addressList = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
			if (addressList != null)
			{
				for (int i = 0; i <= addressList.Length; i++)
				{
					if (addressList[i].AddressFamily == AddressFamily.InterNetwork && (!addressList[i].ToString().Contains(":") & !addressList.ToString().Contains("%")))
					{
						if (array == null)
						{
							array = new string[1] { addressList[i].ToString() };
						}
						else
						{
							Array.Resize(ref array, array.Length + 1);
							array[array.Length - 1] = addressList[i].ToString();
						}
					}
				}
			}
		}
		catch
		{
		}
		return array;
	}

	private static string PadLeftWithZeros(string string_3, int int_4 = 2)
	{
		if (string_3 == null)
		{
			string_3 = string.Empty;
		}
		while (string_3.Length < int_4)
		{
			string_3 = "0" + string_3;
		}
		return string_3;
	}

	public static string GetTimestamp()
	{
		DateTime now = DateTime.Now;
		string text = PadLeftWithZeros(now.Hour.ToString());
		string text2 = PadLeftWithZeros(now.Minute.ToString());
		string text3 = PadLeftWithZeros(now.Second.ToString());
		return text + ":" + text2 + ":" + text3;
	}

	private static string GetMessageField(string[] string_3, int int_4, int int_5 = 0)
	{
		if ((int_5 <= 0 || int_5 > int_4) && string_3 != null && string_3.Length > int_4)
		{
			string text = string_3[int_4];
			if (text == null)
			{
				text = string.Empty;
			}
			return string_3[int_4];
		}
		return string.Empty;
	}

	public static void ApplySyncMessage(string string_3)
	{
		Form1.manualAuxiliaryMachineModeEnabled = 0;
		Form1.remoteAuxiliarySyncModeEnabled = 1;
		if (LicenseRuntimeCoordinator.networkTimeTicks != 0L && !AuxiliaryMachineManager.auxiliaryMachineActive)
		{
			if (string_3 == null || string_3 == string.Empty)
			{
				return;
			}
			try
			{
				if (string_3[0] == 'U' && string_3[1] == 'P' && string_3[2] == ':')
				{
					string text = string_3.Substring(3);
					int length = text.Length;
					if (length % 2 > 0)
					{
						text = text.Substring(0, length - 1);
					}
					AuxiliaryMachineManager.ApplyCombatTargetSyncPayload(text);
					combatTargetSyncPayloadReceived = true;
					return;
				}
				if (combatTargetSyncPayloadReceived)
				{
					combatTargetSyncPayloadReceived = false;
					Form1.combatFilterSyncPending = true;
				}
				int num;
				int num2;
				while (true)
				{
					num = string_3.IndexOf('@');
					num2 = string_3.IndexOf('*');
					if (num2 >= num)
					{
						break;
					}
					string_3 = string_3.Substring(num);
				}
				if (num < 0 || num2 < 0)
				{
					return;
				}
				string text2 = string_3.Substring(num, num2 + 1);
				string[] array = text2.Split('|');
				int num3 = array.Length;
				if (num3 < 44)
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
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId = CommonUtility.ParseInt32OrZero(GetMessageField(array, 1, num3));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.fightState = CommonUtility.ParseInt32OrZero(GetMessageField(array, 2, num3));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates[0] = CommonUtility.ParseUInt32OrZero(GetMessageField(array, 3, num3));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates[1] = CommonUtility.ParseUInt32OrZero(GetMessageField(array, 4, num3));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.entityExistsFlag = CommonUtility.ParseInt32OrZero(GetMessageField(array, 5, num3));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.currentTargetEntityId = CommonUtility.ParseUInt32OrZero(GetMessageField(array, 6, num3));
				Form1.chienLongDongCombatEnabled = CommonUtility.ParseInt32OrZero(GetMessageField(array, 7, num3));
				Form1.pkModeIndex = CommonUtility.ParseInt32OrZero(GetMessageField(array, 8, num3));
				Form1.primaryBattlefieldIndex = CommonUtility.ParseInt32OrZero(GetMessageField(array, 9, num3));
				Form1.secondaryBattlefieldIndex = CommonUtility.ParseInt32OrZero(GetMessageField(array, 10, num3));
				ChienLongDongNavigationHelper.int_0 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 11, num3));
				Form1.findMainAccountInCityEnabled = CommonUtility.ParseInt32OrZero(GetMessageField(array, 12, num3));
				Form1.attackPlayersEnabled = CommonUtility.ParseInt32OrZero(GetMessageField(array, 13, num3));
				Form1.attackMonstersEnabled = CommonUtility.ParseInt32OrZero(GetMessageField(array, 14, num3));
				Form1.prioritizeBossTargetsEnabled = CommonUtility.ParseInt32OrZero(GetMessageField(array, 15, num3));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_10 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 16, num3));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.killerStatus = CommonUtility.ParseInt32OrZero(GetMessageField(array, 17, num3));
				Form1.congThanhChienModeIndex = CommonUtility.ParseInt32OrZero(GetMessageField(array, 18, num3));
				Form1.mainAccountLeavesRearCampEnabled = 1;
				Form1.auxiliaryAccountsWaitForMainAccountEnabled = CommonUtility.ParseInt32OrZero(GetMessageField(array, 20, num3));
				FormDame.combinedDamageEnabled = CommonUtility.ParseInt32OrZero(GetMessageField(array, 21, num3));
				FormDame.attackInputModeIndex = CommonUtility.ParseInt32OrZero(GetMessageField(array, 22, num3));
				FormDame.autoSwitchToNormalAttackEnabled = CommonUtility.ParseInt32OrZero(GetMessageField(array, 23, num3));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.packedMousePosition = CommonUtility.ParseUInt32OrZero(GetMessageField(array, 24, num3));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.lastVirtualKeyCode = CommonUtility.ParseInt32OrZero(GetMessageField(array, 25, num3));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.currentTargetEntityId = CommonUtility.ParseUInt32OrZero(GetMessageField(array, 26, num3));
				Form1.shareTargetEnabled = CommonUtility.ParseInt32OrZero(GetMessageField(array, 27, num3));
				Form1.autoFindTargetEnabled = CommonUtility.ParseInt32OrZero(GetMessageField(array, 28, num3));
				Form1.findMainAccountEnabled = CommonUtility.ParseInt32OrZero(GetMessageField(array, 29, num3));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.pendingSyncCommandCode = CommonUtility.ParseInt32OrZero(GetMessageField(array, 30, num3));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.entityId = CommonUtility.ParseUInt32OrZero(GetMessageField(array, 31, num3));
				Form1.scoutModeEnabled = CommonUtility.ParseInt32OrZero(GetMessageField(array, 32, num3));
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.spaceKeyPressedFlag = CommonUtility.ParseInt32OrZero(GetMessageField(array, 33, num3));
				CharacterStateSyncCoordinator.characterSyncSnapshot_0.spaceKeyPressedFlag = CommonUtility.ParseInt32OrZero(GetMessageField(array, 34, num3));
				Form1.int_48[0] = CommonUtility.ParseInt32OrZero(GetMessageField(array, 35, num3));
				Form1.int_48[1] = CommonUtility.ParseInt32OrZero(GetMessageField(array, 36, num3));
				Form1.selectedGameProfileIndex = CommonUtility.ParseInt32OrZero(GetMessageField(array, 37, num3));
				MapNavigationProfileProvider.int_1 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 38, num3));
				Form1.congThanhChienTownPortalEnabled = CommonUtility.ParseInt32OrZero(GetMessageField(array, 39, num3));
				Form1.congThanhChienTownPortalMenuIndices = GetMessageField(array, 40, num3);
				Form1.syncPkModeWithMainAccountEnabled = CommonUtility.ParseInt32OrZero(GetMessageField(array, 41, num3));
				Form1.allAccountsGoToCoordinateEnabled = CommonUtility.ParseInt32OrZero(GetMessageField(array, 42, num3));
				Form1.gatheringPointEnabled = CommonUtility.ParseInt32OrZero(GetMessageField(array, 43, num3));
				if (num3 <= 44)
				{
					return;
				}
				int num4 = CommonUtility.ParseInt32OrZero(GetMessageField(array, 44, num3));
				if (num4 <= 0 || Form1.characterAccountConfig_1 == null)
				{
					return;
				}
				for (int i = 0; i < Form1.characterAccountConfig_1.Length; i++)
				{
					if (num4 == 1 && Form1.characterAccountConfig_1[i].bool_25)
					{
						GameProcessInteractionHelper.WriteSharedSlotInt32(Form1.characterAccountConfig_1[i], GameProcessInteractionHelper.uint_22, 1, 4);
					}
					else
					{
						GameProcessInteractionHelper.WriteSharedSlotInt32(Form1.characterAccountConfig_1[i], GameProcessInteractionHelper.uint_22, 0, 4);
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
		uint num = 0u;
		uint num2 = 0u;
		int int_ = CharacterStateSyncCoordinator.characterSyncSnapshot_0.mapId;
		if (CharacterStateSyncCoordinator.characterSyncSnapshot_0.coordinates != null)
		{
			num = CharacterStateSyncCoordinator.characterSyncSnapshot_0.coordinates[0];
			num2 = CharacterStateSyncCoordinator.characterSyncSnapshot_0.coordinates[1];
		}
		if (num != 0 && num2 != 0 && int_ > 0)
		{
			string text = "0";
			if (TongKimBattlefieldHelper.int_0 > 0)
			{
				if (CommonUtility.GetElapsedMilliseconds(TongKimBattlefieldHelper.long_0) < 1500L)
				{
					text = TongKimBattlefieldHelper.int_0.ToString();
				}
				else
				{
					TongKimBattlefieldHelper.int_0 = 0;
				}
			}
			string result = "@|" + int_ + "|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.fightState + "|" + num + "|" + num2 + "|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.entityExistsFlag + "|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.currentTargetEntityId + "|" + Form1.chienLongDongCombatEnabled + "|" + Form1.pkModeIndex + "|" + Form1.primaryBattlefieldIndex + "|" + Form1.secondaryBattlefieldIndex + "|" + ChienLongDongNavigationHelper.int_0 + "|" + Form1.findMainAccountInCityEnabled + "|" + Form1.attackPlayersEnabled + "|" + Form1.attackMonstersEnabled + "|" + Form1.prioritizeBossTargetsEnabled + "|" + Form1.defenderFactionEnabled + "|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.killerStatus + "|" + Form1.congThanhChienModeIndex + "|" + Form1.mainAccountLeavesRearCampEnabled + "|" + Form1.auxiliaryAccountsWaitForMainAccountEnabled + "|" + FormDame.combinedDamageEnabled + "|" + FormDame.attackInputModeIndex + "|" + FormDame.autoSwitchToNormalAttackEnabled + "|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.packedMousePosition + "|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.lastVirtualKeyCode + "|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.currentTargetEntityId + "|" + Form1.shareTargetEnabled + "|" + Form1.autoFindTargetEnabled + "|" + Form1.findMainAccountEnabled + "|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.pendingSyncCommandCode + "|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.entityId + "|" + Form1.scoutModeEnabled + "|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.spaceKeyPressedFlag + "|" + CharacterStateSyncCoordinator.characterSyncSnapshot_0.spaceKeyPressedFlag + "|" + Form1.int_48[0] + "|" + Form1.int_48[1] + "|" + Form1.selectedGameProfileIndex + "|" + MapNavigationProfileProvider.int_1 + "|" + Form1.congThanhChienTownPortalEnabled + "|" + Form1.congThanhChienTownPortalMenuIndices.Replace(" ", "").Replace(",", "_") + "|" + Form1.syncPkModeWithMainAccountEnabled + "|" + Form1.allAccountsGoToCoordinateEnabled + "|" + Form1.gatheringPointEnabled + "|" + text + "|*";
			CharacterStateSyncCoordinator.characterSyncSnapshot_0.pendingSyncCommandCode = 0;
			return result;
		}
		return string.Empty;
	}
}
