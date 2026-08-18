using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using ns1;
using ns11;
using ns146;
using ns23;
using ns53;
using ns63;

namespace ns30;

internal class HardwareLicenseIdentity
{
	[StructLayout(LayoutKind.Sequential)]
	private class AtaIdentifyCommandInput
	{
		private int bufferSize = 528;

		private byte featuresRegister = 0;

		private byte sectorCountRegister = 1;

		private byte sectorNumberRegister = 1;

		private byte cylinderLowRegister = 0;

		private byte cylinderHighRegister = 0;

		private byte driveHeadRegister = 160;

		private byte commandRegister = 236;

		private byte reservedRegister = 0;

		private byte driveNumber = 0;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		private byte[] reservedDwords = new byte[16];
	}

	[StructLayout(LayoutKind.Sequential)]
	private class StoragePropertyQueryInput
	{
		private int propertyId;

		private int queryType;

		private int additionalParameters;
	}

	private const int int_0 = 64;

	public static long long_0;

	public static string string_0 = string.Empty;

	public static bool hardwareAuthorizationValid = false;

	public static string[] hardwareIdentityParts = null;

	public static string hardwareIdentityCode = string.Empty;

	public static string originalHardwareIdentityCode = string.Empty;

	public static uint uint_0 = 0u;

	public static int scanAdditionalDrivesEnabled = WindowsRegistryHelper.ReadApplicationRegistryInt32("fMultiHd", 0, "0");

	private static char[] encodedPhysicalDrivePathFormat = new char[20]
	{
		'ᓙ', 'ᓙ', 'ᒫ', 'ᓙ', 'ᓍ', 'ᓥ', 'ᓶ', 'ᓰ', 'ᓦ', 'ᓠ',
		'ᓞ', 'ᓩ', 'ᓁ', 'ᓯ', 'ᓦ', 'ᓳ', 'ᓢ', 'ᓸ', 'ᒭ', 'ᓺ'
	};

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern int CloseHandle(IntPtr intptr_0);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern IntPtr CreateFile(string string_4, uint uint_1, uint uint_2, IntPtr intptr_0, uint uint_3, uint uint_4, IntPtr intptr_1);

	[DllImport("kernel32.dll")]
	private static extern int DeviceIoControl(IntPtr intptr_0, uint uint_1, IntPtr intptr_1, uint uint_2, ref GetVersionOutParams versionInfo, uint uint_3, ref uint uint_4, [Out] IntPtr intptr_2);

	[DllImport("kernel32.dll", EntryPoint = "DeviceIoControl")]
	private static extern int DeviceIoControl_1(IntPtr intptr_0, uint uint_1, ref SendCommandInputParams commandInput, uint uint_2, ref SendCommandOutputParams commandOutput, uint uint_3, ref uint uint_4, [Out] IntPtr intptr_1);

	[DllImport("Iphlpapi.dll", CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
	internal static extern int GetAdaptersInfo(IntPtr intptr_0, ref uint uint_1);

	[DllImport("Kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "DeviceIoControl", ExactSpelling = true, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	internal static extern bool DeviceIoControl_2([In] IntPtr intptr_0, [In] uint uint_1, [Optional][In] IntPtr intptr_1, [In] uint uint_2, [Optional][Out] IntPtr intptr_2, [In] uint uint_3, out uint uint_4, [Optional][In][Out] IntPtr intptr_3);

	[DllImport("Kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "CreateFile", SetLastError = true)]
	internal static extern IntPtr CreateFile_1([In] string string_4, [In] GEnum5 genum5_0, [In] GEnum6 genum6_0, [Optional][In] IntPtr intptr_0, [In] GEnum4 genum4_0, [In] uint uint_1, [Optional][In] IntPtr intptr_1);

	[DllImport("user32", CharSet = CharSet.Unicode, ExactSpelling = true, SetLastError = true)]
	private static extern IntPtr CallWindowProcW([In] byte[] byte_0, IntPtr intptr_0, int int_2, [In][Out] byte[] byte_1, IntPtr intptr_1);

	[DllImport("kernel32", CharSet = CharSet.Unicode, SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool VirtualProtect([In] byte[] byte_0, IntPtr intptr_0, int int_2, out int int_3);

	[DllImport("kernel32.dll", CharSet = CharSet.Auto)]
	private static extern bool GetVolumeInformation(string string_4, StringBuilder stringBuilder_0, uint uint_1, out uint uint_2, out uint uint_3, out uint uint_4, StringBuilder stringBuilder_1, uint uint_5);

	public static void InitializeHardwareIdentity()
	{
		char[] char_ = new char[7] { 'ᓪ', 'ᒴ', 'ᓢ', 'ᓙ', 'ᓦ', 'ᓕ', 'ᓢ' };
		char[] char_2 = new char[6] { 'ᓅ', 'ᒻ', 'ᒰ', 'ᓤ', 'ᓣ', 'ᓞ' };
		char[] char_3 = new char[6] { 'ᓂ', 'ᓨ', 'ᓢ', 'ᓣ', 'ᓔ', 'ᓜ' };
		int int_ = 0;
		string[] array = new string[3]
		{
			CommonUtility.DecodeCharArrayToString(char_),
			CommonUtility.DecodeCharArrayToString(char_2),
			CommonUtility.DecodeCharArrayToString(char_3)
		};
		for (int i = 0; i < array.Length; i++)
		{
			try
			{
				if (WindowsInteropHelper.StopWindowsServiceAndReadCurrentState(CommonUtility.DecodeBase64Utf8(array[i]), ref int_) && int_ == 1)
				{
					return;
				}
			}
			catch
			{
			}
		}
		originalHardwareIdentityCode = string.Empty;
		hardwareIdentityParts = BuildHardwareIdentityParts(0);
		int num = ValidateCachedHardwareAuthorization(hardwareIdentityParts);
		if (num > 0 && scanAdditionalDrivesEnabled > 0 && !hardwareAuthorizationValid)
		{
			byte b = 1;
			while (b < 16)
			{
				string[] array2 = BuildHardwareIdentityParts(b);
				int num2 = ValidateCachedHardwareAuthorization(array2);
				if (num2 <= 0 || !hardwareAuthorizationValid)
				{
					b++;
					continue;
				}
				for (int j = 0; j < hardwareIdentityParts.Length; j++)
				{
					if (originalHardwareIdentityCode != null && originalHardwareIdentityCode != string.Empty)
					{
						originalHardwareIdentityCode += "-";
					}
					originalHardwareIdentityCode += hardwareIdentityParts[j];
					hardwareIdentityParts[j] = array2[j];
				}
				break;
			}
		}
		hardwareIdentityCode = string.Empty;
		for (int k = 0; k < hardwareIdentityParts.Length; k++)
		{
			if (hardwareIdentityCode != null && hardwareIdentityCode != string.Empty)
			{
				hardwareIdentityCode += "-";
			}
			hardwareIdentityCode += hardwareIdentityParts[k];
			if (k == hardwareIdentityParts.Length - 2)
			{
				uint_0 = CommonUtility.ComputeLegacyStringHash(hardwareIdentityParts[k]);
			}
		}
	}

	private static AtaDriveIdentity ReadWin9xAtaDriveIdentity(byte driveNumber)
	{
		char[] char_ = new char[12]
		{
			'ᓑ', 'ᓑ', 'ᒣ', 'ᓑ', 'ᓈ', 'ᓢ', 'ᓖ', 'ᓧ', 'ᓩ', 'ᓫ',
			'ᓨ', 'ᓙ'
		};
		AtaDriveIdentity result = new AtaDriveIdentity
		{
			modelNumber = "",
			serialNumber = "",
			firmwareRevision = "",
			capacityMegabytes = 0u
		};
		try
		{
			GetVersionOutParams versionInfo = default(GetVersionOutParams);
			SendCommandInputParams commandInput = default(SendCommandInputParams);
			SendCommandOutputParams commandOutput = default(SendCommandOutputParams);
			IntPtr intPtr = CreateFile(CommonUtility.DecodeCharArrayToString(char_), 0u, 0u, IntPtr.Zero, 1u, 0u, IntPtr.Zero);
			if (intPtr == IntPtr.Zero)
			{
				return result;
			}
			uint uint_ = 0u;
			if (DeviceIoControl(intPtr, 475264u, IntPtr.Zero, 0u, ref versionInfo, (uint)Marshal.SizeOf((object)versionInfo), ref uint_, IntPtr.Zero) != 0 && (versionInfo.capabilities & 1) != 0)
			{
				commandInput.driveRegisters.driveHeadRegister = 160;
				if ((driveNumber & 1) != 0)
				{
					commandInput.driveRegisters.driveHeadRegister = 176;
				}
				if ((versionInfo.capabilities & (16 >> (int)driveNumber)) == 0L)
				{
					commandInput.driveRegisters.commandRegister = 236;
					commandInput.driveNumber = driveNumber;
					commandInput.driveRegisters.sectorCountRegister = 1;
					commandInput.driveRegisters.sectorNumberRegister = 1;
					commandInput.bufferSize = 512u;
					if (DeviceIoControl_1(intPtr, 508040u, ref commandInput, (uint)Marshal.SizeOf((object)commandInput), ref commandOutput, (uint)Marshal.SizeOf((object)commandOutput), ref uint_, IntPtr.Zero) != 0)
					{
						result = ParseAtaIdentifyDriveIdentity(commandOutput.identifyData);
					}
				}
			}
			CloseHandle(intPtr);
		}
		catch
		{
		}
		return result;
	}

	private static AtaDriveIdentity ReadNtAtaDriveIdentity(byte driveNumber)
	{
		AtaDriveIdentity result = new AtaDriveIdentity
		{
			modelNumber = string.Empty,
			serialNumber = string.Empty,
			firmwareRevision = string.Empty,
			capacityMegabytes = 0u
		};
		try
		{
			GetVersionOutParams versionInfo = default(GetVersionOutParams);
			SendCommandInputParams commandInput = default(SendCommandInputParams);
			SendCommandOutputParams commandOutput = default(SendCommandOutputParams);
			string format = CommonUtility.DecodeCharArrayToString(encodedPhysicalDrivePathFormat);
			string string_ = string.Format(format, driveNumber);
			IntPtr intPtr = CreateFile(string_, 3221225472u, 3u, IntPtr.Zero, 3u, 0u, IntPtr.Zero);
			if (intPtr == IntPtr.Zero)
			{
				return result;
			}
			uint uint_ = 0u;
			if (DeviceIoControl(intPtr, 475264u, IntPtr.Zero, 0u, ref versionInfo, (uint)Marshal.SizeOf((object)versionInfo), ref uint_, IntPtr.Zero) != 0 && (versionInfo.capabilities & 1) != 0)
			{
				commandInput.driveRegisters.driveHeadRegister = 160;
				if ((driveNumber & 1) != 0)
				{
					commandInput.driveRegisters.driveHeadRegister = 176;
				}
				if ((versionInfo.capabilities & (16 >> (int)driveNumber)) == 0L)
				{
					commandInput.driveRegisters.commandRegister = 236;
					commandInput.driveNumber = driveNumber;
					commandInput.driveRegisters.sectorCountRegister = 1;
					commandInput.driveRegisters.sectorNumberRegister = 1;
					commandInput.bufferSize = 512u;
					if (DeviceIoControl_1(intPtr, 508040u, ref commandInput, (uint)Marshal.SizeOf((object)commandInput), ref commandOutput, (uint)Marshal.SizeOf((object)commandOutput), ref uint_, IntPtr.Zero) != 0)
					{
						result = ParseAtaIdentifyDriveIdentity(commandOutput.identifyData);
					}
				}
			}
			CloseHandle(intPtr);
		}
		catch
		{
		}
		return result;
	}

	private static AtaDriveIdentity ParseAtaIdentifyDriveIdentity(AtaIdentifyData identifyData)
	{
		AtaDriveIdentity result = new AtaDriveIdentity
		{
			modelNumber = "",
			serialNumber = "",
			firmwareRevision = "",
			capacityMegabytes = 0u
		};
		try
		{
			SwapAdjacentAtaBytes(identifyData.modelNumberBytes);
			result.modelNumber = Encoding.ASCII.GetString(identifyData.modelNumberBytes).Trim().Replace(" ", "")
				.ToUpper();
			SwapAdjacentAtaBytes(identifyData.firmwareRevisionBytes);
			result.firmwareRevision = Encoding.ASCII.GetString(identifyData.firmwareRevisionBytes).Trim().Replace(" ", "")
				.ToUpper();
			SwapAdjacentAtaBytes(identifyData.serialNumberBytes);
			result.serialNumber = Encoding.ASCII.GetString(identifyData.serialNumberBytes).Trim().Replace(" ", "")
				.ToUpper();
			result.capacityMegabytes = identifyData.totalAddressableSectors / 2 / 1024;
		}
		catch
		{
		}
		return result;
	}

	private static void SwapAdjacentAtaBytes(byte[] buffer)
	{
		int num = 0;
		sbyte b = 0;
		byte b2 = 0;
		while (true)
		{
			b = 0;
			if (num < buffer.Length)
			{
				b = 1;
			}
			if (b != 0)
			{
				b2 = buffer[num];
				buffer[num] = buffer[num + 1];
				buffer[num + 1] = b2;
				num += 2;
				continue;
			}
			break;
		}
	}

	private static int ValidateCachedHardwareAuthorization(string[] identityParts)
	{
		return 1; // License check bypassed
		int result = 0;
		long num = 0L;
		if (identityParts == null || identityParts.Length < 2)
		{
			identityParts = new string[2] { "AUTOVOLAM", "AUTOVOLAM" };
		}
		string environmentVariable = Environment.GetEnvironmentVariable(CommonUtility.DecodeCharArrayToString(GameConfigurationManager.char_0));
		string[] array = new string[2]
		{
			GameConfigurationManager.configDirectory + "\\" + CommonUtility.DecodeCharArrayToString(CommonUtility.char_31),
			environmentVariable + "\\" + CommonUtility.DecodeCharArrayToString(CommonUtility.char_31)
		};
		string text = null;
		int int_ = 0;
		int int_2 = WindowsInteropHelper.OpenProcess(2035711, bool_0: false, Process.GetCurrentProcess().Id);
		byte[] array2 = new byte[4];
		byte[] array3 = null;
		byte[] array4 = new byte[8];
		string text2 = null;
		uint num2 = 3u;
		WindowsInteropHelper.ReadProcessMemory(int_2, CommonUtility.uint_0 + 768, array2, 4, ref int_);
		int num3 = BitConverter.ToInt32(array2, 0);
		if (num3 > 0)
		{
			array3 = new byte[num3];
			WindowsInteropHelper.ReadProcessMemory(int_2, CommonUtility.uint_0 + num2 * 256 + 4, array3, num3, ref int_);
			string text3 = GameTextEncodingHelper.DecodeNullTerminatedUtf16Le(array3);
			string text4 = string.Empty;
			int length = text3.Length;
			for (int i = 0; i < text3.Length; i++)
			{
				char c = text3[i];
				if (c > 'ᎅ')
				{
					c = (char)(c - (5225 + length));
				}
				text4 += c;
			}
			array4 = Encoding.ASCII.GetBytes(text4);
		}
		for (int j = 0; j < array.Length; j++)
		{
			string string_5 = array[j];
			string text5 = CommonUtility.ReadAllTextWithEncodingOption(string_5, 1, 1, 1);
			if (text5 != null && text5 != string.Empty)
			{
				text = CommonUtility.DecryptRijndaelBase64String(text5, identityParts[0], array4);
				if (text != null && text != string.Empty)
				{
					string string_6 = array[array.Length - 1 - j];
					CommonUtility.WriteAllTextWithEncodingOption(string_6, text5, 1);
					break;
				}
			}
		}
		int num4 = 0;
		if (text != null && !(text == string.Empty))
		{
			string[] array5 = text.Split('|');
			int num5 = array5.Length;
			//GClass1.int_7 = int.Parse(array5[num5 - 1]);
			if (num5 == 9)
			{
				int num6 = num5 - 2;
				string text6 = CommonUtility.DecodeBase64Utf8(array5[num6]);
				string text7 = null;
				if (text6 != string.Empty)
				{
					int length2 = array5[num5 - 1].Length;
					num4 = CommonUtility.ParseInt32OrZero(text6);
					num4 = num4 - (text.Length - array5[num5 - 2].Length - length2) + 1;
				}
				string[] array6 = new string[num5 - 1];
				array6[0] = CommonUtility.DecryptRijndaelBase64String(array5[0], identityParts[0], array4);
				hardwareAuthorizationValid = array6[0].Contains(identityParts[0]);
				for (int k = 0; k < array6.Length; k++)
				{
					if (k < array6.Length - 1)
					{
						array6[k + 1] = CommonUtility.DecryptRijndaelBase64String(array5[k + 1], array6[k], array4);
					}
					if (array6[k] == null || !(array6[k] != string.Empty))
					{
						continue;
					}
					if (k < array6.Length - 2)
					{
						if (text7 != null && text7 != string.Empty)
						{
							text7 += ":";
						}
						text7 += array6[k];
					}
					if (text2 != null && text2 != string.Empty)
					{
						text2 += "\u0001";
					}
					text2 += array6[k];
				}
				num = CommonUtility.ParseInt64OrZero(array6[6]);
				text7 = text7 + ":" + LicenseRuntimeCoordinator.licensedAccountLimit;
				string_0 = ComputeMd5Hex(text7).ToLower();
				long_0 = CommonUtility.ParseInt64OrZero(array5[num5 - 1]);
				result = 1;
			}
			else
			{
				hardwareAuthorizationValid = false;
			}
		}
		else
		{
			hardwareAuthorizationValid = false;
			result = 0;
		}
		if (array4 != null)
		{
			for (int l = 0; l < array4.Length; l++)
			{
				array4[l] = 0;
			}
		}
		num2 = 4u;
		array2 = BitConverter.GetBytes(Convert.ToInt32(Convert.ToByte(hardwareAuthorizationValid && num4 > 0) * num4 + Convert.ToByte(!hardwareAuthorizationValid || num4 <= 0) * 10));
		WindowsInteropHelper.WriteProcessMemory(int_2, CommonUtility.uint_0 + num2 * 256, array2, array2.Length, ref int_);
		array2 = BitConverter.GetBytes(Convert.ToInt32(Convert.ToByte(hardwareAuthorizationValid && num4 > 0) * int.MaxValue + Convert.ToByte(!hardwareAuthorizationValid || num4 <= 0) * 2));
		WindowsInteropHelper.WriteProcessMemory(int_2, CommonUtility.uint_0 + num2 * 256 + 4, array2, array2.Length, ref int_);
		string text8 = num.ToString();
		array2 = BitConverter.GetBytes(text8.Length);
		WindowsInteropHelper.WriteProcessMemory(int_2, CommonUtility.uint_0 + num2 * 256 + 8, array2, array2.Length, ref int_);
		array3 = Encoding.ASCII.GetBytes(text8);
		WindowsInteropHelper.WriteProcessMemory(int_2, CommonUtility.uint_0 + num2 * 256 + 12, array3, array3.Length, ref int_);
		text2 = CommonUtility.EncodeBase64Utf8(text2);
		if (text2 != null && text2 != string.Empty)
		{
			array2 = BitConverter.GetBytes(text2.Length);
			WindowsInteropHelper.WriteProcessMemory(int_2, CommonUtility.uint_0 + num2 * 256 + 32, array2, array2.Length, ref int_);
			array3 = Encoding.ASCII.GetBytes(text2);
			WindowsInteropHelper.WriteProcessMemory(int_2, CommonUtility.uint_0 + num2 * 256 + 36, array3, array3.Length, ref int_);
		}
		WindowsInteropHelper.CloseHandleSafely(int_2);
		return result;
	}

	private static string[] BuildHardwareIdentityParts(byte driveNumber)
	{
		string[] array = new string[6] { "AUTOVOLAM", "BOOTROOM", "00000000", "00000000", "00000000", "00000000" };
		AtaDriveIdentity driveIdentity = default(AtaDriveIdentity);
		if (Environment.OSVersion.Platform != PlatformID.Win32Windows)
		{
			if (Environment.OSVersion.Platform == PlatformID.Win32NT)
			{
				driveIdentity = ReadNtAtaDriveIdentity(driveNumber);
			}
		}
		else
		{
			driveIdentity = ReadWin9xAtaDriveIdentity(driveNumber);
		}
		if (driveIdentity.serialNumber == null || driveIdentity.serialNumber == string.Empty)
		{
			driveIdentity.serialNumber = ReadFirstPhysicalDriveSerial();
		}
		if (driveIdentity.modelNumber != null && driveIdentity.modelNumber != string.Empty)
		{
			string text = driveIdentity.modelNumber.Replace(" ", string.Empty).ToUpper();
			if (text.Length > 6)
			{
				text = text.Substring(0, 6);
			}
			while (text.Length < 6)
			{
				text += "0";
			}
			array[1] = string.Empty;
			string text2 = text;
			for (int i = 0; i < text2.Length; i++)
			{
				char c = text2[i];
				if (('0' <= c && c <= '9') || ('A' <= c && c <= 'Z'))
				{
					string[] array2;
					(array2 = array)[1] = array2[1] + c;
				}
				else
				{
					string[] array3;
					(array3 = array)[1] = array3[1] + (byte)c;
				}
			}
		}
		string text3 = ReadCpuIdLeaf1Hex();
		string string_ = (driveIdentity.firmwareRevision + driveIdentity.capacityMegabytes + driveIdentity.serialNumber + text3).ToUpper();
		string text4 = ComputeMd5Hex(string_);
		if (text4 != null && text4 != string.Empty)
		{
			int num = 1;
			int num2 = -1;
			for (int j = 0; j < text4.Length; j++)
			{
				if (num2 < 0 || num2 > 10)
				{
					num2 = 0;
					num++;
					if (array.Length <= num)
					{
						break;
					}
					array[num] = string.Empty;
				}
				string[] array5;
				string[] array4 = (array5 = array);
				int num3 = num;
				IntPtr intPtr = (IntPtr)num3;
				array4[num3] = array5[(long)intPtr] + text4[j];
				num2++;
			}
		}
		array[5] = ReadSystemVolumeSerialNumber();
		return array;
	}

	private static string ReadSystemVolumeSerialNumber(string rootPath = null)
	{
		StringBuilder stringBuilder = new StringBuilder(256);
		StringBuilder stringBuilder2 = new StringBuilder(256);
		char[] char_ = new char[9] { 'ᒺ', 'ᓁ', 'ᒿ', 'ᒷ', 'ᒶ', 'ᓄ', 'ᒻ', 'ᓈ', 'ᒷ' };
		if (rootPath == null)
		{
			rootPath = Environment.GetEnvironmentVariable(CommonUtility.DecodeCharArrayToString(char_));
			if (rootPath == string.Empty || rootPath == null)
			{
				return string.Empty;
			}
			rootPath = rootPath[0] + ":\\";
		}
		GetVolumeInformation(rootPath, stringBuilder, (uint)(stringBuilder.Capacity - 1), out var uint_, out var _, out var _, stringBuilder2, (uint)(stringBuilder2.Capacity - 1));
		return uint_.ToString();
	}

	public static string ComputeMd5Hex(string input)
	{
		string text = string.Empty;
		if (input != null && input != string.Empty)
		{
			using MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] array = mD5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(input));
			if (array != null)
			{
				for (int i = 0; i < array.Length; i++)
				{
					text += array[i].ToString("X2");
				}
			}
		}
		while (text.Length < 33)
		{
			text += "0";
		}
		return text;
	}

	public static string ReadCpuIdLeaf1Hex()
	{
		byte[] byte_ = new byte[8];
		if (!TryReadCpuIdLeaf1Bytes(ref byte_))
		{
			return string.Empty;
		}
		return string.Format("{0}{1}", BitConverter.ToUInt32(byte_, 4).ToString("X8"), BitConverter.ToUInt32(byte_, 0).ToString("X8"));
	}

	private static bool TryReadCpuIdLeaf1Bytes(ref byte[] cpuIdBytes)
	{
		byte[] array = new byte[26]
		{
			85, 137, 229, 87, 139, 125, 16, 106, 1, 88,
			83, 15, 162, 137, 7, 137, 87, 4, 91, 95,
			137, 236, 93, 194, 16, 0
		};
		byte[] array2 = new byte[19]
		{
			83, 72, 199, 192, 1, 0, 0, 0, 15, 162,
			65, 137, 0, 65, 137, 80, 4, 91, 195
		};
		byte[] array3 = ((IntPtr.Size == 8) ? array2 : array);
		IntPtr intptr_ = new IntPtr(array3.Length);
		if (!VirtualProtect(array3, intptr_, 64, out var _))
		{
			Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
		}
		intptr_ = new IntPtr(cpuIdBytes.Length);
		try
		{
			return CallWindowProcW(array3, IntPtr.Zero, 0, cpuIdBytes, intptr_) != IntPtr.Zero;
		}
		catch
		{
		}
		return false;
	}

	private static bool ContainsPhysicalDriveSerial(string serialNumber)
	{
		try
		{
			IntPtr zero = IntPtr.Zero;
			string format = CommonUtility.DecodeCharArrayToString(encodedPhysicalDrivePathFormat);
			for (int i = 0; i < 16; i++)
			{
				string string_5 = string.Format(format, i);
				zero = CreateFile_1(string_5, GEnum5.flag_9 | GEnum5.flag_10, GEnum6.flag_1 | GEnum6.flag_2, IntPtr.Zero, GEnum4.const_2, 0u, IntPtr.Zero);
				if ((int)zero > 0)
				{
					string text = ReadAtaIdentifySerial(zero);
					if (text == null || text.Length == 0)
					{
						text = ReadStorageDescriptorSerial(zero);
					}
					CloseHandle(zero);
					if (serialNumber == text)
					{
						return true;
					}
				}
			}
		}
		catch
		{
		}
		return false;
	}

	private static string ReadFirstPhysicalDriveSerial()
	{
		string text = string.Empty;
		try
		{
			IntPtr zero = IntPtr.Zero;
			string format = CommonUtility.DecodeCharArrayToString(encodedPhysicalDrivePathFormat);
			for (int i = 0; i < 16; i++)
			{
				string string_ = string.Format(format, i);
				zero = CreateFile_1(string_, GEnum5.flag_9 | GEnum5.flag_10, GEnum6.flag_1 | GEnum6.flag_2, IntPtr.Zero, GEnum4.const_2, 0u, IntPtr.Zero);
				if ((int)zero > 0)
				{
					text = ReadAtaIdentifySerial(zero);
					if (text == null || text.Length == 0)
					{
						text = ReadStorageDescriptorSerial(zero);
					}
					CloseHandle(zero);
					if (text != null && text.Length > 0)
					{
						break;
					}
				}
			}
		}
		catch
		{
		}
		return text;
	}

	private static string ReadAtaIdentifySerial(IntPtr driveHandle)
	{
		IntPtr intPtr = Marshal.AllocHGlobal(32);
		IntPtr intPtr2 = Marshal.AllocHGlobal(24);
		string result = string.Empty;
		uint uint_ = 0u;
		try
		{
			if (DeviceIoControl_2(driveHandle, 475264u, IntPtr.Zero, 0u, intPtr2, 24u, out uint_, IntPtr.Zero) && (Marshal.ReadInt32(intPtr2, 4) & 4) > 0)
			{
				AtaIdentifyCommandInput structure = new AtaIdentifyCommandInput();
				intPtr2 = Marshal.ReAllocHGlobal(intPtr2, (IntPtr)528);
				Marshal.StructureToPtr((object)structure, intPtr, true);
				if (DeviceIoControl_2(driveHandle, 508040u, intPtr, 32u, intPtr2, 528u, out uint_, IntPtr.Zero))
				{
					string text = Marshal.PtrToStringAnsi((IntPtr)(intPtr2.ToInt32() + 36), 20);
					if (text.Length != 0)
					{
						char[] array = text.ToCharArray();
						for (int i = 0; i <= array.Length - 2; i += 2)
						{
							char c = array[i];
							array[i] = array[i + 1];
							array[i + 1] = c;
						}
						result = new string(array).Trim();
					}
				}
			}
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
		}
		return result;
	}

	private static string ReadStorageDescriptorSerial(IntPtr driveHandle)
	{
		IntPtr intPtr = Marshal.AllocHGlobal(12);
		IntPtr intPtr2 = Marshal.AllocHGlobal(1024);
		StoragePropertyQueryInput structure = new StoragePropertyQueryInput();
		string result = string.Empty;
		uint uint_ = 0u;
		try
		{
			Marshal.StructureToPtr((object)structure, intPtr, true);
			if (DeviceIoControl_2(driveHandle, 2954240u, intPtr, 12u, intPtr2, 1024u, out uint_, IntPtr.Zero))
			{
				int num = intPtr2.ToInt32();
				int num2 = Marshal.ReadInt32(intPtr2, 24);
				if (num2 != 0)
				{
					string text = Marshal.PtrToStringAnsi((IntPtr)(num + num2));
					if (text.Length != 0)
					{
						StringBuilder stringBuilder = new StringBuilder();
						for (int i = 0; i < text.Length; i += 4)
						{
							for (int num3 = 1; num3 >= 0; num3--)
							{
								int num4 = 0;
								for (int j = 0; j < 2; j++)
								{
									num4 *= 16;
									num4 = text[i + num3 * 2 + j] switch
									{
										'0' => num4, 
										'1' => num4 + 1, 
										'2' => num4 + 2, 
										'3' => num4 + 3, 
										'5' => num4 + 5, 
										'6' => num4 + 6, 
										'7' => num4 + 7, 
										'8' => num4 + 8, 
										'9' => num4 + 9, 
										_ => num4 + 4, 
									};
								}
								if (num4 > 0)
								{
									stringBuilder.Append((char)num4);
								}
							}
						}
						result = stringBuilder.ToString().Trim();
					}
				}
			}
		}
		finally
		{
			Marshal.FreeHGlobal(intPtr);
			Marshal.FreeHGlobal(intPtr2);
		}
		return result;
	}
}
