using System;

public struct NativeMouseInput
{
	public int dx;

	public int dy;

	public uint mouseData;

	public uint flags;

	public uint time;

	public IntPtr extraInfo;
}
