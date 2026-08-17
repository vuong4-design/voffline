using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal struct DriverStatus
{
	public byte driverError;

	public byte ideStatus;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] reservedBytes;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public uint[] reservedDwords;
}
