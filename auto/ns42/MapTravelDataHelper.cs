using System;
using ns10;
using ns11;
using ns28;
using ns34;
using ns36;
using ns41;
using ns61;

namespace ns42;

internal class MapTravelDataHelper
{
	public static uint[,] uint_0;

	public static int[] int_0;

	public static MapTravelConnection[] travelConnections;

	public static TravelMapEntry[] gstruct27_0;

	static MapTravelDataHelper()
	{
		uint[,] array_ = new uint[9, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_, 189655);
		uint_0 = array_;
		int_0 = new int[16]
		{
			74, 75, 76, 77, 103, 131, 136, 140, 224, 225,
			226, 227, 319, 320, 321, 322
		};
		MapTravelConnection[] array = new MapTravelConnection[127];
		ref MapTravelConnection reference = ref array[0];
		MapTravelConnection gStruct = new MapTravelConnection
		{
			sourceMapId = 1,
			sourceMapName = "Ph\u00adîng T\u00adêng"
		};
		uint[,] array_2 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_2, 189817);
		gStruct.routeCoordinates = array_2;
		gStruct.destinationMapId = 7;
		gStruct.destinationMapName = "TÇn L\u00a8ng";
		reference = gStruct;
		ref MapTravelConnection reference2 = ref array[1];
		MapTravelConnection gStruct2 = new MapTravelConnection
		{
			sourceMapId = 7,
			sourceMapName = "TÇn L\u00a8ng"
		};
		uint[,] array_3 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_3, 189850);
		gStruct2.routeCoordinates = array_3;
		gStruct2.destinationMapId = 1;
		gStruct2.destinationMapName = "Ph\u00adîng T\u00adêng";
		reference2 = gStruct2;
		ref MapTravelConnection reference3 = ref array[2];
		MapTravelConnection gStruct3 = new MapTravelConnection
		{
			sourceMapId = 174,
			sourceMapName = "Long TuyÒn th«n"
		};
		uint[,] array_4 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_4, 189883);
		gStruct3.routeCoordinates = array_4;
		gStruct3.destinationMapId = 195;
		gStruct3.destinationMapName = "Nh¹n §·ng s¬n";
		reference3 = gStruct3;
		ref MapTravelConnection reference4 = ref array[3];
		MapTravelConnection gStruct4 = new MapTravelConnection
		{
			sourceMapId = 195,
			sourceMapName = "Nh¹n §·ng s¬n"
		};
		uint[,] array_5 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_5, 189916);
		gStruct4.routeCoordinates = array_5;
		gStruct4.destinationMapId = 174;
		gStruct4.destinationMapName = "Long TuyÒn th«n";
		reference4 = gStruct4;
		ref MapTravelConnection reference5 = ref array[4];
		MapTravelConnection gStruct5 = new MapTravelConnection
		{
			sourceMapId = 54,
			sourceMapName = "Nam Nh¹c trÊn"
		};
		uint[,] array_6 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_6, 189949);
		gStruct5.routeCoordinates = array_6;
		gStruct5.destinationMapId = 875;
		gStruct5.destinationMapName = "H¾c Sa ®éng";
		reference5 = gStruct5;
		ref MapTravelConnection reference6 = ref array[5];
		MapTravelConnection gStruct6 = new MapTravelConnection
		{
			sourceMapId = 875,
			sourceMapName = "H¾c Sa ®éng"
		};
		uint[,] array_7 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_7, 189982);
		gStruct6.routeCoordinates = array_7;
		gStruct6.destinationMapId = 54;
		gStruct6.destinationMapName = "Nam Nh¹c trÊn";
		reference6 = gStruct6;
		ref MapTravelConnection reference7 = ref array[6];
		MapTravelConnection gStruct7 = new MapTravelConnection
		{
			sourceMapId = 103,
			sourceMapName = "ThiÕu L©m ph\u00b8i"
		};
		uint[,] array_8 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_8, 190015);
		gStruct7.routeCoordinates = array_8;
		gStruct7.destinationMapId = 110;
		gStruct7.destinationMapName = "La H\u00b8n §\u00adêng";
		reference7 = gStruct7;
		ref MapTravelConnection reference8 = ref array[7];
		MapTravelConnection gStruct8 = new MapTravelConnection
		{
			sourceMapId = 110,
			sourceMapName = "La H\u00b8n §\u00adêng"
		};
		uint[,] array_9 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_9, 190048);
		gStruct8.routeCoordinates = array_9;
		gStruct8.destinationMapId = 103;
		gStruct8.destinationMapName = "ThiÕu L©m ph\u00b8i";
		reference8 = gStruct8;
		ref MapTravelConnection reference9 = ref array[8];
		MapTravelConnection gStruct9 = new MapTravelConnection
		{
			sourceMapId = 110,
			sourceMapName = "La H\u00b8n §\u00adêng"
		};
		uint[,] array_10 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_10, 190081);
		gStruct9.routeCoordinates = array_10;
		gStruct9.destinationMapId = 114;
		gStruct9.destinationMapName = "108 La H\u00b8n trËn";
		reference9 = gStruct9;
		ref MapTravelConnection reference10 = ref array[9];
		MapTravelConnection gStruct10 = new MapTravelConnection
		{
			sourceMapId = 114,
			sourceMapName = "108 La H\u00b8n trËn"
		};
		uint[,] array_11 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_11, 190114);
		gStruct10.routeCoordinates = array_11;
		gStruct10.destinationMapId = 110;
		gStruct10.destinationMapName = "La H\u00b8n §\u00adêng";
		reference10 = gStruct10;
		ref MapTravelConnection reference11 = ref array[10];
		MapTravelConnection gStruct11 = new MapTravelConnection
		{
			sourceMapId = 1,
			sourceMapName = "Ph\u00adîng T\u00adêng"
		};
		uint[,] array_12 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_12, 190147);
		gStruct11.routeCoordinates = array_12;
		gStruct11.destinationMapId = 3;
		gStruct11.destinationMapName = "KiÕm C\u00b8c T©y B¾";
		reference11 = gStruct11;
		ref MapTravelConnection reference12 = ref array[11];
		MapTravelConnection gStruct12 = new MapTravelConnection
		{
			sourceMapId = 3,
			sourceMapName = "KiÕm C\u00b8c T©y B¾"
		};
		uint[,] array_13 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_13, 190180);
		gStruct12.routeCoordinates = array_13;
		gStruct12.destinationMapId = 1;
		gStruct12.destinationMapName = "Ph\u00adîng T\u00adêng";
		reference12 = gStruct12;
		ref MapTravelConnection reference13 = ref array[12];
		MapTravelConnection gStruct13 = new MapTravelConnection
		{
			sourceMapId = 53,
			sourceMapName = "Ba L\u00a8ng huyÖn"
		};
		uint[,] array_14 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_14, 190213);
		gStruct13.routeCoordinates = array_14;
		gStruct13.destinationMapId = 70;
		gStruct13.destinationMapName = "Vò L\u00a8ng s¬n";
		reference13 = gStruct13;
		ref MapTravelConnection reference14 = ref array[13];
		MapTravelConnection gStruct14 = new MapTravelConnection
		{
			sourceMapId = 70,
			sourceMapName = "Vò L\u00a8ng s¬n"
		};
		uint[,] array_15 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_15, 190246);
		gStruct14.routeCoordinates = array_15;
		gStruct14.destinationMapId = 53;
		gStruct14.destinationMapName = "Ba L\u00a8ng huyÖn";
		reference14 = gStruct14;
		ref MapTravelConnection reference15 = ref array[14];
		MapTravelConnection gStruct15 = new MapTravelConnection
		{
			sourceMapId = 53,
			sourceMapName = "Ba L\u00a8ng huyÖn"
		};
		uint[,] array_16 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_16, 190279);
		gStruct15.routeCoordinates = array_16;
		gStruct15.destinationMapId = 74;
		gStruct15.destinationMapName = "Miªu LÜnh";
		reference15 = gStruct15;
		ref MapTravelConnection reference16 = ref array[15];
		MapTravelConnection gStruct16 = new MapTravelConnection
		{
			sourceMapId = 74,
			sourceMapName = "Miªu LÜnh"
		};
		uint[,] array_17 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_17, 190312);
		gStruct16.routeCoordinates = array_17;
		gStruct16.destinationMapId = 53;
		gStruct16.destinationMapName = "Ba L\u00a8ng huyÖn";
		reference16 = gStruct16;
		ref MapTravelConnection reference17 = ref array[16];
		MapTravelConnection gStruct17 = new MapTravelConnection
		{
			sourceMapId = 174,
			sourceMapName = "Long TuyÒn th«n"
		};
		uint[,] array_18 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_18, 190345);
		gStruct17.routeCoordinates = array_18;
		gStruct17.destinationMapId = 193;
		gStruct17.destinationMapName = "Vò Di s¬n";
		reference17 = gStruct17;
		ref MapTravelConnection reference18 = ref array[17];
		MapTravelConnection gStruct18 = new MapTravelConnection
		{
			sourceMapId = 193,
			sourceMapName = "Vò Di s¬n"
		};
		uint[,] array_19 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_19, 190378);
		gStruct18.routeCoordinates = array_19;
		gStruct18.destinationMapId = 174;
		gStruct18.destinationMapName = "Long TuyÒn th«n";
		reference18 = gStruct18;
		ref MapTravelConnection reference19 = ref array[18];
		MapTravelConnection gStruct19 = new MapTravelConnection
		{
			sourceMapId = 80,
			sourceMapName = "D\u00ad¬ng Ch©u"
		};
		uint[,] array_20 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_20, 190411);
		gStruct19.routeCoordinates = array_20;
		gStruct19.destinationMapId = 92;
		gStruct19.destinationMapName = "Thôc C\u00ad¬ng s¬n";
		reference19 = gStruct19;
		ref MapTravelConnection reference20 = ref array[19];
		MapTravelConnection gStruct20 = new MapTravelConnection
		{
			sourceMapId = 92,
			sourceMapName = "Thôc C\u00ad¬ng s¬n"
		};
		uint[,] array_21 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_21, 190444);
		gStruct20.routeCoordinates = array_21;
		gStruct20.destinationMapId = 80;
		gStruct20.destinationMapName = "D\u00ad¬ng Ch©u";
		reference20 = gStruct20;
		ref MapTravelConnection reference21 = ref array[20];
		MapTravelConnection gStruct21 = new MapTravelConnection
		{
			sourceMapId = 92,
			sourceMapName = "Thôc C\u00ad¬ng s¬n"
		};
		uint[,] array_22 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_22, 190477);
		gStruct21.routeCoordinates = array_22;
		gStruct21.destinationMapId = 93;
		gStruct21.destinationMapName = "TiÕn Cóc ®éng";
		reference21 = gStruct21;
		ref MapTravelConnection reference22 = ref array[21];
		MapTravelConnection gStruct22 = new MapTravelConnection
		{
			destinationMapId = 93,
			destinationMapName = "TiÕn Cóc ®éng"
		};
		uint[,] array_23 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_23, 190510);
		gStruct22.routeCoordinates = array_23;
		gStruct22.sourceMapId = 92;
		gStruct22.sourceMapName = "Thôc C\u00ad¬ng s¬n";
		reference22 = gStruct22;
		ref MapTravelConnection reference23 = ref array[22];
		MapTravelConnection gStruct23 = new MapTravelConnection
		{
			sourceMapId = 78,
			sourceMapName = "T\u00ad¬ng D\u00ad¬ng"
		};
		uint[,] array_24 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_24, 190543);
		gStruct23.routeCoordinates = array_24;
		gStruct23.destinationMapId = 90;
		gStruct23.destinationMapName = "Phôc Ng\u00adu S¬n §";
		reference23 = gStruct23;
		ref MapTravelConnection reference24 = ref array[23];
		MapTravelConnection gStruct24 = new MapTravelConnection
		{
			sourceMapId = 90,
			sourceMapName = "Phôc Ng\u00adu S¬n §"
		};
		uint[,] array_25 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_25, 190576);
		gStruct24.routeCoordinates = array_25;
		gStruct24.destinationMapId = 78;
		gStruct24.destinationMapName = "T\u00ad¬ng D\u00ad¬ng";
		reference24 = gStruct24;
		ref MapTravelConnection reference25 = ref array[24];
		MapTravelConnection gStruct25 = new MapTravelConnection
		{
			sourceMapId = 42,
			sourceMapName = "Thiªn T©m ®éng"
		};
		uint[,] array_26 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_26, 190609);
		gStruct25.routeCoordinates = array_26;
		gStruct25.destinationMapId = 43;
		gStruct25.destinationMapName = "KiÕm C\u00b8c Trung ";
		reference25 = gStruct25;
		ref MapTravelConnection reference26 = ref array[25];
		MapTravelConnection gStruct26 = new MapTravelConnection
		{
			sourceMapId = 43,
			sourceMapName = "KiÕm C\u00b8c Trung "
		};
		uint[,] array_27 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_27, 190642);
		gStruct26.routeCoordinates = array_27;
		gStruct26.destinationMapId = 42;
		gStruct26.destinationMapName = "Thiªn T©m ®éng";
		reference26 = gStruct26;
		ref MapTravelConnection reference27 = ref array[26];
		MapTravelConnection gStruct27 = new MapTravelConnection
		{
			sourceMapId = 41,
			sourceMapName = "Phôc Ng\u00adu S¬n T"
		};
		uint[,] array_28 = new uint[3, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_28, 190675);
		gStruct27.routeCoordinates = array_28;
		gStruct27.destinationMapId = 42;
		gStruct27.destinationMapName = "Thiªn T©m ®éng";
		reference27 = gStruct27;
		ref MapTravelConnection reference28 = ref array[27];
		MapTravelConnection gStruct28 = new MapTravelConnection
		{
			sourceMapId = 42,
			sourceMapName = "Thiªn T©m ®éng"
		};
		uint[,] array_29 = new uint[3, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_29, 190732);
		gStruct28.routeCoordinates = array_29;
		gStruct28.destinationMapId = 41;
		gStruct28.destinationMapName = "Phôc Ng\u00adu S¬n T";
		reference28 = gStruct28;
		ref MapTravelConnection reference29 = ref array[28];
		MapTravelConnection gStruct29 = new MapTravelConnection
		{
			sourceMapId = 37,
			sourceMapName = "BiÖn Kinh"
		};
		uint[,] array_30 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_30, 190789);
		gStruct29.routeCoordinates = array_30;
		gStruct29.destinationMapId = 41;
		gStruct29.destinationMapName = "Phôc Ng\u00adu S¬n T";
		reference29 = gStruct29;
		ref MapTravelConnection reference30 = ref array[29];
		MapTravelConnection gStruct30 = new MapTravelConnection
		{
			sourceMapId = 41,
			sourceMapName = "Phôc Ng\u00adu S¬n T"
		};
		uint[,] array_31 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_31, 190822);
		gStruct30.routeCoordinates = array_31;
		gStruct30.destinationMapId = 37;
		gStruct30.destinationMapName = "BiÖn Kinh";
		reference30 = gStruct30;
		ref MapTravelConnection reference31 = ref array[30];
		MapTravelConnection gStruct31 = new MapTravelConnection
		{
			sourceMapId = 11,
			sourceMapName = "Thµnh §«"
		};
		uint[,] array_32 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_32, 190855);
		gStruct31.routeCoordinates = array_32;
		gStruct31.destinationMapId = 21;
		gStruct31.destinationMapName = "Thanh Thµnh s¬n";
		reference31 = gStruct31;
		ref MapTravelConnection reference32 = ref array[31];
		MapTravelConnection gStruct32 = new MapTravelConnection
		{
			sourceMapId = 21,
			sourceMapName = "Thanh Thµnh s¬n"
		};
		uint[,] array_33 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_33, 190888);
		gStruct32.routeCoordinates = array_33;
		gStruct32.destinationMapId = 11;
		gStruct32.destinationMapName = "Thµnh §«";
		reference32 = gStruct32;
		ref MapTravelConnection reference33 = ref array[32];
		MapTravelConnection gStruct33 = new MapTravelConnection
		{
			sourceMapId = 162,
			sourceMapName = "§¹i Lý"
		};
		uint[,] array_34 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_34, 190921);
		gStruct33.routeCoordinates = array_34;
		gStruct33.destinationMapId = 167;
		gStruct33.destinationMapName = "§iÓm Th\u00ad¬ng s¬n";
		reference33 = gStruct33;
		ref MapTravelConnection reference34 = ref array[33];
		MapTravelConnection gStruct34 = new MapTravelConnection
		{
			sourceMapId = 167,
			sourceMapName = "§iÓm Th\u00ad¬ng s¬n"
		};
		uint[,] array_35 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_35, 190954);
		gStruct34.routeCoordinates = array_35;
		gStruct34.destinationMapId = 162;
		gStruct34.destinationMapName = "§¹i Lý";
		reference34 = gStruct34;
		ref MapTravelConnection reference35 = ref array[34];
		MapTravelConnection gStruct35 = new MapTravelConnection
		{
			sourceMapId = 175,
			sourceMapName = "T©y S¬n Th«n"
		};
		uint[,] array_36 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_36, 190987);
		gStruct35.routeCoordinates = array_36;
		gStruct35.destinationMapId = 195;
		gStruct35.destinationMapName = "Nh¹n §·ng S¬n";
		reference35 = gStruct35;
		ref MapTravelConnection reference36 = ref array[35];
		MapTravelConnection gStruct36 = new MapTravelConnection
		{
			sourceMapId = 195,
			sourceMapName = "Nh¹n §·ng S¬n"
		};
		uint[,] array_37 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_37, 191020);
		gStruct36.routeCoordinates = array_37;
		gStruct36.destinationMapId = 175;
		gStruct36.destinationMapName = "T©y S¬n Th«n";
		reference36 = gStruct36;
		ref MapTravelConnection reference37 = ref array[36];
		MapTravelConnection gStruct37 = new MapTravelConnection
		{
			sourceMapId = 53,
			sourceMapName = "Ba L\u00a8ng huyÖn"
		};
		uint[,] array_38 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_38, 191053);
		gStruct37.routeCoordinates = array_38;
		gStruct37.destinationMapId = 199;
		gStruct37.destinationMapName = "Vò L\u00a8ng ®éng";
		reference37 = gStruct37;
		ref MapTravelConnection reference38 = ref array[37];
		MapTravelConnection gStruct38 = new MapTravelConnection
		{
			sourceMapId = 199,
			sourceMapName = "Vò L\u00a8ng ®éng"
		};
		uint[,] array_39 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_39, 191086);
		gStruct38.routeCoordinates = array_39;
		gStruct38.destinationMapId = 53;
		gStruct38.destinationMapName = "Ba L\u00a8ng huyÖn";
		reference38 = gStruct38;
		ref MapTravelConnection reference39 = ref array[38];
		MapTravelConnection gStruct39 = new MapTravelConnection
		{
			sourceMapId = 53,
			sourceMapName = "Ba L\u00a8ng huyÖn"
		};
		uint[,] array_40 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_40, 191119);
		gStruct39.routeCoordinates = array_40;
		gStruct39.destinationMapId = 74;
		gStruct39.destinationMapName = "Miªu LÜnh";
		reference39 = gStruct39;
		ref MapTravelConnection reference40 = ref array[39];
		MapTravelConnection gStruct40 = new MapTravelConnection
		{
			sourceMapId = 74,
			sourceMapName = "Miªu LÜnh"
		};
		uint[,] array_41 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_41, 191152);
		gStruct40.routeCoordinates = array_41;
		gStruct40.destinationMapId = 53;
		gStruct40.destinationMapName = "Ba L\u00a8ng huyÖn";
		reference40 = gStruct40;
		ref MapTravelConnection reference41 = ref array[40];
		MapTravelConnection gStruct41 = new MapTravelConnection
		{
			sourceMapId = 74,
			sourceMapName = "Miªu LÜnh"
		};
		uint[,] array_42 = new uint[5, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_42, 191185);
		gStruct41.routeCoordinates = array_42;
		gStruct41.destinationMapId = 76;
		gStruct41.destinationMapName = "S¬n B¶o ®éng";
		reference41 = gStruct41;
		ref MapTravelConnection reference42 = ref array[41];
		MapTravelConnection gStruct42 = new MapTravelConnection
		{
			sourceMapId = 76,
			sourceMapName = "S¬n B¶o ®éng"
		};
		uint[,] array_43 = new uint[5, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_43, 191266);
		gStruct42.routeCoordinates = array_43;
		gStruct42.destinationMapId = 74;
		gStruct42.destinationMapName = "Miªu LÜnh";
		reference42 = gStruct42;
		ref MapTravelConnection reference43 = ref array[42];
		MapTravelConnection gStruct43 = new MapTravelConnection
		{
			sourceMapId = 76,
			sourceMapName = "S¬n B¶o ®éng"
		};
		uint[,] array_44 = new uint[2, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_44, 191347);
		gStruct43.routeCoordinates = array_44;
		gStruct43.destinationMapId = 75;
		gStruct43.destinationMapName = "Kho¶ Lang ®éng";
		reference43 = gStruct43;
		ref MapTravelConnection reference44 = ref array[43];
		MapTravelConnection gStruct44 = new MapTravelConnection
		{
			sourceMapId = 75,
			sourceMapName = "Kho¶ Lang ®éng"
		};
		uint[,] array_45 = new uint[2, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_45, 191392);
		gStruct44.routeCoordinates = array_45;
		gStruct44.destinationMapId = 76;
		gStruct44.destinationMapName = "S¬n B¶o ®éng";
		reference44 = gStruct44;
		ref MapTravelConnection reference45 = ref array[44];
		MapTravelConnection gStruct45 = new MapTravelConnection
		{
			sourceMapId = 75,
			sourceMapName = "Kho¶ Lang ®éng"
		};
		uint[,] array_46 = new uint[2, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_46, 191437);
		gStruct45.routeCoordinates = array_46;
		gStruct45.destinationMapId = 77;
		gStruct45.destinationMapName = "YÕn Tö ®éng";
		reference45 = gStruct45;
		ref MapTravelConnection reference46 = ref array[45];
		MapTravelConnection gStruct46 = new MapTravelConnection
		{
			sourceMapId = 77,
			sourceMapName = "YÕn Tö ®éng"
		};
		uint[,] array_47 = new uint[2, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_47, 191482);
		gStruct46.routeCoordinates = array_47;
		gStruct46.destinationMapId = 75;
		gStruct46.destinationMapName = "Kho¶ Lang ®éng";
		reference46 = gStruct46;
		ref MapTravelConnection reference47 = ref array[46];
		MapTravelConnection gStruct47 = new MapTravelConnection
		{
			sourceMapId = 20,
			sourceMapName = "Giang T©n Th«n"
		};
		uint[,] array_48 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_48, 191527);
		gStruct47.routeCoordinates = array_48;
		gStruct47.destinationMapId = 202;
		gStruct47.destinationMapName = "Phï Dung ®éng";
		reference47 = gStruct47;
		ref MapTravelConnection reference48 = ref array[47];
		MapTravelConnection gStruct48 = new MapTravelConnection
		{
			sourceMapId = 202,
			sourceMapName = "Phï Dung ®éng"
		};
		uint[,] array_49 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_49, 191560);
		gStruct48.routeCoordinates = array_49;
		gStruct48.destinationMapId = 20;
		gStruct48.destinationMapName = "Giang T©n Th«n";
		reference48 = gStruct48;
		ref MapTravelConnection reference49 = ref array[48];
		MapTravelConnection gStruct49 = new MapTravelConnection
		{
			sourceMapId = 99,
			sourceMapName = "VÜnh L¹c trÊn"
		};
		uint[,] array_50 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_50, 191593);
		gStruct49.routeCoordinates = array_50;
		gStruct49.destinationMapId = 2;
		gStruct49.destinationMapName = "Hoa S¬n";
		reference49 = gStruct49;
		ref MapTravelConnection reference50 = ref array[49];
		MapTravelConnection gStruct50 = new MapTravelConnection
		{
			sourceMapId = 2,
			sourceMapName = "Hoa S¬n"
		};
		uint[,] array_51 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_51, 191626);
		gStruct50.routeCoordinates = array_51;
		gStruct50.destinationMapId = 99;
		gStruct50.destinationMapName = "VÜnh L¹c trÊn";
		reference50 = gStruct50;
		ref MapTravelConnection reference51 = ref array[50];
		MapTravelConnection gStruct51 = new MapTravelConnection
		{
			sourceMapId = 2,
			sourceMapName = "Hoa S¬n"
		};
		uint[,] array_52 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_52, 191659);
		gStruct51.routeCoordinates = array_52;
		gStruct51.destinationMapId = 333;
		gStruct51.destinationMapName = "Hoa S¬n ph\u00b8i";
		reference51 = gStruct51;
		ref MapTravelConnection reference52 = ref array[51];
		MapTravelConnection gStruct52 = new MapTravelConnection
		{
			sourceMapId = 333,
			sourceMapName = "Hoa S¬n ph\u00b8i"
		};
		uint[,] array_53 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_53, 191692);
		gStruct52.routeCoordinates = array_53;
		gStruct52.destinationMapId = 2;
		gStruct52.destinationMapName = "Hoa S¬n";
		reference52 = gStruct52;
		ref MapTravelConnection reference53 = ref array[52];
		MapTravelConnection gStruct53 = new MapTravelConnection
		{
			sourceMapId = 100,
			sourceMapName = "Chu Tiªn trÊn"
		};
		uint[,] array_54 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_54, 191725);
		gStruct53.routeCoordinates = array_54;
		gStruct53.destinationMapId = 204;
		gStruct53.destinationMapName = "Phi Thiªn ®éng";
		reference53 = gStruct53;
		ref MapTravelConnection reference54 = ref array[53];
		MapTravelConnection gStruct54 = new MapTravelConnection
		{
			sourceMapId = 204,
			sourceMapName = "Phi Thiªn ®éng"
		};
		uint[,] array_55 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_55, 191758);
		gStruct54.routeCoordinates = array_55;
		gStruct54.destinationMapId = 100;
		gStruct54.destinationMapName = "Chu Tiªn trÊn";
		reference54 = gStruct54;
		ref MapTravelConnection reference55 = ref array[54];
		MapTravelConnection gStruct55 = new MapTravelConnection
		{
			sourceMapId = 101,
			sourceMapName = "§¹o H\u00ad¬ng th«n"
		};
		uint[,] array_56 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_56, 191791);
		gStruct55.routeCoordinates = array_56;
		gStruct55.destinationMapId = 205;
		gStruct55.destinationMapName = "D\u00ad¬ng Trung ®én";
		reference55 = gStruct55;
		ref MapTravelConnection reference56 = ref array[55];
		MapTravelConnection gStruct56 = new MapTravelConnection
		{
			sourceMapId = 205,
			sourceMapName = "D\u00ad¬ng Trung ®én"
		};
		uint[,] array_57 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_57, 191824);
		gStruct56.routeCoordinates = array_57;
		gStruct56.destinationMapId = 101;
		gStruct56.destinationMapName = "§¹o H\u00ad¬ng th«n";
		reference56 = gStruct56;
		ref MapTravelConnection reference57 = ref array[56];
		MapTravelConnection gStruct57 = new MapTravelConnection
		{
			sourceMapId = 121,
			sourceMapName = "Long M«n trÊn"
		};
		uint[,] array_58 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_58, 191857);
		gStruct57.routeCoordinates = array_58;
		gStruct57.destinationMapId = 340;
		gStruct57.destinationMapName = "M¹c Cao QuËt";
		reference57 = gStruct57;
		ref MapTravelConnection reference58 = ref array[57];
		MapTravelConnection gStruct58 = new MapTravelConnection
		{
			sourceMapId = 340,
			sourceMapName = "M¹c Cao QuËt"
		};
		uint[,] array_59 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_59, 191890);
		gStruct58.routeCoordinates = array_59;
		gStruct58.destinationMapId = 121;
		gStruct58.destinationMapName = "Long M«n trÊn";
		reference58 = gStruct58;
		ref MapTravelConnection reference59 = ref array[58];
		MapTravelConnection gStruct59 = new MapTravelConnection
		{
			sourceMapId = 131,
			sourceMapName = "C«n L«n ph\u00b8i"
		};
		uint[,] array_60 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_60, 191923);
		gStruct59.routeCoordinates = array_60;
		gStruct59.destinationMapId = 136;
		gStruct59.destinationMapName = "Kho\u00b8i Ho¹t L©m";
		reference59 = gStruct59;
		ref MapTravelConnection reference60 = ref array[59];
		MapTravelConnection gStruct60 = new MapTravelConnection
		{
			sourceMapId = 136,
			sourceMapName = "Kho\u00b8i Ho¹t L©m"
		};
		uint[,] array_61 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_61, 191956);
		gStruct60.routeCoordinates = array_61;
		gStruct60.destinationMapId = 131;
		gStruct60.destinationMapName = "C«n L«n ph\u00b8i";
		reference60 = gStruct60;
		ref MapTravelConnection reference61 = ref array[60];
		MapTravelConnection gStruct61 = new MapTravelConnection
		{
			sourceMapId = 136,
			sourceMapName = "Kho\u00b8i Ho¹t L©m"
		};
		uint[,] array_62 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_62, 191989);
		gStruct61.routeCoordinates = array_62;
		gStruct61.destinationMapId = 224;
		gStruct61.destinationMapName = "Sa m¹c ®Þa biÓu";
		reference61 = gStruct61;
		ref MapTravelConnection reference62 = ref array[61];
		MapTravelConnection gStruct62 = new MapTravelConnection
		{
			sourceMapId = 121,
			sourceMapName = "Long M«n trÊn"
		};
		uint[,] array_63 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_63, 192022);
		gStruct62.routeCoordinates = array_63;
		gStruct62.destinationMapId = 131;
		gStruct62.destinationMapName = "C«n L«n ph\u00b8i";
		reference62 = gStruct62;
		ref MapTravelConnection reference63 = ref array[62];
		MapTravelConnection gStruct63 = new MapTravelConnection
		{
			sourceMapId = 131,
			sourceMapName = "C«n L«n ph\u00b8i"
		};
		uint[,] array_64 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_64, 192055);
		gStruct63.routeCoordinates = array_64;
		gStruct63.destinationMapId = 121;
		gStruct63.destinationMapName = "Long M«n trÊn";
		reference63 = gStruct63;
		ref MapTravelConnection reference64 = ref array[63];
		MapTravelConnection gStruct64 = new MapTravelConnection
		{
			sourceMapId = 121,
			sourceMapName = "Long M«n trÊn"
		};
		uint[,] array_65 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_65, 192088);
		gStruct64.routeCoordinates = array_65;
		gStruct64.destinationMapId = 336;
		gStruct64.destinationMapName = "Phong L\u00a8ng ®é";
		reference64 = gStruct64;
		ref MapTravelConnection reference65 = ref array[64];
		MapTravelConnection gStruct65 = new MapTravelConnection
		{
			sourceMapId = 336,
			sourceMapName = "Phong L\u00a8ng ®é"
		};
		uint[,] array_66 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_66, 192121);
		gStruct65.routeCoordinates = array_66;
		gStruct65.destinationMapId = 121;
		gStruct65.destinationMapName = "Long M«n trÊn";
		reference65 = gStruct65;
		ref MapTravelConnection reference66 = ref array[65];
		MapTravelConnection gStruct66 = new MapTravelConnection
		{
			sourceMapId = 336,
			sourceMapName = "Phong L\u00a8ng ®é"
		};
		uint[,] array_67 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_67, 192154);
		gStruct66.routeCoordinates = array_67;
		gStruct66.destinationMapId = 341;
		gStruct66.destinationMapName = "M¹c B¾c Th¶o Ng";
		reference66 = gStruct66;
		ref MapTravelConnection reference67 = ref array[66];
		MapTravelConnection gStruct67 = new MapTravelConnection
		{
			sourceMapId = 341,
			sourceMapName = "M¹c B¾c Th¶o Ng"
		};
		uint[,] array_68 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_68, 192187);
		gStruct67.routeCoordinates = array_68;
		gStruct67.destinationMapId = 336;
		gStruct67.destinationMapName = "Phong L\u00a8ng ®é";
		reference67 = gStruct67;
		ref MapTravelConnection reference68 = ref array[67];
		MapTravelConnection gStruct68 = new MapTravelConnection
		{
			sourceMapId = 121,
			sourceMapName = "Long M«n trÊn"
		};
		uint[,] array_69 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_69, 192220);
		gStruct68.routeCoordinates = array_69;
		gStruct68.destinationMapId = 140;
		gStruct68.destinationMapName = "D\u00adîc V\u00ad¬ng Cèc";
		reference68 = gStruct68;
		ref MapTravelConnection reference69 = ref array[68];
		MapTravelConnection gStruct69 = new MapTravelConnection
		{
			sourceMapId = 121,
			sourceMapName = "Long M«n trÊn"
		};
		uint[,] array_70 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_70, 192253);
		gStruct69.routeCoordinates = array_70;
		gStruct69.destinationMapId = 200;
		gStruct69.destinationMapName = "Cöu D\u00ad¬ng §éng";
		reference69 = gStruct69;
		ref MapTravelConnection reference70 = ref array[69];
		MapTravelConnection gStruct70 = new MapTravelConnection
		{
			sourceMapId = 200,
			sourceMapName = "Cöu D\u00ad¬ng §éng"
		};
		uint[,] array_71 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_71, 192286);
		gStruct70.routeCoordinates = array_71;
		gStruct70.destinationMapId = 121;
		gStruct70.destinationMapName = "Long M«n trÊn";
		reference70 = gStruct70;
		ref MapTravelConnection reference71 = ref array[70];
		MapTravelConnection gStruct71 = new MapTravelConnection
		{
			sourceMapId = 140,
			sourceMapName = "D\u00adîc V\u00ad¬ng Cèc"
		};
		uint[,] array_72 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_72, 192319);
		gStruct71.routeCoordinates = array_72;
		gStruct71.destinationMapId = 121;
		gStruct71.destinationMapName = "Long M«n trÊn";
		reference71 = gStruct71;
		ref MapTravelConnection reference72 = ref array[71];
		MapTravelConnection gStruct72 = new MapTravelConnection
		{
			sourceMapId = 153,
			sourceMapName = "Th¹ch Cæ trÊn"
		};
		uint[,] array_73 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_73, 192352);
		gStruct72.routeCoordinates = array_73;
		gStruct72.destinationMapId = 203;
		gStruct72.destinationMapName = "V« Danh ®éng";
		reference72 = gStruct72;
		ref MapTravelConnection reference73 = ref array[72];
		MapTravelConnection gStruct73 = new MapTravelConnection
		{
			sourceMapId = 203,
			sourceMapName = "V« Danh ®éng"
		};
		uint[,] array_74 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_74, 192385);
		gStruct73.routeCoordinates = array_74;
		gStruct73.destinationMapId = 153;
		gStruct73.destinationMapName = "Th¹ch Cæ trÊn";
		reference73 = gStruct73;
		ref MapTravelConnection reference74 = ref array[73];
		MapTravelConnection gStruct74 = new MapTravelConnection
		{
			sourceMapId = 174,
			sourceMapName = "Long TuyÒn th«n"
		};
		uint[,] array_75 = new uint[1, 5];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_75, 192418);
		gStruct74.routeCoordinates = array_75;
		gStruct74.destinationMapId = 198;
		gStruct74.destinationMapName = "Thanh khª ®éng";
		reference74 = gStruct74;
		ref MapTravelConnection reference75 = ref array[74];
		MapTravelConnection gStruct75 = new MapTravelConnection
		{
			sourceMapId = 198,
			sourceMapName = "Thanh khª ®éng"
		};
		uint[,] array_76 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_76, 192459);
		gStruct75.routeCoordinates = array_76;
		gStruct75.destinationMapId = 174;
		gStruct75.destinationMapName = "Long TuyÒn th«n";
		reference75 = gStruct75;
		ref MapTravelConnection reference76 = ref array[75];
		MapTravelConnection gStruct76 = new MapTravelConnection
		{
			sourceMapId = 174,
			sourceMapName = "Long TuyÒn th«n"
		};
		uint[,] array_77 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_77, 192492);
		gStruct76.routeCoordinates = array_77;
		gStruct76.destinationMapId = 179;
		gStruct76.destinationMapName = "La Tiªu s¬n";
		reference76 = gStruct76;
		ref MapTravelConnection reference77 = ref array[76];
		MapTravelConnection gStruct77 = new MapTravelConnection
		{
			sourceMapId = 179,
			sourceMapName = "La Tiªu s¬n"
		};
		uint[,] array_78 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_78, 192525);
		gStruct77.routeCoordinates = array_78;
		gStruct77.destinationMapId = 174;
		gStruct77.destinationMapName = "Long TuyÒn th«n";
		reference77 = gStruct77;
		ref MapTravelConnection reference78 = ref array[77];
		MapTravelConnection gStruct78 = new MapTravelConnection
		{
			sourceMapId = 179,
			sourceMapName = "La Tiªu s¬n"
		};
		uint[,] array_79 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_79, 192558);
		gStruct78.routeCoordinates = array_79;
		gStruct78.destinationMapId = 181;
		gStruct78.destinationMapName = "L\u00adìng Thñy ®éng";
		reference78 = gStruct78;
		ref MapTravelConnection reference79 = ref array[78];
		MapTravelConnection gStruct79 = new MapTravelConnection
		{
			sourceMapId = 181,
			sourceMapName = "L\u00adìng Thñy ®éng"
		};
		uint[,] array_80 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_80, 192591);
		gStruct79.routeCoordinates = array_80;
		gStruct79.destinationMapId = 179;
		gStruct79.destinationMapName = "La Tiªu s¬n";
		reference79 = gStruct79;
		ref MapTravelConnection reference80 = ref array[79];
		MapTravelConnection gStruct80 = new MapTravelConnection
		{
			sourceMapId = 179,
			sourceMapName = "La Tiªu s¬n"
		};
		uint[,] array_81 = new uint[2, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_81, 192624);
		gStruct80.routeCoordinates = array_81;
		gStruct80.destinationMapId = 182;
		gStruct80.destinationMapName = "NghiÖt Long ®én";
		reference80 = gStruct80;
		ref MapTravelConnection reference81 = ref array[80];
		MapTravelConnection gStruct81 = new MapTravelConnection
		{
			sourceMapId = 182,
			sourceMapName = "NghiÖt Long ®én"
		};
		uint[,] array_82 = new uint[2, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_82, 192669);
		gStruct81.routeCoordinates = array_82;
		gStruct81.destinationMapId = 179;
		gStruct81.destinationMapName = "La Tiªu s¬n";
		reference81 = gStruct81;
		ref MapTravelConnection reference82 = ref array[81];
		MapTravelConnection gStruct82 = new MapTravelConnection
		{
			sourceMapId = 175,
			sourceMapName = "T©y S¬n th«n"
		};
		uint[,] array_83 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_83, 192714);
		gStruct82.routeCoordinates = array_83;
		gStruct82.destinationMapId = 195;
		gStruct82.destinationMapName = "Nh¹n §·ng s¬n";
		reference82 = gStruct82;
		ref MapTravelConnection reference83 = ref array[82];
		MapTravelConnection gStruct83 = new MapTravelConnection
		{
			sourceMapId = 195,
			sourceMapName = "Nh¹n §·ng s¬n"
		};
		uint[,] array_84 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_84, 192747);
		gStruct83.routeCoordinates = array_84;
		gStruct83.destinationMapId = 175;
		gStruct83.destinationMapName = "T©y S¬n th«n";
		reference83 = gStruct83;
		ref MapTravelConnection reference84 = ref array[83];
		MapTravelConnection gStruct84 = new MapTravelConnection
		{
			sourceMapId = 136,
			sourceMapName = "Kho\u00b8i Ho¹t L©m"
		};
		uint[,] array_85 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_85, 192780);
		gStruct84.routeCoordinates = array_85;
		gStruct84.destinationMapId = 224;
		gStruct84.destinationMapName = "Sa m¹c ®Þa biÓu";
		reference84 = gStruct84;
		ref MapTravelConnection reference85 = ref array[84];
		MapTravelConnection gStruct85 = new MapTravelConnection
		{
			sourceMapId = 224,
			sourceMapName = "Sa m¹c ®Þa biÓu"
		};
		uint[,] array_86 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_86, 192813);
		gStruct85.routeCoordinates = array_86;
		gStruct85.destinationMapId = 136;
		gStruct85.destinationMapName = "Kho\u00b8i Ho¹t L©m";
		reference85 = gStruct85;
		ref MapTravelConnection reference86 = ref array[85];
		MapTravelConnection gStruct86 = new MapTravelConnection
		{
			sourceMapId = 224,
			sourceMapName = "Sa m¹c ®Þa biÓu"
		};
		uint[,] array_87 = new uint[6, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_87, 192846);
		gStruct86.routeCoordinates = array_87;
		gStruct86.destinationMapId = 225;
		gStruct86.destinationMapName = "Sa M¹c 1";
		reference86 = gStruct86;
		ref MapTravelConnection reference87 = ref array[86];
		MapTravelConnection gStruct87 = new MapTravelConnection
		{
			sourceMapId = 224,
			sourceMapName = "Sa m¹c ®Þa biÓu"
		};
		uint[,] array_88 = new uint[6, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_88, 192939);
		gStruct87.routeCoordinates = array_88;
		gStruct87.destinationMapId = 226;
		gStruct87.destinationMapName = "Sa M¹c 2";
		reference87 = gStruct87;
		ref MapTravelConnection reference88 = ref array[87];
		MapTravelConnection gStruct88 = new MapTravelConnection
		{
			sourceMapId = 224,
			sourceMapName = "Sa m¹c ®Þa biÓu"
		};
		uint[,] array_89 = new uint[6, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_89, 193032);
		gStruct88.routeCoordinates = array_89;
		gStruct88.destinationMapId = 227;
		gStruct88.destinationMapName = "Sa M¹c 3";
		reference88 = gStruct88;
		ref MapTravelConnection reference89 = ref array[88];
		MapTravelConnection gStruct89 = new MapTravelConnection
		{
			sourceMapId = 227,
			sourceMapName = "Sa M¹c 3"
		};
		uint[,] array_90 = new uint[2, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_90, 193125);
		gStruct89.routeCoordinates = array_90;
		gStruct89.destinationMapId = 224;
		gStruct89.destinationMapName = "Sa m¹c ®Þa biÓu";
		reference89 = gStruct89;
		ref MapTravelConnection reference90 = ref array[89];
		MapTravelConnection gStruct90 = new MapTravelConnection
		{
			sourceMapId = 227,
			sourceMapName = "Sa M¹c 3"
		};
		uint[,] array_91 = new uint[2, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_91, 193170);
		gStruct90.routeCoordinates = array_91;
		gStruct90.destinationMapId = 225;
		gStruct90.destinationMapName = "Sa M¹c 1";
		reference90 = gStruct90;
		ref MapTravelConnection reference91 = ref array[90];
		MapTravelConnection gStruct91 = new MapTravelConnection
		{
			sourceMapId = 227,
			sourceMapName = "Sa M¹c 3"
		};
		uint[,] array_92 = new uint[2, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_92, 193215);
		gStruct91.routeCoordinates = array_92;
		gStruct91.destinationMapId = 226;
		gStruct91.destinationMapName = "Sa M¹c 2";
		reference91 = gStruct91;
		ref MapTravelConnection reference92 = ref array[91];
		MapTravelConnection gStruct92 = new MapTravelConnection
		{
			sourceMapId = 226,
			sourceMapName = "Sa M¹c 2"
		};
		uint[,] array_93 = new uint[4, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_93, 193260);
		gStruct92.routeCoordinates = array_93;
		gStruct92.destinationMapId = 227;
		gStruct92.destinationMapName = "Sa M¹c 3";
		reference92 = gStruct92;
		ref MapTravelConnection reference93 = ref array[92];
		MapTravelConnection gStruct93 = new MapTravelConnection
		{
			sourceMapId = 226,
			sourceMapName = "Sa M¹c 2"
		};
		uint[,] array_94 = new uint[4, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_94, 193329);
		gStruct93.routeCoordinates = array_94;
		gStruct93.destinationMapId = 225;
		gStruct93.destinationMapName = "Sa M¹c 1";
		reference93 = gStruct93;
		ref MapTravelConnection reference94 = ref array[93];
		MapTravelConnection gStruct94 = new MapTravelConnection
		{
			sourceMapId = 226,
			sourceMapName = "Sa M¹c 2"
		};
		uint[,] array_95 = new uint[4, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_95, 193398);
		gStruct94.routeCoordinates = array_95;
		gStruct94.destinationMapId = 224;
		gStruct94.destinationMapName = "Sa m¹c ®Þa biÓu";
		reference94 = gStruct94;
		ref MapTravelConnection reference95 = ref array[94];
		MapTravelConnection gStruct95 = new MapTravelConnection
		{
			sourceMapId = 225,
			sourceMapName = "Sa M¹c 1"
		};
		uint[,] array_96 = new uint[2, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_96, 193467);
		gStruct95.routeCoordinates = array_96;
		gStruct95.destinationMapId = 224;
		gStruct95.destinationMapName = "Sa m¹c ®Þa biÓu";
		reference95 = gStruct95;
		ref MapTravelConnection reference96 = ref array[95];
		MapTravelConnection gStruct96 = new MapTravelConnection
		{
			sourceMapId = 225,
			sourceMapName = "Sa M¹c 1"
		};
		uint[,] array_97 = new uint[2, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_97, 193512);
		gStruct96.routeCoordinates = array_97;
		gStruct96.destinationMapId = 226;
		gStruct96.destinationMapName = "Sa M¹c 2";
		reference96 = gStruct96;
		ref MapTravelConnection reference97 = ref array[96];
		MapTravelConnection gStruct97 = new MapTravelConnection
		{
			sourceMapId = 225,
			sourceMapName = "Sa M¹c 1"
		};
		uint[,] array_98 = new uint[2, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_98, 193557);
		gStruct97.routeCoordinates = array_98;
		gStruct97.destinationMapId = 227;
		gStruct97.destinationMapName = "Sa M¹c 3";
		reference97 = gStruct97;
		ref MapTravelConnection reference98 = ref array[97];
		MapTravelConnection gStruct98 = new MapTravelConnection
		{
			sourceMapId = 321,
			sourceMapName = "Tr\u00adêng B¹ch s¬n N"
		};
		uint[,] array_99 = new uint[2, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_99, 193602);
		gStruct98.routeCoordinates = array_99;
		gStruct98.destinationMapId = 320;
		gStruct98.destinationMapName = "Ch©n nói Tr\u00adêng";
		reference98 = gStruct98;
		ref MapTravelConnection reference99 = ref array[98];
		MapTravelConnection gStruct99 = new MapTravelConnection
		{
			sourceMapId = 320,
			sourceMapName = "Ch©n nói Tr\u00adêng"
		};
		uint[,] array_100 = new uint[2, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_100, 193647);
		gStruct99.routeCoordinates = array_100;
		gStruct99.destinationMapId = 321;
		gStruct99.destinationMapName = "Tr\u00adêng B¹ch s¬n N";
		reference99 = gStruct99;
		ref MapTravelConnection reference100 = ref array[99];
		MapTravelConnection gStruct100 = new MapTravelConnection
		{
			sourceMapId = 320,
			sourceMapName = "Ch©n nói Tr\u00adêng"
		};
		uint[,] array_101 = new uint[2, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_101, 193692);
		gStruct100.routeCoordinates = array_101;
		gStruct100.destinationMapId = 322;
		gStruct100.destinationMapName = "Tr\u00adêng B¹ch s¬n B";
		reference100 = gStruct100;
		ref MapTravelConnection reference101 = ref array[100];
		MapTravelConnection gStruct101 = new MapTravelConnection
		{
			sourceMapId = 322,
			sourceMapName = "Tr\u00adêng B¹ch s¬n B"
		};
		uint[,] array_102 = new uint[2, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_102, 193737);
		gStruct101.routeCoordinates = array_102;
		gStruct101.destinationMapId = 320;
		gStruct101.destinationMapName = "Ch©n nói Tr\u00adêng";
		reference101 = gStruct101;
		ref MapTravelConnection reference102 = ref array[101];
		MapTravelConnection gStruct102 = new MapTravelConnection
		{
			sourceMapId = 320,
			sourceMapName = "Ch©n nói Tr\u00adêng"
		};
		uint[,] array_103 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_103, 193782);
		gStruct102.routeCoordinates = array_103;
		gStruct102.destinationMapId = 319;
		gStruct102.destinationMapName = "L©m Du Quan";
		reference102 = gStruct102;
		ref MapTravelConnection reference103 = ref array[102];
		MapTravelConnection gStruct103 = new MapTravelConnection
		{
			sourceMapId = 319,
			sourceMapName = "L©m Du Quan"
		};
		uint[,] array_104 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_104, 193815);
		gStruct103.routeCoordinates = array_104;
		gStruct103.destinationMapId = 320;
		gStruct103.destinationMapName = "Ch©n nói Tr\u00adêng";
		reference103 = gStruct103;
		ref MapTravelConnection reference104 = ref array[103];
		MapTravelConnection gStruct104 = new MapTravelConnection
		{
			sourceMapId = 319,
			sourceMapName = "L©m Du Quan"
		};
		uint[,] array_105 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_105, 193848);
		gStruct104.routeCoordinates = array_105;
		gStruct104.destinationMapId = 37;
		gStruct104.destinationMapName = "BiÖn Kinh";
		reference104 = gStruct104;
		ref MapTravelConnection reference105 = ref array[104];
		MapTravelConnection gStruct105 = new MapTravelConnection
		{
			sourceMapId = 37,
			sourceMapName = "BiÖn Kinh"
		};
		uint[,] array_106 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_106, 193881);
		gStruct105.routeCoordinates = array_106;
		gStruct105.destinationMapId = 319;
		gStruct105.destinationMapName = "L©m Du Quan";
		reference105 = gStruct105;
		ref MapTravelConnection reference106 = ref array[105];
		MapTravelConnection gStruct106 = new MapTravelConnection
		{
			sourceMapId = 103,
			sourceMapName = "ThiÕu L©m ph\u00b8i"
		};
		uint[,] array_107 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_107, 193914);
		gStruct106.routeCoordinates = array_107;
		gStruct106.destinationMapId = 37;
		gStruct106.destinationMapName = "BiÖn Kinh";
		reference106 = gStruct106;
		ref MapTravelConnection reference107 = ref array[106];
		MapTravelConnection gStruct107 = new MapTravelConnection
		{
			sourceMapId = 37,
			sourceMapName = "BiÖn Kinh"
		};
		uint[,] array_108 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_108, 193947);
		gStruct107.routeCoordinates = array_108;
		gStruct107.destinationMapId = 103;
		gStruct107.destinationMapName = "ThiÕu L©m ph\u00b8i";
		reference107 = gStruct107;
		ref MapTravelConnection reference108 = ref array[107];
		MapTravelConnection gStruct108 = new MapTravelConnection
		{
			sourceMapId = 11,
			sourceMapName = "Thµnh §«"
		};
		uint[,] array_109 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_109, 193980);
		gStruct108.routeCoordinates = array_109;
		gStruct108.destinationMapId = 9;
		gStruct108.destinationMapName = "Tr\u00adêng Giang Ng";
		reference108 = gStruct108;
		ref MapTravelConnection reference109 = ref array[108];
		MapTravelConnection gStruct109 = new MapTravelConnection
		{
			sourceMapId = 9,
			sourceMapName = "Tr\u00adêng Giang Ng"
		};
		uint[,] array_110 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_110, 194013);
		gStruct109.routeCoordinates = array_110;
		gStruct109.destinationMapId = 11;
		gStruct109.destinationMapName = "Thµnh §«";
		reference109 = gStruct109;
		ref MapTravelConnection reference110 = ref array[109];
		MapTravelConnection gStruct110 = new MapTravelConnection
		{
			sourceMapId = 9,
			sourceMapName = "Tr\u00adêng Giang Ng"
		};
		uint[,] array_111 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_111, 194046);
		gStruct110.routeCoordinates = array_111;
		gStruct110.destinationMapId = 10;
		gStruct110.destinationMapName = "Nh¹n Th¹ch ®éng";
		reference110 = gStruct110;
		ref MapTravelConnection reference111 = ref array[110];
		MapTravelConnection gStruct111 = new MapTravelConnection
		{
			sourceMapId = 10,
			sourceMapName = "Nh¹n Th¹ch ®éng"
		};
		uint[,] array_112 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_112, 194079);
		gStruct111.routeCoordinates = array_112;
		gStruct111.destinationMapId = 9;
		gStruct111.destinationMapName = "Tr\u00adêng Giang Ng";
		reference111 = gStruct111;
		ref MapTravelConnection reference112 = ref array[111];
		MapTravelConnection gStruct112 = new MapTravelConnection
		{
			sourceMapId = 37,
			sourceMapName = "BiÖn Kinh"
		};
		uint[,] array_113 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_113, 194112);
		gStruct112.routeCoordinates = array_113;
		gStruct112.destinationMapId = 45;
		gStruct112.destinationMapName = "Thiªn NhÉn gi\u00b8o";
		reference112 = gStruct112;
		ref MapTravelConnection reference113 = ref array[112];
		MapTravelConnection gStruct113 = new MapTravelConnection
		{
			sourceMapId = 45,
			sourceMapName = "Thiªn NhÉn gi\u00b8o"
		};
		uint[,] array_114 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_114, 194145);
		gStruct113.routeCoordinates = array_114;
		gStruct113.destinationMapId = 37;
		gStruct113.destinationMapName = "BiÖn Kinh";
		reference113 = gStruct113;
		ref MapTravelConnection reference114 = ref array[113];
		MapTravelConnection gStruct114 = new MapTravelConnection
		{
			sourceMapId = 11,
			sourceMapName = "Thµnh §«"
		};
		uint[,] array_115 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_115, 194178);
		gStruct114.routeCoordinates = array_115;
		gStruct114.destinationMapId = 13;
		gStruct114.destinationMapName = "Nga My ph\u00b8i";
		reference114 = gStruct114;
		ref MapTravelConnection reference115 = ref array[114];
		MapTravelConnection gStruct115 = new MapTravelConnection
		{
			sourceMapId = 13,
			sourceMapName = "Nga My ph\u00b8i"
		};
		uint[,] array_116 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_116, 194211);
		gStruct115.routeCoordinates = array_116;
		gStruct115.destinationMapId = 11;
		gStruct115.destinationMapName = "Thµnh §«";
		reference115 = gStruct115;
		ref MapTravelConnection reference116 = ref array[115];
		MapTravelConnection gStruct116 = new MapTravelConnection
		{
			sourceMapId = 11,
			sourceMapName = "Thµnh §«"
		};
		uint[,] array_117 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_117, 194244);
		gStruct116.routeCoordinates = array_117;
		gStruct116.destinationMapId = 25;
		gStruct116.destinationMapName = "§\u00adêng M«n";
		reference116 = gStruct116;
		ref MapTravelConnection reference117 = ref array[116];
		MapTravelConnection gStruct117 = new MapTravelConnection
		{
			sourceMapId = 25,
			sourceMapName = "§\u00adêng M«n"
		};
		uint[,] array_118 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_118, 194277);
		gStruct117.routeCoordinates = array_118;
		gStruct117.destinationMapId = 11;
		gStruct117.destinationMapName = "Thµnh §«";
		reference117 = gStruct117;
		ref MapTravelConnection reference118 = ref array[117];
		MapTravelConnection gStruct118 = new MapTravelConnection
		{
			sourceMapId = 78,
			sourceMapName = "T\u00ad¬ng D\u00ad¬ng"
		};
		uint[,] array_119 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_119, 194310);
		gStruct118.routeCoordinates = array_119;
		gStruct118.destinationMapId = 81;
		gStruct118.destinationMapName = "Vâ §ang ph\u00b8i";
		reference118 = gStruct118;
		ref MapTravelConnection reference119 = ref array[118];
		MapTravelConnection gStruct119 = new MapTravelConnection
		{
			sourceMapId = 81,
			sourceMapName = "Vâ §ang ph\u00b8i"
		};
		uint[,] array_120 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_120, 194343);
		gStruct119.routeCoordinates = array_120;
		gStruct119.destinationMapId = 78;
		gStruct119.destinationMapName = "T\u00ad¬ng D\u00ad¬ng";
		reference119 = gStruct119;
		ref MapTravelConnection reference120 = ref array[119];
		MapTravelConnection gStruct120 = new MapTravelConnection
		{
			sourceMapId = 162,
			sourceMapName = "§¹i Lý phñ"
		};
		uint[,] array_121 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_121, 194376);
		gStruct120.routeCoordinates = array_121;
		gStruct120.destinationMapId = 154;
		gStruct120.destinationMapName = "Thóy Yªn m«n";
		reference120 = gStruct120;
		ref MapTravelConnection reference121 = ref array[120];
		MapTravelConnection gStruct121 = new MapTravelConnection
		{
			sourceMapId = 154,
			sourceMapName = "Thóy Yªn m«n"
		};
		uint[,] array_122 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_122, 194409);
		gStruct121.routeCoordinates = array_122;
		gStruct121.destinationMapId = 162;
		gStruct121.destinationMapName = "§¹i Lý phñ";
		reference121 = gStruct121;
		ref MapTravelConnection reference122 = ref array[121];
		MapTravelConnection gStruct122 = new MapTravelConnection
		{
			sourceMapId = 80,
			sourceMapName = "D\u00ad¬ng Ch©u"
		};
		uint[,] array_123 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_123, 194442);
		gStruct122.routeCoordinates = array_123;
		gStruct122.destinationMapId = 115;
		gStruct122.destinationMapName = "C\u00b8i Bang";
		reference122 = gStruct122;
		ref MapTravelConnection reference123 = ref array[122];
		MapTravelConnection gStruct123 = new MapTravelConnection
		{
			sourceMapId = 115,
			sourceMapName = "C\u00b8i Bang"
		};
		uint[,] array_124 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_124, 194475);
		gStruct123.routeCoordinates = array_124;
		gStruct123.destinationMapId = 80;
		gStruct123.destinationMapName = "D\u00ad¬ng Ch©u";
		reference123 = gStruct123;
		ref MapTravelConnection reference124 = ref array[123];
		MapTravelConnection gStruct124 = new MapTravelConnection
		{
			sourceMapId = 80,
			sourceMapName = "D\u00ad¬ng Ch©u"
		};
		uint[,] array_125 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_125, 194508);
		gStruct124.routeCoordinates = array_125;
		gStruct124.destinationMapId = 92;
		gStruct124.destinationMapName = "Thôc C\u00ad¬ng s¬n";
		reference124 = gStruct124;
		ref MapTravelConnection reference125 = ref array[124];
		MapTravelConnection gStruct125 = new MapTravelConnection
		{
			sourceMapId = 92,
			sourceMapName = "Thôc C\u00ad¬ng s¬n"
		};
		uint[,] array_126 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_126, 194541);
		gStruct125.routeCoordinates = array_126;
		gStruct125.destinationMapId = 80;
		gStruct125.destinationMapName = "D\u00ad¬ng Ch©u";
		reference125 = gStruct125;
		ref MapTravelConnection reference126 = ref array[125];
		MapTravelConnection gStruct126 = new MapTravelConnection
		{
			sourceMapId = 174,
			sourceMapName = "Long TuyÒn th«n"
		};
		uint[,] array_127 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_127, 194574);
		gStruct126.routeCoordinates = array_127;
		gStruct126.destinationMapId = 183;
		gStruct126.destinationMapName = "Ngò §éc Gi\u00b8o";
		reference126 = gStruct126;
		ref MapTravelConnection reference127 = ref array[126];
		MapTravelConnection gStruct127 = new MapTravelConnection
		{
			sourceMapId = 183,
			sourceMapName = "Ngò §éc Gi\u00b8o"
		};
		uint[,] array_128 = new uint[1, 3];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_128, 194607);
		gStruct127.routeCoordinates = array_128;
		gStruct127.destinationMapId = 174;
		gStruct127.destinationMapName = "Long TuyÒn th«n";
		reference127 = gStruct127;
		travelConnections = array;
		TravelMapEntry[] array2 = new TravelMapEntry[29];
		ref TravelMapEntry reference128 = ref array2[0];
		TravelMapEntry gStruct128 = new TravelMapEntry
		{
			mapName = "BiÖn Kinh",
			mapId = 37
		};
		MapTravelPoint[] array3 = new MapTravelPoint[17];
		ref MapTravelPoint reference129 = ref array3[0];
		MapTravelPoint gStruct129 = new MapTravelPoint
		{
			pointName = "NgoaiThanh"
		};
		uint[,] array_129 = new uint[4, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_129, 194652);
		gStruct129.coordinateOptions = array_129;
		reference129 = gStruct129;
		ref MapTravelPoint reference130 = ref array3[1];
		reference130 = new MapTravelPoint
		{
			pointName = "Sø gi¶ m«n ph\u00b8i",
			coordinateOptions = new uint[1, 2] { { 55808u, 98304u } }
		};
		ref MapTravelPoint reference131 = ref array3[2];
		reference131 = new MapTravelPoint
		{
			pointName = "Xa phu c«ng thµnh",
			coordinateOptions = new uint[1, 2] { { 54144u, 102784u } }
		};
		ref MapTravelPoint reference132 = ref array3[3];
		MapTravelPoint gStruct130 = new MapTravelPoint
		{
			pointName = "Xa phu"
		};
		uint[,] array_130 = new uint[4, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_130, 194769);
		gStruct130.coordinateOptions = array_130;
		reference132 = gStruct130;
		ref MapTravelPoint reference133 = ref array3[4];
		MapTravelPoint gStruct131 = new MapTravelPoint
		{
			pointName = "R\u00ad¬ng chøa ®å"
		};
		uint[,] array_131 = new uint[4, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_131, 194814);
		gStruct131.coordinateOptions = array_131;
		reference133 = gStruct131;
		ref MapTravelPoint reference134 = ref array3[5];
		reference134 = new MapTravelPoint
		{
			pointName = "Chñ TiÒn trang",
			coordinateOptions = new uint[1, 2] { { 53267u, 102674u } }
		};
		ref MapTravelPoint reference135 = ref array3[6];
		reference135 = new MapTravelPoint
		{
			pointName = "V\u00ad¬ng ThiÕt T\u00adîng",
			coordinateOptions = new uint[1, 2] { { 54877u, 99328u } }
		};
		ref MapTravelPoint reference136 = ref array3[7];
		reference136 = new MapTravelPoint
		{
			pointName = "Khóc ThiÕt T\u00adîng",
			coordinateOptions = new uint[1, 2] { { 55903u, 97604u } }
		};
		ref MapTravelPoint reference137 = ref array3[8];
		reference137 = new MapTravelPoint
		{
			pointName = "Thî rÌn",
			coordinateOptions = new uint[1, 2] { { 55903u, 97604u } }
		};
		ref MapTravelPoint reference138 = ref array3[9];
		reference138 = new MapTravelPoint
		{
			pointName = "D· TÈu",
			coordinateOptions = new uint[1, 2] { { 55537u, 99223u } }
		};
		ref MapTravelPoint reference139 = ref array3[10];
		reference139 = new MapTravelPoint
		{
			pointName = "Chñ tiÖm t¹p hãa",
			coordinateOptions = new uint[1, 2] { { 57176u, 99283u } }
		};
		ref MapTravelPoint reference140 = ref array3[11];
		reference140 = new MapTravelPoint
		{
			pointName = "¤ng chñ d\u00adîc ®iÕm",
			coordinateOptions = new uint[1, 2] { { 56809u, 98897u } }
		};
		ref MapTravelPoint reference141 = ref array3[12];
		reference141 = new MapTravelPoint
		{
			pointName = "HIEUTHUOC",
			coordinateOptions = new uint[1, 2] { { 56809u, 98897u } }
		};
		ref MapTravelPoint reference142 = ref array3[13];
		reference142 = new MapTravelPoint
		{
			pointName = "B\u00b8n ngùa",
			coordinateOptions = new uint[1, 2] { { 54815u, 96940u } }
		};
		ref MapTravelPoint reference143 = ref array3[14];
		reference143 = new MapTravelPoint
		{
			pointName = "NhiÕp ThÝ TrÇn",
			coordinateOptions = new uint[1, 2] { { 52704u, 97600u } }
		};
		ref MapTravelPoint reference144 = ref array3[15];
		reference144 = new MapTravelPoint
		{
			pointName = "DÞch quan",
			coordinateOptions = new uint[1, 2] { { 51279u, 96030u } }
		};
		ref MapTravelPoint reference145 = ref array3[16];
		reference145 = new MapTravelPoint
		{
			pointName = "VÖ binh thµnh m«n",
			coordinateOptions = new uint[1, 2] { { 51279u, 96030u } }
		};
		gStruct128.gstruct24_0 = array3;
		reference128 = gStruct128;
		ref TravelMapEntry reference146 = ref array2[1];
		TravelMapEntry gStruct132 = new TravelMapEntry
		{
			mapName = "Ph\u00adîng T\u00adêng",
			mapId = 1
		};
		array3 = new MapTravelPoint[15];
		ref MapTravelPoint reference147 = ref array3[0];
		MapTravelPoint gStruct133 = new MapTravelPoint
		{
			pointName = "NgoaiThanh"
		};
		uint[,] array_132 = new uint[4, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_132, 195303);
		gStruct133.coordinateOptions = array_132;
		reference147 = gStruct133;
		ref MapTravelPoint reference148 = ref array3[1];
		reference148 = new MapTravelPoint
		{
			pointName = "Sø gi¶ m«n ph\u00b8i",
			coordinateOptions = new uint[1, 2] { { 51424u, 102240u } }
		};
		ref MapTravelPoint reference149 = ref array3[2];
		reference149 = new MapTravelPoint
		{
			pointName = "Xa phu c«ng thµnh",
			coordinateOptions = new uint[1, 2] { { 52544u, 104640u } }
		};
		ref MapTravelPoint reference150 = ref array3[3];
		MapTravelPoint gStruct134 = new MapTravelPoint
		{
			pointName = "Xa phu"
		};
		uint[,] array_133 = new uint[4, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_133, 195420);
		gStruct134.coordinateOptions = array_133;
		reference150 = gStruct134;
		ref MapTravelPoint reference151 = ref array3[4];
		MapTravelPoint gStruct135 = new MapTravelPoint
		{
			pointName = "R\u00ad¬ng chøa ®å"
		};
		uint[,] array_134 = new uint[5, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_134, 195465);
		gStruct135.coordinateOptions = array_134;
		reference151 = gStruct135;
		ref MapTravelPoint reference152 = ref array3[5];
		reference152 = new MapTravelPoint
		{
			pointName = "Chñ TiÒn trang",
			coordinateOptions = new uint[1, 2] { { 49667u, 103796u } }
		};
		ref MapTravelPoint reference153 = ref array3[6];
		reference153 = new MapTravelPoint
		{
			pointName = "Thî rÌn",
			coordinateOptions = new uint[1, 2] { { 51766u, 102214u } }
		};
		ref MapTravelPoint reference154 = ref array3[7];
		reference154 = new MapTravelPoint
		{
			pointName = "D· TÈu",
			coordinateOptions = new uint[1, 2] { { 51741u, 98828u } }
		};
		ref MapTravelPoint reference155 = ref array3[8];
		reference155 = new MapTravelPoint
		{
			pointName = "LÔ Quan",
			coordinateOptions = new uint[1, 2] { { 51704u, 100900u } }
		};
		ref MapTravelPoint reference156 = ref array3[9];
		reference156 = new MapTravelPoint
		{
			pointName = "Vâ L©m truyÒn nh©n",
			coordinateOptions = new uint[1, 2] { { 52012u, 102561u } }
		};
		ref MapTravelPoint reference157 = ref array3[10];
		reference157 = new MapTravelPoint
		{
			pointName = "Chñ tiÖm t¹p hãa",
			coordinateOptions = new uint[1, 2] { { 49901u, 102638u } }
		};
		ref MapTravelPoint reference158 = ref array3[11];
		reference158 = new MapTravelPoint
		{
			pointName = "¤ng chñ d\u00adîc ®iÕm",
			coordinateOptions = new uint[1, 2] { { 51287u, 102080u } }
		};
		ref MapTravelPoint reference159 = ref array3[12];
		reference159 = new MapTravelPoint
		{
			pointName = "HIEUTHUOC",
			coordinateOptions = new uint[1, 2] { { 51287u, 102080u } }
		};
		ref MapTravelPoint reference160 = ref array3[13];
		reference160 = new MapTravelPoint
		{
			pointName = "B\u00b8n ngùa",
			coordinateOptions = new uint[1, 2] { { 52421u, 102157u } }
		};
		ref MapTravelPoint reference161 = ref array3[14];
		reference161 = new MapTravelPoint
		{
			pointName = "NhiÕp ThÝ TrÇn",
			coordinateOptions = new uint[1, 2] { { 48257u, 102220u } }
		};
		gStruct132.gstruct24_0 = array3;
		reference146 = gStruct132;
		ref TravelMapEntry reference162 = ref array2[2];
		TravelMapEntry gStruct136 = new TravelMapEntry
		{
			mapName = "Thµnh §«",
			mapId = 11
		};
		array3 = new MapTravelPoint[16];
		ref MapTravelPoint reference163 = ref array3[0];
		MapTravelPoint gStruct137 = new MapTravelPoint
		{
			pointName = "NgoaiThanh"
		};
		uint[,] array_135 = new uint[4, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_135, 195890);
		gStruct137.coordinateOptions = array_135;
		reference163 = gStruct137;
		ref MapTravelPoint reference164 = ref array3[1];
		reference164 = new MapTravelPoint
		{
			pointName = "Sø gi¶ m«n ph\u00b8i",
			coordinateOptions = new uint[1, 2] { { 100800u, 162336u } }
		};
		ref MapTravelPoint reference165 = ref array3[2];
		reference165 = new MapTravelPoint
		{
			pointName = "Xa phu c«ng thµnh",
			coordinateOptions = new uint[1, 2] { { 101952u, 165824u } }
		};
		ref MapTravelPoint reference166 = ref array3[3];
		MapTravelPoint gStruct138 = new MapTravelPoint
		{
			pointName = "Xa phu"
		};
		uint[,] array_136 = new uint[4, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_136, 196007);
		gStruct138.coordinateOptions = array_136;
		reference166 = gStruct138;
		ref MapTravelPoint reference167 = ref array3[4];
		MapTravelPoint gStruct139 = new MapTravelPoint
		{
			pointName = "R\u00ad¬ng chøa ®å"
		};
		uint[,] array_137 = new uint[5, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_137, 196052);
		gStruct139.coordinateOptions = array_137;
		reference167 = gStruct139;
		ref MapTravelPoint reference168 = ref array3[5];
		reference168 = new MapTravelPoint
		{
			pointName = "Thî rÌn",
			coordinateOptions = new uint[1, 2] { { 99314u, 163834u } }
		};
		ref MapTravelPoint reference169 = ref array3[6];
		reference169 = new MapTravelPoint
		{
			pointName = "D· TÈu",
			coordinateOptions = new uint[1, 2] { { 100891u, 162236u } }
		};
		ref MapTravelPoint reference170 = ref array3[7];
		reference170 = new MapTravelPoint
		{
			pointName = "LÔ Quan",
			coordinateOptions = new uint[1, 2] { { 100083u, 159858u } }
		};
		ref MapTravelPoint reference171 = ref array3[8];
		reference171 = new MapTravelPoint
		{
			pointName = "Vâ L©m truyÒn nh©n",
			coordinateOptions = new uint[1, 2] { { 100285u, 161562u } }
		};
		ref MapTravelPoint reference172 = ref array3[9];
		reference172 = new MapTravelPoint
		{
			pointName = "Chñ tiÖm t¹p hãa",
			coordinateOptions = new uint[1, 2] { { 99001u, 164350u } }
		};
		ref MapTravelPoint reference173 = ref array3[10];
		reference173 = new MapTravelPoint
		{
			pointName = "¤ng chñ d\u00adîc ®iÕm",
			coordinateOptions = new uint[1, 2] { { 100552u, 164296u } }
		};
		ref MapTravelPoint reference174 = ref array3[11];
		reference174 = new MapTravelPoint
		{
			pointName = "HIEUTHUOC",
			coordinateOptions = new uint[1, 2] { { 100552u, 164296u } }
		};
		ref MapTravelPoint reference175 = ref array3[12];
		reference175 = new MapTravelPoint
		{
			pointName = "B\u00b8n ngùa",
			coordinateOptions = new uint[1, 2] { { 101157u, 163040u } }
		};
		ref MapTravelPoint reference176 = ref array3[13];
		reference176 = new MapTravelPoint
		{
			pointName = "NhiÕp ThÝ TrÇn",
			coordinateOptions = new uint[1, 2] { { 102675u, 159250u } }
		};
		ref MapTravelPoint reference177 = ref array3[14];
		reference177 = new MapTravelPoint
		{
			pointName = "DÞch quan",
			coordinateOptions = new uint[1, 2] { { 96611u, 162858u } }
		};
		ref MapTravelPoint reference178 = ref array3[15];
		MapTravelPoint gStruct140 = new MapTravelPoint
		{
			pointName = "VÖ binh thµnh m«n"
		};
		uint[,] array_138 = new uint[4, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_138, 196465);
		gStruct140.coordinateOptions = array_138;
		reference178 = gStruct140;
		gStruct136.gstruct24_0 = array3;
		reference162 = gStruct136;
		ref TravelMapEntry reference179 = ref array2[3];
		TravelMapEntry gStruct141 = new TravelMapEntry
		{
			mapName = "§¹i Lý",
			mapId = 162
		};
		array3 = new MapTravelPoint[14];
		ref MapTravelPoint reference180 = ref array3[0];
		MapTravelPoint gStruct142 = new MapTravelPoint
		{
			pointName = "NgoaiThanh"
		};
		uint[,] array_139 = new uint[3, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_139, 196522);
		gStruct142.coordinateOptions = array_139;
		reference180 = gStruct142;
		ref MapTravelPoint reference181 = ref array3[1];
		reference181 = new MapTravelPoint
		{
			pointName = "Sø gi¶ m«n ph\u00b8i",
			coordinateOptions = new uint[1, 2] { { 51968u, 102464u } }
		};
		ref MapTravelPoint reference182 = ref array3[2];
		reference182 = new MapTravelPoint
		{
			pointName = "Xa phu c«ng thµnh",
			coordinateOptions = new uint[1, 2] { { 53760u, 104832u } }
		};
		ref MapTravelPoint reference183 = ref array3[3];
		MapTravelPoint gStruct143 = new MapTravelPoint
		{
			pointName = "Xa phu"
		};
		uint[,] array_140 = new uint[3, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_140, 196631);
		gStruct143.coordinateOptions = array_140;
		reference183 = gStruct143;
		ref MapTravelPoint reference184 = ref array3[4];
		MapTravelPoint gStruct144 = new MapTravelPoint
		{
			pointName = "R\u00ad¬ng chøa ®å"
		};
		uint[,] array_141 = new uint[2, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_141, 196668);
		gStruct144.coordinateOptions = array_141;
		reference184 = gStruct144;
		ref MapTravelPoint reference185 = ref array3[5];
		reference185 = new MapTravelPoint
		{
			pointName = "Thî rÌn",
			coordinateOptions = new uint[1, 2] { { 49851u, 104390u } }
		};
		ref MapTravelPoint reference186 = ref array3[6];
		reference186 = new MapTravelPoint
		{
			pointName = "D· TÈu",
			coordinateOptions = new uint[1, 2] { { 52746u, 103322u } }
		};
		ref MapTravelPoint reference187 = ref array3[7];
		reference187 = new MapTravelPoint
		{
			pointName = "LÔ Quan",
			coordinateOptions = new uint[1, 2] { { 50807u, 103128u } }
		};
		ref MapTravelPoint reference188 = ref array3[8];
		reference188 = new MapTravelPoint
		{
			pointName = "Vâ L©m truyÒn nh©n",
			coordinateOptions = new uint[1, 2] { { 52086u, 101930u } }
		};
		ref MapTravelPoint reference189 = ref array3[9];
		reference189 = new MapTravelPoint
		{
			pointName = "Chñ tiÖm t¹p hãa",
			coordinateOptions = new uint[1, 2] { { 49138u, 102411u } }
		};
		ref MapTravelPoint reference190 = ref array3[10];
		reference190 = new MapTravelPoint
		{
			pointName = "¤ng chñ d\u00adîc ®iÕm",
			coordinateOptions = new uint[1, 2] { { 47983u, 102684u } }
		};
		ref MapTravelPoint reference191 = ref array3[11];
		reference191 = new MapTravelPoint
		{
			pointName = "HIEUTHUOC",
			coordinateOptions = new uint[1, 2] { { 47983u, 102684u } }
		};
		ref MapTravelPoint reference192 = ref array3[12];
		reference192 = new MapTravelPoint
		{
			pointName = "B\u00b8n ngùa",
			coordinateOptions = new uint[1, 2] { { 52499u, 100822u } }
		};
		ref MapTravelPoint reference193 = ref array3[13];
		reference193 = new MapTravelPoint
		{
			pointName = "NhiÕp ThÝ TrÇn",
			coordinateOptions = new uint[1, 2] { { 50399u, 103114u } }
		};
		gStruct141.gstruct24_0 = array3;
		reference179 = gStruct141;
		ref TravelMapEntry reference194 = ref array2[4];
		TravelMapEntry gStruct145 = new TravelMapEntry
		{
			mapName = "L©m An",
			mapId = 176
		};
		array3 = new MapTravelPoint[23];
		ref MapTravelPoint reference195 = ref array3[0];
		MapTravelPoint gStruct146 = new MapTravelPoint
		{
			pointName = "NgoaiThanh"
		};
		uint[,] array_142 = new uint[4, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_142, 197033);
		gStruct146.coordinateOptions = array_142;
		reference195 = gStruct146;
		ref MapTravelPoint reference196 = ref array3[1];
		reference196 = new MapTravelPoint
		{
			pointName = "Sø gi¶ m«n ph\u00b8i",
			coordinateOptions = new uint[1, 2] { { 46016u, 104928u } }
		};
		ref MapTravelPoint reference197 = ref array3[2];
		reference197 = new MapTravelPoint
		{
			pointName = "Xa phu c«ng thµnh",
			coordinateOptions = new uint[1, 2] { { 54048u, 105248u } }
		};
		ref MapTravelPoint reference198 = ref array3[3];
		MapTravelPoint gStruct147 = new MapTravelPoint
		{
			pointName = "Xa phu"
		};
		uint[,] array_143 = new uint[4, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_143, 197150);
		gStruct147.coordinateOptions = array_143;
		reference198 = gStruct147;
		ref MapTravelPoint reference199 = ref array3[4];
		MapTravelPoint gStruct148 = new MapTravelPoint
		{
			pointName = "R\u00ad¬ng chøa ®å"
		};
		uint[,] array_144 = new uint[3, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_144, 197195);
		gStruct148.coordinateOptions = array_144;
		reference199 = gStruct148;
		ref MapTravelPoint reference200 = ref array3[5];
		reference200 = new MapTravelPoint
		{
			pointName = "Chñ TiÒn trang",
			coordinateOptions = new uint[1, 2] { { 46210u, 98030u } }
		};
		ref MapTravelPoint reference201 = ref array3[6];
		MapTravelPoint gStruct149 = new MapTravelPoint
		{
			pointName = "Thî rÌn"
		};
		uint[,] array_145 = new uint[3, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_145, 197268);
		gStruct149.coordinateOptions = array_145;
		reference201 = gStruct149;
		ref MapTravelPoint reference202 = ref array3[7];
		reference202 = new MapTravelPoint
		{
			pointName = "D· TÈu",
			coordinateOptions = new uint[1, 2] { { 49927u, 95318u } }
		};
		ref MapTravelPoint reference203 = ref array3[8];
		reference203 = new MapTravelPoint
		{
			pointName = "LÔ Quan",
			coordinateOptions = new uint[1, 2] { { 48145u, 95494u } }
		};
		ref MapTravelPoint reference204 = ref array3[9];
		reference204 = new MapTravelPoint
		{
			pointName = "Vâ L©m truyÒn nh©n",
			coordinateOptions = new uint[1, 2] { { 49050u, 96262u } }
		};
		ref MapTravelPoint reference205 = ref array3[10];
		reference205 = new MapTravelPoint
		{
			pointName = "Chñ tiÖm t¹p hãa",
			coordinateOptions = new uint[1, 2] { { 42929u, 101358u } }
		};
		ref MapTravelPoint reference206 = ref array3[11];
		MapTravelPoint gStruct150 = new MapTravelPoint
		{
			pointName = "¤ng chñ d\u00adîc ®iÕm"
		};
		uint[,] array_146 = new uint[4, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_146, 197449);
		gStruct150.coordinateOptions = array_146;
		reference206 = gStruct150;
		ref MapTravelPoint reference207 = ref array3[12];
		MapTravelPoint gStruct151 = new MapTravelPoint
		{
			pointName = "HIEUTHUOC"
		};
		uint[,] array_147 = new uint[4, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_147, 197494);
		gStruct151.coordinateOptions = array_147;
		reference207 = gStruct151;
		ref MapTravelPoint reference208 = ref array3[13];
		reference208 = new MapTravelPoint
		{
			pointName = "B\u00b8n ngùa",
			coordinateOptions = new uint[1, 2] { { 47850u, 96544u } }
		};
		ref MapTravelPoint reference209 = ref array3[14];
		reference209 = new MapTravelPoint
		{
			pointName = "NhiÕp ThÝ TrÇn",
			coordinateOptions = new uint[1, 2] { { 43844u, 96200u } }
		};
		ref MapTravelPoint reference210 = ref array3[15];
		reference210 = new MapTravelPoint
		{
			pointName = "DÞch quan",
			coordinateOptions = new uint[1, 2] { { 50882u, 93634u } }
		};
		ref MapTravelPoint reference211 = ref array3[16];
		reference211 = new MapTravelPoint
		{
			pointName = "T«ng TÈu",
			coordinateOptions = new uint[1, 2] { { 44913u, 105472u } }
		};
		ref MapTravelPoint reference212 = ref array3[17];
		reference212 = new MapTravelPoint
		{
			pointName = "Minh Chñ H¾c §iÓu",
			coordinateOptions = new uint[1, 2] { { 45160u, 105860u } }
		};
		ref MapTravelPoint reference213 = ref array3[18];
		reference213 = new MapTravelPoint
		{
			pointName = "Minh Chñ Nh\u00ad ý",
			coordinateOptions = new uint[1, 2] { { 45856u, 105184u } }
		};
		ref MapTravelPoint reference214 = ref array3[19];
		reference214 = new MapTravelPoint
		{
			pointName = "Minh Chñ - CHAO",
			coordinateOptions = new uint[1, 2] { { 46016u, 104896u } }
		};
		ref MapTravelPoint reference215 = ref array3[20];
		reference215 = new MapTravelPoint
		{
			pointName = "Minh Chñ - §¹iGiaMªGame",
			coordinateOptions = new uint[1, 2] { { 46656u, 104416u } }
		};
		ref MapTravelPoint reference216 = ref array3[21];
		reference216 = new MapTravelPoint
		{
			pointName = "Minh Chñ - V«§ÞchThÇnN÷",
			coordinateOptions = new uint[1, 2] { { 46656u, 104416u } }
		};
		ref MapTravelPoint reference217 = ref array3[22];
		reference217 = new MapTravelPoint
		{
			pointName = "ThÈm Th\u00a8ng Y",
			coordinateOptions = new uint[1, 2] { { 45568u, 105600u } }
		};
		gStruct145.gstruct24_0 = array3;
		reference194 = gStruct145;
		ref TravelMapEntry reference218 = ref array2[5];
		TravelMapEntry gStruct152 = new TravelMapEntry
		{
			mapName = "D\u00ad¬ng Ch©u",
			mapId = 80
		};
		array3 = new MapTravelPoint[17];
		ref MapTravelPoint reference219 = ref array3[0];
		MapTravelPoint gStruct153 = new MapTravelPoint
		{
			pointName = "NgoaiThanh"
		};
		uint[,] array_148 = new uint[4, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_148, 197911);
		gStruct153.coordinateOptions = array_148;
		reference219 = gStruct153;
		ref MapTravelPoint reference220 = ref array3[1];
		reference220 = new MapTravelPoint
		{
			pointName = "Sø gi¶ m«n ph\u00b8i",
			coordinateOptions = new uint[1, 2] { { 56736u, 96768u } }
		};
		ref MapTravelPoint reference221 = ref array3[2];
		reference221 = new MapTravelPoint
		{
			pointName = "Xa phu c«ng thµnh",
			coordinateOptions = new uint[1, 2] { { 54144u, 102976u } }
		};
		ref MapTravelPoint reference222 = ref array3[3];
		MapTravelPoint gStruct154 = new MapTravelPoint
		{
			pointName = "Xa phu"
		};
		uint[,] array_149 = new uint[4, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_149, 198028);
		gStruct154.coordinateOptions = array_149;
		reference222 = gStruct154;
		ref MapTravelPoint reference223 = ref array3[4];
		MapTravelPoint gStruct155 = new MapTravelPoint
		{
			pointName = "R\u00ad¬ng chøa ®å"
		};
		uint[,] array_150 = new uint[5, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_150, 198073);
		gStruct155.coordinateOptions = array_150;
		reference223 = gStruct155;
		ref MapTravelPoint reference224 = ref array3[5];
		reference224 = new MapTravelPoint
		{
			pointName = "Thî rÌn",
			coordinateOptions = new uint[1, 2] { { 54041u, 101416u } }
		};
		ref MapTravelPoint reference225 = ref array3[6];
		reference225 = new MapTravelPoint
		{
			pointName = "D· TÈu",
			coordinateOptions = new uint[1, 2] { { 55741u, 94848u } }
		};
		ref MapTravelPoint reference226 = ref array3[7];
		reference226 = new MapTravelPoint
		{
			pointName = "ThÇn BÝ Th\u00ad¬ng Nh©n",
			coordinateOptions = new uint[1, 2] { { 53089u, 98738u } }
		};
		ref MapTravelPoint reference227 = ref array3[8];
		reference227 = new MapTravelPoint
		{
			pointName = "LÔ Quan",
			coordinateOptions = new uint[1, 2] { { 55780u, 95904u } }
		};
		ref MapTravelPoint reference228 = ref array3[9];
		reference228 = new MapTravelPoint
		{
			pointName = "Vâ L©m truyÒn nh©n",
			coordinateOptions = new uint[1, 2] { { 57344u, 97546u } }
		};
		ref MapTravelPoint reference229 = ref array3[10];
		reference229 = new MapTravelPoint
		{
			pointName = "T¹p Hãa",
			coordinateOptions = new uint[1, 2] { { 54490u, 96668u } }
		};
		ref MapTravelPoint reference230 = ref array3[11];
		reference230 = new MapTravelPoint
		{
			pointName = "Chñ tiÖm t¹p hãa",
			coordinateOptions = new uint[1, 2] { { 54490u, 96668u } }
		};
		ref MapTravelPoint reference231 = ref array3[12];
		reference231 = new MapTravelPoint
		{
			pointName = "¤ng chñ d\u00adîc ®iÕm",
			coordinateOptions = new uint[1, 2] { { 56801u, 98722u } }
		};
		ref MapTravelPoint reference232 = ref array3[13];
		reference232 = new MapTravelPoint
		{
			pointName = "HIEUTHUOC",
			coordinateOptions = new uint[1, 2] { { 56801u, 98722u } }
		};
		ref MapTravelPoint reference233 = ref array3[14];
		reference233 = new MapTravelPoint
		{
			pointName = "B\u00b8n ngùa",
			coordinateOptions = new uint[1, 2] { { 52632u, 101834u } }
		};
		ref MapTravelPoint reference234 = ref array3[15];
		reference234 = new MapTravelPoint
		{
			pointName = "NhiÕp ThÝ TrÇn",
			coordinateOptions = new uint[1, 2] { { 54460u, 94738u } }
		};
		ref MapTravelPoint reference235 = ref array3[16];
		reference235 = new MapTravelPoint
		{
			pointName = "DÞch quan",
			coordinateOptions = new uint[1, 2] { { 53677u, 96036u } }
		};
		gStruct152.gstruct24_0 = array3;
		reference218 = gStruct152;
		ref TravelMapEntry reference236 = ref array2[6];
		TravelMapEntry gStruct156 = new TravelMapEntry
		{
			mapName = "T\u00ad¬ng D\u00ad¬ng",
			mapId = 78
		};
		array3 = new MapTravelPoint[17];
		ref MapTravelPoint reference237 = ref array3[0];
		MapTravelPoint gStruct157 = new MapTravelPoint
		{
			pointName = "NgoaiThanh"
		};
		uint[,] array_151 = new uint[4, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_151, 198570);
		gStruct157.coordinateOptions = array_151;
		reference237 = gStruct157;
		ref MapTravelPoint reference238 = ref array3[1];
		reference238 = new MapTravelPoint
		{
			pointName = "Sø gi¶ m«n ph\u00b8i",
			coordinateOptions = new uint[1, 2] { { 51264u, 103328u } }
		};
		ref MapTravelPoint reference239 = ref array3[2];
		reference239 = new MapTravelPoint
		{
			pointName = "Xa phu c«ng thµnh",
			coordinateOptions = new uint[1, 2] { { 50624u, 108160u } }
		};
		ref MapTravelPoint reference240 = ref array3[3];
		MapTravelPoint gStruct158 = new MapTravelPoint
		{
			pointName = "Xa phu"
		};
		uint[,] array_152 = new uint[4, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_152, 198687);
		gStruct158.coordinateOptions = array_152;
		reference240 = gStruct158;
		ref MapTravelPoint reference241 = ref array3[4];
		MapTravelPoint gStruct159 = new MapTravelPoint
		{
			pointName = "R\u00ad¬ng chøa ®å"
		};
		uint[,] array_153 = new uint[5, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_153, 198732);
		gStruct159.coordinateOptions = array_153;
		reference241 = gStruct159;
		ref MapTravelPoint reference242 = ref array3[5];
		reference242 = new MapTravelPoint
		{
			pointName = "Chñ TiÒn trang",
			coordinateOptions = new uint[1, 2] { { 48938u, 103230u } }
		};
		ref MapTravelPoint reference243 = ref array3[6];
		reference243 = new MapTravelPoint
		{
			pointName = "Thî rÌn",
			coordinateOptions = new uint[1, 2] { { 49678u, 102940u } }
		};
		ref MapTravelPoint reference244 = ref array3[7];
		reference244 = new MapTravelPoint
		{
			pointName = "D· TÈu",
			coordinateOptions = new uint[1, 2] { { 51006u, 105324u } }
		};
		ref MapTravelPoint reference245 = ref array3[8];
		reference245 = new MapTravelPoint
		{
			pointName = "LÔ Quan",
			coordinateOptions = new uint[1, 2] { { 49323u, 103880u } }
		};
		ref MapTravelPoint reference246 = ref array3[9];
		reference246 = new MapTravelPoint
		{
			pointName = "ThÇn bÝ Th\u00ad¬ng Nh©n",
			coordinateOptions = new uint[1, 2] { { 49791u, 101861u } }
		};
		ref MapTravelPoint reference247 = ref array3[10];
		reference247 = new MapTravelPoint
		{
			pointName = "Vâ L©m truyÒn nh©n",
			coordinateOptions = new uint[1, 2] { { 51481u, 104206u } }
		};
		ref MapTravelPoint reference248 = ref array3[11];
		reference248 = new MapTravelPoint
		{
			pointName = "Chñ tiÖm t¹p hãa",
			coordinateOptions = new uint[1, 2] { { 52093u, 104410u } }
		};
		ref MapTravelPoint reference249 = ref array3[12];
		reference249 = new MapTravelPoint
		{
			pointName = "¤ng chñ d\u00adîc ®iÕm",
			coordinateOptions = new uint[1, 2] { { 51560u, 103866u } }
		};
		ref MapTravelPoint reference250 = ref array3[13];
		reference250 = new MapTravelPoint
		{
			pointName = "HIEUTHUOC",
			coordinateOptions = new uint[1, 2] { { 51560u, 103866u } }
		};
		ref MapTravelPoint reference251 = ref array3[14];
		reference251 = new MapTravelPoint
		{
			pointName = "B\u00b8n ngùa",
			coordinateOptions = new uint[1, 2] { { 50086u, 102232u } }
		};
		ref MapTravelPoint reference252 = ref array3[15];
		reference252 = new MapTravelPoint
		{
			pointName = "NhiÕp ThÝ TrÇn",
			coordinateOptions = new uint[1, 2] { { 48350u, 102630u } }
		};
		ref MapTravelPoint reference253 = ref array3[16];
		reference253 = new MapTravelPoint
		{
			pointName = "DÞch quan",
			coordinateOptions = new uint[1, 2] { { 50773u, 107826u } }
		};
		gStruct156.gstruct24_0 = array3;
		reference236 = gStruct156;
		ref TravelMapEntry reference254 = ref array2[7];
		reference254 = new TravelMapEntry
		{
			mapName = "Ba L\u00a8ng huyÖn",
			mapId = 53,
			gstruct24_0 = new MapTravelPoint[22]
			{
				new MapTravelPoint
				{
					pointName = "Xa phu",
					coordinateOptions = new uint[1, 2] { { 50553u, 103612u } }
				},
				new MapTravelPoint
				{
					pointName = "R\u00ad¬ng chøa ®å",
					coordinateOptions = new uint[1, 2] { { 51679u, 101442u } }
				},
				new MapTravelPoint
				{
					pointName = "Thî rÌn",
					coordinateOptions = new uint[1, 2] { { 50705u, 101006u } }
				},
				new MapTravelPoint
				{
					pointName = "D· TÈu",
					coordinateOptions = new uint[1, 2] { { 51990u, 101598u } }
				},
				new MapTravelPoint
				{
					pointName = "LÔ Quan",
					coordinateOptions = new uint[1, 2] { { 52083u, 102230u } }
				},
				new MapTravelPoint
				{
					pointName = "Chñ tiÖm t¹p hãa",
					coordinateOptions = new uint[1, 2] { { 51208u, 101458u } }
				},
				new MapTravelPoint
				{
					pointName = "HIEUTHUOC",
					coordinateOptions = new uint[1, 2] { { 51193u, 102754u } }
				},
				new MapTravelPoint
				{
					pointName = "Ng« ThÇn Y",
					coordinateOptions = new uint[1, 2] { { 51193u, 102754u } }
				},
				new MapTravelPoint
				{
					pointName = "Long Ngò",
					coordinateOptions = new uint[1, 2] { { 51679u, 101442u } }
				},
				new MapTravelPoint
				{
					pointName = "Qu©n S\u00ad T©n Thñ",
					coordinateOptions = new uint[1, 2] { { 52096u, 101856u } }
				},
				new MapTravelPoint
				{
					pointName = "Thiªn V\u00ad¬ng T\u00adíng LÜnh",
					coordinateOptions = new uint[1, 2] { { 51528u, 102294u } }
				},
				new MapTravelPoint
				{
					pointName = "ThiÕu L©m La H\u00b8n",
					coordinateOptions = new uint[1, 2] { { 50936u, 100144u } }
				},
				new MapTravelPoint
				{
					pointName = "§\u00adêng M«n ThÞ VÖ",
					coordinateOptions = new uint[1, 2] { { 51623u, 101582u } }
				},
				new MapTravelPoint
				{
					pointName = "Ngò §écT\u00b8n nh©n",
					coordinateOptions = new uint[1, 2] { { 51891u, 102620u } }
				},
				new MapTravelPoint
				{
					pointName = "Nga My CÈm Y Ni",
					coordinateOptions = new uint[1, 2] { { 52374u, 101894u } }
				},
				new MapTravelPoint
				{
					pointName = "Thóy Yªn Hoa Sø",
					coordinateOptions = new uint[1, 2] { { 50608u, 102481u } }
				},
				new MapTravelPoint
				{
					pointName = "Thiªn NhÉn Tö sÜ",
					coordinateOptions = new uint[1, 2] { { 51811u, 101266u } }
				},
				new MapTravelPoint
				{
					pointName = "§Ö tö C\u00b8i Bang",
					coordinateOptions = new uint[1, 2] { { 51214u, 99970u } }
				},
				new MapTravelPoint
				{
					pointName = "C«n L«n Hé Ph\u00b8p",
					coordinateOptions = new uint[1, 2] { { 50439u, 100656u } }
				},
				new MapTravelPoint
				{
					pointName = "Vâ §ang §¹o Nh©n",
					coordinateOptions = new uint[1, 2] { { 52335u, 102036u } }
				},
				new MapTravelPoint
				{
					pointName = "Hoa S¬n Èn SÜ",
					coordinateOptions = new uint[1, 2] { { 51936u, 102272u } }
				},
				new MapTravelPoint
				{
					pointName = "TiÓu Ph\u00ad¬ng C« N\u00ad¬ng",
					coordinateOptions = new uint[1, 2] { { 52192u, 101664u } }
				}
			}
		};
		ref TravelMapEntry reference255 = ref array2[8];
		reference255 = new TravelMapEntry
		{
			mapName = "§¹o H\u00ad¬ng th«n",
			mapId = 101,
			gstruct24_0 = new MapTravelPoint[16]
			{
				new MapTravelPoint
				{
					pointName = "Xa phu",
					coordinateOptions = new uint[1, 2] { { 51946u, 99340u } }
				},
				new MapTravelPoint
				{
					pointName = "R\u00ad¬ng chøa ®å",
					coordinateOptions = new uint[1, 2] { { 53791u, 100422u } }
				},
				new MapTravelPoint
				{
					pointName = "Thî rÌn",
					coordinateOptions = new uint[1, 2] { { 51667u, 100402u } }
				},
				new MapTravelPoint
				{
					pointName = "D· TÈu",
					coordinateOptions = new uint[1, 2] { { 53791u, 100422u } }
				},
				new MapTravelPoint
				{
					pointName = "LÔ Quan",
					coordinateOptions = new uint[1, 2] { { 53449u, 101594u } }
				},
				new MapTravelPoint
				{
					pointName = "Chñ tiÖm t¹p hãa",
					coordinateOptions = new uint[1, 2] { { 52457u, 100610u } }
				},
				new MapTravelPoint
				{
					pointName = "¤ng chñ t¹p hãa",
					coordinateOptions = new uint[1, 2] { { 52457u, 100610u } }
				},
				new MapTravelPoint
				{
					pointName = "HIEUTHUOC",
					coordinateOptions = new uint[1, 2] { { 53735u, 102287u } }
				},
				new MapTravelPoint
				{
					pointName = "¤ng chñ d\u00adîc ®iÕm",
					coordinateOptions = new uint[1, 2] { { 53735u, 102287u } }
				},
				new MapTravelPoint
				{
					pointName = "Chñ d\u00adîc ®iÕm §¹o H\u00ad¬ng Th«n",
					coordinateOptions = new uint[1, 2] { { 53735u, 102287u } }
				},
				new MapTravelPoint
				{
					pointName = "Long Ngò",
					coordinateOptions = new uint[1, 2] { { 54116u, 100510u } }
				},
				new MapTravelPoint
				{
					pointName = "C«ng thµnh quan",
					coordinateOptions = new uint[1, 2] { { 52608u, 101002u } }
				},
				new MapTravelPoint
				{
					pointName = "ThiÕu L©m La H\u00b8n",
					coordinateOptions = new uint[1, 2] { { 53340u, 101337u } }
				},
				new MapTravelPoint
				{
					pointName = "Qu©n S\u00ad T©n Thñ",
					coordinateOptions = new uint[1, 2] { { 54304u, 100864u } }
				},
				new MapTravelPoint
				{
					pointName = "TiÓu Ph\u00ad¬ng C« N\u00ad¬ng",
					coordinateOptions = new uint[1, 2] { { 54240u, 100064u } }
				},
				new MapTravelPoint
				{
					pointName = "Thiªn NhÉn Tö sÜ",
					coordinateOptions = new uint[1, 2] { { 53384u, 100759u } }
				}
			}
		};
		ref TravelMapEntry reference256 = ref array2[9];
		TravelMapEntry gStruct160 = new TravelMapEntry
		{
			mapName = "Long M«n trÊn",
			mapId = 121
		};
		array3 = new MapTravelPoint[15];
		ref MapTravelPoint reference257 = ref array3[0];
		MapTravelPoint gStruct161 = new MapTravelPoint
		{
			pointName = "Xa phu"
		};
		uint[,] array_154 = new uint[2, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_154, 200621);
		gStruct161.coordinateOptions = array_154;
		reference257 = gStruct161;
		ref MapTravelPoint reference258 = ref array3[1];
		MapTravelPoint gStruct162 = new MapTravelPoint
		{
			pointName = "R\u00ad¬ng chøa ®å"
		};
		uint[,] array_155 = new uint[2, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_155, 200650);
		gStruct162.coordinateOptions = array_155;
		reference258 = gStruct162;
		ref MapTravelPoint reference259 = ref array3[2];
		reference259 = new MapTravelPoint
		{
			pointName = "Thî rÌn",
			coordinateOptions = new uint[1, 2] { { 64017u, 144400u } }
		};
		ref MapTravelPoint reference260 = ref array3[3];
		reference260 = new MapTravelPoint
		{
			pointName = "D· TÈu",
			coordinateOptions = new uint[1, 2] { { 62627u, 143996u } }
		};
		ref MapTravelPoint reference261 = ref array3[4];
		reference261 = new MapTravelPoint
		{
			pointName = "LÔ Quan",
			coordinateOptions = new uint[1, 2] { { 62610u, 144486u } }
		};
		ref MapTravelPoint reference262 = ref array3[5];
		reference262 = new MapTravelPoint
		{
			pointName = "Chñ tiÖm t¹p hãa",
			coordinateOptions = new uint[1, 2] { { 61265u, 144783u } }
		};
		ref MapTravelPoint reference263 = ref array3[6];
		reference263 = new MapTravelPoint
		{
			pointName = "¤ng chñ d\u00adîc ®iÕm",
			coordinateOptions = new uint[1, 2] { { 61906u, 145644u } }
		};
		ref MapTravelPoint reference264 = ref array3[7];
		reference264 = new MapTravelPoint
		{
			pointName = "HIEUTHUOC",
			coordinateOptions = new uint[1, 2] { { 61906u, 145644u } }
		};
		ref MapTravelPoint reference265 = ref array3[8];
		reference265 = new MapTravelPoint
		{
			pointName = "Long Ngò",
			coordinateOptions = new uint[1, 2] { { 64202u, 143484u } }
		};
		ref MapTravelPoint reference266 = ref array3[9];
		reference266 = new MapTravelPoint
		{
			pointName = "C«ng thµnh quan",
			coordinateOptions = new uint[1, 2] { { 63454u, 143925u } }
		};
		ref MapTravelPoint reference267 = ref array3[10];
		reference267 = new MapTravelPoint
		{
			pointName = "ThiÕu L©m La H\u00b8n",
			coordinateOptions = new uint[1, 2] { { 62345u, 144894u } }
		};
		ref MapTravelPoint reference268 = ref array3[11];
		reference268 = new MapTravelPoint
		{
			pointName = "Qu©n S\u00ad T©n Thñ",
			coordinateOptions = new uint[1, 2] { { 63168u, 144000u } }
		};
		ref MapTravelPoint reference269 = ref array3[12];
		reference269 = new MapTravelPoint
		{
			pointName = "TiÓu Ph\u00ad¬ng C« N\u00ad¬ng",
			coordinateOptions = new uint[1, 2] { { 63392u, 143488u } }
		};
		ref MapTravelPoint reference270 = ref array3[13];
		reference270 = new MapTravelPoint
		{
			pointName = "Thiªn NhÉn Tö sÜ",
			coordinateOptions = new uint[1, 2] { { 64199u, 142895u } }
		};
		ref MapTravelPoint reference271 = ref array3[14];
		reference271 = new MapTravelPoint
		{
			pointName = "Thiªn NhÉn Gi\u00b8o ®å",
			coordinateOptions = new uint[1, 2] { { 64199u, 142895u } }
		};
		gStruct160.gstruct24_0 = array3;
		reference256 = gStruct160;
		ref TravelMapEntry reference272 = ref array2[10];
		TravelMapEntry gStruct163 = new TravelMapEntry
		{
			mapName = "VÜnh L¹c trÊn",
			mapId = 99
		};
		array3 = new MapTravelPoint[15];
		ref MapTravelPoint reference273 = ref array3[0];
		MapTravelPoint gStruct164 = new MapTravelPoint
		{
			pointName = "Xa phu"
		};
		uint[,] array_156 = new uint[2, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_156, 201159);
		gStruct164.coordinateOptions = array_156;
		reference273 = gStruct164;
		ref MapTravelPoint reference274 = ref array3[1];
		MapTravelPoint gStruct165 = new MapTravelPoint
		{
			pointName = "R\u00ad¬ng chøa ®å"
		};
		uint[,] array_157 = new uint[2, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_157, 201188);
		gStruct165.coordinateOptions = array_157;
		reference274 = gStruct165;
		ref MapTravelPoint reference275 = ref array3[2];
		reference275 = new MapTravelPoint
		{
			pointName = "Thî rÌn",
			coordinateOptions = new uint[1, 2] { { 53415u, 104588u } }
		};
		ref MapTravelPoint reference276 = ref array3[3];
		reference276 = new MapTravelPoint
		{
			pointName = "D· TÈu",
			coordinateOptions = new uint[1, 2] { { 52427u, 101957u } }
		};
		ref MapTravelPoint reference277 = ref array3[4];
		reference277 = new MapTravelPoint
		{
			pointName = "LÔ Quan",
			coordinateOptions = new uint[1, 2] { { 52000u, 101888u } }
		};
		ref MapTravelPoint reference278 = ref array3[5];
		reference278 = new MapTravelPoint
		{
			pointName = "Chñ tiÖm t¹p hãa",
			coordinateOptions = new uint[1, 2] { { 51413u, 105044u } }
		};
		ref MapTravelPoint reference279 = ref array3[6];
		reference279 = new MapTravelPoint
		{
			pointName = "¤ng chñ t¹p hãa",
			coordinateOptions = new uint[1, 2] { { 51413u, 105044u } }
		};
		ref MapTravelPoint reference280 = ref array3[7];
		reference280 = new MapTravelPoint
		{
			pointName = "HIEUTHUOC",
			coordinateOptions = new uint[1, 2] { { 51061u, 103279u } }
		};
		ref MapTravelPoint reference281 = ref array3[8];
		reference281 = new MapTravelPoint
		{
			pointName = "¤ng chñ d\u00adîc ®iÕm",
			coordinateOptions = new uint[1, 2] { { 51061u, 103279u } }
		};
		ref MapTravelPoint reference282 = ref array3[9];
		reference282 = new MapTravelPoint
		{
			pointName = "Long Ngò",
			coordinateOptions = new uint[1, 2] { { 52083u, 102047u } }
		};
		ref MapTravelPoint reference283 = ref array3[10];
		reference283 = new MapTravelPoint
		{
			pointName = "C«ng thµnh quan",
			coordinateOptions = new uint[1, 2] { { 53108u, 105033u } }
		};
		ref MapTravelPoint reference284 = ref array3[11];
		reference284 = new MapTravelPoint
		{
			pointName = "ThiÕu L©m La H\u00b8n",
			coordinateOptions = new uint[1, 2] { { 53326u, 102681u } }
		};
		ref MapTravelPoint reference285 = ref array3[12];
		reference285 = new MapTravelPoint
		{
			pointName = "Qu©n S\u00ad T©n Thñ",
			coordinateOptions = new uint[1, 2] { { 52256u, 102304u } }
		};
		ref MapTravelPoint reference286 = ref array3[13];
		reference286 = new MapTravelPoint
		{
			pointName = "TiÓu Ph\u00ad¬ng C« N\u00ad¬ng",
			coordinateOptions = new uint[1, 2] { { 52032u, 102624u } }
		};
		ref MapTravelPoint reference287 = ref array3[14];
		reference287 = new MapTravelPoint
		{
			pointName = "Thiªn NhÉn Tö sÜ",
			coordinateOptions = new uint[1, 2] { { 51753u, 102320u } }
		};
		gStruct163.gstruct24_0 = array3;
		reference272 = gStruct163;
		ref TravelMapEntry reference288 = ref array2[11];
		TravelMapEntry gStruct166 = new TravelMapEntry
		{
			mapName = "Th¹ch Cæ trÊn",
			mapId = 153
		};
		array3 = new MapTravelPoint[15];
		ref MapTravelPoint reference289 = ref array3[0];
		MapTravelPoint gStruct167 = new MapTravelPoint
		{
			pointName = "Xa phu"
		};
		uint[,] array_158 = new uint[2, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_158, 201697);
		gStruct167.coordinateOptions = array_158;
		reference289 = gStruct167;
		ref MapTravelPoint reference290 = ref array3[1];
		reference290 = new MapTravelPoint
		{
			pointName = "R\u00ad¬ng chøa ®å",
			coordinateOptions = new uint[1, 2] { { 53273u, 103217u } }
		};
		ref MapTravelPoint reference291 = ref array3[2];
		reference291 = new MapTravelPoint
		{
			pointName = "Thî rÌn",
			coordinateOptions = new uint[1, 2] { { 51484u, 103991u } }
		};
		ref MapTravelPoint reference292 = ref array3[3];
		reference292 = new MapTravelPoint
		{
			pointName = "D· TÈu",
			coordinateOptions = new uint[1, 2] { { 52589u, 103319u } }
		};
		ref MapTravelPoint reference293 = ref array3[4];
		reference293 = new MapTravelPoint
		{
			pointName = "LÔ Quan",
			coordinateOptions = new uint[1, 2] { { 51340u, 103711u } }
		};
		ref MapTravelPoint reference294 = ref array3[5];
		reference294 = new MapTravelPoint
		{
			pointName = "Chñ tiÖm t¹p hãa",
			coordinateOptions = new uint[1, 2] { { 52312u, 103140u } }
		};
		ref MapTravelPoint reference295 = ref array3[6];
		reference295 = new MapTravelPoint
		{
			pointName = "HIEUTHUOC",
			coordinateOptions = new uint[1, 2] { { 51224u, 102694u } }
		};
		ref MapTravelPoint reference296 = ref array3[7];
		reference296 = new MapTravelPoint
		{
			pointName = "¤ng chñ d\u00adîc ®iÕm",
			coordinateOptions = new uint[1, 2] { { 51224u, 102694u } }
		};
		ref MapTravelPoint reference297 = ref array3[8];
		reference297 = new MapTravelPoint
		{
			pointName = "Long Ngò",
			coordinateOptions = new uint[1, 2] { { 52192u, 104165u } }
		};
		ref MapTravelPoint reference298 = ref array3[9];
		reference298 = new MapTravelPoint
		{
			pointName = "C«ng thµnh quan",
			coordinateOptions = new uint[1, 2] { { 52128u, 102438u } }
		};
		ref MapTravelPoint reference299 = ref array3[10];
		reference299 = new MapTravelPoint
		{
			pointName = "ThiÕu L©m La H\u00b8n",
			coordinateOptions = new uint[1, 2] { { 51945u, 103300u } }
		};
		ref MapTravelPoint reference300 = ref array3[11];
		reference300 = new MapTravelPoint
		{
			pointName = "Qu©n S\u00ad T©n Thñ",
			coordinateOptions = new uint[1, 2] { { 52448u, 102272u } }
		};
		ref MapTravelPoint reference301 = ref array3[12];
		reference301 = new MapTravelPoint
		{
			pointName = "TiÓu Ph\u00ad¬ng C« N\u00ad¬ng",
			coordinateOptions = new uint[1, 2] { { 51808u, 103008u } }
		};
		ref MapTravelPoint reference302 = ref array3[13];
		reference302 = new MapTravelPoint
		{
			pointName = "Thiªn NhÉn Tö sÜ",
			coordinateOptions = new uint[1, 2] { { 52465u, 102843u } }
		};
		ref MapTravelPoint reference303 = ref array3[14];
		reference303 = new MapTravelPoint
		{
			pointName = "Thiªn NhÉn Gi\u00b8o ®å",
			coordinateOptions = new uint[1, 2] { { 52465u, 102843u } }
		};
		gStruct166.gstruct24_0 = array3;
		reference288 = gStruct166;
		ref TravelMapEntry reference304 = ref array2[12];
		TravelMapEntry gStruct168 = new TravelMapEntry
		{
			mapName = "Giang T©n Th«n",
			mapId = 20
		};
		array3 = new MapTravelPoint[14]
		{
			new MapTravelPoint
			{
				pointName = "Xa phu",
				coordinateOptions = new uint[1, 2] { { 110678u, 195539u } }
			},
			default(MapTravelPoint),
			default(MapTravelPoint),
			default(MapTravelPoint),
			default(MapTravelPoint),
			default(MapTravelPoint),
			default(MapTravelPoint),
			default(MapTravelPoint),
			default(MapTravelPoint),
			default(MapTravelPoint),
			default(MapTravelPoint),
			default(MapTravelPoint),
			default(MapTravelPoint),
			default(MapTravelPoint)
		};
		ref MapTravelPoint reference305 = ref array3[1];
		MapTravelPoint gStruct169 = new MapTravelPoint
		{
			pointName = "R\u00ad¬ng chøa ®å"
		};
		uint[,] array_159 = new uint[3, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_159, 202278);
		gStruct169.coordinateOptions = array_159;
		reference305 = gStruct169;
		ref MapTravelPoint reference306 = ref array3[2];
		reference306 = new MapTravelPoint
		{
			pointName = "Thî rÌn",
			coordinateOptions = new uint[1, 2] { { 110057u, 199063u } }
		};
		ref MapTravelPoint reference307 = ref array3[3];
		reference307 = new MapTravelPoint
		{
			pointName = "D· TÈu",
			coordinateOptions = new uint[1, 2] { { 113652u, 198912u } }
		};
		ref MapTravelPoint reference308 = ref array3[4];
		reference308 = new MapTravelPoint
		{
			pointName = "LÔ Quan",
			coordinateOptions = new uint[1, 2] { { 113759u, 198134u } }
		};
		ref MapTravelPoint reference309 = ref array3[5];
		reference309 = new MapTravelPoint
		{
			pointName = "Chñ tiÖm t¹p hãa",
			coordinateOptions = new uint[1, 2] { { 107844u, 200180u } }
		};
		ref MapTravelPoint reference310 = ref array3[6];
		reference310 = new MapTravelPoint
		{
			pointName = "HIEUTHUOC",
			coordinateOptions = new uint[1, 2] { { 111038u, 197266u } }
		};
		ref MapTravelPoint reference311 = ref array3[7];
		reference311 = new MapTravelPoint
		{
			pointName = "¤ng chñ d\u00adîc ®iÕm",
			coordinateOptions = new uint[1, 2] { { 111038u, 197266u } }
		};
		ref MapTravelPoint reference312 = ref array3[8];
		reference312 = new MapTravelPoint
		{
			pointName = "Long Ngò",
			coordinateOptions = new uint[1, 2] { { 113652u, 198912u } }
		};
		ref MapTravelPoint reference313 = ref array3[9];
		reference313 = new MapTravelPoint
		{
			pointName = "C«ng thµnh quan",
			coordinateOptions = new uint[1, 2] { { 111594u, 196282u } }
		};
		ref MapTravelPoint reference314 = ref array3[10];
		reference314 = new MapTravelPoint
		{
			pointName = "ThiÕu L©m La H\u00b8n",
			coordinateOptions = new uint[1, 2] { { 113962u, 198919u } }
		};
		ref MapTravelPoint reference315 = ref array3[11];
		reference315 = new MapTravelPoint
		{
			pointName = "Qu©n S\u00ad T©n Thñ",
			coordinateOptions = new uint[1, 2] { { 114048u, 198240u } }
		};
		ref MapTravelPoint reference316 = ref array3[12];
		reference316 = new MapTravelPoint
		{
			pointName = "TiÓu Ph\u00ad¬ng C« N\u00ad¬ng",
			coordinateOptions = new uint[1, 2] { { 113248u, 198528u } }
		};
		ref MapTravelPoint reference317 = ref array3[13];
		reference317 = new MapTravelPoint
		{
			pointName = "Thiªn NhÉn Tö sÜ",
			coordinateOptions = new uint[1, 2] { { 114697u, 198577u } }
		};
		gStruct168.gstruct24_0 = array3;
		reference304 = gStruct168;
		ref TravelMapEntry reference318 = ref array2[13];
		TravelMapEntry gStruct170 = new TravelMapEntry
		{
			mapName = "Long TuyÒn th«n",
			mapId = 174
		};
		array3 = new MapTravelPoint[15]
		{
			new MapTravelPoint
			{
				pointName = "Xa phu",
				coordinateOptions = new uint[1, 2] { { 52308u, 102274u } }
			},
			default(MapTravelPoint),
			default(MapTravelPoint),
			default(MapTravelPoint),
			default(MapTravelPoint),
			default(MapTravelPoint),
			default(MapTravelPoint),
			default(MapTravelPoint),
			default(MapTravelPoint),
			default(MapTravelPoint),
			default(MapTravelPoint),
			default(MapTravelPoint),
			default(MapTravelPoint),
			default(MapTravelPoint),
			default(MapTravelPoint)
		};
		ref MapTravelPoint reference319 = ref array3[1];
		MapTravelPoint gStruct171 = new MapTravelPoint
		{
			pointName = "R\u00ad¬ng chøa ®å"
		};
		uint[,] array_160 = new uint[2, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_160, 202795);
		gStruct171.coordinateOptions = array_160;
		reference319 = gStruct171;
		ref MapTravelPoint reference320 = ref array3[2];
		reference320 = new MapTravelPoint
		{
			pointName = "Thî rÌn",
			coordinateOptions = new uint[1, 2] { { 51403u, 104040u } }
		};
		ref MapTravelPoint reference321 = ref array3[3];
		reference321 = new MapTravelPoint
		{
			pointName = "D· TÈu",
			coordinateOptions = new uint[1, 2] { { 51734u, 102092u } }
		};
		ref MapTravelPoint reference322 = ref array3[4];
		reference322 = new MapTravelPoint
		{
			pointName = "LÔ Quan",
			coordinateOptions = new uint[1, 2] { { 52148u, 102866u } }
		};
		ref MapTravelPoint reference323 = ref array3[5];
		reference323 = new MapTravelPoint
		{
			pointName = "Chñ tiÖm t¹p hãa",
			coordinateOptions = new uint[1, 2] { { 50124u, 102456u } }
		};
		ref MapTravelPoint reference324 = ref array3[6];
		reference324 = new MapTravelPoint
		{
			pointName = "¤ng chñ d\u00adîc ®iÕm",
			coordinateOptions = new uint[1, 2] { { 50321u, 104123u } }
		};
		ref MapTravelPoint reference325 = ref array3[7];
		reference325 = new MapTravelPoint
		{
			pointName = "HIEUTHUOC",
			coordinateOptions = new uint[1, 2] { { 50321u, 104123u } }
		};
		ref MapTravelPoint reference326 = ref array3[8];
		reference326 = new MapTravelPoint
		{
			pointName = "Long Ngò",
			coordinateOptions = new uint[1, 2] { { 52177u, 105345u } }
		};
		ref MapTravelPoint reference327 = ref array3[9];
		reference327 = new MapTravelPoint
		{
			pointName = "C«ng thµnh quan",
			coordinateOptions = new uint[1, 2] { { 52869u, 102616u } }
		};
		ref MapTravelPoint reference328 = ref array3[10];
		reference328 = new MapTravelPoint
		{
			pointName = "ThiÕu L©m La H\u00b8n",
			coordinateOptions = new uint[1, 2] { { 51930u, 103210u } }
		};
		ref MapTravelPoint reference329 = ref array3[11];
		reference329 = new MapTravelPoint
		{
			pointName = "Qu©n S\u00ad T©n Thñ",
			coordinateOptions = new uint[1, 2] { { 51296u, 102912u } }
		};
		ref MapTravelPoint reference330 = ref array3[12];
		reference330 = new MapTravelPoint
		{
			pointName = "TiÓu Ph\u00ad¬ng C« N\u00ad¬ng",
			coordinateOptions = new uint[1, 2] { { 52256u, 105024u } }
		};
		ref MapTravelPoint reference331 = ref array3[13];
		reference331 = new MapTravelPoint
		{
			pointName = "Thiªn NhÉn Tö sÜ",
			coordinateOptions = new uint[1, 2] { { 53565u, 104389u } }
		};
		ref MapTravelPoint reference332 = ref array3[14];
		reference332 = new MapTravelPoint
		{
			pointName = "Thiªn NhÉn Gi\u00b8o ®å",
			coordinateOptions = new uint[1, 2] { { 53565u, 104389u } }
		};
		gStruct170.gstruct24_0 = array3;
		reference318 = gStruct170;
		ref TravelMapEntry reference333 = ref array2[14];
		TravelMapEntry gStruct172 = new TravelMapEntry
		{
			mapName = "Chu Tiªn trÊn",
			mapId = 100
		};
		array3 = new MapTravelPoint[15];
		ref MapTravelPoint reference334 = ref array3[0];
		MapTravelPoint gStruct173 = new MapTravelPoint
		{
			pointName = "Xa phu"
		};
		uint[,] array_161 = new uint[3, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_161, 203304);
		gStruct173.coordinateOptions = array_161;
		reference334 = gStruct173;
		ref MapTravelPoint reference335 = ref array3[1];
		MapTravelPoint gStruct174 = new MapTravelPoint
		{
			pointName = "R\u00ad¬ng chøa ®å"
		};
		uint[,] array_162 = new uint[2, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_162, 203341);
		gStruct174.coordinateOptions = array_162;
		reference335 = gStruct174;
		ref MapTravelPoint reference336 = ref array3[2];
		reference336 = new MapTravelPoint
		{
			pointName = "Thî rÌn",
			coordinateOptions = new uint[1, 2] { { 53116u, 100760u } }
		};
		ref MapTravelPoint reference337 = ref array3[3];
		reference337 = new MapTravelPoint
		{
			pointName = "D· TÈu",
			coordinateOptions = new uint[1, 2] { { 51552u, 101760u } }
		};
		ref MapTravelPoint reference338 = ref array3[4];
		reference338 = new MapTravelPoint
		{
			pointName = "LÔ Quan",
			coordinateOptions = new uint[1, 2] { { 51552u, 101760u } }
		};
		ref MapTravelPoint reference339 = ref array3[5];
		reference339 = new MapTravelPoint
		{
			pointName = "Chñ tiÖm t¹p hãa",
			coordinateOptions = new uint[1, 2] { { 52519u, 100042u } }
		};
		ref MapTravelPoint reference340 = ref array3[6];
		reference340 = new MapTravelPoint
		{
			pointName = "¤ng chñ t¹p hãa",
			coordinateOptions = new uint[1, 2] { { 52519u, 100042u } }
		};
		ref MapTravelPoint reference341 = ref array3[7];
		reference341 = new MapTravelPoint
		{
			pointName = "HIEUTHUOC",
			coordinateOptions = new uint[1, 2] { { 53041u, 99967u } }
		};
		ref MapTravelPoint reference342 = ref array3[8];
		reference342 = new MapTravelPoint
		{
			pointName = "Chñ d\u00adîc ®iÕm Chu Tiªn TrÊn",
			coordinateOptions = new uint[1, 2] { { 53041u, 99967u } }
		};
		ref MapTravelPoint reference343 = ref array3[9];
		reference343 = new MapTravelPoint
		{
			pointName = "Long Ngò",
			coordinateOptions = new uint[1, 2] { { 51552u, 101760u } }
		};
		ref MapTravelPoint reference344 = ref array3[10];
		reference344 = new MapTravelPoint
		{
			pointName = "C«ng thµnh quan",
			coordinateOptions = new uint[1, 2] { { 52117u, 102928u } }
		};
		ref MapTravelPoint reference345 = ref array3[11];
		reference345 = new MapTravelPoint
		{
			pointName = "ThiÕu L©m La H\u00b8n",
			coordinateOptions = new uint[1, 2] { { 53328u, 99724u } }
		};
		ref MapTravelPoint reference346 = ref array3[12];
		reference346 = new MapTravelPoint
		{
			pointName = "Qu©n S\u00ad T©n Thñ",
			coordinateOptions = new uint[1, 2] { { 51904u, 102208u } }
		};
		ref MapTravelPoint reference347 = ref array3[13];
		reference347 = new MapTravelPoint
		{
			pointName = "TiÓu Ph\u00ad¬ng C« N\u00ad¬ng",
			coordinateOptions = new uint[1, 2] { { 52032u, 102400u } }
		};
		ref MapTravelPoint reference348 = ref array3[14];
		reference348 = new MapTravelPoint
		{
			pointName = "Thiªn NhÉn Tö sÜ",
			coordinateOptions = new uint[1, 2] { { 51992u, 100479u } }
		};
		gStruct172.gstruct24_0 = array3;
		reference333 = gStruct172;
		ref TravelMapEntry reference349 = ref array2[15];
		reference349 = new TravelMapEntry
		{
			mapName = "Nam Nh¹c trÊn",
			mapId = 54,
			gstruct24_0 = new MapTravelPoint[6]
			{
				new MapTravelPoint
				{
					pointName = "Xa phu",
					coordinateOptions = new uint[1, 2] { { 50913u, 98975u } }
				},
				new MapTravelPoint
				{
					pointName = "R\u00ad¬ng chøa ®å",
					coordinateOptions = new uint[1, 2] { { 53247u, 100481u } }
				},
				new MapTravelPoint
				{
					pointName = "Chñ tiÖm t¹p hãa",
					coordinateOptions = new uint[1, 2] { { 52721u, 99473u } }
				},
				new MapTravelPoint
				{
					pointName = "¤ng chñ d\u00adîc ®iÕm",
					coordinateOptions = new uint[1, 2] { { 52427u, 100556u } }
				},
				new MapTravelPoint
				{
					pointName = "HIEUTHUOC",
					coordinateOptions = new uint[1, 2] { { 52427u, 100556u } }
				},
				new MapTravelPoint
				{
					pointName = "Thî rÌn",
					coordinateOptions = new uint[1, 2] { { 53607u, 101750u } }
				}
			}
		};
		ref TravelMapEntry reference350 = ref array2[16];
		reference350 = new TravelMapEntry
		{
			mapName = "Minh NguyÖt trÊ",
			gstruct24_0 = new MapTravelPoint[2]
			{
				new MapTravelPoint
				{
					pointName = "B¾c §Èu L·o Nh©n",
					coordinateOptions = new uint[1, 2] { { 50432u, 99552u } }
				},
				new MapTravelPoint
				{
					pointName = "¤ng Giµ Noel",
					coordinateOptions = new uint[1, 2] { { 50656u, 99712u } }
				}
			}
		};
		ref TravelMapEntry reference351 = ref array2[17];
		reference351 = new TravelMapEntry
		{
			mapName = "Vi s¬n ®¶o",
			mapId = 342,
			gstruct24_0 = new MapTravelPoint[5]
			{
				new MapTravelPoint
				{
					pointName = "R\u00ad¬ng chøa ®å",
					coordinateOptions = new uint[1, 2] { { 44864u, 90496u } }
				},
				new MapTravelPoint
				{
					pointName = "HIEUTHUOC",
					coordinateOptions = new uint[1, 2] { { 45408u, 89504u } }
				},
				new MapTravelPoint
				{
					pointName = "¤ng chñ d\u00adîc ®iÕm",
					coordinateOptions = new uint[1, 2] { { 45408u, 89504u } }
				},
				new MapTravelPoint
				{
					pointName = "Chñ tiÖm thuèc",
					coordinateOptions = new uint[1, 2] { { 45408u, 89504u } }
				},
				new MapTravelPoint
				{
					pointName = "Thî rÌn",
					coordinateOptions = new uint[1, 2] { { 44160u, 89728u } }
				}
			}
		};
		ref TravelMapEntry reference352 = ref array2[18];
		reference352 = new TravelMapEntry
		{
			mapName = "M¹c B¾c Th¶o Ng",
			mapId = 341,
			gstruct24_0 = new MapTravelPoint[4]
			{
				new MapTravelPoint
				{
					pointName = "R\u00ad¬ng chøa ®å",
					coordinateOptions = new uint[1, 2] { { 40600u, 79654u } }
				},
				new MapTravelPoint
				{
					pointName = "HIEUTHUOC",
					coordinateOptions = new uint[1, 2] { { 41539u, 80225u } }
				},
				new MapTravelPoint
				{
					pointName = "B\u00b8n thuèc",
					coordinateOptions = new uint[1, 2] { { 41539u, 80225u } }
				},
				new MapTravelPoint
				{
					pointName = "Thî rÌn",
					coordinateOptions = new uint[1, 2] { { 41238u, 81085u } }
				}
			}
		};
		ref TravelMapEntry reference353 = ref array2[19];
		reference353 = new TravelMapEntry
		{
			mapName = "Hoa S¬n",
			mapId = 2,
			gstruct24_0 = new MapTravelPoint[1]
			{
				new MapTravelPoint
				{
					pointName = "DÞch tr¹m Xa phu",
					coordinateOptions = new uint[1, 2] { { 83745u, 114757u } }
				}
			}
		};
		ref TravelMapEntry reference354 = ref array2[20];
		reference354 = new TravelMapEntry
		{
			mapName = "Hoa S¬n ph\u00b8i",
			mapId = 333,
			gstruct24_0 = new MapTravelPoint[5]
			{
				new MapTravelPoint
				{
					pointName = "HiÖu thuèc chiÕn tr\u00adêng",
					coordinateOptions = new uint[1, 2] { { 40544u, 103808u } }
				},
				new MapTravelPoint
				{
					pointName = "¤ng chñ d\u00adîc ®iÕm",
					coordinateOptions = new uint[1, 2] { { 40544u, 103808u } }
				},
				new MapTravelPoint
				{
					pointName = "HIEUTHUOC",
					coordinateOptions = new uint[1, 2] { { 40544u, 103808u } }
				},
				new MapTravelPoint
				{
					pointName = "Thñ khè",
					coordinateOptions = new uint[1, 2] { { 40800u, 103456u } }
				},
				new MapTravelPoint
				{
					pointName = "R\u00ad¬ng chøa ®å",
					coordinateOptions = new uint[1, 2] { { 40800u, 103456u } }
				}
			}
		};
		ref TravelMapEntry reference355 = ref array2[21];
		reference355 = new TravelMapEntry
		{
			mapName = "Héi tr\u00adêng liªn",
			mapId = 540,
			gstruct24_0 = new MapTravelPoint[5]
			{
				new MapTravelPoint
				{
					pointName = "Xa phu",
					coordinateOptions = new uint[1, 2] { { 46752u, 96704u } }
				},
				new MapTravelPoint
				{
					pointName = "HIEUTHUOC",
					coordinateOptions = new uint[1, 2] { { 49792u, 97600u } }
				},
				new MapTravelPoint
				{
					pointName = "¤ng chñ d\u00adîc ®iÕm",
					coordinateOptions = new uint[1, 2] { { 49792u, 97600u } }
				},
				new MapTravelPoint
				{
					pointName = "Chñ d\u00adîc ®iÕm",
					coordinateOptions = new uint[1, 2] { { 49792u, 97600u } }
				},
				new MapTravelPoint
				{
					pointName = "R\u00ad¬ng chøa ®å",
					coordinateOptions = new uint[1, 2] { { 48704u, 98656u } }
				}
			}
		};
		ref TravelMapEntry reference356 = ref array2[22];
		reference356 = new TravelMapEntry
		{
			mapName = "Héi tr\u00adêng liªn",
			mapId = 541,
			gstruct24_0 = new MapTravelPoint[5]
			{
				new MapTravelPoint
				{
					pointName = "Xa phu",
					coordinateOptions = new uint[1, 2] { { 46752u, 96704u } }
				},
				new MapTravelPoint
				{
					pointName = "HIEUTHUOC",
					coordinateOptions = new uint[1, 2] { { 49792u, 97600u } }
				},
				new MapTravelPoint
				{
					pointName = "¤ng chñ d\u00adîc ®iÕm",
					coordinateOptions = new uint[1, 2] { { 49792u, 97600u } }
				},
				new MapTravelPoint
				{
					pointName = "Chñ d\u00adîc ®iÕm",
					coordinateOptions = new uint[1, 2] { { 49792u, 97600u } }
				},
				new MapTravelPoint
				{
					pointName = "R\u00ad¬ng chøa ®å",
					coordinateOptions = new uint[1, 2] { { 48704u, 98656u } }
				}
			}
		};
		ref TravelMapEntry reference357 = ref array2[23];
		reference357 = new TravelMapEntry
		{
			mapName = "Héi tr\u00adêng liªn",
			mapId = 542,
			gstruct24_0 = new MapTravelPoint[5]
			{
				new MapTravelPoint
				{
					pointName = "Xa phu",
					coordinateOptions = new uint[1, 2] { { 46752u, 96704u } }
				},
				new MapTravelPoint
				{
					pointName = "HIEUTHUOC",
					coordinateOptions = new uint[1, 2] { { 49792u, 97600u } }
				},
				new MapTravelPoint
				{
					pointName = "¤ng chñ d\u00adîc ®iÕm",
					coordinateOptions = new uint[1, 2] { { 49792u, 97600u } }
				},
				new MapTravelPoint
				{
					pointName = "Chñ d\u00adîc ®iÕm",
					coordinateOptions = new uint[1, 2] { { 49792u, 97600u } }
				},
				new MapTravelPoint
				{
					pointName = "R\u00ad¬ng chøa ®å",
					coordinateOptions = new uint[1, 2] { { 48704u, 98656u } }
				}
			}
		};
		ref TravelMapEntry reference358 = ref array2[24];
		TravelMapEntry gStruct175 = new TravelMapEntry
		{
			mapName = "§Êu Tr\u00adêng Sinh",
			mapId = 999
		};
		array3 = new MapTravelPoint[18];
		ref MapTravelPoint reference359 = ref array3[0];
		MapTravelPoint gStruct176 = new MapTravelPoint
		{
			pointName = "NgoaiThanh"
		};
		uint[,] array_163 = new uint[4, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_163, 205322);
		gStruct176.coordinateOptions = array_163;
		reference359 = gStruct176;
		ref MapTravelPoint reference360 = ref array3[1];
		reference360 = new MapTravelPoint
		{
			pointName = "Sø gi¶ m«n ph\u00b8i",
			coordinateOptions = new uint[1, 2] { { 55808u, 98304u } }
		};
		ref MapTravelPoint reference361 = ref array3[2];
		reference361 = new MapTravelPoint
		{
			pointName = "Xa phu c«ng thµnh",
			coordinateOptions = new uint[1, 2] { { 54144u, 102784u } }
		};
		ref MapTravelPoint reference362 = ref array3[3];
		MapTravelPoint gStruct177 = new MapTravelPoint
		{
			pointName = "Xa phu"
		};
		uint[,] array_164 = new uint[4, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_164, 205439);
		gStruct177.coordinateOptions = array_164;
		reference362 = gStruct177;
		ref MapTravelPoint reference363 = ref array3[4];
		MapTravelPoint gStruct178 = new MapTravelPoint
		{
			pointName = "Xa Phu Hoµng Kim"
		};
		uint[,] array_165 = new uint[4, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_165, 205484);
		gStruct178.coordinateOptions = array_165;
		reference363 = gStruct178;
		ref MapTravelPoint reference364 = ref array3[5];
		MapTravelPoint gStruct179 = new MapTravelPoint
		{
			pointName = "R\u00ad¬ng chøa"
		};
		uint[,] array_166 = new uint[3, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_166, 205529);
		gStruct179.coordinateOptions = array_166;
		reference364 = gStruct179;
		ref MapTravelPoint reference365 = ref array3[6];
		reference365 = new MapTravelPoint
		{
			pointName = "Chñ TiÒn trang",
			coordinateOptions = new uint[1, 2] { { 53267u, 102674u } }
		};
		ref MapTravelPoint reference366 = ref array3[7];
		reference366 = new MapTravelPoint
		{
			pointName = "V\u00ad¬ng ThiÕt T\u00adîng",
			coordinateOptions = new uint[1, 2] { { 54877u, 99328u } }
		};
		ref MapTravelPoint reference367 = ref array3[8];
		reference367 = new MapTravelPoint
		{
			pointName = "Khóc ThiÕt T\u00adîng",
			coordinateOptions = new uint[1, 2] { { 55903u, 97604u } }
		};
		ref MapTravelPoint reference368 = ref array3[9];
		reference368 = new MapTravelPoint
		{
			pointName = "Thî rÌn",
			coordinateOptions = new uint[1, 2] { { 55903u, 97604u } }
		};
		ref MapTravelPoint reference369 = ref array3[10];
		reference369 = new MapTravelPoint
		{
			pointName = "D· TÈu",
			coordinateOptions = new uint[1, 2] { { 55537u, 99223u } }
		};
		ref MapTravelPoint reference370 = ref array3[11];
		reference370 = new MapTravelPoint
		{
			pointName = "Chñ tiÖm t¹p hãa",
			coordinateOptions = new uint[1, 2] { { 57176u, 99283u } }
		};
		ref MapTravelPoint reference371 = ref array3[12];
		reference371 = new MapTravelPoint
		{
			pointName = "¤ng chñ d\u00adîc ®iÕm",
			coordinateOptions = new uint[1, 2] { { 56809u, 98897u } }
		};
		ref MapTravelPoint reference372 = ref array3[13];
		reference372 = new MapTravelPoint
		{
			pointName = "HIEUTHUOC",
			coordinateOptions = new uint[1, 2] { { 56809u, 98897u } }
		};
		ref MapTravelPoint reference373 = ref array3[14];
		reference373 = new MapTravelPoint
		{
			pointName = "B\u00b8n ngùa",
			coordinateOptions = new uint[1, 2] { { 54815u, 96940u } }
		};
		ref MapTravelPoint reference374 = ref array3[15];
		reference374 = new MapTravelPoint
		{
			pointName = "NhiÕp ThÝ TrÇn",
			coordinateOptions = new uint[1, 2] { { 52704u, 97600u } }
		};
		ref MapTravelPoint reference375 = ref array3[16];
		reference375 = new MapTravelPoint
		{
			pointName = "DÞch quan",
			coordinateOptions = new uint[1, 2] { { 51279u, 96030u } }
		};
		ref MapTravelPoint reference376 = ref array3[17];
		reference376 = new MapTravelPoint
		{
			pointName = "VÖ binh thµnh m«n",
			coordinateOptions = new uint[1, 2] { { 51279u, 96030u } }
		};
		gStruct175.gstruct24_0 = array3;
		reference358 = gStruct175;
		ref TravelMapEntry reference377 = ref array2[25];
		reference377 = new TravelMapEntry
		{
			mapName = "ÊÔ½£¹È",
			mapId = 949,
			gstruct24_0 = new MapTravelPoint[5]
			{
				new MapTravelPoint
				{
					pointName = "Phu xe",
					coordinateOptions = new uint[1, 2] { { 51264u, 101984u } }
				},
				new MapTravelPoint
				{
					pointName = "Xa phu",
					coordinateOptions = new uint[1, 2] { { 51264u, 101984u } }
				},
				new MapTravelPoint
				{
					pointName = "HIEUTHUOC",
					coordinateOptions = new uint[1, 2] { { 50496u, 100608u } }
				},
				new MapTravelPoint
				{
					pointName = "¤ng chñ d\u00adîc ®iÕm",
					coordinateOptions = new uint[1, 2] { { 50496u, 100608u } }
				},
				new MapTravelPoint
				{
					pointName = "LiÔu D\u00adîc S\u00ad ",
					coordinateOptions = new uint[1, 2] { { 50496u, 100608u } }
				}
			}
		};
		ref TravelMapEntry reference378 = ref array2[26];
		TravelMapEntry gStruct180 = new TravelMapEntry
		{
			mapName = "Cæ Loa Thµnh",
			mapId = 977
		};
		array3 = new MapTravelPoint[5];
		ref MapTravelPoint reference379 = ref array3[0];
		MapTravelPoint gStruct181 = new MapTravelPoint
		{
			pointName = "HIEUTHUOC"
		};
		uint[,] array_167 = new uint[13, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_167, 206202);
		gStruct181.coordinateOptions = array_167;
		reference379 = gStruct181;
		ref MapTravelPoint reference380 = ref array3[1];
		MapTravelPoint gStruct182 = new MapTravelPoint
		{
			pointName = "¤ng chñ d\u00adîc ®iÕm"
		};
		uint[,] array_168 = new uint[4, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_168, 206319);
		gStruct182.coordinateOptions = array_168;
		reference380 = gStruct182;
		ref MapTravelPoint reference381 = ref array3[2];
		MapTravelPoint gStruct183 = new MapTravelPoint
		{
			pointName = "D\u00adîc §iÕm"
		};
		uint[,] array_169 = new uint[9, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_169, 206364);
		gStruct183.coordinateOptions = array_169;
		reference381 = gStruct183;
		ref MapTravelPoint reference382 = ref array3[3];
		MapTravelPoint gStruct184 = new MapTravelPoint
		{
			pointName = "R\u00ad¬ng chøa ®å"
		};
		uint[,] array_170 = new uint[4, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_170, 206449);
		gStruct184.coordinateOptions = array_170;
		reference382 = gStruct184;
		ref MapTravelPoint reference383 = ref array3[4];
		MapTravelPoint gStruct185 = new MapTravelPoint
		{
			pointName = "RUONGDO"
		};
		uint[,] array_171 = new uint[4, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_171, 206494);
		gStruct185.coordinateOptions = array_171;
		reference383 = gStruct185;
		gStruct180.gstruct24_0 = array3;
		reference378 = gStruct180;
		ref TravelMapEntry reference384 = ref array2[27];
		TravelMapEntry gStruct186 = new TravelMapEntry
		{
			mapName = "Ph\u00adîng Hoµng Th",
			mapId = 989
		};
		array3 = new MapTravelPoint[15];
		ref MapTravelPoint reference385 = ref array3[0];
		MapTravelPoint gStruct187 = new MapTravelPoint
		{
			pointName = "NgoaiThanh"
		};
		uint[,] array_172 = new uint[4, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_172, 206551);
		gStruct187.coordinateOptions = array_172;
		reference385 = gStruct187;
		ref MapTravelPoint reference386 = ref array3[1];
		MapTravelPoint gStruct188 = new MapTravelPoint
		{
			pointName = "Xa phu"
		};
		uint[,] array_173 = new uint[4, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_173, 206596);
		gStruct188.coordinateOptions = array_173;
		reference386 = gStruct188;
		ref MapTravelPoint reference387 = ref array3[2];
		MapTravelPoint gStruct189 = new MapTravelPoint
		{
			pointName = "R\u00ad¬ng chøa ®å"
		};
		uint[,] array_174 = new uint[5, 2];
		EmbeddedResourceDataReader.CopyLengthPrefixedBlock(array_174, 206641);
		gStruct189.coordinateOptions = array_174;
		reference387 = gStruct189;
		ref MapTravelPoint reference388 = ref array3[3];
		reference388 = new MapTravelPoint
		{
			pointName = "Chñ TiÒn trang",
			coordinateOptions = new uint[1, 2] { { 48938u, 103230u } }
		};
		ref MapTravelPoint reference389 = ref array3[4];
		reference389 = new MapTravelPoint
		{
			pointName = "Thî rÌn",
			coordinateOptions = new uint[1, 2] { { 49678u, 102940u } }
		};
		ref MapTravelPoint reference390 = ref array3[5];
		reference390 = new MapTravelPoint
		{
			pointName = "D· TÈu",
			coordinateOptions = new uint[1, 2] { { 51006u, 105324u } }
		};
		ref MapTravelPoint reference391 = ref array3[6];
		reference391 = new MapTravelPoint
		{
			pointName = "LÔ Quan",
			coordinateOptions = new uint[1, 2] { { 49323u, 103880u } }
		};
		ref MapTravelPoint reference392 = ref array3[7];
		reference392 = new MapTravelPoint
		{
			pointName = "ThÇn bÝ Th\u00ad¬ng Nh©n",
			coordinateOptions = new uint[1, 2] { { 49791u, 101861u } }
		};
		ref MapTravelPoint reference393 = ref array3[8];
		reference393 = new MapTravelPoint
		{
			pointName = "Vâ L©m truyÒn nh©n",
			coordinateOptions = new uint[1, 2] { { 51481u, 104206u } }
		};
		ref MapTravelPoint reference394 = ref array3[9];
		reference394 = new MapTravelPoint
		{
			pointName = "Chñ tiÖm t¹p hãa",
			coordinateOptions = new uint[1, 2] { { 52144u, 104333u } }
		};
		ref MapTravelPoint reference395 = ref array3[10];
		reference395 = new MapTravelPoint
		{
			pointName = "¤ng chñ d\u00adîc ®iÕm",
			coordinateOptions = new uint[1, 2] { { 51590u, 103816u } }
		};
		ref MapTravelPoint reference396 = ref array3[11];
		reference396 = new MapTravelPoint
		{
			pointName = "HIEUTHUOC",
			coordinateOptions = new uint[1, 2] { { 51590u, 103816u } }
		};
		ref MapTravelPoint reference397 = ref array3[12];
		reference397 = new MapTravelPoint
		{
			pointName = "B\u00b8n ngùa",
			coordinateOptions = new uint[1, 2] { { 50086u, 102232u } }
		};
		ref MapTravelPoint reference398 = ref array3[13];
		reference398 = new MapTravelPoint
		{
			pointName = "NhiÕp ThÝ TrÇn",
			coordinateOptions = new uint[1, 2] { { 48350u, 102630u } }
		};
		ref MapTravelPoint reference399 = ref array3[14];
		reference399 = new MapTravelPoint
		{
			pointName = "DÞch quan",
			coordinateOptions = new uint[1, 2] { { 50773u, 107826u } }
		};
		gStruct186.gstruct24_0 = array3;
		reference384 = gStruct186;
		ref TravelMapEntry reference400 = ref array2[28];
		reference400 = new TravelMapEntry
		{
			mapName = "X\u00b8m Hèi §éng",
			mapId = 901,
			gstruct24_0 = new MapTravelPoint[1]
			{
				new MapTravelPoint
				{
					pointName = "Xa phu",
					coordinateOptions = new uint[1, 2] { { 52832u, 102112u } }
				}
			}
		};
		gstruct27_0 = array2;
	}

	public static int ResolveMappedRouteMapId(int int_1)
	{
		for (int i = 0; i < MapRouteCatalog.routeMapIdAliases.GetLength(0); i++)
		{
			if (int_1 == MapRouteCatalog.routeMapIdAliases[i, 1])
			{
				return MapRouteCatalog.routeMapIdAliases[i, 0];
			}
		}
		return 0;
	}

	public static bool IsMapIn586To604Range(int int_1)
	{
		return 586 <= int_1 && int_1 <= 604;
	}

	public static uint[] GetMap586To604ReferenceCoordinate(int int_1)
	{
		if (!IsMapIn586To604Range(int_1))
		{
			return null;
		}
		switch (int_1)
		{
		case 586:
			return new uint[2] { 54976u, 105728u };
		case 587:
		case 588:
			return new uint[2] { 54976u, 105888u };
		case 589:
			return new uint[2] { 55040u, 105888u };
		case 590:
			return new uint[2] { 54848u, 105792u };
		case 591:
			return new uint[2] { 54720u, 106144u };
		default:
			return new uint[2] { 54976u, 105728u };
		case 593:
			return new uint[2] { 54816u, 105696u };
		case 594:
			return new uint[2] { 54784u, 105632u };
		}
	}

	public static int FindConfiguredTravelMapIdIndex(int int_1)
	{
		for (int i = 0; i < int_0.Length; i++)
		{
			if (int_1 == int_0[i])
			{
				return i;
			}
		}
		return -1;
	}

	public static MapTravelConnection FindTravelConnection(int sourceMapId, int destinationMapId)
	{
		for (int i = 0; i < travelConnections.GetLength(0); i++)
		{
			if (sourceMapId == travelConnections[i].sourceMapId && destinationMapId == travelConnections[i].destinationMapId)
			{
				return travelConnections[i];
			}
		}
		return new MapTravelConnection
		{
			sourceMapId = 0,
			destinationMapId = 0
		};
	}

	public static MapTravelConnection FindTravelConnectionExcludingDestinations(int sourceMapId, int[] excludedDestinationMapIds = null)
	{
		for (int i = 0; i < travelConnections.GetLength(0); i++)
		{
			if (sourceMapId != travelConnections[i].sourceMapId)
			{
				continue;
			}
			bool flag = true;
			if (excludedDestinationMapIds != null)
			{
				for (int j = 0; j < excludedDestinationMapIds.Length; j++)
				{
					if (excludedDestinationMapIds[j] == travelConnections[i].destinationMapId)
					{
						flag = false;
						break;
					}
				}
			}
			if (flag)
			{
				return travelConnections[i];
			}
		}
		return new MapTravelConnection
		{
			sourceMapId = 0,
			destinationMapId = 0
		};
	}

	public static MapTravelConnection FindTravelConnectionByEndpoint(int mapId, bool matchDestinationEndpoint)
	{
		for (int i = 0; i < travelConnections.GetLength(0); i++)
		{
			if ((!matchDestinationEndpoint && mapId == travelConnections[i].sourceMapId) || (matchDestinationEndpoint && mapId == travelConnections[i].destinationMapId))
			{
				return travelConnections[i];
			}
		}
		return new MapTravelConnection
		{
			sourceMapId = 0,
			destinationMapId = 0
		};
	}

	public static void ExpandNamedPointDataForMapAliases(int[,] int_1, int int_2 = 0)
	{
		while (int_1 != null && int_1.GetLength(0) > int_2)
		{
			if (int_2 < 0)
			{
				int_2 = 0;
			}
			int num = int_1[int_2, 0];
			int num2 = -1;
			for (int i = 0; i < gstruct27_0.Length; i++)
			{
				if (gstruct27_0[i].mapId == num)
				{
					num2 = i;
					break;
				}
			}
			if (num2 >= 0)
			{
				int num3 = int_1[int_2, 1];
				for (int j = 0; j < gstruct27_0.Length; j++)
				{
					if (gstruct27_0[j].mapId == num3)
					{
						num3 = 0;
						break;
					}
				}
				if (num3 > 0)
				{
					Array.Resize(ref gstruct27_0, gstruct27_0.Length + 1);
					ref TravelMapEntry reference = ref gstruct27_0[gstruct27_0.Length - 1];
					reference = gstruct27_0[num2];
					gstruct27_0[gstruct27_0.Length - 1].mapId = num3;
					gstruct27_0[gstruct27_0.Length - 1].mapName = null;
				}
			}
			int_2++;
		}
	}

	private static int[,] RankRouteGroupsByDistance(CoordinateRouteCandidate[] routeCandidates, uint[] uint_1)
	{
		if (routeCandidates != null && uint_1 != null)
		{
			int length = routeCandidates.GetLength(0);
			switch (length)
			{
			default:
			{
				int[,] array = new int[length, 2];
				for (int i = 0; i < routeCandidates.GetLength(0); i++)
				{
					array[i, 0] = i;
					array[i, 1] = (int)GameAutomationUtility.GetNearestCoordinateSquaredDistance(routeCandidates[i].routeCoordinates, uint_1);
				}
				for (int j = 0; j < length; j++)
				{
					while (true)
					{
						int num = 0;
						while (num < length)
						{
							if (array[num, 1] <= array[j, 1])
							{
								num++;
								continue;
							}
							goto IL_00a3;
						}
						break;
						IL_00a3:
						int num2 = array[num, 0];
						int num3 = array[num, 1];
						array[num, 0] = array[j, 0];
						array[num, 1] = array[j, 1];
						array[j, 0] = num2;
						array[j, 1] = num3;
					}
				}
				return array;
			}
			case 1:
				return new int[1, 2] { 
				{
					0,
					(int)GameAutomationUtility.GetNearestCoordinateSquaredDistance(routeCandidates[0].routeCoordinates, uint_1)
				} };
			case 0:
				return null;
			}
		}
		return null;
	}

	private static uint[,] GetNearestRouteGroupCoordinates(CoordinateRouteCandidate[] routeCandidates, uint[] uint_1)
	{
		if (routeCandidates != null && uint_1 != null)
		{
			int num = -1;
			long num2 = 0L;
			for (int i = 0; i < routeCandidates.GetLength(0); i++)
			{
				long num3 = GameAutomationUtility.GetNearestCoordinateSquaredDistance(routeCandidates[i].routeCoordinates, uint_1);
				if (num < 0 || num3 < num2)
				{
					num = i;
					num2 = num3;
				}
			}
			return routeCandidates[num].routeCoordinates;
		}
		return null;
	}

	public static uint[,] SelectBestRouteCoordinates(CoordinateRouteCandidate[] routeCandidates, uint[] uint_1, uint[] uint_2, int int_1 = 60000)
	{
		int[,] array = RankRouteGroupsByDistance(routeCandidates, uint_2);
		if (array == null)
		{
			return null;
		}
		if (array.GetLength(0) != 1)
		{
			int num = -1;
			long num2 = 0L;
			for (int i = 0; i < array.GetLength(0); i++)
			{
				if (num < 0)
				{
					num = array[i, 0];
					num2 = GameAutomationUtility.GetNearestCoordinateSquaredDistance(routeCandidates[num].routeCoordinates, uint_1);
				}
				else if (array[i, 1] <= int_1 && array[i, 1] > 0)
				{
					long num3 = GameAutomationUtility.GetNearestCoordinateSquaredDistance(routeCandidates[array[i, 0]].routeCoordinates, uint_1);
					if (num3 <= num2)
					{
						num = array[i, 0];
						num2 = num3;
					}
				}
			}
			return routeCandidates[num].routeCoordinates;
		}
		return routeCandidates[0].routeCoordinates;
	}

	public static uint[] FindNearestNamedMapPointCoordinates(uint[] uint_1, object object_0, string string_0, bool bool_0 = true)
	{
		int num = -1;
		string text = null;
		string text2 = null;
		int num2 = MapNavigationHelper.FindNavigationEntryIndex(object_0);
		if (0 <= num2)
		{
			text = MapNavigationProfileProvider.mapNavigationEntry_0[num2].string_0;
			text2 = MapNavigationProfileProvider.mapNavigationEntry_0[num2].string_2;
			num = MapNavigationProfileProvider.mapNavigationEntry_0[num2].int_0;
		}
		else
		{
			string[] array = typeof(string).ToString().Split('.');
			string value = array[array.Length - 1].ToUpper();
			string text3 = object_0.GetType().ToString().ToUpper();
			if (text3.IndexOf(value) <= 0)
			{
				num = CommonUtility.ParseInt32OrZero(object_0.ToString());
				text = GameMapCatalog.GetMapName(num);
			}
			else
			{
				text = object_0.ToString();
			}
		}
		if (text != null && string_0 != null && uint_1 != null)
		{
			int num3 = ResolveMappedRouteMapId(num);
			if (num3 > 0)
			{
				num = num3;
			}
			for (int i = 0; i < gstruct27_0.Length; i++)
			{
				if ((num <= 0 || num != gstruct27_0[i].mapId) && !(text == gstruct27_0[i].mapName) && !(text2 == gstruct27_0[i].mapName) && (bool_0 || (0 > CommonUtility.FindSubstringIndex(text, gstruct27_0[i].mapName) && 0 > CommonUtility.FindSubstringIndex(gstruct27_0[i].mapName, text) && 0 > CommonUtility.FindSubstringIndex(gstruct27_0[i].mapName, text2) && 0 > CommonUtility.FindSubstringIndex(text2, gstruct27_0[i].mapName))))
				{
					continue;
				}
				MapTravelPoint[] gstruct24_ = gstruct27_0[i].gstruct24_0;
				for (int j = 0; j < gstruct24_.Length; j++)
				{
					string string_1 = gstruct24_[j].pointName;
					bool flag = string_1 == string_0;
					bool flag2 = 0 <= CommonUtility.FindSubstringIndex(string_1, string_0);
					bool flag3 = 0 <= CommonUtility.FindSubstringIndex(string_0, string_1);
					if (!flag && (bool_0 || (!flag2 && !flag3)))
					{
						continue;
					}
					uint[,] array2 = gstruct24_[j].coordinateOptions;
					int num4 = -1;
					long num5 = 0L;
					long num6 = 0L;
					for (int k = 0; k < array2.GetLength(0); k++)
					{
						num6 = GameAutomationUtility.GetSquaredCoordinateDistance(uint_1, new uint[2]
						{
							array2[k, 0],
							array2[k, 1]
						});
						if (num4 < 0 || num6 < num5)
						{
							num4 = k;
							num5 = num6;
						}
					}
					if (num4 < 0)
					{
						break;
					}
					return new uint[2]
					{
						array2[num4, 0],
						array2[num4, 1]
					};
				}
				break;
			}
			return null;
		}
		return null;
	}

	public static uint[] GetFirstNamedMapPointCoordinates(int int_1, string string_0, bool bool_0 = false)
	{
		for (int i = 0; i < gstruct27_0.Length; i++)
		{
			if (int_1 != gstruct27_0[i].mapId)
			{
				continue;
			}
			MapTravelPoint[] gstruct24_ = gstruct27_0[i].gstruct24_0;
			for (int j = 0; j < gstruct24_.Length; j++)
			{
				string string_1 = gstruct24_[j].pointName;
				bool flag = string_1 == string_0;
				bool flag2 = 0 <= CommonUtility.FindSubstringIndex(string_1, string_0);
				bool flag3 = 0 <= CommonUtility.FindSubstringIndex(string_0, string_1);
				if (flag || (!bool_0 && (flag2 || flag3)))
				{
					uint[,] array = gstruct24_[j].coordinateOptions;
					return new uint[2]
					{
						array[0, 0],
						array[0, 1]
					};
				}
			}
			break;
		}
		return null;
	}
}
