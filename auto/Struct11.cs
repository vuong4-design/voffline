using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal struct IdeRegisters
{
	public byte featuresRegister;

	public byte sectorCountRegister;

	public byte sectorNumberRegister;

	public byte cylinderLowRegister;

	public byte cylinderHighRegister;

	public byte driveHeadRegister;

	public byte commandRegister;

	public byte reserved;
}
