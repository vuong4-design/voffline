using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, Pack = 1, Size = 512)]
internal struct AtaIdentifyData
{
	public ushort generalConfiguration;

	public ushort cylinderCount;

	public ushort reservedWord2;

	public ushort headCount;

	public ushort bytesPerTrack;

	public ushort bytesPerSector;

	public ushort sectorsPerTrack;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public ushort[] vendorUniqueWords;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public byte[] serialNumberBytes;

	public ushort bufferType;

	public ushort bufferSizeWords;

	public ushort eccSize;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] firmwareRevisionBytes;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
	public byte[] modelNumberBytes;

	public ushort vendorUniqueWord47;

	public ushort doubleWordIo;

	public ushort capabilities;

	public ushort reservedWord50;

	public ushort pioTiming;

	public ushort dmaTiming;

	public ushort fieldValidityFlags;

	public ushort currentCylinderCount;

	public ushort currentHeadCount;

	public ushort currentSectorsPerTrack;

	public uint currentSectorCapacity;

	public ushort multipleSectorSetting;

	public uint totalAddressableSectors;

	public ushort singleWordDma;

	public ushort multiWordDma;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] reservedBytes;
}
