using System;

public struct NativeProcessInformation
{
	public IntPtr processHandle;

	public IntPtr threadHandle;

	public uint processId;

	public uint threadId;
}
