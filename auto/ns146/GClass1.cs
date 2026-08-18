using ns1;
using ns100;
using ns11;
using ns23;
using ns27;
using ns30;
using ns35;
using ns48;
using ns53;
using ns63;
using ns70;
using ns78;
using ns85;
using ns9;
using System;
using System.IO;
using System.Text;
using System.Threading;

namespace ns146;

public class LicenseRuntimeCoordinator
{
	public struct LicenseState
	{
		public string string_0;

		public string string_1;

		public uint licenseIdentityHash;

		public long licenseExpirationTicks;

		public string licenseFileSuffix;

		public int licensedAccountLimit;

		public bool licenseValid;

		public uint[] authorizedMachineHashes;

		public string encodedAuthorizedMachineList;

		public string[] IPList;

		public string IPAuth;

		public long TimeDelaySendProtocol;
	}

	public struct AuxiliaryLicensePolicy
	{
		public long authorizationExpirationTicks;

		public int int_0;

		public int int_1;

		public int int_2;

		public string string_0;

		public int int_3;

		public string string_1;

		public uint machineIdentityHash;

		public string remoteGameScript;
	}

	public static string selectedGameProfileName = null;

	public static string multiMachineFeatureFlagText = null;

	public static string string_2 = null;

	public static int int_0 = 0;

	public static long long_0 = -1L;

	public static int remoteEndpointAttemptCount = 0;

	public static AuxiliaryLicensePolicy[] auxiliaryLicensePolicies = null;

	public static int licenseCoordinatorSignal = 0;

	public static bool versionCheckCompleted = false;

	public static long networkTimeTicks = 0L;

	public static bool restrictedEnvironmentDetected = false;

	public static string string_3 = null;

	public static string latestVersionText = null;

	public static string importantNoticeText = null;

	public static long supplementalLicenseExpirationTicks = 0L;

	public static long long_3 = 0L;

	public static int int_3 = 0;

	public static LicenseState licenseState = default(LicenseState);

	public static int baseLicenseFetchState = 0;

	public static MapTravelConnection[] gstruct28_0 = null;

	public static int int_5 = -1;

	public static int int_6 = 0;

	public static int licensedAccountLimit = 1000;

	public static string string_6 = string.Empty;

	public static bool bool_2 = false;

	public static string string_7 = "\\script\\allowauto.lua";

	public static string string_8 = "RecvResult";

	public static string string_9 = "d";

	public static void RunLicenseAndVersionCoordinationLoop()
	{
		byte[] array = null;
		int bytesRead = 0;
		byte[] lengthPrefixBuffer = new byte[4];
		int restrictedArtifactScanCountdown = 0;
		int networkTimeRefreshCountdown = 0;
		int versionCheckState = 0;
		int advertisementRefreshCountdown = 0;
		int hardwareLicenseFetchStarted = 0;
		int supplementalLicenseFetchStarted = 0;
		int versionRetryCount = 0;
		int startupWarmupCycleCount = 0;
		NetworkTimeUpdater[] networkTimeUpdaters = null;
		RemoteResourceFetchWorker[] versionFetchWorkers = null;
		RemoteResourceFetchWorker[] hardwareLicenseFetchWorkers = null;
		RemoteResourceFetchWorker[] baseLicenseFetchWorkers = null;
		RemoteResourceFetchWorker[] supplementalLicenseFetchWorkers = null;
		RemoteResourceFetchWorker[] advertisementFetchWorkers = null;
		long versionCheckRefreshStartTicks = 0L;
		while (true)
		{
			licenseState = new LicenseState
			{
				string_0 = null,
				string_1 = null,
				licenseValid = false,
				licenseFileSuffix = string.Empty,
				licenseExpirationTicks = 0L,
				licensedAccountLimit = 0,
				licenseIdentityHash = 0u
			};
			baseLicenseFetchState = 0;
			supplementalLicenseFetchStarted = 0;
			versionRetryCount = 0;
			supplementalLicenseExpirationTicks = 0L;
			licenseCoordinatorSignal = 0;
			while (true)
			{
				Thread.Sleep(1300);
				if (CommonUtility.bool_0)
				{
					return;
				}
				if (licenseCoordinatorSignal == 2)
				{
					break;
				}
				restrictedArtifactScanCountdown--;
				if (restrictedArtifactScanCountdown <= 0)
				{
					restrictedEnvironmentDetected = restrictedEnvironmentDetected || DetectRestrictedRuntimeArtifacts();
					restrictedArtifactScanCountdown = 1800;
				}
				if (!Form1.mainRuntimeInitialized || CommonUtility.uint_0 == 0)
				{
					continue;
				}
				if (restrictedEnvironmentDetected)
				{
					Form1.characterAccountConfig_1 = null;
					continue;
				}
				int processHandle = CommonUtility.int_1;
				uint sharedMemoryBaseAddress = CommonUtility.uint_0;
				if (networkTimeUpdaters == null || array == null)
				{
					array = new byte[8];
					networkTimeUpdaters = new NetworkTimeUpdater[RemoteEndpointCatalog.EncodedTimeServers.Length];
					int downloadEndpointCount = RemoteEndpointCatalog.DownloadBaseUrls.Length;
					versionFetchWorkers = new RemoteResourceFetchWorker[downloadEndpointCount];
					hardwareLicenseFetchWorkers = new RemoteResourceFetchWorker[downloadEndpointCount];
					baseLicenseFetchWorkers = new RemoteResourceFetchWorker[downloadEndpointCount];
					supplementalLicenseFetchWorkers = new RemoteResourceFetchWorker[downloadEndpointCount];
					advertisementFetchWorkers = new RemoteResourceFetchWorker[downloadEndpointCount];
					// HardwareLicenseIdentity.InitializeHardwareIdentity(); // License check removed
					long_3 = 0L;
					string text = ReadAndClearLengthPrefixedProcessString(processHandle, sharedMemoryBaseAddress + 256);
					text = CommonUtility.DecodeLengthShiftedString(ReadAndClearLengthPrefixedProcessString(processHandle, sharedMemoryBaseAddress + 768));
					if (text != string.Empty)
					{
						array = Encoding.ASCII.GetBytes(text);
					}
					uint sharedStringAddress = sharedMemoryBaseAddress + 1024 + 8;
					WindowsInteropHelper.ReadProcessMemory(processHandle, sharedStringAddress, lengthPrefixBuffer, 4, ref bytesRead);
					int sharedStringLength = BitConverter.ToInt32(lengthPrefixBuffer, 0);
					if (sharedStringLength > 0)
					{
						text = ReadAndClearLengthPrefixedProcessString(processHandle, sharedStringAddress, decodeGameText: true);
						CommonUtility.long_0 = CommonUtility.ParseInt64OrZero(text);
					}
				}
				if (versionCheckState == 0)
				{
					versionCheckState = 1;
					if (versionRetryCount == 0)
					{
						CommonUtility.string_17 = new string[1] { "Đang kiểm tra phiên bản, xin chờ chút xíu..." };
					}
					else
					{
						CommonUtility.string_17 = new string[1] { "Đang thử kiểm tra phiên bản lần thứ " + (versionCheckState + 1) };
					}
					for (int i = 0; i < versionFetchWorkers.Length; i++)
					{
						versionFetchWorkers[i] = new RemoteResourceFetchWorker
						{
							resourcePathSource = "KYKeoxe.txt",
							baseUrl = RemoteEndpointCatalog.DownloadBaseUrls[i],
							fetchCompleted = false,
							int_0 = i + 1
						};
						new Thread(versionFetchWorkers[i].FetchVersionMetadata).Start();
					}
					Thread.Sleep(800);
				}
				if (versionCheckState == 1 || versionCheckState == -1)
				{
					if (latestVersionText == null || latestVersionText == string.Empty)
					{
						if (versionCheckState == -1)
						{
							if (versionRetryCount < 3)
							{
								versionRetryCount++;
								versionCheckState = 0;
								continue;
							}
							if (versionCheckCompleted)
							{
								versionCheckState = 2;
								continue;
							}
							CommonUtility.string_17 = new string[1] { "Không thể kiểm tra phiên bản. Qua phụ trợ bấm cập nhật auto mới." };
							return;
						}
						int pendingVersionFetchCount = versionFetchWorkers.Length;
						for (int j = 0; j < versionFetchWorkers.Length; j++)
						{
							if (versionFetchWorkers[j] == null || versionFetchWorkers[j].fetchCompleted)
							{
								pendingVersionFetchCount--;
							}
						}
						if (pendingVersionFetchCount <= 0)
						{
							versionCheckState = -1;
						}
						continue;
					}
					versionCheckState = 2;
				}
				switch (versionCheckState)
				{
				case 3:
					if (CommonUtility.GetElapsedMilliseconds(versionCheckRefreshStartTicks) > 43200000L)
					{
						versionCheckState = 0;
						versionCheckRefreshStartTicks = 0L;
					}
					break;
				case 2:
					CommonUtility.AppendStringIfMissing(ref CommonUtility.string_17, CommonUtility.DecodeCharArrayToString(CommonUtility.char_22));
					licenseCoordinatorSignal = 1;
					versionCheckCompleted = true;
					versionCheckState = 3;
					versionRetryCount = 0;
					versionCheckRefreshStartTicks = CommonUtility.GetCurrentTicks();
					break;
				}
				networkTimeRefreshCountdown--;
				if (networkTimeRefreshCountdown <= 0 && (versionCheckCompleted || versionCheckState == 3))
				{
					for (int k = 0; k < networkTimeUpdaters.Length; k++)
					{
						networkTimeUpdaters[k] = new NetworkTimeUpdater
						{
							TimeServer = RemoteEndpointCatalog.EncodedTimeServers[k]
						};
						networkTimeTicks = DateTime.Now.Ticks;
						new Thread(networkTimeUpdaters[k].Update).Start();
						Thread.Sleep(150);
					}
					networkTimeRefreshCountdown = 1800;
					if (licenseState.licenseValid)
					{
						licenseState.licenseValid = licenseState.licenseFileSuffix != string.Empty && licenseState.licenseIdentityHash != 0 && licenseState.licenseExpirationTicks > networkTimeTicks && networkTimeTicks > 636758336219996160L;
						licenseCoordinatorSignal = 1;
					}
				}
				if (networkTimeTicks <= 0L)
				{
					if (networkTimeRefreshCountdown > 100)
					{
						networkTimeRefreshCountdown = 100;
					}
					continue;
				}
				if (hardwareLicenseFetchStarted == 0 && HardwareLicenseIdentity.string_0 != string.Empty && HardwareLicenseIdentity.hardwareAuthorizationValid)
				{
					hardwareLicenseFetchStarted = 1;
					string text2 = CommonUtility.DecodeLengthShiftedString(CommonUtility.string_5);
					string text3 = CommonUtility.DecodeLengthShiftedString(string.Concat(CommonUtility.char_12));
					string hardwareLicenseResourcePath = "hdd/" + HardwareLicenseIdentity.hardwareIdentityCode + text2 + HardwareLicenseIdentity.long_0 + text3;
					for (int l = 0; l < hardwareLicenseFetchWorkers.Length; l++)
					{
						hardwareLicenseFetchWorkers[l] = new RemoteResourceFetchWorker
						{
							resourcePathSource = hardwareLicenseResourcePath,
							baseUrl = RemoteEndpointCatalog.DownloadBaseUrls[l],
							fetchCompleted = false,
							int_0 = l + 1
						};
						new Thread(hardwareLicenseFetchWorkers[l].FetchHardwareLicensePayload).Start();
					}
					Thread.Sleep(800);
				}
				if (baseLicenseFetchState == 0 && licenseState.licenseFileSuffix == string.Empty)
				{
					baseLicenseFetchState = 1;
					string baseLicenseResourcePath = "license/" + Form1.usageId + ".txt";
					if (Form1.usageId.IndexOf(Form1.defaultUsageIdPlaceholder) != 0)
					{
						for (int m = 0; m < baseLicenseFetchWorkers.Length; m++)
						{
							baseLicenseFetchWorkers[m] = new RemoteResourceFetchWorker
							{
								resourcePathSource = baseLicenseResourcePath,
								baseUrl = RemoteEndpointCatalog.DownloadBaseUrls[m],
								fetchCompleted = false,
								int_0 = m + 1,
								byte_0 = array
							};
							new Thread(baseLicenseFetchWorkers[m].FetchBaseLicensePayload).Start();
						}
					}
					Thread.Sleep(800);
				}
				if (baseLicenseFetchState == 1)
				{
					bool baseLicenseFetchPending = false;
					for (int n = 0; n < baseLicenseFetchWorkers.Length; n++)
					{
						if (baseLicenseFetchWorkers[n] != null && !baseLicenseFetchWorkers[n].fetchCompleted)
						{
							baseLicenseFetchPending = true;
							break;
						}
					}
					if (!baseLicenseFetchPending || licenseState.licenseIdentityHash != 0)
					{
						baseLicenseFetchState = 2;
						licenseCoordinatorSignal = 1;
					}
				}
				if (supplementalLicenseFetchStarted == 0 && supplementalLicenseExpirationTicks <= 0L && licenseState.licenseFileSuffix != string.Empty && licenseState.licenseValid)
				{
					supplementalLicenseFetchStarted = 1;
					string supplementalLicenseResourcePath = "license/" + Form1.usageId + "_" + licenseState.licenseFileSuffix + ".txt";
					for (int supplementalEndpointIndex = 0; supplementalEndpointIndex < supplementalLicenseFetchWorkers.Length; supplementalEndpointIndex++)
					{
						supplementalLicenseFetchWorkers[supplementalEndpointIndex] = new RemoteResourceFetchWorker
						{
							resourcePathSource = supplementalLicenseResourcePath,
							baseUrl = RemoteEndpointCatalog.DownloadBaseUrls[supplementalEndpointIndex],
							fetchCompleted = false,
							int_0 = supplementalEndpointIndex + 1
						};
						new Thread(supplementalLicenseFetchWorkers[supplementalEndpointIndex].FetchSupplementalLicensePayload).Start();
					}
					Thread.Sleep(1500);
				}
				if (startupWarmupCycleCount < 3)
				{
					startupWarmupCycleCount++;
					continue;
				}
				if (startupWarmupCycleCount < 20)
				{
					startupWarmupCycleCount++;
					continue;
				}
				if (advertisementRefreshCountdown <= 0)
				{
					advertisementRefreshCountdown = 600;
					for (int advertisementEndpointIndex = 0; advertisementEndpointIndex < advertisementFetchWorkers.Length; advertisementEndpointIndex++)
					{
						advertisementFetchWorkers[advertisementEndpointIndex] = new RemoteResourceFetchWorker
						{
							baseUrl = RemoteEndpointCatalog.DownloadBaseUrls[advertisementEndpointIndex],
							resourcePathSource = "quangcao.txt",
							fetchCompleted = false,
							int_0 = advertisementEndpointIndex + 1
						};
						new Thread(advertisementFetchWorkers[advertisementEndpointIndex].FetchAdvertisementCatalog).Start();
						Thread.Sleep(800);
					}
				}
				advertisementRefreshCountdown--;
			}
		}
	}

	private static string ReadAndClearLengthPrefixedProcessString(int processHandle, uint address, bool decodeGameText = false)
	{
		int bytesTransferred = 0;
		byte[] lengthBuffer = new byte[4];
		string decodedText = string.Empty;
		WindowsInteropHelper.ReadProcessMemory(processHandle, address, lengthBuffer, 4, ref bytesTransferred);
		int dataLength = BitConverter.ToInt32(lengthBuffer, 0);
		if (dataLength > 0)
		{
			byte[] dataBuffer = new byte[dataLength];
			WindowsInteropHelper.ReadProcessMemory(processHandle, address + 4, dataBuffer, dataLength, ref bytesTransferred);
			decodedText = ((!decodeGameText) ? GameTextEncodingHelper.DecodeNullTerminatedUtf16Le(dataBuffer) : GameTextEncodingHelper.DecodeNullTerminatedUtf7(dataBuffer));
			if (dataBuffer[0] != 0)
			{
				for (int i = 0; i < dataBuffer.Length; i++)
				{
					dataBuffer[i] = 0;
				}
				WindowsInteropHelper.WriteProcessMemory(processHandle, address, dataBuffer, dataLength, ref bytesTransferred);
			}
		}
		return decodedText;
	}

	private static bool DetectRestrictedRuntimeArtifacts()
	{
		bool restrictedArtifactDetected = false;
		try
		{
			string environmentRoot = Environment.GetEnvironmentVariable(CommonUtility.DecodeCharArrayToString(GameConfigurationManager.char_0));
			string scanDirectoryPath = environmentRoot + "\\" + CommonUtility.DecompressBase64DeflateUtf8(CommonUtility.DecodeLengthShiftedString(CommonUtility.string_14));
			string registryMarkerValueName = CommonUtility.DecodeCharArrayToString(CommonUtility.char_27);
			string detectionTimestampValueName = CommonUtility.EncodeBase64Utf8(registryMarkerValueName);
			string[] candidateFiles = Directory.GetFiles(scanDirectoryPath, CommonUtility.DecodeCharArrayToString(CommonUtility.char_25));
			if (candidateFiles != null)
			{
				candidateFiles = Directory.GetFiles(scanDirectoryPath, CommonUtility.DecodeCharArrayToString(CommonUtility.char_26));
			}
			if (candidateFiles != null)
			{
				string[] candidateFilePaths = candidateFiles;
				foreach (string candidateFilePath in candidateFilePaths)
				{
					string candidateFileContent = CommonUtility.ReadAllTextWithEncodingOption(candidateFilePath, 0, 0, 1);
					if (candidateFileContent != null && candidateFileContent != string.Empty)
					{
						for (int j = 0; j < CommonUtility.string_15.Length; j++)
						{
							string restrictedSignature = CommonUtility.DecompressBase64DeflateUtf8(CommonUtility.DecodeLengthShiftedString(CommonUtility.string_15[j]));
							restrictedArtifactDetected = restrictedArtifactDetected || 0 <= CommonUtility.FindSubstringIndex(candidateFileContent, restrictedSignature);
						}
						if (restrictedArtifactDetected)
						{
							WindowsRegistryHelper.SetRegistryValue(WindowsRegistryHelper.GetApplicationRegistryPath(), detectionTimestampValueName, CommonUtility.GetCurrentTicks(), "", 0);
							CommonUtility.DeleteFileIfExists(candidateFilePath);
							CommonUtility.WriteAllTextWithEncodingOption(candidateFilePath, string.Empty, 1);
						}
					}
				}
			}
			if (!restrictedArtifactDetected)
			{
				long detectionTimestampTicks = WindowsRegistryHelper.ReadApplicationRegistryInt64(detectionTimestampValueName, 0, "0");
				long elapsedSinceDetectionMilliseconds = CommonUtility.GetElapsedMilliseconds(detectionTimestampTicks);
				if (elapsedSinceDetectionMilliseconds < 295000L)
				{
					restrictedArtifactDetected = true;
				}
			}
			if (!restrictedArtifactDetected)
			{
				WindowsRegistryHelper.SetRegistryValue(WindowsRegistryHelper.GetApplicationRegistryPath(), detectionTimestampValueName, 0, "", 0);
			}
			WindowsRegistryHelper.SetRegistryValue(WindowsRegistryHelper.GetApplicationRegistryPath(), registryMarkerValueName, DateTime.Now.AddYears(15).Ticks, "", 0);
			return restrictedArtifactDetected;
		}
		catch
		{
			return restrictedArtifactDetected;
		}
	}

	public static string[] GetLicenseStatusLines()
	{
		string primaryStatusLine = CommonUtility.DecodeCharArrayToString(CommonUtility.char_15);
		if (!HardwareLicenseIdentity.hardwareAuthorizationValid)
		{
			return new string[2]
			{
				primaryStatusLine,
				CommonUtility.DecodeCharArrayToString(CommonUtility.char_16)
			};
		}
		DateTime authorizationExpirationDate = new DateTime(CommonUtility.long_0);
		string remainingDaysText = CommonUtility.DecodeCharArrayToString(CommonUtility.char_17);
		if (networkTimeTicks > 0L)
		{
			remainingDaysText = ((int)new TimeSpan(CommonUtility.long_0 - networkTimeTicks).TotalDays).ToString();
		}
		string identityPartSeparator = CommonUtility.DecodeLengthShiftedString(CommonUtility.string_7);
		string joinedHardwareIdentity = null;
		for (int i = 0; i < HardwareLicenseIdentity.hardwareIdentityParts.Length; i++)
		{
			if (i > 0)
			{
				joinedHardwareIdentity += identityPartSeparator;
			}
			joinedHardwareIdentity += HardwareLicenseIdentity.hardwareIdentityParts[i];
		}
		CommonUtility.ComputeLegacyStringHash(joinedHardwareIdentity + identityPartSeparator + HardwareLicenseIdentity.long_0);
		HardwareLicenseIdentity.ComputeMd5Hex(joinedHardwareIdentity).ToLower();
		if (HardwareLicenseIdentity.string_0 == string.Empty || CommonUtility.long_0 <= 0L)
		{
			primaryStatusLine = CommonUtility.DecodeCharArrayToString(CommonUtility.char_18);
		}
		string expirationStatusLine = CommonUtility.DecodeCharArrayToString(CommonUtility.char_19) + authorizationExpirationDate.Day + CommonUtility.DecodeLengthShiftedString(CommonUtility.string_4) + authorizationExpirationDate.Month + CommonUtility.DecodeLengthShiftedString(CommonUtility.string_4) + authorizationExpirationDate.Year + " " + CommonUtility.DecodeLengthShiftedString(CommonUtility.string_8) + remainingDaysText + CommonUtility.DecodeCharArrayToString(CommonUtility.char_20) + CommonUtility.DecodeLengthShiftedString(CommonUtility.string_9);
		return new string[2] { primaryStatusLine, expirationStatusLine };
	}

	public static string FormatFetchedLicenseStatus()
	{
		try
		{
			if (licenseState.licenseExpirationTicks == 0L)
			{
				return CommonUtility.DecodeCharArrayToString(CommonUtility.char_16);
			}
			DateTime networkDateTime = new DateTime(networkTimeTicks);
			DateTime licenseExpirationDateTime = new DateTime(licenseState.licenseExpirationTicks);
			int remainingLicenseDays = (int)(licenseExpirationDateTime - networkDateTime).TotalDays;
			return CommonUtility.DecodeLengthShiftedString(CommonUtility.string_11) + GameTextEncodingHelper.ConvertGameTextToDisplayText(licenseState.string_1, 1) + CommonUtility.DecodeLengthShiftedString(CommonUtility.string_12) + " " + remainingLicenseDays + CommonUtility.DecodeCharArrayToString(CommonUtility.char_20) + GameConfigurationManager.lineSeparator + CommonUtility.DecodeCharArrayToString(CommonUtility.char_19) + licenseExpirationDateTime.Day + CommonUtility.DecodeLengthShiftedString(CommonUtility.string_4) + licenseExpirationDateTime.Month + CommonUtility.DecodeLengthShiftedString(CommonUtility.string_4) + licenseExpirationDateTime.Year + " " + licenseExpirationDateTime.ToShortTimeString() + GameConfigurationManager.lineSeparator + CommonUtility.DecodeCharArrayToString(CommonUtility.char_21) + Form1.usageId;
		}
		catch
		{
		}
		return string.Concat('\u0001');
	}

	public static int GetAccountStateCodeSafe(CharacterAccountConfig accountConfig)
	{
		try
		{
			return GetAccountStateCode(accountConfig);
		}
		catch
		{
		}
		return 0;
	}

    public static int GetAccountStateCode(CharacterAccountConfig accountConfig)
    {
       
        return 2;
    }
}
