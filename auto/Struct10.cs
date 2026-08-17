using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal struct SendCommandInputParams
{
	public uint bufferSize;

	public IdeRegisters driveRegisters;

	public byte driveNumber;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] reservedBytes;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public uint[] reservedDwords;

	public byte buffer;
}
