using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using ns1;
using ns100;
using ns109;
using ns11;
using ns13;
using ns146;
using ns19;
using ns23;
using ns28;
using ns3;
using ns34;
using ns40;
using ns41;
using ns42;
using ns43;
using ns50;
using ns53;
using ns56;
using ns6;
using ns61;
using ns63;
using ns65;
using ns68;
using ns71;
using ns83;
using ns85;
using ns86;
using ns88;
using ns94;

namespace ns121;

public class AuxiliaryMachineManager : Form
{
	public static int pendingSyncCharacterId = 0;

	public static bool isManagerFormOpen = false;

	public static string[] auxiliaryAccountNames = null;

	public static bool auxiliaryMachineActive = false;

	public static int[] auxiliaryLicenseExpirationDateParts = null;

	public static string multiMachineRestrictionLabel = null;

	public static string remoteGameScript = null;

	public static bool bool_2 = false;

	public static bool followMainAccountRestricted = false;

	public static bool guildTargetExclusionRestricted = false;

	public static bool automaticGuildColorChangeRestricted = false;

	public static bool bool_6 = false;

	public static bool bool_7 = false;

	public static string syncFieldDelimiter = WindowsRegistryHelper.ReadApplicationRegistryString("SMayphu", 0, "|");

	public static int coordinateReportDelayMilliseconds = WindowsRegistryHelper.ReadApplicationRegistryInt32("TocdoBaoToado", 0, "100");

	public int anchorCursorX = 0;

	public int anchorCursorY = 0;

	public int int_5;

	public int int_6;

	public static bool combatTargetSyncBroadcastPending = false;

	public static long combatTargetSyncBroadcastStartTicks = 0L;

	public static long combatTargetSyncBroadcastDurationMilliseconds = 4000L;

	private static bool combatTargetSyncUpdateReceived = false;

	private string[] auxiliaryAccountNameCandidates = null;

	private IContainer icontainer_0 = null;

	private ListView listView1;

	private ColumnHeader columnHeader_0;

	private ColumnHeader columnHeader_1;

	private ComboBox comboBoxThemAcc;

	private Button buttonThemAcc;

	private Button buttonXoaAcc;

	private System.Windows.Forms.Timer timer_0;

	private Label label1;

	private Button buttonClose;

	public AuxiliaryMachineManager()
	{
		isManagerFormOpen = true;
		InitializeComponent();
		base.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
	}

	public static string BuildCombatTargetSyncPayload()
	{
		string targetGroup1Text = string.Empty;
		string targetGroup2Text = string.Empty;
		string targetGroup3Text = string.Empty;
		if (CombatTargetSelectionHelper.string_4 != null)
		{
			for (int i = 0; i < CombatTargetSelectionHelper.string_4.Length; i++)
			{
				if (CombatTargetSelectionHelper.string_4[i] != null && !(CombatTargetSelectionHelper.string_4[i] == string.Empty))
				{
					if (targetGroup1Text != string.Empty)
					{
						targetGroup1Text += ";";
					}
					targetGroup1Text += CombatTargetSelectionHelper.string_4[i];
				}
			}
		}
		if (CombatTargetSelectionHelper.string_3 != null)
		{
			for (int j = 0; j < CombatTargetSelectionHelper.string_3.Length; j++)
			{
				if (CombatTargetSelectionHelper.string_3[j] != null && !(CombatTargetSelectionHelper.string_3[j] == string.Empty))
				{
					if (targetGroup2Text != string.Empty)
					{
						targetGroup2Text += ";";
					}
					targetGroup2Text += CombatTargetSelectionHelper.string_3[j];
				}
			}
		}
		if (CombatTargetSelectionHelper.string_5 != null)
		{
			for (int k = 0; k < CombatTargetSelectionHelper.string_5.Length; k++)
			{
				if (CombatTargetSelectionHelper.string_5[k] != null && !(CombatTargetSelectionHelper.string_5[k] == string.Empty))
				{
					if (targetGroup3Text != string.Empty)
					{
						targetGroup3Text += ";";
					}
					targetGroup3Text += CombatTargetSelectionHelper.string_5[k];
				}
			}
		}
		string payloadText = CombatTargetSelectionHelper.alwaysAttackGuildTargetsEnabled + "|" + CombatTargetSelectionHelper.int_2 + "|" + CombatTargetSelectionHelper.int_3 + "|" + targetGroup1Text + "|" + targetGroup2Text + "|" + targetGroup3Text;
		return CommonUtility.EncodeUnicodeStringAsHex(payloadText);
	}

	public static void ApplyCombatTargetSyncPayload(string payloadHex)
	{
		string decodedPayloadText = CommonUtility.DecodeUnicodeHexString(payloadHex);
		string[] payloadFields = decodedPayloadText.Split('|');
		if (payloadFields.Length < 3)
		{
			return;
		}
		CombatTargetSelectionHelper.alwaysAttackGuildTargetsEnabled = CommonUtility.ParseInt32OrZero(payloadFields[0]);
		CombatTargetSelectionHelper.int_2 = CommonUtility.ParseInt32OrZero(payloadFields[1]);
		CombatTargetSelectionHelper.int_3 = CommonUtility.ParseInt32OrZero(payloadFields[2]);
		if (payloadFields.Length > 3)
		{
			CombatTargetSelectionHelper.string_4 = null;
			if (payloadFields[3] != null && payloadFields[3] != string.Empty)
			{
				CombatTargetSelectionHelper.string_4 = payloadFields[3].Split(';');
			}
		}
		if (payloadFields.Length > 4)
		{
			CombatTargetSelectionHelper.string_3 = null;
			if (payloadFields[4] != null && payloadFields[4] != string.Empty)
			{
				CombatTargetSelectionHelper.string_3 = payloadFields[4].Split(';');
			}
		}
		if (payloadFields.Length > 5)
		{
			CombatTargetSelectionHelper.string_5 = null;
			if (payloadFields[5] != null && payloadFields[5] != string.Empty)
			{
				CombatTargetSelectionHelper.string_5 = payloadFields[5].Split(';');
			}
		}
		CombatTargetSelectionHelper.uint_1 = CombatTargetSelectionHelper.ComputeNameHashes(CombatTargetSelectionHelper.string_4);
		CombatTargetSelectionHelper.uint_0 = CombatTargetSelectionHelper.ComputeNameHashes(CombatTargetSelectionHelper.string_3);
	}

	private static string TransformAuxiliarySyncText(string syncText, int transformKey, bool decode = false)
	{
		if (syncText != null && !(syncText == string.Empty))
		{
			if (transformKey > 0)
			{
				string transformedText;
				if (!decode)
				{
					if (transformKey > 9)
					{
						syncText = CommonUtility.CompressUtf8DeflateToBase64(syncText);
						if (syncText != null && syncText != string.Empty)
						{
							transformedText = string.Empty;
							for (int i = 0; i < syncText.Length; i++)
							{
								char transformedChar = syncText[i];
								if (transformedChar >= '\u0080')
								{
									if (transformedChar > '\u0080')
									{
										transformedChar = (char)(transformedChar - 128);
									}
								}
								else
								{
									transformedChar = (char)(transformedChar + 128);
								}
								transformedText += transformedChar;
							}
							syncText = transformedText;
						}
						return syncText;
					}
					transformedText = string.Empty;
					for (int j = 0; j < syncText.Length; j++)
					{
						transformedText += (char)(syncText[j] + transformKey + j % 10);
					}
					return transformedText;
				}
				if (transformKey > 9)
				{
					string restoredText = string.Empty;
					for (int k = 0; k < syncText.Length; k++)
					{
						char restoredChar = syncText[k];
						if (restoredChar < '\u0080')
						{
							restoredChar = (char)(restoredChar + 128);
						}
						else if (restoredChar > '\u0080')
						{
							restoredChar = (char)(restoredChar - 128);
						}
						restoredText += restoredChar;
					}
					syncText = CommonUtility.DecompressBase64DeflateUtf8(restoredText);
					return syncText;
				}
				transformedText = string.Empty;
				for (int l = 0; l < syncText.Length; l++)
				{
					transformedText += (char)(syncText[l] - transformKey - l % 10);
				}
				return transformedText;
			}
			return syncText;
		}
		return string.Empty;
	}

	public static void RunAuxiliarySyncSenderWithRetry()
	{
		int characterIdToSync = pendingSyncCharacterId;
		pendingSyncCharacterId = 0;
		while (true)
		{
			try
			{
				RunAuxiliarySyncSenderForCharacterId(characterIdToSync);
				break;
			}
			catch
			{
				Thread.Sleep(100);
			}
		}
	}

	public static void RunAuxiliarySyncSenderForCharacterId(int characterId)
	{
		int bytesTransferred = 0;
		int accountRefreshCountdown = 0;
		int recipientIndex = 0;
		int accountIndex = 0;
		int accountStateCode = -1000;
		long lastRoomChannelSendTicks = 0L;
		byte[] readBuffer = new byte[4];
		string combatTargetBroadcastMessage = null;
		string outgoingSyncText = string.Empty;
		CharacterAccountConfig accountConfig = default(CharacterAccountConfig);
		while (true)
		{
			accountRefreshCountdown--;
			Thread.Sleep(100);
			if (CommonUtility.bool_0)
			{
				break;
			}
			if (accountRefreshCountdown <= 0)
			{
				accountIndex = CharacterAccountListHelper.FindAccountIndexById(Form1.characterAccountConfig_1, characterId);
				if (accountIndex < 0)
				{
					break;
				}
				accountRefreshCountdown = 30;
				GameInterfaceMemoryHelper.smethod_41(accountConfig, Form1.lockPrivateChatEnabled > 0);
			}
			accountConfig = Form1.characterAccountConfig_1[accountIndex];
			if (accountStateCode == -1000)
			{
				accountStateCode = LicenseRuntimeCoordinator.GetAccountStateCodeSafe(accountConfig);
			}
			if (accountConfig.int_2 > 0 && accountStateCode > 0)
			{
				WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, readBuffer, 4, ref bytesTransferred);
				uint syncRootPointer = BitConverter.ToUInt32(readBuffer, 0);
				WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, syncRootPointer + GameConfigurationManager.memorySignatureScanConfig_13.resolvedValue, readBuffer, 4, ref bytesTransferred);
				uint syncEntryIndex = BitConverter.ToUInt32(readBuffer, 0);
				uint syncEntryOffset = syncEntryIndex * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
				WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, readBuffer, 4, ref bytesTransferred);
				uint syncTableBaseAddress = BitConverter.ToUInt32(readBuffer, 0);
				uint syncEntryAddress = syncTableBaseAddress + syncEntryOffset;
				WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, syncEntryAddress + GameConfigurationManager.memorySignatureScanConfig_55.resolvedValue, readBuffer, 4, ref bytesTransferred);
				int syncGuardValue1 = BitConverter.ToInt32(readBuffer, 0);
				WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, syncEntryAddress + GameConfigurationManager.memorySignatureScanConfig_50.resolvedValue, readBuffer, 4, ref bytesTransferred);
				int syncGuardValue2 = BitConverter.ToInt32(readBuffer, 0);
				WindowsInteropHelper.ReadProcessMemory(accountConfig.int_137, GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, readBuffer, 4, ref bytesTransferred);
				int syncGuardValue3 = BitConverter.ToInt32(readBuffer, 0);
				int gatewayConnectionState = GameInterfaceMemoryHelper.ReadGatewayConnectionState(accountConfig);
				if (syncGuardValue2 == 0 || syncGuardValue1 == 0 || syncGuardValue3 == 0 || gatewayConnectionState <= 1)
				{
					continue;
				}
				int multiMachinePasswordValue = 0;
				if (Form1.multiMachinePasswordEnabled > 0)
				{
					multiMachinePasswordValue = Form1.multiMachinePassword;
				}
				if (combatTargetSyncBroadcastPending)
				{
					if (combatTargetSyncBroadcastStartTicks == 0L || combatTargetBroadcastMessage == null)
					{
						combatTargetSyncBroadcastStartTicks = CommonUtility.GetCurrentTicks();
						combatTargetBroadcastMessage = "UP:" + multiMachinePasswordValue + ":" + BuildCombatTargetSyncPayload();
					}
					if (CommonUtility.GetElapsedMilliseconds(combatTargetSyncBroadcastStartTicks) < combatTargetSyncBroadcastDurationMilliseconds)
					{
						outgoingSyncText = combatTargetBroadcastMessage;
						goto IL_072c;
					}
					combatTargetSyncBroadcastPending = false;
					combatTargetSyncBroadcastStartTicks = 0L;
					combatTargetBroadcastMessage = null;
				}
				uint mainCoordinateX = 0u;
				uint mainCoordinateY = 0u;
				int mainMapId = CharacterStateSyncCoordinator.characterSyncSnapshot_0.mapId;
				if (CharacterStateSyncCoordinator.characterSyncSnapshot_0.coordinates != null)
				{
					mainCoordinateX = CharacterStateSyncCoordinator.characterSyncSnapshot_0.coordinates[0];
					mainCoordinateY = CharacterStateSyncCoordinator.characterSyncSnapshot_0.coordinates[1];
				}
				if (mainCoordinateX == 0 || mainCoordinateY == 0 || mainMapId <= 0)
				{
					continue;
				}
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
				outgoingSyncText = syncFieldDelimiter + mainMapId + syncFieldDelimiter + CharacterStateSyncCoordinator.characterSyncSnapshot_0.fightState + syncFieldDelimiter + mainCoordinateX + syncFieldDelimiter + mainCoordinateY + syncFieldDelimiter + CharacterStateSyncCoordinator.characterSyncSnapshot_0.entityExistsFlag + syncFieldDelimiter + CharacterStateSyncCoordinator.characterSyncSnapshot_0.currentTargetEntityId + syncFieldDelimiter + Form1.chienLongDongCombatEnabled + syncFieldDelimiter + Form1.pkModeIndex + syncFieldDelimiter + Form1.primaryBattlefieldIndex + syncFieldDelimiter + Form1.secondaryBattlefieldIndex + syncFieldDelimiter + ChienLongDongNavigationHelper.int_0 + syncFieldDelimiter + Form1.findMainAccountInCityEnabled + syncFieldDelimiter + Form1.attackPlayersEnabled + syncFieldDelimiter + Form1.attackMonstersEnabled + syncFieldDelimiter + Form1.prioritizeBossTargetsEnabled + syncFieldDelimiter + Form1.defenderFactionEnabled + syncFieldDelimiter + CharacterStateSyncCoordinator.characterSyncSnapshot_0.killerStatus + syncFieldDelimiter + Form1.congThanhChienModeIndex + syncFieldDelimiter + Form1.mainAccountLeavesRearCampEnabled + syncFieldDelimiter + Form1.auxiliaryAccountsWaitForMainAccountEnabled + syncFieldDelimiter + FormDame.combinedDamageEnabled + syncFieldDelimiter + FormDame.attackInputModeIndex + syncFieldDelimiter + FormDame.autoSwitchToNormalAttackEnabled + syncFieldDelimiter + CharacterStateSyncCoordinator.characterSyncSnapshot_0.packedMousePosition + syncFieldDelimiter + CharacterStateSyncCoordinator.characterSyncSnapshot_0.lastVirtualKeyCode + syncFieldDelimiter + CharacterStateSyncCoordinator.characterSyncSnapshot_0.currentTargetEntityId + syncFieldDelimiter + Form1.shareTargetEnabled + syncFieldDelimiter + Form1.autoFindTargetEnabled + syncFieldDelimiter + Form1.findMainAccountEnabled + syncFieldDelimiter + CharacterStateSyncCoordinator.characterSyncSnapshot_0.pendingSyncCommandCode + syncFieldDelimiter + CharacterStateSyncCoordinator.characterSyncSnapshot_0.entityId + syncFieldDelimiter + Form1.scoutModeEnabled + syncFieldDelimiter + CharacterStateSyncCoordinator.characterSyncSnapshot_0.spaceKeyPressedFlag + syncFieldDelimiter + multiMachinePasswordValue + syncFieldDelimiter + Form1.int_48[0] + syncFieldDelimiter + Form1.int_48[1] + syncFieldDelimiter + Form1.selectedGameProfileIndex + syncFieldDelimiter + MapNavigationProfileProvider.int_1 + syncFieldDelimiter + Form1.congThanhChienTownPortalEnabled + syncFieldDelimiter + Form1.congThanhChienTownPortalMenuIndices.Replace(" ", "").Replace(",", "_") + syncFieldDelimiter + Form1.syncPkModeWithMainAccountEnabled + syncFieldDelimiter + Form1.allAccountsGoToCoordinateEnabled + syncFieldDelimiter + Form1.gatheringPointEnabled + syncFieldDelimiter + battlefieldSyncValueText;
				goto IL_072c;
			}
			Form1.characterAccountConfig_1[accountIndex].int_2 = 0;
			break;
			IL_072c:
			string encodedSyncText = TransformAuxiliarySyncText(outgoingSyncText, Form1.coordinateEncryptionValue);
			CharacterStateSyncCoordinator.characterSyncSnapshot_0.pendingSyncCommandCode = 0;
			if (auxiliaryAccountNames != null)
			{
				int auxiliaryAccountCount = auxiliaryAccountNames.Length;
				if (recipientIndex < 0 || auxiliaryAccountCount <= recipientIndex)
				{
					recipientIndex = 0;
				}
				int recipientSearchStartIndex = recipientIndex;
				string recipientAccountName = null;
				while (recipientAccountName == null || recipientAccountName == string.Empty || recipientAccountName == accountConfig.string_22)
				{
					try
					{
						recipientAccountName = auxiliaryAccountNames[recipientIndex];
					}
					catch
					{
						break;
					}
					recipientIndex++;
					if (recipientIndex < 0 || auxiliaryAccountCount <= recipientIndex)
					{
						recipientIndex = 0;
					}
					if (recipientSearchStartIndex == recipientIndex || auxiliaryAccountNames == null || auxiliaryAccountNames.Length <= recipientSearchStartIndex)
					{
						break;
					}
				}
				if (recipientAccountName != null && recipientAccountName != string.Empty && accountConfig.string_22 != recipientAccountName)
				{
					GameProcessInteractionHelper.SendPrivatePlayerMessage(accountConfig, recipientAccountName, encodedSyncText);
					Thread.Sleep(80 + 200 / auxiliaryAccountCount + coordinateReportDelayMilliseconds);
				}
			}
			if (Form1.roomChannelAlertEnabled > 0 && CommonUtility.GetElapsedMilliseconds(lastRoomChannelSendTicks) >= 2500 + coordinateReportDelayMilliseconds)
			{
				GameProcessInteractionHelper.ExecuteGameScript(accountConfig, "Chat('CH_CHATROOM', '" + encodedSyncText + "')");
				lastRoomChannelSendTicks = CommonUtility.GetCurrentTicks();
			}
		}
		GameInterfaceMemoryHelper.smethod_41(accountConfig, bool_0: false);
	}

	public static void ProcessIncomingAuxiliarySyncText(CharacterAccountConfig accountConfig)
	{
		if (Form1.manualAuxiliaryMachineModeEnabled <= 0)
		{
			return;
		}
		if (LicenseRuntimeCoordinator.networkTimeTicks != 0L && !auxiliaryMachineActive)
		{
			string latestChannelText = GameInterfaceMemoryHelper.ReadLatestTopChannelText(accountConfig);
			if (latestChannelText != null && latestChannelText.Length >= 10)
			{
				int messageSeparatorIndex = latestChannelText.IndexOf(":");
				if (0 <= messageSeparatorIndex && latestChannelText.Length > messageSeparatorIndex)
				{
					latestChannelText = latestChannelText.Substring(messageSeparatorIndex + 1).Trim();
				}
				string decodedSyncText = TransformAuxiliarySyncText(latestChannelText, Form1.coordinateEncryptionValue, decode: true);
				if (decodedSyncText != null && !(decodedSyncText == string.Empty))
				{
					int combatUpdateMarkerIndex = decodedSyncText.IndexOf("UP:");
					if (0 <= combatUpdateMarkerIndex)
					{
						combatTargetSyncUpdateReceived = true;
						string combatUpdateSegment = decodedSyncText.Substring(combatUpdateMarkerIndex);
						string[] combatUpdateParts = combatUpdateSegment.Split(':');
						if (combatUpdateParts.Length >= 3 && combatUpdateParts[2] != null && !(combatUpdateParts[2] == string.Empty) && (Form1.multiMachinePasswordEnabled <= 0 || CommonUtility.ParseInt32OrZero(combatUpdateParts[1]) == Form1.multiMachinePassword))
						{
							string combatPayloadHex = combatUpdateParts[2];
							int combatPayloadLength = combatPayloadHex.Length;
							if (combatPayloadLength % 2 > 0)
							{
								combatPayloadHex = combatPayloadHex.Substring(0, combatPayloadLength - 1);
							}
							ApplyCombatTargetSyncPayload(combatPayloadHex);
							return;
						}
					}
					else
					{
						if (combatTargetSyncUpdateReceived)
						{
							Form1.combatFilterSyncPending = true;
							combatTargetSyncUpdateReceived = false;
						}
						if (syncFieldDelimiter == null || syncFieldDelimiter == string.Empty)
						{
							syncFieldDelimiter = "|";
						}
						string[] syncFields = decodedSyncText.Split(syncFieldDelimiter[0]);
						int syncFieldCount = syncFields.Length;
						if (syncFieldCount >= 43)
						{
							try
							{
								if (Form1.multiMachinePasswordEnabled <= 0 || CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 34, syncFieldCount)) == Form1.multiMachinePassword)
								{
									if (CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates == null)
									{
										CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates = new uint[2];
									}
									Form1.mainAccountSelfControlsCongThanhChienEnabled = 0;
									CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 1, syncFieldCount));
									CharacterStateSyncCoordinator.characterSyncSnapshot_1.fightState = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 2, syncFieldCount));
									CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates[0] = CommonUtility.ParseUInt32OrZero(GetSyncFieldOrEmpty(syncFields, 3, syncFieldCount));
									CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates[1] = CommonUtility.ParseUInt32OrZero(GetSyncFieldOrEmpty(syncFields, 4, syncFieldCount));
									CharacterStateSyncCoordinator.characterSyncSnapshot_1.entityExistsFlag = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 5, syncFieldCount));
									CharacterStateSyncCoordinator.characterSyncSnapshot_1.currentTargetEntityId = CommonUtility.ParseUInt32OrZero(GetSyncFieldOrEmpty(syncFields, 6, syncFieldCount));
									Form1.chienLongDongCombatEnabled = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 7, syncFieldCount));
									Form1.pkModeIndex = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 8, syncFieldCount));
									Form1.primaryBattlefieldIndex = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 9, syncFieldCount));
									Form1.secondaryBattlefieldIndex = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 10, syncFieldCount));
									ChienLongDongNavigationHelper.int_0 = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 11, syncFieldCount));
									Form1.findMainAccountInCityEnabled = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 12, syncFieldCount));
									Form1.attackPlayersEnabled = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 13, syncFieldCount));
									Form1.attackMonstersEnabled = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 14, syncFieldCount));
									Form1.prioritizeBossTargetsEnabled = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 15, syncFieldCount));
									CharacterStateSyncCoordinator.characterSyncSnapshot_1.int_10 = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 16, syncFieldCount));
									CharacterStateSyncCoordinator.characterSyncSnapshot_1.killerStatus = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 17, syncFieldCount));
									Form1.congThanhChienModeIndex = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 18, syncFieldCount));
									Form1.mainAccountLeavesRearCampEnabled = 1;
									Form1.auxiliaryAccountsWaitForMainAccountEnabled = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 20, syncFieldCount));
									FormDame.combinedDamageEnabled = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 21, syncFieldCount));
									FormDame.attackInputModeIndex = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 22, syncFieldCount));
									FormDame.autoSwitchToNormalAttackEnabled = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 23, syncFieldCount));
									CharacterStateSyncCoordinator.characterSyncSnapshot_1.packedMousePosition = CommonUtility.ParseUInt32OrZero(GetSyncFieldOrEmpty(syncFields, 24, syncFieldCount));
									CharacterStateSyncCoordinator.characterSyncSnapshot_1.lastVirtualKeyCode = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 25, syncFieldCount));
									CharacterStateSyncCoordinator.characterSyncSnapshot_1.currentTargetEntityId = CommonUtility.ParseUInt32OrZero(GetSyncFieldOrEmpty(syncFields, 26, syncFieldCount));
									Form1.shareTargetEnabled = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 27, syncFieldCount));
									Form1.autoFindTargetEnabled = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 28, syncFieldCount));
									Form1.findMainAccountEnabled = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 29, syncFieldCount));
									CharacterStateSyncCoordinator.characterSyncSnapshot_1.pendingSyncCommandCode = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 30, syncFieldCount));
									CharacterStateSyncCoordinator.characterSyncSnapshot_1.entityId = CommonUtility.ParseUInt32OrZero(GetSyncFieldOrEmpty(syncFields, 31, syncFieldCount));
									Form1.scoutModeEnabled = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 32, syncFieldCount));
									CharacterStateSyncCoordinator.characterSyncSnapshot_1.spaceKeyPressedFlag = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 33, syncFieldCount));
									CharacterStateSyncCoordinator.characterSyncSnapshot_0.spaceKeyPressedFlag = CharacterStateSyncCoordinator.characterSyncSnapshot_1.spaceKeyPressedFlag;
									Form1.int_48[0] = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 35, syncFieldCount));
									Form1.int_48[1] = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 36, syncFieldCount));
									Form1.selectedGameProfileIndex = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 37, syncFieldCount));
									MapNavigationProfileProvider.int_1 = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 38, syncFieldCount));
									Form1.congThanhChienTownPortalEnabled = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 39, syncFieldCount));
									Form1.congThanhChienTownPortalMenuIndices = GetSyncFieldOrEmpty(syncFields, 40, syncFieldCount);
									Form1.syncPkModeWithMainAccountEnabled = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 41, syncFieldCount));
									Form1.allAccountsGoToCoordinateEnabled = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 42, syncFieldCount));
									Form1.gatheringPointEnabled = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 43, syncFieldCount));
									if (syncFieldCount > 44)
									{
										int sharedSlotFlagValue = CommonUtility.ParseInt32OrZero(GetSyncFieldOrEmpty(syncFields, 44, syncFieldCount));
										if (sharedSlotFlagValue > 0 && Form1.characterAccountConfig_1 != null)
										{
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
										}
									}
									goto IL_064e;
								}
							}
							catch
							{
								goto IL_064e;
							}
						}
					}
				}
			}
			if (CommonUtility.GetElapsedMilliseconds(CharacterStateSyncCoordinator.characterSyncSnapshot_1.long_1) > 6000L)
			{
				GameInterfaceMemoryHelper.smethod_41(accountConfig, bool_0: false);
				if (CommonUtility.MatchesGameTextPattern(latestChannelText, "g\u00adêi nµy"))
				{
					GameInterfaceMemoryHelper.WriteLatestTopChannelText(accountConfig, "0K..");
					GameProcessInteractionHelper.ExecuteGameScript(accountConfig, "Switch([[trade]])");
					Thread.Sleep(50);
				}
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId = 0;
				CharacterStateSyncCoordinator.characterSyncSnapshot_1.long_1 = CommonUtility.GetCurrentTicks();
			}
		}
		else
		{
			CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId = 0;
			CharacterStateSyncCoordinator.characterSyncSnapshot_1.accountId = 0;
			CharacterStateSyncCoordinator.characterSyncSnapshot_1.entityExistsFlag = 0;
		}
		return;
		IL_064e:
		CharacterStateSyncCoordinator.characterSyncSnapshot_1.long_1 = CommonUtility.GetCurrentTicks();
	}

	private void AuxiliaryMachineManager_Load(object sender, EventArgs e)
	{
		if (anchorCursorX >= 0 && anchorCursorY >= 0)
		{
			int windowLeft = anchorCursorX - base.Width - 10;
			int windowTop = anchorCursorY - base.Height - 10;
			if (windowLeft < 0)
			{
				windowLeft = 0;
			}
			if (windowTop < 0)
			{
				windowTop = 0;
			}
			SetBounds(windowLeft, windowTop, base.Width, base.Height);
		}
		listView1.Items.Clear();
		if (auxiliaryAccountNames != null)
		{
			for (int accountIndex = 0; accountIndex < auxiliaryAccountNames.Length; accountIndex++)
			{
				if (auxiliaryAccountNames[accountIndex] != null && auxiliaryAccountNames[accountIndex] != string.Empty)
				{
					AppendAuxiliaryAccountListItem(ref listView1, GameTextEncodingHelper.ConvertGameTextToDisplayText(auxiliaryAccountNames[accountIndex], 1));
				}
			}
		}
		timer_0.Interval = 300;
		timer_0.Enabled = true;
		base.TopMost = true;
	}

	protected override void OnFormClosing(FormClosingEventArgs e)
	{
		isManagerFormOpen = false;
	}

	private void timer_0_Tick(object sender, EventArgs e)
	{
		if (!isManagerFormOpen)
		{
			Close();
		}
	}

	public static void AppendAuxiliaryAccountListItem(ref ListView listView, string accountName)
	{
		if (accountName != null)
		{
			try
			{
				ListViewItem listViewItem = new ListViewItem((listView.Items.Count + 1).ToString());
				ListViewItem.ListViewSubItem item = new ListViewItem.ListViewSubItem(listViewItem, accountName);
				listViewItem.SubItems.Add(item);
				listView.Items.Add(listViewItem);
			}
			catch
			{
			}
		}
	}

	private int FindSelectedListViewItemIndex(ListView listView)
	{
		if (listView.Items != null)
		{
			for (int i = 0; i < listView.Items.Count; i++)
			{
				if (listView.Items[i].Selected)
				{
					return i;
				}
			}
		}
		return -1;
	}

	private void comboBoxThemAcc_DropDown(object sender, EventArgs e)
	{
		auxiliaryAccountNameCandidates = null;
		if (Form1.characterAccountConfig_1 != null)
		{
			for (int i = 0; i < Form1.characterAccountConfig_1.Length; i++)
			{
				GameEntityMemoryHelper.CollectEntityNames(Form1.characterAccountConfig_1[i], ref auxiliaryAccountNameCandidates, 1);
			}
		}
		comboBoxThemAcc.Items.Clear();
		if (auxiliaryAccountNameCandidates != null)
		{
			Array.Sort(auxiliaryAccountNameCandidates);
			for (int j = 0; j < auxiliaryAccountNameCandidates.Length; j++)
			{
				comboBoxThemAcc.Items.Add(GameTextEncodingHelper.ConvertGameTextToDisplayText(auxiliaryAccountNameCandidates[j], 1));
			}
		}
		comboBoxThemAcc.Items.Add(string.Empty);
	}

	private void buttonThemAcc_Click(object sender, EventArgs e)
	{
		string selectedAccountName = comboBoxThemAcc.Text;
		if (listView1.Items.Count > 0)
		{
			for (int existingItemIndex = 0; existingItemIndex < listView1.Items.Count; existingItemIndex++)
			{
				if (selectedAccountName == listView1.Items[existingItemIndex].SubItems[1].Text)
				{
					comboBoxThemAcc.Items.Clear();
					comboBoxThemAcc.Text = "";
					return;
				}
			}
		}
		if (auxiliaryAccountNameCandidates != null)
		{
			for (int candidateIndex = 0; candidateIndex < auxiliaryAccountNameCandidates.Length; candidateIndex++)
			{
				if (selectedAccountName == GameTextEncodingHelper.ConvertGameTextToDisplayText(auxiliaryAccountNameCandidates[candidateIndex], 1))
				{
					selectedAccountName = auxiliaryAccountNameCandidates[candidateIndex];
					break;
				}
			}
		}
		CommonUtility.AppendStringIfMissing(ref auxiliaryAccountNames, selectedAccountName);
		AppendAuxiliaryAccountListItem(ref listView1, selectedAccountName);
		comboBoxThemAcc.Items.Clear();
		comboBoxThemAcc.Text = "";
		SaveAuxiliaryAccountList();
	}

	private void buttonXoaAcc_Click(object sender, EventArgs e)
	{
		int selectedItemIndex = FindSelectedListViewItemIndex(listView1);
		if (selectedItemIndex < 0 || selectedItemIndex > listView1.Items.Count - 1)
		{
			return;
		}
		string selectedDisplayName = listView1.Items[selectedItemIndex].SubItems[1].Text;
		if (auxiliaryAccountNames != null)
		{
			for (int accountIndex = 0; accountIndex < auxiliaryAccountNames.Length; accountIndex++)
			{
				if (selectedDisplayName == GameTextEncodingHelper.ConvertGameTextToDisplayText(auxiliaryAccountNames[accountIndex], 1))
				{
					CommonUtility.RemoveStringFromArray(ref auxiliaryAccountNames, auxiliaryAccountNames[accountIndex]);
					break;
				}
			}
		}
		listView1.Items.RemoveAt(selectedItemIndex);
		for (int remainingItemIndex = 0; remainingItemIndex < listView1.Items.Count; remainingItemIndex++)
		{
			listView1.Items[remainingItemIndex].SubItems[0].Text = (remainingItemIndex + 1).ToString();
		}
		SaveAuxiliaryAccountList();
	}

	private void buttonClose_Click(object sender, EventArgs e)
	{
		isManagerFormOpen = false;
		Close();
	}

	private static void SaveAuxiliaryAccountList()
	{
		string serializedAccountList = string.Empty;
		if (auxiliaryAccountNames != null)
		{
			for (int accountIndex = 0; accountIndex < auxiliaryAccountNames.Length; accountIndex++)
			{
				if (serializedAccountList != string.Empty)
				{
					serializedAccountList += "|";
				}
				serializedAccountList += auxiliaryAccountNames[accountIndex];
			}
			serializedAccountList = CommonUtility.EncodeBase64Utf8(serializedAccountList);
		}
		CommonUtility.WriteAllTextWithEncodingOption(GameConfigurationManager.auxiliaryMachineConfigFilePath, serializedAccountList, 1);
	}

	private static string GetSyncFieldOrEmpty(string[] fields, int fieldIndex, int fieldCount = 0)
	{
		if ((fieldCount <= 0 || fieldCount > fieldIndex) && fields != null && fields.Length > fieldIndex)
		{
			return fields[fieldIndex];
		}
		return string.Empty;
	}

	public static int MaintainSyncedPositionOnTransportMap(CharacterAccountConfig accountConfig, ref long lastMovementCommandTicks, ref int movementRetryCount, ref uint[] previousMovementCoordinates)
	{
		Form1.mainAccountSelfControlsCongThanhChienEnabled = 0;
		if (CommonUtility.IsNonZeroCoordinatePair(CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates))
		{
			int currentMapId = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, accountConfig.int_137);
			if (CongThanhQuanTransportCatalog.IsTransportMap(currentMapId))
			{
				uint memoryRootPointer = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, accountConfig.int_137);
				uint memoryEntryIndex = WindowsInteropHelper.ReadProcessUInt32(memoryRootPointer + GameConfigurationManager.memorySignatureScanConfig_13.resolvedValue, accountConfig.int_137);
				uint memoryTableBaseAddress = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, accountConfig.int_137);
				uint characterStateAddress = memoryTableBaseAddress + memoryEntryIndex * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
				int stateGuardValue1 = (int)WindowsInteropHelper.ReadProcessUInt32(characterStateAddress + GameConfigurationManager.memorySignatureScanConfig_55.resolvedValue, accountConfig.int_137);
				int stateGuardValue2 = (int)WindowsInteropHelper.ReadProcessUInt32(characterStateAddress + GameConfigurationManager.memorySignatureScanConfig_50.resolvedValue, accountConfig.int_137);
				int gatewayConnectionState = GameInterfaceMemoryHelper.ReadGatewayConnectionState(accountConfig);
				if (stateGuardValue1 != 10 && stateGuardValue1 != 21 && stateGuardValue2 != 0 && gatewayConnectionState > 1)
				{
					uint[] currentCoordinates = new uint[2]
					{
						WindowsInteropHelper.ReadProcessUInt32(characterStateAddress + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, accountConfig.int_137),
						WindowsInteropHelper.ReadProcessUInt32(characterStateAddress + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, accountConfig.int_137)
					};
					int currentFightState = (int)WindowsInteropHelper.ReadProcessUInt32(characterStateAddress + GameConfigurationManager.memorySignatureScanConfig_43.resolvedValue, accountConfig.int_137);
					long distanceSquared;
					byte[] zeroBuffer;
					if (currentMapId != CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId)
					{
						if (!CongThanhQuanTransportCatalog.IsTransportMap(CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId))
						{
							return 1;
						}
						currentCoordinates = new uint[2]
						{
							WindowsInteropHelper.ReadProcessUInt32(characterStateAddress + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, accountConfig.int_137),
							WindowsInteropHelper.ReadProcessUInt32(characterStateAddress + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, accountConfig.int_137)
						};
						uint[] routeWaypointData = CongThanhQuanTransportCatalog.GetRouteWaypoint(currentMapId, currentCoordinates, CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId, CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates);
						if (routeWaypointData != null)
						{
							int routeBytesWritten = 0;
							int routeProcessHandle = accountConfig.int_137;
							uint routeControlAddress = characterStateAddress + GameConfigurationManager.memorySignatureScanConfig_72.resolvedValue;
							zeroBuffer = new byte[4];
							WindowsInteropHelper.WriteProcessMemory(routeProcessHandle, routeControlAddress, zeroBuffer, 4, ref routeBytesWritten);
							uint[] routeWaypointCoordinates = new uint[2]
							{
								routeWaypointData[0],
								routeWaypointData[1]
							};
							int routeMovementAngleDegrees = (int)routeWaypointData[2];
							long waypointDistanceSquared = GameAutomationUtility.GetSquaredCoordinateDistance(currentCoordinates, routeWaypointCoordinates);
							if (waypointDistanceSquared >= 90000L)
							{
								GameAutomationUtility.SwitchHorseStateIfNeeded(accountConfig, bool_0: false);
								if (previousMovementCoordinates == null)
								{
									previousMovementCoordinates = new uint[2]
									{
										currentCoordinates[0],
										currentCoordinates[1]
									};
									movementRetryCount = 0;
								}
								if (movementRetryCount > 6)
								{
									bool movementAppearsStalled = previousMovementCoordinates != null && GameAutomationUtility.GetSquaredCoordinateDistance(previousMovementCoordinates, currentCoordinates) < 180000L;
									previousMovementCoordinates = null;
									movementRetryCount = 0;
									if (movementAppearsStalled)
									{
										GameAutomationUtility.MoveToApproachCoordinateAndWaitForMovementState(accountConfig, currentCoordinates, CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates, 600);
										return -1;
									}
								}
								if (!CharacterMovementHelper.IsMovementActive(accountConfig) || CommonUtility.GetElapsedMilliseconds(lastMovementCommandTicks) > 3000L)
								{
									movementRetryCount++;
									CharacterMovementHelper.MoveToCoordinates(accountConfig, routeWaypointCoordinates);
									lastMovementCommandTicks = CommonUtility.GetCurrentTicks();
								}
								return -1;
							}
							movementRetryCount = 0;
							previousMovementCoordinates = null;
							for (int approachAttemptIndex = 0; approachAttemptIndex < 10; approachAttemptIndex++)
							{
								currentCoordinates = new uint[2]
								{
									WindowsInteropHelper.ReadProcessUInt32(characterStateAddress + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, accountConfig.int_137),
									WindowsInteropHelper.ReadProcessUInt32(characterStateAddress + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, accountConfig.int_137)
								};
								distanceSquared = GameAutomationUtility.GetSquaredCoordinateDistance(currentCoordinates, routeWaypointCoordinates);
								if (distanceSquared < 11500L || WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, accountConfig.int_137) != currentMapId)
								{
									break;
								}
								GameProcessInteractionHelper.RunToCoordinates(accountConfig, routeWaypointCoordinates);
								Thread.Sleep(300);
							}
							for (int transportAdvanceAttemptIndex = 0; transportAdvanceAttemptIndex < 5; transportAdvanceAttemptIndex++)
							{
								GameAutomationUtility.Move200UnitsAtAngle(accountConfig, routeMovementAngleDegrees);
								Thread.Sleep(300);
								uint mapIdAfterMoveAttempt = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, accountConfig.int_137);
								if (mapIdAfterMoveAttempt != currentMapId)
								{
									break;
								}
							}
						}
						return -1;
					}
					distanceSquared = GameAutomationUtility.GetSquaredCoordinateDistance(currentCoordinates, CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates);
					if (accountConfig.int_130[0] > 0 && accountConfig.int_136 != CharacterStateSyncCoordinator.characterSyncSnapshot_1.accountId && currentFightState == CharacterStateSyncCoordinator.characterSyncSnapshot_1.fightState && currentFightState > 0)
					{
						int circularSearchRadius = accountConfig.int_130[1] + Form1.mainAccountSearchDistance;
						if (distanceSquared <= circularSearchRadius * circularSearchRadius && CircularMovementHelper.MoveToNextPointAroundCenter(accountConfig, CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates, accountConfig.int_130[1]) > 0)
						{
							return 3;
						}
					}
					if (distanceSquared <= Form1.mainAccountSearchDistance * Form1.mainAccountSearchDistance)
					{
						CharacterMovementHelper.SetMovementActive(accountConfig, bool_0: false);
						if (distanceSquared > 20000L)
						{
							GameProcessInteractionHelper.RunToCoordinates(accountConfig, CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates);
							Thread.Sleep(100);
						}
						movementRetryCount = 0;
						previousMovementCoordinates = null;
						return 3;
					}
					int followBytesWritten = 0;
					int followProcessHandle = accountConfig.int_137;
					uint followControlAddress = characterStateAddress + GameConfigurationManager.memorySignatureScanConfig_72.resolvedValue;
					zeroBuffer = new byte[4];
					WindowsInteropHelper.WriteProcessMemory(followProcessHandle, followControlAddress, zeroBuffer, 4, ref followBytesWritten);
					if (distanceSquared > Form1.mountHorseDistance * Form1.mountHorseDistance)
					{
						GameAutomationUtility.SwitchHorseStateIfNeeded(accountConfig, bool_0: false);
					}
					if (movementRetryCount > 6)
					{
						bool followMovementAppearsStalled = previousMovementCoordinates != null && GameAutomationUtility.GetSquaredCoordinateDistance(previousMovementCoordinates, currentCoordinates) < 180000L;
						previousMovementCoordinates = null;
						movementRetryCount = 0;
						if (followMovementAppearsStalled)
						{
							int recoveryBytesWritten = 0;
							int recoveryProcessHandle = accountConfig.int_137;
							uint recoveryControlAddress = characterStateAddress + GameConfigurationManager.memorySignatureScanConfig_72.resolvedValue;
							zeroBuffer = new byte[4];
							WindowsInteropHelper.WriteProcessMemory(recoveryProcessHandle, recoveryControlAddress, zeroBuffer, 4, ref recoveryBytesWritten);
							GameAutomationUtility.MoveToApproachCoordinateAndWaitForMovementState(accountConfig, currentCoordinates, CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates, 600);
							return -1;
						}
					}
					if (distanceSquared < 810000L)
					{
						CharacterMovementHelper.SetMovementActive(accountConfig, bool_0: false);
						GameProcessInteractionHelper.RunToCoordinates(accountConfig, CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates);
						Thread.Sleep(100);
						return -1;
					}
					if (!CharacterMovementHelper.IsMovementActive(accountConfig) || CommonUtility.GetElapsedMilliseconds(lastMovementCommandTicks) > 3000L)
					{
						movementRetryCount++;
						CharacterMovementHelper.MoveToCoordinates(accountConfig, CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates);
						lastMovementCommandTicks = CommonUtility.GetCurrentTicks();
					}
					return -1;
				}
				return 1;
			}
			return 1;
		}
		return 1;
	}

	public static int MaintainSyncedPositionOnMatchingMap(CharacterAccountConfig accountConfig, ref long lastMovementCommandTicks, ref int movementRetryCount, ref uint[] previousMovementCoordinates)
	{
		if (CommonUtility.IsNonZeroCoordinatePair(CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates))
		{
			uint memoryRootPointer = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, accountConfig.int_137);
			uint memoryEntryIndex = WindowsInteropHelper.ReadProcessUInt32(memoryRootPointer + GameConfigurationManager.memorySignatureScanConfig_13.resolvedValue, accountConfig.int_137);
			uint memoryTableBaseAddress = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, accountConfig.int_137);
			uint characterStateAddress = memoryTableBaseAddress + memoryEntryIndex * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
			int stateGuardValue1 = (int)WindowsInteropHelper.ReadProcessUInt32(characterStateAddress + GameConfigurationManager.memorySignatureScanConfig_55.resolvedValue, accountConfig.int_137);
			int stateGuardValue2 = (int)WindowsInteropHelper.ReadProcessUInt32(characterStateAddress + GameConfigurationManager.memorySignatureScanConfig_50.resolvedValue, accountConfig.int_137);
			int gatewayConnectionState = GameInterfaceMemoryHelper.ReadGatewayConnectionState(accountConfig);
			if (stateGuardValue1 != 10 && stateGuardValue1 != 21 && stateGuardValue2 != 0 && gatewayConnectionState > 1)
			{
				int currentMapId = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, accountConfig.int_137);
				if (currentMapId != CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId)
				{
					return 1;
				}
				int currentFightState = (int)WindowsInteropHelper.ReadProcessUInt32(characterStateAddress + GameConfigurationManager.memorySignatureScanConfig_43.resolvedValue, accountConfig.int_137);
				if (currentFightState > 0 && (currentFightState <= 0 || CharacterStateSyncCoordinator.characterSyncSnapshot_1.fightState > 0))
				{
					uint[] currentCoordinates = new uint[2]
					{
						WindowsInteropHelper.ReadProcessUInt32(characterStateAddress + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, accountConfig.int_137),
						WindowsInteropHelper.ReadProcessUInt32(characterStateAddress + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, accountConfig.int_137)
					};
					long distanceSquared = GameAutomationUtility.GetSquaredCoordinateDistance(currentCoordinates, CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates);
					if (accountConfig.int_130[0] > 0 && accountConfig.int_136 != CharacterStateSyncCoordinator.characterSyncSnapshot_1.accountId && currentFightState == CharacterStateSyncCoordinator.characterSyncSnapshot_1.fightState && currentFightState > 0)
					{
						int circularSearchRadius = accountConfig.int_130[1] + Form1.mainAccountSearchDistance;
						if (distanceSquared <= circularSearchRadius * circularSearchRadius && CircularMovementHelper.MoveToNextPointAroundCenter(accountConfig, CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates, accountConfig.int_130[1]) > 0)
						{
							return 3;
						}
					}
					if (distanceSquared > Form1.mainAccountSearchDistance * Form1.mainAccountSearchDistance)
					{
						int bytesWritten = 0;
						int processHandle = accountConfig.int_137;
						uint movementControlAddress = characterStateAddress + GameConfigurationManager.memorySignatureScanConfig_72.resolvedValue;
						byte[] zeroBuffer = new byte[4];
						WindowsInteropHelper.WriteProcessMemory(processHandle, movementControlAddress, zeroBuffer, 4, ref bytesWritten);
						if (distanceSquared > Form1.mountHorseDistance * Form1.mountHorseDistance)
						{
							GameAutomationUtility.SwitchHorseStateIfNeeded(accountConfig, bool_0: false);
						}
						if (previousMovementCoordinates == null)
						{
							previousMovementCoordinates = new uint[2]
							{
								currentCoordinates[0],
								currentCoordinates[1]
							};
							movementRetryCount = 0;
						}
						if (movementRetryCount > 6)
						{
							bool movementAppearsStalled = previousMovementCoordinates != null && GameAutomationUtility.GetSquaredCoordinateDistance(previousMovementCoordinates, currentCoordinates) < 180000L;
							previousMovementCoordinates = null;
							movementRetryCount = 0;
							if (movementAppearsStalled)
							{
								GameAutomationUtility.MoveToApproachCoordinateAndWaitForMovementState(accountConfig, currentCoordinates, CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates, 600);
								return -1;
							}
						}
						if (distanceSquared < 810000L)
						{
							CharacterMovementHelper.SetMovementActive(accountConfig, bool_0: false);
							GameProcessInteractionHelper.RunToCoordinates(accountConfig, CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates);
							Thread.Sleep(100);
							return -1;
						}
						if (!CharacterMovementHelper.IsMovementActive(accountConfig) || CommonUtility.GetElapsedMilliseconds(lastMovementCommandTicks) > 3000L)
						{
							movementRetryCount++;
							CharacterMovementHelper.MoveToCoordinates(accountConfig, CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates);
							lastMovementCommandTicks = CommonUtility.GetCurrentTicks();
						}
						return -1;
					}
					CharacterMovementHelper.SetMovementActive(accountConfig, bool_0: false);
					if (distanceSquared > 20000L)
					{
						GameProcessInteractionHelper.RunToCoordinates(accountConfig, CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates);
						Thread.Sleep(110);
					}
					movementRetryCount = 0;
					previousMovementCoordinates = null;
					return 3;
				}
				return 1;
			}
			return 1;
		}
		return 1;
	}

	public static int NavigateCharacterTowardSyncSnapshot(CharacterAccountConfig characterAccountConfig_0, ref bool bool_10, ref long long_2, ref int int_7, ref uint[] uint_0)
	{
		if (!CommonUtility.IsNonZeroCoordinatePair(CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates))
		{
			return 1;
		}
		uint num = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_11.resolvedValue, characterAccountConfig_0.int_137);
		uint num2 = WindowsInteropHelper.ReadProcessUInt32(num + GameConfigurationManager.memorySignatureScanConfig_13.resolvedValue, characterAccountConfig_0.int_137);
		uint num3 = WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_14.resolvedValue, characterAccountConfig_0.int_137);
		uint num4 = num3 + num2 * GameConfigurationManager.memorySignatureScanConfig_15.resolvedValue;
		int num5 = (int)WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_55.resolvedValue, characterAccountConfig_0.int_137);
		int num6 = (int)WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_50.resolvedValue, characterAccountConfig_0.int_137);
		int num7 = GameInterfaceMemoryHelper.ReadGatewayConnectionState(characterAccountConfig_0);
		int num12;
		uint[] uint_2;
		uint[] uint_3;
		MapTravelConnection gStruct;
		int num8;
		byte[] byte_;
		uint[] array;
		if (num5 != 10 && num5 != 21 && num6 != 0 && num7 > 1)
		{
			array = new uint[2]
			{
				WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, characterAccountConfig_0.int_137),
				WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, characterAccountConfig_0.int_137)
			};
			num8 = (int)WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_43.resolvedValue, characterAccountConfig_0.int_137);
			int num9 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, characterAccountConfig_0.int_137);
			if (num9 != CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId)
			{
				if (ChienLongDongNavigationHelper.IsChienLongDongMap(CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId))
				{
					ChienLongDongNavigationHelper.NavigateChienLongDong(characterAccountConfig_0, bool_0: true, bool_1: true);
					return -4;
				}
				if ((num9 == 221 || num9 == 539) && InterMapTravelHelper.UseCurrentMapTransportNpc(characterAccountConfig_0) > 0)
				{
					return -5;
				}
				num9 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, characterAccountConfig_0.int_137);
				if (ChienLongDongNavigationHelper.IsChienLongDongMap(num9))
				{
					if (GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig_0, GameProcessInteractionHelper.uint_19, 4) > 0 && MapNavigationHelper.NavigateToDestination(characterAccountConfig_0, CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId, null, CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates))
					{
						int num10 = 0;
						while (num10 < 10)
						{
							if (WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, characterAccountConfig_0.int_137) == num9)
							{
								num10++;
								Thread.Sleep(100);
								continue;
							}
							return -5;
						}
					}
					uint[] array2 = ChienLongDongNavigationHelper.NavigateToChienLongDongTeleportAnchor(characterAccountConfig_0);
					if (array2 != null)
					{
						int int_8 = 0;
						int int_9 = characterAccountConfig_0.int_137;
						uint uint_1 = num4 + GameConfigurationManager.memorySignatureScanConfig_72.resolvedValue;
						byte_ = new byte[4];
						WindowsInteropHelper.WriteProcessMemory(int_9, uint_1, byte_, 4, ref int_8);
						if (!CharacterMovementHelper.IsMovementActive(characterAccountConfig_0) || CommonUtility.GetElapsedMilliseconds(long_2) > 3000L)
						{
							CharacterMovementHelper.MoveToCoordinates(characterAccountConfig_0, array2);
							long_2 = CommonUtility.GetCurrentTicks();
						}
					}
					return -5;
				}
				array = new uint[2]
				{
					WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, characterAccountConfig_0.int_137),
					WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, characterAccountConfig_0.int_137)
				};
				gStruct = default(MapTravelConnection);
				int num11 = 0;
				num12 = 0;
				uint_2 = null;
				uint_3 = null;
				if (num9 != 336 && CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId == 341)
				{
					long num13 = GameAutomationUtility.GetNearestCoordinateSquaredDistance(PhongLangDoBoardingAutomation.uint_0, array);
					long num14 = GameAutomationUtility.GetNearestCoordinateSquaredDistance(PhongLangDoBoardingAutomation.uint_1, array);
					if (num13 > num14)
					{
						return 6;
					}
					gStruct = MapTravelDataHelper.FindTravelConnection(num9, CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId);
				}
				else
				{
					if (num9 == 175 || num9 == 195)
					{
						string text = "Tèng Kim Chiªu th|Phong V©n Chiªu\u00ad th";
						if (GameProcessInteractionHelper.UseMatchingInventoryItem(characterAccountConfig_0, text))
						{
							Thread.Sleep(300);
							NpcDialogHelper.SelectMenuOption(characterAccountConfig_0, 0);
							return -6;
						}
					}
					if (num9 != 175)
					{
						if (MapTravelDataHelper.IsMapIn586To604Range(num9) && !MapTravelDataHelper.IsMapIn586To604Range(CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId))
						{
							int num15 = 11;
							int[] array3 = GameAutomationUtility.FindTravelHubGroupPosition(CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId);
							if (array3 != null)
							{
								num15 = GameAutomationUtility.TravelHubMapIds[array3[0], 0];
							}
							InterMapTravelHelper.TravelToDestinationMap(characterAccountConfig_0, num15);
							return -9;
						}
						if (Form1.findMainAccountInCityEnabled <= 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_1.fightState <= 0)
						{
							return 7;
						}
						if (num8 > 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_1.fightState <= 0)
						{
							gStruct = MapTravelDataHelper.FindTravelConnection(num9, CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId);
							if (gStruct.sourceMapId != num9 || gStruct.destinationMapId != CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId)
							{
								if (CommonUtility.FindSubstringIndex(CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapName, "Õn thuyÒ") > 0)
								{
									return 8;
								}
								if (Form1.returnToPreviousPositionEnabled > 0 && num9 != 195)
								{
									if (GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig_0, GameProcessInteractionHelper.uint_19, 4) > 0 && MapNavigationHelper.NavigateToDestination(characterAccountConfig_0, CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId, null, CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates))
									{
										return -7;
									}
									if (GameAutomationUtility.TryUseTownTeleportItem(characterAccountConfig_0))
									{
										return -8;
									}
								}
								if (GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig_0, GameProcessInteractionHelper.uint_19, 4) > 0 && MapNavigationHelper.NavigateToDestination(characterAccountConfig_0, CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId, null, CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates))
								{
									if (num9 == 195 || num9 == 195)
									{
										try
										{
											int int_10 = 0;
											byte[] byte_2 = new byte[1] { 1 };
											WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_16 + GameProcessInteractionHelper.uint_33 * 4, byte_2, 1, ref int_10);
										}
										catch
										{
										}
									}
									return -7;
								}
								if (num9 != 195)
								{
									if (GameAutomationUtility.TryUseTownTeleportItem(characterAccountConfig_0))
									{
										Thread.Sleep(300);
										GameAutomationUtility.WaitForGameSessionReady(characterAccountConfig_0);
										Thread.Sleep(600);
										int num16 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, characterAccountConfig_0.int_137);
										if (num16 != num9)
										{
											return -9;
										}
									}
									string text2 = "Tèng Kim Chiªu th|Phong V©n Chiªu\u00ad th";
									if (GameProcessInteractionHelper.UseMatchingInventoryItem(characterAccountConfig_0, text2))
									{
										Thread.Sleep(300);
										NpcDialogHelper.SelectMenuOption(characterAccountConfig_0, 0);
										return -6;
									}
									return -8;
								}
								return 9;
							}
						}
						else
						{
							if (num8 <= 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_1.fightState <= 0)
							{
								if (GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig_0, GameProcessInteractionHelper.uint_19, 4) > 0 && MapNavigationHelper.NavigateToDestination(characterAccountConfig_0, CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId, null, CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates))
								{
									return -7;
								}
								InterMapTravelHelper.TravelToDestinationMap(characterAccountConfig_0, CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId);
								return -9;
							}
							if (num8 == 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_1.fightState > 0)
							{
								gStruct = MapTravelDataHelper.FindTravelConnection(num9, CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId);
								if (gStruct.sourceMapId != num9 || gStruct.destinationMapId != CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId)
								{
									if (Form1.returnToPreviousPositionEnabled > 0 || GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig_0, GameProcessInteractionHelper.uint_19, 4) == 0)
									{
										if (bool_10)
										{
											bool_10 = false;
											uint[] uint_4 = null;
											if (Form1.findMainAccountEnabled > 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_1.accountId > 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId == num9)
											{
												uint_4 = CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates;
											}
											if (InterMapTravelHelper.UseTravelMenuPath(characterAccountConfig_0, "®iÓm c", uint_4) > 0)
											{
												GameAutomationUtility.WaitForGameSessionReady(characterAccountConfig_0);
												goto IL_0b64;
											}
										}
										if (InterMapTravelHelper.UseTravelMenuForDestinationMap(characterAccountConfig_0, CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId) > 0)
										{
											Thread.Sleep(300);
											GameAutomationUtility.WaitForGameSessionReady(characterAccountConfig_0);
											Thread.Sleep(600);
											int num17 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, characterAccountConfig_0.int_137);
											if (num17 != num9)
											{
												goto IL_0b64;
											}
										}
									}
									bool flag = CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId == 181 && MapNavigationProfileProvider.int_0 > 0;
									if (GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig_0, GameProcessInteractionHelper.uint_19, 4) > 0 && !flag)
									{
										int num18 = CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId;
										int num19 = MapNavigationHelper.FindNavigationEntryIndex(num18);
										if (num19 < 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId == 76)
										{
											num18 = 75;
											num19 = MapNavigationHelper.FindNavigationEntryIndex(75);
										}
										if (0 <= num19 && MapNavigationHelper.NavigateToDestination(characterAccountConfig_0, num18))
										{
											Thread.Sleep(300);
											GameAutomationUtility.WaitForGameSessionReady(characterAccountConfig_0);
											Thread.Sleep(600);
											int num20 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, characterAccountConfig_0.int_137);
											if (num20 != num9)
											{
												goto IL_0b64;
											}
										}
										else if (num9 != 103 && num9 != 114 && num9 != 110 && (CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId == 110 || CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId == 114) && MapNavigationHelper.NavigateToDestination(characterAccountConfig_0, 103))
										{
											Thread.Sleep(300);
											GameAutomationUtility.WaitForGameSessionReady(characterAccountConfig_0);
											Thread.Sleep(600);
											int num21 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, characterAccountConfig_0.int_137);
											if (num21 != num9)
											{
												goto IL_0b64;
											}
										}
									}
									int[] array4 = GameAutomationUtility.FindTravelHubGroupPosition(num9);
									if (array4 == null && CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId > 0 && TongKimBattlefieldHelper.FindBattlefieldMapMatrixPosition(num9) != null && TongKimBattlefieldHelper.FindBattlefieldMapGroupPosition(CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId) == null)
									{
										InterMapTravelHelper.TravelToDestinationMap(characterAccountConfig_0, 11);
										Thread.Sleep(600);
										int num22 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, characterAccountConfig_0.int_137);
										if (num22 != num9)
										{
											int int_11 = 0;
											byte[] byte_3 = new byte[1] { 1 };
											WindowsInteropHelper.WriteProcessMemory(characterAccountConfig_0.int_137, characterAccountConfig_0.uint_16 + GameProcessInteractionHelper.uint_33 * 4, byte_3, 1, ref int_11);
											goto IL_0b64;
										}
									}
									bool flag2 = false;
									if (!ChienLongDongNavigationHelper.IsChienLongDongMap(CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId))
									{
										if (CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId != 181)
										{
											if (CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId != 224)
											{
												if (CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId == 993)
												{
													InterMapTravelHelper.UseTravelMenuPath(characterAccountConfig_0, "NguyÖt Ca");
													flag2 = true;
												}
												else
												{
													InterMapTravelHelper.UseTravelMenuForDestinationMap(characterAccountConfig_0, CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId);
													flag2 = true;
												}
											}
											else
											{
												InterMapTravelHelper.UseTravelMenuPath(characterAccountConfig_0, "h÷ng n¬i ®· ®i q|Sa M¹c");
												flag2 = true;
											}
										}
										else
										{
											InterMapTravelHelper.UseTravelMenuPath(characterAccountConfig_0, "h÷ng n¬i ®· ®i q|L\u00adìng Thñy|" + CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapName);
											flag2 = true;
										}
									}
									else
									{
										InterMapTravelHelper.UseTravelMenuPath(characterAccountConfig_0, "ChiÕn Long|H\u00b8i Qu¶ H|L\u00adìng Thñy ");
										flag2 = true;
									}
									if (flag2)
									{
										Thread.Sleep(150);
										GameAutomationUtility.WaitForGameSessionReady(characterAccountConfig_0);
										int num23 = 0;
										while (num23 < 8)
										{
											int num24 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, characterAccountConfig_0.int_137);
											if (num24 == num9)
											{
												num23++;
												Thread.Sleep(100);
												continue;
											}
											goto IL_0b64;
										}
									}
									int num25 = -1;
									if (Form1.disableRunningEnabled > 0)
									{
										num25 = -1;
									}
									if (num25 < 0)
									{
										num11 = GameAutomationUtility.FindTravelHubMapTowardDestination(num9, CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId, ref gStruct);
										if (num11 == 0)
										{
											goto IL_0cfc;
										}
										if (num11 > 0)
										{
											InterMapTravelHelper.TravelToDestinationMap(characterAccountConfig_0, num11);
											goto IL_0b64;
										}
									}
									return -9;
								}
							}
							else
							{
								if (GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig_0, GameProcessInteractionHelper.uint_19, 4) > 0 && MapNavigationHelper.NavigateToDestination(characterAccountConfig_0, CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId))
								{
									Thread.Sleep(300);
									GameAutomationUtility.WaitForGameSessionReady(characterAccountConfig_0);
									Thread.Sleep(600);
									int num26 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, characterAccountConfig_0.int_137);
									if (num26 != num9)
									{
										return -7;
									}
								}
								gStruct = MapTravelDataHelper.FindTravelConnection(num9, CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId);
								if (gStruct.sourceMapId != num9 || gStruct.destinationMapId != CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId)
								{
									num11 = GameAutomationUtility.FindTravelHubMapTowardDestination(num9, CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId, ref gStruct);
									if (num11 != 0)
									{
										bool_10 = false;
										if (num11 > 0)
										{
											if (num9 == 336)
											{
												long num27 = GameAutomationUtility.GetNearestCoordinateSquaredDistance(PhongLangDoBoardingAutomation.uint_0, array);
												long num28 = GameAutomationUtility.GetNearestCoordinateSquaredDistance(PhongLangDoBoardingAutomation.uint_1, array);
												if (num27 > num28)
												{
													gStruct = MapTravelDataHelper.FindTravelConnection(num9, 121);
													goto IL_0cfc;
												}
											}
											if (GameAutomationUtility.TryUseTownTeleportItem(characterAccountConfig_0))
											{
												Thread.Sleep(300);
												GameAutomationUtility.WaitForGameSessionReady(characterAccountConfig_0);
												Thread.Sleep(600);
												int num29 = (int)WindowsInteropHelper.ReadProcessUInt32(GameConfigurationManager.memorySignatureScanConfig_27.resolvedValue, characterAccountConfig_0.int_137);
												if (num29 != num9)
												{
													return -8;
												}
											}
										}
										return 1;
									}
								}
							}
						}
					}
					else
					{
						gStruct = MapTravelDataHelper.FindTravelConnection(num9, 195);
					}
				}
				goto IL_0cfc;
			}
			bool flag3 = TongKimBattlefieldHelper.FindBattlefieldMapGroupPosition(num9) != null || TongKimBattlefieldHelper.FindConfiguredBattlefieldMapIndex(num9) > 0;
			if (num8 > 0 && flag3 && CharacterStateSyncCoordinator.characterSyncSnapshot_1.fightState <= 0)
			{
				return 3;
			}
			long num30 = GameAutomationUtility.GetSquaredCoordinateDistance(array, CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates);
			if (characterAccountConfig_0.int_130[0] > 0 && characterAccountConfig_0.int_136 != CharacterStateSyncCoordinator.characterSyncSnapshot_1.accountId && num8 == CharacterStateSyncCoordinator.characterSyncSnapshot_1.fightState && num8 > 0)
			{
				int num31 = characterAccountConfig_0.int_130[1] + Form1.mainAccountSearchDistance;
				if (num30 <= num31 * num31 && CircularMovementHelper.MoveToNextPointAroundCenter(characterAccountConfig_0, CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates, characterAccountConfig_0.int_130[1]) > 0)
				{
					return 4;
				}
			}
			if (num30 > Form1.mainAccountSearchDistance * Form1.mainAccountSearchDistance)
			{
				if (num9 == 336)
				{
					int num32 = 0;
					int num33 = 0;
					long num34 = GameAutomationUtility.GetNearestCoordinateSquaredDistance(PhongLangDoBoardingAutomation.uint_0, array);
					long num35 = GameAutomationUtility.GetNearestCoordinateSquaredDistance(PhongLangDoBoardingAutomation.uint_1, array);
					if (num34 < num35)
					{
						num32 = 1;
					}
					num34 = GameAutomationUtility.GetNearestCoordinateSquaredDistance(PhongLangDoBoardingAutomation.uint_0, CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates);
					num35 = GameAutomationUtility.GetNearestCoordinateSquaredDistance(PhongLangDoBoardingAutomation.uint_1, CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates);
					if (num34 < num35)
					{
						num33 = 1;
					}
					if (num32 != num33)
					{
						return 5;
					}
				}
				int int_12 = 0;
				int int_13 = characterAccountConfig_0.int_137;
				uint uint_5 = num4 + GameConfigurationManager.memorySignatureScanConfig_72.resolvedValue;
				byte_ = new byte[4];
				WindowsInteropHelper.WriteProcessMemory(int_13, uint_5, byte_, 4, ref int_12);
				if (uint_0 == null)
				{
					uint_0 = new uint[2]
					{
						array[0],
						array[1]
					};
					int_7 = 0;
				}
				if (int_7 > 6)
				{
					bool flag4 = uint_0 != null && GameAutomationUtility.GetSquaredCoordinateDistance(uint_0, array) < 180000L;
					uint_0 = null;
					int_7 = 0;
					if (flag4)
					{
						GameAutomationUtility.MoveToApproachCoordinateAndWaitForMovementState(characterAccountConfig_0, array, CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates, 600);
						return -1;
					}
				}
				if (num30 > Form1.mountHorseDistance * Form1.mountHorseDistance)
				{
					GameAutomationUtility.SwitchHorseStateIfNeeded(characterAccountConfig_0, bool_0: false);
				}
				if (num30 < 22500L)
				{
					CharacterMovementHelper.SetMovementActive(characterAccountConfig_0, bool_0: false);
					return 4;
				}
				if (num30 >= 810000L)
				{
					int[] array5 = GameAutomationUtility.FindTravelHubGroupPosition(num9);
					if (array5 != null && num8 > 0 && CharacterStateSyncCoordinator.characterSyncSnapshot_1.fightState <= 0)
					{
						if (GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig_0, GameProcessInteractionHelper.uint_19, 4) > 0 && MapNavigationHelper.NavigateToDestination(characterAccountConfig_0, CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId, null, CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates))
						{
							return -2;
						}
						if (GameAutomationUtility.TryUseTownTeleportItem(characterAccountConfig_0))
						{
							return -2;
						}
					}
					if (bool_10 && !flag3 && num8 == 0 && array5 != null && array5[1] == 0 && (CharacterStateSyncCoordinator.characterSyncSnapshot_1.fightState > 0 || CharacterStateSyncCoordinator.characterSyncSnapshot_0.fightState > 0))
					{
						bool_10 = false;
						uint[] uint_6 = null;
						if (CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId == num9)
						{
							uint_6 = CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates;
						}
						if (InterMapTravelHelper.UseTravelMenuPath(characterAccountConfig_0, "®iÓm c", uint_6) > 0)
						{
							Thread.Sleep(300);
							GameAutomationUtility.WaitForGameSessionReady(characterAccountConfig_0);
							return -2;
						}
					}
					int num36 = -1;
					long num37 = 0L;
					uint[,] array6 = null;
					uint[] array7 = null;
					if (CharacterStateSyncCoordinator.characterSyncSnapshot_1.fightState > 0)
					{
						uint[] array8 = MapTravelDataHelper.FindNearestNamedMapPointCoordinates(CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates, num9, "NGOAITHANH");
						if (array8 != null)
						{
							long num38 = GameAutomationUtility.GetSquaredCoordinateDistance(CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates, array8);
							if (num38 <= 100000000L)
							{
								array6 = MapRouteCatalog.FindRoute(num9, array, array8);
								if (array6 != null)
								{
									num36 = GameAutomationUtility.FindNearestCoordinateIndex(array6, array8);
									if (num36 >= 0)
									{
										array7 = new uint[2]
										{
											array6[num36, 0],
											array6[num36, 1]
										};
										num37 = GameAutomationUtility.GetSquaredCoordinateDistance(array, array7);
										if (num37 > 500000L)
										{
											CharacterMovementHelper.SetMovementActive(characterAccountConfig_0, bool_0: false);
											GameAutomationUtility.FollowCoordinateRoute(characterAccountConfig_0, array6, array, array8, num9, bool_0: true, 8000);
											num8 = (int)WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_43.resolvedValue, characterAccountConfig_0.int_137);
											if (num8 <= 0)
											{
												return -1;
											}
										}
									}
								}
							}
						}
					}
					else
					{
						array6 = MapRouteCatalog.FindRoute(num9, CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates);
						if (array6 != null)
						{
							num36 = GameAutomationUtility.FindNearestCoordinateIndex(array6, CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates);
							if (num36 >= 0)
							{
								array7 = new uint[2]
								{
									array6[num36, 0],
									array6[num36, 1]
								};
								num37 = GameAutomationUtility.GetSquaredCoordinateDistance(array, array7);
								num8 = (int)WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_43.resolvedValue, characterAccountConfig_0.int_137);
								if (num37 >= 90000L && num8 <= 0)
								{
									CharacterMovementHelper.SetMovementActive(characterAccountConfig_0, bool_0: false);
									GameAutomationUtility.FollowCoordinateRoute(characterAccountConfig_0, array6, array, CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates, num9, bool_0: true, 8000);
									return -1;
								}
							}
						}
					}
					if (num9 == 53 && CharacterStateSyncCoordinator.characterSyncSnapshot_1.mapId == 53 && num8 <= 0)
					{
						uint[] array9 = CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates;
						if (ViSonDaoRouteHelper.navigationRouteCandidates == null)
						{
							ViSonDaoRouteHelper.navigationRouteCandidates = ViSonDaoRouteHelper.CreateNavigationRouteGroups();
						}
						if (CharacterStateSyncCoordinator.characterSyncSnapshot_1.fightState > 0)
						{
							array9 = ViSonDaoRouteHelper.GetNearestRegionAnchorCoordinate(array9);
						}
						uint[,] uint_7 = MapTravelDataHelper.SelectBestRouteCoordinates(ViSonDaoRouteHelper.navigationRouteCandidates, array, array9);
						uint[] array10 = array;
						int num39 = GameAutomationUtility.FollowCoordinateRoute(characterAccountConfig_0, uint_7, array, array9, 53, bool_0: true, 8000);
						array = new uint[2]
						{
							WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, characterAccountConfig_0.int_137),
							WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, characterAccountConfig_0.int_137)
						};
						if (array10 != null && num39 > 0 && (array10[0] != array[0] || array10[1] != array[1]))
						{
							return -3;
						}
					}
					num30 = GameAutomationUtility.GetSquaredCoordinateDistance(array, CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates);
					uint[] array11 = new uint[2]
					{
						CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates[0],
						CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates[1]
					};
					if (num9 == 333)
					{
						if (GameProcessInteractionHelper.ReadSharedSlotIntegerValue(characterAccountConfig_0, GameProcessInteractionHelper.uint_19, 4) > 0 && num30 > 15354505L && Form1.selectedGameProfileName == "vltrungnguyen.com")
						{
							num30 = -1L;
							int num40 = -1;
							for (int i = 0; i < HoaSonMapRouteHelper.MapGates.Length; i++)
							{
								long num41 = GameAutomationUtility.GetSquaredCoordinateDistance(CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates, HoaSonMapRouteHelper.MapGates[i].coordinates);
								if (num40 < 0 || num41 < num30)
								{
									num40 = i;
									num30 = num41;
								}
							}
							if (MapNavigationHelper.UseTravelScrollMenuOption(characterAccountConfig_0, "b¶n ®å|§Æc BiÖt|" + HoaSonMapRouteHelper.MapGates[num40].name))
							{
								Thread.Sleep(200);
								return -3;
							}
						}
						bool flag5 = HoaSonMapRouteHelper.IsCloserToRouteSetFourThanRouteSetThree(array);
						bool flag6 = HoaSonMapRouteHelper.IsCloserToRouteSetFourThanRouteSetThree(CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates);
						if (flag5 == flag6)
						{
							if (!flag5)
							{
								long num42 = GameAutomationUtility.GetNearestCoordinateSquaredDistance(HoaSonMapRouteHelper.uint_0, array);
								long num43 = GameAutomationUtility.GetNearestCoordinateSquaredDistance(HoaSonMapRouteHelper.uint_0, CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates);
								long num44 = GameAutomationUtility.GetSquaredCoordinateDistance(array, CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates);
								if (num42 > 1500000L && num43 > 1500000L && num44 > 1500000L)
								{
									uint[,] array12 = HoaSonMapRouteHelper.GetNearestRouteSet(array);
									num30 = GameAutomationUtility.GetNearestCoordinateSquaredDistance(array12, array);
									if (num30 <= 300000L)
									{
										GameAutomationUtility.FollowCoordinateRoute(characterAccountConfig_0, array12, array, null, num9, bool_0: false, 6000, bool_1: true);
										return -3;
									}
									array11[0] = array12[0, 0];
									array11[1] = array12[0, 1];
								}
							}
						}
						else
						{
							uint[,] array13 = null;
							uint[,] array14 = HoaSonMapRouteHelper.GetNearestRouteSet(CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates);
							uint[,] array15 = HoaSonMapRouteHelper.GetNearestRouteSet(array);
							int length = array14.GetLength(0);
							int length2 = array15.GetLength(0);
							long num45 = 0L;
							long num46 = 0L;
							if (!flag5)
							{
								num45 = GameAutomationUtility.GetSquaredDistanceToCoordinate(array, array14[0, 0], array14[0, 1]);
								num45 += GameAutomationUtility.GetSquaredDistanceToCoordinate(new uint[2]
								{
									array14[0, 0],
									array14[0, 1]
								}, array14[length - 1, 0], array14[length - 1, 1]);
								num45 += GameAutomationUtility.GetSquaredDistanceToCoordinate(CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates, array14[length - 1, 0], array14[length - 1, 1]);
								num46 = GameAutomationUtility.GetSquaredDistanceToCoordinate(array, array15[0, 0], array15[0, 1]);
								num46 += GameAutomationUtility.GetSquaredDistanceToCoordinate(new uint[2]
								{
									array15[0, 0],
									array15[0, 1]
								}, array15[length2 - 1, 0], array15[length2 - 1, 1]);
								num46 += GameAutomationUtility.GetSquaredDistanceToCoordinate(CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates, array15[length2 - 1, 0], array15[length2 - 1, 1]);
							}
							else
							{
								num45 = GameAutomationUtility.GetSquaredDistanceToCoordinate(array, array14[length - 1, 0], array14[length - 1, 1]);
								num45 += GameAutomationUtility.GetSquaredDistanceToCoordinate(new uint[2]
								{
									array14[0, 0],
									array14[0, 1]
								}, array14[length - 1, 0], array14[length - 1, 1]);
								num45 += GameAutomationUtility.GetSquaredDistanceToCoordinate(CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates, array14[0, 0], array14[0, 1]);
								num46 = GameAutomationUtility.GetSquaredDistanceToCoordinate(array, array15[length2 - 1, 0], array15[length2 - 1, 1]);
								num46 += GameAutomationUtility.GetSquaredDistanceToCoordinate(new uint[2]
								{
									array15[0, 0],
									array15[0, 1]
								}, array15[length2 - 1, 0], array15[length2 - 1, 1]);
								num46 += GameAutomationUtility.GetSquaredDistanceToCoordinate(CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates, array15[0, 0], array15[0, 1]);
							}
							array13 = ((num45 > num46) ? array15 : array14);
							uint[] array16 = new uint[2]
							{
								array13[0, 0],
								array13[0, 1]
							};
							uint[] array17 = new uint[2]
							{
								array13[array13.GetLength(0) - 1, 0],
								array13[array13.GetLength(0) - 1, 1]
							};
							num30 = GameAutomationUtility.GetNearestCoordinateSquaredDistance(array13, array);
							if (num30 <= 300000L)
							{
								if (flag5)
								{
									GameAutomationUtility.FollowCoordinateRoute(characterAccountConfig_0, array13, array, array16, num9, bool_0: false, 6000, bool_1: true);
								}
								else
								{
									GameAutomationUtility.FollowCoordinateRoute(characterAccountConfig_0, array13, array, array17, num9, bool_0: false, 6000, bool_1: true);
								}
								return -3;
							}
							if (flag5)
							{
								array11[0] = array17[0];
								array11[1] = array17[1];
							}
							else
							{
								array11[0] = array16[0];
								array11[1] = array16[1];
							}
						}
					}
					if (!CharacterMovementHelper.IsMovementActive(characterAccountConfig_0) || CommonUtility.GetElapsedMilliseconds(long_2) > 4000L)
					{
						int_7++;
						CharacterMovementHelper.MoveToCoordinates(characterAccountConfig_0, array11);
						Thread.Sleep(600);
						long_2 = CommonUtility.GetCurrentTicks();
					}
					return -3;
				}
				CharacterMovementHelper.SetMovementActive(characterAccountConfig_0, bool_0: false);
				GameProcessInteractionHelper.RunToCoordinates(characterAccountConfig_0, CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates);
				Thread.Sleep(100);
				return 2;
			}
			CharacterMovementHelper.SetMovementActive(characterAccountConfig_0, bool_0: false);
			if (num30 > 20000L)
			{
				GameProcessInteractionHelper.RunToCoordinates(characterAccountConfig_0, CharacterStateSyncCoordinator.characterSyncSnapshot_1.coordinates);
				Thread.Sleep(100);
			}
			int_7 = 0;
			uint_0 = null;
			return 4;
		}
		return 1;
		IL_0b64:
		NpcDialogHelper.DismissActiveDialogsAndMenus(characterAccountConfig_0);
		return -9;
		IL_0cfc:
		num8 = (int)WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_43.resolvedValue, characterAccountConfig_0.int_137);
		if (num8 > 0)
		{
			bool_10 = true;
		}
		if (gStruct.routeCoordinates == null)
		{
			int num47 = NpcDialogHelper.GetActiveMenuLayoutState(characterAccountConfig_0);
			GameProcessInteractionHelper.SelectMenuOptionByLayout(characterAccountConfig_0, 0, Convert.ToByte(num47 != 0));
			return 12;
		}
		int int_14 = 0;
		int int_15 = characterAccountConfig_0.int_137;
		uint uint_8 = num4 + GameConfigurationManager.memorySignatureScanConfig_72.resolvedValue;
		byte_ = new byte[4];
		WindowsInteropHelper.WriteProcessMemory(int_15, uint_8, byte_, 4, ref int_14);
		array = new uint[2]
		{
			WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_58.resolvedValue, characterAccountConfig_0.int_137),
			WindowsInteropHelper.ReadProcessUInt32(num4 + GameConfigurationManager.memorySignatureScanConfig_57.resolvedValue + GameConfigurationManager.memorySignatureScanConfig_59.resolvedValue, characterAccountConfig_0.int_137)
		};
		int num48 = 0;
		if (gStruct.routeCoordinates.GetLength(0) > 1)
		{
			num48 = GameAutomationUtility.FindNearestCoordinateIndex(gStruct.routeCoordinates, array);
		}
		GameAutomationUtility.ExtractCoordinateRow(gStruct.routeCoordinates, num48, ref uint_2, ref uint_3, ref num12);
		long num49 = GameAutomationUtility.GetSquaredCoordinateDistance(array, uint_2);
		if (num49 > 90000L)
		{
			if (uint_0 == null)
			{
				uint_0 = new uint[2]
				{
					array[0],
					array[1]
				};
				int_7 = 0;
			}
			if (int_7 > 6)
			{
				bool flag7 = uint_0 != null && GameAutomationUtility.GetSquaredCoordinateDistance(uint_0, array) < 180000L;
				uint_0 = null;
				int_7 = 0;
				if (flag7)
				{
					GameAutomationUtility.MoveToApproachCoordinateAndWaitForMovementState(characterAccountConfig_0, array, uint_2, 600);
					return -1;
				}
			}
			GameAutomationUtility.SwitchHorseStateIfNeeded(characterAccountConfig_0, bool_0: false);
			if (!CharacterMovementHelper.IsMovementActive(characterAccountConfig_0) || CommonUtility.GetElapsedMilliseconds(long_2) > 3000L)
			{
				int_7++;
				CharacterMovementHelper.MoveToCoordinates(characterAccountConfig_0, uint_2);
				long_2 = CommonUtility.GetCurrentTicks();
			}
			return -4;
		}
		int_7 = 0;
		uint_0 = null;
		GameAutomationUtility.TriggerMapTransitionAtCoordinate(characterAccountConfig_0, uint_2, num12, uint_3, gStruct.destinationMapId);
		return -4;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.icontainer_0 = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ns121.AuxiliaryMachineManager));
		this.listView1 = new System.Windows.Forms.ListView();
		this.columnHeader_0 = new System.Windows.Forms.ColumnHeader();
		this.columnHeader_1 = new System.Windows.Forms.ColumnHeader();
		this.comboBoxThemAcc = new System.Windows.Forms.ComboBox();
		this.buttonThemAcc = new System.Windows.Forms.Button();
		this.buttonXoaAcc = new System.Windows.Forms.Button();
		this.timer_0 = new System.Windows.Forms.Timer(this.icontainer_0);
		this.label1 = new System.Windows.Forms.Label();
		this.buttonClose = new System.Windows.Forms.Button();
		base.SuspendLayout();
		this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[2] { this.columnHeader_0, this.columnHeader_1 });
		this.listView1.ForeColor = System.Drawing.Color.Black;
		this.listView1.FullRowSelect = true;
		this.listView1.GridLines = true;
		this.listView1.HideSelection = false;
		this.listView1.Location = new System.Drawing.Point(9, 48);
		this.listView1.MultiSelect = false;
		this.listView1.Name = "listView1";
		this.listView1.Size = new System.Drawing.Size(265, 243);
		this.listView1.TabIndex = 2;
		this.listView1.UseCompatibleStateImageBehavior = false;
		this.listView1.View = System.Windows.Forms.View.Details;
		this.columnHeader_0.Text = "No";
		this.columnHeader_0.Width = 40;
		this.columnHeader_1.Text = "Tên nhân vật";
		this.columnHeader_1.Width = 200;
		this.comboBoxThemAcc.DropDownWidth = 120;
		this.comboBoxThemAcc.ForeColor = System.Drawing.Color.Black;
		this.comboBoxThemAcc.FormattingEnabled = true;
		this.comboBoxThemAcc.Location = new System.Drawing.Point(9, 299);
		this.comboBoxThemAcc.Name = "comboBoxThemAcc";
		this.comboBoxThemAcc.Size = new System.Drawing.Size(178, 21);
		this.comboBoxThemAcc.TabIndex = 63;
		this.comboBoxThemAcc.DropDown += new System.EventHandler(comboBoxThemAcc_DropDown);
		this.buttonThemAcc.ForeColor = System.Drawing.Color.Black;
		this.buttonThemAcc.Location = new System.Drawing.Point(9, 326);
		this.buttonThemAcc.Name = "buttonThemAcc";
		this.buttonThemAcc.Size = new System.Drawing.Size(178, 26);
		this.buttonThemAcc.TabIndex = 64;
		this.buttonThemAcc.Text = "Thêm tên ac vào danh sách";
		this.buttonThemAcc.UseVisualStyleBackColor = true;
		this.buttonThemAcc.Click += new System.EventHandler(buttonThemAcc_Click);
		this.buttonXoaAcc.ForeColor = System.Drawing.Color.Black;
		this.buttonXoaAcc.Location = new System.Drawing.Point(193, 297);
		this.buttonXoaAcc.Name = "buttonXoaAcc";
		this.buttonXoaAcc.Size = new System.Drawing.Size(79, 23);
		this.buttonXoaAcc.TabIndex = 65;
		this.buttonXoaAcc.Text = "Xóa";
		this.buttonXoaAcc.UseVisualStyleBackColor = true;
		this.buttonXoaAcc.Click += new System.EventHandler(buttonXoaAcc_Click);
		this.timer_0.Tick += new System.EventHandler(timer_0_Tick);
		this.label1.Location = new System.Drawing.Point(6, 5);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(268, 40);
		this.label1.TabIndex = 69;
		this.label1.Text = "Danh sách ac máy phụ cần thông báo, danh sách nếu càng ít thì tốc độ thông báo càng nhanh, do đó ac nào trong danh sách không online thì xóa đi nhé.";
		this.buttonClose.ForeColor = System.Drawing.Color.Black;
		this.buttonClose.Location = new System.Drawing.Point(193, 326);
		this.buttonClose.Name = "buttonClose";
		this.buttonClose.Size = new System.Drawing.Size(79, 26);
		this.buttonClose.TabIndex = 70;
		this.buttonClose.Text = "Đóng";
		this.buttonClose.UseVisualStyleBackColor = true;
		this.buttonClose.Click += new System.EventHandler(buttonClose_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(284, 359);
		base.Controls.Add(this.buttonClose);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.listView1);
		base.Controls.Add(this.comboBoxThemAcc);
		base.Controls.Add(this.buttonThemAcc);
		base.Controls.Add(this.buttonXoaAcc);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		base.MinimizeBox = false;
		base.Name = "AuxiliaryMachineManager";
		base.ShowInTaskbar = false;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "DANH SACH AC MAY PHU";
		base.Load += new System.EventHandler(AuxiliaryMachineManager_Load);
		base.ResumeLayout(false);
	}
}
