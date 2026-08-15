using System.Diagnostics;

public struct CharacterSyncSnapshot
{
	public int accountId;

	public int processHandle;

	public uint windowHandle;

	public uint gameModuleBaseAddress;

	public uint entityId;

	public uint currentTargetEntityId;

	public Process process;

	public string characterName;

	public string mapName;

	public long lastRefreshTicks;

	public long long_1;

	public int killerStatus;

	public int fightState;

	public int mapId;

	public int int_5;

	public int entityExistsFlag;

	public uint[] coordinates;

	public uint packedMousePosition;

	public int lastVirtualKeyCode;

	public int spaceKeyPressedFlag;

	public int pendingSyncCommandCode;

	public bool snapshotUnavailable;

	public bool bool_1;

	public int int_10;

	public bool bool_2;

	public int[] int_11;
}
