using ns10;
using ns61;

namespace ns94;

internal class HoaSonMapRouteHelper
{
	public static NamedMapLocation[] MapGates;

	public static uint[,] uint_0;

	public static uint[,] uint_1;

	public static uint[,] uint_2;

	private static uint[,] routeSetThreeCoordinates;

	private static uint[,] routeSetFourCoordinates;

	static HoaSonMapRouteHelper()
	{
		MapGates = new NamedMapLocation[3]
		{
			new NamedMapLocation
			{
				mapId = 333,
				coordinates = new uint[2] { 42240u, 92160u },
				name = "T©y"
			},
			new NamedMapLocation
			{
				mapId = 333,
				coordinates = new uint[2] { 49408u, 102464u },
				name = "®«ng|§«ng"
			},
			new NamedMapLocation
			{
				mapId = 333,
				coordinates = new uint[2] { 41265u, 102756u },
				name = "Nam"
			}
		};
		uint[,] array_ = new uint[3, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_, 376335);
		uint_0 = array_;
		uint[,] array_2 = new uint[3, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_2, 376368);
		uint_1 = array_2;
		uint[,] array_3 = new uint[4, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_3, 376401);
		uint_2 = array_3;
		uint[,] array_4 = new uint[52, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_4, 376442);
		routeSetThreeCoordinates = array_4;
		uint[,] array_5 = new uint[84, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_5, 376868);
		routeSetFourCoordinates = array_5;
	}

	public static bool IsCloserToRouteSetFourThanRouteSetThree(uint[] uint_5)
	{
		long num = GameAutomationUtility.GetNearestCoordinateSquaredDistance(routeSetFourCoordinates, uint_5);
		long num2 = GameAutomationUtility.GetNearestCoordinateSquaredDistance(routeSetThreeCoordinates, uint_5);
		return num < num2;
	}

	public static uint[,] GetNearestRouteSet(uint[] uint_5)
	{
		uint[,] array = new uint[3, 2];
		int num = GameAutomationUtility.FindNearestCoordinateIndex(uint_0, uint_5);
		array[0, 0] = uint_0[num, 0];
		array[0, 1] = uint_0[num, 1];
		num = GameAutomationUtility.FindNearestCoordinateIndex(uint_1, uint_5);
		array[1, 0] = uint_1[num, 0];
		array[1, 1] = uint_1[num, 1];
		num = GameAutomationUtility.FindNearestCoordinateIndex(uint_2, uint_5);
		array[2, 0] = uint_2[num, 0];
		array[2, 1] = uint_2[num, 1];
		return GameAutomationUtility.FindNearestCoordinateIndex(array, uint_5) switch
		{
			1 => uint_1, 
			0 => uint_0, 
			_ => uint_2, 
		};
	}
}
