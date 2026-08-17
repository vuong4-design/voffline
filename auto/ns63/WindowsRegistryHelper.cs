using System;
using Microsoft.Win32;
using ns11;
using ns23;

namespace ns63;

internal class WindowsRegistryHelper
{
	private static RegistryKey cachedLocalMachineKey = null;

	private static RegistryKey cachedCurrentUserKey = null;

	public static string string_0 = "Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\Explorer\\DisallowRun";

	public static string GetDefaultHttpHandlerExecutablePath()
	{
		try
		{
			string name = "HTTP\\shell\\open\\command";
			using RegistryKey registryKey = Registry.ClassesRoot.OpenSubKey(name, writable: false);
			return ((string)registryKey.GetValue(null, null)).Split('"')[1];
		}
		catch
		{
		}
		return string.Empty;
	}

	public static string GetApplicationRegistryPath()
	{
		return CommonUtility.DecompressBase64DeflateUtf8("C/Z3Cwl3DHKNiQkIAgA=");
	}

	public static string ReadRegistryValueAsString(string subKeyPath, string valueName, byte hiveSelector = 0, string defaultValue = "")
	{
		string text = string.Empty;
		try
		{
			RegistryKey registryKey = ((hiveSelector == 0) ? Registry.LocalMachine.OpenSubKey(subKeyPath) : Registry.CurrentUser.OpenSubKey(subKeyPath));
			valueName = valueName.ToUpper();
			string[] valueNames = registryKey.GetValueNames();
			string[] array = valueNames;
			string[] array2 = array;
			foreach (string text2 in array2)
			{
				if (text2.ToUpper() == valueName)
				{
					text = registryKey.GetValue(text2).ToString();
					break;
				}
			}
			if (text == string.Empty)
			{
				text = defaultValue;
			}
			registryKey.Close();
		}
		catch
		{
			text = defaultValue;
			EnsureRegistrySubKeyExists(subKeyPath, hiveSelector);
		}
		return text;
	}

	public static string ReadCachedApplicationRegistryString(string valueName, byte hiveSelector = 0, string defaultValue = "")
	{
		string text = string.Empty;
		string name = GetApplicationRegistryPath();
		try
		{
			RegistryKey registryKey;
			if (hiveSelector == 0)
			{
				if (cachedLocalMachineKey == null)
				{
					cachedLocalMachineKey = Registry.LocalMachine.OpenSubKey(name);
				}
				registryKey = cachedLocalMachineKey;
			}
			else
			{
				if (cachedCurrentUserKey == null)
				{
					cachedCurrentUserKey = Registry.CurrentUser.OpenSubKey(name);
				}
				registryKey = cachedCurrentUserKey;
			}
			valueName = valueName.ToUpper();
			string[] valueNames = registryKey.GetValueNames();
			string[] array = valueNames;
			string[] array2 = array;
			foreach (string text2 in array2)
			{
				if (text2.ToUpper() == valueName)
				{
					text = registryKey.GetValue(text2).ToString();
					break;
				}
			}
			if (text == string.Empty)
			{
				text = defaultValue;
			}
		}
		catch
		{
			text = defaultValue;
			EnsureRegistrySubKeyExists(GetApplicationRegistryPath(), hiveSelector);
			cachedLocalMachineKey = null;
			cachedCurrentUserKey = null;
		}
		return text;
	}

	public static int ReadApplicationRegistryInt32(string valueName, byte hiveSelector = 0, string defaultValue = "")
	{
		int result = 0;
		string text = ReadCachedApplicationRegistryString(valueName, hiveSelector, defaultValue);
		if (text != null && text != string.Empty)
		{
			try
			{
				result = Convert.ToInt32(text);
			}
			catch
			{
				result = 0;
			}
		}
		return result;
	}

	public static uint ReadApplicationRegistryUInt32(string valueName, byte hiveSelector = 0, string defaultValue = "")
	{
		uint result = 0u;
		string text = ReadCachedApplicationRegistryString(valueName, hiveSelector, defaultValue);
		if (text != null && text != string.Empty)
		{
			try
			{
				result = Convert.ToUInt32(text);
			}
			catch
			{
				result = 0u;
			}
		}
		return result;
	}

	public static long ReadApplicationRegistryInt64(string valueName, byte hiveSelector = 0, string defaultValue = "")
	{
		long result = 0L;
		string text = ReadCachedApplicationRegistryString(valueName, hiveSelector, defaultValue);
		if (text != null && text != string.Empty)
		{
			try
			{
				result = Convert.ToInt64(text);
			}
			catch
			{
				result = 0L;
			}
		}
		return result;
	}

	public static string ReadApplicationRegistryString(string valueName, byte hiveSelector = 0, string defaultValue = "")
	{
		return ReadCachedApplicationRegistryString(valueName, hiveSelector, defaultValue);
	}

	public static string ReadRegistryStringOrFirstArrayValue(string subKeyPath, string valueName, byte hiveSelector = 0, string defaultValue = "")
	{
		string text = string.Empty;
		try
		{
			valueName = valueName.ToUpper();
			RegistryKey registryKey = ((hiveSelector == 0) ? Registry.LocalMachine.OpenSubKey(subKeyPath) : Registry.CurrentUser.OpenSubKey(subKeyPath));
			string[] valueNames = registryKey.GetValueNames();
			string[] array = valueNames;
			string[] array2 = array;
			foreach (string text2 in array2)
			{
				if (text2.ToUpper() == valueName)
				{
					object value = registryKey.GetValue(text2);
					if (CommonUtility.FindSubstringIndex(value.ToString().ToUpper(), "STRING[]") <= 0)
					{
						text = value.ToString();
						break;
					}
					string[] array3 = (string[])value;
					text = array3[0];
					break;
				}
			}
			if (text == "")
			{
				text = defaultValue;
			}
			registryKey.Close();
		}
		catch
		{
			text = defaultValue;
			EnsureRegistrySubKeyExists(subKeyPath, hiveSelector);
		}
		return text;
	}

	public static string[] GetRegistrySubKeyNames(string subKeyPath, bool useCurrentUserHive = false)
	{
		try
		{
			RegistryKey registryKey = ((!useCurrentUserHive) ? Registry.LocalMachine.OpenSubKey(subKeyPath, writable: true) : Registry.CurrentUser.OpenSubKey(subKeyPath, writable: true));
			if (registryKey != null)
			{
				string[] subKeyNames = registryKey.GetSubKeyNames();
				registryKey.Close();
				return subKeyNames;
			}
		}
		catch
		{
		}
		return null;
	}

	public static string[] EnumerateRegistryEntryNames(string subKeyPath, bool useCurrentUserHive = false, bool includeFullPath = false, int entryEnumerationMode = 0)
	{
		try
		{
			RegistryKey registryKey = ((!useCurrentUserHive) ? Registry.LocalMachine.OpenSubKey(subKeyPath, writable: true) : Registry.CurrentUser.OpenSubKey(subKeyPath, writable: true));
			if (registryKey != null)
			{
				string[] array = null;
				if (entryEnumerationMode > 0)
				{
					if (entryEnumerationMode != 1)
					{
						array = registryKey.GetValueNames();
						if (array != null && array.Length != 0)
						{
							string[] subKeyNames = registryKey.GetSubKeyNames();
							if (subKeyNames != null)
							{
								int num = array.Length;
								Array.Resize(ref array, num + subKeyNames.Length);
								for (int i = 0; i < subKeyNames.Length; i++)
								{
									array[num + i] = subKeyNames[i];
								}
							}
						}
						else
						{
							array = registryKey.GetSubKeyNames();
						}
					}
					else
					{
						array = registryKey.GetSubKeyNames();
					}
				}
				else
				{
					array = registryKey.GetValueNames();
				}
				if (includeFullPath && array != null)
				{
					for (int j = 0; j < array.Length; j++)
					{
						array[j] = registryKey.Name + "\\" + array[j];
					}
				}
				registryKey.Close();
				return array;
			}
		}
		catch
		{
		}
		return null;
	}

	public static bool SetRegistryValue(string subKeyPath, string valueName, object value, string valueKindName = "", byte hiveSelector = 0)
	{
		try
		{
			RegistryKey registryKey = ((hiveSelector == 0) ? Registry.LocalMachine.CreateSubKey(subKeyPath) : Registry.CurrentUser.CreateSubKey(subKeyPath));
			if (registryKey != null)
			{
				if (value != null)
				{
					registryKey.SetValue(valueName, value, ParseRegistryValueKind(valueKindName));
				}
				else
				{
					registryKey.SetValue(valueName, string.Empty, ParseRegistryValueKind(valueKindName));
				}
				registryKey.Close();
				return true;
			}
		}
		catch
		{
		}
		return false;
	}

	private static void EnsureRegistrySubKeyExists(string subKeyPath, byte hiveSelector = 0)
	{
		try
		{
			if (hiveSelector == 0)
			{
				Registry.LocalMachine.CreateSubKey(subKeyPath);
			}
			else
			{
				Registry.CurrentUser.CreateSubKey(subKeyPath);
			}
		}
		catch
		{
		}
	}

	public static void DeleteRegistryValue(string registryPath, string valueName, byte hiveSelector = 0)
	{
		try
		{
			if (hiveSelector == 3)
			{
				if (registryPath.IndexOf("HKEY_LOCAL_MACHINE\\") != 0)
				{
					if (registryPath.IndexOf("HKEY_CURRENT_USER\\") == 0)
					{
						hiveSelector = 2;
						registryPath = registryPath.Replace("HKEY_CURRENT_USER\\", string.Empty);
					}
				}
				else
				{
					hiveSelector = 0;
					registryPath = registryPath.Replace("HKEY_LOCAL_MACHINE\\", string.Empty);
				}
			}
			RegistryKey registryKey = ((hiveSelector == 0) ? Registry.LocalMachine.OpenSubKey(registryPath, writable: true) : Registry.CurrentUser.OpenSubKey(registryPath, writable: true));
			if (registryKey != null)
			{
				registryKey.DeleteValue(valueName);
				registryKey.Close();
			}
		}
		catch
		{
		}
	}

	private static RegistryValueKind ParseRegistryValueKind(string valueKindName = "")
	{
		RegistryValueKind result = RegistryValueKind.String;
		valueKindName = valueKindName.ToUpper();
		if (!(valueKindName == "DWORD"))
		{
			if (valueKindName == "BINARY")
			{
				result = RegistryValueKind.Binary;
			}
		}
		else
		{
			result = RegistryValueKind.DWord;
		}
		return result;
	}

	public static void OpenRegistryEditorAtKey(string registryPath)
	{
		try
		{
			for (int i = 0; i < 10; i++)
			{
				int num = WindowsInteropHelper.FindFirstProcessIdByName("Regedit");
				if (num == 0)
				{
					break;
				}
				WindowsInteropHelper.KillProcessByIdWithRetry(num);
			}
			Registry.SetValue("HKEY_CURRENT_USER\\Software\\Microsoft\\Windows\\CurrentVersion\\Applets\\Regedit", "LastKey", registryPath);
			WindowsInteropHelper.StartProcess("regedit.exe", "", "", 0);
		}
		catch
		{
		}
	}
}
