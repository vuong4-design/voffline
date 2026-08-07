using System;
using System.Runtime.InteropServices;
using System.Text;

[ComImport]
[Guid("000214F9-0000-0000-C000-000000000046")]
[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
internal interface IShellLinkW
{
	void GetPath([Out][MarshalAs(UnmanagedType.LPWStr)] StringBuilder filePath, int maxPath, out IntPtr findData, int flags);

	void GetIDList(out IntPtr itemIdList);

	void SetIDList(IntPtr itemIdList);

	void GetDescription([Out][MarshalAs(UnmanagedType.LPWStr)] StringBuilder description, int maxLength);

	void SetDescription([MarshalAs(UnmanagedType.LPWStr)] string description);

	void GetWorkingDirectory([Out][MarshalAs(UnmanagedType.LPWStr)] StringBuilder workingDirectory, int maxLength);

	void SetWorkingDirectory([MarshalAs(UnmanagedType.LPWStr)] string workingDirectory);

	void GetArguments([Out][MarshalAs(UnmanagedType.LPWStr)] StringBuilder arguments, int maxLength);

	void SetArguments([MarshalAs(UnmanagedType.LPWStr)] string arguments);

	void GetHotkey(out short hotkey);

	void SetHotkey(short hotkey);

	void GetShowCmd(out int showCommand);

	void SetShowCmd(int showCommand);

	void GetIconLocation([Out][MarshalAs(UnmanagedType.LPWStr)] StringBuilder iconPath, int maxPath, out int iconIndex);

	void SetIconLocation([MarshalAs(UnmanagedType.LPWStr)] string iconPath, int iconIndex);

	void SetRelativePath([MarshalAs(UnmanagedType.LPWStr)] string relativePath, int reserved);

	void Resolve(IntPtr windowHandle, int flags);

	void SetPath([MarshalAs(UnmanagedType.LPWStr)] string filePath);
}
