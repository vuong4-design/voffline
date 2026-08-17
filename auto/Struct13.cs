using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal struct SendCommandOutputParams
{
	public uint bufferSize;

	public DriverStatus driverStatus;

	public AtaIdentifyData identifyData;
}
