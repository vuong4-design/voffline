using System;

public struct GStruct3
{
	public uint structureSize;

	public string reserved;

	public string desktopName;

	public string windowTitle;

	public uint windowX;

	public uint windowY;

	public uint windowWidth;

	public uint windowHeight;

	public uint consoleWidth;

	public uint consoleHeight;

	public uint fillAttribute;

	public uint flags;

	public short showWindow;

	public short reservedByteCount;

	public IntPtr reservedBytesPointer;

	public IntPtr standardInputHandle;

	public IntPtr standardOutputHandle;

	public IntPtr standardErrorHandle;
}
