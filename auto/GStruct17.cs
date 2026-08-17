using System;

[Serializable]
public struct AtaDriveIdentity
{
	public string modelNumber;

	public string firmwareRevision;

	public string serialNumber;

	public uint capacityMegabytes;
}
