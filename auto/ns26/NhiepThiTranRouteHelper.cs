using ns10;
using ns42;

namespace ns26;

internal class NhiepThiTranRouteHelper
{
	private static uint[,] map80RouteVariant1Coordinates;

	private static uint[,] map80RouteVariant2Coordinates;

	private static uint[,] map80RouteVariant3Coordinates;

	private static uint[,] map80RouteVariant4Coordinates;

	private static uint[,] map80RouteVariant5Coordinates;

	private static CoordinateRouteCandidate[] map80RouteCandidates;

	private static uint[,] map11RouteVariant1Coordinates;

	private static uint[,] map11RouteVariant2Coordinates;

	private static uint[,] map11RouteVariant3Coordinates;

	private static uint[,] map11RouteVariant4Coordinates;

	private static CoordinateRouteCandidate[] map11RouteCandidates;

	private static uint[,] map1RouteVariant1Coordinates;

	private static uint[,] map1RouteVariant2Coordinates;

	private static uint[,] map1RouteVariant3Coordinates;

	private static uint[,] map1RouteVariant4Coordinates;

	private static CoordinateRouteCandidate[] map1RouteCandidates;

	private static uint[,] map37RouteVariant1Coordinates;

	private static uint[,] map37RouteVariant2Coordinates;

	private static uint[,] map37RouteVariant3Coordinates;

	private static uint[,] map37RouteVariant4Coordinates;

	private static CoordinateRouteCandidate[] map37RouteCandidates;

	private static uint[,] map162RouteVariant1Coordinates;

	private static uint[,] map162RouteVariant2Coordinates;

	private static uint[,] map162RouteVariant3Coordinates;

	private static uint[,] map162RouteVariant4Coordinates;

	private static CoordinateRouteCandidate[] map162RouteCandidates;

	private static uint[,] map78RouteVariant1Coordinates;

	private static uint[,] map78RouteVariant2Coordinates;

	private static uint[,] map78RouteVariant3Coordinates;

	private static uint[,] map78RouteVariant4Coordinates;

	private static uint[,] map78RouteVariant5Coordinates;

	private static uint[,] map78RouteVariant6Coordinates;

	private static CoordinateRouteCandidate[] map78RouteCandidates;

	private static uint[,] map176RouteVariant1Coordinates;

	private static uint[,] map176RouteVariant2Coordinates;

	private static uint[,] map176RouteVariant3Coordinates;

	private static CoordinateRouteCandidate[] map176RouteCandidates;

	static NhiepThiTranRouteHelper()
	{
		uint[,] array_ = new uint[20, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_, 54488);
		map80RouteVariant1Coordinates = array_;
		uint[,] array_2 = new uint[13, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_2, 54658);
		map80RouteVariant2Coordinates = array_2;
		uint[,] array_3 = new uint[14, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_3, 54771);
		map80RouteVariant3Coordinates = array_3;
		uint[,] array_4 = new uint[20, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_4, 54892);
		map80RouteVariant4Coordinates = array_4;
		uint[,] array_5 = new uint[7, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_5, 55062);
		map80RouteVariant5Coordinates = array_5;
		map80RouteCandidates = new CoordinateRouteCandidate[5]
		{
			new CoordinateRouteCandidate
			{
				routeCoordinates = map80RouteVariant1Coordinates
			},
			new CoordinateRouteCandidate
			{
				routeCoordinates = map80RouteVariant2Coordinates
			},
			new CoordinateRouteCandidate
			{
				routeCoordinates = map80RouteVariant3Coordinates
			},
			new CoordinateRouteCandidate
			{
				routeCoordinates = map80RouteVariant4Coordinates
			},
			new CoordinateRouteCandidate
			{
				routeCoordinates = map80RouteVariant5Coordinates
			}
		};
		uint[,] array_6 = new uint[21, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_6, 55151);
		map11RouteVariant1Coordinates = array_6;
		uint[,] array_7 = new uint[20, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_7, 55329);
		map11RouteVariant2Coordinates = array_7;
		uint[,] array_8 = new uint[25, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_8, 55499);
		map11RouteVariant3Coordinates = array_8;
		uint[,] array_9 = new uint[16, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_9, 55709);
		map11RouteVariant4Coordinates = array_9;
		map11RouteCandidates = new CoordinateRouteCandidate[4]
		{
			new CoordinateRouteCandidate
			{
				routeCoordinates = map11RouteVariant1Coordinates
			},
			new CoordinateRouteCandidate
			{
				routeCoordinates = map11RouteVariant2Coordinates
			},
			new CoordinateRouteCandidate
			{
				routeCoordinates = map11RouteVariant3Coordinates
			},
			new CoordinateRouteCandidate
			{
				routeCoordinates = map11RouteVariant4Coordinates
			}
		};
		uint[,] array_10 = new uint[6, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_10, 55867);
		map1RouteVariant1Coordinates = array_10;
		uint[,] array_11 = new uint[8, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_11, 55924);
		map1RouteVariant2Coordinates = array_11;
		uint[,] array_12 = new uint[14, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_12, 55997);
		map1RouteVariant3Coordinates = array_12;
		uint[,] array_13 = new uint[15, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_13, 56118);
		map1RouteVariant4Coordinates = array_13;
		map1RouteCandidates = new CoordinateRouteCandidate[4]
		{
			new CoordinateRouteCandidate
			{
				routeCoordinates = map1RouteVariant1Coordinates
			},
			new CoordinateRouteCandidate
			{
				routeCoordinates = map1RouteVariant2Coordinates
			},
			new CoordinateRouteCandidate
			{
				routeCoordinates = map1RouteVariant3Coordinates
			},
			new CoordinateRouteCandidate
			{
				routeCoordinates = map1RouteVariant4Coordinates
			}
		};
		uint[,] array_14 = new uint[22, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_14, 56267);
		map37RouteVariant1Coordinates = array_14;
		uint[,] array_15 = new uint[31, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_15, 56453);
		map37RouteVariant2Coordinates = array_15;
		uint[,] array_16 = new uint[25, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_16, 56711);
		map37RouteVariant3Coordinates = array_16;
		uint[,] array_17 = new uint[13, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_17, 56921);
		map37RouteVariant4Coordinates = array_17;
		map37RouteCandidates = new CoordinateRouteCandidate[4]
		{
			new CoordinateRouteCandidate
			{
				routeCoordinates = map37RouteVariant1Coordinates
			},
			new CoordinateRouteCandidate
			{
				routeCoordinates = map37RouteVariant2Coordinates
			},
			new CoordinateRouteCandidate
			{
				routeCoordinates = map37RouteVariant3Coordinates
			},
			new CoordinateRouteCandidate
			{
				routeCoordinates = map37RouteVariant4Coordinates
			}
		};
		uint[,] array_18 = new uint[16, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_18, 57054);
		map162RouteVariant1Coordinates = array_18;
		uint[,] array_19 = new uint[13, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_19, 57192);
		map162RouteVariant2Coordinates = array_19;
		uint[,] array_20 = new uint[7, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_20, 57305);
		map162RouteVariant3Coordinates = array_20;
		uint[,] array_21 = new uint[10, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_21, 57370);
		map162RouteVariant4Coordinates = array_21;
		map162RouteCandidates = new CoordinateRouteCandidate[4]
		{
			new CoordinateRouteCandidate
			{
				routeCoordinates = map162RouteVariant1Coordinates
			},
			new CoordinateRouteCandidate
			{
				routeCoordinates = map162RouteVariant2Coordinates
			},
			new CoordinateRouteCandidate
			{
				routeCoordinates = map162RouteVariant3Coordinates
			},
			new CoordinateRouteCandidate
			{
				routeCoordinates = map162RouteVariant4Coordinates
			}
		};
		uint[,] array_22 = new uint[16, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_22, 57479);
		map78RouteVariant1Coordinates = array_22;
		uint[,] array_23 = new uint[6, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_23, 57617);
		map78RouteVariant2Coordinates = array_23;
		uint[,] array_24 = new uint[11, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_24, 57674);
		map78RouteVariant3Coordinates = array_24;
		uint[,] array_25 = new uint[6, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_25, 57771);
		map78RouteVariant4Coordinates = array_25;
		uint[,] array_26 = new uint[11, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_26, 57828);
		map78RouteVariant5Coordinates = array_26;
		uint[,] array_27 = new uint[16, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_27, 57925);
		map78RouteVariant6Coordinates = array_27;
		map78RouteCandidates = new CoordinateRouteCandidate[6]
		{
			new CoordinateRouteCandidate
			{
				routeCoordinates = map78RouteVariant1Coordinates
			},
			new CoordinateRouteCandidate
			{
				routeCoordinates = map78RouteVariant2Coordinates
			},
			new CoordinateRouteCandidate
			{
				routeCoordinates = map78RouteVariant3Coordinates
			},
			new CoordinateRouteCandidate
			{
				routeCoordinates = map78RouteVariant4Coordinates
			},
			new CoordinateRouteCandidate
			{
				routeCoordinates = map78RouteVariant5Coordinates
			},
			new CoordinateRouteCandidate
			{
				routeCoordinates = map78RouteVariant6Coordinates
			}
		};
		uint[,] array_28 = new uint[54, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_28, 58091);
		map176RouteVariant1Coordinates = array_28;
		uint[,] array_29 = new uint[37, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_29, 58533);
		map176RouteVariant2Coordinates = array_29;
		uint[,] array_30 = new uint[27, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_30, 58839);
		map176RouteVariant3Coordinates = array_30;
		map176RouteCandidates = new CoordinateRouteCandidate[3]
		{
			new CoordinateRouteCandidate
			{
				routeCoordinates = map176RouteVariant1Coordinates
			},
			new CoordinateRouteCandidate
			{
				routeCoordinates = map176RouteVariant2Coordinates
			},
			new CoordinateRouteCandidate
			{
				routeCoordinates = map176RouteVariant3Coordinates
			}
		};
	}

	public static uint[,] GetRouteToNhiepThiTran(int int_0, uint[] uint_30, uint[] uint_31)
	{
		if (uint_31 == null)
		{
			return null;
		}
		uint[,] result = null;
		switch (int_0)
		{
		case 37:
			result = MapTravelDataHelper.SelectBestRouteCoordinates(map37RouteCandidates, uint_30, uint_31);
			break;
		case 11:
			result = MapTravelDataHelper.SelectBestRouteCoordinates(map11RouteCandidates, uint_30, uint_31);
			break;
		case 1:
			result = MapTravelDataHelper.SelectBestRouteCoordinates(map1RouteCandidates, uint_30, uint_31);
			break;
		case 80:
			result = MapTravelDataHelper.SelectBestRouteCoordinates(map80RouteCandidates, uint_30, uint_31);
			break;
		case 78:
			result = MapTravelDataHelper.SelectBestRouteCoordinates(map78RouteCandidates, uint_30, uint_31);
			break;
		case 176:
			result = MapTravelDataHelper.SelectBestRouteCoordinates(map176RouteCandidates, uint_30, uint_31);
			break;
		case 162:
			result = MapTravelDataHelper.SelectBestRouteCoordinates(map162RouteCandidates, uint_30, uint_31);
			break;
		}
		return result;
	}
}
