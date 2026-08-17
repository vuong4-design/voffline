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

	public void method_0()
	{
		if (LicenseRuntimeCoordinator.long_0 < 0L)
		{
			LicenseRuntimeCoordinator.long_0 = 0L;
		}
		try
		{
			method_1();
		}
		catch
		{
		}
		LicenseRuntimeCoordinator.int_1++;
	}

	public void method_1()
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
			string text = FetchRemoteResourceTextAndClearCredentials();
			if (text == null || text == string.Empty)
			{
				break;
			}
			string text2 = CommonUtility.DecryptRijndaelBase64String(text, "10", Encoding.ASCII.GetBytes(CommonUtility.DecodeCharArrayToString(CommonUtility.char_9)));
			string[] array = text2.Split('\n', '\r');
			LicenseRuntimeCoordinator.auxiliaryLicensePolicies = new LicenseRuntimeCoordinator.AuxiliaryLicensePolicy[array.Length];
			int num = 0;
			string[] array2 = array;
			foreach (string text3 in array2)
			{
				if (text3 == null || text3 == string.Empty)
				{
					continue;
				}
				if (text3[0] != 'N')
				{
					string[] array3 = text3.Split('|');
					if (array3[0] == null || array3[0] == string.Empty)
					{
						continue;
					}
					string text4 = array3[0].Replace(" ", string.Empty);
					LicenseRuntimeCoordinator.auxiliaryLicensePolicies[num].machineIdentityHash = CommonUtility.ComputeLegacyStringHash(text4);
					LicenseRuntimeCoordinator.auxiliaryLicensePolicies[num].authorizationExpirationTicks = 0L;
					if (text4 != null && text4 != string.Empty)
					{
						_ = text4.Length;
						text4 = string.Empty;
						for (int j = 0; j < text4.Length; j++)
						{
							text4 += "\0";
						}
					}
					if (array3.Length <= 1)
					{
						num++;
						continue;
					}
					string[] array4 = array3[1].Split('.', '/', '-');
					if (array4.Length == 3)
					{
						int num2 = CommonUtility.ParseInt32OrZero(array4[0]);
						int num3 = CommonUtility.ParseInt32OrZero(array4[1]);
						int num4 = CommonUtility.ParseInt32OrZero(array4[2]);
						if (0 < num2 && num2 <= 31 && 0 < num3 && num3 <= 12 && num4 > 0)
						{
							LicenseRuntimeCoordinator.auxiliaryLicensePolicies[num].authorizationExpirationTicks = new DateTime(num4, num3, num2, 12, 30, 0, 0).Ticks;
						}
					}
					if (array3.Length > 2)
					{
						string[] array5 = array3[2].Split(':');
						if (array5.Length > 1)
						{
							LicenseRuntimeCoordinator.auxiliaryLicensePolicies[num].string_0 = array5[0];
							LicenseRuntimeCoordinator.auxiliaryLicensePolicies[num].int_0 = CommonUtility.ParseInt32OrZero(array5[1]);
							if (array5.Length > 2)
							{
								LicenseRuntimeCoordinator.auxiliaryLicensePolicies[num].int_2 = CommonUtility.ParseInt32OrZero(array5[2]);
							}
							if (array5.Length > 3)
							{
								LicenseRuntimeCoordinator.auxiliaryLicensePolicies[num].int_1 = CommonUtility.ParseInt32OrZero(array5[3]);
							}
							if (array5.Length > 4)
							{
								LicenseRuntimeCoordinator.auxiliaryLicensePolicies[num].int_3 = CommonUtility.ParseInt32OrZero(array5[4]);
							}
							if (array5.Length > 5)
							{
								LicenseRuntimeCoordinator.auxiliaryLicensePolicies[num].remoteGameScript = array5[5];
							}
						}
						if (array3.Length > 3)
						{
							LicenseRuntimeCoordinator.auxiliaryLicensePolicies[num].string_1 = array3[3];
						}
						num++;
					}
					else
					{
						num++;
					}
				}
				else
				{
					LicenseRuntimeCoordinator.long_0 = CommonUtility.ParseInt64OrZero(text3.Substring(1));
				}
			}
			if (num == 0)
			{
				LicenseRuntimeCoordinator.auxiliaryLicensePolicies = null;
			}
			else if (LicenseRuntimeCoordinator.auxiliaryLicensePolicies.Length > num)
			{
				Array.Resize(ref LicenseRuntimeCoordinator.auxiliaryLicensePolicies, num);
			}
			break;
		}
		fetchCompleted = true;
	}

	public void method_2()
	{
		Random random = new Random();
		int num = random.Next(100, 400);
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
					Thread.Sleep(150 + num);
					continue;
				}
			}
			advertisementFetchTicks = CommonUtility.GetCurrentTicks();
			string text = FetchRemoteResourceTextAndClearCredentials();
			if (text == null || text == string.Empty)
			{
				break;
			}
			string[] array = null;
			string[] array2 = text.Split('\n', '\r');
			for (int i = 0; i < array2.Length; i++)
			{
				if (array2[i] != null && array2[i] != string.Empty)
				{
					string[] array3 = array2[i].Split('|');
					int num2 = array3.Length;
					if (num2 < 2 || array3[1] != "1")
					{
					}
					if (array != null)
					{
						Array.Resize(ref array, array.Length + 1);
						array[array.Length - 1] = array2[i];
					}
					else
					{
						array = new string[1] { array2[i] };
					}
				}
			}
			if (array == null)
			{
				break;
			}
			AdvertisementAssetLoader.SourceEntries = new string[array.Length];
			for (int j = 0; j < array.Length; j++)
			{
				string text2 = string.Empty;
				if (forceHttps)
				{
					text2 = array[j].Replace("http://", "https://");
				}
				AdvertisementAssetLoader.SourceEntries[j] = text2;
			}
			new Thread(AdvertisementAssetLoader.LoadWithRetries).Start();
			break;
		}
		advertisementFetchTicks = 0L;
		fetchCompleted = true;
	}

	public void method_3()
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
			string text = FetchRemoteResourceTextAndClearCredentials();
			if (text != null && !(text == string.Empty))
			{
				LicenseRuntimeCoordinator.string_6 = text;
				LicenseRuntimeCoordinator.int_2 = 1;
			}
			break;
		}
		fetchCompleted = true;
	}

	public void method_4()
	{
		while (true)
		{
			if (!CommonUtility.bool_0 && licenseDataFetchTicks > 0L)
			{
				if (LicenseRuntimeCoordinator.long_2 > 0L)
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
			string text = FetchRemoteResourceTextAndClearCredentials();
			if (text != null && !(text == string.Empty))
			{
				string text2 = CommonUtility.DecryptRijndaelBase64String(text, "JXKeoXe", Encoding.ASCII.GetBytes("JXKEOXEUKDKLA5H8"));
				if (text2 != null && !(text2 == string.Empty))
				{
					LicenseRuntimeCoordinator.long_2 = LicenseRuntimeCoordinator.licenseState.licenseExpirationTicks;
					LicenseRuntimeCoordinator.int_2 = 1;
					LicenseRuntimeCoordinator.string_6 = text2;
				}
			}
			break;
		}
		fetchCompleted = true;
	}

	public void method_5()
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
			string text = FetchRemoteResourceTextAndClearCredentials();
			if (!LicenseRuntimeCoordinator.licenseState.licenseValid && !(text == string.Empty))
			{
				string[] array = text.Split('$');
				if (array.Length >= 2)
				{
					string text2 = CommonUtility.DecryptRijndaelBase64String(array[1], "JXKeoXe", Encoding.ASCII.GetBytes("JXKEOXEUKDKLA5H8"));
					if (text2 != null && !(text2 == string.Empty))
					{
						string[] array2 = text2.Split('|');
						if (array2.Length >= 2)
						{
							if (!array2[0].Contains(array2[1]))
							{
								LicenseRuntimeCoordinator.string_2 = "bang";
								LicenseRuntimeCoordinator.licenseState.encodedAuthorizedMachineList = string.Empty;
								LicenseRuntimeCoordinator.licenseState.licenseFileSuffix = string.Empty;
								LicenseRuntimeCoordinator.licenseState.authorizedMachineHashes = null;
								string empty = string.Empty;
								empty = array2[2];
								LicenseRuntimeCoordinator.licenseState.string_0 = array2[1];
								LicenseRuntimeCoordinator.licenseState.string_1 = array2[0];
								LicenseRuntimeCoordinator.licenseState.encodedAuthorizedMachineList = CommonUtility.EncodeBase64Utf8(empty);
								LicenseRuntimeCoordinator.licenseState.licenseExpirationTicks = CommonUtility.ParseInt64OrZero(array2[3]);
								LicenseRuntimeCoordinator.licenseState.licenseFileSuffix = array2[5];
								LicenseRuntimeCoordinator.licenseState.licensedAccountLimit = CommonUtility.ParseInt32OrZero(array2[4]);
								LicenseRuntimeCoordinator.licenseState.licenseIdentityHash = CommonUtility.ComputeLegacyStringHash(array2[0]);
								LicenseRuntimeCoordinator.string_1 = array2[6];
								LicenseRuntimeCoordinator.selectedGameProfileName = array2[7];
								LicenseRuntimeCoordinator.int_0 = CommonUtility.ParseInt32OrZero(array2[8]);
								LicenseRuntimeCoordinator.int_7 = CommonUtility.ParseInt32OrZero(array2[4]);
								if (empty != null && empty != string.Empty)
								{
									string[] array3 = empty.Replace(" ", string.Empty).Replace("-", string.Empty).Split(',', ';');
									LicenseRuntimeCoordinator.licenseState.authorizedMachineHashes = new uint[array3.Length];
									LicenseRuntimeCoordinator.licenseState.IPList = new string[array3.Length];
									for (int i = 0; i < array3.Length; i++)
									{
										LicenseRuntimeCoordinator.licenseState.authorizedMachineHashes[i] = CommonUtility.ComputeLegacyStringHash(array3[i]);
										LicenseRuntimeCoordinator.licenseState.IPList[i] = array3[i];
									}
									int length = empty.Length;
									empty = string.Empty;
									for (int j = 0; j < length; j++)
									{
										empty += "\0";
									}
									array3 = null;
								}
								LicenseRuntimeCoordinator.licenseState.licenseValid = LicenseRuntimeCoordinator.licenseState.licenseIdentityHash != 0 && LicenseRuntimeCoordinator.licenseState.licenseExpirationTicks > LicenseRuntimeCoordinator.networkTimeTicks && LicenseRuntimeCoordinator.networkTimeTicks > 638082106219996160L;
								LicenseRuntimeCoordinator.string_6 = string.Empty;
								LicenseRuntimeCoordinator.int_2 = 1;
								break;
							}
							LicenseRuntimeCoordinator.string_2 = "server";
							LicenseRuntimeCoordinator.licenseState.encodedAuthorizedMachineList = string.Empty;
							LicenseRuntimeCoordinator.licenseState.licenseFileSuffix = string.Empty;
							LicenseRuntimeCoordinator.licenseState.authorizedMachineHashes = null;
							LicenseRuntimeCoordinator.licenseState.string_0 = array2[1];
							string empty2 = string.Empty;
							empty2 = array2[2];
							LicenseRuntimeCoordinator.licenseState.string_0 = array2[1];
							LicenseRuntimeCoordinator.licenseState.string_1 = array2[0];
							LicenseRuntimeCoordinator.licenseState.encodedAuthorizedMachineList = CommonUtility.EncodeBase64Utf8(empty2);
							LicenseRuntimeCoordinator.licenseState.licenseExpirationTicks = CommonUtility.ParseInt64OrZero(array2[3]);
							LicenseRuntimeCoordinator.licenseState.licenseFileSuffix = array2[5];
							LicenseRuntimeCoordinator.licenseState.licensedAccountLimit = CommonUtility.ParseInt32OrZero(array2[4]);
							LicenseRuntimeCoordinator.licenseState.licenseIdentityHash = CommonUtility.ComputeLegacyStringHash(array2[0]);
							LicenseRuntimeCoordinator.string_1 = array2[6];
							LicenseRuntimeCoordinator.selectedGameProfileName = array2[7];
							LicenseRuntimeCoordinator.int_0 = CommonUtility.ParseInt32OrZero(array2[8]);
							LicenseRuntimeCoordinator.int_7 = CommonUtility.ParseInt32OrZero(array2[4]);
							if (empty2 != null && empty2 != string.Empty)
							{
								string[] array4 = empty2.Replace(" ", string.Empty).Replace("-", string.Empty).Split(',', ';');
								LicenseRuntimeCoordinator.licenseState.authorizedMachineHashes = new uint[array4.Length];
								LicenseRuntimeCoordinator.licenseState.IPList = new string[array4.Length];
								for (int k = 0; k < array4.Length; k++)
								{
									LicenseRuntimeCoordinator.licenseState.authorizedMachineHashes[k] = CommonUtility.ComputeLegacyStringHash(array4[k]);
									LicenseRuntimeCoordinator.licenseState.IPList[k] = array4[k];
								}
								int length2 = empty2.Length;
								empty2 = string.Empty;
								for (int l = 0; l < length2; l++)
								{
									empty2 += "\0";
								}
								array4 = null;
							}
							LicenseRuntimeCoordinator.licenseState.licenseValid = LicenseRuntimeCoordinator.licenseState.licenseIdentityHash != 0 && LicenseRuntimeCoordinator.licenseState.licenseExpirationTicks > LicenseRuntimeCoordinator.networkTimeTicks && LicenseRuntimeCoordinator.networkTimeTicks > 638082106219996160L;
							LicenseRuntimeCoordinator.string_6 = string.Empty;
							LicenseRuntimeCoordinator.int_2 = 1;
							break;
						}
					}
				}
			}
			if (text != string.Empty && text != null)
			{
				int length3 = text.Length;
				text = string.Empty;
				for (int m = 0; m < length3; m++)
				{
					text += "\0";
				}
			}
			break;
		}
		fetchCompleted = true;
		byte_0 = null;
	}

	public void method_6()
	{
		while (!CommonUtility.bool_0 && versionInfoFetchTicks > 0L && CommonUtility.GetElapsedMilliseconds(versionInfoFetchTicks) <= 1500L)
		{
			Thread.Sleep(150);
		}
		versionInfoFetchTicks = CommonUtility.GetCurrentTicks();
		string text = FetchRemoteResourceTextAndClearCredentials();
		string[] array;
		if (text != null && !(text == string.Empty))
		{
			array = text.Split('|');
			string text2 = array[0].Replace(".", "");
			if (CommonUtility.ParseInt32OrZero(text2) > 0)
			{
				if (LicenseRuntimeCoordinator.latestVersionText == null || !(LicenseRuntimeCoordinator.latestVersionText != string.Empty))
				{
					goto IL_016a;
				}
				string text3 = LicenseRuntimeCoordinator.latestVersionText.Replace(".", "");
				while (text3.Length != text2.Length)
				{
					if (text3.Length < text2.Length)
					{
						text3 += "0";
					}
					else
					{
						text2 += "0";
					}
				}
				int num = CommonUtility.ParseInt32OrZero(text3);
				int num2 = CommonUtility.ParseInt32OrZero(text2);
				if (num2 >= num)
				{
					if (num2 != num)
					{
						goto IL_016a;
					}
					if (array.Length > 1 && array[1] != string.Empty && array[1] != null)
					{
						LicenseRuntimeCoordinator.importantNoticeText = array[1];
					}
				}
			}
		}
		goto IL_019f;
		IL_016a:
		LicenseRuntimeCoordinator.latestVersionText = array[0];
		LicenseRuntimeCoordinator.string_3 = array[0];
		if (array.Length > 1 && array[1] != string.Empty && array[1] != null)
		{
			LicenseRuntimeCoordinator.importantNoticeText = array[1];
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
		string result = string.Empty;
		if (baseUrl != null && !(baseUrl == string.Empty))
		{
			try
			{
				string text = resourcePathSource.ToString();
				string text2 = resourcePathSource.GetType().ToString().ToUpper();
				if (text2.IndexOf(CommonUtility.DecodeLengthShiftedString(CommonUtility.string_12)) > 0)
				{
					text = string.Concat((char[])resourcePathSource);
				}
				if (text[0] > 'ÿ')
				{
					text = CommonUtility.DecodeLengthShiftedString(text);
				}
				if ((byte)text[0] != 47)
				{
					text = "/" + text;
				}
				if ((ProbeWindowsProductNameAndReturnLegacyLabel() != string.Empty && ProbeWindowsProductNameAndReturnLegacyLabel().Contains("Windows 10")) || (ProbeWindowsProductNameAndReturnLegacyLabel() != string.Empty && ProbeWindowsProductNameAndReturnLegacyLabel().Contains("Windows 11")))
				{
					forceHttps = true;
					baseUrl = baseUrl.Replace("http://", "https://");
				}
				Uri uri = new Uri(baseUrl + text);
				if (uri.Host != null && !(uri.Host == string.Empty))
				{
					string text3 = uri.Host.ToLower();
					if (text3 != null && !(text3 == string.Empty))
					{
						WebClient webClient = new WebClient();
						if ((ProbeWindowsProductNameAndReturnLegacyLabel() != string.Empty && ProbeWindowsProductNameAndReturnLegacyLabel().Contains("Windows 10")) || (ProbeWindowsProductNameAndReturnLegacyLabel() != string.Empty && ProbeWindowsProductNameAndReturnLegacyLabel().Contains("Windows 11")))
						{
							forceHttps = true;
							ServicePointManager.ServerCertificateValidationCallback = (object _003Cp0_003E, X509Certificate _003Cp1_003E, X509Chain _003Cp2_003E, SslPolicyErrors _003Cp3_003E) => true;
                            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072 | (SecurityProtocolType)768 | SecurityProtocolType.Tls | SecurityProtocolType.Ssl3;
                            webClient.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/64.0.3282.140 Safari/537.36 Edge/17.17134");
						}
						byte[] array = null;
						if (baseUrl[0] != 'f' && baseUrl[0] != 'F')
						{
							array = webClient.DownloadData(uri);
						}
						else
						{
							if (credentialUserName != null && credentialUserName != string.Empty && credentialUserName[0] > 'ÿ')
							{
								credentialUserName = CommonUtility.DecodeLengthShiftedString(credentialUserName);
							}
							webClient.Credentials = new NetworkCredential(credentialUserName, credentialPassword);
							array = webClient.DownloadData(uri);
						}
						if (array != null)
						{
							result = Encoding.UTF8.GetString(array, 0, array.Length);
						}
						webClient.CancelAsync();
						webClient.Dispose();
					}
				}
			}
			catch (Exception)
			{
			}
		}
		if (credentialUserName != string.Empty && credentialUserName != null)
		{
			int length = credentialUserName.Length;
			credentialUserName = string.Empty;
			for (int num = 0; num < length; num++)
			{
				credentialUserName += "\0";
			}
		}
		credentialPassword = null;
		credentialUserName = null;
		return result;
	}

	private static string ProbeWindowsProductNameAndReturnLegacyLabel()
	{
		try
		{
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion");
			_ = (string)registryKey.GetValue("ProductName");
			return "Windows 7";
		}
		catch
		{
			return string.Empty;
		}
	}
}
