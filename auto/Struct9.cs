using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal struct GetVersionOutParams
{
	public byte version;

	public byte revision;

	public byte reserved;

	public byte ideDeviceMap;

	public uint capabilities;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public uint[] reservedDwords;
}
