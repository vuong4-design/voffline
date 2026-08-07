using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace ns15;

internal class DebuggerDetector
{
	[StructLayout(LayoutKind.Sequential)]
	internal class ProcessBasicInformation
	{
		internal IntPtr reserved1;

		internal IntPtr pebBaseAddress;

		internal IntPtr reserved2_0;

		internal IntPtr reserved2_1;

		internal IntPtr uniqueProcessId;

		internal IntPtr reserved3;
	}

	internal delegate int NtQueryInformationProcessDelegate(IntPtr processHandle, int processInformationClass, ProcessBasicInformation processInformation, uint processInformationLength, out uint returnLength);

	internal delegate int NtQueryInformationProcessDebugPortDelegate(IntPtr processHandle, int processInformationClass, out uint debugPort, uint processInformationLength, out uint returnLength);

	internal delegate int IsDebuggerPresentDelegate();

	internal delegate void OutputDebugStringDelegate([MarshalAs(UnmanagedType.LPStr)] string outputString);

	internal delegate int CheckRemoteDebuggerPresentDelegate(IntPtr processHandle, ref int debuggerPresent);

	internal delegate int EnumWindowsCallback(IntPtr windowHandle, IntPtr lParam);

	internal delegate int EnumWindowsDelegate(EnumWindowsCallback enumWindowsCallback, IntPtr lParam);

	internal const uint uint_0 = 1024u;

	internal const uint uint_1 = 64u;

	internal const int int_0 = 0;

	private static bool debuggerWindowDetected;

	[DllImport("kernel32.dll", ExactSpelling = true)]
	internal static extern void SetLastError(uint errorCode);

	[DllImport("kernel32.dll", ExactSpelling = true)]
	internal static extern int CloseHandle(IntPtr handle);

	[DllImport("kernel32.dll", ExactSpelling = true)]
	internal static extern IntPtr OpenProcess(uint desiredAccess, int inheritHandle, uint processId);

	[DllImport("kernel32.dll", ExactSpelling = true)]
	internal static extern uint GetCurrentProcessId();

	[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
	internal static extern IntPtr LoadLibrary(string libraryName);

	[DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true)]
	internal static extern NtQueryInformationProcessDelegate GetProcAddress(IntPtr moduleHandle, string procedureName);

	[DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetProcAddress", ExactSpelling = true)]
	internal static extern NtQueryInformationProcessDebugPortDelegate GetProcAddress_1(IntPtr moduleHandle, string procedureName);

	[DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetProcAddress", ExactSpelling = true)]
	internal static extern CheckRemoteDebuggerPresentDelegate GetProcAddress_2(IntPtr moduleHandle, string procedureName);

	[DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetProcAddress", ExactSpelling = true)]
	internal static extern IsDebuggerPresentDelegate GetProcAddress_3(IntPtr moduleHandle, string procedureName);

	[DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetProcAddress", ExactSpelling = true)]
	internal static extern OutputDebugStringDelegate GetProcAddress_4(IntPtr moduleHandle, string procedureName);

	[DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetProcAddress", ExactSpelling = true)]
	internal static extern EnumWindowsDelegate GetProcAddress_5(IntPtr moduleHandle, string procedureName);

	private static int InspectWindowForDebugger(IntPtr windowHandle, IntPtr lParam)
	{
		string[] debuggerWindowClasses = new string[1] { "OLLYDBG" };
		string windowClassName = GetWindowClassName(windowHandle);
		string[] windowClasses = debuggerWindowClasses;
		foreach (string debuggerWindowClass in windowClasses)
		{
			if (string.Compare(windowClassName, debuggerWindowClass, ignoreCase: true) == 0)
			{
				debuggerWindowDetected = true;
				return 0;
			}
		}
		return 1;
	}

	[DllImport("user32.dll", CharSet = CharSet.Auto)]
	internal static extern int GetClassName(IntPtr windowHandle, StringBuilder className, int maxCount);

	internal static string GetWindowClassName(IntPtr windowHandle)
	{
		StringBuilder className = new StringBuilder(260);
		GetClassName(windowHandle, className, className.Capacity);
		return className.ToString();
	}

	internal static void ThrowIfDebuggerDetected()
	{
		if (IsDebuggerDetected())
		{
			string debuggerName = "Debugger";
			throw new Exception(string.Format("{0} was found - this software cannot be executed under the {0}.", debuggerName));
		}
	}

	internal static bool IsDebuggerDetected()
	{
		try
		{
			if (Debugger.IsAttached)
			{
				return true;
			}
			IntPtr kernel32Module = LoadLibrary("kernel32.dll");
			IsDebuggerPresentDelegate isDebuggerPresent = GetProcAddress_3(kernel32Module, "IsDebuggerPresent");
			if (isDebuggerPresent != null && isDebuggerPresent() != 0)
			{
				return true;
			}
			uint currentProcessId = GetCurrentProcessId();
			IntPtr currentProcess = OpenProcess(1024u, 0, currentProcessId);
			if (currentProcess != IntPtr.Zero)
			{
				try
				{
					CheckRemoteDebuggerPresentDelegate checkRemoteDebuggerPresent = GetProcAddress_2(kernel32Module, "CheckRemoteDebuggerPresent");
					if (checkRemoteDebuggerPresent != null)
					{
						int debuggerPresent = 0;
						if (checkRemoteDebuggerPresent(currentProcess, ref debuggerPresent) != 0 && debuggerPresent != 0)
						{
							return true;
						}
					}
				}
				finally
				{
					CloseHandle(currentProcess);
				}
			}
			bool invalidHandleRaisedException = false;
			try
			{
				CloseHandle(new IntPtr(305419896));
			}
			catch
			{
				invalidHandleRaisedException = true;
			}
			if (invalidHandleRaisedException)
			{
				return true;
			}
			try
			{
				IntPtr user32Module = LoadLibrary("user32.dll");
				EnumWindowsDelegate enumWindows = GetProcAddress_5(user32Module, "EnumWindows");
				if (enumWindows != null)
				{
					debuggerWindowDetected = false;
					enumWindows(InspectWindowForDebugger, IntPtr.Zero);
					if (debuggerWindowDetected)
					{
						return true;
					}
				}
			}
			catch
			{
			}
		}
		catch
		{
		}
		return false;
	}
}
