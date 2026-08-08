using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using ns13;
using ns71;

namespace ns17;

internal class CoordinateRouteRunner : IDisposable
{
	private readonly ListView routeListView;

	private readonly Func<CharacterAccountConfig?> accountProvider;

	private readonly Func<CharacterAccountConfig, uint[]> positionProvider;

	private readonly Func<CharacterAccountConfig, int> combatStateProvider;

	private readonly Func<bool> canMoveProvider;

	private readonly Action<string> messageCallback;

	private readonly Func<CharacterAccountConfig, int> mapIdProvider;

	private readonly Action disableRouteAction;

	private readonly int pollIntervalMs;

	private System.Threading.Timer routeTimer;

	private readonly List<uint[]> waypoints = new List<uint[]>();

	private int currentWaypointIndex;

	private bool movingBackward;

	private bool wasMovementBlocked = false;

	private bool wasCombatInactive = false;

	private bool isDisposed = false;

	private readonly object timerLock = new object();

	private int lastAnnouncedWaypointIndex = -1;

	private uint[] uint_0 = null;

	private static readonly int[] allowedMapIds = new int[7] { 323, 324, 325, 379, 380, 381, 382 };

	private const uint arrivalDistanceSquared = 5625u;

	public CoordinateRouteRunner(ListView sourceListView, Func<CharacterAccountConfig?> accountProviderArgument, Func<CharacterAccountConfig, uint[]> positionProviderArgument, Func<CharacterAccountConfig, int> combatStateProviderArgument = null, Func<bool> canMoveProviderArgument = null, Action<string> messageCallbackArgument = null, Func<CharacterAccountConfig, int> mapIdProviderArgument = null, Action disableRouteActionArgument = null, int intervalMs = 300)
	{
		routeListView = sourceListView ?? throw new ArgumentNullException("listViewTrain");
		accountProvider = accountProviderArgument ?? throw new ArgumentNullException("playerProvider");
		positionProvider = positionProviderArgument ?? throw new ArgumentNullException("positionProvider");
		combatStateProvider = combatStateProviderArgument;
		canMoveProvider = canMoveProviderArgument;
		messageCallback = messageCallbackArgument;
		mapIdProvider = mapIdProviderArgument;
		disableRouteAction = disableRouteActionArgument;
		pollIntervalMs = intervalMs;
	}

	public bool Start()
	{
		waypoints.Clear();
		LoadWaypoints(waypoints);
		CharacterAccountConfig? characterAccountConfig = accountProvider();
		if (!characterAccountConfig.HasValue)
		{
			return false;
		}
		if (waypoints.Count == 0)
		{
			Class75.smethod_52(characterAccountConfig.Value, "<bclr=red><color=white>[TBTkeoxe]: Vui lßng lÊy to¹ ®é råi bËt chøc n\u00a8ng.");
			return false;
		}
		uint[] array = positionProvider(characterAccountConfig.Value);
		if (array != null && array.Length >= 2)
		{
			uint_0 = null;
			wasCombatInactive = false;
			wasMovementBlocked = false;
			currentWaypointIndex = FindNearestWaypointIndex(array);
			movingBackward = ShouldStartMovingBackward(currentWaypointIndex, waypoints.Count);
			lastAnnouncedWaypointIndex = currentWaypointIndex;
			lock (timerLock)
			{
				if (routeTimer == null)
				{
					routeTimer = new System.Threading.Timer(OnTimerTick, null, pollIntervalMs, pollIntervalMs);
				}
				else
				{
					routeTimer.Change(pollIntervalMs, pollIntervalMs);
				}
			}
			return true;
		}
		return false;
	}

	public void Stop()
	{
		lock (timerLock)
		{
			routeTimer?.Change(-1, -1);
		}
	}

	public void Dispose()
	{
		lock (timerLock)
		{
			isDisposed = true;
			routeTimer?.Change(-1, -1);
			routeTimer?.Dispose();
			routeTimer = null;
		}
	}

	private void OnTimerTick(object state)
	{
		if (isDisposed)
		{
			return;
		}
		CharacterAccountConfig? characterAccountConfig = accountProvider();
		if (!characterAccountConfig.HasValue)
		{
			Stop();
			return;
		}
		CharacterAccountConfig value = characterAccountConfig.Value;
		if (waypoints.Count == 0)
		{
			Class75.smethod_52(value, "<bclr=red><color=white>[TBTkeoxe]: Vui lßng lÊy to¹ ®é råi bËt chøc n\u00a8ng.");
			disableRouteAction?.Invoke();
			Stop();
			return;
		}
		if (mapIdProvider != null)
		{
			int num = mapIdProvider(value);
			bool flag = false;
			for (int i = 0; i < allowedMapIds.Length; i++)
			{
				if (num == allowedMapIds[i])
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				Class75.smethod_52(value, "<bclr=red><color=white>[TBTkeoxe]: Sai maps TK, tù ®éng t¾t Chøc N\u00a8ng");
				disableRouteAction?.Invoke();
				Stop();
				return;
			}
		}
		if (canMoveProvider != null)
		{
			if (!canMoveProvider())
			{
				if (!wasMovementBlocked)
				{
					Class75.smethod_52(value, "<bclr=red><color=white>[TBTkeoxe]:<bclr=blue><color=white> §ang chê rêi khái hËu doanh");
					wasMovementBlocked = true;
				}
				return;
			}
			if (wasMovementBlocked)
			{
				wasMovementBlocked = false;
				if (waypoints.Count > 0)
				{
					uint[] array = positionProvider(value);
					if (array != null && array.Length >= 2)
					{
						currentWaypointIndex = FindNearestWaypointIndex(array);
						movingBackward = ShouldStartMovingBackward(currentWaypointIndex, waypoints.Count);
					}
					else
					{
						int num2 = currentWaypointIndex;
						if (num2 < 0 || num2 >= waypoints.Count)
						{
							num2 = (movingBackward ? (waypoints.Count - 1) : 0);
						}
						currentWaypointIndex = num2;
					}
					uint[] array2 = waypoints[currentWaypointIndex];
					lastAnnouncedWaypointIndex = -1;
					Class75.smethod_52(value, "<bclr=red><color=white>[TBTkeoxe]:<bclr=blue><color=white>§ang di chuyÓn ®Õn to¹ ®é: (" + array2[0] + ", " + array2[1] + ")");
				}
			}
		}
		uint[] array3 = null;
		if (combatStateProvider != null)
		{
			int num3 = combatStateProvider(value);
			if (num3 <= 0)
			{
				uint_0 = null;
				currentWaypointIndex = -1;
				movingBackward = false;
				lastAnnouncedWaypointIndex = -1;
				if (!wasCombatInactive)
				{
					wasCombatInactive = true;
				}
				return;
			}
			if (wasCombatInactive)
			{
				wasCombatInactive = false;
				array3 = positionProvider(value);
				if (array3 != null && array3.Length >= 2)
				{
					currentWaypointIndex = FindNearestWaypointIndex(array3);
					movingBackward = ShouldStartMovingBackward(currentWaypointIndex, waypoints.Count);
					lastAnnouncedWaypointIndex = -1;
					uint_0 = null;
					uint[] array4 = waypoints[currentWaypointIndex];
					Class75.smethod_52(value, "<bclr=red><color=white>[TBTkeoxe]:<bclr=blue><color=white>§· vµo chiÕn ®Êu, di chuyÓn ®Õn to¹ ®é gÇn nhÊt: (" + array4[0] + ", " + array4[1] + ")");
				}
				else
				{
					currentWaypointIndex = -1;
					movingBackward = false;
					lastAnnouncedWaypointIndex = -1;
				}
			}
			else
			{
				array3 = positionProvider(value);
			}
		}
		if (array3 == null)
		{
			array3 = positionProvider(value);
		}
		if (array3 != null && array3.Length >= 2)
		{
			if (currentWaypointIndex < 0 || currentWaypointIndex >= waypoints.Count)
			{
				currentWaypointIndex = FindNearestWaypointIndex(array3);
				movingBackward = ShouldStartMovingBackward(currentWaypointIndex, waypoints.Count);
				lastAnnouncedWaypointIndex = -1;
				uint_0 = null;
			}
			uint[] array5 = waypoints[currentWaypointIndex];
			uint num4 = CalculateSquaredDistance(array3, array5);
			if (num4 <= 5625)
			{
				Class75.smethod_52(value, "<bclr=red><color=white>[TBTkeoxe] :<bclr=blue><color=white>§· ®Õn to¹ ®é: (" + array5[0] + ", " + array5[1] + ")");
				AdvanceWaypoint();
				array5 = waypoints[currentWaypointIndex];
				lastAnnouncedWaypointIndex = -1;
			}
			if (currentWaypointIndex != lastAnnouncedWaypointIndex)
			{
				Class75.smethod_52(value, "<bclr=red><color=white>[TBTkeoxe] :<bclr=blue><color=white>Di chuyÓn ®Õn to¹ ®é tiÕp theo: (" + array5[0] + ", " + array5[1] + ")");
				lastAnnouncedWaypointIndex = currentWaypointIndex;
			}
			Class13.smethod_1(value, array5);
		}
	}

	private void AdvanceWaypoint()
	{
		if (movingBackward)
		{
			currentWaypointIndex--;
			if (currentWaypointIndex < 0)
			{
				if (waypoints.Count > 1)
				{
					currentWaypointIndex = 1;
					movingBackward = false;
				}
				else
				{
					currentWaypointIndex = 0;
				}
			}
			return;
		}
		currentWaypointIndex++;
		if (currentWaypointIndex >= waypoints.Count)
		{
			if (waypoints.Count > 1)
			{
				currentWaypointIndex = waypoints.Count - 2;
				movingBackward = true;
			}
			else
			{
				currentWaypointIndex = 0;
			}
		}
	}

	private static uint CalculateSquaredDistance(uint[] position, uint[] targetPosition)
	{
		if (position != null && targetPosition != null && position.Length >= 2 && targetPosition.Length >= 2)
		{
			long num = (long)position[0] - (long)targetPosition[0];
			long num2 = (long)position[1] - (long)targetPosition[1];
			return (uint)(num * num + num2 * num2);
		}
		return uint.MaxValue;
	}

	private static bool ShouldStartMovingBackward(int waypointIndex, int waypointCount)
	{
		int num = waypointCount - 1 - waypointIndex;
		return num < waypointIndex;
	}

	private int FindNearestWaypointIndex(uint[] position)
	{
		uint num = uint.MaxValue;
		int result = 0;
		for (int i = 0; i < waypoints.Count; i++)
		{
			uint num2 = CalculateSquaredDistance(position, waypoints[i]);
			if (num2 < num)
			{
				num = num2;
				result = i;
			}
		}
		return result;
	}

	private static void ReadWaypointsFromListView(ICollection<uint[]> destination, ListView sourceListView)
	{
		foreach (ListViewItem item in sourceListView.Items)
		{
			if (item != null && item.SubItems != null && item.SubItems.Count >= 2)
			{
				string[] array = item.SubItems[1].Text.Split(',');
				if (array.Length >= 2 && uint.TryParse(array[0], out var result) && uint.TryParse(array[1], out var result2))
				{
					destination.Add(new uint[2] { result, result2 });
				}
			}
		}
	}

	private void LoadWaypoints(ICollection<uint[]> destination)
	{
		ReadWaypointsFromListView(destination, routeListView);
	}
}
