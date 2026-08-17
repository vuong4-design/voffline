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

public class GClass1
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

	public static string string_1 = null;

	public static string string_2 = null;

	public static int int_0 = 0;

	public static long long_0 = -1L;

	public static int int_1 = 0;

	public static AuxiliaryLicensePolicy[] gstruct16_0 = null;

	public static int int_2 = 0;

	public static bool bool_0 = false;

	public static long networkTimeTicks = 0L;

	public static bool bool_1 = false;

	public static string string_3 = null;

	public static string latestVersionText = null;

	public static string importantNoticeText = null;

	public static long long_2 = 0L;

	public static long long_3 = 0L;

	public static int int_3 = 0;

	public static LicenseState gstruct15_0 = default(LicenseState);

	public static int int_4 = 0;

	public static MapTravelConnection[] gstruct28_0 = null;

	public static int int_5 = -1;

	public static int int_6 = 0;

	public static int int_7 = 1000;

	public static string string_6 = string.Empty;

	public static bool bool_2 = false;

	public static string string_7 = "\\script\\allowauto.lua";

	public static string string_8 = "RecvResult";

	public static string string_9 = "d";

	public static void RunLicenseAndVersionCoordinationLoop()
	{
		byte[] array = null;
		int int_ = 0;
		byte[] array2 = new byte[4];
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		NetworkTimeUpdater[] array3 = null;
		RemoteResourceFetchWorker[] array4 = null;
		RemoteResourceFetchWorker[] array5 = null;
		RemoteResourceFetchWorker[] array6 = null;
		RemoteResourceFetchWorker[] array7 = null;
		RemoteResourceFetchWorker[] array8 = null;
		long num9 = 0L;
		while (true)
		{
			gstruct15_0 = new LicenseState
			{
				string_0 = null,
				string_1 = null,
				licenseValid = false,
				licenseFileSuffix = string.Empty,
				licenseExpirationTicks = 0L,
				licensedAccountLimit = 0,
				licenseIdentityHash = 0u
			};
			int_4 = 0;
			num6 = 0;
			num7 = 0;
			long_2 = 0L;
			int_2 = 0;
			while (true)
			{
				Thread.Sleep(1300);
				if (CommonUtility.bool_0)
				{
					return;
				}
				if (int_2 == 2)
				{
					break;
				}
				num--;
				if (num <= 0)
				{
					bool_1 = bool_1 || smethod_2();
					num = 1800;
				}
				if (!Form1.mainRuntimeInitialized || CommonUtility.uint_0 == 0)
				{
					continue;
				}
				if (bool_1)
				{
					Form1.characterAccountConfig_1 = null;
					continue;
				}
				int num10 = CommonUtility.int_1;
				uint uint_ = CommonUtility.uint_0;
				if (array3 == null || array == null)
				{
					array = new byte[8];
					array3 = new NetworkTimeUpdater[RemoteEndpointCatalog.EncodedTimeServers.Length];
					int num11 = RemoteEndpointCatalog.DownloadBaseUrls.Length;
					array4 = new RemoteResourceFetchWorker[num11];
					array5 = new RemoteResourceFetchWorker[num11];
					array6 = new RemoteResourceFetchWorker[num11];
					array7 = new RemoteResourceFetchWorker[num11];
					array8 = new RemoteResourceFetchWorker[num11];
					// HardwareLicenseIdentity.InitializeHardwareIdentity(); // License check removed
					long_3 = 0L;
					string text = ReadAndClearLengthPrefixedProcessString(num10, uint_ + 256);
					text = CommonUtility.DecodeLengthShiftedString(ReadAndClearLengthPrefixedProcessString(num10, uint_ + 768));
					if (text != string.Empty)
					{
						array = Encoding.ASCII.GetBytes(text);
					}
					uint num12 = uint_ + 1024 + 8;
					WindowsInteropHelper.ReadProcessMemory(num10, num12, array2, 4, ref int_);
					int num13 = BitConverter.ToInt32(array2, 0);
					if (num13 > 0)
					{
						text = ReadAndClearLengthPrefixedProcessString(num10, num12, bool_3: true);
						CommonUtility.long_0 = CommonUtility.ParseInt64OrZero(text);
					}
				}
				if (num3 == 0)
				{
					num3 = 1;
					if (num7 == 0)
					{
						CommonUtility.string_17 = new string[1] { "Đang kiểm tra phiên bản, xin chờ chút xíu..." };
					}
					else
					{
						CommonUtility.string_17 = new string[1] { "Đang thử kiểm tra phiên bản lần thứ " + (num3 + 1) };
					}
					for (int i = 0; i < array4.Length; i++)
					{
						array4[i] = new RemoteResourceFetchWorker
						{
							resourcePathSource = "KYKeoxe.txt",
							baseUrl = RemoteEndpointCatalog.DownloadBaseUrls[i],
							fetchCompleted = false,
							int_0 = i + 1
						};
						new Thread(array4[i].method_6).Start();
					}
					Thread.Sleep(800);
				}
				if (num3 == 1 || num3 == -1)
				{
					if (latestVersionText == null || latestVersionText == string.Empty)
					{
						if (num3 == -1)
						{
							if (num7 < 3)
							{
								num7++;
								num3 = 0;
								continue;
							}
							if (bool_0)
							{
								num3 = 2;
								continue;
							}
							CommonUtility.string_17 = new string[1] { "Không thể kiểm tra phiên bản. Qua phụ trợ bấm cập nhật auto mới." };
							return;
						}
						int num14 = array4.Length;
						for (int j = 0; j < array4.Length; j++)
						{
							if (array4[j] == null || array4[j].fetchCompleted)
							{
								num14--;
							}
						}
						if (num14 <= 0)
						{
							num3 = -1;
						}
						continue;
					}
					num3 = 2;
				}
				switch (num3)
				{
				case 3:
					if (CommonUtility.GetElapsedMilliseconds(num9) > 43200000L)
					{
						num3 = 0;
						num9 = 0L;
					}
					break;
				case 2:
					CommonUtility.AppendStringIfMissing(ref CommonUtility.string_17, CommonUtility.DecodeCharArrayToString(CommonUtility.char_22));
					int_2 = 1;
					bool_0 = true;
					num3 = 3;
					num7 = 0;
					num9 = CommonUtility.GetCurrentTicks();
					break;
				}
				num2--;
				if (num2 <= 0 && (bool_0 || num3 == 3))
				{
					for (int k = 0; k < array3.Length; k++)
					{
						array3[k] = new NetworkTimeUpdater
						{
							TimeServer = RemoteEndpointCatalog.EncodedTimeServers[k]
						};
						networkTimeTicks = DateTime.Now.Ticks;
						new Thread(array3[k].Update).Start();
						Thread.Sleep(150);
					}
					num2 = 1800;
					if (gstruct15_0.licenseValid)
					{
						gstruct15_0.licenseValid = gstruct15_0.licenseFileSuffix != string.Empty && gstruct15_0.licenseIdentityHash != 0 && gstruct15_0.licenseExpirationTicks > networkTimeTicks && networkTimeTicks > 636758336219996160L;
						int_2 = 1;
					}
				}
				if (networkTimeTicks <= 0L)
				{
					if (num2 > 100)
					{
						num2 = 100;
					}
					continue;
				}
				if (num5 == 0 && HardwareLicenseIdentity.string_0 != string.Empty && HardwareLicenseIdentity.bool_0)
				{
					num5 = 1;
					string text2 = CommonUtility.DecodeLengthShiftedString(CommonUtility.string_5);
					string text3 = CommonUtility.DecodeLengthShiftedString(string.Concat(CommonUtility.char_12));
					string object_ = "hdd/" + HardwareLicenseIdentity.string_2 + text2 + HardwareLicenseIdentity.long_0 + text3;
					for (int l = 0; l < array5.Length; l++)
					{
						array5[l] = new RemoteResourceFetchWorker
						{
							resourcePathSource = object_,
							baseUrl = RemoteEndpointCatalog.DownloadBaseUrls[l],
							fetchCompleted = false,
							int_0 = l + 1
						};
						new Thread(array5[l].method_3).Start();
					}
					Thread.Sleep(800);
				}
				if (int_4 == 0 && gstruct15_0.licenseFileSuffix == string.Empty)
				{
					int_4 = 1;
					string object_2 = "license/" + Form1.usageId + ".txt";
					if (Form1.usageId.IndexOf(Form1.defaultUsageIdPlaceholder) != 0)
					{
						for (int m = 0; m < array6.Length; m++)
						{
							array6[m] = new RemoteResourceFetchWorker
							{
								resourcePathSource = object_2,
								baseUrl = RemoteEndpointCatalog.DownloadBaseUrls[m],
								fetchCompleted = false,
								int_0 = m + 1,
								byte_0 = array
							};
							new Thread(array6[m].method_5).Start();
						}
					}
					Thread.Sleep(800);
				}
				if (int_4 == 1)
				{
					bool flag = false;
					for (int n = 0; n < array6.Length; n++)
					{
						if (array6[n] != null && !array6[n].fetchCompleted)
						{
							flag = true;
							break;
						}
					}
					if (!flag || gstruct15_0.licenseIdentityHash != 0)
					{
						int_4 = 2;
						int_2 = 1;
					}
				}
				if (num6 == 0 && long_2 <= 0L && gstruct15_0.licenseFileSuffix != string.Empty && gstruct15_0.licenseValid)
				{
					num6 = 1;
					string object_3 = "license/" + Form1.usageId + "_" + gstruct15_0.licenseFileSuffix + ".txt";
					for (int num15 = 0; num15 < array7.Length; num15++)
					{
						array7[num15] = new RemoteResourceFetchWorker
						{
							resourcePathSource = object_3,
							baseUrl = RemoteEndpointCatalog.DownloadBaseUrls[num15],
							fetchCompleted = false,
							int_0 = num15 + 1
						};
						new Thread(array7[num15].method_4).Start();
					}
					Thread.Sleep(1500);
				}
				if (num8 < 3)
				{
					num8++;
					continue;
				}
				if (num8 < 20)
				{
					num8++;
					continue;
				}
				if (num4 <= 0)
				{
					num4 = 600;
					for (int num16 = 0; num16 < array8.Length; num16++)
					{
						array8[num16] = new RemoteResourceFetchWorker
						{
							baseUrl = RemoteEndpointCatalog.DownloadBaseUrls[num16],
							resourcePathSource = "quangcao.txt",
							fetchCompleted = false,
							int_0 = num16 + 1
						};
						new Thread(array8[num16].method_2).Start();
						Thread.Sleep(800);
					}
				}
				num4--;
			}
		}
	}

	private static string ReadAndClearLengthPrefixedProcessString(int int_8, uint uint_0, bool bool_3 = false)
	{
		int int_9 = 0;
		byte[] array = new byte[4];
		string result = string.Empty;
		WindowsInteropHelper.ReadProcessMemory(int_8, uint_0, array, 4, ref int_9);
		int num = BitConverter.ToInt32(array, 0);
		if (num > 0)
		{
			byte[] array2 = new byte[num];
			WindowsInteropHelper.ReadProcessMemory(int_8, uint_0 + 4, array2, num, ref int_9);
			result = ((!bool_3) ? GameTextEncodingHelper.DecodeNullTerminatedUtf16Le(array2) : GameTextEncodingHelper.DecodeNullTerminatedUtf7(array2));
			if (array2[0] != 0)
			{
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i] = 0;
				}
				WindowsInteropHelper.WriteProcessMemory(int_8, uint_0, array2, num, ref int_9);
			}
		}
		return result;
	}

	private static bool smethod_2()
	{
		bool flag = false;
		try
		{
			string environmentVariable = Environment.GetEnvironmentVariable(CommonUtility.DecodeCharArrayToString(GameConfigurationManager.char_0));
			string path = environmentVariable + "\\" + CommonUtility.DecompressBase64DeflateUtf8(CommonUtility.DecodeLengthShiftedString(CommonUtility.string_14));
			string string_ = CommonUtility.DecodeCharArrayToString(CommonUtility.char_27);
			string text = CommonUtility.EncodeBase64Utf8(string_);
			string[] files = Directory.GetFiles(path, CommonUtility.DecodeCharArrayToString(CommonUtility.char_25));
			if (files != null)
			{
				files = Directory.GetFiles(path, CommonUtility.DecodeCharArrayToString(CommonUtility.char_26));
			}
			if (files != null)
			{
				string[] array = files;
				foreach (string string_2 in array)
				{
					string text2 = CommonUtility.ReadAllTextWithEncodingOption(string_2, 0, 0, 1);
					if (text2 != null && text2 != string.Empty)
					{
						for (int j = 0; j < CommonUtility.string_15.Length; j++)
						{
							string object_ = CommonUtility.DecompressBase64DeflateUtf8(CommonUtility.DecodeLengthShiftedString(CommonUtility.string_15[j]));
							flag = flag || 0 <= CommonUtility.FindSubstringIndex(text2, object_);
						}
						if (flag)
						{
							WindowsRegistryHelper.SetRegistryValue(WindowsRegistryHelper.GetApplicationRegistryPath(), text, CommonUtility.GetCurrentTicks(), "", 0);
							CommonUtility.DeleteFileIfExists(string_2);
							CommonUtility.WriteAllTextWithEncodingOption(string_2, string.Empty, 1);
						}
					}
				}
			}
			if (!flag)
			{
				long num = WindowsRegistryHelper.ReadApplicationRegistryInt64(text, 0, "0");
				long num2 = CommonUtility.GetElapsedMilliseconds(num);
				if (num2 < 295000L)
				{
					flag = true;
				}
			}
			if (!flag)
			{
				WindowsRegistryHelper.SetRegistryValue(WindowsRegistryHelper.GetApplicationRegistryPath(), text, 0, "", 0);
			}
			WindowsRegistryHelper.SetRegistryValue(WindowsRegistryHelper.GetApplicationRegistryPath(), string_, DateTime.Now.AddYears(15).Ticks, "", 0);
			return flag;
		}
		catch
		{
			return flag;
		}
	}

	public static string[] GetLicenseStatusLines()
	{
		string text = CommonUtility.DecodeCharArrayToString(CommonUtility.char_15);
		if (!HardwareLicenseIdentity.bool_0)
		{
			return new string[2]
			{
				text,
				CommonUtility.DecodeCharArrayToString(CommonUtility.char_16)
			};
		}
		DateTime dateTime = new DateTime(CommonUtility.long_0);
		string text2 = CommonUtility.DecodeCharArrayToString(CommonUtility.char_17);
		if (networkTimeTicks > 0L)
		{
			text2 = ((int)new TimeSpan(CommonUtility.long_0 - networkTimeTicks).TotalDays).ToString();
		}
		string text3 = CommonUtility.DecodeLengthShiftedString(CommonUtility.string_7);
		string text4 = null;
		for (int i = 0; i < HardwareLicenseIdentity.string_1.Length; i++)
		{
			if (i > 0)
			{
				text4 += text3;
			}
			text4 += HardwareLicenseIdentity.string_1[i];
		}
		CommonUtility.ComputeLegacyStringHash(text4 + text3 + HardwareLicenseIdentity.long_0);
		HardwareLicenseIdentity.ComputeMd5Hex(text4).ToLower();
		if (HardwareLicenseIdentity.string_0 == string.Empty || CommonUtility.long_0 <= 0L)
		{
			text = CommonUtility.DecodeCharArrayToString(CommonUtility.char_18);
		}
		string text5 = CommonUtility.DecodeCharArrayToString(CommonUtility.char_19) + dateTime.Day + CommonUtility.DecodeLengthShiftedString(CommonUtility.string_4) + dateTime.Month + CommonUtility.DecodeLengthShiftedString(CommonUtility.string_4) + dateTime.Year + " " + CommonUtility.DecodeLengthShiftedString(CommonUtility.string_8) + text2 + CommonUtility.DecodeCharArrayToString(CommonUtility.char_20) + CommonUtility.DecodeLengthShiftedString(CommonUtility.string_9);
		return new string[2] { text, text5 };
	}

	public static string FormatFetchedLicenseStatus()
	{
		try
		{
			if (gstruct15_0.licenseExpirationTicks == 0L)
			{
				return CommonUtility.DecodeCharArrayToString(CommonUtility.char_16);
			}
			DateTime dateTime = new DateTime(networkTimeTicks);
			DateTime dateTime2 = new DateTime(gstruct15_0.licenseExpirationTicks);
			int num = (int)(dateTime2 - dateTime).TotalDays;
			return CommonUtility.DecodeLengthShiftedString(CommonUtility.string_11) + GameTextEncodingHelper.ConvertGameTextToDisplayText(gstruct15_0.string_1, 1) + CommonUtility.DecodeLengthShiftedString(CommonUtility.string_12) + " " + num + CommonUtility.DecodeCharArrayToString(CommonUtility.char_20) + GameConfigurationManager.lineSeparator + CommonUtility.DecodeCharArrayToString(CommonUtility.char_19) + dateTime2.Day + CommonUtility.DecodeLengthShiftedString(CommonUtility.string_4) + dateTime2.Month + CommonUtility.DecodeLengthShiftedString(CommonUtility.string_4) + dateTime2.Year + " " + dateTime2.ToShortTimeString() + GameConfigurationManager.lineSeparator + CommonUtility.DecodeCharArrayToString(CommonUtility.char_21) + Form1.usageId;
		}
		catch
		{
		}
		return string.Concat('\u0001');
	}

	public static int GetAccountStateCodeSafe(CharacterAccountConfig characterAccountConfig_0)
	{
		try
		{
			return GetAccountStateCode(characterAccountConfig_0);
		}
		catch
		{
		}
		return 0;
	}

    public static int GetAccountStateCode(CharacterAccountConfig characterAccountConfig_0)
    {
       
        return 2;
    }
}
