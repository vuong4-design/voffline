using ns10;
using ns61;

namespace ns86;

internal class ViSonDaoRouteHelper
{
	public static CoordinateRouteCandidate[] navigationRouteCandidates = null;

	public static CoordinateRouteCandidate[] anchorRegionRouteCandidates = null;

	public static uint[] GetNearestRegionAnchorCoordinate(uint[] uint_0)
	{
		if (anchorRegionRouteCandidates == null)
		{
			anchorRegionRouteCandidates = CreateAnchorRegionRouteGroups();
		}
		int num = -1;
		long num2 = -1L;
		for (int i = 0; i < anchorRegionRouteCandidates.Length; i++)
		{
			long num3 = Class64.GetNearestCoordinateSquaredDistance(anchorRegionRouteCandidates[i].routeCoordinates, uint_0);
			if (num < 0 || num3 < num2)
			{
				num = i;
				num2 = num3;
			}
		}
		return num switch
		{
			0 => new uint[2] { 52692u, 103470u }, 
			1 => new uint[2] { 49674u, 104586u }, 
			2 => new uint[2] { 49046u, 99282u }, 
			_ => new uint[2] { 52318u, 98808u }, 
		};
	}

	public static CoordinateRouteCandidate[] CreateNavigationRouteGroups()
	{
		uint[,] array = new uint[12, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array, 367135);
		uint[,] uint_ = array;
		uint[,] array2 = new uint[10, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array2, 367240);
		uint[,] uint_2 = array2;
		uint[,] array3 = new uint[15, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array3, 367329);
		uint[,] uint_3 = array3;
		uint[,] array4 = new uint[12, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array4, 367458);
		uint[,] uint_4 = array4;
		uint[,] array5 = new uint[15, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array5, 367563);
		uint[,] uint_5 = array5;
		uint[,] array6 = new uint[9, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array6, 367692);
		uint[,] uint_6 = array6;
		uint[,] array7 = new uint[12, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array7, 367773);
		uint[,] uint_7 = array7;
		return new CoordinateRouteCandidate[7]
		{
			new CoordinateRouteCandidate
			{
				routeCoordinates = uint_
			},
			new CoordinateRouteCandidate
			{
				routeCoordinates = uint_2
			},
			new CoordinateRouteCandidate
			{
				routeCoordinates = uint_3
			},
			new CoordinateRouteCandidate
			{
				routeCoordinates = uint_4
			},
			new CoordinateRouteCandidate
			{
				routeCoordinates = uint_5
			},
			new CoordinateRouteCandidate
			{
				routeCoordinates = uint_6
			},
			new CoordinateRouteCandidate
			{
				routeCoordinates = uint_7
			}
		};
	}

	public static CoordinateRouteCandidate[] CreateAnchorRegionRouteGroups()
	{
		uint[,] array = new uint[7, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array, 367910);
		uint[,] uint_ = array;
		uint[,] array2 = new uint[7, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array2, 367975);
		uint[,] uint_2 = array2;
		uint[,] array3 = new uint[8, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array3, 368040);
		uint[,] uint_3 = array3;
		uint[,] array4 = new uint[7, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array4, 368113);
		uint[,] uint_4 = array4;
		return new CoordinateRouteCandidate[4]
		{
			new CoordinateRouteCandidate
			{
				routeCoordinates = uint_4
			},
			new CoordinateRouteCandidate
			{
				routeCoordinates = uint_3
			},
			new CoordinateRouteCandidate
			{
				routeCoordinates = uint_2
			},
			new CoordinateRouteCandidate
			{
				routeCoordinates = uint_
			}
		};
	}
}
