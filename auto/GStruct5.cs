using System;

public struct NativeListViewItem
{
	public uint mask;

	public int itemIndex;

	public int subItemIndex;

	public uint state;

	public uint stateMask;

	public IntPtr textPointer;

	public int textCapacity;

	public int imageIndex;
}
