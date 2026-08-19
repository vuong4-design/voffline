using System;
using System.Net;
using System.Net.Security;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using Microsoft.Win32;
using ns11;
using ns146;
using ns25;

namespace ns70;

internal class RemoteResourceFetchWorker
{
	public bool fetchCompleted;

	public string credentialUserName;

	public SecureString credentialPassword;

	public string baseUrl;

	public object resourcePathSource;

	public byte[] byte_0;

	public int int_0;

	private static long authorizationCatalogFetchTicks = 0L;

	private static long advertisementFetchTicks = 0L;

	private static long hardwareLicenseFetchTicks = 0L;

	private static long licenseDataFetchTicks = 0L;

	private static long versionInfoFetchTicks = 0L;

	private static long long_5 = 0L;

	private static Random random_0 = new Random();

	public bool bool_1 = false;

	public static bool forceHttps = false;

	public static string string_2;

	public void FetchAuxiliaryLicensePoliciesAndAdvanceEndpoint()
	{
		if (LicenseRuntimeCoordinator.long_0 < 0L)
		{
			LicenseRuntimeCoordinator.long_0 = 0L;
		}
		try
		{
			FetchAuxiliaryLicensePolicies();
		}
		catch
		{
		}
		LicenseRuntimeCoordinator.remoteEndpointAttemptCount++;
	}

	public void FetchAuxiliaryLicensePolicies()
	{
		while (true)
		{
			if (!CommonUtility.bool_0)
			{
				if (LicenseRuntimeCoordinator.auxiliaryLicensePolicies != null)
				{
					break;
				}
				if (CommonUtility.GetElapsedMilliseconds(authorizationCatalogFetchTicks) <= 1500L)
				{
					Thread.Sleep(150);
					continue;
				}
			}
			authorizationCatalogFetchTicks = CommonUtility.GetCurrentTicks();
			string fetchedCatalogText = FetchRemoteResourceTextAndClearCredentials();
			if (fetchedCatalogText == null || fetchedCatalogText == string.Empty)
			{
				break;
			}
			string decryptedCatalogText = CommonUtility.DecryptRijndaelBase64String(fetchedCatalogText, "10", Encoding.ASCII.GetBytes(CommonUtility.DecodeCharArrayToString(CommonUtility.char_9)));
			string[] catalogLines = decryptedCatalogText.Split('\n', '\r');
			LicenseRuntimeCoordinator.auxiliaryLicensePolicies = new LicenseRuntimeCoordinator.AuxiliaryLicensePolicy[catalogLines.Length];
			int parsedPolicyCount = 0;
			string[] parsingLines = catalogLines;
			foreach (string catalogLine in parsingLines)
			{
				if (catalogLine == null || catalogLine == string.Empty)
				{
					continue;
				}
				if (catalogLine[0] != 'N')
				{
					string[] policyFields = catalogLine.Split('|');
					if (policyFields[0] == null || policyFields[0] == string.Empty)
					{
						continue;
					}
					string machineIdentityText = policyFields[0].Replace(" ", string.Empty);
					LicenseRuntimeCoordinator.auxiliaryLicensePolicies[parsedPolicyCount].machineIdentityHash = CommonUtility.ComputeLegacyStringHash(machineIdentityText);
					LicenseRuntimeCoordinator.auxiliaryLicensePolicies[parsedPolicyCount].authorizationExpirationTicks = 0L;
					if (machineIdentityText != null && machineIdentityText != string.Empty)
					{
						_ = machineIdentityText.Length;
						machineIdentityText = string.Empty;
						for (int j = 0; j < machineIdentityText.Length; j++)
						{
							machineIdentityText += "\0";
						}
					}
					if (policyFields.Length <= 1)
					{
						parsedPolicyCount++;
						continue;
					}
					string[] expirationDateParts = policyFields[1].Split('.', '/', '-');
					if (expirationDateParts.Length == 3)
					{
						int expirationDay = CommonUtility.ParseInt32OrZero(expirationDateParts[0]);
						int expirationMonth = CommonUtility.ParseInt32OrZero(expirationDateParts[1]);
						int expirationYear = CommonUtility.ParseInt32OrZero(expirationDateParts[2]);
						if (0 < expirationDay && expirationDay <= 31 && 0 < expirationMonth && expirationMonth <= 12 && expirationYear > 0)
						{
							LicenseRuntimeCoordinator.auxiliaryLicensePolicies[parsedPolicyCount].authorizationExpirationTicks = new DateTime(expirationYear, expirationMonth, expirationDay, 12, 30, 0, 0).Ticks;
						}
					}
					if (policyFields.Length > 2)
					{
						string[] policyOptionFields = policyFields[2].Split(':');
						if (policyOptionFields.Length > 1)
						{
							LicenseRuntimeCoordinator.auxiliaryLicensePolicies[parsedPolicyCount].string_0 = policyOptionFields[0];
							LicenseRuntimeCoordinator.auxiliaryLicensePolicies[parsedPolicyCount].int_0 = CommonUtility.ParseInt32OrZero(policyOptionFields[1]);
							if (policyOptionFields.Length > 2)
							{
								LicenseRuntimeCoordinator.auxiliaryLicensePolicies[parsedPolicyCount].int_2 = CommonUtility.ParseInt32OrZero(policyOptionFields[2]);
							}
							if (policyOptionFields.Length > 3)
							{
								LicenseRuntimeCoordinator.auxiliaryLicensePolicies[parsedPolicyCount].int_1 = CommonUtility.ParseInt32OrZero(policyOptionFields[3]);
							}
							if (policyOptionFields.Length > 4)
							{
								LicenseRuntimeCoordinator.auxiliaryLicensePolicies[parsedPolicyCount].int_3 = CommonUtility.ParseInt32OrZero(policyOptionFields[4]);
							}
							if (policyOptionFields.Length > 5)
							{
								LicenseRuntimeCoordinator.auxiliaryLicensePolicies[parsedPolicyCount].remoteGameScript = policyOptionFields[5];
							}
						}
						if (policyFields.Length > 3)
						{
							LicenseRuntimeCoordinator.auxiliaryLicensePolicies[parsedPolicyCount].string_1 = policyFields[3];
						}
						parsedPolicyCount++;
					}
					else
					{
						parsedPolicyCount++;
					}
				}
				else
				{
					LicenseRuntimeCoordinator.long_0 = CommonUtility.ParseInt64OrZero(catalogLine.Substring(1));
				}
			}
			if (parsedPolicyCount == 0)
			{
				LicenseRuntimeCoordinator.auxiliaryLicensePolicies = null;
			}
			else if (LicenseRuntimeCoordinator.auxiliaryLicensePolicies.Length > parsedPolicyCount)
			{
				Array.Resize(ref LicenseRuntimeCoordinator.auxiliaryLicensePolicies, parsedPolicyCount);
			}
			break;
		}
		fetchCompleted = true;
	}

	public void FetchAdvertisementCatalog()
	{
		Random jitterRandom = new Random();
		int requestJitterMilliseconds = jitterRandom.Next(100, 400);
		while (true)
		{
			if (!CommonUtility.bool_0 && advertisementFetchTicks > 0L)
			{
				if (AdvertisementAssetLoader.Advertisements != null)
				{
					break;
				}
				if (CommonUtility.GetElapsedMilliseconds(advertisementFetchTicks) <= 150000L)
				{
					Thread.Sleep(150 + requestJitterMilliseconds);
					continue;
				}
			}
			advertisementFetchTicks = CommonUtility.GetCurrentTicks();
			string responseText = FetchRemoteResourceTextAndClearCredentials();
			if (responseText == null || responseText == string.Empty)
			{
				break;
			}
			string[] advertisementEntries = null;
			string[] responseLines = responseText.Split('\n', '\r');
			for (int i = 0; i < responseLines.Length; i++)
			{
				if (responseLines[i] != null && responseLines[i] != string.Empty)
				{
					string[] entryFields = responseLines[i].Split('|');
					int entryFieldCount = entryFields.Length;
					if (entryFieldCount < 2 || entryFields[1] != "1")
					{
					}
					if (advertisementEntries != null)
					{
						Array.Resize(ref advertisementEntries, advertisementEntries.Length + 1);
						advertisementEntries[advertisementEntries.Length - 1] = responseLines[i];
					}
					else
					{
						advertisementEntries = new string[1] { responseLines[i] };
					}
				}
			}
			if (advertisementEntries == null)
			{
				break;
			}
			AdvertisementAssetLoader.SourceEntries = new string[advertisementEntries.Length];
			for (int j = 0; j < advertisementEntries.Length; j++)
			{
				string normalizedSourceEntry = string.Empty;
				if (forceHttps)
				{
					normalizedSourceEntry = advertisementEntries[j].Replace("http://", "https://");
				}
				AdvertisementAssetLoader.SourceEntries[j] = normalizedSourceEntry;
			}
			new Thread(AdvertisementAssetLoader.LoadWithRetries).Start();
			break;
		}
		advertisementFetchTicks = 0L;
		fetchCompleted = true;
	}

	public void FetchHardwareLicensePayload()
	{
		while (true)
		{
			if (!CommonUtility.bool_0 && hardwareLicenseFetchTicks > 0L)
			{
				if (LicenseRuntimeCoordinator.long_3 > 0L)
				{
					break;
				}
				if (CommonUtility.GetElapsedMilliseconds(hardwareLicenseFetchTicks) <= 1500L)
				{
					Thread.Sleep(150);
					continue;
				}
			}
			hardwareLicenseFetchTicks = CommonUtility.GetCurrentTicks();
			string payloadText = FetchRemoteResourceTextAndClearCredentials();
			if (payloadText != null && !(payloadText == string.Empty))
			{
				LicenseRuntimeCoordinator.string_6 = payloadText;
				LicenseRuntimeCoordinator.licenseCoordinatorSignal = 1;
			}
			break;
		}
		fetchCompleted = true;
	}

	public void FetchSupplementalLicensePayload()
	{
		while (true)
		{
			if (!CommonUtility.bool_0 && licenseDataFetchTicks > 0L)
			{
				if (LicenseRuntimeCoordinator.supplementalLicenseExpirationTicks > 0L)
				{
					break;
				}
				if (CommonUtility.GetElapsedMilliseconds(licenseDataFetchTicks) <= 1500L)
				{
					Thread.Sleep(150);
					continue;
				}
			}
			licenseDataFetchTicks = CommonUtility.GetCurrentTicks();
			string encryptedPayloadText = FetchRemoteResourceTextAndClearCredentials();
			if (encryptedPayloadText != null && !(encryptedPayloadText == string.Empty))
			{
				string decryptedPayloadText = CommonUtility.DecryptRijndaelBase64String(encryptedPayloadText, "JXKeoXe", Encoding.ASCII.GetBytes("JXKEOXEUKDKLA5H8"));
				if (decryptedPayloadText != null && !(decryptedPayloadText == string.Empty))
				{
					LicenseRuntimeCoordinator.supplementalLicenseExpirationTicks = LicenseRuntimeCoordinator.licenseState.licenseExpirationTicks;
					LicenseRuntimeCoordinator.licenseCoordinatorSignal = 1;
					LicenseRuntimeCoordinator.string_6 = decryptedPayloadText;
				}
			}
			break;
		}
		fetchCompleted = true;
	}

	public void FetchBaseLicensePayload()
	{
		while (true)
		{
			if (!CommonUtility.bool_0 && licenseDataFetchTicks > 0L)
			{
				if (LicenseRuntimeCoordinator.licenseState.licenseValid)
				{
					break;
				}
				if (CommonUtility.GetElapsedMilliseconds(licenseDataFetchTicks) <= 1500L)
				{
					Thread.Sleep(150);
					continue;
				}
			}
			if (byte_0 == null || byte_0.Length == 0)
			{
				break;
			}
			licenseDataFetchTicks = CommonUtility.GetCurrentTicks();
			string payloadText = FetchRemoteResourceTextAndClearCredentials();
			if (!LicenseRuntimeCoordinator.licenseState.licenseValid && !(payloadText == string.Empty))
			{
				string[] payloadSections = payloadText.Split('$');
				if (payloadSections.Length >= 2)
				{
					string decryptedLicenseText = CommonUtility.DecryptRijndaelBase64String(payloadSections[1], "JXKeoXe", Encoding.ASCII.GetBytes("JXKEOXEUKDKLA5H8"));
					if (decryptedLicenseText != null && !(decryptedLicenseText == string.Empty))
					{
						string[] licenseFields = decryptedLicenseText.Split('|');
						if (licenseFields.Length >= 2)
						{
							if (!licenseFields[0].Contains(licenseFields[1]))
							{
								LicenseRuntimeCoordinator.string_2 = "bang";
								LicenseRuntimeCoordinator.licenseState.encodedAuthorizedMachineList = string.Empty;
								LicenseRuntimeCoordinator.licenseState.licenseFileSuffix = string.Empty;
								LicenseRuntimeCoordinator.licenseState.authorizedMachineHashes = null;
								string authorizedMachineListText = string.Empty;
								authorizedMachineListText = licenseFields[2];
								LicenseRuntimeCoordinator.licenseState.string_0 = licenseFields[1];
								LicenseRuntimeCoordinator.licenseState.string_1 = licenseFields[0];
								LicenseRuntimeCoordinator.licenseState.encodedAuthorizedMachineList = CommonUtility.EncodeBase64Utf8(authorizedMachineListText);
								LicenseRuntimeCoordinator.licenseState.licenseExpirationTicks = CommonUtility.ParseInt64OrZero(licenseFields[3]);
								LicenseRuntimeCoordinator.licenseState.licenseFileSuffix = licenseFields[5];
								LicenseRuntimeCoordinator.licenseState.licensedAccountLimit = CommonUtility.ParseInt32OrZero(licenseFields[4]);
								LicenseRuntimeCoordinator.licenseState.licenseIdentityHash = CommonUtility.ComputeLegacyStringHash(licenseFields[0]);
								LicenseRuntimeCoordinator.multiMachineFeatureFlagText = licenseFields[6];
								LicenseRuntimeCoordinator.selectedGameProfileName = licenseFields[7];
								LicenseRuntimeCoordinator.int_0 = CommonUtility.ParseInt32OrZero(licenseFields[8]);
								LicenseRuntimeCoordinator.licensedAccountLimit = CommonUtility.ParseInt32OrZero(licenseFields[4]);
								if (authorizedMachineListText != null && authorizedMachineListText != string.Empty)
								{
									string[] machineIdentityEntries = authorizedMachineListText.Replace(" ", string.Empty).Replace("-", string.Empty).Split(',', ';');
									LicenseRuntimeCoordinator.licenseState.authorizedMachineHashes = new uint[machineIdentityEntries.Length];
									LicenseRuntimeCoordinator.licenseState.IPList = new string[machineIdentityEntries.Length];
									for (int i = 0; i < machineIdentityEntries.Length; i++)
									{
										LicenseRuntimeCoordinator.licenseState.authorizedMachineHashes[i] = CommonUtility.ComputeLegacyStringHash(machineIdentityEntries[i]);
										LicenseRuntimeCoordinator.licenseState.IPList[i] = machineIdentityEntries[i];
									}
									int sensitiveMachineListLength = authorizedMachineListText.Length;
									authorizedMachineListText = string.Empty;
									for (int j = 0; j < sensitiveMachineListLength; j++)
									{
										authorizedMachineListText += "\0";
									}
									machineIdentityEntries = null;
								}
								LicenseRuntimeCoordinator.licenseState.licenseValid = LicenseRuntimeCoordinator.licenseState.licenseIdentityHash != 0 && LicenseRuntimeCoordinator.licenseState.licenseExpirationTicks > LicenseRuntimeCoordinator.networkTimeTicks && LicenseRuntimeCoordinator.networkTimeTicks > 638082106219996160L;
								LicenseRuntimeCoordinator.string_6 = string.Empty;
								LicenseRuntimeCoordinator.licenseCoordinatorSignal = 1;
								break;
							}
							LicenseRuntimeCoordinator.string_2 = "server";
							LicenseRuntimeCoordinator.licenseState.encodedAuthorizedMachineList = string.Empty;
							LicenseRuntimeCoordinator.licenseState.licenseFileSuffix = string.Empty;
							LicenseRuntimeCoordinator.licenseState.authorizedMachineHashes = null;
							LicenseRuntimeCoordinator.licenseState.string_0 = licenseFields[1];
							string authorizedMachineListText2 = string.Empty;
							authorizedMachineListText2 = licenseFields[2];
							LicenseRuntimeCoordinator.licenseState.string_0 = licenseFields[1];
							LicenseRuntimeCoordinator.licenseState.string_1 = licenseFields[0];
							LicenseRuntimeCoordinator.licenseState.encodedAuthorizedMachineList = CommonUtility.EncodeBase64Utf8(authorizedMachineListText2);
							LicenseRuntimeCoordinator.licenseState.licenseExpirationTicks = CommonUtility.ParseInt64OrZero(licenseFields[3]);
							LicenseRuntimeCoordinator.licenseState.licenseFileSuffix = licenseFields[5];
							LicenseRuntimeCoordinator.licenseState.licensedAccountLimit = CommonUtility.ParseInt32OrZero(licenseFields[4]);
							LicenseRuntimeCoordinator.licenseState.licenseIdentityHash = CommonUtility.ComputeLegacyStringHash(licenseFields[0]);
							LicenseRuntimeCoordinator.multiMachineFeatureFlagText = licenseFields[6];
							LicenseRuntimeCoordinator.selectedGameProfileName = licenseFields[7];
							LicenseRuntimeCoordinator.int_0 = CommonUtility.ParseInt32OrZero(licenseFields[8]);
							LicenseRuntimeCoordinator.licensedAccountLimit = CommonUtility.ParseInt32OrZero(licenseFields[4]);
							if (authorizedMachineListText2 != null && authorizedMachineListText2 != string.Empty)
							{
								string[] machineIdentityEntries2 = authorizedMachineListText2.Replace(" ", string.Empty).Replace("-", string.Empty).Split(',', ';');
								LicenseRuntimeCoordinator.licenseState.authorizedMachineHashes = new uint[machineIdentityEntries2.Length];
								LicenseRuntimeCoordinator.licenseState.IPList = new string[machineIdentityEntries2.Length];
								for (int k = 0; k < machineIdentityEntries2.Length; k++)
								{
									LicenseRuntimeCoordinator.licenseState.authorizedMachineHashes[k] = CommonUtility.ComputeLegacyStringHash(machineIdentityEntries2[k]);
									LicenseRuntimeCoordinator.licenseState.IPList[k] = machineIdentityEntries2[k];
								}
								int sensitiveMachineListLength2 = authorizedMachineListText2.Length;
								authorizedMachineListText2 = string.Empty;
								for (int l = 0; l < sensitiveMachineListLength2; l++)
								{
									authorizedMachineListText2 += "\0";
								}
								machineIdentityEntries2 = null;
							}
							LicenseRuntimeCoordinator.licenseState.licenseValid = LicenseRuntimeCoordinator.licenseState.licenseIdentityHash != 0 && LicenseRuntimeCoordinator.licenseState.licenseExpirationTicks > LicenseRuntimeCoordinator.networkTimeTicks && LicenseRuntimeCoordinator.networkTimeTicks > 638082106219996160L;
							LicenseRuntimeCoordinator.string_6 = string.Empty;
							LicenseRuntimeCoordinator.licenseCoordinatorSignal = 1;
							break;
						}
					}
				}
			}
			if (payloadText != string.Empty && payloadText != null)
			{
				int payloadTextLength = payloadText.Length;
				payloadText = string.Empty;
				for (int m = 0; m < payloadTextLength; m++)
				{
					payloadText += "\0";
				}
			}
			break;
		}
		fetchCompleted = true;
		byte_0 = null;
	}

	public void FetchVersionMetadata()
	{
		while (!CommonUtility.bool_0 && versionInfoFetchTicks > 0L && CommonUtility.GetElapsedMilliseconds(versionInfoFetchTicks) <= 1500L)
		{
			Thread.Sleep(150);
		}
		versionInfoFetchTicks = CommonUtility.GetCurrentTicks();
		string responseText = FetchRemoteResourceTextAndClearCredentials();
		string[] versionFields;
		if (responseText != null && !(responseText == string.Empty))
		{
			versionFields = responseText.Split('|');
			string fetchedVersionDigits = versionFields[0].Replace(".", "");
			if (CommonUtility.ParseInt32OrZero(fetchedVersionDigits) > 0)
			{
				if (LicenseRuntimeCoordinator.latestVersionText == null || !(LicenseRuntimeCoordinator.latestVersionText != string.Empty))
				{
					goto IL_016a;
				}
				string currentVersionDigits = LicenseRuntimeCoordinator.latestVersionText.Replace(".", "");
				while (currentVersionDigits.Length != fetchedVersionDigits.Length)
				{
					if (currentVersionDigits.Length < fetchedVersionDigits.Length)
					{
						currentVersionDigits += "0";
					}
					else
					{
						fetchedVersionDigits += "0";
					}
				}
				int currentVersionNumber = CommonUtility.ParseInt32OrZero(currentVersionDigits);
				int fetchedVersionNumber = CommonUtility.ParseInt32OrZero(fetchedVersionDigits);
				if (fetchedVersionNumber >= currentVersionNumber)
				{
					if (fetchedVersionNumber != currentVersionNumber)
					{
						goto IL_016a;
					}
					if (versionFields.Length > 1 && versionFields[1] != string.Empty && versionFields[1] != null)
					{
						LicenseRuntimeCoordinator.importantNoticeText = versionFields[1];
					}
				}
			}
		}
		goto IL_019f;
		IL_016a:
		LicenseRuntimeCoordinator.latestVersionText = versionFields[0];
		LicenseRuntimeCoordinator.string_3 = versionFields[0];
		if (versionFields.Length > 1 && versionFields[1] != string.Empty && versionFields[1] != null)
		{
			LicenseRuntimeCoordinator.importantNoticeText = versionFields[1];
		}
		goto IL_019f;
		IL_019f:
		fetchCompleted = true;
	}

	public void method_7()
	{
		try
		{
		}
		catch
		{
		}
	}

	private string FetchRemoteResourceTextAndClearCredentials()
	{
		string responseText = string.Empty;
		if (baseUrl != null && !(baseUrl == string.Empty))
		{
			try
			{
				string resourcePath = resourcePathSource.ToString();
				string resourcePathSourceTypeName = resourcePathSource.GetType().ToString().ToUpper();
				if (resourcePathSourceTypeName.IndexOf(CommonUtility.DecodeLengthShiftedString(CommonUtility.string_12)) > 0)
				{
					resourcePath = string.Concat((char[])resourcePathSource);
				}
				if (resourcePath[0] > 'ÿ')
				{
					resourcePath = CommonUtility.DecodeLengthShiftedString(resourcePath);
				}
				if ((byte)resourcePath[0] != 47)
				{
					resourcePath = "/" + resourcePath;
				}
				if ((ProbeWindowsProductNameAndReturnLegacyLabel() != string.Empty && ProbeWindowsProductNameAndReturnLegacyLabel().Contains("Windows 10")) || (ProbeWindowsProductNameAndReturnLegacyLabel() != string.Empty && ProbeWindowsProductNameAndReturnLegacyLabel().Contains("Windows 11")))
				{
					forceHttps = true;
					baseUrl = baseUrl.Replace("http://", "https://");
				}
				Uri resourceUri = new Uri(baseUrl + resourcePath);
				if (resourceUri.Host != null && !(resourceUri.Host == string.Empty))
				{
					string hostName = resourceUri.Host.ToLower();
					if (hostName != null && !(hostName == string.Empty))
					{
						WebClient client = new WebClient();
						if ((ProbeWindowsProductNameAndReturnLegacyLabel() != string.Empty && ProbeWindowsProductNameAndReturnLegacyLabel().Contains("Windows 10")) || (ProbeWindowsProductNameAndReturnLegacyLabel() != string.Empty && ProbeWindowsProductNameAndReturnLegacyLabel().Contains("Windows 11")))
						{
							forceHttps = true;
							ServicePointManager.ServerCertificateValidationCallback = (object _003Cp0_003E, X509Certificate _003Cp1_003E, X509Chain _003Cp2_003E, SslPolicyErrors _003Cp3_003E) => true;
                            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072 | (SecurityProtocolType)768 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
                            client.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.140 Safari/537.36 Edge/17.17134");
						}
						byte[] responseBytes = null;
						if (baseUrl[0] != 'f' && baseUrl[0] != 'F')
						{
							responseBytes = client.DownloadData(resourceUri);
						}
						else
						{
							if (credentialUserName != null && credentialUserName != string.Empty && credentialUserName[0] > 'ÿ')
							{
								credentialUserName = CommonUtility.DecodeLengthShiftedString(credentialUserName);
							}
							client.Credentials = new NetworkCredential(credentialUserName, credentialPassword);
							responseBytes = client.DownloadData(resourceUri);
						}
						if (responseBytes != null)
						{
							responseText = Encoding.UTF8.GetString(responseBytes, 0, responseBytes.Length);
						}
						client.CancelAsync();
						client.Dispose();
					}
				}
			}
			catch (Exception)
			{
			}
		}
		if (credentialUserName != string.Empty && credentialUserName != null)
		{
			int credentialUserNameLength = credentialUserName.Length;
			credentialUserName = string.Empty;
			for (int wipeIndex = 0; wipeIndex < credentialUserNameLength; wipeIndex++)
			{
				credentialUserName += "\0";
			}
		}
		credentialPassword = null;
		credentialUserName = null;
		return responseText;
	}

	private static string ProbeWindowsProductNameAndReturnLegacyLabel()
	{
		try
		{
			RegistryKey currentVersionKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion");
			_ = (string)currentVersionKey.GetValue("ProductName");
			return "Windows 7";
		}
		catch
		{
			return string.Empty;
		}
	}
}
